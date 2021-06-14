// Decompiled with JetBrains decompiler
// Type: InteropTools.MEditorBackend
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Runtime.CompilerServices;
using UnrealEd;

namespace InteropTools
{
  internal class MEditorBackend : IEditorBackendInterface
  {
    public virtual unsafe void LogWarningMessage(string Text)
    {
      // ISSUE: cast to a reference type
      // ISSUE: variable of a reference type
      byte* local = (byte*) Text;
      if (local != null)
        local = (long) (uint) RuntimeHelpers.OffsetToStringData + local;
      // ISSUE: explicit reference operation
      fixed (byte* numPtr = &^local)
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (char*) numPtr);
    }
  }
}
