// Decompiled with JetBrains decompiler
// Type: MFoliageMeshWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

internal class MFoliageMeshWrapper : INotifyPropertyChanged
{
  private int index;
  private unsafe FFoliageMeshUIInfo* mesh;
  private unsafe UInstancedFoliageSettings* settings;
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

  public unsafe MFoliageMeshWrapper(int InIndex, FFoliageMeshUIInfo* InMesh)
  {
    this.index = InIndex;
    this.mesh = InMesh;
    this.settings = (UInstancedFoliageSettings*) *(long*) (*(long*) ((IntPtr) InMesh + 8L) + 144L);
    // ISSUE: explicit constructor call
    base.\u002Ector();
    MFoliageMeshWrapper mfoliageMeshWrapper = this;
    mfoliageMeshWrapper.bitmap = \u003CModule\u003E.ThumbnailToolsCLR\u002EGetBitmapSourceForObject((UObject*) *(long*) mfoliageMeshWrapper.mesh);
  }

  public unsafe UStaticMesh* GetStaticMesh() => (UStaticMesh*) *(long*) this.mesh;

  public int Index => this.index;

  public BitmapSource Bitmap => this.bitmap;

  public unsafe string StaticMeshName
  {
    get
    {
      FString fstring;
      FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) *(long*) this.mesh, &fstring);
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

