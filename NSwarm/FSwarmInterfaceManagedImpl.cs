// Decompiled with JetBrains decompiler
// Type: NSwarm.FSwarmInterfaceManagedImpl
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using AgentInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using System.Windows.Forms;

namespace NSwarm
{
  internal class FSwarmInterfaceManagedImpl : IDisposable
  {
    private Process AgentProcess = (Process) null;
    private int AgentProcessOwner = 0;
    private IAgentInterfaceWrapper Connection = (IAgentInterfaceWrapper) null;
    private int ConnectionHandle = Constants.INVALID;
    private Thread ConnectionMessageThread = (Thread) null;
    private Thread ConnectionMonitorThread = (Thread) null;
    private __FnPtr<void (FMessage*, void*)> ConnectionCallback = (__FnPtr<void (FMessage*, void*)>) 0L;
    private unsafe void* ConnectionCallbackData;
    private ELogFlags ConnectionLoggingFlags;
    private AgentConfiguration ConnectionConfiguration = (AgentConfiguration) null;
    private object CleanupClosedConnectionLock;
    private ReaderWriterDictionary<int, FSwarmInterfaceManagedImpl.ChannelInfo> OpenChannels;
    private Stack<byte[]> FreeChannelWriteBuffers;
    private int BaseChannelHandle = 0;
    private List<AgentTaskSpecification> PendingTasks = (List<AgentTaskSpecification>) null;
    private string AgentCacheFolder;
    private TcpClientChannel NetworkChannel = (TcpClientChannel) null;
    private PerfTimer PerfTimerInstance = (PerfTimer) null;

    public FSwarmInterfaceManagedImpl()
    {
      this.OpenChannels = new ReaderWriterDictionary<int, FSwarmInterfaceManagedImpl.ChannelInfo>();
      this.FreeChannelWriteBuffers = new Stack<byte[]>();
      this.CleanupClosedConnectionLock = new object();
    }

    private void \u007EFSwarmInterfaceManagedImpl()
    {
    }

    public virtual unsafe int OpenConnection(
      __FnPtr<void (FMessage*, void*)> CallbackFunc,
      void* CallbackData,
      ELogFlags LoggingFlags)
    {
      if ((LoggingFlags & ELogFlags.LOG_TIMINGS) == ELogFlags.LOG_TIMINGS)
        this.PerfTimerInstance = new PerfTimer();
      this.PerfTimerInstance?.Start("OpenConnection-Managed", 1, 0L);
      this.ConnectionHandle = Constants.INVALID;
      int num = Constants.INVALID;
      try
      {
        Debug.WriteLineIf(Debugger.IsAttached, "[OpenConnection] Registering TCP channel ...");
        TcpClientChannel tcpClientChannel = new TcpClientChannel();
        this.NetworkChannel = tcpClientChannel;
        ChannelServices.RegisterChannel((IChannel) tcpClientChannel, false);
        this.EnsureAgentIsRunning();
        if (this.AgentProcess != null)
        {
          Debug.WriteLineIf(Debugger.IsAttached, "[OpenConnection] Connecting to agent ...");
          num = this.TryOpenConnection(CallbackFunc, CallbackData, LoggingFlags);
          if (num >= 0)
          {
            string agentCachePath = this.ConnectionConfiguration.AgentCachePath;
            this.AgentCacheFolder = agentCachePath;
            if (agentCachePath.Length == 0)
            {
              this.CloseConnection();
              num = Constants.ERROR_FILE_FOUND_NOT;
            }
          }
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLineIf(Debugger.IsAttached, "[OpenConnection] Error: " + ex.Message);
        num = Constants.ERROR_EXCEPTION;
      }
      if (num >= 0)
        this.ConnectionHandle = num;
      else
        this.CleanupClosedConnection();
      this.PerfTimerInstance?.Stop();
      return this.ConnectionHandle;
    }

    public virtual int CloseConnection()
    {
      this.DumpTimings();
      this.PerfTimerInstance?.Start("CloseConnection-Managed", 1, 0L);
      int invalid = Constants.INVALID;
      int num;
      if (this.Connection != null)
      {
        try
        {
          this.StartTiming("CloseConnection-Remote", 0);
          this.Connection.CloseConnection(this.ConnectionHandle);
          this.StopTiming();
          num = Constants.SUCCESS;
        }
        catch (Exception ex)
        {
          num = Constants.ERROR_EXCEPTION;
          Debug.WriteLineIf(Debugger.IsAttached, "[CloseConnection] Error: " + ex.Message);
        }
        this.CleanupClosedConnection();
        if (!this.ConnectionMessageThread.Join(1000))
        {
          Debug.WriteLineIf(Debugger.IsAttached, "[CloseConnection] Error: Message queue thread failed to quit before timeout, killing.");
          this.ConnectionMessageThread.Abort();
        }
        this.ConnectionMessageThread = (Thread) null;
        if (!this.ConnectionMonitorThread.Join(0))
          this.ConnectionMonitorThread.Abort();
        this.ConnectionMonitorThread = (Thread) null;
      }
      else
        num = Constants.ERROR_CONNECTION_NOT_FOUND;
      this.PerfTimerInstance?.Stop();
      return num;
    }

    public virtual unsafe int SendMessage(FMessage* NativeMessage)
    {
      this.PerfTimerInstance?.Start("SendMessage-Managed", 1, 0L);
      int num1 = Constants.INVALID;
      if (this.Connection != null)
      {
        AgentMessage NewMessage = (AgentMessage) null;
        if (*(int*) NativeMessage == 16)
        {
          int num2 = *(int*) ((IntPtr) NativeMessage + 4L);
          switch (num2)
          {
            case 1:
              AgentInfoMessage agentInfoMessage = new AgentInfoMessage();
              ulong num3 = (ulong) *(long*) ((IntPtr) NativeMessage + 8L);
              if (num3 != 0UL)
                agentInfoMessage.TextMessage = new string((char*) num3);
              NewMessage = (AgentMessage) agentInfoMessage;
              break;
            case 2:
              AgentAlertMessage agentAlertMessage = new AgentAlertMessage(new AgentGuid((uint) *(int*) ((IntPtr) NativeMessage + 8L), (uint) *(int*) ((IntPtr) NativeMessage + 12L), (uint) *(int*) ((IntPtr) NativeMessage + 16L), (uint) *(int*) ((IntPtr) NativeMessage + 20L)));
              agentAlertMessage.AlertLevel = (EAlertLevel) *(int*) ((IntPtr) NativeMessage + 24L);
              AgentGuid agentGuid = new AgentGuid((uint) *(int*) ((IntPtr) NativeMessage + 28L), (uint) *(int*) ((IntPtr) NativeMessage + 32L), (uint) *(int*) ((IntPtr) NativeMessage + 36L), (uint) *(int*) ((IntPtr) NativeMessage + 40L));
              agentAlertMessage.ObjectGuid = agentGuid;
              agentAlertMessage.TypeId = *(int*) ((IntPtr) NativeMessage + 44L);
              ulong num4 = (ulong) *(long*) ((IntPtr) NativeMessage + 48L);
              if (num4 != 0UL)
                agentAlertMessage.TextMessage = new string((char*) num4);
              NewMessage = (AgentMessage) agentAlertMessage;
              break;
            case 3:
              NewMessage = (AgentMessage) new AgentTimingMessage((EProgressionState) *(int*) ((IntPtr) NativeMessage + 8L), *(int*) ((IntPtr) NativeMessage + 12L));
              break;
            case 512:
              break;
            case 768:
              AgentTaskState agentTaskState = new AgentTaskState((AgentGuid) null, new AgentGuid((uint) *(int*) ((IntPtr) NativeMessage + 8L), (uint) *(int*) ((IntPtr) NativeMessage + 12L), (uint) *(int*) ((IntPtr) NativeMessage + 16L), (uint) *(int*) ((IntPtr) NativeMessage + 20L)), (EJobTaskState) *(int*) ((IntPtr) NativeMessage + 24L));
              agentTaskState.TaskExitCode = *(int*) ((IntPtr) NativeMessage + 40L);
              agentTaskState.TaskRunningTime = *(double*) ((IntPtr) NativeMessage + 48L);
              ulong num5 = (ulong) *(long*) ((IntPtr) NativeMessage + 32L);
              if (num5 != 0UL)
                agentTaskState.TaskMessage = new string((char*) num5);
              NewMessage = (AgentMessage) agentTaskState;
              break;
            default:
              NewMessage = new AgentMessage((EMessageType) num2);
              break;
          }
        }
        if (NewMessage != null)
        {
          try
          {
            this.StartTiming("SendMessage-Remote", 0);
            this.Connection.SendMessage(this.ConnectionHandle, NewMessage);
            this.StopTiming();
            num1 = Constants.SUCCESS;
          }
          catch (Exception ex)
          {
            this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:SendMessage] Error: " + ex.Message);
            num1 = Constants.ERROR_CONNECTION_DISCONNECTED;
            this.CleanupClosedConnection();
          }
        }
      }
      else
        num1 = Constants.ERROR_CONNECTION_NOT_FOUND;
      this.PerfTimerInstance?.Stop();
      return num1;
    }

