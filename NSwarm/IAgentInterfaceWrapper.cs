// Decompiled with JetBrains decompiler
// Type: NSwarm.IAgentInterfaceWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using AgentInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace NSwarm
{
  internal class IAgentInterfaceWrapper : IDisposable
  {
    private IAgentInterface Connection;
    private ManualResetEvent ConnectionDroppedEvent;

    public IAgentInterfaceWrapper()
    {
      this.Connection = (IAgentInterface) Activator.GetObject(typeof (IAgentInterface), "tcp://127.0.0.1:8008/SwarmAgent");
      this.ConnectionDroppedEvent = new ManualResetEvent(false);
    }

    private void \u007EIAgentInterfaceWrapper()
    {
    }

    public void SignalConnectionDropped() => this.ConnectionDroppedEvent.Set();

    public unsafe int OpenConnection(
      __FnPtr<void (FMessage*, void*)> CallbackFunc,
      void* CallbackData,
      ELogFlags LoggingFlags,
      Process AgentProcess,
      int AgentProcessOwner,
      int LocalProcessID,
      ref AgentConfiguration NewConfiguration)
    {
      IAgentInterfaceWrapper.OpenConnectionDelegate connectionDelegate = new IAgentInterfaceWrapper.OpenConnectionDelegate(this.Connection.OpenConnection);
      Hashtable InParameters = new Hashtable();
      InParameters[(object) "Version"] = (object) 16;
      InParameters[(object) "ProcessID"] = (object) LocalProcessID;
      bool flag = AgentProcessOwner == 1;
      InParameters[(object) "ProcessIsOwner"] = (object) flag;
      InParameters[(object) nameof (LoggingFlags)] = (object) LoggingFlags;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = connectionDelegate.BeginInvoke(InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      if (!result.AsyncWaitHandle.WaitOne(1000))
      {
        while (!AgentProcess.HasExited && AgentProcess.Responding)
        {
          Debug.WriteLineIf(Debugger.IsAttached, "[OpenConnection] Waiting for agent to respond ...");
          if (CallbackFunc != null)
          {
            FMessage fmessage;
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            ^(int&) ref fmessage = 16;
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            ^(int&) ((IntPtr) &fmessage + 4) = 6;
            ref FMessage local = ref fmessage;
            void* voidPtr = CallbackData;
            // ISSUE: function pointer call
            __calli(CallbackFunc)((void*) ref local, (FMessage*) voidPtr);
          }
          if (result.AsyncWaitHandle.WaitOne(1000))
            break;
        }
      }
      if (result.IsCompleted)
      {
        int num = connectionDelegate.EndInvoke(ref hashtable, result);
        if (hashtable != null && (int) hashtable[(object) "Version"] == 16)
        {
          NewConfiguration = new AgentConfiguration();
          NewConfiguration.AgentProcessID = (int) hashtable[(object) "AgentProcessID"];
          NewConfiguration.AgentCachePath = (string) hashtable[(object) "AgentCachePath"];
          NewConfiguration.AgentJobGuid = (AgentGuid) hashtable[(object) "AgentJobGuid"];
          if (hashtable.ContainsKey((object) "IsPureLocalConnection"))
            NewConfiguration.IsPureLocalConnection = (bool) hashtable[(object) "IsPureLocalConnection"];
          return num;
        }
      }
      return Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int CloseConnection(int ConnectionHandle)
    {
      IAgentInterfaceWrapper.CloseConnectionDelegate connectionDelegate = new IAgentInterfaceWrapper.CloseConnectionDelegate(this.Connection.CloseConnection);
      Hashtable InParameters = (Hashtable) null;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = connectionDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? connectionDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int SendMessage(int ConnectionHandle, AgentMessage NewMessage)
    {
      IAgentInterfaceWrapper.SendMessageDelegate sendMessageDelegate = new IAgentInterfaceWrapper.SendMessageDelegate(this.Connection.SendMessage);
      Hashtable InParameters = new Hashtable();
      InParameters[(object) "Version"] = (object) 16;
      InParameters[(object) "Message"] = (object) NewMessage;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = sendMessageDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? sendMessageDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int GetMessage(int ConnectionHandle, ref AgentMessage NextMessage, int Timeout)
    {
      IAgentInterfaceWrapper.GetMessageDelegate getMessageDelegate = new IAgentInterfaceWrapper.GetMessageDelegate(this.Connection.GetMessage);
      Hashtable InParameters = new Hashtable();
      InParameters[(object) "Version"] = (object) 16;
      InParameters[(object) nameof (Timeout)] = (object) Timeout;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = getMessageDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      if (result.IsCompleted)
      {
        int num = getMessageDelegate.EndInvoke(ref hashtable, result);
        if (hashtable != null && (int) hashtable[(object) "Version"] == 16)
        {
          NextMessage = (AgentMessage) hashtable[(object) "Message"];
          return num;
        }
      }
      return Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int AddChannel(int ConnectionHandle, string FullPath, string ChannelName)
    {
      IAgentInterfaceWrapper.AddChannelDelegate addChannelDelegate = new IAgentInterfaceWrapper.AddChannelDelegate(this.Connection.AddChannel);
      Hashtable InParameters = new Hashtable();
      InParameters[(object) "Version"] = (object) 16;
      InParameters[(object) nameof (FullPath)] = (object) FullPath;
      InParameters[(object) nameof (ChannelName)] = (object) ChannelName;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = addChannelDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? addChannelDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int TestChannel(int ConnectionHandle, string ChannelName)
    {
      IAgentInterfaceWrapper.TestChannelDelegate testChannelDelegate = new IAgentInterfaceWrapper.TestChannelDelegate(this.Connection.TestChannel);
      Hashtable InParameters = new Hashtable();
      InParameters[(object) "Version"] = (object) 16;
      InParameters[(object) nameof (ChannelName)] = (object) ChannelName;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = testChannelDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? testChannelDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int OpenChannel(int ConnectionHandle, string ChannelName, EChannelFlags ChannelFlags)
    {
      IAgentInterfaceWrapper.OpenChannelDelegate openChannelDelegate = new IAgentInterfaceWrapper.OpenChannelDelegate(this.Connection.OpenChannel);
      Hashtable InParameters = new Hashtable();
      InParameters[(object) "Version"] = (object) 16;
      InParameters[(object) nameof (ChannelName)] = (object) ChannelName;
      InParameters[(object) nameof (ChannelFlags)] = (object) ChannelFlags;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = openChannelDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? openChannelDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int CloseChannel(int ConnectionHandle, int ChannelHandle)
    {
      IAgentInterfaceWrapper.CloseChannelDelegate closeChannelDelegate = new IAgentInterfaceWrapper.CloseChannelDelegate(this.Connection.CloseChannel);
      Hashtable InParameters = new Hashtable();
      InParameters[(object) "Version"] = (object) 16;
      InParameters[(object) nameof (ChannelHandle)] = (object) ChannelHandle;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = closeChannelDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? closeChannelDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int OpenJob(int ConnectionHandle, AgentGuid JobGuid)
    {
      IAgentInterfaceWrapper.OpenJobDelegate openJobDelegate = new IAgentInterfaceWrapper.OpenJobDelegate(this.Connection.OpenJob);
      Hashtable InParameters = new Hashtable();
      InParameters[(object) "Version"] = (object) 16;
      InParameters[(object) nameof (JobGuid)] = (object) JobGuid;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = openJobDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? openJobDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int BeginJobSpecification(
      int ConnectionHandle,
      AgentJobSpecification Specification32,
      Hashtable Description32,
      AgentJobSpecification Specification64,
      Hashtable Description64)
    {
      IAgentInterfaceWrapper.BeginJobSpecificationDelegate specificationDelegate = new IAgentInterfaceWrapper.BeginJobSpecificationDelegate(this.Connection.BeginJobSpecification);
      Hashtable InParameters = new Hashtable();
      InParameters[(object) "Version"] = (object) 16;
      InParameters[(object) nameof (Specification32)] = (object) Specification32;
      InParameters[(object) nameof (Specification64)] = (object) Specification64;
      InParameters[(object) nameof (Description32)] = (object) Description32;
      InParameters[(object) nameof (Description64)] = (object) Description64;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = specificationDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? specificationDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int AddTask(int ConnectionHandle, List<AgentTaskSpecification> Specifications)
    {
      IAgentInterfaceWrapper.AddTaskDelegate addTaskDelegate = new IAgentInterfaceWrapper.AddTaskDelegate(this.Connection.AddTask);
      Hashtable InParameters = new Hashtable();
      InParameters[(object) "Version"] = (object) 16;
      InParameters[(object) nameof (Specifications)] = (object) Specifications;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = addTaskDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? addTaskDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int EndJobSpecification(int ConnectionHandle)
    {
      IAgentInterfaceWrapper.EndJobSpecificationDelegate specificationDelegate = new IAgentInterfaceWrapper.EndJobSpecificationDelegate(this.Connection.EndJobSpecification);
      Hashtable InParameters = (Hashtable) null;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = specificationDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? specificationDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int CloseJob(int ConnectionHandle)
    {
      IAgentInterfaceWrapper.CloseJobDelegate closeJobDelegate = new IAgentInterfaceWrapper.CloseJobDelegate(this.Connection.CloseJob);
      Hashtable InParameters = (Hashtable) null;
      Hashtable hashtable = (Hashtable) null;
      IAsyncResult result = closeJobDelegate.BeginInvoke(ConnectionHandle, InParameters, ref hashtable, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? closeJobDelegate.EndInvoke(ref hashtable, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int Method(int ConnectionHandle, Hashtable InParameters, ref Hashtable OutParameters)
    {
      IAgentInterfaceWrapper.MethodDelegate methodDelegate = new IAgentInterfaceWrapper.MethodDelegate(this.Connection.Method);
      IAsyncResult result = methodDelegate.BeginInvoke(ConnectionHandle, InParameters, ref OutParameters, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? methodDelegate.EndInvoke(ref OutParameters, result) : Constants.ERROR_CONNECTION_DISCONNECTED;
    }

    public int Log(EVerbosityLevel Verbosity, Color TextColour, string Line)
    {
      IAgentInterfaceWrapper.LogDelegate logDelegate = new IAgentInterfaceWrapper.LogDelegate(this.Connection.Log);
      IAsyncResult result = logDelegate.BeginInvoke(Verbosity, TextColour, Line, (AsyncCallback) null, (object) null);
      WaitHandle.WaitAny(new WaitHandle[2]
      {
        result.AsyncWaitHandle,
        (WaitHandle) this.ConnectionDroppedEvent
      });
      return result.IsCompleted ? logDelegate.EndInvoke(result) : Constants.ERROR_CONNECTION_DISCONNECTED;
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

    private delegate int OpenConnectionDelegate(Hashtable InParameters, ref Hashtable OutParameters);

    private delegate int CloseConnectionDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int SendMessageDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int GetMessageDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int AddChannelDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int TestChannelDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int OpenChannelDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int CloseChannelDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int OpenJobDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int BeginJobSpecificationDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int AddTaskDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int EndJobSpecificationDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int CloseJobDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int MethodDelegate(
      int ConnectionHandle,
      Hashtable InParameters,
      ref Hashtable OutParameters);

    private delegate int LogDelegate(EVerbosityLevel Verbosity, Color TextColour, string Line);
  }
}
