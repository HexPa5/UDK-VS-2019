// Decompiled with JetBrains decompiler
// Type: MNativePointer<TSet<FName,DefaultKeyFuncs<FName,0>,FDefaultSetAllocator> >
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class MNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E
{
  protected unsafe TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* NativePointer = (TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) 0L;

  [SpecialName]
  public unsafe TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* op_MemberSelection() => this.NativePointer;

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool IsValid() => (IntPtr) this.NativePointer != 0L;

  public unsafe TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* Release()
  {
    TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* nativePointer = this.NativePointer;
    this.NativePointer = (TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) 0L;
    return nativePointer;
  }

  public virtual unsafe void Reset(
    TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* InNativePointer)
  {
    this.NativePointer = InNativePointer;
  }
}
