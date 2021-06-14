// Decompiled with JetBrains decompiler
// Type: MBuildAndSubmitPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

internal class MBuildAndSubmitPanel : MWPFPanel
{
  private uint bAnyLevelsHidden;
  private CheckBox BuildErrorCheckBox;
  private CheckBox AddNotInDepotCheckBox;
  private CheckBox SaveErrorCheckBox;
  private CheckBox IncludeUnsourcedPackagesCheckBox;
  private TextBox ChangelistDescriptionTextBox;
  private DockPanel ErrorPanel;
  private TextBlock ErrorPanelTextBlock;
  private readonly MNativePointer\u003CFSourceControlEventListener\u003E SCEventListener;
  private ListView SubmitListView;
  private ObservableCollection<BuildAndSubmitCheckBoxListViewItem> ListViewItemSource;
  private ICollectionView ListItemCollectionView;

  public unsafe MBuildAndSubmitPanel(
    string InXamlName,
    FSourceControlEventListener* InEventListener)
  {
    this.SCEventListener = new MNativePointer\u003CFSourceControlEventListener\u003E(InEventListener);
    // ISSUE: explicit constructor call
    base.\u002Ector(InXamlName);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "OKButton")).Click += new RoutedEventHandler(this.OKClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CancelButton")).Click += new RoutedEventHandler(this.CancelClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "DismissErrorPanelButton")).Click += new RoutedEventHandler(this.DismissErrorPanelClicked);
    MBuildAndSubmitPanel mbuildAndSubmitPanel1 = this;
    mbuildAndSubmitPanel1.BuildErrorCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mbuildAndSubmitPanel1, nameof (BuildErrorCheckBox));
    MBuildAndSubmitPanel mbuildAndSubmitPanel2 = this;
    mbuildAndSubmitPanel2.AddNotInDepotCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mbuildAndSubmitPanel2, nameof (AddNotInDepotCheckBox));
    MBuildAndSubmitPanel mbuildAndSubmitPanel3 = this;
    mbuildAndSubmitPanel3.IncludeUnsourcedPackagesCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mbuildAndSubmitPanel3, nameof (IncludeUnsourcedPackagesCheckBox));
    this.IncludeUnsourcedPackagesCheckBox.Click += new RoutedEventHandler(this.IncludeUnsourcedPackagesClick);
    MBuildAndSubmitPanel mbuildAndSubmitPanel4 = this;
    mbuildAndSubmitPanel4.SaveErrorCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mbuildAndSubmitPanel4, nameof (SaveErrorCheckBox));
    MBuildAndSubmitPanel mbuildAndSubmitPanel5 = this;
    mbuildAndSubmitPanel5.ChangelistDescriptionTextBox = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mbuildAndSubmitPanel5, nameof (ChangelistDescriptionTextBox));
    MBuildAndSubmitPanel mbuildAndSubmitPanel6 = this;
    mbuildAndSubmitPanel6.ErrorPanel = (DockPanel) LogicalTreeHelper.FindLogicalNode((DependencyObject) mbuildAndSubmitPanel6, nameof (ErrorPanel));
    MBuildAndSubmitPanel mbuildAndSubmitPanel7 = this;
    mbuildAndSubmitPanel7.ErrorPanelTextBlock = (TextBlock) LogicalTreeHelper.FindLogicalNode((DependencyObject) mbuildAndSubmitPanel7, nameof (ErrorPanelTextBlock));
    MBuildAndSubmitPanel mbuildAndSubmitPanel8 = this;
    mbuildAndSubmitPanel8.SubmitListView = (ListView) LogicalTreeHelper.FindLogicalNode((DependencyObject) mbuildAndSubmitPanel8, nameof (SubmitListView));
    this.SubmitListView.AddHandler(ButtonBase.ClickEvent, (Delegate) new RoutedEventHandler(MBuildAndSubmitPanel.ColumnHeaderClicked));
    this.ListViewItemSource = new ObservableCollection<BuildAndSubmitCheckBoxListViewItem>();
    FPackageFileCache* gpackageFileCache = \u003CModule\u003E.GPackageFileCache;
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator1;
    ref TArray\u003CFString\u002CFDefaultAllocator\u003E local = ref fdefaultAllocator1;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    long num = (long) __calli((__FnPtr<TArray\u003CFString\u002CFDefaultAllocator\u003E* (IntPtr, TArray\u003CFString\u002CFDefaultAllocator\u003E*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 40L))((TArray\u003CFString\u002CFDefaultAllocator\u003E*) gpackageFileCache, (IntPtr) ref local);
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) num);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
      TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, &fdefaultAllocator2);
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          FFilename ffilename1;
          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename1, \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt));
          FFilename ffilename2;
          ESourceControlState esourceControlState;
          bool flag;
          // ISSUE: fault handler
          try
          {
            FString fstring1;
            FString* baseFilename = \u003CModule\u003E.FFilename\u002EGetBaseFilename(&ffilename1, &fstring1, 1U);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename2, baseFilename);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
            }
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
              // ISSUE: cast to a function pointer type
              // ISSUE: function pointer call
              esourceControlState = (ESourceControlState) __calli((__FnPtr<int (IntPtr, char*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 32L))((char*) \u003CModule\u003E.GPackageFileCache, (IntPtr) \u003CModule\u003E.FString\u002E\u002A((FString*) &ffilename2));
              switch (esourceControlState)
              {
                case (ESourceControlState) 1:
                case (ESourceControlState) 4:
                  FString fstring2;
                  FString* fstringPtr = &fstring2;
                  if (!\u003CModule\u003E.CLRTools\u002EIsMapPackageAsset(\u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A((FString*) &ffilename1))))
                  {
                    flag = false;
                    if (esourceControlState == (ESourceControlState) 1)
                    {
                      UPackage* package = \u003CModule\u003E.UObject\u002EFindPackage((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A((FString*) &ffilename2));
                      if ((IntPtr) package != IntPtr.Zero)
                      {
                        if (\u003CModule\u003E.UPackage\u002EIsDirty(package) != 0U)
                        {
                          flag = true;
                          goto label_18;
                        }
                        else
                          break;
                      }
                      else
                        break;
                    }
                    else
                      goto label_18;
                  }
                  else
                    goto label_25;
                default:
                  goto label_25;
              }
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename2);
            }
            \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename1);
          }
          \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename1);
          goto label_29;
