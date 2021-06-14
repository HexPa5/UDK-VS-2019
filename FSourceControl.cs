// Decompiled with JetBrains decompiler
// Type: FSourceControl
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using Microsoft.VisualC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[MiscellaneousBits(64)]
[NativeCppClass]
[DebugInfoInPDB]
[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct FSourceControl
{
  [CLSCompliant(false)]
  [NativeCppClass]
  [DebugInfoInPDB]
  [MiscellaneousBits(64)]
  [StructLayout(LayoutKind.Sequential, Size = 80)]
  public struct FSourceControlFileRevisionInfo
  {
    private int \u003Calignment\u0020member\u003E;
  }

  [DebugInfoInPDB]
  [NativeCppClass]
  [CLSCompliant(false)]
  [MiscellaneousBits(64)]
  [StructLayout(LayoutKind.Sequential, Size = 32)]
  public struct FSourceControlFileHistoryInfo
  {
    private int \u003Calignment\u0020member\u003E;

    [DebugInfoInPDB]
    [NativeCppClass]
    [CLSCompliant(false)]
    [MiscellaneousBits(64)]
    public enum EFileHistoryKeys
    {
    }
  }
}
