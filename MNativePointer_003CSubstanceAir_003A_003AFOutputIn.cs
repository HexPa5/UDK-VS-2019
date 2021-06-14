// Decompiled with JetBrains decompiler
// Type: MNativePointer<SubstanceAir::FOutputInstance>
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using SubstanceAir;
using System.Runtime.CompilerServices;

internal class MNativePointer\u003CSubstanceAir\u003A\u003AFOutputInstance\u003E
{
  protected unsafe FOutputInstance* NativePointer = (FOutputInstance*) 0L;

  [SpecialName]
  public unsafe FOutputInstance* op_MemberSelection() => this.NativePointer;

  public unsafe FOutputInstance* Get() => this.NativePointer;

  public virtual unsafe void Reset(FOutputInstance* InNativePointer) => this.NativePointer = InNativePointer;
}