    public virtual unsafe int AddChannel(char* FullPath, char* ChannelName)
    {
      this.PerfTimerInstance?.Start("AddChannel-Managed", 1, 0L);
      int invalid = Constants.INVALID;
      int num;
      if (this.Connection != null)
      {
        string FullPath1 = new string(FullPath);
        string ChannelName1 = new string(ChannelName);
        try
        {
          this.StartTiming("AddChannel-Remote", 0);
          num = this.Connection.AddChannel(this.ConnectionHandle, FullPath1, ChannelName1);
          this.StopTiming();
        }
        catch (Exception ex)
        {
          this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:AddChannel] Error: " + ex.Message);
          num = Constants.ERROR_CONNECTION_DISCONNECTED;
          this.CleanupClosedConnection();
        }
      }
      else
        num = Constants.ERROR_CONNECTION_NOT_FOUND;
      this.PerfTimerInstance?.Stop();
      return num;
    }

    public virtual unsafe int TestChannel(char* ChannelName)
    {
      this.PerfTimerInstance?.Start("TestChannel-Managed", 1, 0L);
      int invalid = Constants.INVALID;
      int num;
      if (this.Connection != null)
      {
        string str = new string(ChannelName);
        try
        {
          if (!this.ConnectionConfiguration.IsPureLocalConnection)
          {
            this.StartTiming("TestChannel-Remote", 0);
            num = this.Connection.TestChannel(this.ConnectionHandle, str);
            this.StopTiming();
          }
          else
            num = !File.Exists(this.GenerateFullChannelName(str, (TChannelFlags) 17)) ? Constants.ERROR_FILE_FOUND_NOT : Constants.SUCCESS;
        }
        catch (Exception ex)
        {
          this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:TestChannel] Error: " + ex.Message);
          num = Constants.ERROR_CONNECTION_DISCONNECTED;
          this.CleanupClosedConnection();
        }
      }
      else
        num = Constants.ERROR_CONNECTION_NOT_FOUND;
      this.PerfTimerInstance?.Stop();
      return num;
    }

    public virtual unsafe int OpenChannel(char* ChannelName, TChannelFlags ChannelFlags)
    {
      this.PerfTimerInstance?.Start("OpenChannel-Managed", 1, 0L);
      int invalid = Constants.INVALID;
      int num1 = 0;
      int num2;
      if (this.Connection != null)
      {
        try
        {
          string str = new string(ChannelName);
          if (!this.ConnectionConfiguration.IsPureLocalConnection)
          {
            this.StartTiming("OpenChannel-Remote", 0);
            num2 = this.Connection.OpenChannel(this.ConnectionHandle, str, (EChannelFlags) ChannelFlags);
            this.StopTiming();
          }
          else
            num2 = Interlocked.Increment(ref this.BaseChannelHandle);
          if (num2 >= 0)
          {
            FSwarmInterfaceManagedImpl.ChannelInfo channelInfo = new FSwarmInterfaceManagedImpl.ChannelInfo();
            channelInfo.ChannelName = str;
            channelInfo.ChannelFlags = ChannelFlags;
            channelInfo.ChannelHandle = num2;
            channelInfo.ChannelFileStream = (Stream) null;
            channelInfo.ChannelData = (byte[]) null;
            channelInfo.ChannelOffset = 0;
            string fullChannelName = this.GenerateFullChannelName(str, ChannelFlags);
            if ((ChannelFlags & (TChannelFlags) 32) != (TChannelFlags) 0)
            {
              FileStream fileStream = new FileStream(fullChannelName, FileMode.Create, FileAccess.Write, FileShare.None);
              channelInfo.ChannelFileStream = (Stream) fileStream;
              if ((ChannelFlags & (TChannelFlags) 131072) != (TChannelFlags) 0)
              {
                Stream stream = (Stream) fileStream;
                channelInfo.ChannelFileStream = (Stream) new GZipStream(stream, CompressionMode.Compress, false);
              }
              Monitor.Enter((object) this.FreeChannelWriteBuffers);
              try
              {
                channelInfo.ChannelData = this.FreeChannelWriteBuffers.Count <= 0 ? new byte[1048576] : this.FreeChannelWriteBuffers.Pop();
              }
              finally
              {
                Monitor.Exit((object) this.FreeChannelWriteBuffers);
              }
              this.OpenChannels.Add(num2, channelInfo);
              num1 = 1;
            }
            else if ((ChannelFlags & (TChannelFlags) 16) != (TChannelFlags) 0)
            {
              if (File.Exists(fullChannelName))
              {
                if ((ChannelFlags & (TChannelFlags) 131072) != (TChannelFlags) 0)
                {
                  byte[] buffer = File.ReadAllBytes(fullChannelName);
                  byte[] numArray = buffer;
                  int int32 = BitConverter.ToInt32(numArray, numArray.Length - 4);
                  channelInfo.ChannelData = new byte[int32];
                  Stream stream = (Stream) new GZipStream((Stream) new MemoryStream(buffer), CompressionMode.Decompress, false);
                  stream.Read(channelInfo.ChannelData, 0, int32);
                  stream.Close();
                }
                else
                  channelInfo.ChannelData = File.ReadAllBytes(fullChannelName);
                this.OpenChannels.Add(num2, channelInfo);
                num1 = 1;
              }
              else
                num2 = Constants.ERROR_CHANNEL_NOT_FOUND;
            }
          }
        }
        catch (Exception ex)
        {
          this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:OpenChannel] Error: " + ex.ToString());
          num2 = Constants.ERROR_CONNECTION_DISCONNECTED;
          this.CleanupClosedConnection();
        }
        if (num2 >= 0 && num1 == 0)
        {
          if (!this.ConnectionConfiguration.IsPureLocalConnection)
          {
            this.PerfTimerInstance?.Start("CloseChannel-Remote", 0, 0L);
            try
            {
              this.Connection.CloseChannel(this.ConnectionHandle, num2);
            }
            catch (Exception ex)
            {
              this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:OpenChannel] Cleanup error: " + ex.Message);
              this.CleanupClosedConnection();
            }
            this.PerfTimerInstance?.Stop();
          }
          num2 = Constants.ERROR_CHANNEL_IO_FAILED;
        }
      }
      else
        num2 = Constants.ERROR_CONNECTION_NOT_FOUND;
      this.PerfTimerInstance?.Stop();
      return num2;
    }

    public virtual int CloseChannel(int Channel)
    {
      this.PerfTimerInstance?.Start("CloseChannel-Managed", 1, 0L);
      int invalid = Constants.INVALID;
      int num;
      if (this.Connection != null)
      {
        FSwarmInterfaceManagedImpl.ChannelInfo ChannelToFlush = (FSwarmInterfaceManagedImpl.ChannelInfo) null;
        if (this.OpenChannels.TryGetValue(Channel, ref ChannelToFlush))
        {
          try
          {
            if ((ChannelToFlush.ChannelFlags & (TChannelFlags) 32) != (TChannelFlags) 0)
            {
              this.FlushChannel(ChannelToFlush);
              Monitor.Enter((object) this.FreeChannelWriteBuffers);
              try
              {
                this.FreeChannelWriteBuffers.Push(ChannelToFlush.ChannelData);
              }
              finally
              {
                Monitor.Exit((object) this.FreeChannelWriteBuffers);
              }
            }
            this.OpenChannels.Remove(Channel);
            if (ChannelToFlush.ChannelFileStream != null)
            {
              ChannelToFlush.ChannelFileStream.Close();
              ChannelToFlush.ChannelFileStream = (Stream) null;
            }
            if (!this.ConnectionConfiguration.IsPureLocalConnection)
            {
              this.StartTiming("CloseChannel-Remote", 0);
              this.Connection.CloseChannel(this.ConnectionHandle, ChannelToFlush.ChannelHandle);
              this.StopTiming();
            }
            else
            {
              TChannelFlags channelFlags = ChannelToFlush.ChannelFlags;
              if ((channelFlags & (TChannelFlags) 1) != (TChannelFlags) 0 && (channelFlags & (TChannelFlags) 32) != (TChannelFlags) 0)
              {
                string fullChannelName1 = this.GenerateFullChannelName(ChannelToFlush.ChannelName, (TChannelFlags) 33);
                string fullChannelName2 = this.GenerateFullChannelName(ChannelToFlush.ChannelName, (TChannelFlags) 17);
                FileInfo fileInfo = new FileInfo(fullChannelName2);
                if (fileInfo.Exists)
                {
                  fileInfo.IsReadOnly = false;
                  fileInfo.Delete();
                }
                if ((ChannelToFlush.ChannelFlags & (TChannelFlags) 65536) != (TChannelFlags) 0)
                  File.Copy(fullChannelName1, fullChannelName2);
                else
                  File.Move(fullChannelName1, fullChannelName2);
              }
            }
            num = Constants.SUCCESS;
          }
          catch (Exception ex)
          {
            this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:CloseChannel] Error: " + ex.Message);
            num = Constants.ERROR_CONNECTION_DISCONNECTED;
            this.CleanupClosedConnection();
          }
        }
        else
          num = Constants.ERROR_CHANNEL_NOT_FOUND;
      }
      else
        num = Constants.ERROR_CONNECTION_NOT_FOUND;
      this.PerfTimerInstance?.Stop();
      return num;
    }

    public virtual unsafe int WriteChannel(int Channel, void* Data, int DataSize)
    {
      this.PerfTimerInstance?.Start("WriteChannel-Managed", 1, (long) DataSize);
      int num1 = Constants.INVALID;
      if (this.Connection != null)
      {
        FSwarmInterfaceManagedImpl.ChannelInfo ChannelToFlush = (FSwarmInterfaceManagedImpl.ChannelInfo) null;
        if (this.OpenChannels.TryGetValue(Channel, ref ChannelToFlush))
        {
          if (ChannelToFlush.ChannelFileStream != null)
          {
            try
            {
              int num2 = 0;
              if (ChannelToFlush.ChannelData != null)
              {
                // ISSUE: variable of a reference type
                byte* local1 = ref ChannelToFlush.ChannelData[0];
                // ISSUE: variable of a reference type
                byte* local2;
                // ISSUE: fault handler
                try
                {
                  int channelOffset = ChannelToFlush.ChannelOffset;
                  if (channelOffset + DataSize <= ChannelToFlush.ChannelData.Length)
                  {
                    // ISSUE: cpblk instruction
                    __memcpy((long) channelOffset + local1, (IntPtr) Data, (long) DataSize);
                    ChannelToFlush.ChannelOffset += DataSize;
                    num1 = DataSize;
                    num2 = 1;
                  }
                  else
                  {
                    this.FlushChannel(ChannelToFlush);
                    if (DataSize <= ChannelToFlush.ChannelData.Length)
                    {
                      // ISSUE: cpblk instruction
                      __memcpy(local1, (IntPtr) Data, (long) DataSize);
                      ChannelToFlush.ChannelOffset = DataSize;
                      num1 = DataSize;
                      num2 = 1;
                    }
                  }
                }
                __fault
                {
                  // ISSUE: cast to a reference type
                  local2 = (byte*) 0L;
                }
                // ISSUE: cast to a reference type
                local2 = (byte*) 0L;
                if (num2 != 0)
                  goto label_20;
              }
              try
              {
                byte[] buffer = new byte[DataSize];
                // ISSUE: variable of a reference type
                byte* local1 = ref buffer[0];
                // ISSUE: variable of a reference type
                byte* local2;
                // ISSUE: fault handler
                try
                {
                  // ISSUE: cpblk instruction
                  __memcpy(local1, (IntPtr) Data, (long) DataSize);
                }
                __fault
                {
                  // ISSUE: cast to a reference type
                  local2 = (byte*) 0L;
                }
                // ISSUE: cast to a reference type
                local2 = (byte*) 0L;
                ChannelToFlush.ChannelFileStream.Write(buffer, 0, DataSize);
                num1 = DataSize;
              }
              catch (Exception ex)
              {
                this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:WriteChannel] Error: " + ex.Message);
                num1 = Constants.ERROR_CHANNEL_IO_FAILED;
              }
            }
            catch (Exception ex)
            {
              this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:WriteChannel] Error: " + ex.Message);
              num1 = Constants.ERROR_CONNECTION_DISCONNECTED;
              this.CleanupClosedConnection();
            }
label_20:
            if (num1 < 0)
            {
              this.OpenChannels.Remove(Channel);
              try
              {
                ChannelToFlush.ChannelFileStream.Close();
                ChannelToFlush.ChannelFileStream = (Stream) null;
                goto label_26;
              }
              catch (Exception ex)
              {
                this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:WriteChannel] Error: " + ex.Message);
                num1 = Constants.ERROR_CONNECTION_DISCONNECTED;
                this.CleanupClosedConnection();
                goto label_26;
              }
            }
            else
              goto label_26;
          }
        }
        num1 = Constants.ERROR_CHANNEL_NOT_FOUND;
      }
      else
        num1 = Constants.ERROR_CONNECTION_NOT_FOUND;
