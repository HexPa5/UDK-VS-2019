// Decompiled with JetBrains decompiler
// Type: MMeshPaintWindow
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
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using UnrealEd;

internal class MMeshPaintWindow : MWPFPanel, IDisposable
{
  private List<int> UVChannelItemsValue;
  private bool IsBreechingUndoBufferValue;
  public MEnumerableTArrayWrapper\u003CMTextureTargetListWrapper\u002CFTextureTargetListInfo\u003E TexturePaintTargetList;
  public ComboBox TexturePaintTargetComboBox;
  public ComboBox UVChannelComboBox;
  protected MColorPickerPanel PaintColorPanel;
  protected MColorPickerPanel EraseColorPanel;
  protected unsafe FPickColorStruct* PaintColorStruct;
  protected unsafe FPickColorStruct* EraseColorStruct;
  protected unsafe FEdModeMeshPaint* MeshPaintSystem;
  protected bool IsColorPickerVisible;
  protected BindableRadioButton RadioTexturePaint;
  protected BindableRadioButton RadioPaintMode_Colors;

  public unsafe MMeshPaintWindow(
    MWPFFrame InFrame,
    FEdModeMeshPaint* InMeshPaintSystem,
    string XamlFileName,
    FPickColorStruct* PaintColorStruct,
    FPickColorStruct* EraseColorStruct)
    : base(XamlFileName)
  {
    this.MeshPaintSystem = InMeshPaintSystem;
    this.DataContext = (object) this;
    MMeshPaintWindow mmeshPaintWindow1 = this;
    mmeshPaintWindow1.RadioTexturePaint = (BindableRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) mmeshPaintWindow1, "ResourceTypeRadio_Texture");
    MMeshPaintWindow mmeshPaintWindow2 = this;
    mmeshPaintWindow2.RadioPaintMode_Colors = (BindableRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) mmeshPaintWindow2, "PaintModeRadio_Colors");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "VertexPaintTargetRadio_ComponentInstance"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsVertexPaintTargetComponentInstance));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "VertexPaintTargetRadio_Mesh"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsVertexPaintTargetMesh));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, nameof (InstanceVertexColorsText)), TextBlock.TextProperty, (object) this, nameof (InstanceVertexColorsText));
    Button logicalNode1 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "RemoveInstanceVertexColorsButton");
    Utils.CreateBinding((FrameworkElement) logicalNode1, UIElement.IsEnabledProperty, (object) this, nameof (HasInstanceVertexColors));
    logicalNode1.Click += new RoutedEventHandler(this.RemoveInstanceVertexColorsButton_Click);
    Button logicalNode2 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "FixupInstanceVertexColorsButton");
    Utils.CreateBinding((FrameworkElement) logicalNode2, UIElement.IsEnabledProperty, (object) this, nameof (RequiresInstanceVertexColorsFixup));
    logicalNode2.Click += new RoutedEventHandler(this.FixInstanceVertexColorsButton_Click);
    Button logicalNode3 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CopyInstanceVertexColorsButton");
    Utils.CreateBinding((FrameworkElement) logicalNode3, UIElement.IsEnabledProperty, (object) this, nameof (CanCopyToColourBufferCopy));
    logicalNode3.Click += new RoutedEventHandler(this.CopyInstanceVertexColorsButton_Click);
    Button logicalNode4 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PasteInstanceVertexColorsButton");
    Utils.CreateBinding((FrameworkElement) logicalNode4, UIElement.IsEnabledProperty, (object) this, nameof (CanPasteFromColourBufferCopy));
    logicalNode4.Click += new RoutedEventHandler(this.PasteInstanceVertexColorsButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "FillInstanceVertexColorsButton")).Click += new RoutedEventHandler(this.FillInstanceVertexColorsButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PushInstanceVertexColorsToMeshButton")).Click += new RoutedEventHandler(this.PushInstanceVertexColorsToMeshButton_Click);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PushInstanceVertexColorsToMeshButton"), UIElement.VisibilityProperty, (object) this, nameof (IsVertexPaintTargetComponentInstance), (IValueConverter) new BooleanToVisibilityConverter());
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ImportVertexColorsFromTGAButton")).Click += new RoutedEventHandler(this.ImportVertexColorsFromTGAButton_Click);
    Button logicalNode5 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "SaveVertexPaintPackageButton");
    Utils.CreateBinding((FrameworkElement) logicalNode5, UIElement.IsEnabledProperty, (object) this, nameof (IsSelectedSourceMeshDirty));
    logicalNode5.Click += new RoutedEventHandler(this.SaveVertexPaintPackageButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "FindVertexPaintMeshInContentBrowserButton")).Click += new RoutedEventHandler(this.FindVertexPaintMeshInContentBrowserButton_Click);
    Button logicalNode6 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "DuplicateInstanceMaterialAndTextureButton");
    Utils.CreateBinding((FrameworkElement) logicalNode6, UIElement.IsEnabledProperty, (object) this, nameof (CanCreateInstanceMaterialAndTexture));
    logicalNode6.Click += new RoutedEventHandler(this.DuplicateTextureMaterialButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CreateNewTextureButton")).Click += new RoutedEventHandler(this.CreateNewTextureButton_Click);
    MMeshPaintWindow mmeshPaintWindow3 = this;
    mmeshPaintWindow3.UVChannelComboBox = (ComboBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mmeshPaintWindow3, "UVChannelCombo");
    Utils.CreateBinding((FrameworkElement) this.UVChannelComboBox, UIElement.IsEnabledProperty, (object) this, nameof (IsSelectedTextureValid));
    Utils.CreateBinding((FrameworkElement) this.UVChannelComboBox, Selector.SelectedIndexProperty, (object) this, nameof (UVChannel), (IValueConverter) new IntToIntOffsetConverter(0));
    Utils.CreateBinding((FrameworkElement) this.UVChannelComboBox, ItemsControl.ItemsSourceProperty, (object) this, nameof (UVChannelItems));
    Utils.CreateBinding((FrameworkElement) this.UVChannelComboBox, UIElement.VisibilityProperty, (object) this, nameof (IsSelectedTextureValid), (IValueConverter) new BooleanToVisibilityConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "UVChannelComboNoSelection"), UIElement.VisibilityProperty, (object) this, nameof (IsSelectedTextureValid), (IValueConverter) new NegatedBooleanToVisibilityConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintModeRadio_Colors"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsPaintModeColors));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintModeRadio_Weights"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsPaintModeWeights));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "BrushRadiusDragSlider"), RangeBase.ValueProperty, (object) this, nameof (BrushRadius));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "BrushFalloffAmountDragSlider"), RangeBase.ValueProperty, (object) this, nameof (BrushFalloffAmount));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "BrushStrengthDragSlider"), RangeBase.ValueProperty, (object) this, nameof (BrushStrength));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EnableFlowCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (EnableFlow));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "FlowAmountDragSlider"), RangeBase.ValueProperty, (object) this, nameof (FlowAmount));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "IgnoreBackFacingCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (IgnoreBackFacing));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EnableSeamPaintingCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (EnableSeamPainting));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "WriteRedCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (WriteRed));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "WriteGreenCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (WriteGreen));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "WriteBlueCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (WriteBlue));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "WriteAlphaCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (WriteAlpha));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintColorsGrid"), UIElement.VisibilityProperty, (object) this, nameof (IsPaintModeColors), (IValueConverter) new BooleanToVisibilityConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintWeightsGrid"), UIElement.VisibilityProperty, (object) this, nameof (IsPaintModeWeights), (IValueConverter) new BooleanToVisibilityConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "TotalWeightCountCombo"), Selector.SelectedIndexProperty, (object) this, nameof (TotalWeightCount), (IValueConverter) new IntToIntOffsetConverter(-2));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintWeightIndexRadio_1"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsPaintWeightIndex1));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintWeightIndexRadio_2"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsPaintWeightIndex2));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintWeightIndexRadio_3"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsPaintWeightIndex3));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintWeightIndexRadio_4"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsPaintWeightIndex4));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintWeightIndexRadio_5"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsPaintWeightIndex5));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseWeightIndexRadio_1"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsEraseWeightIndex1));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseWeightIndexRadio_2"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsEraseWeightIndex2));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseWeightIndexRadio_3"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsEraseWeightIndex3));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseWeightIndexRadio_4"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsEraseWeightIndex4));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseWeightIndexRadio_5"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsEraseWeightIndex5));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintWeightIndexRadio_3"), UIElement.VisibilityProperty, (object) this, nameof (TotalWeightCount), (IValueConverter) new TotalWeightCountToVisibilityConverter(), (object) 2);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintWeightIndexRadio_4"), UIElement.VisibilityProperty, (object) this, nameof (TotalWeightCount), (IValueConverter) new TotalWeightCountToVisibilityConverter(), (object) 3);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintWeightIndexRadio_5"), UIElement.VisibilityProperty, (object) this, nameof (TotalWeightCount), (IValueConverter) new TotalWeightCountToVisibilityConverter(), (object) 4);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseWeightIndexRadio_3"), UIElement.VisibilityProperty, (object) this, nameof (TotalWeightCount), (IValueConverter) new TotalWeightCountToVisibilityConverter(), (object) 2);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseWeightIndexRadio_4"), UIElement.VisibilityProperty, (object) this, nameof (TotalWeightCount), (IValueConverter) new TotalWeightCountToVisibilityConverter(), (object) 3);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseWeightIndexRadio_5"), UIElement.VisibilityProperty, (object) this, nameof (TotalWeightCount), (IValueConverter) new TotalWeightCountToVisibilityConverter(), (object) 4);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ResourceTypeRadio_VertexColors"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsResourceTypeVertexColors));
    BindableRadioButton logicalNode7 = (BindableRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ResourceTypeRadio_Texture");
    Utils.CreateBinding((FrameworkElement) logicalNode7, (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsResourceTypeTexture));
    ((ButtonBase) logicalNode7).Click += new RoutedEventHandler(this.ResourceTypePaintRadioButton_Click);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "UndoBufferWarningGrid"), UIElement.VisibilityProperty, (object) this, nameof (IsBreechingUndoBuffer), (IValueConverter) new BooleanToVisibilityConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ColorViewModeRadio_Normal"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsColorViewModeNormal));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ColorViewModeRadio_RGB"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsColorViewModeRGB));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ColorViewModeRadio_Alpha"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsColorViewModeAlpha));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ColorViewModeRadio_Red"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsColorViewModeRed));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ColorViewModeRadio_Green"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsColorViewModeGreen));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ColorViewModeRadio_Blue"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, nameof (IsColorViewModeBlue));
    MMeshPaintWindow mmeshPaintWindow4 = this;
    mmeshPaintWindow4.PropertyChanged += new PropertyChangedEventHandler(mmeshPaintWindow4.OnMeshPaintPropertyChanged);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "SwapPaintAndEraseColorButton")).Click += new RoutedEventHandler(this.SwapPaintColorButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "SwapPaintAndEraseWeightIndexButton")).Click += new RoutedEventHandler(this.SwapPaintWeightIndexButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintColorButton")).Click += new RoutedEventHandler(this.EditPaintColor);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseColorButton")).Click += new RoutedEventHandler(this.EditEraseColor);
    FString fstring1;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CO\u0040DAOLCMAK\u0040\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAP\u003F\u0024AAi\u003F\u0024AAc\u003F\u0024AAk\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAW\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AA\u003F4\u003F\u0024AAx\u003F\u0024AAa\u003F\u0024AAm\u003F\u0024AAl\u003F\u0024AA\u003F\u0024AA\u0040);
    // ISSUE: fault handler
    try
    {
      string InXamlName = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring1), 0, \u003CModule\u003E.FString\u002ELen(&fstring1));
      this.PaintColorPanel = new MColorPickerPanel(PaintColorStruct, InXamlName, 1U);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    FLinearColor* flinearColorPtr1 = (FLinearColor*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 32L);
    \u003CModule\u003E.TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem((TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) PaintColorStruct + 48L), &flinearColorPtr1);
    this.PaintColorPanel.BindData();
    this.PaintColorPanel.SetParentFrame(InFrame);
    FString fstring2;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CO\u0040DAOLCMAK\u0040\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAP\u003F\u0024AAi\u003F\u0024AAc\u003F\u0024AAk\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAW\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AA\u003F4\u003F\u0024AAx\u003F\u0024AAa\u003F\u0024AAm\u003F\u0024AAl\u003F\u0024AA\u003F\u0024AA\u0040);
    // ISSUE: fault handler
    try
    {
      string InXamlName = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
      this.EraseColorPanel = new MColorPickerPanel(EraseColorStruct, InXamlName, 1U);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
    FLinearColor* flinearColorPtr2 = (FLinearColor*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 48L);
    \u003CModule\u003E.TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem((TArray\u003CFLinearColor\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) EraseColorStruct + 48L), &flinearColorPtr2);
    this.EraseColorPanel.BindData();
    this.EraseColorPanel.SetParentFrame(InFrame);
    this.PaintColorPanel.AddCallbackDelegate(new ColorPickerPropertyChangeFunction(this.UpdatePreviewColors));
    this.EraseColorPanel.AddCallbackDelegate(new ColorPickerPropertyChangeFunction(this.UpdatePreviewColors));
    this.UpdatePreviewColors();
    ((Decorator) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintColorBorder")).Child = (UIElement) this.PaintColorPanel;
    ((Decorator) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseColorBorder")).Child = (UIElement) this.EraseColorPanel;
    this.EraseColorPanel.Visibility = Visibility.Collapsed;
    Button logicalNode8 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "FindTextureInContentBrowserButton");
    Utils.CreateBinding((FrameworkElement) logicalNode8, UIElement.IsEnabledProperty, (object) this, nameof (IsSelectedTextureValid));
    logicalNode8.Click += new RoutedEventHandler(this.FindTextureInContentBrowserButton_Click);
    Button logicalNode9 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "SaveTextureButton");
    Utils.CreateBinding((FrameworkElement) logicalNode9, UIElement.IsEnabledProperty, (object) this, nameof (IsSelectedTextureDirty));
    logicalNode9.Click += new RoutedEventHandler(this.SaveTextureButton_Click);
    MMeshPaintWindow mmeshPaintWindow5 = this;
    mmeshPaintWindow5.TexturePaintTargetList = new MEnumerableTArrayWrapper\u003CMTextureTargetListWrapper\u002CFTextureTargetListInfo\u003E(\u003CModule\u003E.FEdModeMeshPaint\u002EGetTexturePaintTargetList(mmeshPaintWindow5.MeshPaintSystem));
    this.TexturePaintTargetList.PropertyChanged += new PropertyChangedEventHandler(this.OnTexturePaintTargetPropertyChanged);
    MMeshPaintWindow mmeshPaintWindow6 = this;
    mmeshPaintWindow6.TexturePaintTargetComboBox = (ComboBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mmeshPaintWindow6, "PaintTextureTargetList");
    Utils.CreateBinding((FrameworkElement) this.TexturePaintTargetComboBox, UIElement.IsEnabledProperty, (object) this, nameof (IsSelectedTextureValid));
    Utils.CreateBinding((FrameworkElement) this.TexturePaintTargetComboBox, UIElement.VisibilityProperty, (object) this, nameof (IsSelectedTextureValid), (IValueConverter) new BooleanToVisibilityConverter());
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintTextureTargetListNoSelection"), UIElement.VisibilityProperty, (object) this, nameof (IsSelectedTextureValid), (IValueConverter) new NegatedBooleanToVisibilityConverter());
    Button logicalNode10 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CommitTextureChangesButton");
    Utils.CreateBinding((FrameworkElement) logicalNode10, UIElement.IsEnabledProperty, (object) this, nameof (AreThereChangesToCommit));
    logicalNode10.Click += new RoutedEventHandler(this.CommitTextureChangesButton_Click);
    this.RefreshAllProperties();
  }

  private void \u007EMMeshPaintWindow()
  {
    this.PaintColorPanel?.Dispose();
    this.EraseColorPanel?.Dispose();
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.OnClose);
  }

  public unsafe void OnClose(object Sender, RoutedEventArgs Args)
  {
    \u003CModule\u003E.FEditorModeTools\u002EDeactivateMode(\u003CModule\u003E.GEditorModeTools(), (EEditorMode) 8);
    if ((IntPtr) \u003CModule\u003E.\u003FInstance\u0040FImportColorsScreen\u0040\u00400PEAV1\u0040EA != IntPtr.Zero)
    {
      FImportColorsScreen* colorsScreen0PeaV1Ea = \u003CModule\u003E.\u003FInstance\u0040FImportColorsScreen\u0040\u00400PEAV1\u0040EA;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      void* voidPtr = __calli((__FnPtr<void* (IntPtr, uint)>) *(long*) *(long*) \u003CModule\u003E.\u003FInstance\u0040FImportColorsScreen\u0040\u00400PEAV1\u0040EA)((uint) colorsScreen0PeaV1Ea, new IntPtr(1));
    }
    \u003CModule\u003E.\u003FInstance\u0040FImportColorsScreen\u0040\u00400PEAV1\u0040EA = (FImportColorsScreen*) 0L;
  }

  public unsafe void RefreshTextureTargetsList()
  {
    \u003CModule\u003E.FEdModeMeshPaint\u002EUpdateTexturePaintTargetList(this.MeshPaintSystem);
    this.RefreshTextureTargetListProperties();
    this.TexturePaintTargetComboBox.SelectedIndex = \u003CModule\u003E.FEdModeMeshPaint\u002EGetCurrentTextureTargetIndex(this.MeshPaintSystem);
  }

  public void RefreshTextureTargetListProperties() => this.TexturePaintTargetProperty.NotifyChanged();

  public unsafe void UpdateUVChannels()
  {
    List<int> intList = new List<int>();
    int num = 0;
    if (0 < \u003CModule\u003E.FEdModeMeshPaint\u002EGetMaxNumUVSets(this.MeshPaintSystem))
    {
      do
      {
        intList.Add(num);
        ++num;
      }
      while (num < \u003CModule\u003E.FEdModeMeshPaint\u002EGetMaxNumUVSets(this.MeshPaintSystem));
    }
    int uvChannel = this.UVChannel;
    this.UVChannelItems = intList;
    if (uvChannel < 0 || uvChannel >= this.UVChannelItems.Count)
      return;
    this.UVChannel = uvChannel;
  }

  public unsafe void CommitPaintChanges([MarshalAs(UnmanagedType.U1)] bool bShouldTriggerUIRefresh) => \u003CModule\u003E.FEdModeMeshPaint\u002ECommitAllPaintedTextures(this.MeshPaintSystem, (uint) bShouldTriggerUIRefresh);

  public unsafe void RestoreRenderTargets() => \u003CModule\u003E.FEdModeMeshPaint\u002ERestoreRenderTargets(this.MeshPaintSystem);

  public unsafe void SaveSettingsForSelectedActors()
  {
    FSelectionIterator fselectionIterator;
    \u003CModule\u003E.UEditorEngine\u002EGetSelectedActorIterator(\u003CModule\u003E.GEditor, &fselectionIterator);
    if (\u003CModule\u003E.FSelectionIterator\u002E\u002EI(&fselectionIterator) == 0U)
      return;
    do
    {
      \u003CModule\u003E.FEdModeMeshPaint\u002ESaveSettingsForActor(this.MeshPaintSystem, \u003CModule\u003E.CastChecked\u003Cclass\u0020AActor\u002Cclass\u0020UObject\u003E(\u003CModule\u003E.FSelectionIterator\u002E\u002A(&fselectionIterator)));
      \u003CModule\u003E.FSelectionIterator\u002E\u002B\u002B(&fselectionIterator);
    }
    while (\u003CModule\u003E.FSelectionIterator\u002E\u002EI(&fselectionIterator) != 0U);
  }

  protected void OnMeshPaintPropertyChanged(object Owner, PropertyChangedEventArgs Args)
  {
    MMeshPaintWindow mmeshPaintWindow = (MMeshPaintWindow) Owner;
    if (Args.PropertyName == (string) null || Args.PropertyName.StartsWith("TotalWeightCount"))
    {
      if (this.IsPaintWeightIndex3 && this.TotalWeightCount < 3)
        this.IsPaintWeightIndex2 = true;
      else if (this.IsPaintWeightIndex4 && this.TotalWeightCount < 4)
        this.IsPaintWeightIndex3 = true;
      else if (this.IsPaintWeightIndex5 && this.TotalWeightCount < 5)
        this.IsPaintWeightIndex4 = true;
    }
    if (mmeshPaintWindow == null || !(Args.PropertyName == "IsResourceTypeTexture") || (!mmeshPaintWindow.IsResourceTypeTexture || mmeshPaintWindow.IsPaintModeColors))
      return;
    mmeshPaintWindow.IsPaintModeWeights = false;
    mmeshPaintWindow.IsPaintModeColors = true;
  }

  protected void OnTexturePaintTargetPropertyChanged(object Owner, PropertyChangedEventArgs Args) => this.RefreshAllProperties();

  protected unsafe void SwapPaintColorButton_Click(object Owner, RoutedEventArgs Args)
  {
    FLinearColor flinearColor;
    // ISSUE: cpblk instruction
    __memcpy(ref flinearColor, (IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 32L, 16);
    \u0024VCls\u00240000000160 vcls0000000160;
    // ISSUE: cpblk instruction
    __memcpy(ref vcls0000000160, (IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 48L, 16);
    // ISSUE: cpblk instruction
    __memcpy((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 32L, ref vcls0000000160, 16);
    // ISSUE: cpblk instruction
    __memcpy((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 48L, ref flinearColor, 16);
    this.PaintColorPanel.BindData();
    this.EraseColorPanel.BindData();
    this.UpdatePreviewColors();
  }

  protected void EditPaintColor(object Owner, RoutedEventArgs Args)
  {
    this.PaintColorPanel.Visibility = Visibility.Visible;
    this.EraseColorPanel.Visibility = Visibility.Collapsed;
  }

  protected void EditEraseColor(object Owner, RoutedEventArgs Args)
  {
    this.PaintColorPanel.Visibility = Visibility.Collapsed;
    this.EraseColorPanel.Visibility = Visibility.Visible;
  }

  protected unsafe void UpdatePreviewColors()
  {
    FLinearColor flinearColor1;
    // ISSUE: cpblk instruction
    __memcpy(ref flinearColor1, (IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 32L, 16);
    FLinearColor flinearColor2;
    // ISSUE: cpblk instruction
    __memcpy(ref flinearColor2, (IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 48L, 16);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ((Shape) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintColorRectNoAlpha")).Fill = (Brush) new SolidColorBrush(MColorPickerPanel.GetBrushColor(1f, ^(float&) ref flinearColor1, ^(float&) ((IntPtr) &flinearColor1 + 4), ^(float&) ((IntPtr) &flinearColor1 + 8), 1U));
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ((Shape) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PaintColorRect")).Fill = (Brush) new SolidColorBrush(MColorPickerPanel.GetBrushColor(^(float&) ((IntPtr) &flinearColor1 + 12), ^(float&) ref flinearColor1, ^(float&) ((IntPtr) &flinearColor1 + 4), ^(float&) ((IntPtr) &flinearColor1 + 8), 1U));
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ((Shape) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseColorRectNoAlpha")).Fill = (Brush) new SolidColorBrush(MColorPickerPanel.GetBrushColor(1f, ^(float&) ref flinearColor2, ^(float&) ((IntPtr) &flinearColor2 + 4), ^(float&) ((IntPtr) &flinearColor2 + 8), 1U));
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ((Shape) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "EraseColorRect")).Fill = (Brush) new SolidColorBrush(MColorPickerPanel.GetBrushColor(^(float&) ((IntPtr) &flinearColor2 + 12), ^(float&) ref flinearColor2, ^(float&) ((IntPtr) &flinearColor2 + 4), ^(float&) ((IntPtr) &flinearColor2 + 8), 1U));
  }

  protected unsafe uint SavePackagesForObjects(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InObjects)
  {
    if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InObjects) > 0)
    {
      TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
      TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator2;
      FString fstring1;
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
          // ISSUE: fault handler
          try
          {
            int num1 = 0;
            if (0 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InObjects))
            {
              do
              {
                UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InObjects, num1);
                if (\u003CModule\u003E.UPackage\u002EIsDirty(\u003CModule\u003E.UObject\u002EGetOutermost(uobjectPtr)) != 0U)
                {
                  UPackage* outermost = \u003CModule\u003E.UObject\u002EGetOutermost(uobjectPtr);
                  \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(&fdefaultAllocator1, &outermost);
                }
                ++num1;
              }
              while (num1 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InObjects));
            }
            if (\u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1) > 0)
            {
              if (\u003CModule\u003E.PackageTools\u002ECheckForReferencesToExternalPackages(&fdefaultAllocator1, &fdefaultAllocator2, (ULevel*) 0L, (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L) != 0U)
              {
                int num2 = 0;
                if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator2))
                {
                  do
                  {
                    FString fstring2;
                    FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator2, num2), &fstring2);
                    // ISSUE: fault handler
                    try
                    {
                      FString fstring3;
                      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_17MJEANDKP\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA\u003F6\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.FString\u002E\u002A(name));
                      // ISSUE: fault handler
                      try
                      {
                        \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring1, fstringPtr);
                      }
                      __fault
                      {
                        // ISSUE: method pointer
                        // ISSUE: cast to a function pointer type
                        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
                      }
                      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
                    }
                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
                    ++num2;
                  }
                  while (num2 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator2));
                }
                FString fstring4;
                FString* fstringPtr1 = \u003CModule\u003E.LocalizeUnrealEd(&fstring4, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BL\u0040JNCDIAJD\u0040Warning_ExternalPackageRef\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
                uint num3;
                // ISSUE: fault handler
                try
                {
                  num3 = \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 1, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr1)), \u003CModule\u003E.FString\u002E\u002A(&fstring1)), \u003CModule\u003E.FString\u002E\u002A(&fstring1));
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
                if (num3 != 0U)
                  goto label_28;
              }
              else
                goto label_28;
            }
            else
              goto label_42;
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
      }
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
      return 0;
