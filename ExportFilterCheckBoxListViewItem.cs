// Decompiled with JetBrains decompiler
// Type: ExportFilterCheckBoxListViewItem
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class ExportFilterCheckBoxListViewItem : INotifyPropertyChanged
{
  private string TextValue;
  private bool SelectedValue;

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

  public bool Selected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.SelectedValue;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (this.SelectedValue == value)
        return;
      this.SelectedValue = value;
      this.OnPropertyChanged(nameof (Selected));
    }
  }

  public ExportFilterCheckBoxListViewItem(string InText)
  {
    if (this.TextValue != InText)
    {
      this.TextValue = InText;
      this.OnPropertyChanged(nameof (Text));
    }
    if (!this.SelectedValue)
      return;
    this.SelectedValue = false;
    this.OnPropertyChanged(nameof (Selected));
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
    ExportFilterCheckBoxListViewItem checkBoxListViewItem = this;
    checkBoxListViewItem.raise_PropertyChanged((object) checkBoxListViewItem, new PropertyChangedEventArgs(Info));
  }
}
