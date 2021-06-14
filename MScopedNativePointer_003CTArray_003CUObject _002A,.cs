// Decompiled with JetBrains decompiler
// Type: MScopedNativePointer<TArray<UObject *,FDefaultAllocator> >
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

internal class MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E : 
  MNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E,
  IDisposable
{
  private unsafe void \u007EMScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E()
  {
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* nativePointer = this.NativePointer;
    if ((IntPtr) nativePointer != IntPtr.Zero)
    {
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(nativePointer);
      \u003CModule\u003E.delete((void*) nativePointer);
    }
    this.NativePointer = (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L;
  }

  private unsafe void \u0021MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E()
  {
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* nativePointer = this.NativePointer;
    if ((IntPtr) nativePointer == IntPtr.Zero)
      return;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(nativePointer);
    \u003CModule\u003E.delete((void*) nativePointer);
  }

  public override unsafe void Reset(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InNativePointer)
  {
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* nativePointer = this.NativePointer;
    if (InNativePointer == nativePointer)
      return;
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = nativePointer;
    if ((IntPtr) fdefaultAllocatorPtr != IntPtr.Zero)
    {
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(fdefaultAllocatorPtr);
      \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr);
    }
    this.NativePointer = InNativePointer;
  }

  public unsafe MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E()
  {
    this.NativePointer = (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  [HandleProcessCorruptedStateExceptions]
  protected virtual unsafe void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* nativePointer = this.NativePointer;
      if ((IntPtr) nativePointer != IntPtr.Zero)
      {
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(nativePointer);
        \u003CModule\u003E.delete((void*) nativePointer);
      }
      this.NativePointer = (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L;
    }
    else
    {
      try
      {
        this.\u0021MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E();
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

  ~MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E() => this.Dispose(false);
}