  public unsafe string SettingsObjectName
  {
    get
    {
      uint num1 = 0;
      FString fstring1;
      FString fstring2;
      FString* fstringPtr;
      FString fstring3;
      if (\u003CModule\u003E.UObject\u002EIsA(\u003CModule\u003E.UObject\u002EGetOuter((UObject*) this.settings), \u003CModule\u003E.UPackage\u002EStaticClass()) != 0U)
      {
        FString* pathName = \u003CModule\u003E.UObject\u002EGetPathName((UObject*) this.settings, &fstring1, (UObject*) 0L);
        try
        {
          num1 = 1U;
          fstringPtr = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(pathName));
          try
          {
            num1 = 3U;
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
      {
        fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1EI\u0040BPHFJCOM\u0040\u003F\u0024AAF\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AAi\u003F\u0024AAa\u003F\u0024AAg\u003F\u0024AAe\u003F\u0024AAM\u003F\u0024AAo\u003F\u0024AAd\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAN\u003F\u0024AAo\u003F\u0024AAt\u003F\u0024AAS\u003F\u0024AAh\u003F\u0024AAa\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAd\u003F\u0024AAS\u003F\u0024AAe\u003F\u0024AAt\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAg\u003F\u0024AAs\u003F\u0024AAO\u003F\u0024AAb\u003F\u0024AAj\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
        try
        {
          try
          {
            try
            {
              num1 = 4U;
            }
            __fault
            {
              if (((int) num1 & 4) != 0)
              {
                num1 &= 4294967291U;
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
              }
            }
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
      string str;
      try
      {
        try
        {
          try
          {
            str = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
          }
          __fault
          {
            if (((int) num1 & 4) != 0)
            {
              num1 &= 4294967291U;
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
          }
          if (((int) num1 & 4) != 0)
          {
            num1 &= 4294967291U;
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
        }
        __fault
        {
          if (((int) num1 & 2) != 0)
          {
            num1 &= 4294967293U;
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
        }
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
      return str;
    }
  }

  public unsafe bool IsUsingSharedSettingsObject
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.UObject\u002EIsA(\u003CModule\u003E.UObject\u002EGetOuter((UObject*) this.settings), \u003CModule\u003E.UPackage\u002EStaticClass()) != 0U;
  }

  public unsafe float Density
  {
    get => *(float*) ((IntPtr) this.settings + 96L);
    set => *(float*) ((IntPtr) this.settings + 96L) = value;
  }

  public unsafe float Radius
  {
    get => *(float*) ((IntPtr) this.settings + 100L);
    set => *(float*) ((IntPtr) this.settings + 100L) = value;
  }

  public unsafe bool AlignToNormal
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 3) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 3 ^ *(int*) uinstancedFoliageSettingsPtr1) & 8;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool RandomYaw
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 4) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 4 ^ *(int*) uinstancedFoliageSettingsPtr1) & 16;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool UniformScale
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 5) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 5 ^ *(int*) uinstancedFoliageSettingsPtr1) & 32;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe float ScaleMinX
  {
    get => *(float*) ((IntPtr) this.settings + 104L);
    set => *(float*) ((IntPtr) this.settings + 104L) = value;
  }

  public unsafe float ScaleMinY
  {
    get => *(float*) ((IntPtr) this.settings + 108L);
    set => *(float*) ((IntPtr) this.settings + 108L) = value;
  }

  public unsafe float ScaleMinZ
  {
    get => *(float*) ((IntPtr) this.settings + 112L);
    set => *(float*) ((IntPtr) this.settings + 112L) = value;
  }

  public unsafe float ScaleMaxX
  {
    get => *(float*) ((IntPtr) this.settings + 116L);
    set => *(float*) ((IntPtr) this.settings + 116L) = value;
  }

  public unsafe float ScaleMaxY
  {
    get => *(float*) ((IntPtr) this.settings + 120L);
    set => *(float*) ((IntPtr) this.settings + 120L) = value;
  }

  public unsafe float ScaleMaxZ
  {
    get => *(float*) ((IntPtr) this.settings + 124L);
    set => *(float*) ((IntPtr) this.settings + 124L) = value;
  }

  public unsafe bool LockScaleX
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) (byte) *(int*) ((IntPtr) this.settings + 128L) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 ^ *(int*) uinstancedFoliageSettingsPtr1) & 1;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool LockScaleY
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 1) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 1 ^ *(int*) uinstancedFoliageSettingsPtr1) & 2;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool LockScaleZ
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 2) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 2 ^ *(int*) uinstancedFoliageSettingsPtr1) & 4;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe float ZOffsetMin
  {
    get => *(float*) ((IntPtr) this.settings + 164L);
    set => *(float*) ((IntPtr) this.settings + 164L) = value;
  }

  public unsafe float ZOffsetMax
  {
    get => *(float*) ((IntPtr) this.settings + 168L);
    set => *(float*) ((IntPtr) this.settings + 168L) = value;
  }

  public unsafe float AlignMaxAngle
  {
    get => *(float*) ((IntPtr) this.settings + 136L);
    set => *(float*) ((IntPtr) this.settings + 136L) = value;
  }

  public unsafe float RandomPitchAngle
  {
    get => *(float*) ((IntPtr) this.settings + 140L);
    set => *(float*) ((IntPtr) this.settings + 140L) = value;
  }

  public unsafe float GroundSlope
  {
    get => *(float*) ((IntPtr) this.settings + 144L);
    set => *(float*) ((IntPtr) this.settings + 144L) = value;
  }

  public unsafe bool IsSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 132L) >> 2) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 132L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 2 ^ *(int*) uinstancedFoliageSettingsPtr1) & 4;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ShowNothing
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 132L) >> 3) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 132L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 3 ^ *(int*) uinstancedFoliageSettingsPtr1) & 8;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ShowPaintSettings
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 132L) >> 4) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 132L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 4 ^ *(int*) uinstancedFoliageSettingsPtr1) & 16;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ShowInstanceSettings
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 132L) >> 5) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 132L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 5 ^ *(int*) uinstancedFoliageSettingsPtr1) & 32;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe float ReapplyDensityAmount
  {
    get => *(float*) ((IntPtr) this.settings + 180L);
    set => *(float*) ((IntPtr) this.settings + 180L) = value;
  }

  public unsafe bool ReapplyDensity
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 6) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 6 ^ *(int*) uinstancedFoliageSettingsPtr1) & 64;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyRadius
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 7) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 7 ^ *(int*) uinstancedFoliageSettingsPtr1) & 128;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyAlignToNormal
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 8) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 8 ^ *(int*) uinstancedFoliageSettingsPtr1) & 256;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyRandomYaw
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 9) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 9 ^ *(int*) uinstancedFoliageSettingsPtr1) & 512;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyScaleX
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 10) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 10 ^ *(int*) uinstancedFoliageSettingsPtr1) & 1024;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyScaleY
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 11) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 11 ^ *(int*) uinstancedFoliageSettingsPtr1) & 2048;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyScaleZ
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 12) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 12 ^ *(int*) uinstancedFoliageSettingsPtr1) & 4096;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyZOffset
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 17) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 17 ^ *(int*) uinstancedFoliageSettingsPtr1) & 131072;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyRandomPitchAngle
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 13) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 13 ^ *(int*) uinstancedFoliageSettingsPtr1) & 8192;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyGroundSlope
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 14) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 14 ^ *(int*) uinstancedFoliageSettingsPtr1) & 16384;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyHeight
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 15) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 15 ^ *(int*) uinstancedFoliageSettingsPtr1) & 32768;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe bool ReapplyLandscapeLayer
  {
    [return: MarshalAs(UnmanagedType.U1)] get => ((int) *(ushort*) ((IntPtr) this.settings + 130L) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      int num1 = value ? 1 : 0;
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num2 = *(int*) uinstancedFoliageSettingsPtr2 ^ (num1 << 16 ^ *(int*) uinstancedFoliageSettingsPtr1) & 65536;
      *(int*) uinstancedFoliageSettingsPtr2 = num2;
    }
  }

  public unsafe string HeightMin
  {
    get
    {
      uint num1 = 0;
      float num2 = *(float*) ((IntPtr) this.settings + 148L);
      FString fstring1;
      FString* fstringPtr;
      FString fstring2;
      if ((double) num2 == -262144.0)
      {
        fstringPtr = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
        try
        {
          num1 = 1U;
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
        fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cfloat\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_15HBBGCAG\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAf\u003F\u0024AA\u003F\u0024AA\u0040, num2);
        try
        {
          try
          {
            num1 = 2U;
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
      string str;
      try
      {
        try
        {
          str = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
        }
        __fault
        {
          if (((int) num1 & 2) != 0)
          {
            num1 &= 4294967293U;
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
        }
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
        uint num3 = num1 & 4294967294U;
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      }
      return str;
    }
    set => *(float*) ((IntPtr) this.settings + 148L) = value.Length != 0 ? (float) Convert.ToDouble(value) : -262144f;
  }

  public unsafe string HeightMax
  {
    get
    {
      uint num1 = 0;
      float num2 = *(float*) ((IntPtr) this.settings + 152L);
      FString fstring1;
      FString* fstringPtr;
      FString fstring2;
      if ((double) num2 == 262144.0)
      {
        fstringPtr = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
        try
        {
          num1 = 1U;
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
        fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cfloat\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1M\u0040HFECKDGI\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AA1\u003F\u0024AA\u003F4\u003F\u0024AA0\u003F\u0024AAf\u003F\u0024AA\u003F\u0024AA\u0040, num2);
        try
        {
          try
          {
            num1 = 2U;
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
      string str;
      try
      {
        try
        {
          str = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
        }
        __fault
        {
          if (((int) num1 & 2) != 0)
          {
            num1 &= 4294967293U;
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
        }
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
        uint num3 = num1 & 4294967294U;
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      }
      return str;
    }
    set => *(float*) ((IntPtr) this.settings + 152L) = value.Length != 0 ? (float) Convert.ToDouble(value) : 262144f;
  }

  public unsafe string LandscapeLayer
  {
    get
    {
      uint num1 = 0;
      FName fname;
      \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (EName) 0);
      string str;
      FString fstring;
      if (\u003CModule\u003E.FName\u002E\u003D\u003D((FName*) ((IntPtr) this.settings + 156L), &fname) != 0U)
      {
        str = "";
      }
      else
      {
        FString* fstringPtr = \u003CModule\u003E.FName\u002EToString((FName*) ((IntPtr) this.settings + 156L), &fstring);
        try
        {
          num1 = 1U;
          str = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
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
      if (((int) num1 & 1) != 0)
      {
        uint num2 = num1 & 4294967294U;
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      }
      return str;
    }
    set
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, value);
      try
      {
        FName fname;
        __memcpy((IntPtr) this.settings + 156L, (IntPtr) \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, \u003CModule\u003E.FString\u002E\u002A(fstring2), (EFindName) 1, 1U), 8);
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    }
  }

  public unsafe int MaxInstancesPerCluster
  {
    get => *(int*) ((IntPtr) this.settings + 172L);
    set
    {
      *(int*) ((IntPtr) this.settings + 172L) = value;
      this.ReallocateClusters();
    }
  }

  public unsafe float MaxClusterRadius
  {
    get => *(float*) ((IntPtr) this.settings + 176L);
    set
    {
      *(float*) ((IntPtr) this.settings + 176L) = value;
      this.ReallocateClusters();
    }
  }

  public unsafe int StartCullDistance
  {
    get => *(int*) ((IntPtr) this.settings + 184L);
    set
    {
      *(int*) ((IntPtr) this.settings + 184L) = value;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe int EndCullDistance
  {
    get => *(int*) ((IntPtr) this.settings + 188L);
    set
    {
      *(int*) ((IntPtr) this.settings + 188L) = value;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe int DetailMode
  {
    get => (int) *(byte*) ((IntPtr) this.settings + 193L);
    set
    {
      *(sbyte*) ((IntPtr) this.settings + 193L) = (sbyte) value;
      this.ReallocateClusters();
    }
  }

  public unsafe bool CastShadow
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 18 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 18 ^ *(int*) uinstancedFoliageSettingsPtr1) & 262144;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bCastDynamicShadow
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 19 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 19 ^ *(int*) uinstancedFoliageSettingsPtr1) & 524288;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bCastStaticShadow
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 20 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 20 ^ *(int*) uinstancedFoliageSettingsPtr1) & 1048576;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bSelfShadowOnly
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 21 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 21 ^ *(int*) uinstancedFoliageSettingsPtr1) & 2097152;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bNoModSelfShadow
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 22 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 22 ^ *(int*) uinstancedFoliageSettingsPtr1) & 4194304;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bAcceptsDynamicDominantLightShadows
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 23 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 23 ^ *(int*) uinstancedFoliageSettingsPtr1) & 8388608;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bCastHiddenShadow
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(byte*) ((IntPtr) this.settings + 131L) & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 24 ^ *(int*) uinstancedFoliageSettingsPtr1) & 16777216;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bCastShadowAsTwoSided
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 25 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 25 ^ *(int*) uinstancedFoliageSettingsPtr1) & 33554432;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bAcceptsLights
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 26 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 26 ^ *(int*) uinstancedFoliageSettingsPtr1) & 67108864;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bAcceptsDynamicLights
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 27 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 27 ^ *(int*) uinstancedFoliageSettingsPtr1) & 134217728;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bUseOnePassLightingOnTranslucency
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 28 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 28 ^ *(int*) uinstancedFoliageSettingsPtr1) & 268435456;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bUsePrecomputedShadows
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 29 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 29 ^ *(int*) uinstancedFoliageSettingsPtr1) & 536870912;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bCollideActors
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 30 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 30 ^ *(int*) uinstancedFoliageSettingsPtr1) & 1073741824;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bBlockActors
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 128L) >> 31 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 128L);
      *(int*) uinstancedFoliageSettingsPtr = (value ? 1 : 0) << 31 | *(int*) uinstancedFoliageSettingsPtr & int.MaxValue;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bBlockNonZeroExtent
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (*(int*) ((IntPtr) this.settings + 132L) & 1) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 132L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) ^ *(int*) uinstancedFoliageSettingsPtr1) & 1;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe bool bBlockZeroExtent
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (bool) ((uint) *(int*) ((IntPtr) this.settings + 132L) >> 1 & 1U);
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr1 = (UInstancedFoliageSettings*) ((IntPtr) this.settings + 132L);
      UInstancedFoliageSettings* uinstancedFoliageSettingsPtr2 = uinstancedFoliageSettingsPtr1;
      int num = *(int*) uinstancedFoliageSettingsPtr2 ^ ((value ? 1 : 0) << 1 ^ *(int*) uinstancedFoliageSettingsPtr1) & 2;
      *(int*) uinstancedFoliageSettingsPtr2 = num;
      \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));
    }
  }

  public unsafe int InstanceCount => \u003CModule\u003E.TArray\u003CFFoliageInstance\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFFoliageInstance\u002CFDefaultAllocator\u003E*) (*(long*) ((IntPtr) this.mesh + 8L) + 16L)) - \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003Cint\u002CFDefaultAllocator\u003E*) (*(long*) ((IntPtr) this.mesh + 8L) + 112L));

  public unsafe int ClusterCount => \u003CModule\u003E.TArray\u003CFFoliageInstanceCluster\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFFoliageInstanceCluster\u002CFDefaultAllocator\u003E*) *(long*) ((IntPtr) this.mesh + 8L));

  private unsafe void UpdateClusterSettings() => \u003CModule\u003E.FFoliageMeshInfo\u002EUpdateClusterSettings((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U));

  private unsafe void ReallocateClusters()
  {
    \u003CModule\u003E.FFoliageMeshInfo\u002EReallocateClusters((FFoliageMeshInfo*) *(long*) ((IntPtr) this.mesh + 8L), \u003CModule\u003E.AInstancedFoliageActor\u002EGetInstancedFoliageActor(1U), (UStaticMesh*) *(long*) this.mesh);
    MFoliageMeshWrapper mfoliageMeshWrapper1 = this;
    mfoliageMeshWrapper1.raise_PropertyChanged((object) mfoliageMeshWrapper1, new PropertyChangedEventArgs("InstanceCount"));
    MFoliageMeshWrapper mfoliageMeshWrapper2 = this;
    mfoliageMeshWrapper2.raise_PropertyChanged((object) mfoliageMeshWrapper2, new PropertyChangedEventArgs("ClusterCount"));
  }
}
