// Decompiled with JetBrains decompiler
// Type: MSourceControlHistoryPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

internal class MSourceControlHistoryPanel : MWPFPanel
{
  private ListView MainHistoryListView;
  private ItemsControl AdditionalInfoItemsControl;
  private ObservableCollection<MHistoryFileListViewItem> HistoryCollection;
  private ObservableCollection<MHistoryRevisionListViewItem> LastSelectedRevisionItem = (ObservableCollection<MHistoryRevisionListViewItem>) null;

  public unsafe MSourceControlHistoryPanel(
    string InXamlName,
    TArray\u003CFSourceControl\u003A\u003AFSourceControlFileHistoryInfo\u002CFDefaultAllocator\u003E* InHistoryInfo)
    : base(InXamlName)
  {
    MSourceControlHistoryPanel controlHistoryPanel1 = this;
    controlHistoryPanel1.MainHistoryListView = (ListView) LogicalTreeHelper.FindLogicalNode((DependencyObject) controlHistoryPanel1, nameof (MainHistoryListView));
    this.HistoryCollection = new ObservableCollection<MHistoryFileListViewItem>();
    TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileHistoryInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
    \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileHistoryInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, InHistoryInfo);
    if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileHistoryInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
    {
      do
      {
        this.HistoryCollection.Add(new MHistoryFileListViewItem(\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileHistoryInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt)));
        \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileHistoryInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
      }
      while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileHistoryInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
    }
    IEnumerator<MHistoryFileListViewItem> enumerator1 = this.HistoryCollection.GetEnumerator();
label_3:
    try
    {
      while (enumerator1.MoveNext())
      {
        using (IEnumerator<MHistoryRevisionListViewItem> enumerator2 = enumerator1.Current.FileRevisions.GetEnumerator())
        {
          while (true)
          {
            if (enumerator2.MoveNext())
              enumerator2.Current.PropertyChanged += new PropertyChangedEventHandler(this.OnRevisionPropertyChanged);
            else
              goto label_3;
          }
        }
      }
    }
    finally
    {
      enumerator1?.Dispose();
    }
    this.MainHistoryListView.ItemsSource = (IEnumerable) this.HistoryCollection;
    MSourceControlHistoryPanel controlHistoryPanel2 = this;
    controlHistoryPanel2.AdditionalInfoItemsControl = (ItemsControl) LogicalTreeHelper.FindLogicalNode((DependencyObject) controlHistoryPanel2, nameof (AdditionalInfoItemsControl));
    ObservableCollection<MHistoryRevisionListViewItem> observableCollection = new ObservableCollection<MHistoryRevisionListViewItem>();
    this.LastSelectedRevisionItem = observableCollection;
    this.AdditionalInfoItemsControl.ItemsSource = (IEnumerable) observableCollection;
  }

  private void OnRevisionPropertyChanged(object Owner, PropertyChangedEventArgs Args)
  {
    MHistoryRevisionListViewItem revisionListViewItem = (MHistoryRevisionListViewItem) Owner;
    if (!revisionListViewItem.IsSelected || string.Compare(Args.PropertyName, "IsSelected") != 0)
      return;
    if (this.LastSelectedRevisionItem.Count > 0)
      this.LastSelectedRevisionItem[0].IsSelected = false;
    this.LastSelectedRevisionItem.Clear();
    this.LastSelectedRevisionItem.Add(revisionListViewItem);
  }
}
