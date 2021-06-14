// Decompiled with JetBrains decompiler
// Type: MColorPickerPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using UnrealEd;

internal class MColorPickerPanel : MWPFPanel, IDisposable
{
  private DragSlider RedSlider;
  private DragSlider GreenSlider;
  private DragSlider BlueSlider;
  private DragSlider AlphaSlider;
  private DragSlider HueSlider;
  private DragSlider SaturationSlider;
  private DragSlider BrightnessSlider;
  private TextBox HexTextBox;
  private ColorWheel ColorWheel;
  private GradientSlider SimpleBrightnessSlider;
  private GradientSlider SimpleSaturationSlider;
  private GradientSlider SimpleAlphaSlider;
  private ToggleButton AdvancedVisibilityToggle;
  private double StartColorRed;
  private double StartColorGreen;
  private double StartColorBlue;
  private double StartColorAlpha;
  private static List<MColorPickerPanel> StaticColorPickerPanelList;
  private bool bBrightnessSliderCausedValueChange;
  private uint bEmbeddedPanel;
  private float RedValue;
  private float GreenValue;
  private float BlueValue;
  private float AlphaValue;
  private string HexStringValue;
  private float HueValue;
  private float SaturationValue;
  private float BrightnessValue;
  public uint bUpdateWhenChanged;
  public uint bCaptureColorFromMouse;
  public uint bIsMouseButtonDown;
  public ColorPickerPropertyChangeFunction PropertyChangeCallback;
  public unsafe FPickColorStruct* ColorStruct;

