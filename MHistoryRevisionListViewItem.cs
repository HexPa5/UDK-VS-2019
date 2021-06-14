// Decompiled with JetBrains decompiler
// Type: MHistoryRevisionListViewItem
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class MHistoryRevisionListViewItem : INotifyPropertyChanged
{
  private string \u003Cbacking_store\u003EDescription;
  private string \u003Cbacking_store\u003EUserName;
  private string \u003Cbacking_store\u003EClientSpec;
  private string \u003Cbacking_store\u003EAction;
  private DateTime \u003Cbacking_store\u003EDate;
  private int \u003Cbacking_store\u003ERevisionNumber;
  private int \u003Cbacking_store\u003EChangelistNumber;
  private int \u003Cbacking_store\u003EFileSize;
  private bool IsSelectedValue;

  public string Description
  {
    get => this.\u003Cbacking_store\u003EDescription;
    set => this.\u003Cbacking_store\u003EDescription = value;
  }

  public string UserName
  {
    get => this.\u003Cbacking_store\u003EUserName;
    set => this.\u003Cbacking_store\u003EUserName = value;
  }

  public string ClientSpec
  {
    get => this.\u003Cbacking_store\u003EClientSpec;
    set => this.\u003Cbacking_store\u003EClientSpec = value;
  }

  public string Action
  {
    get => this.\u003Cbacking_store\u003EAction;
    set => this.\u003Cbacking_store\u003EAction = value;
  }

  public DateTime Date
  {
    get => this.\u003Cbacking_store\u003EDate;
    set => this.\u003Cbacking_store\u003EDate = value;
  }

  public int RevisionNumber
  {
    get => this.\u003Cbacking_store\u003ERevisionNumber;
    set => this.\u003Cbacking_store\u003ERevisionNumber = value;
  }

  public int ChangelistNumber
  {
    get => this.\u003Cbacking_store\u003EChangelistNumber;
    set => this.\u003Cbacking_store\u003EChangelistNumber = value;
  }

  public int FileSize
  {
    get => this.\u003Cbacking_store\u003EFileSize;
    set => this.\u003Cbacking_store\u003EFileSize = value;
  }

  public bool IsSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.IsSelectedValue;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (this.IsSelectedValue == value)
        return;
      this.IsSelectedValue = value;
      this.OnPropertyChanged(nameof (IsSelected));
    }
  }

  public unsafe MHistoryRevisionListViewItem(
    FSourceControl.FSourceControlFileRevisionInfo* InRevisionInfo)
  {
    this.\u003Cbacking_store\u003EDescription = new string(\u003CModule\u003E.FString\u002E\u002A((FString*) InRevisionInfo), 0, \u003CModule\u003E.FString\u002ELen((FString*) InRevisionInfo));
    FString* fstringPtr1 = (FString*) ((IntPtr) InRevisionInfo + 16L);
    this.\u003Cbacking_store\u003EUserName = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr1), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr1));
    FString* fstringPtr2 = (FString*) ((IntPtr) InRevisionInfo + 32L);
    this.\u003Cbacking_store\u003EClientSpec = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr2), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr2));
    FString* fstringPtr3 = (FString*) ((IntPtr) InRevisionInfo + 48L);
    this.\u003Cbacking_store\u003EAction = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr3), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr3));
    this.\u003Cbacking_store\u003EDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds((double) *(int*) ((IntPtr) InRevisionInfo + 64L)).ToLocalTime();
    this.\u003Cbacking_store\u003ERevisionNumber = *(int*) ((IntPtr) InRevisionInfo + 68L);
    this.\u003Cbacking_store\u003EChangelistNumber = *(int*) ((IntPtr) InRevisionInfo + 72L);
    this.\u003Cbacking_store\u003EFileSize = *(int*) ((IntPtr) InRevisionInfo + 76L);
    if (!this.IsSelectedValue)
      return;
    this.IsSelectedValue = false;
    this.OnPropertyChanged(nameof (IsSelected));
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

  public virtual void OnPropertyChanged(string Info)
  {
    MHistoryRevisionListViewItem revisionListViewItem = this;
    revisionListViewItem.raise_PropertyChanged((object) revisionListViewItem, new PropertyChangedEventArgs(Info));
  }
}
