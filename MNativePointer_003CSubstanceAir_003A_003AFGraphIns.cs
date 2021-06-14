// Decompiled with JetBrains decompiler
// Type: MNativePointer<SubstanceAir::FGraphInstance>
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using SubstanceAir;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E
{
  protected unsafe FGraphInstance* NativePointer = (FGraphInstance*) 0L;

  public unsafe MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(
    FGraphInstance* InNativePointer)
  {
    this.NativePointer = InNativePointer;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E()
  {
  }

  [SpecialName]
  public unsafe FGraphInstance* op_MemberSelection() => this.NativePointer;

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool IsValid() => (IntPtr) this.NativePointer != 0L;

  public unsafe FGraphInstance* Get() => this.NativePointer;

  public virtual unsafe void Reset(FGraphInstance* InNativePointer) => this.NativePointer = InNativePointer;
}