  public unsafe MColorPickerPanel(
    FPickColorStruct* InColorStruct,
    string InXamlName,
    uint bInEmbeddedPanel)
  {
    this.bEmbeddedPanel = bInEmbeddedPanel;
    this.ColorStruct = InColorStruct;
    // ISSUE: explicit constructor call
    base.\u002Ector(InXamlName);
    Button logicalNode1 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "OKButton");
    logicalNode1.Click += new RoutedEventHandler(this.OKClicked);
    Button logicalNode2 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CancelButton");
    logicalNode2.Click += new RoutedEventHandler(this.CancelClicked);
    if (this.bEmbeddedPanel != 0U)
    {
      logicalNode1.Visibility = Visibility.Collapsed;
      logicalNode2.Visibility = Visibility.Collapsed;
    }
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EyeDropperButton")).Click += new RoutedEventHandler(this.EyeDropperClicked);
    MColorPickerPanel mcolorPickerPanel1 = this;
    mcolorPickerPanel1.MouseUp += new MouseButtonEventHandler(mcolorPickerPanel1.OnMouseUp);
    MColorPickerPanel mcolorPickerPanel2 = this;
    mcolorPickerPanel2.LostMouseCapture += new MouseEventHandler(mcolorPickerPanel2.OnLostMouseCapture);
    MColorPickerPanel mcolorPickerPanel3 = this;
    mcolorPickerPanel3.RedSlider = (DragSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel3, "RedDragSlider");
    MColorPickerPanel mcolorPickerPanel4 = this;
    mcolorPickerPanel4.GreenSlider = (DragSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel4, "GreenDragSlider");
    MColorPickerPanel mcolorPickerPanel5 = this;
    mcolorPickerPanel5.BlueSlider = (DragSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel5, "BlueDragSlider");
    MColorPickerPanel mcolorPickerPanel6 = this;
    mcolorPickerPanel6.AlphaSlider = (DragSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel6, "AlphaDragSlider");
    MColorPickerPanel mcolorPickerPanel7 = this;
    mcolorPickerPanel7.HueSlider = (DragSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel7, "HueDragSlider");
    MColorPickerPanel mcolorPickerPanel8 = this;
    mcolorPickerPanel8.SaturationSlider = (DragSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel8, "SaturationDragSlider");
    MColorPickerPanel mcolorPickerPanel9 = this;
    mcolorPickerPanel9.BrightnessSlider = (DragSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel9, "BrightnessDragSlider");
    MColorPickerPanel mcolorPickerPanel10 = this;
    mcolorPickerPanel10.ColorWheel = (ColorWheel) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel10, nameof (ColorWheel));
    MColorPickerPanel mcolorPickerPanel11 = this;
    mcolorPickerPanel11.SimpleSaturationSlider = (GradientSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel11, nameof (SimpleSaturationSlider));
    MColorPickerPanel mcolorPickerPanel12 = this;
    mcolorPickerPanel12.SimpleBrightnessSlider = (GradientSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel12, nameof (SimpleBrightnessSlider));
    MColorPickerPanel mcolorPickerPanel13 = this;
    mcolorPickerPanel13.SimpleAlphaSlider = (GradientSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel13, nameof (SimpleAlphaSlider));
    MColorPickerPanel mcolorPickerPanel14 = this;
    mcolorPickerPanel14.AdvancedVisibilityToggle = (ToggleButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel14, nameof (AdvancedVisibilityToggle));
    this.RedSlider.NextDragSliderControl = this.GreenSlider;
    this.GreenSlider.NextDragSliderControl = this.BlueSlider;
    this.BlueSlider.NextDragSliderControl = this.AlphaSlider;
    this.AlphaSlider.NextDragSliderControl = this.RedSlider;
    this.HueSlider.NextDragSliderControl = this.SaturationSlider;
    this.SaturationSlider.NextDragSliderControl = this.BrightnessSlider;
    this.BrightnessSlider.NextDragSliderControl = this.HueSlider;
    MColorPickerPanel mcolorPickerPanel15 = this;
    mcolorPickerPanel15.HexTextBox = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mcolorPickerPanel15, nameof (HexTextBox));
    this.HexTextBox.KeyUp += new KeyEventHandler(this.OnKeyUp);
    Utils.CreateBinding((FrameworkElement) this.RedSlider, RangeBase.ValueProperty, (object) this, nameof (Red));
    Utils.CreateBinding((FrameworkElement) this.GreenSlider, RangeBase.ValueProperty, (object) this, nameof (Green));
    Utils.CreateBinding((FrameworkElement) this.BlueSlider, RangeBase.ValueProperty, (object) this, nameof (Blue));
    Utils.CreateBinding((FrameworkElement) this.AlphaSlider, RangeBase.ValueProperty, (object) this, nameof (Alpha));
    Utils.CreateBinding((FrameworkElement) this.HueSlider, RangeBase.ValueProperty, (object) this, nameof (Hue));
    Utils.CreateBinding((FrameworkElement) this.SaturationSlider, RangeBase.ValueProperty, (object) this, nameof (Saturation));
    Utils.CreateBinding((FrameworkElement) this.BrightnessSlider, RangeBase.ValueProperty, (object) this, nameof (Brightness));
    Utils.CreateBinding((FrameworkElement) this.SimpleSaturationSlider, (DependencyProperty) GradientSlider.ValueProperty, (object) this, nameof (Saturation));
    Utils.CreateBinding((FrameworkElement) this.SimpleBrightnessSlider, (DependencyProperty) GradientSlider.ValueProperty, (object) this, nameof (Brightness));
    Utils.CreateBinding((FrameworkElement) this.SimpleAlphaSlider, (DependencyProperty) GradientSlider.ValueProperty, (object) this, nameof (Alpha));
    Utils.CreateBinding((FrameworkElement) this.ColorWheel, (DependencyProperty) ColorWheel.HueProperty, (object) this, nameof (Hue));
    Utils.CreateBinding((FrameworkElement) this.ColorWheel, (DependencyProperty) ColorWheel.SaturationProperty, (object) this, nameof (Saturation));
    Utils.CreateBinding((FrameworkElement) this.ColorWheel, (DependencyProperty) ColorWheel.BrightnessProperty, (object) this, nameof (Brightness));
    Utils.CreateBinding((FrameworkElement) this.HexTextBox, TextBox.TextProperty, (object) this, nameof (HexString));
    MColorPickerPanel mcolorPickerPanel16 = this;
    mcolorPickerPanel16.PropertyChanged += new PropertyChangedEventHandler(mcolorPickerPanel16.OnColorPickerPropertyChanged);
    ((UIElement) this.RedSlider).MouseUp += new MouseButtonEventHandler(this.Widget_MouseUp);
    ((UIElement) this.GreenSlider).MouseUp += new MouseButtonEventHandler(this.Widget_MouseUp);
    ((UIElement) this.BlueSlider).MouseUp += new MouseButtonEventHandler(this.Widget_MouseUp);
    ((UIElement) this.AlphaSlider).MouseUp += new MouseButtonEventHandler(this.Widget_MouseUp);
    ((UIElement) this.HueSlider).MouseUp += new MouseButtonEventHandler(this.Widget_MouseUp);
    ((UIElement) this.SaturationSlider).MouseUp += new MouseButtonEventHandler(this.Widget_MouseUp);
    ((UIElement) this.BrightnessSlider).MouseUp += new MouseButtonEventHandler(this.Widget_MouseUp);
    ((UIElement) this.ColorWheel).MouseUp += new MouseButtonEventHandler(this.Widget_MouseUp);
    ((UIElement) this.RedSlider).PreviewMouseDown += new MouseButtonEventHandler(this.Widget_MouseDown);
    ((UIElement) this.GreenSlider).PreviewMouseDown += new MouseButtonEventHandler(this.Widget_MouseDown);
    ((UIElement) this.BlueSlider).PreviewMouseDown += new MouseButtonEventHandler(this.Widget_MouseDown);
    ((UIElement) this.AlphaSlider).PreviewMouseDown += new MouseButtonEventHandler(this.Widget_MouseDown);
    ((UIElement) this.HueSlider).PreviewMouseDown += new MouseButtonEventHandler(this.Widget_MouseDown);
    ((UIElement) this.SaturationSlider).PreviewMouseDown += new MouseButtonEventHandler(this.Widget_MouseDown);
    ((UIElement) this.BrightnessSlider).PreviewMouseDown += new MouseButtonEventHandler(this.Widget_MouseDown);
    ((UIElement) this.ColorWheel).PreviewMouseDown += new MouseButtonEventHandler(this.Widget_MouseDown);
    // ISSUE: method pointer
    this.SimpleBrightnessSlider.ValueCommitted += new GradientSlider.ValueCommitted_Handler((object) this, __methodptr(StopDeferringUpdates));
    // ISSUE: method pointer
    this.SimpleSaturationSlider.ValueCommitted += new GradientSlider.ValueCommitted_Handler((object) this, __methodptr(StopDeferringUpdates));
    // ISSUE: method pointer
    this.SimpleAlphaSlider.ValueCommitted += new GradientSlider.ValueCommitted_Handler((object) this, __methodptr(StopDeferringUpdates));
    this.AdvancedVisibilityToggle.Checked += new RoutedEventHandler(this.AdvancedToggled);
    this.AdvancedVisibilityToggle.Unchecked += new RoutedEventHandler(this.AdvancedToggled);
    // ISSUE: method pointer
    this.SimpleBrightnessSlider.WhitepointChanged += new GradientSlider.WhitepointChanged_Handler((object) this, __methodptr(WhitepointChaned));
    this.bUpdateWhenChanged = 1U;
    this.bCaptureColorFromMouse = 0U;
    this.bIsMouseButtonDown = 0U;
    if (MColorPickerPanel.StaticColorPickerPanelList == null)
      MColorPickerPanel.StaticColorPickerPanelList = new List<MColorPickerPanel>();
    MColorPickerPanel.StaticColorPickerPanelList.Add(this);
    this.ReadSettings();
  }

  private void \u007EMColorPickerPanel()
  {
    if (MColorPickerPanel.StaticColorPickerPanelList == null)
      return;
    MColorPickerPanel.StaticColorPickerPanelList.Remove(this);
    if (MColorPickerPanel.StaticColorPickerPanelList.Count != 0)
      return;
    if (MColorPickerPanel.StaticColorPickerPanelList is IDisposable colorPickerPanelList)
      colorPickerPanelList.Dispose();
    MColorPickerPanel.StaticColorPickerPanelList = (List<MColorPickerPanel>) null;
  }

  public unsafe void BindData()
  {
    bool flag = false;
    if (\u003CModule\u003E.TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 48L)) != 0)
    {
      FLinearColor** flinearColorPtr = \u003CModule\u003E.TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 48L), 0);
      FLinearColor flinearColor;
      // ISSUE: cpblk instruction
      __memcpy(ref flinearColor, *(long*) flinearColorPtr, 16);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.StartColorRed = (double) ^(float&) ref flinearColor;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.StartColorGreen = (double) ^(float&) ((IntPtr) &flinearColor + 4);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.StartColorBlue = (double) ^(float&) ((IntPtr) &flinearColor + 8);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.StartColorAlpha = (double) ^(float&) ((IntPtr) &flinearColor + 12);
      flag = true;
    }
    if (\u003CModule\u003E.TArray\u003CFColorChannelStruct\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFColorChannelStruct\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 64L)) != 0)
    {
      FColorChannelStruct* fcolorChannelStructPtr = \u003CModule\u003E.TArray\u003CFColorChannelStruct\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFColorChannelStruct\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 64L), 0);
      ulong num1 = (ulong) *(long*) fcolorChannelStructPtr;
      this.StartColorRed = num1 == 0UL ? 0.0 : (double) *(float*) num1;
      ulong num2 = (ulong) *(long*) ((IntPtr) fcolorChannelStructPtr + 8L);
      this.StartColorGreen = num2 == 0UL ? 0.0 : (double) *(float*) num2;
      ulong num3 = (ulong) *(long*) ((IntPtr) fcolorChannelStructPtr + 16L);
      this.StartColorBlue = num3 == 0UL ? 0.0 : (double) *(float*) num3;
      ulong num4 = (ulong) *(long*) ((IntPtr) fcolorChannelStructPtr + 24L);
      this.StartColorAlpha = num4 == 0UL ? 0.0 : (double) *(float*) num4;
      flag = true;
    }
    else if (\u003CModule\u003E.TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 32L)) != 0)
    {
      FColor** fcolorPtr = \u003CModule\u003E.TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 32L), 0);
      FLinearColor flinearColor;
      \u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor, (FColor*) *(long*) fcolorPtr);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.StartColorRed = (double) ^(float&) ref flinearColor;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.StartColorGreen = (double) ^(float&) ((IntPtr) &flinearColor + 4);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.StartColorBlue = (double) ^(float&) ((IntPtr) &flinearColor + 8);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.StartColorAlpha = (double) ^(float&) ((IntPtr) &flinearColor + 12);
      flag = false;
    }
    double InValueMax = 1000.0;
    if (\u003CModule\u003E.TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 32L)) > 0)
      InValueMax = 1.0;
    MColorPickerPanel mcolorPickerPanel1 = this;
    mcolorPickerPanel1.SetSliderRange(mcolorPickerPanel1.RedSlider, 0.0, 1.0, 0.0, InValueMax, 0.01);
    MColorPickerPanel mcolorPickerPanel2 = this;
    mcolorPickerPanel2.SetSliderRange(mcolorPickerPanel2.GreenSlider, 0.0, 1.0, 0.0, InValueMax, 0.01);
    MColorPickerPanel mcolorPickerPanel3 = this;
    mcolorPickerPanel3.SetSliderRange(mcolorPickerPanel3.BlueSlider, 0.0, 1.0, 0.0, InValueMax, 0.01);
    MColorPickerPanel mcolorPickerPanel4 = this;
    mcolorPickerPanel4.SetSliderRange(mcolorPickerPanel4.AlphaSlider, 0.0, 1.0, 0.0, 1.0, 0.01);
    MColorPickerPanel mcolorPickerPanel5 = this;
    mcolorPickerPanel5.SetSliderRange(mcolorPickerPanel5.HueSlider, 0.0, 360.0, 0.0, 360.0, 1.0);
    MColorPickerPanel mcolorPickerPanel6 = this;
    mcolorPickerPanel6.SetSliderRange(mcolorPickerPanel6.SaturationSlider, 0.0, 1.0, 0.0, 1.0, 0.01);
    MColorPickerPanel mcolorPickerPanel7 = this;
    mcolorPickerPanel7.SetSliderRange(mcolorPickerPanel7.BrightnessSlider, 0.0, 1.0, 0.0, 1.0, 0.01);
    this.bUpdateWhenChanged = 0U;
    MColorPickerPanel mcolorPickerPanel8 = this;
    mcolorPickerPanel8.Red = (float) mcolorPickerPanel8.StartColorRed;
    MColorPickerPanel mcolorPickerPanel9 = this;
    mcolorPickerPanel9.Green = (float) mcolorPickerPanel9.StartColorGreen;
    MColorPickerPanel mcolorPickerPanel10 = this;
    mcolorPickerPanel10.Blue = (float) mcolorPickerPanel10.StartColorBlue;
    MColorPickerPanel mcolorPickerPanel11 = this;
    mcolorPickerPanel11.Alpha = (float) mcolorPickerPanel11.StartColorAlpha;
    ((Shape) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "OldColorRectNoAlpha")).Fill = (Brush) this.GetHDRColorGradient(1f, this.Red, this.Green, this.Blue, true);
    Rectangle logicalNode = (Rectangle) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "OldColorRect");
    MColorPickerPanel mcolorPickerPanel12 = this;
    RadialGradientBrush hdrColorGradient = mcolorPickerPanel12.GetHDRColorGradient(mcolorPickerPanel12.Alpha, this.Red, this.Green, this.Blue, false);
    logicalNode.Fill = (Brush) hdrColorGradient;
    this.UpdateOriginalColorPreview();
    this.UpdateSimpleSliders();
    this.SimpleBrightnessSlider.IsVariableRange = flag;
    this.SimpleBrightnessSlider.Whitepoint = 1.0;
    if (flag)
      this.SimpleBrightnessSlider.AdjustRangeToValue();
    this.bUpdateWhenChanged = 1U;
    this.UpdateColorPreview();
  }

  public void SetEnabled(uint bInEnable) => ((UIElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "DataPanel")).IsEnabled = bInEnable != 0U;

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.CancelClicked);
  }

  public static uint GetNumColorPickerPanels() => MColorPickerPanel.StaticColorPickerPanelList != null ? (uint) MColorPickerPanel.StaticColorPickerPanelList.Count : 0U;

  public static MColorPickerPanel GetStaticColorPicker(uint InIndex) => MColorPickerPanel.StaticColorPickerPanelList[(int) InIndex];

  public unsafe void Tick()
  {
    if (this.bCaptureColorFromMouse == 0U)
      return;
    HDC__* dc = \u003CModule\u003E.GetDC((HWND__*) 0L);
    if (\u003CModule\u003E.GetDeviceCaps(dc, 121) != 0)
    {
      tagPOINT tagPoint;
      \u003CModule\u003E.GetCursorPos(&tagPoint);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      uint pixel = \u003CModule\u003E.GetPixel(dc, ^(int&) ref tagPoint, ^(int&) ((IntPtr) &tagPoint + 4));
      FColor fcolor;
      \u003CModule\u003E.FColor\u002E\u007Bctor\u007D(&fcolor, (byte) pixel, (byte) ((uint) (ushort) pixel >> 8), (byte) (pixel >> 16), byte.MaxValue);
      FLinearColor flinearColor;
      \u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor, &fcolor);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.Red = ^(float&) ref flinearColor;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.Green = ^(float&) ((IntPtr) &flinearColor + 4);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.Blue = ^(float&) ((IntPtr) &flinearColor + 8);
      this.Alpha = 1f;
    }
    \u003CModule\u003E.ReleaseDC((HWND__*) 0L, dc);
  }

  public static Color GetBrushColor(
    float InAlphaPercent,
    float InRed,
    float InGreen,
    float InBlue,
    uint bUseSrgb)
  {
    float num1;
    float num2;
    float num3;
    float num4;
    if (bUseSrgb != 0U)
    {
      num1 = \u003CModule\u003E.Clamp\u003Cfloat\u003E(\u003CModule\u003E.appPow(InRed, 0.4545454f) * (float) byte.MaxValue, 0.0f, (float) byte.MaxValue);
      num2 = \u003CModule\u003E.Clamp\u003Cfloat\u003E(\u003CModule\u003E.appPow(InGreen, 0.4545454f) * (float) byte.MaxValue, 0.0f, (float) byte.MaxValue);
      num3 = \u003CModule\u003E.Clamp\u003Cfloat\u003E(\u003CModule\u003E.appPow(InBlue, 0.4545454f) * (float) byte.MaxValue, 0.0f, (float) byte.MaxValue);
      num4 = \u003CModule\u003E.Clamp\u003Cfloat\u003E(InAlphaPercent * (float) byte.MaxValue, 0.0f, (float) byte.MaxValue);
    }
    else
    {
      num1 = \u003CModule\u003E.Clamp\u003Cfloat\u003E(InRed * (float) byte.MaxValue, 0.0f, (float) byte.MaxValue);
      num2 = \u003CModule\u003E.Clamp\u003Cfloat\u003E(InGreen * (float) byte.MaxValue, 0.0f, (float) byte.MaxValue);
      num3 = \u003CModule\u003E.Clamp\u003Cfloat\u003E(InBlue * (float) byte.MaxValue, 0.0f, (float) byte.MaxValue);
      num4 = \u003CModule\u003E.Clamp\u003Cfloat\u003E(InAlphaPercent * (float) byte.MaxValue, 0.0f, (float) byte.MaxValue);
    }
    return Color.FromArgb((byte) \u003CModule\u003E.appTrunc(num4), (byte) \u003CModule\u003E.appTrunc(num1), (byte) \u003CModule\u003E.appTrunc(num2), (byte) \u003CModule\u003E.appTrunc(num3));
  }

  public void AddCallbackDelegate(
    ColorPickerPropertyChangeFunction InPropertyChangeCallback)
  {
    this.PropertyChangeCallback += InPropertyChangeCallback;
  }

  protected void OKClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(0);

  protected void CancelClicked(object Owner, RoutedEventArgs Args)
  {
    this.bUpdateWhenChanged = 0U;
    MColorPickerPanel mcolorPickerPanel1 = this;
    mcolorPickerPanel1.Red = (float) mcolorPickerPanel1.StartColorRed;
    MColorPickerPanel mcolorPickerPanel2 = this;
    mcolorPickerPanel2.Green = (float) mcolorPickerPanel2.StartColorGreen;
    MColorPickerPanel mcolorPickerPanel3 = this;
    mcolorPickerPanel3.Blue = (float) mcolorPickerPanel3.StartColorBlue;
    MColorPickerPanel mcolorPickerPanel4 = this;
    mcolorPickerPanel4.Alpha = (float) mcolorPickerPanel4.StartColorAlpha;
    this.bUpdateWhenChanged = 1U;
    this.PushColorToDataPtrs(0U);
    this.ParentFrame.Close(1);
  }

  protected void EyeDropperClicked(object Owner, RoutedEventArgs Args)
  {
    MColorPickerPanel mcolorPickerPanel = this;
    mcolorPickerPanel.Cursor = ((FrameworkElement) ((FrameworkElement) mcolorPickerPanel.ColorWheel).FindResource((object) "curEyeDropper")).Cursor;
    this.bCaptureColorFromMouse = 1U;
    this.CaptureMouse();
  }

  protected void OnColorPickerPropertyChanged(object Owner, PropertyChangedEventArgs Args)
  {
    if (\u003CModule\u003E.\u003FA0x3a4a4fc4\u002E\u003FbPerformingUpdate\u0040\u003F1\u003F\u003FOnColorPickerPropertyChanged\u0040MColorPickerPanel\u0040\u0040IE\u0024AAMXPE\u0024AAVObject\u0040System\u0040\u0040PE\u0024AAVPropertyChangedEventArgs\u0040ComponentModel\u00404\u0040\u0040Z\u00404IA != 0U)
      return;
    \u003CModule\u003E.\u003FA0x3a4a4fc4\u002E\u003FbPerformingUpdate\u0040\u003F1\u003F\u003FOnColorPickerPropertyChanged\u0040MColorPickerPanel\u0040\u0040IE\u0024AAMXPE\u0024AAVObject\u0040System\u0040\u0040PE\u0024AAVPropertyChangedEventArgs\u0040ComponentModel\u00404\u0040\u0040Z\u00404IA = 1U;
    if (string.Compare(Args.PropertyName, "HexString") == 0)
    {
      this.ConvertHexStringToRGBA();
      this.ConvertRGBToHSV();
    }
    else if (string.Compare(Args.PropertyName, "Hue") != 0 && string.Compare(Args.PropertyName, "Saturation") != 0 && string.Compare(Args.PropertyName, "Brightness") != 0)
    {
      this.ConvertRGBToHSV();
      this.ConvertRGBAToHexString();
    }
    else
    {
      this.ConvertHSVToRGB();
      this.ConvertRGBAToHexString();
    }
    this.UpdateSimpleSliders();
    \u003CModule\u003E.\u003FA0x3a4a4fc4\u002E\u003FbPerformingUpdate\u0040\u003F1\u003F\u003FOnColorPickerPropertyChanged\u0040MColorPickerPanel\u0040\u0040IE\u0024AAMXPE\u0024AAVObject\u0040System\u0040\u0040PE\u0024AAVPropertyChangedEventArgs\u0040ComponentModel\u00404\u0040\u0040Z\u00404IA = 0U;
    this.PushColorToDataPtrs(1U);
    this.UpdateColorPreview();
  }

  protected void OnMouseUp(object Sender, MouseButtonEventArgs e) => this.RelinquishCaptureColorFromMouse();

  protected void OnLostMouseCapture(object Owner, MouseEventArgs Args) => this.RelinquishCaptureColorFromMouse();

  protected void RelinquishCaptureColorFromMouse()
  {
    if (this.bCaptureColorFromMouse == 0U)
      return;
    this.Cursor = Cursors.Arrow;
    this.bCaptureColorFromMouse = 0U;
    this.ReleaseMouseCapture();
    this.bUpdateWhenChanged = 1U;
    this.PushColorToDataPtrs(0U);
  }

  protected void OnKeyUp(object Owner, KeyEventArgs Args)
  {
    if (Args.Key != Key.Return)
      return;
    ((FrameworkElement) Args.Source)?.GetBindingExpression(TextBox.TextProperty).UpdateSource();
  }

  protected void Widget_MouseDown(object Sender, MouseButtonEventArgs e) => this.bIsMouseButtonDown = 1U;

  protected void Widget_MouseUp(object Sender, MouseButtonEventArgs e)
  {
    this.bIsMouseButtonDown = 0U;
    this.StopDeferringUpdates();
  }

  protected void StopDeferringUpdates()
  {
    this.bUpdateWhenChanged = 1U;
    this.PushColorToDataPtrs(0U);
  }

  protected void WhitepointChaned(double NewValue) => this.UpdateSimpleSliders();

  protected unsafe void PushColorToDataPtrs(uint bStopUpdateBasedOnPerf)
  {
    if (bStopUpdateBasedOnPerf != 0U && *(int*) ((IntPtr) this.ColorStruct + 96L) != 0 && this.bIsMouseButtonDown != 0U)
      this.bUpdateWhenChanged = 0U;
    if (this.bUpdateWhenChanged == 0U)
      return;
    double num1 = \u003CModule\u003E.appSeconds();
    FPickColorStruct* colorStruct1 = this.ColorStruct;
    if (*(long*) colorStruct1 != 0L)
      \u003CModule\u003E.WxPropertyWindow\u002EChangeActiveCallbackCount((WxPropertyWindow*) *(long*) colorStruct1, 1);
    int num2 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 80L)))
    {
      do
      {
        UObject* uobjectPtr1 = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 80L), num2);
        FPickColorStruct* colorStruct2 = this.ColorStruct;
        if (*(long*) colorStruct2 != 0L)
        {
          ulong num3 = (ulong) *(long*) ((IntPtr) colorStruct2 + 8L);
          if (num3 != 0UL)
          {
            \u003CModule\u003E.WxPropertyWindow\u002ENotifyPreChange((WxPropertyWindow*) *(long*) this.ColorStruct, \u003CModule\u003E.FPropertyNode\u002EGetNodeWindow((FPropertyNode*) num3), \u003CModule\u003E.FPropertyNode\u002EGetProperty((FPropertyNode*) *(long*) ((IntPtr) this.ColorStruct + 8L)), uobjectPtr1);
            goto label_10;
          }
        }
        UObject* uobjectPtr2 = uobjectPtr1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, UProperty*)>) *(long*) (*(long*) uobjectPtr1 + 136L))((UProperty*) uobjectPtr2, IntPtr.Zero);
