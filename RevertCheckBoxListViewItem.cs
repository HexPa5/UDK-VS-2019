// Decompiled with JetBrains decompiler
// Type: RevertCheckBoxListViewItem
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class RevertCheckBoxListViewItem : INotifyPropertyChanged
{
  private string TextValue;
  private bool IsEnabledValue;
  private bool IsSelectedValue;

  public string Text
  {
    get => this.TextValue;
    set
    {
      if (!(this.TextValue != value))
        return;
      this.TextValue = value;
      this.OnPropertyChanged(nameof (Text));
    }
  }

  public bool IsEnabled
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.IsEnabledValue;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (this.IsEnabledValue == value)
        return;
      this.IsEnabledValue = value;
      this.OnPropertyChanged(nameof (IsEnabled));
    }
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

  public RevertCheckBoxListViewItem(string InText)
  {
    if (this.TextValue != InText)
    {
      this.TextValue = InText;
      this.OnPropertyChanged(nameof (Text));
    }
    if (!this.IsEnabledValue)
    {
      this.IsEnabledValue = true;
      this.OnPropertyChanged(nameof (IsEnabled));
    }
    if (!this.IsSelectedValue)
      return;
    this.IsSelectedValue = false;
    this.OnPropertyChanged(nameof (IsSelected));
  }

  public override string ToString() => this.TextValue;

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
    RevertCheckBoxListViewItem checkBoxListViewItem = this;
    checkBoxListViewItem.raise_PropertyChanged((object) checkBoxListViewItem, new PropertyChangedEventArgs(Info));
  }
}