label_28:
      // ISSUE: fault handler
      try
      {
        // ISSUE: fault handler
        try
        {
          // ISSUE: fault handler
          try
          {
            TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator3;
            \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator3);
            // ISSUE: fault handler
            try
            {
              uint checkoutPackages = \u003CModule\u003E.FEditorFileUtils\u002EPromptToCheckoutPackages(0U, &fdefaultAllocator1, &fdefaultAllocator3, 0U, 0U);
              int num = (int) checkoutPackages;
              TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr;
              if (checkoutPackages == 0U)
              {
                if (\u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator3) > 0)
                  fdefaultAllocatorPtr = &fdefaultAllocator3;
                else
                  goto label_35;
              }
              else
                fdefaultAllocatorPtr = &fdefaultAllocator1;
              if (\u003CModule\u003E.PackageTools\u002ESavePackages(fdefaultAllocatorPtr, 0U, (FString*) 0L, (TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L) != 0U)
                goto label_36;
label_35:
              if (num != 1)
                goto label_38;
label_36:
              FCallbackEventParameters fcallbackEventParameters;
              \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters, (FCallbackEventDevice*) 0L, (ECallbackEventType) 23, 321U);
              FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
              ref FCallbackEventParameters local = ref fcallbackEventParameters;
              // ISSUE: cast to a function pointer type
              // ISSUE: function pointer call
              __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) gcallbackEvent, (IntPtr) ref local);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
            }