label_10:
        ++num2;
      }
      while (num2 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 80L)));
    }
    int num4 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 32L)))
    {
      do
      {
        long num3 = *(long*) \u003CModule\u003E.TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 32L), num4);
        FLinearColor flinearColor;
        \u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor, this.Red, this.Green, this.Blue, this.Alpha);
        FColor fcolor;
        \u003CModule\u003E.FColor\u002E\u007Bctor\u007D(&fcolor, &flinearColor);
        ref FColor local = ref fcolor;
        // ISSUE: cpblk instruction
        __memcpy(num3, ref local, 4);
        ++num4;
      }
      while (num4 < \u003CModule\u003E.TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 32L)));
    }
    int num5 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 48L)))
    {
      do
      {
        FLinearColor flinearColor;
        // ISSUE: cpblk instruction
        __memcpy(*(long*) \u003CModule\u003E.TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 48L), num5), (IntPtr) \u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor, this.Red, this.Green, this.Blue, this.Alpha), 16);
        ++num5;
      }
      while (num5 < \u003CModule\u003E.TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 48L)));
    }
    int num6 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CFColorChannelStruct\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFColorChannelStruct\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 64L)))
    {
      do
      {
        FColorChannelStruct* fcolorChannelStructPtr = \u003CModule\u003E.TArray\u003CFColorChannelStruct\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFColorChannelStruct\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 64L), num6);
        FColorChannelStruct fcolorChannelStruct;
        // ISSUE: cpblk instruction
        __memcpy(ref fcolorChannelStruct, (IntPtr) fcolorChannelStructPtr, 32);
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        if (^(long&) ref fcolorChannelStruct != 0L)
        {
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          *(float*) ^(long&) ref fcolorChannelStruct = this.Red;
        }
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        if (^(long&) ((IntPtr) &fcolorChannelStruct + 8) != 0L)
        {
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          *(float*) ^(long&) ((IntPtr) &fcolorChannelStruct + 8) = this.Green;
        }
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        if (^(long&) ((IntPtr) &fcolorChannelStruct + 16) != 0L)
        {
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          *(float*) ^(long&) ((IntPtr) &fcolorChannelStruct + 16) = this.Blue;
        }
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        if (^(long&) ((IntPtr) &fcolorChannelStruct + 24) != 0L)
        {
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          *(float*) ^(long&) ((IntPtr) &fcolorChannelStruct + 24) = this.Alpha;
        }
        ++num6;
      }
      while (num6 < \u003CModule\u003E.TArray\u003CFColorChannelStruct\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFColorChannelStruct\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 64L)));
    }
    int num7 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 80L)))
    {
      do
      {
        UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 80L), num7);
        FPickColorStruct* colorStruct2 = this.ColorStruct;
        if (*(long*) colorStruct2 != 0L && *(long*) ((IntPtr) colorStruct2 + 8L) != 0L)
        {
          WxPropertyControl* nodeWindow = \u003CModule\u003E.FPropertyNode\u002EGetNodeWindow((FPropertyNode*) *(long*) ((IntPtr) colorStruct2 + 8L));
          UProperty* property = \u003CModule\u003E.FPropertyNode\u002EGetProperty((FPropertyNode*) *(long*) ((IntPtr) this.ColorStruct + 8L));
          FPropertyChangedEvent fpropertyChangedEvent;
          \u003CModule\u003E.FPropertyChangedEvent\u002E\u007Bctor\u007D(&fpropertyChangedEvent, property, 0U, 1U);
          \u003CModule\u003E.WxPropertyWindow\u002ENotifyPostChange((WxPropertyWindow*) *(long*) this.ColorStruct, nodeWindow, &fpropertyChangedEvent);
        }
        else
          \u003CModule\u003E.UObject\u002EPostEditChange(uobjectPtr);
        ++num7;
      }
      while (num7 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 80L)));
    }
    FPickColorStruct* colorStruct3 = this.ColorStruct;
    if (*(long*) colorStruct3 != 0L)
    {
      \u003CModule\u003E.WxPropertyWindow\u002EChangeActiveCallbackCount((WxPropertyWindow*) *(long*) colorStruct3, -1);
      \u003CModule\u003E.WxPropertyWindow\u002ERefreshVisibleWindows((WxPropertyWindow*) *(long*) this.ColorStruct);
    }
    FPickColorStruct* colorStruct4 = this.ColorStruct;
    ulong num8 = (ulong) *(long*) ((IntPtr) colorStruct4 + 8L);
    if (num8 != 0UL && *(long*) colorStruct4 != 0L && \u003CModule\u003E.FPropertyNode\u002EHasNodeFlags((FPropertyNode*) num8, 32U) != 0U)
    {
      FPickColorStruct* colorStruct2 = this.ColorStruct;
      \u003CModule\u003E.WxPropertyWindow\u002ERebuildSubTree((WxPropertyWindow*) *(long*) colorStruct2, (FPropertyNode*) *(long*) ((IntPtr) colorStruct2 + 8L));
      \u003CModule\u003E.FPropertyNode\u002ESetExpanded((FPropertyNode*) *(long*) ((IntPtr) this.ColorStruct + 8L), 1U, 0U, 0U);
    }
    FCallbackEventObserver* gcallbackEvent1 = \u003CModule\u003E.GCallbackEvent;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr, ECallbackEventType)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 72L))((ECallbackEventType) gcallbackEvent1, new IntPtr(12));
    FCallbackEventObserver* gcallbackEvent2 = \u003CModule\u003E.GCallbackEvent;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr, ECallbackEventType)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 72L))((ECallbackEventType) gcallbackEvent2, new IntPtr(74));
    int num9 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CwxWindow\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CwxWindow\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 16L)))
    {
      do
      {
        wxWindow* wxWindowPtr1 = (wxWindow*) *(long*) \u003CModule\u003E.TArray\u003CwxWindow\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CwxWindow\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 16L), num9);
        if ((IntPtr) wxWindowPtr1 != IntPtr.Zero)
        {
          do
          {
            wxWindow* wxWindowPtr2 = wxWindowPtr1;
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            __calli((__FnPtr<void (IntPtr, byte, wxRect*)>) *(long*) (*(long*) wxWindowPtr1 + 560L))((wxRect*) wxWindowPtr2, (byte) 1, IntPtr.Zero);
            if (*(int*) ((IntPtr) this.ColorStruct + 100L) != 0)
            {
              wxWindow* wxWindowPtr3 = wxWindowPtr1;
              // ISSUE: cast to a function pointer type
              // ISSUE: function pointer call
              __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) wxWindowPtr3 + 568L))((IntPtr) wxWindowPtr3);
            }
            wxWindowPtr1 = \u003CModule\u003E.wxWindowBase\u002EGetParent((wxWindowBase*) wxWindowPtr1);
          }
          while ((IntPtr) wxWindowPtr1 != IntPtr.Zero);
        }
        ++num9;
      }
      while (num9 < \u003CModule\u003E.TArray\u003CwxWindow\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CwxWindow\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.ColorStruct + 16L)));
    }
    ColorPickerPropertyChangeFunction propertyChangeCallback = this.PropertyChangeCallback;
    if (propertyChangeCallback != null)
      propertyChangeCallback();
    double num10 = \u003CModule\u003E.appSeconds();
    if (bStopUpdateBasedOnPerf == 0U || num10 - num1 < 0.05)
      return;
    this.bUpdateWhenChanged = 0U;
  }

  protected unsafe RadialGradientBrush GetHDRColorGradient(
    float InAlpha,
    float InRed,
    float InGreen,
    float InBlue,
    [MarshalAs(UnmanagedType.U1)] bool bRightHalf)
  {
    RadialGradientBrush radialGradientBrush = new RadialGradientBrush();
    radialGradientBrush.RadiusX = 1.0;
    radialGradientBrush.RadiusY = 0.5;
    if (bRightHalf)
    {
      Point point1 = new Point(1.0, 0.5);
      radialGradientBrush.GradientOrigin = point1;
      Point point2 = new Point(1.0, 0.5);
      radialGradientBrush.Center = point2;
    }
    else
    {
      Point point1 = new Point(0.0, 0.5);
      radialGradientBrush.GradientOrigin = point1;
      Point point2 = new Point(0.0, 0.5);
      radialGradientBrush.Center = point2;
    }
    Color brushColor1 = MColorPickerPanel.GetBrushColor(InAlpha, InRed, InGreen, InBlue, (uint) *(int*) ((IntPtr) this.ColorStruct + 104L));
    radialGradientBrush.GradientStops.Add(new GradientStop(brushColor1, 0.0));
    List<float> floatList1 = new List<float>();
    if ((double) InRed > 1.0)
      floatList1.Add(InRed);
    if ((double) InGreen > 1.0)
      floatList1.Add(InGreen);
    if ((double) InBlue > 1.0)
      floatList1.Add(InBlue);
    floatList1.Sort();
    if (floatList1.Count == 0)
      floatList1.Add(1f);
    int index = 0;
    if (0 < floatList1.Count)
    {
      do
      {
        float num1 = 1f / floatList1[index];
        double num2 = (double) floatList1[index];
        List<float> floatList2 = floatList1;
        double num3 = (double) floatList2[floatList2.Count - 1];
        float num4 = (float) (num2 / num3);
        Color brushColor2 = MColorPickerPanel.GetBrushColor(InAlpha, num1 * InRed, num1 * InGreen, num1 * InBlue, (uint) *(int*) ((IntPtr) this.ColorStruct + 104L));
        radialGradientBrush.GradientStops.Add(new GradientStop(brushColor2, (double) num4));
        ++index;
      }
      while (index < floatList1.Count);
    }
    return radialGradientBrush;
  }

  protected void UpdateColorPreview()
  {
    ((Shape) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "NewColorRectNoAlpha")).Fill = (Brush) this.GetHDRColorGradient(1f, this.Red, this.Green, this.Blue, true);
    Rectangle logicalNode = (Rectangle) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "NewColorRect");
    MColorPickerPanel mcolorPickerPanel = this;
    RadialGradientBrush hdrColorGradient = mcolorPickerPanel.GetHDRColorGradient(mcolorPickerPanel.Alpha, this.Red, this.Green, this.Blue, false);
    logicalNode.Fill = (Brush) hdrColorGradient;
    if (this.bEmbeddedPanel == 0U)
      return;
    this.UpdateOriginalColorPreview();
  }

  protected unsafe void UpdateOriginalColorPreview()
  {
    ((Shape) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "OldColorRectNoAlpha")).Fill = (Brush) new SolidColorBrush(MColorPickerPanel.GetBrushColor(1f, this.Red, this.Green, this.Blue, (uint) *(int*) ((IntPtr) this.ColorStruct + 104L)));
    ((Shape) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "OldColorRect")).Fill = (Brush) new SolidColorBrush(MColorPickerPanel.GetBrushColor(this.Alpha, this.Red, this.Green, this.Blue, (uint) *(int*) ((IntPtr) this.ColorStruct + 104L)));
  }

  protected unsafe void UpdateSimpleSliders()
  {
    FLinearColor flinearColor1;
    FLinearColor flinearColor2;
    \u003CModule\u003E.FLinearColor\u002EHSVToLinearRGB(\u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor1, this.Hue, 1f, this.Brightness, 1f), &flinearColor2);
    FLinearColor flinearColor3;
    FLinearColor flinearColor4;
    \u003CModule\u003E.FLinearColor\u002EHSVToLinearRGB(\u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor3, this.Hue, 0.0f, this.Brightness, 1f), &flinearColor4);
    LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush();
    linearGradientBrush1.StartPoint = new Point(0.0, 0.0);
    linearGradientBrush1.EndPoint = new Point(1.0, 0.0);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    Color brushColor1 = MColorPickerPanel.GetBrushColor(1f, ^(float&) ref flinearColor4, ^(float&) ((IntPtr) &flinearColor4 + 4), ^(float&) ((IntPtr) &flinearColor4 + 8), (uint) *(int*) ((IntPtr) this.ColorStruct + 104L));
    linearGradientBrush1.GradientStops.Add(new GradientStop(brushColor1, 0.0));
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    Color brushColor2 = MColorPickerPanel.GetBrushColor(1f, ^(float&) ref flinearColor2, ^(float&) ((IntPtr) &flinearColor2 + 4), ^(float&) ((IntPtr) &flinearColor2 + 8), (uint) *(int*) ((IntPtr) this.ColorStruct + 104L));
    linearGradientBrush1.GradientStops.Add(new GradientStop(brushColor2, 1.0));
    ((Control) this.SimpleSaturationSlider).Background = (Brush) linearGradientBrush1;
    FLinearColor flinearColor5;
    FLinearColor flinearColor6;
    \u003CModule\u003E.FLinearColor\u002EHSVToLinearRGB(\u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor5, this.Hue, this.Saturation, 1f, 1f), &flinearColor6);
    LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush();
    linearGradientBrush2.StartPoint = new Point(0.0, 0.0);
    linearGradientBrush2.EndPoint = new Point(this.SimpleBrightnessSlider.Whitepoint, 0.0);
    Color brushColor3 = MColorPickerPanel.GetBrushColor(1f, 0.0f, 0.0f, 0.0f, (uint) *(int*) ((IntPtr) this.ColorStruct + 104L));
    linearGradientBrush2.GradientStops.Add(new GradientStop(brushColor3, 0.0));
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    Color brushColor4 = MColorPickerPanel.GetBrushColor(1f, ^(float&) ref flinearColor6, ^(float&) ((IntPtr) &flinearColor6 + 4), ^(float&) ((IntPtr) &flinearColor6 + 8), (uint) *(int*) ((IntPtr) this.ColorStruct + 104L));
    linearGradientBrush2.GradientStops.Add(new GradientStop(brushColor4, 1.0));
    ((Control) this.SimpleBrightnessSlider).Background = (Brush) linearGradientBrush2;
    LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush();
    linearGradientBrush3.StartPoint = new Point(0.0, 0.0);
    linearGradientBrush3.EndPoint = new Point(1.0, 0.0);
    Color brushColor5 = MColorPickerPanel.GetBrushColor(0.0f, 1f, 1f, 1f, (uint) *(int*) ((IntPtr) this.ColorStruct + 104L));
    linearGradientBrush3.GradientStops.Add(new GradientStop(brushColor5, 0.0));
    Color brushColor6 = MColorPickerPanel.GetBrushColor(1f, 1f, 1f, 1f, (uint) *(int*) ((IntPtr) this.ColorStruct + 104L));
    linearGradientBrush3.GradientStops.Add(new GradientStop(brushColor6, 1.0));
    ((Control) this.SimpleAlphaSlider).Background = (Brush) linearGradientBrush3;
  }

  protected void SetSliderRange(
    DragSlider InSlider,
    double InSliderMin,
    double InSliderMax,
    double InValueMin,
    double InValueMax,
    double InIncrement)
  {
    InSlider.SliderMin = InSliderMin;
    ((RangeBase) InSlider).Minimum = InValueMin;
    InSlider.SliderMax = InSliderMax;
    ((RangeBase) InSlider).Maximum = InValueMax;
    InSlider.ValuesPerDragPixel = InIncrement;
  }

  private void AdvancedToggled(object Sender, RoutedEventArgs e)
  {
    this.SaveSettings();
    e.Handled = true;
  }

  private unsafe void ReadSettings()
  {
    uint num;
    if (\u003CModule\u003E.FConfigCacheIni\u002EGetBool(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D148, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D147, &num, (char*) &\u003CModule\u003E.GEditorUserSettingsIni) != 0U)
      this.AdvancedVisibilityToggle.IsChecked = (bool?) (num == 1U);
    else
      this.AdvancedVisibilityToggle.IsChecked = (bool?) false;
  }

  private unsafe void SaveSettings()
  {
    uint num = !this.AdvancedVisibilityToggle.IsChecked.HasValue || !this.AdvancedVisibilityToggle.IsChecked.Value ? 0U : 1U;
    \u003CModule\u003E.FConfigCacheIni\u002ESetBool(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D150, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D149, num, (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
  }

  private unsafe void ConvertHexStringToRGBA()
  {
    // ISSUE: untyped stack allocation
    long num1 = (long) __untypedstackalloc(\u003CModule\u003E.__CxxQueryExceptionSize());
    FColor fcolor;
    \u003CModule\u003E.FColor\u002E\u007Bctor\u007D(&fcolor);
    try
    {
      *\u003CModule\u003E.FColor\u002EDWColor(&fcolor) = Convert.ToUInt32(this.HexString, 16);
      FLinearColor flinearColor;
      \u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor, &fcolor);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.Red = ^(float&) ref flinearColor;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.Green = ^(float&) ((IntPtr) &flinearColor + 4);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.Blue = ^(float&) ((IntPtr) &flinearColor + 8);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.Alpha = ^(float&) ((IntPtr) &flinearColor + 12);
    }
    catch (Exception ex1) when (
    {
      // ISSUE: unable to correctly present filter
      uint exceptionCode = (uint) Marshal.GetExceptionCode();
      if (\u003CModule\u003E.__CxxExceptionFilter((void*) Marshal.GetExceptionPointers(), (void*) 0L, 0, (void*) 0L) != 0)
      {
        SuccessfulFiltering;
      }
      else
        throw;
    }
    )
    {
      uint num2 = 0;
      \u003CModule\u003E.__CxxRegisterExceptionObject((void*) Marshal.GetExceptionPointers(), (void*) num1);
      try
      {
        try
        {
        }
        catch (Exception ex2) when (
        {
          // ISSUE: unable to correctly present filter
          num2 = (uint) \u003CModule\u003E.__CxxDetectRethrow((void*) Marshal.GetExceptionPointers());
          if (num2 != 0U)
          {
            SuccessfulFiltering;
          }
          else
            throw;
        }
        )
        {
        }
        return;
        if (num2 == 0U)
          return;
        throw;
      }
      finally
      {
        \u003CModule\u003E.__CxxUnregisterExceptionObject((void*) num1, (int) num2);
      }
    }
  }

  private unsafe void ConvertRGBAToHexString()
  {
    FColor fcolor;
    FLinearColor flinearColor;
    \u003CModule\u003E.FColor\u002E\u007Bctor\u007D(&fcolor, \u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor, this.Red, this.Green, this.Blue, this.Alpha));
    uint* numPtr = \u003CModule\u003E.FColor\u002EDWColor(&fcolor);
    FString fstring1;
    FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cunsigned\u0020long\u003E(&fstring1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D151, *numPtr);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
      // ISSUE: fault handler
      try
      {
        this.HexString = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
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
  }

  private unsafe void ConvertHSVToRGB()
  {
    FLinearColor flinearColor1;
    \u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor1, this.Hue, this.Saturation, this.Brightness, 1f);
    FLinearColor flinearColor2;
    \u003CModule\u003E.FLinearColor\u002EHSVToLinearRGB(&flinearColor1, &flinearColor2);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    this.Red = ^(float&) ref flinearColor2;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    this.Green = ^(float&) ((IntPtr) &flinearColor2 + 4);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    this.Blue = ^(float&) ((IntPtr) &flinearColor2 + 8);
  }

  private unsafe void ConvertRGBToHSV()
  {
    FLinearColor flinearColor1;
    \u003CModule\u003E.FLinearColor\u002E\u007Bctor\u007D(&flinearColor1, this.Red, this.Green, this.Blue, 1f);
    FLinearColor flinearColor2;
    \u003CModule\u003E.FLinearColor\u002ELinearRGBToHSV(&flinearColor1, &flinearColor2);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    this.Hue = ^(float&) ref flinearColor2;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    this.Saturation = ^(float&) ((IntPtr) &flinearColor2 + 4);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    this.Brightness = ^(float&) ((IntPtr) &flinearColor2 + 8);
  }

  public float Red
  {
    get => this.RedValue;
    set
    {
      if ((double) this.RedValue == (double) value)
        return;
      this.RedValue = value;
      this.OnPropertyChanged(nameof (Red));
    }
  }

  public float Green
  {
    get => this.GreenValue;
    set
    {
      if ((double) this.GreenValue == (double) value)
        return;
      this.GreenValue = value;
      this.OnPropertyChanged(nameof (Green));
    }
  }

  public float Blue
  {
    get => this.BlueValue;
    set
    {
      if ((double) this.BlueValue == (double) value)
        return;
      this.BlueValue = value;
      this.OnPropertyChanged(nameof (Blue));
    }
  }

  public float Alpha
  {
    get => this.AlphaValue;
    set
    {
      if ((double) this.AlphaValue == (double) value)
        return;
      this.AlphaValue = value;
      this.OnPropertyChanged(nameof (Alpha));
    }
  }

  public string HexString
  {
    get => this.HexStringValue;
    set
    {
      if (!(this.HexStringValue != value))
        return;
      this.HexStringValue = value;
      this.OnPropertyChanged(nameof (HexString));
    }
  }

  public float Hue
  {
    get => this.HueValue;
    set
    {
      if ((double) this.HueValue == (double) value)
        return;
      this.HueValue = value;
      this.OnPropertyChanged(nameof (Hue));
    }
  }

  public float Saturation
  {
    get => this.SaturationValue;
    set
    {
      if ((double) this.SaturationValue == (double) value)
        return;
      this.SaturationValue = value;
      this.OnPropertyChanged(nameof (Saturation));
    }
  }

  public float Brightness
  {
    get => this.BrightnessValue;
    set
    {
      if ((double) this.BrightnessValue == (double) value)
        return;
      this.BrightnessValue = value;
      this.OnPropertyChanged(nameof (Brightness));
    }
  }

  protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      this.\u007EMColorPickerPanel();
    }
    else
    {
      // ISSUE: explicit finalizer call
      this.Finalize();
    }
  }

  public virtual void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }
}
