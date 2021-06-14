// Decompiled with JetBrains decompiler
// Type: MGizmoHistoryWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

internal class MGizmoHistoryWrapper : INotifyPropertyChanged
{
  private int index;
  private unsafe FGizmoHistory* gizmo;

  public unsafe MGizmoHistoryWrapper(int InIndex, FGizmoHistory* InGizmo)
  {
    this.index = InIndex;
    this.gizmo = InGizmo;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public virtual event PropertyChangedEventHandler PropertyChanged;

  [SpecialName]
  protected virtual void raise_PropertyChanged(object value0, PropertyChangedEventArgs value1)
  {
    PropertyChangedEventHandler storePropertyChanged = this.\u003Cbacking_store\u003EPropertyChanged;
    if (storePropertyChanged == null)
      return;
    storePropertyChanged(value0, value1);
  }

  public unsafe ALandscapeGizmoActor* GetGizmo() => (ALandscapeGizmoActor*) *(long*) this.gizmo;

  public int Index => this.index;

  public unsafe string GizmoName
  {
    get
    {
      int num = \u003CModule\u003E.FString\u002EInStr((FString*) ((IntPtr) this.gizmo + 8L), (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_13JOFGPIOO\u0040\u003F\u0024AA\u003F4\u003F\u0024AA\u003F\u0024AA\u0040, 1U, 0U, -1);
      FString fstring;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EMid((FString*) ((IntPtr) this.gizmo + 8L), &fstring, num + 1, int.MaxValue);
      string str;
      try
      {
        str = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      return str;
    }
  }
}