label_38:
            \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
      }
label_42:
      // ISSUE: fault handler
      try
      {
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
      }
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    }
    return 1;
  }

  protected unsafe void SwapPaintWeightIndexButton_Click(object Owner, RoutedEventArgs Args)
  {
    int num = *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L);
    FMeshPaintSettings* fmeshPaintSettingsPtr = (FMeshPaintSettings*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L);
    *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) = *(int*) fmeshPaintSettingsPtr;
    *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) = num;
    this.RefreshAllProperties();
  }

  protected unsafe void RemoveInstanceVertexColorsButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEdModeMeshPaint\u002ERemoveInstanceVertexColors(this.MeshPaintSystem);

  protected unsafe void FixInstanceVertexColorsButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEdModeMeshPaint\u002EFixupInstanceVertexColors(this.MeshPaintSystem);

  protected unsafe void CopyInstanceVertexColorsButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEdModeMeshPaint\u002ECopyInstanceVertexColors(this.MeshPaintSystem);

  protected unsafe void PasteInstanceVertexColorsButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEdModeMeshPaint\u002EPasteInstanceVertexColors(this.MeshPaintSystem);

  protected unsafe void FillInstanceVertexColorsButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEdModeMeshPaint\u002EFillInstanceVertexColors(this.MeshPaintSystem);

  protected unsafe void PushInstanceVertexColorsToMeshButton_Click(
    object Owner,
    RoutedEventArgs Args)
  {
    \u003CModule\u003E.FEdModeMeshPaint\u002EPushInstanceVertexColorsToMesh(this.MeshPaintSystem);
  }

  protected void ImportVertexColorsFromTGAButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FImportColorsScreen\u002EDisplayImportColorsScreen();

  protected unsafe void SaveVertexPaintPackageButton_Click(object Owner, RoutedEventArgs Args)
  {
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      FSelectionIterator fselectionIterator;
      \u003CModule\u003E.UEditorEngine\u002EGetSelectedActorIterator(\u003CModule\u003E.GEditor, &fselectionIterator);
      if (\u003CModule\u003E.FSelectionIterator\u002E\u002EI(&fselectionIterator) != 0U)
      {
        do
        {
          AActor* aactorPtr = \u003CModule\u003E.CastChecked\u003Cclass\u0020AActor\u002Cclass\u0020UObject\u003E(\u003CModule\u003E.FSelectionIterator\u002E\u002A(&fselectionIterator));
          AStaticMeshActor* astaticMeshActorPtr = \u003CModule\u003E.Cast\u003Cclass\u0020AStaticMeshActor\u003E((UObject*) aactorPtr);
          UStaticMeshComponent* ustaticMeshComponentPtr;
          if ((IntPtr) astaticMeshActorPtr != IntPtr.Zero)
          {
            ustaticMeshComponentPtr = (UStaticMeshComponent*) *(long*) ((IntPtr) astaticMeshActorPtr + 572L);
          }
          else
          {
            ADynamicSMActor* adynamicSmActorPtr = \u003CModule\u003E.Cast\u003Cclass\u0020ADynamicSMActor\u003E((UObject*) aactorPtr);
            if ((IntPtr) adynamicSmActorPtr != IntPtr.Zero)
              ustaticMeshComponentPtr = (UStaticMeshComponent*) *(long*) ((IntPtr) adynamicSmActorPtr + 572L);
            else
              goto label_9;
          }
          if ((IntPtr) ustaticMeshComponentPtr != IntPtr.Zero)
          {
            ulong num = (ulong) *(long*) ((IntPtr) ustaticMeshComponentPtr + 576L);
            if (num != 0UL)
            {
              UObject* uobjectPtr = (UObject*) num;
              \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, &uobjectPtr);
            }
          }
label_9:
          \u003CModule\u003E.FSelectionIterator\u002E\u002B\u002B(&fselectionIterator);
        }
        while (\u003CModule\u003E.FSelectionIterator\u002E\u002EI(&fselectionIterator) != 0U);
      }
      if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator) > 0)
      {
        int num = (int) this.SavePackagesForObjects(&fdefaultAllocator);
        this.RefreshAllProperties();
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  protected unsafe void FindVertexPaintMeshInContentBrowserButton_Click(
    object Owner,
    RoutedEventArgs Args)
  {
    \u003CModule\u003E.WxEditorFrame\u002ESyncToContentBrowser((WxEditorFrame*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L));
  }

  protected unsafe void CreateInstanceMaterialAndTextureButton_Click(
    object Owner,
    RoutedEventArgs Args)
  {
    \u003CModule\u003E.FEdModeMeshPaint\u002ECreateInstanceMaterialAndTexture(this.MeshPaintSystem);
  }

  protected unsafe void RemoveInstanceMaterialAndTextureButton_Click(
    object Owner,
    RoutedEventArgs Args)
  {
    \u003CModule\u003E.FEdModeMeshPaint\u002ERemoveInstanceMaterialAndTexture(this.MeshPaintSystem);
  }

  protected unsafe void ResourceTypePaintRadioButton_Click(object Owner, RoutedEventArgs Args)
  {
    FEdModeMeshPaint* meshPaintSystem = this.MeshPaintSystem;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) meshPaintSystem + 120L))((IntPtr) meshPaintSystem);
  }

  protected unsafe void FindTextureInContentBrowserButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEdModeMeshPaint\u002EFindSelectedTextureInContentBrowser(this.MeshPaintSystem);

  protected unsafe void DuplicateTextureMaterialButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEdModeMeshPaint\u002EDuplicateTextureMaterialCombo(this.MeshPaintSystem);

  protected unsafe void CreateNewTextureButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEdModeMeshPaint\u002ECreateNewTexture(this.MeshPaintSystem);

  protected unsafe void SaveTextureButton_Click(object Owner, RoutedEventArgs Args)
  {
    UTexture2D* selectedTexture = \u003CModule\u003E.FEdModeMeshPaint\u002EGetSelectedTexture(this.MeshPaintSystem);
    if (0L == (IntPtr) selectedTexture)
      return;
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      UObject* uobjectPtr = (UObject*) selectedTexture;
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, &uobjectPtr);
      int num = (int) this.SavePackagesForObjects(&fdefaultAllocator);
      this.RefreshAllProperties();
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  protected void CommitTextureChangesButton_Click(object Owner, RoutedEventArgs Args) => this.CommitPaintChanges(true);

  public unsafe double BrushRadius
  {
    get => (double) *(float*) \u003CModule\u003E.FMeshPaintSettings\u002EGet();
    set
    {
      float num = (float) value;
      FMeshPaintSettings* fmeshPaintSettingsPtr = \u003CModule\u003E.FMeshPaintSettings\u002EGet();
      if ((double) num == (double) *(float*) fmeshPaintSettingsPtr)
        return;
      *(float*) \u003CModule\u003E.FMeshPaintSettings\u002EGet() = num;
      this.OnPropertyChanged(nameof (BrushRadius));
    }
  }

  public unsafe double BrushFalloffAmount
  {
    get => (double) *(float*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 4L);
    set
    {
      float num = (float) value;
      if ((double) num == (double) *(float*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 4L))
        return;
      *(float*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 4L) = num;
      this.OnPropertyChanged(nameof (BrushFalloffAmount));
    }
  }

  public unsafe double BrushStrength
  {
    get => (double) *(float*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 8L);
    set
    {
      float num = (float) value;
      if ((double) num == (double) *(float*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 8L))
        return;
      *(float*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 8L) = num;
      this.OnPropertyChanged(nameof (BrushStrength));
    }
  }

  public unsafe bool EnableFlow
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 12L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 12L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 12L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (EnableFlow));
    }
  }

  public unsafe double FlowAmount
  {
    get => (double) *(float*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 16L);
    set
    {
      float num = (float) value;
      if ((double) num == (double) *(float*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 16L))
        return;
      *(float*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 16L) = num;
      this.OnPropertyChanged(nameof (FlowAmount));
    }
  }

  public unsafe bool IgnoreBackFacing
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 20L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 20L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 20L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (IgnoreBackFacing));
    }
  }

  public unsafe bool EnableSeamPainting
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 112L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 112L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 112L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (EnableSeamPainting));
    }
  }

  public unsafe bool IsResourceTypeVertexColors
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 24L) == 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsResourceTypeVertexColors)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      EMeshPaintResource.Type type = (EMeshPaintResource.Type) num;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 24L) = (int) type;
      this.OnPropertyChanged(nameof (IsResourceTypeVertexColors));
    }
  }

  public unsafe bool IsResourceTypeTexture
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 24L) == 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsResourceTypeTexture)
        return;
      int num = 1;
      if (!value)
        num = -num;
      EMeshPaintResource.Type type = (EMeshPaintResource.Type) num;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 24L) = (int) type;
      this.OnPropertyChanged(nameof (IsResourceTypeTexture));
    }
  }

  public unsafe bool IsVertexPaintTargetComponentInstance
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 92L) == 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsVertexPaintTargetComponentInstance)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      EMeshVertexPaintTarget.Type type = (EMeshVertexPaintTarget.Type) num;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 92L) = (int) type;
      this.OnPropertyChanged(nameof (IsVertexPaintTargetComponentInstance));
    }
  }

  public unsafe bool IsVertexPaintTargetMesh
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 92L) == 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsVertexPaintTargetMesh)
        return;
      int num = 1;
      if (!value)
        num = -num;
      EMeshVertexPaintTarget.Type type = (EMeshVertexPaintTarget.Type) num;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 92L) = (int) type;
      this.OnPropertyChanged(nameof (IsVertexPaintTargetMesh));
    }
  }

  public unsafe int UVChannel
  {
    get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 96L);
    set
    {
      if (value == *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 96L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 96L) = value;
      this.OnPropertyChanged(nameof (UVChannel));
    }
  }

  public List<int> UVChannelItems
  {
    get => this.UVChannelItemsValue;
    set
    {
      if (this.UVChannelItemsValue == value)
        return;
      this.UVChannelItemsValue = value;
      this.OnPropertyChanged(nameof (UVChannelItems));
    }
  }

  public bool IsBreechingUndoBuffer
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.IsBreechingUndoBufferValue;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (this.IsBreechingUndoBufferValue == value)
        return;
      this.IsBreechingUndoBufferValue = value;
      this.OnPropertyChanged(nameof (IsBreechingUndoBuffer));
    }
  }

  public unsafe string InstanceVertexColorsText
  {
    get
    {
      string str = Utils.Localize("MeshPaintWindow_InstanceVertexColorsText_NoData");
      int num1 = 0;
      int num2 = 0;
      uint num3 = 0;
      int selectedMeshInfo = (int) \u003CModule\u003E.FEdModeMeshPaint\u002EGetSelectedMeshInfo(this.MeshPaintSystem, &num1, &num2, &num3);
      if (num2 <= 0)
        return str;
      float num4 = (float) num2 * (1f / 1000f);
      return string.Format(Utils.Localize("MeshPaintWindow_InstanceVertexColorsText_NumBytes"), (object) num4);
    }
  }

  public unsafe bool HasInstanceVertexColors
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      int num1 = 0;
      int num2 = 0;
      uint num3 = 0;
      int selectedMeshInfo = (int) \u003CModule\u003E.FEdModeMeshPaint\u002EGetSelectedMeshInfo(this.MeshPaintSystem, &num1, &num2, &num3);
      return num2 > 0;
    }
  }

  public unsafe bool RequiresInstanceVertexColorsFixup
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FEdModeMeshPaint\u002ERequiresInstanceVertexColorsFixup(this.MeshPaintSystem) == 1U;
  }

  public unsafe bool CanCopyToColourBufferCopy
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      if (\u003CModule\u003E.USelection\u002ENum(\u003CModule\u003E.UEditorEngine\u002EGetSelectedActors(\u003CModule\u003E.GEditor)) != 1)
        return false;
      int num1 = 0;
      int num2 = 0;
      uint num3 = 0;
      int selectedMeshInfo = (int) \u003CModule\u003E.FEdModeMeshPaint\u002EGetSelectedMeshInfo(this.MeshPaintSystem, &num1, &num2, &num3);
      return num2 + num1 > 0;
    }
  }

  public unsafe bool CanPasteFromColourBufferCopy
  {
    [return: MarshalAs(UnmanagedType.U1)] get => 1U == \u003CModule\u003E.FEdModeMeshPaint\u002ECanPasteVertexColors(this.MeshPaintSystem);
  }

  public unsafe bool CanCreateInstanceMaterialAndTexture
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      int num1 = 0;
      int num2 = 0;
      uint num3 = 0;
      return \u003CModule\u003E.FEdModeMeshPaint\u002EGetSelectedMeshInfo(this.MeshPaintSystem, &num1, &num2, &num3) != 0U && num3 == 0U;
    }
  }

  public unsafe bool HasInstanceMaterialAndTexture
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      int num1 = 0;
      int num2 = 0;
      uint num3 = 0;
      int selectedMeshInfo = (int) \u003CModule\u003E.FEdModeMeshPaint\u002EGetSelectedMeshInfo(this.MeshPaintSystem, &num1, &num2, &num3);
      return num3 != 0U;
    }
  }

  public unsafe bool IsSelectedSourceMeshDirty
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      FSelectionIterator fselectionIterator;
      \u003CModule\u003E.UEditorEngine\u002EGetSelectedActorIterator(\u003CModule\u003E.GEditor, &fselectionIterator);
      if (\u003CModule\u003E.FSelectionIterator\u002E\u002EI(&fselectionIterator) != 0U)
      {
        do
        {
          AActor* aactorPtr = \u003CModule\u003E.CastChecked\u003Cclass\u0020AActor\u002Cclass\u0020UObject\u003E(\u003CModule\u003E.FSelectionIterator\u002E\u002A(&fselectionIterator));
          AStaticMeshActor* astaticMeshActorPtr = \u003CModule\u003E.Cast\u003Cclass\u0020AStaticMeshActor\u003E((UObject*) aactorPtr);
          UStaticMeshComponent* ustaticMeshComponentPtr;
          if ((IntPtr) astaticMeshActorPtr != IntPtr.Zero)
          {
            ustaticMeshComponentPtr = (UStaticMeshComponent*) *(long*) ((IntPtr) astaticMeshActorPtr + 572L);
          }
          else
          {
            ADynamicSMActor* adynamicSmActorPtr = \u003CModule\u003E.Cast\u003Cclass\u0020ADynamicSMActor\u003E((UObject*) aactorPtr);
            if ((IntPtr) adynamicSmActorPtr != IntPtr.Zero)
              ustaticMeshComponentPtr = (UStaticMeshComponent*) *(long*) ((IntPtr) adynamicSmActorPtr + 572L);
            else
              goto label_7;
          }
          if ((IntPtr) ustaticMeshComponentPtr != IntPtr.Zero)
          {
            ulong num = (ulong) *(long*) ((IntPtr) ustaticMeshComponentPtr + 576L);
            if (num != 0UL && \u003CModule\u003E.UPackage\u002EIsDirty(\u003CModule\u003E.UObject\u002EGetOutermost((UObject*) num)) != 0U)
              goto label_8;
          }
label_7:
          \u003CModule\u003E.FSelectionIterator\u002E\u002B\u002B(&fselectionIterator);
        }
        while (\u003CModule\u003E.FSelectionIterator\u002E\u002EI(&fselectionIterator) != 0U);
        goto label_9;
label_8:
        return true;
      }
