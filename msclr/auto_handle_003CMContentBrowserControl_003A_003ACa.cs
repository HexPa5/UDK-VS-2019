// Decompiled with JetBrains decompiler
// Type: msclr.auto_handle<MContentBrowserControl::CachedQueryDataType>
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace msclr
{
  internal class auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E : 
    IDisposable
  {
    private MContentBrowserControl.CachedQueryDataType m_handle = (MContentBrowserControl.CachedQueryDataType) null;

    public auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E(
      auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E _right)
    {
      MContentBrowserControl.CachedQueryDataType handle = _right.m_handle;
      _right.m_handle = (MContentBrowserControl.CachedQueryDataType) null;
      this.m_handle = handle;
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }

    public auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E()
    {
    }

    [SpecialName]
    public auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E op_Assign(
      auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E _right)
    {
      MContentBrowserControl.CachedQueryDataType handle = _right.m_handle;
      _right.m_handle = (MContentBrowserControl.CachedQueryDataType) null;
      this.reset(handle);
      return this;
    }

    public MContentBrowserControl.CachedQueryDataType get() => this.m_handle;

    [SpecialName]
    public MContentBrowserControl.CachedQueryDataType op_MemberSelection() => this.m_handle;

    public void reset() => this.reset((MContentBrowserControl.CachedQueryDataType) null);

    public void reset(
      MContentBrowserControl.CachedQueryDataType _new_ptr)
    {
      MContentBrowserControl.CachedQueryDataType handle = this.m_handle;
      if (handle == _new_ptr)
        return;
      if ((handle != null ? 1 : 0) != 0 && handle is IDisposable disposable)
        disposable.Dispose();
      this.m_handle = _new_ptr;
    }

    public MContentBrowserControl.CachedQueryDataType release()
    {
      MContentBrowserControl.CachedQueryDataType handle = this.m_handle;
      this.m_handle = (MContentBrowserControl.CachedQueryDataType) null;
      return handle;
    }

    private void \u007Eauto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E()
    {
      MContentBrowserControl.CachedQueryDataType handle = this.m_handle;
      if ((handle != null ? 1 : 0) == 0 || !(handle is IDisposable disposable))
        return;
      disposable.Dispose();
    }

    [return: MarshalAs(UnmanagedType.U1)]
    private bool valid() => this.m_handle != null;

    protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
    {
      if (_param1)
      {
        MContentBrowserControl.CachedQueryDataType handle = this.m_handle;
        if ((handle != null ? 1 : 0) == 0 || !(handle is IDisposable disposable2))
          return;
        disposable2.Dispose();
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