label_26:
      this.PerfTimerInstance?.Stop();
      return num1;
    }

    public virtual unsafe int ReadChannel(int Channel, void* Data, int DataSize)
    {
      this.PerfTimerInstance?.Start("ReadChannel-Managed", 1, (long) DataSize);
      int invalid = Constants.INVALID;
      int num1;
      if (this.Connection != null)
      {
        FSwarmInterfaceManagedImpl.ChannelInfo channelInfo = (FSwarmInterfaceManagedImpl.ChannelInfo) null;
        if (this.OpenChannels.TryGetValue(Channel, ref channelInfo))
        {
          if (channelInfo.ChannelData != null)
          {
            try
            {
              byte[] channelData = channelInfo.ChannelData;
              int num2 = channelData.Length - channelInfo.ChannelOffset;
              if (num2 >= 0)
              {
                int num3 = num2 < DataSize ? num2 : DataSize;
                if (num3 > 0)
                {
                  fixed (byte* numPtr = &channelData[0])
                  {
                    // ISSUE: variable of a reference type
                    byte* local;
                    // ISSUE: fault handler
                    try
                    {
                      long channelOffset = (long) channelInfo.ChannelOffset;
                      // ISSUE: cast to a reference type
                      // ISSUE: cpblk instruction
                      __memcpy((IntPtr) Data, (byte*) numPtr + channelOffset, (long) num3);
                      channelInfo.ChannelOffset += num3;
                    }
                    __fault
                    {
                      // ISSUE: cast to a reference type
                      local = (byte*) 0L;
                    }
                    // ISSUE: cast to a reference type
                    local = (byte*) 0L;
                  }
                }
                num1 = num3;
              }
              else
                num1 = Constants.ERROR_CHANNEL_IO_FAILED;
            }
            catch (Exception ex)
            {
              this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:ReadChannel] Error: " + ex.Message);
              num1 = Constants.ERROR_CONNECTION_DISCONNECTED;
              this.CleanupClosedConnection();
            }
            if (num1 < 0)
            {
              this.OpenChannels.Remove(Channel);
              goto label_18;
            }
            else
              goto label_18;
          }
        }
        num1 = Constants.ERROR_CHANNEL_NOT_FOUND;
      }
      else
        num1 = Constants.ERROR_CONNECTION_NOT_FOUND;
