// Decompiled with JetBrains decompiler
// Type: MSourceControlRevertPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

internal class MSourceControlRevertPanel : MWPFPanel
{
  private uint bAlreadyQueriedModifiedFiles = 0;
  private CheckBox RevertUnchangedCheckBox;
  private ListView RevertListView;
  private ObservableCollection<RevertCheckBoxListViewItem> ListViewItemSource;
  private List<string> ModifiedPackages;

  public unsafe MSourceControlRevertPanel(
    string InXamlName,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* InPackageNames)
    : base(InXamlName)
  {
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "OKButton")).Click += new RoutedEventHandler(this.OKClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CancelButton")).Click += new RoutedEventHandler(this.CancelClicked);
    MSourceControlRevertPanel controlRevertPanel1 = this;
    controlRevertPanel1.RevertUnchangedCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) controlRevertPanel1, nameof (RevertUnchangedCheckBox));
    this.RevertUnchangedCheckBox.Checked += new RoutedEventHandler(this.RevertUnchangedToggled);
    this.RevertUnchangedCheckBox.Unchecked += new RoutedEventHandler(this.RevertUnchangedToggled);
    MSourceControlRevertPanel controlRevertPanel2 = this;
    controlRevertPanel2.RevertListView = (ListView) LogicalTreeHelper.FindLogicalNode((DependencyObject) controlRevertPanel2, nameof (RevertListView));
    this.RevertListView.AddHandler(ButtonBase.ClickEvent, (Delegate) new RoutedEventHandler(MSourceControlRevertPanel.ColumnHeaderClicked));
    this.ListViewItemSource = new ObservableCollection<RevertCheckBoxListViewItem>();
    TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
    \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, InPackageNames);
    if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
    {
      do
      {
        FString* fstringPtr = \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
        this.ListViewItemSource.Add(new RevertCheckBoxListViewItem(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr))));
        \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
      }
      while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
    }
    this.RevertListView.ItemsSource = (IEnumerable) this.ListViewItemSource;
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.CancelClicked);
  }

  public unsafe void GetPackagesToRevert(
    TArray\u003CFString\u002CFDefaultAllocator\u003E* OutPackagesToRevert)
  {
    foreach (RevertCheckBoxListViewItem selectedItem in (IEnumerable) this.RevertListView.SelectedItems)
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, selectedItem.Text);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(OutPackagesToRevert, fstring2);
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

  private void OKClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(0);

  private void CancelClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(1);

  private unsafe void RevertUnchangedToggled(object Owner, RoutedEventArgs Args)
  {
    uint num1;
    if (this.RevertUnchangedCheckBox.IsChecked.HasValue && this.RevertUnchangedCheckBox.IsChecked.Value)
    {
      num1 = 1U;
      if (this.bAlreadyQueriedModifiedFiles == 0U)
      {
        TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator1;
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
        // ISSUE: fault handler
        try
        {
          foreach (RevertCheckBoxListViewItem checkBoxListViewItem in (Collection<RevertCheckBoxListViewItem>) this.ListViewItemSource)
          {
            FString fstring1;
            FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, checkBoxListViewItem.Text);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator1, fstring2);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          }
          \u003CModule\u003E.FSourceControl\u002EConvertPackageNamesToSourceControlPaths(&fdefaultAllocator1);
          TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
          // ISSUE: fault handler
          try
          {
            int modifiedFromServer = (int) \u003CModule\u003E.FSourceControl\u002EGetFilesModifiedFromServer((FSourceControlEventListener*) 0L, &fdefaultAllocator1, &fdefaultAllocator2);
            this.ModifiedPackages = \u003CModule\u003E.CLRTools\u002EToStringArray(&fdefaultAllocator2);
            this.bAlreadyQueriedModifiedFiles = 1U;
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
          }
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
        }
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
      }
    }
    else
      num1 = 0U;
    foreach (RevertCheckBoxListViewItem checkBoxListViewItem in (Collection<RevertCheckBoxListViewItem>) this.ListViewItemSource)
    {
      uint num2 = 0;
      for (int index = 0; index < this.ModifiedPackages.Count; ++index)
      {
        if (checkBoxListViewItem.Text.CompareTo(this.ModifiedPackages[index]) == 0)
          goto label_27;
      }
      if (num2 == 0U)
        goto label_29;
label_27:
      byte num3;
      if (num1 != 0U)
      {
        num3 = (byte) 0;
        goto label_30;
      }
label_29:
      num3 = (byte) 1;
label_30:
      checkBoxListViewItem.IsEnabled = (bool) num3;
      int num4 = !checkBoxListViewItem.IsEnabled ? 0 : (checkBoxListViewItem.IsSelected ? 1 : 0);
      checkBoxListViewItem.IsSelected = num4 != 0;
    }
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
          foreach (RevertCheckBoxListViewItem checkBoxListViewItem in listView.ItemsSource)
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
