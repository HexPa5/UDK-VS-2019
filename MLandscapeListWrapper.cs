// Decompiled with JetBrains decompiler
// Type: MLandscapeListWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

internal class MLandscapeListWrapper : INotifyPropertyChanged
{
  private int index;
  private unsafe FLandscapeListInfo* landscapeinfo;

  public virtual event PropertyChangedEventHandler PropertyChanged;

  [SpecialName]
  protected virtual void raise_PropertyChanged(object value0, PropertyChangedEventArgs value1)
  {
    PropertyChangedEventHandler storePropertyChanged = this.\u003Cbacking_store\u003EPropertyChanged;
    if (storePropertyChanged == null)
      return;
    storePropertyChanged(value0, value1);
  }

  public unsafe MLandscapeListWrapper(int InIndex, FLandscapeListInfo* InInfo)
  {
    this.index = InIndex;
    this.landscapeinfo = InInfo;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public unsafe string LandscapeName
  {
    get
    {
      FString* landscapeinfo = (FString*) this.landscapeinfo;
      return new string(\u003CModule\u003E.FString\u002E\u002A(landscapeinfo), 0, \u003CModule\u003E.FString\u002ELen(landscapeinfo));
    }
  }

  public unsafe string LandscapeGuid
  {
    get
    {
      FString fstring;
      FString* fstringPtr = \u003CModule\u003E.FGuid\u002EString((FGuid*) ((IntPtr) this.landscapeinfo + 16L), &fstring);
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

  public unsafe string LandscapeData
  {
    get
    {
      ulong num1 = (ulong) *(long*) ((IntPtr) this.landscapeinfo + 32L);
      int num2 = num1 == 0UL ? 0 : \u003CModule\u003E.TMapBase\u003Cunsigned\u0020__int64\u002CULandscapeHeightfieldCollisionComponent\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003Cunsigned\u0020__int64\u002CULandscapeHeightfieldCollisionComponent\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E*) ((long) num1 + 264L));
      ulong num3 = (ulong) *(long*) ((IntPtr) this.landscapeinfo + 32L);
      int num4 = num3 == 0UL ? 0 : \u003CModule\u003E.TMapBase\u003Cunsigned\u0020__int64\u002CULandscapeComponent\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003Cunsigned\u0020__int64\u002CULandscapeComponent\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E*) ((long) num3 + 192L));
      FLandscapeListInfo* landscapeinfo = this.landscapeinfo;
      FString fstring1;
      FString* fstringPtr1 = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u002Cint\u002Cint\u002Cint\u003E(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FG\u0040CGBIHMBE\u0040\u003F\u0024AA\u003F5\u003F\u0024AA\u003F9\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CD\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAm\u003F\u0024AAp\u003F\u0024AAs\u003F\u0024AA\u003F3\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F1\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F0\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CD\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAm\u003F\u0024AAp\u003F\u0024AAQ\u003F\u0024AAu\u003F\u0024AAa\u003F\u0024AAd\u003F\u0024AA\u003F3\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F0\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CD\u0040, num4, num2, *(int*) ((IntPtr) landscapeinfo + 40L), *(int*) ((IntPtr) landscapeinfo + 44L));
      string str;
      try
      {
        FString fstring2;
        FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B((FString*) this.landscapeinfo, &fstring2, fstringPtr1);
        try
        {
          str = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr2), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr2));
        }
        __fault
        {
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      return str;
    }
  }

  public unsafe string LandscapeCompNum
  {
    get
    {
      ulong num1 = (ulong) *(long*) ((IntPtr) this.landscapeinfo + 32L);
      int num2 = num1 == 0UL ? 0 : \u003CModule\u003E.TMapBase\u003Cunsigned\u0020__int64\u002CULandscapeComponent\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003Cunsigned\u0020__int64\u002CULandscapeComponent\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E*) ((long) num1 + 192L));
      FString fstring;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_15KNBIKKIN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, num2);
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
