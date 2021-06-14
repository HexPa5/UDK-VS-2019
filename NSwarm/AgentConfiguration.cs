// Decompiled with JetBrains decompiler
// Type: NSwarm.AgentConfiguration
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using AgentInterface;

namespace NSwarm
{
  internal class AgentConfiguration
  {
    public int AgentProcessID;
    public string AgentCachePath;
    public AgentGuid AgentJobGuid;
    public bool IsPureLocalConnection;

    public AgentConfiguration()
    {
      this.AgentProcessID = -1;
      this.AgentCachePath = (string) null;
      this.AgentJobGuid = (AgentGuid) null;
      this.IsPureLocalConnection = false;
    }
  }
}
