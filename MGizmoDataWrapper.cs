// Decompiled with JetBrains decompiler
// Type: MGizmoDataWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

internal class MGizmoDataWrapper : INotifyPropertyChanged
{
  private int index;
  private unsafe FGizmoData* data;
  private BitmapSource bitmap;

  public unsafe MGizmoDataWrapper(int InIndex, FGizmoData* InData)
  {
    this.index = InIndex;
    this.data = InData;
    // ISSUE: explicit constructor call
    base.\u002Ector();
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

  public int Index => this.index;
}
