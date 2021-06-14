// Decompiled with JetBrains decompiler
// Type: MNativePointer<TSet<UGenericBrowserType *,DefaultKeyFuncs<UGenericBrowserType *,0>,FDefaultSetAllocator> >
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Runtime.CompilerServices;

internal class MNativePointer\u003CTSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E
{
  protected unsafe TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E* NativePointer = (TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) 0L;

  [SpecialName]
  public unsafe TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E* op_MemberSelection() => this.NativePointer;

  public unsafe TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E* Get() => this.NativePointer;

  public virtual unsafe void Reset(
    TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E* InNativePointer)
  {
    this.NativePointer = InNativePointer;
  }
}
