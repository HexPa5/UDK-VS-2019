// Decompiled with JetBrains decompiler
// Type: MLightingToolsWindow
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using UnrealEd;

internal class MLightingToolsWindow : MWPFWindowWrapper, INotifyPropertyChanged
{
  public unsafe FLightingToolsWindow* ToolsWindow;

  public unsafe uint InitLightingToolsWindow(
    FLightingToolsWindow* InToolsWindow,
    HWND__* InParentWindowHandle)
  {
    this.ToolsWindow = InToolsWindow;
    string InWindowTitle = \u003CModule\u003E.CLRTools\u002ELocalizeString("LightingToolsWindow_WindowTitle", (string) null, (string) null, (string) null);
    string InWPFXamlFileName = "LightingToolsWindow.xaml";
    int num = *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 28L) == -1 || *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 32L) == -1 ? 1 : 0;
    int InPositionY = *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 32L);
    int InPositionX = *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 28L);
    int window = (int) this.CreateWindow(InParentWindowHandle, InWindowTitle, InWPFXamlFileName, InPositionX, InPositionY, 0, 0, 28, 0, 1, 0);
    this.FinalizeLayout(num != 0);
    if (window == 0)
      return 0;
    Visual rootVisual = this.InteropWindow.op_MemberSelection().RootVisual;
    ((FrameworkElement) rootVisual).DataContext = (object) this;
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ShowBoundsCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "ShowBounds");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ShowShadowTracesCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "ShowShadowTraces");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ShowDirectCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "ShowDirect");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ShowIndirectCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "ShowIndirect");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ShowIndirectSamplesCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "ShowSamples");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ShowDominantLightsCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "ShowDominantLights");
    MLightingToolsWindow mlightingToolsWindow = this;
    mlightingToolsWindow.PropertyChanged += new PropertyChangedEventHandler(mlightingToolsWindow.OnLightingToolsPropertyChanged);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "LightingToolsCloseButton")).Click += new RoutedEventHandler(this.CloseButton_Click);
    \u003CModule\u003E.ShowWindow(this.GetWindowHandle(), 5);
    return 1;
  }

  protected void OnLightingToolsPropertyChanged(object Owner, PropertyChangedEventArgs Args)
  {
    int num = (int) \u003CModule\u003E.FLightingToolsSettings\u002EApplyToggle();
  }

  protected unsafe void CloseButton_Click(object Owner, RoutedEventArgs Args)
  {
    \u003CModule\u003E.FLightingToolsSettings\u002EReset();
    FLightingToolsWindow* toolsWindow = this.ToolsWindow;
    \u003CModule\u003E.ShowWindow(\u003CModule\u003E.gcroot\u003CMLightingToolsWindow\u0020\u005E\u003E\u002E\u002EPE\u0024AAVMLightingToolsWindow\u0040\u0040((gcroot\u003CMLightingToolsWindow\u0020\u005E\u003E*) ((IntPtr) toolsWindow + 8L)).GetWindowHandle(), 0);
    \u003CModule\u003E.FLightingToolsWindow\u002ESaveWindowSettings(toolsWindow);
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

  public void RefreshAllProperties() => this.OnPropertyChanged((string) null);

  public virtual void OnPropertyChanged(string Info)
  {
    MLightingToolsWindow mlightingToolsWindow = this;
    mlightingToolsWindow.raise_PropertyChanged((object) mlightingToolsWindow, new PropertyChangedEventArgs(Info));
  }

  public unsafe bool ShowBounds
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) \u003CModule\u003E.FLightingToolsSettings\u002EGet() != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      FLightingToolsSettings* flightingToolsSettingsPtr = \u003CModule\u003E.FLightingToolsSettings\u002EGet();
      if ((value ? 1 : 0) == *(int*) flightingToolsSettingsPtr)
        return;
      *(int*) \u003CModule\u003E.FLightingToolsSettings\u002EGet() = value ? 1 : 0;
      this.OnPropertyChanged(nameof (ShowBounds));
    }
  }

  public unsafe bool ShowShadowTraces
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 4L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 4L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 4L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (ShowShadowTraces));
    }
  }

  public unsafe bool ShowDirect
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 8L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 8L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 8L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (ShowDirect));
    }
  }

  public unsafe bool ShowIndirect
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 12L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 12L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 12L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (ShowIndirect));
    }
  }

  public unsafe bool ShowSamples
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 16L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 16L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 16L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (ShowSamples));
    }
  }

  public unsafe bool ShowDominantLights
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 20L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 20L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FLightingToolsSettings\u002EGet() + 20L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (ShowDominantLights));
    }
  }
}
