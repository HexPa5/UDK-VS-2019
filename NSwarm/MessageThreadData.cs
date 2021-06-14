// Decompiled with JetBrains decompiler
// Type: NSwarm.MessageThreadData
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

namespace NSwarm
{
  internal class MessageThreadData
  {
    public FSwarmInterfaceManagedImpl Owner;
    public IAgentInterfaceWrapper Connection;
    public int ConnectionHandle;
    public __FnPtr<void (FMessage*, void*)> ConnectionCallback;
    public unsafe void* ConnectionCallbackData;
    public AgentConfiguration ConnectionConfiguration;
  }
}