label_9:
      return false;
    }
  }

  public unsafe bool IsSelectedTextureDirty
  {
    [return: MarshalAs(UnmanagedType.U1)] get
    {
      UTexture2D* selectedTexture = \u003CModule\u003E.FEdModeMeshPaint\u002EGetSelectedTexture(this.MeshPaintSystem);
      return 0L != (IntPtr) selectedTexture && \u003CModule\u003E.UPackage\u002EIsDirty(\u003CModule\u003E.UObject\u002EGetOutermost((UObject*) selectedTexture)) != 0U;
    }
  }

  public unsafe bool AreThereChangesToCommit
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FEdModeMeshPaint\u002EGetNumberOfPendingPaintChanges(this.MeshPaintSystem) > 0;
  }

  public unsafe bool IsSelectedTextureValid
  {
    [return: MarshalAs(UnmanagedType.U1)] get => (IntPtr) \u003CModule\u003E.FEdModeMeshPaint\u002EGetSelectedTexture(this.MeshPaintSystem) != 0L;
  }

  public unsafe bool IsPaintModeColors
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 28L) == 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsPaintModeColors)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      EMeshPaintMode.Type type = (EMeshPaintMode.Type) num;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 28L) = (int) type;
      this.OnPropertyChanged(nameof (IsPaintModeColors));
    }
  }

  public unsafe bool IsPaintModeWeights
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 28L) == 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsPaintModeWeights)
        return;
      int num = 1;
      if (!value)
        num = -num;
      EMeshPaintMode.Type type = (EMeshPaintMode.Type) num;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 28L) = (int) type;
      this.OnPropertyChanged(nameof (IsPaintModeWeights));
    }
  }

  public unsafe bool WriteRed
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 64L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 64L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 64L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (WriteRed));
    }
  }

  public unsafe bool WriteGreen
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 68L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 68L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 68L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (WriteGreen));
    }
  }

  public unsafe bool WriteBlue
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 72L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 72L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 72L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (WriteBlue));
    }
  }

  public unsafe bool WriteAlpha
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 76L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 76L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 76L) = value ? 1 : 0;
      this.OnPropertyChanged(nameof (WriteAlpha));
    }
  }

  public unsafe int TotalWeightCount
  {
    get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 80L);
    set
    {
      if (value == *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 80L))
        return;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 80L) = value;
      this.OnPropertyChanged(nameof (TotalWeightCount));
    }
  }

  public unsafe bool IsPaintWeightIndex1
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) == 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsPaintWeightIndex1)
        return;
      int num1 = 0;
      if (!value)
        num1 = ~num1;
      int num2 = num1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) = num2;
      this.OnPropertyChanged(nameof (IsPaintWeightIndex1));
    }
  }

  public unsafe bool IsPaintWeightIndex2
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) == 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsPaintWeightIndex2)
        return;
      int num1 = 1;
      if (!value)
        num1 = -num1;
      int num2 = num1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) = num2;
      this.OnPropertyChanged(nameof (IsPaintWeightIndex2));
    }
  }

  public unsafe bool IsPaintWeightIndex3
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) == 2;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsPaintWeightIndex3)
        return;
      int num = value ? 2 : -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) = num;
      this.OnPropertyChanged(nameof (IsPaintWeightIndex3));
    }
  }

  public unsafe bool IsPaintWeightIndex4
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) == 3;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsPaintWeightIndex4)
        return;
      int num = value ? 3 : -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) = num;
      this.OnPropertyChanged(nameof (IsPaintWeightIndex4));
    }
  }

  public unsafe bool IsPaintWeightIndex5
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) == 4;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsPaintWeightIndex5)
        return;
      int num = value ? 4 : -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 84L) = num;
      this.OnPropertyChanged(nameof (IsPaintWeightIndex5));
    }
  }

  public unsafe bool IsEraseWeightIndex1
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) == 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsEraseWeightIndex1)
        return;
      int num1 = 0;
      if (!value)
        num1 = ~num1;
      int num2 = num1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) = num2;
      this.OnPropertyChanged(nameof (IsEraseWeightIndex1));
    }
  }

  public unsafe bool IsEraseWeightIndex2
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) == 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsEraseWeightIndex2)
        return;
      int num1 = 1;
      if (!value)
        num1 = -num1;
      int num2 = num1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) = num2;
      this.OnPropertyChanged(nameof (IsEraseWeightIndex2));
    }
  }

  public unsafe bool IsEraseWeightIndex3
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) == 2;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsEraseWeightIndex3)
        return;
      int num = value ? 2 : -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) = num;
      this.OnPropertyChanged(nameof (IsEraseWeightIndex3));
    }
  }

  public unsafe bool IsEraseWeightIndex4
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) == 3;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsEraseWeightIndex4)
        return;
      int num = value ? 3 : -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) = num;
      this.OnPropertyChanged(nameof (IsEraseWeightIndex4));
    }
  }

  public unsafe bool IsEraseWeightIndex5
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) == 4;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsEraseWeightIndex5)
        return;
      int num = value ? 4 : -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 88L) = num;
      this.OnPropertyChanged(nameof (IsEraseWeightIndex5));
    }
  }

  public unsafe bool IsColorViewModeNormal
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) == 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsColorViewModeNormal)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      EMeshPaintColorViewMode.Type type = (EMeshPaintColorViewMode.Type) num;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) = (int) type;
      this.OnPropertyChanged(nameof (IsColorViewModeNormal));
    }
  }

  public unsafe bool IsColorViewModeRGB
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) == 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsColorViewModeRGB)
        return;
      int num = 1;
      if (!value)
        num = -num;
      EMeshPaintColorViewMode.Type type = (EMeshPaintColorViewMode.Type) num;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) = (int) type;
      this.OnPropertyChanged(nameof (IsColorViewModeRGB));
    }
  }

  public unsafe bool IsColorViewModeAlpha
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) == 2;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsColorViewModeAlpha)
        return;
      EMeshPaintColorViewMode.Type type = value ? (EMeshPaintColorViewMode.Type) 2 : (EMeshPaintColorViewMode.Type) -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) = (int) type;
      this.OnPropertyChanged(nameof (IsColorViewModeAlpha));
    }
  }

  public unsafe bool IsColorViewModeRed
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) == 3;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsColorViewModeRed)
        return;
      EMeshPaintColorViewMode.Type type = value ? (EMeshPaintColorViewMode.Type) 3 : (EMeshPaintColorViewMode.Type) -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) = (int) type;
      this.OnPropertyChanged(nameof (IsColorViewModeRed));
    }
  }

  public unsafe bool IsColorViewModeGreen
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) == 4;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsColorViewModeGreen)
        return;
      EMeshPaintColorViewMode.Type type = value ? (EMeshPaintColorViewMode.Type) 4 : (EMeshPaintColorViewMode.Type) -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) = (int) type;
      this.OnPropertyChanged(nameof (IsColorViewModeGreen));
    }
  }

  public unsafe bool IsColorViewModeBlue
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) == 5;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (value == this.IsColorViewModeBlue)
        return;
      EMeshPaintColorViewMode.Type type = value ? (EMeshPaintColorViewMode.Type) 5 : (EMeshPaintColorViewMode.Type) -1;
      *(int*) ((IntPtr) \u003CModule\u003E.FMeshPaintSettings\u002EGet() + 100L) = (int) type;
      this.OnPropertyChanged(nameof (IsColorViewModeBlue));
    }
  }

  public MEnumerableTArrayWrapper\u003CMTextureTargetListWrapper\u002CFTextureTargetListInfo\u003E TexturePaintTargetProperty
  {
    get => this.TexturePaintTargetList;
    set
    {
      if (value == this.TexturePaintTargetList)
        return;
      this.TexturePaintTargetList = value;
      this.OnPropertyChanged(nameof (TexturePaintTargetProperty));
    }
  }

  public bool IsSelectionLocked
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.GEdSelectionLock != 0U;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == (int) \u003CModule\u003E.GEdSelectionLock)
        return;
      \u003CModule\u003E.GEdSelectionLock = (uint) value;
      this.OnPropertyChanged(nameof (IsSelectionLocked));
    }
  }

  protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      this.\u007EMMeshPaintWindow();
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
