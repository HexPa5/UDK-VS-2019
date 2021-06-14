// Decompiled with JetBrains decompiler
// Type: MFoliageEditWindow
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using \u003CCppImplementationDetails\u003E;
using CustomControls;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UnrealEd;

internal class MFoliageEditWindow : MWPFWindowWrapper, INotifyPropertyChanged
{
  public MEnumerableTArrayWrapper\u003CMFoliageMeshWrapper\u002CFFoliageMeshUIInfo\u003E FoliageMeshesValue;
  protected readonly MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E DroppedAssets;
  protected unsafe FEdModeFoliage* FoliageEditSystem;

  public unsafe bool PaintToolSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FFoliageUISettings\u002EGetPaintToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (\u003CModule\u003E.FFoliageUISettings\u002EGetPaintToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetPaintToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe bool ReapplyToolSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FFoliageUISettings\u002EGetReapplyToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (\u003CModule\u003E.FFoliageUISettings\u002EGetReapplyToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetReapplyToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe bool SelectToolSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FFoliageUISettings\u002EGetSelectToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (\u003CModule\u003E.FFoliageUISettings\u002EGetSelectToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetSelectToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe bool LassoSelectToolSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FFoliageUISettings\u002EGetLassoSelectToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (\u003CModule\u003E.FFoliageUISettings\u002EGetLassoSelectToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetLassoSelectToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe bool PaintBucketToolSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FFoliageUISettings\u002EGetPaintBucketToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (\u003CModule\u003E.FFoliageUISettings\u002EGetPaintBucketToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetPaintBucketToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe bool ReapplyPaintBucketToolSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FFoliageUISettings\u002EGetReapplyPaintBucketToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (\u003CModule\u003E.FFoliageUISettings\u002EGetReapplyPaintBucketToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetReapplyPaintBucketToolSelected((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe float Radius
  {
    get => \u003CModule\u003E.FFoliageUISettings\u002EGetRadius((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    set
    {
      if ((double) \u003CModule\u003E.FFoliageUISettings\u002EGetRadius((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == (double) value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetRadius((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe float PaintDensity
  {
    get => \u003CModule\u003E.FFoliageUISettings\u002EGetPaintDensity((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    set
    {
      if ((double) \u003CModule\u003E.FFoliageUISettings\u002EGetPaintDensity((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == (double) value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetPaintDensity((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe float UnpaintDensity
  {
    get => \u003CModule\u003E.FFoliageUISettings\u002EGetUnpaintDensity((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    set
    {
      if ((double) \u003CModule\u003E.FFoliageUISettings\u002EGetUnpaintDensity((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == (double) value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetUnpaintDensity((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe bool FilterLandscape
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FFoliageUISettings\u002EGetFilterLandscape((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (\u003CModule\u003E.FFoliageUISettings\u002EGetFilterLandscape((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetFilterLandscape((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe bool FilterStaticMesh
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FFoliageUISettings\u002EGetFilterStaticMesh((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (\u003CModule\u003E.FFoliageUISettings\u002EGetFilterStaticMesh((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetFilterStaticMesh((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe bool FilterBSP
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FFoliageUISettings\u002EGetFilterBSP((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (\u003CModule\u003E.FFoliageUISettings\u002EGetFilterBSP((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetFilterBSP((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public unsafe bool FilterTerrain
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FFoliageUISettings\u002EGetFilterTerrain((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L));
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (\u003CModule\u003E.FFoliageUISettings\u002EGetFilterTerrain((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L)) == value)
        return;
      \u003CModule\u003E.FFoliageUISettings\u002ESetFilterTerrain((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), value);
    }
  }

  public MEnumerableTArrayWrapper\u003CMFoliageMeshWrapper\u002CFFoliageMeshUIInfo\u003E FoliageMeshesProperty
  {
    get => this.FoliageMeshesValue;
    set
    {
      if (value == this.FoliageMeshesValue)
        return;
      this.FoliageMeshesValue = value;
      this.OnPropertyChanged(nameof (FoliageMeshesProperty));
    }
  }

  public unsafe MFoliageEditWindow(FEdModeFoliage* InFoliageEditSystem)
  {
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator = new MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E();
    // ISSUE: fault handler
    try
    {
      this.DroppedAssets = fdefaultAllocator;
      this.FoliageEditSystem = InFoliageEditSystem;
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }
    __fault
    {
      this.DroppedAssets.Dispose();
    }
  }

  public unsafe uint InitFoliageEditWindow(HWND__* InParentWindowHandle)
  {
    string InWindowTitle = \u003CModule\u003E.CLRTools\u002ELocalizeString("FoliageEditWindow_WindowTitle", (string) null, (string) null, (string) null);
    string InWPFXamlFileName = "FoliageEditWindow.xaml";
    int InPositionX;
    int InPositionY;
    int InWidth;
    int InHeight;
    \u003CModule\u003E.FFoliageUISettings\u002EGetWindowSizePos((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), &InPositionX, &InPositionY, &InWidth, &InHeight);
    bool bCenterWindow = InPositionX == -1 || InPositionY == -1;
    if (this.InitWindow(InParentWindowHandle, InWindowTitle, InWPFXamlFileName, InPositionX, InPositionY, InWidth, InHeight, bCenterWindow, 28, 0) == 0U)
      return 0;
    MFoliageEditWindow mfoliageEditWindow1 = this;
    mfoliageEditWindow1.PropertyChanged += new PropertyChangedEventHandler(mfoliageEditWindow1.OnFoliageEditPropertyChanged);
    Visual rootVisual = this.InteropWindow.op_MemberSelection().RootVisual;
    FrameworkElement frameworkElement = (FrameworkElement) rootVisual;
    frameworkElement.DataContext = (object) this;
    Button logicalNode1 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "TitleBarCloseButton");
    logicalNode1.Click += new RoutedEventHandler(this.OnClose);
    this.FakeTitleBarButtonWidth = (int) (logicalNode1.ActualWidth + (double) this.FakeTitleBarButtonWidth);
    ImageRadioButton logicalNode2 = (ImageRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "Tool_Paint");
    FString fstring1;
    FString* editorResourcesDir1 = \u003CModule\u003E.GetEditorResourcesDir(&fstring1);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FA\u0040BDEGNJEH\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAP\u003F\u0024AAa\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AA_\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAt\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir1));
      // ISSUE: fault handler
      try
      {
        logicalNode2.CheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
    FString fstring3;
    FString* editorResourcesDir2 = \u003CModule\u003E.GetEditorResourcesDir(&fstring3);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FE\u0040CCLOFJKN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAP\u003F\u0024AAa\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AA_\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAa\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir2));
      // ISSUE: fault handler
      try
      {
        logicalNode2.UncheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
    Utils.CreateBinding((FrameworkElement) logicalNode2, (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "PaintToolSelected");
    ((ButtonBase) logicalNode2).Click += new RoutedEventHandler(this.ToolButton_Click);
    ImageRadioButton logicalNode3 = (ImageRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "Tool_Reapply");
    FString fstring4;
    FString* editorResourcesDir3 = \u003CModule\u003E.GetEditorResourcesDir(&fstring4);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FE\u0040OGJIHIKD\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAR\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAp\u003F\u0024AAl\u003F\u0024AAy\u003F\u0024AA_\u003F\u0024AAa\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir3));
      // ISSUE: fault handler
      try
      {
        logicalNode3.CheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
    FString fstring5;
    FString* editorResourcesDir4 = \u003CModule\u003E.GetEditorResourcesDir(&fstring5);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FI\u0040HBHFFGJH\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAR\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAp\u003F\u0024AAl\u003F\u0024AAy\u003F\u0024AA_\u003F\u0024AAi\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir4));
      // ISSUE: fault handler
      try
      {
        logicalNode3.UncheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
    Utils.CreateBinding((FrameworkElement) logicalNode3, (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "ReapplyToolSelected");
    ((ButtonBase) logicalNode3).Click += new RoutedEventHandler(this.ToolButton_Click);
    ImageRadioButton logicalNode4 = (ImageRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "Tool_Select");
    FString fstring6;
    FString* editorResourcesDir5 = \u003CModule\u003E.GetEditorResourcesDir(&fstring6);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FI\u0040MOFOKHGI\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAS\u003F\u0024AAe\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAc\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAo\u003F\u0024AAn\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir5));
      // ISSUE: fault handler
      try
      {
        logicalNode4.CheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
    FString fstring7;
    FString* editorResourcesDir6 = \u003CModule\u003E.GetEditorResourcesDir(&fstring7);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FM\u0040POPJJFKP\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAS\u003F\u0024AAe\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAc\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAo\u003F\u0024AAn\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir6));
      // ISSUE: fault handler
      try
      {
        logicalNode4.UncheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring7);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring7);
    Utils.CreateBinding((FrameworkElement) logicalNode4, (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "SelectToolSelected");
    ((ButtonBase) logicalNode4).Click += new RoutedEventHandler(this.ToolButton_Click);
    ImageRadioButton logicalNode5 = (ImageRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "Tool_LassoSelect");
    FString fstring8;
    FString* editorResourcesDir7 = \u003CModule\u003E.GetEditorResourcesDir(&fstring8);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1EO\u0040PPDKNCGA\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAM\u003F\u0024AAa\u003F\u0024AAs\u003F\u0024AAk\u003F\u0024AA_\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAt\u003F\u0024AAi\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir7));
      // ISSUE: fault handler
      try
      {
        logicalNode5.CheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring8);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring8);
    FString fstring9;
    FString* editorResourcesDir8 = \u003CModule\u003E.GetEditorResourcesDir(&fstring9);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FC\u0040DJDILJGC\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAM\u003F\u0024AAa\u003F\u0024AAs\u003F\u0024AAk\u003F\u0024AA_\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAa\u003F\u0024AAc\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir8));
      // ISSUE: fault handler
      try
      {
        logicalNode5.UncheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring9);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring9);
    Utils.CreateBinding((FrameworkElement) logicalNode5, (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "LassoSelectToolSelected");
    ((ButtonBase) logicalNode5).Click += new RoutedEventHandler(this.ToolButton_Click);
    ImageRadioButton logicalNode6 = (ImageRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "Tool_PaintBucket");
    FString fstring10;
    FString* editorResourcesDir9 = \u003CModule\u003E.GetEditorResourcesDir(&fstring10);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FM\u0040FKPHHMPL\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAP\u003F\u0024AAa\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAu\u003F\u0024AAc\u003F\u0024AAk\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir9));
      // ISSUE: fault handler
      try
      {
        logicalNode6.CheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring10);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring10);
    FString fstring11;
    FString* editorResourcesDir10 = \u003CModule\u003E.GetEditorResourcesDir(&fstring11);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1GA\u0040FIHHFBMJ\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAP\u003F\u0024AAa\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAu\u003F\u0024AAc\u003F\u0024AAk\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir10));
      // ISSUE: fault handler
      try
      {
        logicalNode6.UncheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring11);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring11);
    Utils.CreateBinding((FrameworkElement) logicalNode6, (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "PaintBucketToolSelected");
    ((ButtonBase) logicalNode6).Click += new RoutedEventHandler(this.ToolButton_Click);
    ImageRadioButton logicalNode7 = (ImageRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "Tool_ReapplyPaintBucket");
    FString fstring12;
    FString* editorResourcesDir11 = \u003CModule\u003E.GetEditorResourcesDir(&fstring12);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1GK\u0040LMCFAMKB\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAP\u003F\u0024AAa\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAu\u003F\u0024AAc\u003F\u0024AAk\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir11));
      // ISSUE: fault handler
      try
      {
        logicalNode7.CheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring12);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring12);
    FString fstring13;
    FString* editorResourcesDir12 = \u003CModule\u003E.GetEditorResourcesDir(&fstring13);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1GO\u0040FCFBDGIP\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AAP\u003F\u0024AAa\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAu\u003F\u0024AAc\u003F\u0024AAk\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir12));
      // ISSUE: fault handler
      try
      {
        logicalNode7.UncheckedImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
    Utils.CreateBinding((FrameworkElement) logicalNode7, (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "ReapplyPaintBucketToolSelected");
    ((ButtonBase) logicalNode7).Click += new RoutedEventHandler(this.ToolButton_Click);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "BrushRadiusSlider"), RangeBase.ValueProperty, (object) this, "Radius");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "PaintDensitySlider"), RangeBase.ValueProperty, (object) this, "PaintDensity");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "UnpaintDensitySlider"), RangeBase.ValueProperty, (object) this, "UnpaintDensity");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FilterLandscapeCheckbox"), ToggleButton.IsCheckedProperty, (object) this, "FilterLandscape");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FilterStaticMeshCheckbox"), ToggleButton.IsCheckedProperty, (object) this, "FilterStaticMesh");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FilterBSPCheckbox"), ToggleButton.IsCheckedProperty, (object) this, "FilterBSP");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FilterTerrainCheckbox"), ToggleButton.IsCheckedProperty, (object) this, "FilterTerrain");
    MFoliageEditWindow mfoliageEditWindow2 = this;
    mfoliageEditWindow2.FoliageMeshesValue = new MEnumerableTArrayWrapper\u003CMFoliageMeshWrapper\u002CFFoliageMeshUIInfo\u003E(\u003CModule\u003E.FEdModeFoliage\u002EGetFoliageMeshList(mfoliageEditWindow2.FoliageEditSystem));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FoliageMeshesListBox"), ItemsControl.ItemsSourceProperty, (object) this, "FoliageMeshesProperty");
    GroupBox logicalNode8 = (GroupBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FoliageMeshesGroupBox");
    logicalNode8.AllowDrop = true;
    logicalNode8.DragOver += new DragEventHandler(this.OnDragOver);
    logicalNode8.Drop += new DragEventHandler(this.OnDrop);
    logicalNode8.DragEnter += new DragEventHandler(this.OnDragEnter);
    logicalNode8.DragLeave += new DragEventHandler(this.OnDragLeave);
    RoutedCommand resource1 = (RoutedCommand) frameworkElement.FindResource((object) "FoliageMeshReplaceCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource1, new ExecutedRoutedEventHandler(this.FoliageMeshReplaceButton_Click)));
    RoutedCommand resource2 = (RoutedCommand) frameworkElement.FindResource((object) "FoliageMeshSyncCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource2, new ExecutedRoutedEventHandler(this.FoliageMeshSync_Click)));
    RoutedCommand resource3 = (RoutedCommand) frameworkElement.FindResource((object) "FoliageMeshRemoveCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource3, new ExecutedRoutedEventHandler(this.FoliageMeshRemoveButton_Click)));
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) frameworkElement.FindResource((object) "FoliageMeshUseSettings"), new ExecutedRoutedEventHandler(this.FoliageMeshUseSettings_Click)));
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) frameworkElement.FindResource((object) "FoliageMeshCopySettings"), new ExecutedRoutedEventHandler(this.FoliageMeshCopySettings_Click)));
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) frameworkElement.FindResource((object) "FoliageMeshSaveSettings"), new ExecutedRoutedEventHandler(this.FoliageMeshSaveSettings_Click)));
    \u003CModule\u003E.ShowWindow(this.GetWindowHandle(), 5);
    return 1;
  }

  public unsafe void RefreshMeshList()
  {
    \u003CModule\u003E.FEdModeFoliage\u002EUpdateFoliageMeshList(this.FoliageEditSystem);
    this.FoliageMeshesValue.NotifyChanged();
  }

  public unsafe void NotifyNewCurrentLevel() => \u003CModule\u003E.FEdModeFoliage\u002ENotifyNewCurrentLevel(this.FoliageEditSystem);

  public void RefreshMeshListProperties() => this.FoliageMeshesValue.NotifyChanged();

  public virtual event PropertyChangedEventHandler PropertyChanged;

  [SpecialName]
  protected virtual void raise_PropertyChanged(object value0, PropertyChangedEventArgs value1)
  {
    PropertyChangedEventHandler storePropertyChanged = this.\u003Cbacking_store\u003EPropertyChanged;
    if (storePropertyChanged == null)
      return;
    storePropertyChanged(value0, value1);
  }

  public unsafe void SaveWindowSettings()
  {
    tagRECT tagRect;
    \u003CModule\u003E.GetWindowRect(this.GetWindowHandle(), &tagRect);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    \u003CModule\u003E.FFoliageUISettings\u002ESetWindowSizePos((FFoliageUISettings*) ((IntPtr) this.FoliageEditSystem + 88L), ^(int&) ref tagRect, ^(int&) ((IntPtr) &tagRect + 4), ^(int&) ((IntPtr) &tagRect + 8) - ^(int&) ref tagRect, ^(int&) ((IntPtr) &tagRect + 12) - ^(int&) ((IntPtr) &tagRect + 4));
  }

  public void RefreshAllProperties() => this.OnPropertyChanged((string) null);

  protected unsafe void OnClose(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEditorModeTools\u002EDeactivateMode(\u003CModule\u003E.GEditorModeTools(), (EEditorMode) 11);

  protected unsafe void ToolButton_Click(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEdModeFoliage\u002ENotifyToolChanged(this.FoliageEditSystem);

  protected void OnFoliageEditPropertyChanged(object Owner, PropertyChangedEventArgs Args)
  {
  }

  protected unsafe void OnDragEnter(object Sender, DragEventArgs Args)
  {
    if (!Args.Data.GetDataPresent(DataFormats.StringFormat))
      return;
    \u0024ArrayType\u0024\u0024\u0024BY01\u0024\u0024CB_W arrayTypeBy01CbW;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ^(short&) ref arrayTypeBy01CbW = (short) 124;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ^(short&) ((IntPtr) &arrayTypeBy01CbW + 2) = (short) 0;
    string data = (string) Args.Data.GetData(DataFormats.StringFormat);
    FString fstring;
    \u003CModule\u003E.CLRTools\u002EToFString(&fstring, data);
    // ISSUE: fault handler
    try
    {
      TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002EParseIntoArray(&fstring, &fdefaultAllocator, (char*) &arrayTypeBy01CbW, 1U);
        TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = (TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
        TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E* InNativePointer;
        // ISSUE: fault handler
        try
        {
          InNativePointer = (IntPtr) fdefaultAllocatorPtr == IntPtr.Zero ? (TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr);
        }
        __fault
        {
          \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr);
        }
        this.DroppedAssets.Reset(InNativePointer);
        \u003CModule\u003E.TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002EEmpty(this.DroppedAssets.op_MemberSelection(), \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator));
        TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
        \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, &fdefaultAllocator);
        if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
        {
          do
          {
            FSelectedAssetInfo* fselectedAssetInfoPtr = (FSelectedAssetInfo*) \u003CModule\u003E.operator\u0020new\u003Cstruct\u0020FSelectedAssetInfo\u002Cclass\u0020FDefaultAllocator\u003E(32UL, this.DroppedAssets.Get());
            if ((IntPtr) fselectedAssetInfoPtr != IntPtr.Zero)
              \u003CModule\u003E.FSelectedAssetInfo\u002E\u007Bctor\u007D(fselectedAssetInfoPtr, \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt));
            \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
          }
          while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
        }
        Args.Handled = true;
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
      }
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  protected unsafe void OnDragLeave(object Sender, DragEventArgs Args)
  {
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E droppedAssets = this.DroppedAssets;
    if ((IntPtr) droppedAssets.Get() != IntPtr.Zero)
    {
      \u003CModule\u003E.TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002EEmpty(droppedAssets.op_MemberSelection(), 0);
      this.DroppedAssets.Reset((TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) 0L);
    }
    Args.Handled = true;
  }

  protected unsafe void OnDragOver(object Owner, DragEventArgs Args)
  {
    Args.Effects = DragDropEffects.Copy;
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E droppedAssets = this.DroppedAssets;
    if ((IntPtr) droppedAssets.Get() != IntPtr.Zero)
    {
      TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, droppedAssets.Get());
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        while (*(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt) == (IntPtr) \u003CModule\u003E.UStaticMesh\u002EStaticClass())
        {
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
          if (!\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
            goto label_5;
        }
        Args.Effects = DragDropEffects.None;
      }
    }
label_5:
    Args.Handled = true;
  }

  protected unsafe void OnDrop(object Owner, DragEventArgs Args)
  {
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E droppedAssets = this.DroppedAssets;
    if ((IntPtr) droppedAssets.Get() != IntPtr.Zero)
    {
      TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, droppedAssets.Get());
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          UStaticMesh* ustaticMeshPtr = \u003CModule\u003E.LoadObject\u003Cclass\u0020UStaticMesh\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt) + 8L)), (char*) 0L, 0U, (UPackageMap*) 0L);
          if ((IntPtr) ustaticMeshPtr != IntPtr.Zero)
          {
            \u003CModule\u003E.FEdModeFoliage\u002EAddFoliageMesh(this.FoliageEditSystem, ustaticMeshPtr);
            this.FoliageMeshesValue.NotifyChanged();
          }
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
      }
      \u003CModule\u003E.TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002EEmpty(this.DroppedAssets.op_MemberSelection(), 0);
      this.DroppedAssets.Reset((TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) 0L);
    }
    Args.Handled = true;
  }

  protected unsafe void FoliageMeshReplaceButton_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr, ECallbackEventType)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 72L))((ECallbackEventType) gcallbackEvent, new IntPtr(24));
    UStaticMesh* ustaticMeshPtr = \u003CModule\u003E.Cast\u003Cclass\u0020UStaticMesh\u003E(\u003CModule\u003E.USelection\u002EGetTop(\u003CModule\u003E.UEditorEngine\u002EGetSelectedSet(\u003CModule\u003E.GEditor, \u003CModule\u003E.UStaticMesh\u002EStaticClass()), \u003CModule\u003E.UStaticMesh\u002EStaticClass()));
    if ((IntPtr) ustaticMeshPtr == IntPtr.Zero)
      return;
    \u003CModule\u003E.FEdModeFoliage\u002EReplaceStaticMesh(this.FoliageEditSystem, ((MFoliageMeshWrapper) Args.Parameter).GetStaticMesh(), ustaticMeshPtr);
    this.FoliageMeshesValue.NotifyChanged();
  }

  protected unsafe void FoliageMeshSync_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    MFoliageMeshWrapper parameter = (MFoliageMeshWrapper) Args.Parameter;
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      UObject* staticMesh = (UObject*) parameter.GetStaticMesh();
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, &staticMesh);
      \u003CModule\u003E.WxEditorFrame\u002ESyncBrowserToObjects((WxEditorFrame*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &fdefaultAllocator);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  protected unsafe void FoliageMeshRemoveButton_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    \u003CModule\u003E.FEdModeFoliage\u002ERemoveFoliageMesh(this.FoliageEditSystem, ((MFoliageMeshWrapper) Args.Parameter).GetStaticMesh());
    this.FoliageMeshesValue.NotifyChanged();
  }

  protected unsafe void FoliageMeshUseSettings_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr, ECallbackEventType)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 72L))((ECallbackEventType) gcallbackEvent, new IntPtr(24));
    UInstancedFoliageSettings* uinstancedFoliageSettingsPtr = \u003CModule\u003E.Cast\u003Cclass\u0020UInstancedFoliageSettings\u003E(\u003CModule\u003E.USelection\u002EGetTop(\u003CModule\u003E.UEditorEngine\u002EGetSelectedSet(\u003CModule\u003E.GEditor, \u003CModule\u003E.UInstancedFoliageSettings\u002EStaticClass()), \u003CModule\u003E.UInstancedFoliageSettings\u002EStaticClass()));
    if ((IntPtr) uinstancedFoliageSettingsPtr == IntPtr.Zero)
      return;
    \u003CModule\u003E.FEdModeFoliage\u002EReplaceSettingsObject(this.FoliageEditSystem, ((MFoliageMeshWrapper) Args.Parameter).GetStaticMesh(), uinstancedFoliageSettingsPtr);
    this.FoliageMeshesValue.NotifyChanged();
  }

  protected unsafe void FoliageMeshCopySettings_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    \u003CModule\u003E.FEdModeFoliage\u002ECopySettingsObject(this.FoliageEditSystem, ((MFoliageMeshWrapper) Args.Parameter).GetStaticMesh());
    this.FoliageMeshesValue.NotifyChanged();
  }

  protected unsafe void FoliageMeshSaveSettings_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    \u003CModule\u003E.FEdModeFoliage\u002ESaveSettingsObject(this.FoliageEditSystem, ((MFoliageMeshWrapper) Args.Parameter).GetStaticMesh());
    this.FoliageMeshesValue.NotifyChanged();
  }

  protected void OnMeshDataChanged(object Owner, PropertyChangedEventArgs Args)
  {
  }

  protected virtual void OnPropertyChanged(string Info)
  {
    MFoliageEditWindow mfoliageEditWindow = this;
    mfoliageEditWindow.raise_PropertyChanged((object) mfoliageEditWindow, new PropertyChangedEventArgs(Info));
  }

  protected override unsafe IntPtr VirtualMessageHookFunction(
    IntPtr HWnd,
    int Msg,
    IntPtr WParam,
    IntPtr LParam,
    ref bool OutHandled)
  {
    OutHandled = false;
    int num1 = 0;
    switch (Msg)
    {
      case 8:
        if (this.InteropWindow.op_MemberSelection().RootVisual != null && FocusManager.GetFocusedElement((DependencyObject) this.InteropWindow.op_MemberSelection().RootVisual) is TextBox focusedElement2)
        {
          BindingExpression bindingExpression = focusedElement2.GetBindingExpression(TextBox.TextProperty);
          if (bindingExpression != null)
          {
            bindingExpression.UpdateSource();
            break;
          }
          break;
        }
        break;
      case 33:
        \u003CModule\u003E.BringWindowToTop((HWND__*) (long) HWnd);
        break;
      case 36:
        long num2 = (long) HWnd;
        long num3 = (long) WParam;
        long num4 = (long) LParam;
        long num5 = num3;
        long num6 = num4;
        num1 = (int) \u003CModule\u003E.DefWindowProcW((HWND__*) num2, 36U, (ulong) num5, num6);
        OutHandled = true;
        *(int*) (num4 + 28L) = 150;
        break;
      case 132:
        HWND__* hwndPtr = (HWND__*) (long) HWnd;
        long num7 = (long) WParam;
        long num8 = (long) LParam;
        num1 = (int) \u003CModule\u003E.DefWindowProcW(hwndPtr, 132U, (ulong) num7, num8);
        if (num1 == 1)
        {
          tagRECT tagRect;
          \u003CModule\u003E.GetWindowRect(hwndPtr, &tagRect);
          int num9 = (int) (short) (uint) ((ulong) num8 >> 16);
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          if (num9 >= ^(int&) ((IntPtr) &tagRect + 4) && num9 < ^(int&) ((IntPtr) &tagRect + 4) + 5)
          {
            num1 = 12;
            OutHandled = true;
            goto label_12;
          }
          else
          {
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            if (num9 <= ^(int&) ((IntPtr) &tagRect + 12) && num9 > ^(int&) ((IntPtr) &tagRect + 12) - 5)
            {
              num1 = 15;
              OutHandled = true;
              goto label_12;
            }
            else
              break;
          }
        }
        else
          break;
      default:
label_13:
        return base.VirtualMessageHookFunction(HWnd, Msg, WParam, LParam, ref OutHandled);
    }
    if (!OutHandled)
      goto label_13;
label_12:
    return (IntPtr) num1;
  }

  public void \u007EMFoliageEditWindow()
  {
  }

  [HandleProcessCorruptedStateExceptions]
  protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      try
      {
      }
      finally
      {
        try
        {
          base.Dispose(true);
        }
        finally
        {
          this.DroppedAssets.Dispose();
        }
      }
    }
    else
      base.Dispose(false);
  }
}
