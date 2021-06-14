// Decompiled with JetBrains decompiler
// Type: MScopedNativePointer<TLookupMap<FName,FDefaultSetAllocator> >
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

internal class MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E : 
  MNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E,
  IDisposable
{
  private unsafe void \u007EMScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E()
  {
    TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E* nativePointer = this.NativePointer;
    if ((IntPtr) nativePointer != IntPtr.Zero)
    {
      \u003CModule\u003E.TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(nativePointer);
      \u003CModule\u003E.delete((void*) nativePointer);
    }
    this.NativePointer = (TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E*) 0L;
  }

  private unsafe void \u0021MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E()
  {
    TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E* nativePointer = this.NativePointer;
    if ((IntPtr) nativePointer == IntPtr.Zero)
      return;
    \u003CModule\u003E.TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(nativePointer);
    \u003CModule\u003E.delete((void*) nativePointer);
  }

  public override unsafe void Reset(
    TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E* InNativePointer)
  {
    TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E* nativePointer = this.NativePointer;
    if (InNativePointer == nativePointer)
      return;
    TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr = nativePointer;
    if ((IntPtr) fdefaultSetAllocatorPtr != IntPtr.Zero)
    {
      \u003CModule\u003E.TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(fdefaultSetAllocatorPtr);
      \u003CModule\u003E.delete((void*) fdefaultSetAllocatorPtr);
    }
    this.NativePointer = InNativePointer;
  }

  public unsafe MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E()
  {
    this.NativePointer = (TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E*) 0L;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  [HandleProcessCorruptedStateExceptions]
  protected virtual unsafe void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E* nativePointer = this.NativePointer;
      if ((IntPtr) nativePointer != IntPtr.Zero)
      {
        \u003CModule\u003E.TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(nativePointer);
        \u003CModule\u003E.delete((void*) nativePointer);
      }
      this.NativePointer = (TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E*) 0L;
    }
    else
    {
      try
      {
        this.\u0021MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E();
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

  ~MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E() => this.Dispose(false);
}
