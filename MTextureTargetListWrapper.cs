// Decompiled with JetBrains decompiler
// Type: MTextureTargetListWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

internal class MTextureTargetListWrapper : INotifyPropertyChanged
{
  private int ListIndex;
  private unsafe FTextureTargetListInfo* TextureTargetInfo;
  private BitmapSource BitmapSrc;

  public virtual event PropertyChangedEventHandler PropertyChanged;

  [SpecialName]
  protected virtual void raise_PropertyChanged(object value0, PropertyChangedEventArgs value1)
  {
    PropertyChangedEventHandler storePropertyChanged = this.\u003Cbacking_store\u003EPropertyChanged;
    if (storePropertyChanged == null)
      return;
    storePropertyChanged(value0, value1);
  }

  public unsafe MTextureTargetListWrapper(int InIndex, FTextureTargetListInfo* InTargetInfo)
  {
    this.ListIndex = InIndex;
    this.TextureTargetInfo = InTargetInfo;
    this.BitmapSrc = (BitmapSource) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public unsafe UTexture2D* GetTargetTexture() => (UTexture2D*) *(long*) this.TextureTargetInfo;

  public int Index => this.ListIndex;

  public unsafe BitmapSource Bitmap
  {
    get
    {
      BitmapSource bitmapSourceForObject = \u003CModule\u003E.ThumbnailToolsCLR\u002EGetBitmapSourceForObject((UObject*) *(long*) this.TextureTargetInfo);
      this.BitmapSrc = bitmapSourceForObject;
      return bitmapSourceForObject;
    }
  }

  public unsafe string TargetName
  {
    get
    {
      FString fstring;
      FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) *(long*) this.TextureTargetInfo, &fstring);
      string str;
      try
      {
        str = new string(\u003CModule\u003E.FString\u002E\u002A(name), 0, \u003CModule\u003E.FString\u002ELen(name));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      return str;
    }
  }

  public unsafe string TargetPathName
  {
    get
    {
      FString fstring1;
      \u003CModule\u003E.UObject\u002EGetPathName((UObject*) *(long*) this.TextureTargetInfo, &fstring1, (UObject*) 0L);
      string str;
      try
      {
        int num = \u003CModule\u003E.FString\u002EInStr(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_13JOFGPIOO\u0040\u003F\u0024AA\u003F4\u003F\u0024AA\u003F\u0024AA\u0040, 1U, 0U, -1);
        if (num > 0)
        {
          FString fstring2;
          FString* fstringPtr = \u003CModule\u003E.FString\u002ELeft(&fstring1, &fstring2, num);
          try
          {
            \u003CModule\u003E.FString\u002E\u003D(&fstring1, fstringPtr);
          }
          __fault
          {
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        }
        str = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring1), 0, \u003CModule\u003E.FString\u002ELen(&fstring1));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      return str;
    }
  }

  public unsafe string DimensionAndFormat
  {
    get
    {
      long num1 = *(long*) this.TextureTargetInfo;
      long num2 = num1;
      FString fstring1;
      ref FString local1 = ref fstring1;
      long num3 = (long) __calli((__FnPtr<FString* (IntPtr, FString*, int)>) *(long*) (*(long*) num1 + 440L))((int) num2, (FString*) ref local1, new IntPtr(1));
      FString fstring2;
      try
      {
        long num4 = *(long*) this.TextureTargetInfo;
        long num5 = num4;
        FString fstring3;
        ref FString local2 = ref fstring3;
        long num6 = (long) __calli((__FnPtr<FString* (IntPtr, FString*, int)>) *(long*) (*(long*) num4 + 440L))((int) num5, (FString*) ref local2, IntPtr.Zero);
        try
        {
          \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1O\u0040HAOEHKBE\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA\u003F\u0024FL\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA\u003F\u0024FN\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.FString\u002E\u002A((FString*) num6), \u003CModule\u003E.FString\u002E\u002A((FString*) num3));
        }
        __fault
        {
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        try
        {
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
        }
        __fault
        {
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      string str;
      try
      {
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        str = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
      return str;
    }
  }

  public unsafe string KiloByteSize
  {
    get
    {
      char* chPtr = (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1M\u0040HAMADPKO\u0040\u003F\u0024AAK\u003F\u0024AAB\u003F\u0024AAy\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040;
      long num1 = *(long*) this.TextureTargetInfo;
      float num2 = (float) __calli((__FnPtr<int (IntPtr)>) *(long*) (*(long*) num1 + 496L))((IntPtr) num1) * 0.0009765625f;
      if ((double) num2 > 1024.0)
      {
        chPtr = (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1M\u0040JPPNJKEO\u0040\u003F\u0024AAM\u003F\u0024AAB\u003F\u0024AAy\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040;
        num2 *= 0.0009765625f;
      }
      FString fstring;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cfloat\u002Cwchar_t\u0020\u002A\u003E(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040FPJAHJMF\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AA5\u003F\u0024AA\u003F4\u003F\u0024AA2\u003F\u0024AAf\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA\u003F\u0024AA\u0040, num2, chPtr);
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

  public unsafe string UndoCount
  {
    get
    {
      FTextureTargetListInfo* ftextureTargetListInfoPtr = (FTextureTargetListInfo*) ((IntPtr) this.TextureTargetInfo + 12L);
      if ((uint) *(int*) ftextureTargetListInfoPtr > 0U)
      {
        FString fstring;
        FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cunsigned\u0020int\u003E(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1DC\u0040MPBJKACG\u0040\u003F\u0024AAA\u003F\u0024AAv\u003F\u0024AAa\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAa\u003F\u0024AAb\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AA\u003F5\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAo\u003F\u0024AA\u003F5\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAu\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AA\u003F3\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (uint) *(int*) ftextureTargetListInfoPtr);
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
      FString fstring1;
      FString* fstringPtr1 = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
      string str1;
      try
      {
        str1 = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr1), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr1));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      return str1;
    }
  }

  public unsafe bool IsSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) this.TextureTargetInfo + 8L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      *(int*) ((IntPtr) this.TextureTargetInfo + 8L) = value ? 1 : 0;
      MTextureTargetListWrapper targetListWrapper = this;
      targetListWrapper.raise_PropertyChanged((object) targetListWrapper, new PropertyChangedEventArgs(nameof (IsSelected)));
    }
  }
}
