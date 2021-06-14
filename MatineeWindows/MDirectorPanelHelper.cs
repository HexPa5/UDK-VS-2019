// Decompiled with JetBrains decompiler
// Type: MatineeWindows.MDirectorPanelHelper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MatineeWindows
{
  internal class MDirectorPanelHelper : IDisposable
  {
    public List<MWPFPanel> DirectorPanelList;

    public MDirectorPanelHelper() => this.DirectorPanelList = new List<MWPFPanel>();

    private void \u007EMDirectorPanelHelper()
    {
      int index = 0;
      if (0 < this.DirectorPanelList.Count)
      {
        do
        {
          if (this.DirectorPanelList[index] is IDisposable directorPanel3)
            directorPanel3.Dispose();
          ++index;
        }
        while (index < this.DirectorPanelList.Count);
      }
      if (this.DirectorPanelList is IDisposable directorPanelList)
        directorPanelList.Dispose();
      this.DirectorPanelList = (List<MWPFPanel>) null;
    }

    protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
    {
      if (_param1)
      {
        this.\u007EMDirectorPanelHelper();
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
