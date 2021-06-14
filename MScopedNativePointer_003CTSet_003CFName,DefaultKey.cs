// Decompiled with JetBrains decompiler
// Type: MScopedNativePointer<TSet<FName,DefaultKeyFuncs<FName,0>,FDefaultSetAllocator> >
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

internal class MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E : 
  MNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E,
  IDisposable
{
  private unsafe void \u007EMScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E()
  {
    TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* nativePointer = this.NativePointer;
    if ((IntPtr) nativePointer != IntPtr.Zero)
      \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E__delDtor(nativePointer, 1U);
    this.NativePointer = (TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) 0L;
  }

  private unsafe void \u0021MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E()
  {
    TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* nativePointer = this.NativePointer;
    if ((IntPtr) nativePointer == IntPtr.Zero)
      return;
    \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E__delDtor(nativePointer, 1U);
  }

  public override unsafe void Reset(
    TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* InNativePointer)
  {
    TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* nativePointer = this.NativePointer;
    if (InNativePointer == nativePointer)
      return;
    TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr = nativePointer;
    if ((IntPtr) fdefaultSetAllocatorPtr != IntPtr.Zero)
      \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E__delDtor(fdefaultSetAllocatorPtr, 1U);
    this.NativePointer = InNativePointer;
  }

  public unsafe MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E()
  {
    this.NativePointer = (TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) 0L;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  [HandleProcessCorruptedStateExceptions]
  protected virtual unsafe void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* nativePointer = this.NativePointer;
      if ((IntPtr) nativePointer != IntPtr.Zero)
        \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E__delDtor(nativePointer, 1U);
      this.NativePointer = (TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) 0L;
    }
    else
    {
      try
      {
        this.\u0021MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E();
      }
      finally
      {
        // ISSUE: explicit finalizer call
        base.Finalize();
      }
    }
  }

  public virtual void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  ~MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E() => this.Dispose(false);
}
