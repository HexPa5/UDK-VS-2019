// Decompiled with JetBrains decompiler
// Type: MLightmapResRatioWindow
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using ELightmapResRatioAdjustLevels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using UnrealEd;

internal class MLightmapResRatioWindow : MWPFWindowWrapper, INotifyPropertyChanged
{
  public unsafe uint InitLightmapResRatioWindow(HWND__* InParentWindowHandle)
  {
    string InWindowTitle = \u003CModule\u003E.CLRTools\u002ELocalizeString("LightmapResRatioWindow_WindowTitle", (string) null, (string) null, (string) null);
    string InWPFXamlFileName = "LightmapResRatioWindow.xaml";
    int num = *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 64L) == -1 || *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 68L) == -1 ? 1 : 0;
    int InPositionY = *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 68L);
    int InPositionX = *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 64L);
    int window = (int) this.CreateWindow(InParentWindowHandle, InWindowTitle, InWPFXamlFileName, InPositionX, InPositionY, 0, 0, 28, 0, 1, 0);
    this.FinalizeLayout(num != 0);
    if (window == 0)
      return 0;
    Visual rootVisual = this.InteropWindow.op_MemberSelection().RootVisual;
    ((FrameworkElement) rootVisual).DataContext = (object) this;
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "PrimitiveStaticMeshesCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "PrimitiveStaticMeshes");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "PrimitiveBSPSurfacesCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "PrimitiveBSPSurfaces");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "PrimitiveTerrainsCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "PrimitiveTerrains");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "PrimitiveFluidSurfacesCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "PrimitiveFluidSurfaces");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "LevelSelectRadio_Current"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsLevelSelectCurrent");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "LevelSelectRadio_Selected"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsLevelSelectSelected");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "LevelSelectRadio_AllLoaded"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsLevelSelectAllLoaded");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "SelectedObjectsOnlyCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "SelectedObjectsOnly");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "RatioDragSlider"), RangeBase.ValueProperty, (object) this, "RatioValue");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "StaticMeshMinDragSlider"), RangeBase.ValueProperty, (object) this, "MinStaticMeshes", (IValueConverter) new RoundedIntToDoubleConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "StaticMeshMaxDragSlider"), RangeBase.ValueProperty, (object) this, "MaxStaticMeshes", (IValueConverter) new RoundedIntToDoubleConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "BSPMinDragSlider"), RangeBase.ValueProperty, (object) this, "MinBSPSurfaces", (IValueConverter) new RoundedIntToDoubleConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "BSPMaxDragSlider"), RangeBase.ValueProperty, (object) this, "MaxBSPSurfaces", (IValueConverter) new RoundedIntToDoubleConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "TerrainMinDragSlider"), RangeBase.ValueProperty, (object) this, "MinTerrains", (IValueConverter) new RoundedIntToDoubleConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "TerrainMaxDragSlider"), RangeBase.ValueProperty, (object) this, "MaxTerrains", (IValueConverter) new RoundedIntToDoubleConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FluidMinDragSlider"), RangeBase.ValueProperty, (object) this, "MinFluidSurfaces", (IValueConverter) new RoundedIntToDoubleConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FluidMaxDragSlider"), RangeBase.ValueProperty, (object) this, "MaxFluidSurfaces", (IValueConverter) new RoundedIntToDoubleConverter());
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "RatioApplyButton")).Click += new RoutedEventHandler(this.ApplyRatioButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "RatioCloseButton")).Click += new RoutedEventHandler(this.CloseButton_Click);
    MLightmapResRatioWindow mlightmapResRatioWindow = this;
    mlightmapResRatioWindow.PropertyChanged += new PropertyChangedEventHandler(mlightmapResRatioWindow.OnLightmapResRatioPropertyChanged);
    \u003CModule\u003E.ShowWindow(this.GetWindowHandle(), 5);
    return 1;
  }

  protected void OnLightmapResRatioPropertyChanged(object Owner, PropertyChangedEventArgs Args)
  {
  }

  protected void ApplyRatioButton_Click(object Owner, RoutedEventArgs Args)
  {
    int num = (int) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EApplyRatioAdjustment();
  }

  protected unsafe void CloseButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.ShowWindow(this.GetWindowHandle(), 0);

  public virtual event PropertyChangedEventHandler PropertyChanged;

  [SpecialName]
  protected virtual void raise_PropertyChanged(object value0, PropertyChangedEventArgs value1)
  {
    PropertyChangedEventHandler storePropertyChanged = this.\u003Cbacking_store\u003EPropertyChanged;
    if (storePropertyChanged == null)
      return;
    storePropertyChanged(value0, value1);
  }

  public void RefreshAllProperties() => this.OnPropertyChanged((string) null);

  public virtual void OnPropertyChanged(string Info)
  {
    MLightmapResRatioWindow mlightmapResRatioWindow = this;
    mlightmapResRatioWindow.raise_PropertyChanged((object) mlightmapResRatioWindow, new PropertyChangedEventArgs(Info));
  }

  public unsafe bool PrimitiveStaticMeshes
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 36L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 36L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 36L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (PrimitiveStaticMeshes));
    }
  }

  public unsafe bool PrimitiveBSPSurfaces
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 40L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 40L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 40L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (PrimitiveBSPSurfaces));
    }
  }

  public unsafe bool PrimitiveTerrains
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 44L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 44L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 44L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (PrimitiveTerrains));
    }
  }

  public unsafe bool PrimitiveFluidSurfaces
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 48L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 48L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 48L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (PrimitiveFluidSurfaces));
    }
  }

  public unsafe bool IsLevelSelectCurrent
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 56L) == 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 56L) == 0;
      if (value == flag)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      Options options = (Options) num;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 56L) = (int) options;
      this.OnPropertyChanged(nameof (IsLevelSelectCurrent));
    }
  }

  public unsafe bool IsLevelSelectSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 56L) == 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 56L) == 1;
      if (value == flag)
        return;
      int num = 1;
      if (!value)
        num = -num;
      Options options = (Options) num;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 56L) = (int) options;
      this.OnPropertyChanged(nameof (IsLevelSelectSelected));
    }
  }

  public unsafe bool IsLevelSelectAllLoaded
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 56L) == 2;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 56L) == 2;
      if (value == flag)
        return;
      Options options = value ? (Options) 2 : (Options) -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 56L) = (int) options;
      this.OnPropertyChanged(nameof (IsLevelSelectAllLoaded));
    }
  }

  public unsafe bool SelectedObjectsOnly
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 60L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 60L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 60L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (SelectedObjectsOnly));
    }
  }

  public unsafe double RatioValue
  {
    get => (double) *(float*) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet();
    set
    {
      float num = (float) value;
      FLightmapResRatioAdjustSettings* ratioAdjustSettingsPtr = \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet();
      if ((double) num == (double) *(float*) ratioAdjustSettingsPtr)
        return;
      *(float*) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() = num;
      this.OnPropertyChanged(nameof (RatioValue));
    }
  }

  public unsafe int MinStaticMeshes
  {
    get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 4L);
    set
    {
      if (value == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 4L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 4L) = value;
      this.OnPropertyChanged(nameof (MinStaticMeshes));
    }
  }

  public unsafe int MaxStaticMeshes
  {
    get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 8L);
    set
    {
      if (value == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 8L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 8L) = value;
      this.OnPropertyChanged(nameof (MaxStaticMeshes));
    }
  }

  public unsafe int MinBSPSurfaces
  {
    get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 12L);
    set
    {
      if (value == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 12L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 12L) = value;
      this.OnPropertyChanged(nameof (MinBSPSurfaces));
    }
  }

  public unsafe int MaxBSPSurfaces
  {
    get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 16L);
    set
    {
      if (value == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 16L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 16L) = value;
      this.OnPropertyChanged(nameof (MaxBSPSurfaces));
    }
  }

  public unsafe int MinTerrains
  {
    get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 20L);
    set
    {
      if (value == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 20L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 20L) = value;
      this.OnPropertyChanged(nameof (MinTerrains));
    }
  }

  public unsafe int MaxTerrains
  {
    get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 24L);
    set
    {
      if (value == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 24L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 24L) = value;
      this.OnPropertyChanged(nameof (MaxTerrains));
    }
  }

  public unsafe int MinFluidSurfaces
  {
    get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 28L);
    set
    {
      if (value == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 28L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 28L) = value;
      this.OnPropertyChanged(nameof (MinFluidSurfaces));
    }
  }

  public unsafe int MaxFluidSurfaces
  {
    get => *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 32L);
    set
    {
      if (value == *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 32L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightmapResRatioAdjustSettings\u002EGet() + 32L) = value;
      this.OnPropertyChanged(nameof (MaxFluidSurfaces));
    }
  }
}