label_18:
      this.PerfTimerInstance?.Stop();
      return num1;
    }

    public virtual unsafe int OpenJob(FGuid* JobGuid)
    {
      this.PerfTimerInstance?.Start("OpenJob-Managed", 1, 0L);
      int invalid = Constants.INVALID;
      int num;
      if (this.Connection != null)
      {
        this.PerfTimerInstance?.Start("OpenJob-Remote", 0, 0L);
        try
        {
          AgentGuid JobGuid1 = new AgentGuid((uint) *(int*) JobGuid, (uint) *(int*) ((IntPtr) JobGuid + 4L), (uint) *(int*) ((IntPtr) JobGuid + 8L), (uint) *(int*) ((IntPtr) JobGuid + 12L));
          num = this.Connection.OpenJob(this.ConnectionHandle, JobGuid1);
          if (num >= 0)
          {
            this.ConnectionConfiguration.AgentJobGuid = JobGuid1;
            this.PendingTasks = new List<AgentTaskSpecification>();
          }
        }
        catch (Exception ex)
        {
          this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:OpenJob] Error: " + ex.Message);
          num = Constants.ERROR_CONNECTION_DISCONNECTED;
          this.CleanupClosedConnection();
        }
        this.PerfTimerInstance?.Stop();
      }
      else
        num = Constants.ERROR_CONNECTION_NOT_FOUND;
      this.PerfTimerInstance?.Stop();
      return num;
    }

    public virtual unsafe int BeginJobSpecification(
      FJobSpecification* Specification32,
      FJobSpecification* Specification64)
    {
      this.PerfTimerInstance?.Start("BeginJobSpecification-Managed", 1, 0L);
      int num1 = Constants.INVALID;
      if (this.Connection != null)
      {
        if (this.ConnectionConfiguration.AgentJobGuid != null)
        {
          AgentJobSpecification jobSpecification1 = this.ConvertJobSpecification(Specification32, false);
          AgentJobSpecification jobSpecification2 = this.ConvertJobSpecification(Specification64, true);
          if (jobSpecification1 != null)
            num1 = this.CacheAllFiles(jobSpecification1);
          if (jobSpecification2 != null)
          {
            if (jobSpecification1 == null || num1 >= 0)
              num1 = this.CacheAllFiles(jobSpecification2);
            else
              goto label_29;
          }
          if (num1 >= 0)
          {
            Hashtable Description32 = (Hashtable) null;
            Hashtable Description64 = (Hashtable) null;
            if ((uint) *(int*) ((IntPtr) Specification32 + 72L) > 0U)
            {
              try
              {
                Description32 = new Hashtable();
                Description32[(object) "Version"] = (object) 16;
                for (uint index = 0; index < (uint) *(int*) ((IntPtr) Specification32 + 72L); ++index)
                {
                  long num2 = (long) index * 8L;
                  string str1 = new string((char*) *(long*) (*(long*) ((IntPtr) Specification32 + 56L) + num2));
                  string str2 = new string((char*) *(long*) (*(long*) ((IntPtr) Specification32 + 64L) + num2));
                  Description32[(object) str1] = (object) str2;
                }
              }
              catch (Exception ex)
              {
                this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:BeginJobSpecification] Error with Specification32 Description: " + ex.Message);
                Description32 = (Hashtable) null;
              }
            }
            if ((uint) *(int*) ((IntPtr) Specification64 + 72L) > 0U)
            {
              try
              {
                Description64 = new Hashtable();
                Description64[(object) "Version"] = (object) 16;
                for (uint index = 0; index < (uint) *(int*) ((IntPtr) Specification64 + 72L); ++index)
                {
                  long num2 = (long) index * 8L;
                  string str1 = new string((char*) *(long*) (*(long*) ((IntPtr) Specification64 + 56L) + num2));
                  string str2 = new string((char*) *(long*) (*(long*) ((IntPtr) Specification64 + 64L) + num2));
                  Description64[(object) str1] = (object) str2;
                }
              }
              catch (Exception ex)
              {
                this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:BeginJobSpecification] Error with Specification64 Description: " + ex.Message);
                Description64 = (Hashtable) null;
              }
            }
            this.PerfTimerInstance?.Start("BeginJobSpecification-Remote", 0, 0L);
            try
            {
              num1 = this.Connection.BeginJobSpecification(this.ConnectionHandle, jobSpecification1, Description32, jobSpecification2, Description64);
            }
            catch (Exception ex)
            {
              this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:BeginJobSpecification] Error: " + ex.Message);
              num1 = Constants.ERROR_CONNECTION_DISCONNECTED;
              this.CleanupClosedConnection();
            }
            this.PerfTimerInstance?.Stop();
          }
        }
        else
          num1 = Constants.ERROR_JOB_NOT_FOUND;
      }
      else
        num1 = Constants.ERROR_CONNECTION_NOT_FOUND;
