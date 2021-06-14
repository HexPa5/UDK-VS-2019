// Decompiled with JetBrains decompiler
// Type: MEnumerableTArrayWrapper<MTemplateTargetListWrapper,FTemplateTargetListInfo>
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class MEnumerableTArrayWrapper\u003CMTemplateTargetListWrapper\u002CFTemplateTargetListInfo\u003E : 
  IEnumerable,
  INotifyCollectionChanged,
  INotifyPropertyChanged
{
  private unsafe TArray\u003CFTemplateTargetListInfo\u002CFDefaultAllocator\u003E* ArrayPtr;

  public virtual event NotifyCollectionChangedEventHandler CollectionChanged;

  [SpecialName]
  protected virtual void raise_CollectionChanged(
    object value0,
    NotifyCollectionChangedEventArgs value1)
  {
    NotifyCollectionChangedEventHandler collectionChanged = this.\u003Cbacking_store\u003ECollectionChanged;
    if (collectionChanged == null)
      return;
    collectionChanged(value0, value1);
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

  public unsafe MEnumerableTArrayWrapper\u003CMTemplateTargetListWrapper\u002CFTemplateTargetListInfo\u003E(
    TArray\u003CFTemplateTargetListInfo\u002CFDefaultAllocator\u003E* InArrayPtr)
  {
    this.ArrayPtr = InArrayPtr;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public unsafe IEnumerator GetEnumerator()
  {
    MEnumerableTArrayWrapper\u003CMTemplateTargetListWrapper\u002CFTemplateTargetListInfo\u003E InParent = this;
    return (IEnumerator) new MEnumerableTArrayWrapper\u003CMTemplateTargetListWrapper\u002CFTemplateTargetListInfo\u003E.MTArrayEnumerator(InParent, InParent.ArrayPtr);
  }

  public void NotifyChanged()
  {
    MEnumerableTArrayWrapper\u003CMTemplateTargetListWrapper\u002CFTemplateTargetListInfo\u003E ftemplateTargetListInfo = this;
    ftemplateTargetListInfo.raise_CollectionChanged((object) ftemplateTargetListInfo, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
  }

  public void OnItemPropertyChanged(object Owner, PropertyChangedEventArgs Args) => this.raise_PropertyChanged(Owner, Args);

  private class MTArrayEnumerator : IEnumerator
  {
    public unsafe TArray\u003CFTemplateTargetListInfo\u002CFDefaultAllocator\u003E* ArrayPtr;
    public int Pos;
    public MEnumerableTArrayWrapper\u003CMTemplateTargetListWrapper\u002CFTemplateTargetListInfo\u003E Parent;

    public unsafe MTArrayEnumerator(
      MEnumerableTArrayWrapper\u003CMTemplateTargetListWrapper\u002CFTemplateTargetListInfo\u003E InParent,
      TArray\u003CFTemplateTargetListInfo\u002CFDefaultAllocator\u003E* InArrayPtr)
    {
      this.ArrayPtr = InArrayPtr;
      this.Pos = -1;
      this.Parent = InParent;
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }

    [return: MarshalAs(UnmanagedType.U1)]
    public virtual unsafe bool MoveNext()
    {
      int pos = this.Pos;
      if (pos >= \u003CModule\u003E.TArray\u003CFTemplateTargetListInfo\u002CFDefaultAllocator\u003E\u002ENum(this.ArrayPtr) - 1)
        return false;
      this.Pos = pos + 1;
      return true;
    }

    public virtual void Reset() => this.Pos = -1;

    public unsafe object Current
    {
      get
      {
        MTemplateTargetListWrapper targetListWrapper = new MTemplateTargetListWrapper(this.Pos, \u003CModule\u003E.TArray\u003CFTemplateTargetListInfo\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(this.ArrayPtr, this.Pos));
        targetListWrapper.PropertyChanged += new PropertyChangedEventHandler(this.Parent.OnItemPropertyChanged);
        return (object) targetListWrapper;
      }
    }
  }
}
