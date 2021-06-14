// Decompiled with JetBrains decompiler
// Type: msclr.auto_handle<System::Windows::Interop::HwndSource>
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace msclr
{
  internal class auto_handle\u003CSystem\u003A\u003AWindows\u003A\u003AInterop\u003A\u003AHwndSource\u003E : 
    IDisposable
  {
    private HwndSource m_handle = (HwndSource) null;

    [SpecialName]
    public HwndSource op_MemberSelection() => this.m_handle;

    public void reset()
    {
      HwndSource handle = this.m_handle;
      if (handle == null)
        return;
      handle.Dispose();
      this.m_handle = (HwndSource) null;
    }

    public void reset(HwndSource _new_ptr)
    {
      HwndSource handle = this.m_handle;
      if (handle == _new_ptr)
        return;
      if ((handle != null ? 1 : 0) != 0)
        handle?.Dispose();
      this.m_handle = _new_ptr;
    }

    private void \u007Eauto_handle\u003CSystem\u003A\u003AWindows\u003A\u003AInterop\u003A\u003AHwndSource\u003E()
    {
      HwndSource handle = this.m_handle;
      if ((handle != null ? 1 : 0) == 0)
        return;
      handle?.Dispose();
    }

    [return: MarshalAs(UnmanagedType.U1)]
    private bool valid() => this.m_handle != null;

    protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
    {
      if (_param1)
      {
        HwndSource handle = this.m_handle;
        if ((handle != null ? 1 : 0) == 0)
          return;
        handle?.Dispose();
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
