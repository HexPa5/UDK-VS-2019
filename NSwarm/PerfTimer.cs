// Decompiled with JetBrains decompiler
// Type: NSwarm.PerfTimer
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace NSwarm
{
  internal class PerfTimer : IDisposable
  {
    public double Frequency;
    public Stack<PerfTiming> LastTimers;
    public ReaderWriterDictionary<string, PerfTiming> Timings;

    public PerfTimer()
    {
      this.Timings = new ReaderWriterDictionary<string, PerfTiming>();
      this.LastTimers = new Stack<PerfTiming>();
    }

    private void \u007EPerfTimer()
    {
    }

    public void Start(string Name, int Accum, long Adder)
    {
      Monitor.Enter((object) this.LastTimers);
      PerfTiming perfTiming = (PerfTiming) null;
      if (!this.Timings.TryGetValue(Name, ref perfTiming))
      {
        perfTiming = new PerfTiming(Name, Accum);
        this.Timings.Add(Name, perfTiming);
      }
      this.LastTimers.Push(perfTiming);
      perfTiming.Counter += Adder;
      perfTiming.Start();
      Monitor.Exit((object) this.LastTimers);
    }

    public void Stop()
    {
      Monitor.Enter((object) this.LastTimers);
      this.LastTimers.Pop().Stop();
      Monitor.Exit((object) this.LastTimers);
    }

    public string DumpTimings()
    {
      string str1 = "";
      double num1 = 0.0;
      Dictionary<string, PerfTiming>.ValueCollection.Enumerator enumerator = this.Timings.Values.GetEnumerator();
      if (enumerator.MoveNext())
      {
        do
        {
          PerfTiming current = enumerator.Current;
          if (current.Count > 0)
          {
            double totalSeconds = current.StopWatchTimer.Elapsed.TotalSeconds;
            double num2 = totalSeconds * 1000000.0 / (double) current.Count;
            double num3 = totalSeconds;
            string str2 = str1 + (current.Name.PadLeft(30) + " : " + num3.ToString("F3") + "s in " + (object) current.Count + " calls (" + num2.ToString("F0") + "us per call)");
            long counter = current.Counter;
            if (counter > 0L)
              str2 += " (" + (object) (counter / 1024L) + "k)";
            str1 = str2 + "\n";
            if (current.Accumulate != 0)
              num1 = totalSeconds + num1;
          }
        }
        while (enumerator.MoveNext());
      }
      double num4 = num1;
      return str1 + ("\nTotal time inside Swarm: " + num4.ToString("F3") + "s\n");
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
  }
}
