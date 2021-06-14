// Decompiled with JetBrains decompiler
// Type: MHistoryFileListViewItem
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Collections.ObjectModel;

internal class MHistoryFileListViewItem
{
  private string \u003Cbacking_store\u003EFileName;
  private ObservableCollection<MHistoryRevisionListViewItem> \u003Cbacking_store\u003EFileRevisions;

  public string FileName
  {
    get => this.\u003Cbacking_store\u003EFileName;
    set => this.\u003Cbacking_store\u003EFileName = value;
  }

  public ObservableCollection<MHistoryRevisionListViewItem> FileRevisions
  {
    get => this.\u003Cbacking_store\u003EFileRevisions;
    set => this.\u003Cbacking_store\u003EFileRevisions = value;
  }

  public unsafe MHistoryFileListViewItem(
    FSourceControl.FSourceControlFileHistoryInfo* InHistoryInfo)
  {
    FString* fstringPtr = (FString*) ((IntPtr) InHistoryInfo + 16L);
    this.\u003Cbacking_store\u003EFileName = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
    this.\u003Cbacking_store\u003EFileRevisions = new ObservableCollection<MHistoryRevisionListViewItem>();
    TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileRevisionInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
    \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileRevisionInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, (TArray\u003CFSourceControl\u003A\u003AFSourceControlFileRevisionInfo\u002CFDefaultAllocator\u003E*) InHistoryInfo);
    if (!\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileRevisionInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      return;
    do
    {
      this.\u003Cbacking_store\u003EFileRevisions.Add(new MHistoryRevisionListViewItem(\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileRevisionInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt)));
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileRevisionInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
    }
    while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSourceControl\u003A\u003AFSourceControlFileRevisionInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
  }
}
