// Decompiled with JetBrains decompiler
// Type: TArray<UObject *,FDefaultAllocator>
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[DebugInfoInPDB]
[MiscellaneousBits(64)]
[NativeCppClass]
[StructLayout(LayoutKind.Sequential, Size = 16)]
internal struct TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E
{
  private int \u003Calignment\u0020member\u003E;

  [SpecialName]
  public static unsafe void \u003CMarshalCopy\u003E(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* _param0,
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* _param1)
  {
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(_param0, _param1);
  }

  [SpecialName]
  public static unsafe void \u003CMarshalDestroy\u003E(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* _param0)
  {
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(_param0);
  }
}
