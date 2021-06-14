// Decompiled with JetBrains decompiler
// Type: FMusicTrackStruct
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using Microsoft.VisualC;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[MiscellaneousBits(65)]
[NativeCppClass]
[DebugInfoInPDB]
[StructLayout(LayoutKind.Sequential, Size = 44)]
internal struct FMusicTrackStruct
{
  private int \u003Calignment\u0020member\u003E;

  [SpecialName]
  public static unsafe void \u003CMarshalCopy\u003E(
    FMusicTrackStruct* _param0,
    FMusicTrackStruct* _param1)
  {
    \u003CModule\u003E.FMusicTrackStruct\u002E\u007Bctor\u007D(_param0, _param1);
  }

  [SpecialName]
  public static unsafe void \u003CMarshalDestroy\u003E(FMusicTrackStruct* _param0) => \u003CModule\u003E.FMusicTrackStruct\u002E\u007Bdtor\u007D(_param0);
}
