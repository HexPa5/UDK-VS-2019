// Decompiled with JetBrains decompiler
// Type: MGizmoImportLayerWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class MGizmoImportLayerWrapper : INotifyPropertyChanged
{
  private int index;
  private unsafe FGizmoImportLayer* layer;

  public unsafe MGizmoImportLayerWrapper(int InIndex, FGizmoImportLayer* InLayer)
  {
    this.index = InIndex;
    this.layer = InLayer;
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

  public int Index => this.index;

  public unsafe string LayerFilename
  {
    get
    {
      FString fstring;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, \u003CModule\u003E.FString\u002E\u002A((FString*) this.layer));
      string str;
      try
      {
        str = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring), 0, \u003CModule\u003E.FString\u002ELen(&fstring));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      return str;
    }
    set
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, value);
      try
      {
        \u003CModule\u003E.FString\u002E\u003D((FString*) this.layer, fstring2);
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    }
  }

  public unsafe string LayerName
  {
    get
    {
      FString fstring;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) this.layer + 16L)));
      string str;
      try
      {
        str = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring), 0, \u003CModule\u003E.FString\u002ELen(&fstring));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      return str;
    }
    set
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, value);
      try
      {
        \u003CModule\u003E.FString\u002E\u003D((FString*) ((IntPtr) this.layer + 16L), fstring2);
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    }
  }

  public unsafe bool NoImport
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) this.layer + 32L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set => *(int*) ((IntPtr) this.layer + 32L) = value ? 1 : 0;
  }
}
