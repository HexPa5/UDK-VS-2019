// Decompiled with JetBrains decompiler
// Type: MSourceControlSubmitPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using CustomControls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

internal class MSourceControlSubmitPanel : MWPFPanel
{
  private Button OKButton;
  private TextBox ChangeListDescriptionTextCtrl;
  private ListView FileListView;
  private List<CheckBox> AllChecks;
  private InfoPanel WarningPanel;

  public unsafe MSourceControlSubmitPanel(
    string InXamlName,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* InAddFiles,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* InOpenFiles)
    : base(InXamlName)
  {
    MSourceControlSubmitPanel controlSubmitPanel1 = this;
    controlSubmitPanel1.OKButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) controlSubmitPanel1, nameof (OKButton));
    this.OKButton.Click += new RoutedEventHandler(this.OKClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CancelButton")).Click += new RoutedEventHandler(this.CancelClicked);
    MSourceControlSubmitPanel controlSubmitPanel2 = this;
    controlSubmitPanel2.ChangeListDescriptionTextCtrl = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) controlSubmitPanel2, "ChangeListDescription");
    this.ChangeListDescriptionTextCtrl.TextChanged += new TextChangedEventHandler(this.OnDescriptionTextChanged);
    MSourceControlSubmitPanel controlSubmitPanel3 = this;
    controlSubmitPanel3.WarningPanel = (InfoPanel) LogicalTreeHelper.FindLogicalNode((DependencyObject) controlSubmitPanel3, "mInvalidDescriptionWarning");
    this.UpdateValidity();
    this.AllChecks = new List<CheckBox>();
    MSourceControlSubmitPanel controlSubmitPanel4 = this;
    controlSubmitPanel4.FileListView = (ListView) LogicalTreeHelper.FindLogicalNode((DependencyObject) controlSubmitPanel4, nameof (FileListView));
    int num1 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InAddFiles))
    {
      do
      {
        this.AddFileToListView(\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InAddFiles, num1));
        ++num1;
      }
      while (num1 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InAddFiles));
    }
    int num2 = 0;
    if (0 >= \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InOpenFiles))
      return;
    do
    {
      this.AddFileToListView(\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InOpenFiles, num2));
      ++num2;
    }
    while (num2 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InOpenFiles));
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.CancelClicked);
  }

  public unsafe void FillChangeListDescription(
    FChangeListDescription* OutDesc,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* InAddFiles,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* InOpenFiles)
  {
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.ChangeListDescriptionTextCtrl.Text);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u003D((FString*) ((IntPtr) OutDesc + 32L), fstring2);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    int index = 0;
    if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InAddFiles))
    {
      do
      {
        if ((bool) this.AllChecks[index].IsChecked)
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) OutDesc, \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InAddFiles, index));
        ++index;
      }
      while (index < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InAddFiles));
    }
    int num = 0;
    if (0 >= \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InOpenFiles))
      return;
    do
    {
      if ((bool) this.AllChecks[\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InAddFiles) + num].IsChecked)
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) OutDesc + 16L), \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InOpenFiles, num));
      ++num;
    }
    while (num < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InOpenFiles));
  }

  private void OKClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(0);

  private void CancelClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(1);

  private void OnDescriptionTextChanged(object Owner, TextChangedEventArgs Args) => this.UpdateValidity();

  private unsafe void UpdateValidity()
  {
    bool flag = this.ChangeListDescriptionTextCtrl.Text.Length > 0;
    this.OKButton.IsEnabled = flag;
    if (flag)
    {
      this.WarningPanel.Hide();
    }
    else
    {
      FString fstring1;
      FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring1, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0CP\u0040EKIELBLP\u0040SourceControlSubmit_DescriptionV\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
      string str;
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
        // ISSUE: fault handler
        try
        {
          str = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      this.WarningPanel.SetWarningText(str);
      this.WarningPanel.Show();
    }
  }

  private unsafe void AddFileToListView(FString* InFileName)
  {
    DockPanel dockPanel = new DockPanel();
    this.FileListView.Items.Add((object) dockPanel);
    CheckBox checkBox = new CheckBox();
    bool? nullable = (bool?) true;
    checkBox.IsChecked = nullable;
    dockPanel.Children.Add((UIElement) checkBox);
    dockPanel.Children.Add((UIElement) new TextBlock()
    {
      Text = new string(\u003CModule\u003E.FString\u002E\u002A(InFileName), 0, \u003CModule\u003E.FString\u002ELen(InFileName))
    });
    this.AllChecks.Add(checkBox);
  }
}