label_18:
          // ISSUE: fault handler
          try
          {
            // ISSUE: fault handler
            try
            {
              FString fstring;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, \u003CModule\u003E.FString\u002E\u002A((FString*) &ffilename2));
              BuildAndSubmitCheckBoxListViewItem checkBoxListViewItem;
              // ISSUE: fault handler
              try
              {
                checkBoxListViewItem = new BuildAndSubmitCheckBoxListViewItem(new string(\u003CModule\u003E.FString\u002E\u002A(&fstring), 0, \u003CModule\u003E.FString\u002ELen(&fstring)));
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
              checkBoxListViewItem.SourceControlState = esourceControlState;
              checkBoxListViewItem.IsSelected = flag;
              this.ListViewItemSource.Add(checkBoxListViewItem);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename2);
            }
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename1);
          }
label_25:
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename1);
          }
          \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename1);
label_29:
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
      }
      this.SubmitListView.ItemsSource = (IEnumerable) this.ListViewItemSource;
      MBuildAndSubmitPanel mbuildAndSubmitPanel9 = this;
      mbuildAndSubmitPanel9.ListItemCollectionView = CollectionViewSource.GetDefaultView((object) mbuildAndSubmitPanel9.ListViewItemSource);
      this.ListItemCollectionView.Filter = new Predicate<object>(this.FilterPackageList);
      this.WarnOfHiddenLevels();
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.CancelClicked);
  }

  [return: MarshalAs(UnmanagedType.U1)]
  private bool FilterPackageList(object item)
  {
    BuildAndSubmitCheckBoxListViewItem checkBoxListViewItem = (BuildAndSubmitCheckBoxListViewItem) item;
    return checkBoxListViewItem != null && (checkBoxListViewItem.SourceControlState == (ESourceControlState) 1 || checkBoxListViewItem.SourceControlState == (ESourceControlState) 4 && this.IncludeUnsourcedPackagesCheckBox.IsChecked.Value);
  }

  private unsafe void OKClicked(object Owner, RoutedEventArgs Args)
  {
    FEditorBuildUtils.FEditorAutomatedBuildSettings automatedBuildSettings;
    \u003CModule\u003E.FEditorBuildUtils\u002EFEditorAutomatedBuildSettings\u002E\u007Bctor\u007D(&automatedBuildSettings);
    // ISSUE: fault handler
    try
    {
      if (this.AddNotInDepotCheckBox.IsChecked.HasValue && (this.AddNotInDepotCheckBox.IsChecked.Value && this.AddNotInDepotCheckBox.IsEnabled))
      {
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        ^(int&) ((IntPtr) &automatedBuildSettings + 16) = 1;
      }
      else
      {
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        ^(int&) ((IntPtr) &automatedBuildSettings + 16) = 0;
      }
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      ^(int&) ((IntPtr) &automatedBuildSettings + 24) = 1;
      FEditorBuildUtils.EAutomatedBuildBehavior eautomatedBuildBehavior1 = !this.BuildErrorCheckBox.IsChecked.HasValue || !this.BuildErrorCheckBox.IsChecked.Value ? (FEditorBuildUtils.EAutomatedBuildBehavior) 2 : (FEditorBuildUtils.EAutomatedBuildBehavior) 1;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      ^(int&) ref automatedBuildSettings = (int) eautomatedBuildBehavior1;
      FEditorBuildUtils.EAutomatedBuildBehavior eautomatedBuildBehavior2 = !this.SaveErrorCheckBox.IsChecked.HasValue || !this.SaveErrorCheckBox.IsChecked.Value ? (FEditorBuildUtils.EAutomatedBuildBehavior) 2 : (FEditorBuildUtils.EAutomatedBuildBehavior) 1;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      ^(int&) ((IntPtr) &automatedBuildSettings + 12) = (int) eautomatedBuildBehavior2;
      foreach (BuildAndSubmitCheckBoxListViewItem checkBoxListViewItem in (IEnumerable) this.SubmitListView.Items)
      {
        if (checkBoxListViewItem.IsSelected)
        {
          FString fstring1;
          FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, checkBoxListViewItem.Text);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) &automatedBuildSettings + 28), fstring2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        }
      }
      FString fstring3;
      FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, this.ChangelistDescriptionTextBox.Text);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002E\u003D((FString*) ((IntPtr) &automatedBuildSettings + 52), fstring4);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      ^(int&) ((IntPtr) &automatedBuildSettings + 20) = 0;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      ^(long&) ((IntPtr) &automatedBuildSettings + 44) = (long) this.SCEventListener.Get();
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      ^(int&) ((IntPtr) &automatedBuildSettings + 8) = 0;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      ^(int&) ((IntPtr) &automatedBuildSettings + 4) = 0;
      FString fstring5;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring5);
      // ISSUE: fault handler
      try
      {
        if (\u003CModule\u003E.FEditorBuildUtils\u002EEditorAutomatedBuildAndSubmit(&automatedBuildSettings, &fstring5) != 0U)
          this.ParentFrame.Close(0);
        else if (\u003CModule\u003E.FString\u002ELen(&fstring5) > 0)
          this.DisplayErrorMessage(new string(\u003CModule\u003E.FString\u002E\u002A(&fstring5), 0, \u003CModule\u003E.FString\u002ELen(&fstring5)));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FEditorBuildUtils\u002EFEditorAutomatedBuildSettings\u002E\u007Bdtor\u007D), (void*) &automatedBuildSettings);
    }
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &automatedBuildSettings + 52));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) (ref automatedBuildSettings + 28L));
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D((TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) &automatedBuildSettings + 28));
  }

  private void CancelClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(0);

  private void DismissErrorPanelClicked(object Owner, RoutedEventArgs Args)
  {
    this.ErrorPanel.Visibility = Visibility.Collapsed;
    this.ErrorPanelTextBlock.Text = string.Empty;
  }

  private void IncludeUnsourcedPackagesClick(object Owner, RoutedEventArgs Args)
  {
    this.AddNotInDepotCheckBox.IsEnabled = this.IncludeUnsourcedPackagesCheckBox.IsChecked.Value;
    this.ListItemCollectionView.Refresh();
  }

  private void DisplayErrorMessage(string InErrorMsg)
  {
    this.ErrorPanel.Visibility = Visibility.Visible;
    this.ErrorPanelTextBlock.Text = InErrorMsg;
  }

  private unsafe void WarnOfHiddenLevels()
  {
    uint num = (uint) (\u003CModule\u003E.FLevelUtils\u002EIsLevelVisible((ULevel*) *(long*) ((IntPtr) \u003CModule\u003E.GWorld + 128L)) == 0U);
    this.bAnyLevelsHidden = num;
    if (num == 0U)
    {
      TIndexedContainerConstIterator\u003CTArray\u003CULevelStreaming\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CULevelStreaming\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, (TArray\u003CULevelStreaming\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) \u003CModule\u003E.UWorld\u002EGetWorldInfo(\u003CModule\u003E.GWorld, 0U) + 1096L));
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CULevelStreaming\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          ULevelStreaming* ulevelStreamingPtr = (ULevelStreaming*) *(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CULevelStreaming\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
          if ((IntPtr) ulevelStreamingPtr == IntPtr.Zero || \u003CModule\u003E.FLevelUtils\u002EIsLevelVisible(ulevelStreamingPtr) != 0U)
            \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CULevelStreaming\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
          else
            goto label_5;
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CULevelStreaming\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
        goto label_6;
label_5:
        this.bAnyLevelsHidden = 1U;
      }
    }
