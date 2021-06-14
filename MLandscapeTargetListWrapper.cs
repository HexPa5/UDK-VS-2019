// Decompiled with JetBrains decompiler
// Type: MLandscapeTargetListWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

internal class MLandscapeTargetListWrapper : INotifyPropertyChanged
{
  private int index;
  private unsafe FLandscapeTargetListInfo* targetinfo;
  private BitmapSource bitmap;

  public virtual event PropertyChangedEventHandler PropertyChanged;

  [SpecialName]
  protected virtual void raise_PropertyChanged(object value0, PropertyChangedEventArgs value1)
  {
    PropertyChangedEventHandler storePropertyChanged = this.\u003Cbacking_store\u003EPropertyChanged;
    if (storePropertyChanged == null)
      return;
    storePropertyChanged(value0, value1);
  }

  public unsafe MLandscapeTargetListWrapper(int InIndex, FLandscapeTargetListInfo* InTargetInfo)
  {
    this.index = InIndex;
    this.targetinfo = InTargetInfo;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    FLandscapeTargetListInfo* targetinfo = this.targetinfo;
    switch (*(int*) ((IntPtr) targetinfo + 16L))
    {
      case 0:
        FString fstring1;
        FString* editorResourcesDir = \u003CModule\u003E.GetEditorResourcesDir(&fstring1);
        // ISSUE: fault handler
        try
        {
          FString fstring2;
          FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1EO\u0040KHJDFLBN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAa\u003F\u0024AAr\u003F\u0024AAg\u003F\u0024AAe\u003F\u0024AAt\u003F\u0024AA_\u003F\u0024AAH\u003F\u0024AAe\u003F\u0024AAi\u003F\u0024AAg\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAm\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir));
          // ISSUE: fault handler
          try
          {
            this.bitmap = (BitmapSource) new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        break;
      case 1:
        this.bitmap = \u003CModule\u003E.ThumbnailToolsCLR\u002EGetBitmapSourceForObject((UObject*) *(long*) (*(long*) ((IntPtr) targetinfo + 20L) + 8L));
        break;
    }
  }

  public unsafe ELandscapeToolTargetType GetTargetType() => (ELandscapeToolTargetType) *(int*) ((IntPtr) this.targetinfo + 16L);

