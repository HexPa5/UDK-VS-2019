// Decompiled with JetBrains decompiler
// Type: MatineeWindows.MRecordPanelHelper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MatineeWindows
{
  internal class MRecordPanelHelper : IDisposable
  {
    public List<MWPFPanel> RecordPanelList;

    public MRecordPanelHelper() => this.RecordPanelList = new List<MWPFPanel>();

    private void \u007EMRecordPanelHelper()
    {
      int index = 0;
      if (0 < this.RecordPanelList.Count)
      {
        do
        {
          if (this.RecordPanelList[index] is IDisposable recordPanel3)
            recordPanel3.Dispose();
          ++index;
        }
        while (index < this.RecordPanelList.Count);
      }
      if (this.RecordPanelList is IDisposable recordPanelList)
        recordPanelList.Dispose();
      this.RecordPanelList = (List<MWPFPanel>) null;
    }

    protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
    {
      if (_param1)
      {
        this.\u007EMRecordPanelHelper();
      }
      else
      {
        // ISSUE: explicit finalizer call
        this.Finalize();
      }
    }

    public virtual void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
