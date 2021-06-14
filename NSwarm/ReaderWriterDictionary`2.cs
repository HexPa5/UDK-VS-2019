// Decompiled with JetBrains decompiler
// Type: NSwarm.ReaderWriterDictionary`2
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace NSwarm
{
  internal class ReaderWriterDictionary<TKey, TValue>
  {
    private ReaderWriterLock AccessLock;
    private Dictionary<TKey, TValue> ProtectedDictionary;

    public Dictionary<TKey, TValue>.ValueCollection Values
    {
      get
      {
        this.AccessLock.AcquireReaderLock(-1);
        try
        {
          return new Dictionary<TKey, TValue>.ValueCollection(this.ProtectedDictionary);
        }
        finally
        {
          this.AccessLock.ReleaseReaderLock();
        }
      }
    }

    public int Count
    {
      get
      {
        this.AccessLock.AcquireReaderLock(-1);
        try
        {
          return this.ProtectedDictionary.Count;
        }
        finally
        {
          this.AccessLock.ReleaseReaderLock();
        }
      }
    }

    public ReaderWriterDictionary()
    {
      this.AccessLock = new ReaderWriterLock();
      this.ProtectedDictionary = new Dictionary<TKey, TValue>();
    }

    public void Add(TKey Key, TValue Value)
    {
      this.AccessLock.AcquireWriterLock(-1);
      try
      {
        this.ProtectedDictionary.Add(Key, Value);
      }
      finally
      {
        this.AccessLock.ReleaseWriterLock();
      }
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public bool Remove(TKey Key)
    {
      this.AccessLock.AcquireWriterLock(-1);
      try
      {
        return this.ProtectedDictionary.Remove(Key);
      }
      finally
      {
        this.AccessLock.ReleaseWriterLock();
      }
    }

    public void Clear()
    {
      this.AccessLock.AcquireWriterLock(-1);
      try
      {
        this.ProtectedDictionary.Clear();
      }
      finally
      {
        this.AccessLock.ReleaseWriterLock();
      }
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public bool TryGetValue(TKey Key, ref TValue Value)
    {
      this.AccessLock.AcquireReaderLock(-1);
      try
      {
        return this.ProtectedDictionary.TryGetValue(Key, out Value);
      }
      finally
      {
        this.AccessLock.ReleaseReaderLock();
      }
    }
  }
}
