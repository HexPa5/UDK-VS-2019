// Decompiled with JetBrains decompiler
// Type: MNativePointer<TMap<UClass *,TArray<UGenericBrowserType *,FDefaultAllocator>,FDefaultSetAllocator> >
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class MNativePointer\u003CTMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E
{
  protected unsafe TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* NativePointer = (TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E*) 0L;

  [SpecialName]
  public unsafe TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* op_MemberSelection() => this.NativePointer;

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool IsValid() => (IntPtr) this.NativePointer != 0L;

  public unsafe TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* Get() => this.NativePointer;

  public virtual unsafe void Reset(
    TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* InNativePointer)
  {
    this.NativePointer = InNativePointer;
  }
}
