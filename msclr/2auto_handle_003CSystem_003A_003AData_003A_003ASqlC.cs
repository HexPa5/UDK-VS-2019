// Decompiled with JetBrains decompiler
// Type: msclr.auto_handle<System::Data::SqlClient::SqlDataReader>
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace msclr
{
  internal class auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlDataReader\u003E : 
    IDisposable
  {
    private SqlDataReader m_handle;

    public auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlDataReader\u003E(
      SqlDataReader _ptr)
    {
      this.m_handle = _ptr;
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }

    public SqlDataReader get() => this.m_handle;

    [SpecialName]
    public SqlDataReader op_MemberSelection() => this.m_handle;

    private void \u007Eauto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlDataReader\u003E()
    {
      SqlDataReader handle = this.m_handle;
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
        SqlDataReader handle = this.m_handle;
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
