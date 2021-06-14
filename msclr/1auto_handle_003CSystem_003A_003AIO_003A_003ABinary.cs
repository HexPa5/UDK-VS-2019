// Decompiled with JetBrains decompiler
// Type: msclr.auto_handle<System::IO::BinaryWriter>
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace msclr
{
  internal class auto_handle\u003CSystem\u003A\u003AIO\u003A\u003ABinaryWriter\u003E : IDisposable
  {
    private BinaryWriter m_handle;

    public auto_handle\u003CSystem\u003A\u003AIO\u003A\u003ABinaryWriter\u003E(BinaryWriter _ptr)
    {
      this.m_handle = _ptr;
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }

    [SpecialName]
    public BinaryWriter op_MemberSelection() => this.m_handle;

    private void \u007Eauto_handle\u003CSystem\u003A\u003AIO\u003A\u003ABinaryWriter\u003E()
    {
      BinaryWriter handle = this.m_handle;
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
        BinaryWriter handle = this.m_handle;
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