label_29:
      this.PerfTimerInstance?.Stop();
      return num1;
    }

    public virtual unsafe int AddTask(FTaskSpecification* Specification)
    {
      this.PerfTimerInstance?.Start("AddTask-Managed", 1, 0L);
      int invalid = Constants.INVALID;
      int num1;
      if (this.Connection != null)
      {
        if (this.ConnectionConfiguration.AgentJobGuid != null)
        {
          AgentGuid TaskTaskGuid = new AgentGuid((uint) *(int*) ((IntPtr) Specification + 12L), (uint) *(int*) ((IntPtr) Specification + 16L), (uint) *(int*) ((IntPtr) Specification + 20L), (uint) *(int*) ((IntPtr) Specification + 24L));
          string TaskParameters = new string((char*) *(long*) ((IntPtr) Specification + 32L));
          List<string> TaskDependencies = (List<string>) null;
          if ((uint) *(int*) ((IntPtr) Specification + 56L) > 0U)
          {
            TaskDependencies = new List<string>();
            uint num2 = 0;
            if (0U < (uint) *(int*) ((IntPtr) Specification + 56L))
            {
              FTaskSpecification* ftaskSpecificationPtr = (FTaskSpecification*) ((IntPtr) Specification + 48L);
              long num3 = 0;
              do
              {
                TaskDependencies.Add(new string((char*) *(long*) (*(long*) ftaskSpecificationPtr + num3)));
                ++num2;
                num3 += 8L;
              }
              while (num2 < (uint) *(int*) ((IntPtr) Specification + 56L));
            }
          }
          AgentTaskSpecification TaskSpecification = new AgentTaskSpecification(this.ConnectionConfiguration.AgentJobGuid, TaskTaskGuid, *(int*) ((IntPtr) Specification + 40L), TaskParameters, *(int*) ((IntPtr) Specification + 44L), TaskDependencies);
          num1 = this.CacheAllFiles(TaskSpecification);
          if (num1 >= 0)
            this.PendingTasks.Add(TaskSpecification);
        }
        else
          num1 = Constants.ERROR_JOB_NOT_FOUND;
      }
      else
        num1 = Constants.ERROR_CONNECTION_NOT_FOUND;
      this.PerfTimerInstance?.Stop();
      return num1;
    }

    public virtual int EndJobSpecification()
    {
      this.PerfTimerInstance?.Start("EndJobSpecification-Managed", 1, 0L);
      int invalid = Constants.INVALID;
      int num;
      if (this.Connection != null)
      {
        if (this.ConnectionConfiguration.AgentJobGuid != null)
        {
          this.PerfTimerInstance?.Start("EndJobSpecification-Remote", 0, 0L);
          try
          {
            num = this.Connection.AddTask(this.ConnectionHandle, this.PendingTasks);
            if (num >= 0)
              num = this.Connection.EndJobSpecification(this.ConnectionHandle);
          }
          catch (Exception ex)
          {
            this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:EndJobSpecification] Error: " + ex.Message);
            num = Constants.ERROR_CONNECTION_DISCONNECTED;
            this.CleanupClosedConnection();
          }
          this.PendingTasks = (List<AgentTaskSpecification>) null;
          this.PerfTimerInstance?.Stop();
        }
        else
          num = Constants.ERROR_JOB_NOT_FOUND;
      }
      else
        num = Constants.ERROR_CONNECTION_NOT_FOUND;
      this.PerfTimerInstance?.Stop();
      return num;
    }

    public virtual int CloseJob()
    {
      this.PerfTimerInstance?.Start("CloseJob-Managed", 1, 0L);
      int invalid = Constants.INVALID;
      int num;
      if (this.Connection != null)
      {
        if (this.ConnectionConfiguration.AgentJobGuid != null)
        {
          this.PerfTimerInstance?.Start("CloseJob-Remote", 0, 0L);
          try
          {
            num = this.Connection.CloseJob(this.ConnectionHandle);
          }
          catch (Exception ex)
          {
            this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:CloseJob] Error: " + ex.Message);
            num = Constants.ERROR_CONNECTION_DISCONNECTED;
            this.CleanupClosedConnection();
          }
          this.PerfTimerInstance?.Stop();
          try
          {
            this.ConnectionConfiguration.AgentJobGuid = (AgentGuid) null;
          }
          catch (Exception ex)
          {
          }
        }
        else
          num = Constants.ERROR_JOB_NOT_FOUND;
      }
      else
        num = Constants.ERROR_CONNECTION_NOT_FOUND;
      this.PerfTimerInstance?.Stop();
      return num;
    }

    public virtual int Log(EVerbosityLevel Verbosity, Color TextColour, string Message)
    {
      try
      {
        this.Connection.Log(Verbosity, TextColour, Message);
      }
      catch (Exception ex)
      {
      }
      return Constants.SUCCESS;
    }

    public static unsafe void MessageThreadProc(object ThreadParameters)
    {
      MessageThreadData messageThreadData = (MessageThreadData) ThreadParameters;
      IAgentInterfaceWrapper connection = messageThreadData.Connection;
      try
      {
        for (AgentMessage NextMessage = (AgentMessage) null; connection.GetMessage(messageThreadData.ConnectionHandle, ref NextMessage, -1) >= 0; NextMessage = (AgentMessage) null)
        {
          if (NextMessage.Version == ESwarmVersionValue.VER_1_0)
          {
            FMessage* fmessagePtr1 = (FMessage*) 0L;
            // ISSUE: cast to a reference type
            // ISSUE: variable of a reference type
            char* local1 = (char*) 0L;
            // ISSUE: variable of a reference type
            char* local2;
            // ISSUE: fault handler
            try
            {
              FMessage* fmessagePtr2;
              switch (NextMessage.Type)
              {
                case EMessageType.INFO:
                  AgentInfoMessage agentInfoMessage = (AgentInfoMessage) NextMessage;
                  FInfoMessage* finfoMessagePtr1 = (FInfoMessage*) \u003CModule\u003E.@new(16UL);
                  FInfoMessage* finfoMessagePtr2;
                  // ISSUE: fault handler
                  try
                  {
                    finfoMessagePtr2 = (IntPtr) finfoMessagePtr1 == IntPtr.Zero ? (FInfoMessage*) 0L : \u003CModule\u003E.NSwarm\u002EFInfoMessage\u002E\u007Bctor\u007D(finfoMessagePtr1, (char*) &\u003CModule\u003E.\u003FA0x28ecff6c\u002Eunnamed\u002Dglobal\u002D0);
                  }
                  __fault
                  {
                    \u003CModule\u003E.delete((void*) finfoMessagePtr1);
                  }
                  if (agentInfoMessage.TextMessage != (string) null)
                  {
                    char[] charArray = agentInfoMessage.TextMessage.ToCharArray();
                    if (charArray.Length > 0)
                    {
                      fixed (char* chPtr = &charArray[0])
                        *(long*) ((IntPtr) finfoMessagePtr2 + 8L) = (long) chPtr;
                    }
                  }
                  fmessagePtr2 = (FMessage*) finfoMessagePtr2;
                  break;
                case EMessageType.ALERT:
                  AgentAlertMessage agentAlertMessage = (AgentAlertMessage) NextMessage;
                  AgentGuid jobGuid1 = agentAlertMessage.JobGuid;
                  FGuid fguid1;
                  \u003CModule\u003E.NSwarm\u002EFGuid\u002E\u007Bctor\u007D(&fguid1, jobGuid1.A, jobGuid1.B, jobGuid1.C, jobGuid1.D);
                  AgentGuid objectGuid = agentAlertMessage.ObjectGuid;
                  FGuid fguid2;
                  \u003CModule\u003E.NSwarm\u002EFGuid\u002E\u007Bctor\u007D(&fguid2, objectGuid.A, objectGuid.B, objectGuid.C, objectGuid.D);
                  FAlertMessage* falertMessagePtr1 = (FAlertMessage*) \u003CModule\u003E.@new(56UL);
                  FAlertMessage* falertMessagePtr2;
                  // ISSUE: fault handler
                  try
                  {
                    falertMessagePtr2 = (IntPtr) falertMessagePtr1 == IntPtr.Zero ? (FAlertMessage*) 0L : \u003CModule\u003E.NSwarm\u002EFAlertMessage\u002E\u007Bctor\u007D(falertMessagePtr1, &fguid1, (TAlertLevel) agentAlertMessage.AlertLevel, &fguid2, agentAlertMessage.TypeId);
                  }
                  __fault
                  {
                    \u003CModule\u003E.delete((void*) falertMessagePtr1);
                  }
                  if (agentAlertMessage.TextMessage != (string) null)
                  {
                    char[] charArray = agentAlertMessage.TextMessage.ToCharArray();
                    if (charArray.Length > 0)
                    {
                      fixed (char* chPtr = &charArray[0])
                        *(long*) ((IntPtr) falertMessagePtr2 + 48L) = (long) chPtr;
                    }
                  }
                  fmessagePtr2 = (FMessage*) falertMessagePtr2;
                  break;
                case EMessageType.JOB_STATE:
                  AgentJobState agentJobState = (AgentJobState) NextMessage;
                  AgentGuid jobGuid2 = agentJobState.JobGuid;
                  FGuid NewJobGuid;
                  \u003CModule\u003E.NSwarm\u002EFGuid\u002E\u007Bctor\u007D(&NewJobGuid, jobGuid2.A, jobGuid2.B, jobGuid2.C, jobGuid2.D);
                  FJobState* fjobStatePtr1 = (FJobState*) \u003CModule\u003E.@new(56UL);
                  FJobState* fjobStatePtr2;
                  // ISSUE: fault handler
                  try
                  {
                    fjobStatePtr2 = (IntPtr) fjobStatePtr1 == IntPtr.Zero ? (FJobState*) 0L : \u003CModule\u003E.NSwarm\u002EFJobState\u002E\u007Bctor\u007D(fjobStatePtr1, NewJobGuid, (TJobTaskState) agentJobState.JobState);
                  }
                  __fault
                  {
                    \u003CModule\u003E.delete((void*) fjobStatePtr1);
                  }
                  *(int*) ((IntPtr) fjobStatePtr2 + 40L) = agentJobState.JobExitCode;
                  *(double*) ((IntPtr) fjobStatePtr2 + 48L) = agentJobState.JobRunningTime;
                  if (agentJobState.JobMessage != (string) null)
                  {
                    char[] charArray = agentJobState.JobMessage.ToCharArray();
                    if (charArray.Length > 0)
                    {
                      fixed (char* chPtr = &charArray[0])
                        *(long*) ((IntPtr) fjobStatePtr2 + 32L) = (long) chPtr;
                    }
                  }
                  fmessagePtr2 = (FMessage*) fjobStatePtr2;
                  break;
                case EMessageType.TASK_REQUEST:
label_51:
                  if (NextMessage.Type == EMessageType.QUIT)
                  {
                    Debug.WriteLineIf(Debugger.IsAttached, "Message queue thread shutting down from a QUIT message");
                    goto label_54;
                  }
                  else
                    goto label_55;
                case EMessageType.TASK_REQUEST_RESPONSE:
                  AgentTaskRequestResponse taskRequestResponse = (AgentTaskRequestResponse) NextMessage;
                  ETaskRequestResponseType responseType = taskRequestResponse.ResponseType;
                  switch (responseType)
                  {
                    case ETaskRequestResponseType.RELEASE:
                    case ETaskRequestResponseType.RESERVATION:
                      FTaskRequestResponse* ftaskRequestResponsePtr1 = (FTaskRequestResponse*) \u003CModule\u003E.@new(12UL);
                      FTaskRequestResponse* ftaskRequestResponsePtr2;
                      // ISSUE: fault handler
                      try
                      {
                        ftaskRequestResponsePtr2 = (IntPtr) ftaskRequestResponsePtr1 == IntPtr.Zero ? (FTaskRequestResponse*) 0L : \u003CModule\u003E.NSwarm\u002EFTaskRequestResponse\u002E\u007Bctor\u007D(ftaskRequestResponsePtr1, (TTaskRequestResponseType) responseType);
                      }
                      __fault
                      {
                        \u003CModule\u003E.delete((void*) ftaskRequestResponsePtr1);
                      }
                      fmessagePtr2 = (FMessage*) ftaskRequestResponsePtr2;
                      break;
                    case ETaskRequestResponseType.SPECIFICATION:
                      AgentTaskSpecification taskSpecification = (AgentTaskSpecification) taskRequestResponse;
                      AgentGuid taskGuid1 = taskSpecification.TaskGuid;
                      FGuid TaskTaskGuid;
                      \u003CModule\u003E.NSwarm\u002EFGuid\u002E\u007Bctor\u007D(&TaskTaskGuid, taskGuid1.A, taskGuid1.B, taskGuid1.C, taskGuid1.D);
                      TJobTaskFlags taskFlags = (TJobTaskFlags) taskSpecification.TaskFlags;
                      char[] charArray1 = taskSpecification.Parameters.ToCharArray();
                      if (charArray1.Length > 0)
                        local1 = ref charArray1[0];
                      FTaskSpecification* ftaskSpecificationPtr1 = (FTaskSpecification*) \u003CModule\u003E.@new(64UL);
                      FTaskSpecification* ftaskSpecificationPtr2;
                      // ISSUE: fault handler
                      try
                      {
                        ftaskSpecificationPtr2 = (IntPtr) ftaskSpecificationPtr1 == IntPtr.Zero ? (FTaskSpecification*) 0L : \u003CModule\u003E.NSwarm\u002EFTaskSpecification\u002E\u007Bctor\u007D(ftaskSpecificationPtr1, TaskTaskGuid, (char*) local1, taskFlags);
                      }
                      __fault
                      {
                        \u003CModule\u003E.delete((void*) ftaskSpecificationPtr1);
                      }
                      fmessagePtr2 = (FMessage*) ftaskSpecificationPtr2;
                      break;
                    default:
                      goto label_51;
                  }
                  break;
                case EMessageType.TASK_STATE:
                  AgentTaskState agentTaskState = (AgentTaskState) NextMessage;
                  AgentGuid taskGuid2 = agentTaskState.TaskGuid;
                  FGuid NewTaskGuid;
                  \u003CModule\u003E.NSwarm\u002EFGuid\u002E\u007Bctor\u007D(&NewTaskGuid, taskGuid2.A, taskGuid2.B, taskGuid2.C, taskGuid2.D);
                  FTaskState* ftaskStatePtr1 = (FTaskState*) \u003CModule\u003E.@new(56UL);
                  FTaskState* ftaskStatePtr2;
                  // ISSUE: fault handler
                  try
                  {
                    ftaskStatePtr2 = (IntPtr) ftaskStatePtr1 == IntPtr.Zero ? (FTaskState*) 0L : \u003CModule\u003E.NSwarm\u002EFTaskState\u002E\u007Bctor\u007D(ftaskStatePtr1, NewTaskGuid, (TJobTaskState) agentTaskState.TaskState);
                  }
                  __fault
                  {
                    \u003CModule\u003E.delete((void*) ftaskStatePtr1);
                  }
                  if (agentTaskState.TaskMessage != (string) null)
                  {
                    char[] charArray2 = agentTaskState.TaskMessage.ToCharArray();
                    if (charArray2.Length > 0)
                    {
                      fixed (char* chPtr = &charArray2[0])
                        *(long*) ((IntPtr) ftaskStatePtr2 + 32L) = (long) chPtr;
                    }
                  }
                  fmessagePtr2 = (FMessage*) ftaskStatePtr2;
                  break;
                default:
                  FMessage* fmessagePtr3 = (FMessage*) \u003CModule\u003E.@new(8UL);
                  FMessage* fmessagePtr4;
                  // ISSUE: fault handler
                  try
                  {
                    fmessagePtr4 = (IntPtr) fmessagePtr3 == IntPtr.Zero ? (FMessage*) 0L : \u003CModule\u003E.NSwarm\u002EFMessage\u002E\u007Bctor\u007D(fmessagePtr3, (TSwarmVersionValue) 16, (TMessageType) NextMessage.Type);
                  }
                  __fault
                  {
                    \u003CModule\u003E.delete((void*) fmessagePtr3);
                  }
                  fmessagePtr2 = fmessagePtr4;
                  break;
              }
              if ((IntPtr) fmessagePtr2 != IntPtr.Zero)
              {
                FMessage* fmessagePtr5 = fmessagePtr2;
                void* connectionCallbackData = messageThreadData.ConnectionCallbackData;
                // ISSUE: function pointer call
                __calli(messageThreadData.ConnectionCallback)((void*) fmessagePtr5, (FMessage*) connectionCallbackData);
                \u003CModule\u003E.delete((void*) fmessagePtr2);
                fmessagePtr1 = (FMessage*) 0L;
                goto label_51;
              }
              else
                goto label_51;
            }
            __fault
            {
              // ISSUE: cast to a reference type
              local2 = (char*) 0L;
            }
label_54:
            // ISSUE: cast to a reference type
            local2 = (char*) 0L;
            return;
label_55:
            // ISSUE: cast to a reference type
            local2 = (char*) 0L;
          }
        }
      }
      catch (ThreadAbortException ex)
      {
        Debug.WriteLineIf(Debugger.IsAttached, "Message queue thread shutting down normally after being closed by CloseConnection");
      }
      catch (Exception ex)
      {
        Debug.WriteLineIf(Debugger.IsAttached, "Error: Exception in the message queue thread: " + ex.Message);
        Debug.WriteLineIf(Debugger.IsAttached, "MessageThreadProc calling CleanupClosedConnection");
        messageThreadData.Owner.CleanupClosedConnection();
      }
      Debug.WriteLineIf(Debugger.IsAttached, "Message queue thread shutting down normally");
    }

    public static void MonitorThreadProc(object ThreadParameters)
    {
      MessageThreadData messageThreadData = (MessageThreadData) ThreadParameters;
      AgentConfiguration connectionConfiguration = messageThreadData.ConnectionConfiguration;
      IAgentInterfaceWrapper connection = messageThreadData.Connection;
      int num1 = 0;
      try
      {
        if (connection != null)
        {
          Process processById = Process.GetProcessById(connectionConfiguration.AgentProcessID);
          if (processById != null)
          {
            int num2 = 1;
            while (num2 != 0)
            {
              Thread.Sleep(1000);
              if (processById.HasExited)
              {
                num1 = 1;
                num2 = 0;
              }
            }
          }
        }
      }
      catch (ThreadAbortException ex)
      {
        Debug.WriteLineIf(Debugger.IsAttached, "Agent monitor thread shutting down normally after being closed by CloseConnection");
      }
      catch (Exception ex)
      {
        Debug.WriteLineIf(Debugger.IsAttached, "Exception in the agent monitor thread: " + ex.Message);
        num1 = 1;
      }
      if (num1 != 0)
      {
        Debug.WriteLineIf(Debugger.IsAttached, "MonitorThreadProc calling CleanupClosedConnection");
        messageThreadData.Owner.CleanupClosedConnection();
      }
      Debug.WriteLineIf(Debugger.IsAttached, "Agent monitor thread shutting down normally");
    }

    public void StartTiming(string Name, int Accum) => this.PerfTimerInstance?.Start(Name, Accum, 0L);

    public void StartTiming(string Name, int Accum, long Adder) => this.PerfTimerInstance?.Start(Name, Accum, Adder);

    public void StopTiming() => this.PerfTimerInstance?.Stop();

    public unsafe void DumpTimings()
    {
      PerfTimer perfTimerInstance = this.PerfTimerInstance;
      if (perfTimerInstance == null)
        return;
      // ISSUE: cast to a reference type
      // ISSUE: variable of a reference type
      byte* local1 = (byte*) perfTimerInstance.DumpTimings();
      if (local1 != null)
        local1 = (long) (uint) RuntimeHelpers.OffsetToStringData + local1;
      // ISSUE: cast to a reference type
      // ISSUE: variable of a reference type
      char* local2 = (char*) local1;
      // ISSUE: fault handler
      try
      {
        char* chPtr = (char*) local2;
        FInfoMessage finfoMessage;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        ^(int&) ref finfoMessage = 16;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        ^(int&) ((IntPtr) &finfoMessage + 4) = 1;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        ^(long&) ((IntPtr) &finfoMessage + 8) = (long) chPtr;
        this.SendMessage((FMessage*) &finfoMessage);
        this.PerfTimerInstance = (PerfTimer) null;
      }
      __fault
      {
        // ISSUE: cast to a reference type
        local2 = (char*) 0L;
      }
      // ISSUE: cast to a reference type
      local2 = (char*) null;
    }

    public unsafe int CleanupClosedConnection()
    {
      Monitor.Enter(this.CleanupClosedConnectionLock);
      Debug.WriteLineIf(Debugger.IsAttached, "[Interface:CleanupClosedConnection] Closing all connections to the Agent");
      this.AgentProcess = (Process) null;
      this.AgentProcessOwner = 0;
      IAgentInterfaceWrapper connection = this.Connection;
      if (connection != null)
      {
        connection.SignalConnectionDropped();
        this.Connection = (IAgentInterfaceWrapper) null;
      }
      this.ConnectionHandle = Constants.INVALID;
      this.ConnectionConfiguration = (AgentConfiguration) null;
      __FnPtr<void (FMessage*, void*)> connectionCallback = this.ConnectionCallback;
      if (connectionCallback != null)
      {
        FMessage fmessage;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        ^(int&) ref fmessage = 16;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        ^(int&) ((IntPtr) &fmessage + 4) = -559030611;
        ref FMessage local = ref fmessage;
        void* connectionCallbackData = this.ConnectionCallbackData;
        // ISSUE: function pointer call
        __calli(connectionCallback)((void*) ref local, (FMessage*) connectionCallbackData);
      }
      // ISSUE: cast to a function pointer type
      this.ConnectionCallback = (__FnPtr<void (FMessage*, void*)>) 0L;
      this.ConnectionCallbackData = (void*) 0L;
      if (this.OpenChannels.Count > 0)
      {
        Dictionary<int, FSwarmInterfaceManagedImpl.ChannelInfo>.ValueCollection.Enumerator enumerator = this.OpenChannels.Values.GetEnumerator();
        if (enumerator.MoveNext())
        {
          do
          {
            FSwarmInterfaceManagedImpl.ChannelInfo current = enumerator.Current;
            Stream channelFileStream = current.ChannelFileStream;
            if (channelFileStream != null)
            {
              channelFileStream.Close();
              current.ChannelFileStream = (Stream) null;
            }
          }
          while (enumerator.MoveNext());
        }
        this.OpenChannels.Clear();
      }
      TcpClientChannel networkChannel = this.NetworkChannel;
      if (networkChannel != null)
      {
        ChannelServices.UnregisterChannel((IChannel) networkChannel);
        this.NetworkChannel = (TcpClientChannel) null;
      }
      Monitor.Exit(this.CleanupClosedConnectionLock);
      return Constants.SUCCESS;
    }

    private unsafe int TryOpenConnection(
      __FnPtr<void (FMessage*, void*)> CallbackFunc,
      void* CallbackData,
      ELogFlags LoggingFlags)
    {
      try
      {
        this.Connection = new IAgentInterfaceWrapper();
        Debug.WriteLineIf(Debugger.IsAttached, "[TryOpenConnection] Testing the Agent");
        Hashtable InParameters = (Hashtable) null;
        Hashtable OutParameters = (Hashtable) null;
        bool flag = false;
        while (!flag)
        {
          try
          {
            this.Connection.Method(0, InParameters, ref OutParameters);
            flag = true;
          }
          catch (Exception ex)
          {
            Debug.WriteLineIf(Debugger.IsAttached, "[TryOpenConnection] Waiting for the agent to start up ...");
            Thread.Sleep(500);
          }
        }
        Debug.WriteLineIf(Debugger.IsAttached, "[TryOpenConnection] Opening Connection to Agent");
        Debug.WriteLineIf(Debugger.IsAttached, "[TryOpenConnection] Local Process ID is " + Process.GetCurrentProcess().Id.ToString());
        this.StartTiming("OpenConnection-Remote", 0);
        FSwarmInterfaceManagedImpl interfaceManagedImpl = this;
        interfaceManagedImpl.ConnectionHandle = interfaceManagedImpl.Connection.OpenConnection(CallbackFunc, CallbackData, LoggingFlags, this.AgentProcess, this.AgentProcessOwner, Process.GetCurrentProcess().Id, ref this.ConnectionConfiguration);
        this.StopTiming();
        if (this.ConnectionHandle >= 0)
        {
          this.Log(EVerbosityLevel.Informative, Color.DarkGreen, "[Interface:TryOpenConnection] Local connection established");
          MessageThreadData messageThreadData = new MessageThreadData();
          messageThreadData.Owner = this;
          messageThreadData.Connection = this.Connection;
          messageThreadData.ConnectionHandle = this.ConnectionHandle;
          messageThreadData.ConnectionCallback = CallbackFunc;
          messageThreadData.ConnectionCallbackData = CallbackData;
          messageThreadData.ConnectionConfiguration = this.ConnectionConfiguration;
          Thread thread1 = new Thread(new ParameterizedThreadStart(FSwarmInterfaceManagedImpl.MessageThreadProc));
          this.ConnectionMessageThread = thread1;
          thread1.Name = "ConnectionMessageThread";
          this.ConnectionMessageThread.Start((object) messageThreadData);
          Thread thread2 = new Thread(new ParameterizedThreadStart(FSwarmInterfaceManagedImpl.MonitorThreadProc));
          this.ConnectionMonitorThread = thread2;
          thread2.Name = "ConnectionMonitorThread";
          this.ConnectionMonitorThread.Start((object) messageThreadData);
          this.ConnectionCallback = CallbackFunc;
          this.ConnectionCallbackData = CallbackData;
          this.ConnectionLoggingFlags = LoggingFlags;
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLineIf(Debugger.IsAttached, "[TryOpenConnection] Error: " + ex.Message);
        this.ConnectionHandle = Constants.INVALID;
        this.Connection = (IAgentInterfaceWrapper) null;
      }
      return this.ConnectionHandle;
    }

    private void EnsureAgentIsRunning()
    {
      this.AgentProcess = (Process) null;
      this.AgentProcessOwner = 0;
      Process[] processesByName = Process.GetProcessesByName("SwarmAgent");
      if (processesByName.Length > 0)
        this.AgentProcess = processesByName[0];
      if (this.AgentProcess != null)
        return;
      Debug.WriteLineIf(Debugger.IsAttached, "[OpenConnection] Spawning agent: " + Application.StartupPath + "\\SwarmAgent.exe");
      if (File.Exists(Application.StartupPath + "\\..\\SwarmAgent.exe"))
      {
        Process process = Process.Start(Application.StartupPath + "\\..\\SwarmAgent.exe");
        this.AgentProcess = process;
        if (process == null)
          Debug.WriteLineIf(Debugger.IsAttached, "[OpenConnection] Failed to start the Agent executable: " + Application.StartupPath + "\\SwarmAgent.exe");
        else
          this.AgentProcessOwner = 1;
      }
      else
        Debug.WriteLineIf(Debugger.IsAttached, "[OpenConnection] Failed to find the Agent executable: " + Application.StartupPath + "\\SwarmAgent.exe");
    }

    private unsafe AgentJobSpecification ConvertJobSpecification(
      FJobSpecification* Specification,
      [MarshalAs(UnmanagedType.U1)] bool bIs64bit)
    {
      ulong num1 = (ulong) *(long*) Specification;
      if (num1 == 0UL)
        return (AgentJobSpecification) null;
      string JobExecutableName = new string((char*) num1);
      string JobParameters = new string((char*) *(long*) ((IntPtr) Specification + 8L));
      int num2 = bIs64bit ? 4 : 0;
      TJobTaskFlags tjobTaskFlags = (TJobTaskFlags) (*(int*) ((IntPtr) Specification + 16L) & -5 | num2);
      List<string> JobRequiredDependencies = (List<string>) null;
      if ((uint) *(int*) ((IntPtr) Specification + 32L) > 0U)
      {
        JobRequiredDependencies = new List<string>();
        uint num3 = 0;
        if (0U < (uint) *(int*) ((IntPtr) Specification + 32L))
        {
          FJobSpecification* fjobSpecificationPtr = (FJobSpecification*) ((IntPtr) Specification + 24L);
          long num4 = 0;
          do
          {
            JobRequiredDependencies.Add(new string((char*) *(long*) (*(long*) fjobSpecificationPtr + num4)));
            ++num3;
            num4 += 8L;
          }
          while (num3 < (uint) *(int*) ((IntPtr) Specification + 32L));
        }
      }
      List<string> JobOptionalDependencies = (List<string>) null;
      if ((uint) *(int*) ((IntPtr) Specification + 48L) > 0U)
      {
        JobOptionalDependencies = new List<string>();
        uint num3 = 0;
        if (0U < (uint) *(int*) ((IntPtr) Specification + 48L))
        {
          FJobSpecification* fjobSpecificationPtr = (FJobSpecification*) ((IntPtr) Specification + 40L);
          long num4 = 0;
          do
          {
            JobOptionalDependencies.Add(new string((char*) *(long*) (*(long*) fjobSpecificationPtr + num4)));
            ++num3;
            num4 += 8L;
          }
          while (num3 < (uint) *(int*) ((IntPtr) Specification + 48L));
        }
      }
      return new AgentJobSpecification(this.ConnectionConfiguration.AgentJobGuid, (EJobTaskFlags) tjobTaskFlags, JobExecutableName, JobParameters, JobRequiredDependencies, JobOptionalDependencies);
    }

    private string GenerateFullChannelName(string ManagedChannelName, TChannelFlags ChannelFlags)
    {
      if ((ChannelFlags & (TChannelFlags) 1) != (TChannelFlags) 0)
      {
        if ((ChannelFlags & (TChannelFlags) 32) != (TChannelFlags) 0)
          return Path.Combine(Path.Combine(this.AgentCacheFolder, "AgentStagingArea"), ManagedChannelName);
        if ((ChannelFlags & (TChannelFlags) 16) != (TChannelFlags) 0)
          return Path.Combine(this.AgentCacheFolder, ManagedChannelName);
      }
      else if ((ChannelFlags & (TChannelFlags) 2) != (TChannelFlags) 0)
      {
        AgentGuid agentGuid = this.ConnectionConfiguration.AgentJobGuid ?? new AgentGuid(291U, 17767U, 35243U, 52719U);
        return Path.Combine(Path.Combine(Path.Combine(this.AgentCacheFolder, "Jobs"), "Job-" + agentGuid.ToString()), ManagedChannelName);
      }
      return "";
    }

    private int CacheFileAndConvertName(
      string FullPathName,
      string* CachedFileName,
      [MarshalAs(UnmanagedType.U1)] bool bUse64bitNamingConvention)
    {
      // ISSUE: unable to decompile the method.
    }

    private unsafe int CacheAllFiles(AgentTaskSpecification TaskSpecification)
    {
      string key = (string) null;
      int invalid = Constants.INVALID;
      int num1;
      try
      {
        TaskSpecification.DependenciesOriginalNames = (Dictionary<string, string>) null;
        List<string> dependencies = TaskSpecification.Dependencies;
        if (dependencies != null && dependencies.Count > 0)
        {
          Dictionary<string, string> dictionary = new Dictionary<string, string>();
          for (int index = 0; index < TaskSpecification.Dependencies.Count; ++index)
          {
            string dependency = TaskSpecification.Dependencies[index];
            int num2 = this.CacheFileAndConvertName(dependency, &key, false);
            if (num2 < 0)
            {
              this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:CacheAllFiles] Failed to cache the dependency: " + dependency);
              return num2;
            }
            TaskSpecification.Dependencies[index] = key;
            string fileName = Path.GetFileName(dependency);
            dictionary.Add(key, fileName);
          }
          TaskSpecification.DependenciesOriginalNames = dictionary;
        }
        num1 = Constants.SUCCESS;
      }
      catch (Exception ex)
      {
        this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:CacheAllFiles] Error: " + ex.Message);
        num1 = Constants.ERROR_CONNECTION_DISCONNECTED;
        this.CleanupClosedConnection();
      }
      return num1;
    }

    private unsafe int CacheAllFiles(AgentJobSpecification JobSpecification)
    {
      string key1 = (string) null;
      string key2 = (string) null;
      string key3 = (string) null;
      int invalid = Constants.INVALID;
      int num1;
      try
      {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        bool bUse64bitNamingConvention1 = ((int) ((uint) JobSpecification.JobFlags >> 2) & 1) != 0;
        bool bUse64bitNamingConvention2 = bUse64bitNamingConvention1;
        string executableName = JobSpecification.ExecutableName;
        int num2 = this.CacheFileAndConvertName(executableName, &key1, bUse64bitNamingConvention1);
        if (num2 < 0)
        {
          this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:CacheAllFiles] Failed to cache the executable: " + executableName);
          return num2;
        }
        JobSpecification.ExecutableName = key1;
        string fileName1 = Path.GetFileName(executableName);
        dictionary.Add(key1, fileName1);
        List<string> requiredDependencies = JobSpecification.RequiredDependencies;
        if (requiredDependencies != null && requiredDependencies.Count > 0)
        {
          for (int index = 0; index < JobSpecification.RequiredDependencies.Count; ++index)
          {
            string requiredDependency = JobSpecification.RequiredDependencies[index];
            int num3 = this.CacheFileAndConvertName(requiredDependency, &key2, bUse64bitNamingConvention2);
            if (num3 < 0)
            {
              this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:CacheAllFiles] Failed to cache the required dependency: " + requiredDependency);
              return num3;
            }
            JobSpecification.RequiredDependencies[index] = key2;
            string fileName2 = Path.GetFileName(requiredDependency);
            dictionary.Add(key2, fileName2);
          }
        }
        List<string> optionalDependencies = JobSpecification.OptionalDependencies;
        if (optionalDependencies != null && optionalDependencies.Count > 0)
        {
          for (int index = 0; index < JobSpecification.OptionalDependencies.Count; ++index)
          {
            string optionalDependency = JobSpecification.OptionalDependencies[index];
            if (this.CacheFileAndConvertName(optionalDependency, &key3, bUse64bitNamingConvention2) < 0)
            {
              this.Log(EVerbosityLevel.Verbose, Color.Orange, "[Interface:CacheAllFiles] Failed to cache an optional dependency: " + optionalDependency);
            }
            else
            {
              JobSpecification.OptionalDependencies[index] = key3;
              string fileName2 = Path.GetFileName(optionalDependency);
              dictionary.Add(key3, fileName2);
            }
          }
        }
        JobSpecification.DependenciesOriginalNames = dictionary;
        num1 = Constants.SUCCESS;
      }
      catch (Exception ex)
      {
        this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:CacheAllFiles] Error: " + ex.Message);
        num1 = Constants.ERROR_CONNECTION_DISCONNECTED;
        this.CleanupClosedConnection();
      }
      return num1;
    }

    private int FlushChannel(
      FSwarmInterfaceManagedImpl.ChannelInfo ChannelToFlush)
    {
      int num = Constants.INVALID;
      if ((ChannelToFlush.ChannelFlags & (TChannelFlags) 32) != (TChannelFlags) 0 && ChannelToFlush.ChannelOffset > 0 && ChannelToFlush.ChannelData != null)
      {
        if (ChannelToFlush.ChannelFileStream != null)
        {
          try
          {
            ChannelToFlush.ChannelFileStream.Write(ChannelToFlush.ChannelData, 0, ChannelToFlush.ChannelOffset);
            num = ChannelToFlush.ChannelOffset;
          }
          catch (Exception ex)
          {
            this.Log(EVerbosityLevel.Critical, Color.Red, "[Interface:FlushChannel] Error: " + ex.Message);
            num = Constants.ERROR_CHANNEL_IO_FAILED;
          }
          ChannelToFlush.ChannelOffset = 0;
        }
      }
      return num;
    }

    protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
    {
      if (_param1)
        return;
      // ISSUE: explicit finalizer call
      this.Finalize();
    }

    public virtual void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private class ChannelInfo
    {
      public string ChannelName;
      public TChannelFlags ChannelFlags;
      public int ChannelHandle;
      public Stream ChannelFileStream;
      public byte[] ChannelData;
      public int ChannelOffset;
    }
  }
}
