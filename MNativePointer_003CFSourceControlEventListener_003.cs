// Decompiled with JetBrains decompiler
// Type: MNativePointer<FSourceControlEventListener>
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

internal class MNativePointer\u003CFSourceControlEventListener\u003E
{
  protected unsafe FSourceControlEventListener* NativePointer;

  public unsafe MNativePointer\u003CFSourceControlEventListener\u003E(
    FSourceControlEventListener* InNativePointer)
  {
    this.NativePointer = InNativePointer;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public unsafe FSourceControlEventListener* Get() => this.NativePointer;

  public virtual unsafe void Reset(FSourceControlEventListener* InNativePointer) => this.NativePointer = InNativePointer;
}
