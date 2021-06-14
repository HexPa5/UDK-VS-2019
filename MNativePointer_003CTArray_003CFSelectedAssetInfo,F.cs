// Decompiled with JetBrains decompiler
// Type: MNativePointer<TArray<FSelectedAssetInfo,FDefaultAllocator> >
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Runtime.CompilerServices;

internal class MNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E
{
  protected unsafe TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E* NativePointer = (TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) 0L;

  [SpecialName]
  public unsafe TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E* op_MemberSelection() => this.NativePointer;

  public unsafe TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E* Get() => this.NativePointer;

  public virtual unsafe void Reset(
    TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E* InNativePointer)
  {
    this.NativePointer = InNativePointer;
  }
}
