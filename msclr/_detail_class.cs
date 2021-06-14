// Decompiled with JetBrains decompiler
// Type: msclr._detail_class
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Runtime.InteropServices;

namespace msclr
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  internal struct _detail_class
  {
    public static string _safe_true = _detail_class.dummy_struct.dummy_string;
    public static string _safe_false = (string) null;

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct dummy_struct
    {
      public static readonly string dummy_string = "";
    }
  }
}