  public unsafe FName* GetLayerName([In] FName* obj0)
  {
    ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
    FName fname;
    FName* fnamePtr = num == 0UL || *(long*) num == 0L ? \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (EName) 0) : (FName*) (*(long*) num + 96L);
    // ISSUE: cpblk instruction
    __memcpy((IntPtr) obj0, (IntPtr) fnamePtr, 8);
    return obj0;
  }

  public int Index => this.index;

  public unsafe int DebugColor
  {
    get
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      return num != 0UL ? *(int*) ((long) num + 24L) : 0;
    }
  }

  public BitmapSource Bitmap => this.bitmap;

  public unsafe string TargetName
  {
    get
    {
      FString* targetinfo = (FString*) this.targetinfo;
      return new string(\u003CModule\u003E.FString\u002E\u002A(targetinfo), 0, \u003CModule\u003E.FString\u002ELen(targetinfo));
    }
  }

  public unsafe float Hardness
  {
    get
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      return num == 0UL || *(long*) num == 0L ? 0.0f : *(float*) (*(long*) num + 112L);
    }
    set
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      if (num == 0UL || *(long*) num == 0L)
        return;
      *(float*) (*(long*) *(long*) ((IntPtr) this.targetinfo + 20L) + 112L) = \u003CModule\u003E.Clamp\u003Cfloat\u003E(value, 0.0f, 1f);
    }
  }

  public unsafe bool IsNoWeightBlend
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      return num != 0UL && *(long*) num != 0L && (*(int*) (*(long*) num + 116L) & 1) != 0;
    }
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      ulong num1 = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      if (num1 == 0UL || *(long*) num1 == 0L)
        return;
      long num2 = *(long*) num1 + 116L;
      long num3 = num2;
      *(int*) num3 = *(int*) num3 ^ ((value ? 1 : 0) ^ *(int*) num2) & 1;
    }
  }

  public unsafe bool IsSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) this.targetinfo + 28L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      *(int*) ((IntPtr) this.targetinfo + 28L) = value ? 1 : 0;
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      if (num != 0UL)
      {
        *(int*) ((long) num + 28L) = *(int*) ((long) num + 28L) & -2;
        *(int*) ((long) num + 28L) = *(int*) ((long) num + 28L) | (value ? 1 : 0) & 1;
      }
      MLandscapeTargetListWrapper targetListWrapper = this;
      targetListWrapper.raise_PropertyChanged((object) targetListWrapper, new PropertyChangedEventArgs(nameof (IsSelected)));
    }
  }

  public unsafe string PhysMaterial
  {
    get
    {
      uint num1 = 0;
      ulong num2 = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      FString fstring;
      string str;
      if (num2 != 0UL && *(long*) num2 != 0L)
      {
        ulong num3 = (ulong) *(long*) (*(long*) num2 + 104L);
        if (num3 != 0UL)
        {
          FString* pathName = \u003CModule\u003E.UObject\u002EGetPathName((UObject*) num3, &fstring, (UObject*) 0L);
          try
          {
            num1 = 1U;
            str = new string(\u003CModule\u003E.FString\u002E\u002A(pathName), 0, \u003CModule\u003E.FString\u002ELen(pathName));
            goto label_8;
          }
          __fault
          {
            if (((int) num1 & 1) != 0)
            {
              num1 &= 4294967294U;
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
            }
          }
        }
      }
      str = "None";
label_8:
      if (((int) num1 & 1) != 0)
      {
        uint num3 = num1 & 4294967294U;
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      }
      return str;
    }
    set
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      if (num == 0UL || *(long*) num == 0L)
        return;
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, value);
      try
      {
        *(long*) (*(long*) *(long*) ((IntPtr) this.targetinfo + 20L) + 104L) = (long) \u003CModule\u003E.FindObject\u003Cclass\u0020UPhysicalMaterial\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      MLandscapeTargetListWrapper targetListWrapper = this;
      targetListWrapper.raise_PropertyChanged((object) targetListWrapper, new PropertyChangedEventArgs(nameof (PhysMaterial)));
    }
  }

  public unsafe string SourceFilePath
  {
    get
    {
      uint num1 = 0;
      FLandscapeTargetListInfo* targetinfo = this.targetinfo;
      FString fstring1;
      string str1;
      FString fstring2;
      if (*(int*) ((IntPtr) targetinfo + 16L) == 0)
      {
        ulong num2 = (ulong) *(long*) ((IntPtr) targetinfo + 32L);
        string str2;
        if (num2 != 0UL && \u003CModule\u003E.FString\u002ELen((FString*) ((long) num2 + 776L)) != 0)
        {
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, \u003CModule\u003E.FString\u002E\u002A((FString*) (*(long*) ((IntPtr) this.targetinfo + 32L) + 776L)));
          try
          {
            num1 = 1U;
            str2 = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring1), 0, \u003CModule\u003E.FString\u002ELen(&fstring1));
          }
          __fault
          {
            if (((int) num1 & 1) != 0)
            {
              num1 &= 4294967294U;
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
            }
          }
        }
        else
          str2 = "None";
        try
        {
          str1 = str2;
        }
        __fault
        {
          if (((int) num1 & 1) != 0)
          {
            num1 &= 4294967294U;
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
        }
      }
      else
      {
        ulong num2 = (ulong) *(long*) ((IntPtr) targetinfo + 20L);
        string str2;
        if (num2 != 0UL && *(long*) num2 != 0L && \u003CModule\u003E.FString\u002ELen((FString*) ((long) num2 + 32L)) != 0)
        {
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A((FString*) (*(long*) ((IntPtr) this.targetinfo + 20L) + 32L)));
          try
          {
            try
            {
              num1 = 2U;
              str2 = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
            }
            __fault
            {
              if (((int) num1 & 2) != 0)
              {
                num1 &= 4294967293U;
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
              }
            }
          }
          __fault
          {
            if (((int) num1 & 1) != 0)
            {
              num1 &= 4294967294U;
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
            }
          }
        }
        else
          str2 = "None";
        try
        {
          try
          {
            str1 = str2;
          }
          __fault
          {
            if (((int) num1 & 2) != 0)
            {
              num1 &= 4294967293U;
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
            }
          }
        }
        __fault
        {
          if (((int) num1 & 1) != 0)
          {
            num1 &= 4294967294U;
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
        }
      }
      try
      {
        if (((int) num1 & 2) != 0)
        {
          num1 &= 4294967293U;
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        }
      }
      __fault
      {
        if (((int) num1 & 1) != 0)
        {
          num1 &= 4294967294U;
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
      }
      if (((int) num1 & 1) != 0)
      {
        uint num2 = num1 & 4294967294U;
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      }
      return str1;
    }
    set
    {
      FLandscapeTargetListInfo* targetinfo = this.targetinfo;
      if (*(int*) ((IntPtr) targetinfo + 16L) == 0)
      {
        if (*(long*) ((IntPtr) targetinfo + 32L) == 0L)
          return;
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, value);
        try
        {
          \u003CModule\u003E.FStringNoInit\u002E\u003D((FStringNoInit*) (*(long*) ((IntPtr) this.targetinfo + 32L) + 776L), fstring2);
        }
        __fault
        {
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        MLandscapeTargetListWrapper targetListWrapper = this;
        targetListWrapper.raise_PropertyChanged((object) targetListWrapper, new PropertyChangedEventArgs(nameof (SourceFilePath)));
      }
      else
      {
        ulong num = (ulong) *(long*) ((IntPtr) targetinfo + 20L);
        if (num == 0UL || *(long*) num == 0L)
          return;
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, value);
        try
        {
          \u003CModule\u003E.FStringNoInit\u002E\u003D((FStringNoInit*) (*(long*) ((IntPtr) this.targetinfo + 20L) + 32L), fstring2);
        }
        __fault
        {
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        MLandscapeTargetListWrapper targetListWrapper = this;
        targetListWrapper.raise_PropertyChanged((object) targetListWrapper, new PropertyChangedEventArgs(nameof (SourceFilePath)));
      }
    }
  }

  public unsafe bool ViewmodeR
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      return num != 0UL && (*(int*) ((long) num + 24L) & 1) != 0;
    }
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      if (num == 0UL)
        return;
      if (value)
        *(int*) ((long) num + 24L) = 1;
      else
        *(int*) ((long) num + 24L) = 0;
      MLandscapeTargetListWrapper targetListWrapper = this;
      targetListWrapper.raise_PropertyChanged((object) targetListWrapper, new PropertyChangedEventArgs("Viewmode"));
    }
  }

  public unsafe bool ViewmodeG
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      return num != 0UL && (*(int*) ((long) num + 24L) & 2) != 0;
    }
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      if (num == 0UL)
        return;
      if (value)
        *(int*) ((long) num + 24L) = 2;
      else
        *(int*) ((long) num + 24L) = 0;
      MLandscapeTargetListWrapper targetListWrapper = this;
      targetListWrapper.raise_PropertyChanged((object) targetListWrapper, new PropertyChangedEventArgs("Viewmode"));
    }
  }

  public unsafe bool ViewmodeB
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      return num != 0UL && (*(int*) ((long) num + 24L) & 4) != 0;
    }
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      if (num == 0UL)
        return;
      if (value)
        *(int*) ((long) num + 24L) = 4;
      else
        *(int*) ((long) num + 24L) = 0;
      MLandscapeTargetListWrapper targetListWrapper = this;
      targetListWrapper.raise_PropertyChanged((object) targetListWrapper, new PropertyChangedEventArgs("Viewmode"));
    }
  }

  public unsafe bool ViewmodeNone
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      return num != 0UL && *(int*) ((long) num + 24L) == 0;
    }
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      ulong num = (ulong) *(long*) ((IntPtr) this.targetinfo + 20L);
      if (num == 0UL || !value)
        return;
      *(int*) ((long) num + 24L) = 0;
    }
  }
}
