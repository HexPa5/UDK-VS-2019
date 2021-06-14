// Decompiled with JetBrains decompiler
// Type: NSwarm.PerfTiming
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Diagnostics;

namespace NSwarm
{
  internal class PerfTiming
  {
    public string Name;
    public Stopwatch StopWatchTimer;
    public int Count;
    public int Accumulate;
    public long Counter;

    public PerfTiming(string InName, int InAccumulate)
    {
      this.Name = InName;
      this.StopWatchTimer = new Stopwatch();
      this.Count = 0;
      this.Accumulate = InAccumulate;
      this.Counter = 0L;
    }

    public void Start() => this.StopWatchTimer.Start();

    public void Stop()
    {
      ++this.Count;
      this.StopWatchTimer.Stop();
    }

    public void IncrementCounter(long Adder) => this.Counter += Adder;
  }
}
