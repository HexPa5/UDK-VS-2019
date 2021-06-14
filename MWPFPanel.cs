// Decompiled with JetBrains decompiler
// Type: MWPFPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

internal class MWPFPanel : ContentControl, INotifyPropertyChanged
{
  protected MWPFFrame ParentFrame;

  public unsafe MWPFPanel(string XamlFileName)
  {
    FString fstring;
    FString* editorResourcesDir = \u003CModule\u003E.GetEditorResourcesDir(&fstring);
    string XamlFileName1;
    // ISSUE: fault handler
    try
    {
      XamlFileName1 = string.Format("{0}WPF\\Controls\\{1}", (object) new string(\u003CModule\u003E.FString\u002E\u002A(editorResourcesDir), 0, \u003CModule\u003E.FString\u002ELen(editorResourcesDir)), (object) XamlFileName);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
    this.Content = (object) (UIElement) \u003CModule\u003E.CLRTools\u002ECreateVisualFromXaml(XamlFileName1);
    this.ParentFrame = (MWPFFrame) null;
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

  public virtual void SetParentFrame(MWPFFrame InParentFrame) => this.ParentFrame = InParentFrame;

  public MWPFFrame GetParentFrame() => this.ParentFrame;

  public virtual void PostLayout()
  {
  }

  public void RefreshAllProperties() => this.OnPropertyChanged((string) null);

  public virtual void OnPropertyChanged(string Info)
  {
    MWPFPanel mwpfPanel = this;
    mwpfPanel.raise_PropertyChanged((object) mwpfPanel, new PropertyChangedEventArgs(Info));
  }
}