label_6:
    if (this.bAnyLevelsHidden == 0U)
      return;
    FString fstring;
    FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0CF\u0040OCDHJCPK\u0040BuildSubmitWindow_Error_HiddenLe\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
    // ISSUE: fault handler
    try
    {
      this.DisplayErrorMessage(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr)));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  private static void ColumnHeaderClicked(object Owner, RoutedEventArgs Args)
  {
    if (Args.OriginalSource.GetType() == typeof (CheckBox) && Owner.GetType() == typeof (ListView))
    {
      CheckBox originalSource = (CheckBox) Args.OriginalSource;
      ListView listView = (ListView) Owner;
      if (originalSource.Name.CompareTo("CheckAllCheckBox") == 0)
      {
        if (originalSource.IsChecked.HasValue && originalSource.IsChecked.Value)
        {
          foreach (BuildAndSubmitCheckBoxListViewItem checkBoxListViewItem in listView.ItemsSource)
          {
            if (checkBoxListViewItem.IsEnabled)
              checkBoxListViewItem.IsSelected = true;
          }
        }
        else
          listView.UnselectAll();
      }
    }
    else if (Args.OriginalSource.GetType() == typeof (GridViewColumnHeader) && Owner.GetType() == typeof (ListView))
    {
      ListView listView = (ListView) Owner;
      if (((FrameworkElement) Args.OriginalSource).Name.CompareTo("PackageNameHeader") == 0)
      {
        ICollectionView defaultView = CollectionViewSource.GetDefaultView((object) listView.ItemsSource);
        ListSortDirection direction = ListSortDirection.Descending;
        if (defaultView.SortDescriptions.Count > 0)
          direction = (ListSortDirection) (defaultView.SortDescriptions[0].Direction == ListSortDirection.Ascending);
        defaultView.SortDescriptions.Clear();
        SortDescription sortDescription = new SortDescription("Text", direction);
        defaultView.SortDescriptions.Add(sortDescription);
        defaultView.Refresh();
      }
    }
    Args.Handled = true;
  }
}
