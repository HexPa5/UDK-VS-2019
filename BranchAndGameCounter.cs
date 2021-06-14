// Decompiled with JetBrains decompiler
// Type: BranchAndGameCounter
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

internal class BranchAndGameCounter
{
  public string BranchName;
  public string GameName;
  public int Counter;

  public BranchAndGameCounter(string InBranch, string InGame)
  {
    this.BranchName = InBranch;
    this.GameName = InGame;
    this.Counter = 0;
  }
}
