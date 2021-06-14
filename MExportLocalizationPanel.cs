// Decompiled with JetBrains decompiler
// Type: MExportLocalizationPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using ExportLocalizationWindow;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

internal class MExportLocalizationPanel : MWPFPanel
{
  private Button OKButton;
  private CheckBox ExportBinariesCheckBox;
  private CheckBox CompareDiffsCheckBox;
  private TextBox ExportPathTextBox;
  private RadioButton NoFilteringRadioButton;
  private RadioButton MatchAnyRadioButton;
  private RadioButton MatchAllRadioButton;
  private ListView FilterTagsListView;
  private unsafe FExportLocalizationOptions* OptionsToPopulate;
  private ObservableCollection<ExportFilterCheckBoxListViewItem> ListViewItemSource;

  public unsafe MExportLocalizationPanel(string InXamlName, FExportLocalizationOptions* OutOptions)
  {
    this.OptionsToPopulate = OutOptions;
    // ISSUE: explicit constructor call
    base.\u002Ector(InXamlName);
    MExportLocalizationPanel localizationPanel1 = this;
    localizationPanel1.OKButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) localizationPanel1, nameof (OKButton));
    this.OKButton.Click += new RoutedEventHandler(this.OKClicked);
    this.OKButton.IsEnabled = false;
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CancelButton")).Click += new RoutedEventHandler(this.CancelClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "BrowseButton")).Click += new RoutedEventHandler(this.BrowseClicked);
    MExportLocalizationPanel localizationPanel2 = this;
    localizationPanel2.ExportBinariesCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) localizationPanel2, nameof (ExportBinariesCheckBox));
    MExportLocalizationPanel localizationPanel3 = this;
    localizationPanel3.CompareDiffsCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) localizationPanel3, nameof (CompareDiffsCheckBox));
    MExportLocalizationPanel localizationPanel4 = this;
    localizationPanel4.ExportPathTextBox = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) localizationPanel4, nameof (ExportPathTextBox));
    this.ExportPathTextBox.TextChanged += new TextChangedEventHandler(this.ExportPathChanged);
    MExportLocalizationPanel localizationPanel5 = this;
    localizationPanel5.FilterTagsListView = (ListView) LogicalTreeHelper.FindLogicalNode((DependencyObject) localizationPanel5, nameof (FilterTagsListView));
    MExportLocalizationPanel localizationPanel6 = this;
    localizationPanel6.NoFilteringRadioButton = (RadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) localizationPanel6, nameof (NoFilteringRadioButton));
    this.NoFilteringRadioButton.IsChecked = (bool?) true;
    MExportLocalizationPanel localizationPanel7 = this;
    localizationPanel7.MatchAnyRadioButton = (RadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) localizationPanel7, nameof (MatchAnyRadioButton));
    MExportLocalizationPanel localizationPanel8 = this;
    localizationPanel8.MatchAllRadioButton = (RadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) localizationPanel8, nameof (MatchAllRadioButton));
    this.ListViewItemSource = new ObservableCollection<ExportFilterCheckBoxListViewItem>();
    this.InitializeFilter();
    this.FilterTagsListView.ItemsSource = (IEnumerable) this.ListViewItemSource;
    this.PromptForDirectory();
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.CancelClicked);
  }

  private void OKClicked(object Owner, RoutedEventArgs Args)
  {
    this.PopulateOptions();
    this.ParentFrame.Close(0);
  }

  private void CancelClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(1);

  private void BrowseClicked(object Owner, RoutedEventArgs Args) => this.PromptForDirectory();

  private void ExportPathChanged(object Owner, TextChangedEventArgs Args) => this.OKButton.IsEnabled = Directory.Exists(this.ExportPathTextBox.Text);

  private unsafe void PromptForDirectory()
  {
    wxString wxString1;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, (char*) ^(long&) ref \u003CModule\u003E.__imp_wxDirDialogNameStr);
    wxDirDialog wxDirDialog;
    // ISSUE: fault handler
    try
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.ExportPathTextBox.Text);
      // ISSUE: fault handler
      try
      {
        wxString wxString2;
        \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, \u003CModule\u003E.FString\u002E\u002A(fstring2));
        // ISSUE: fault handler
        try
        {
          FString fstring3;
          FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BB\u0040GPNJFID\u0040ChooseADirectory\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
          // ISSUE: fault handler
          try
          {
            wxString wxString3;
            \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString3, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
            // ISSUE: fault handler
            try
            {
              // ISSUE: cast to a reference type
              // ISSUE: explicit reference operation
              // ISSUE: cast to a reference type
              // ISSUE: explicit reference operation
              \u003CModule\u003E.wxDirDialog\u002E\u007Bctor\u007D(&wxDirDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString3, &wxString2, 536877120, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition, (wxSize*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultSize, &wxString1);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString3);
            }
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString3);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxDirDialog\u002E\u007Bdtor\u007D), (void*) &wxDirDialog);
            }
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxDirDialog\u002E\u007Bdtor\u007D), (void*) &wxDirDialog);
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString2);
        }
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxDirDialog\u002E\u007Bdtor\u007D), (void*) &wxDirDialog);
        }
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxDirDialog\u002E\u007Bdtor\u007D), (void*) &wxDirDialog);
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString1);
    }
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString1);
      ref wxDirDialog local1 = ref wxDirDialog;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      if (__calli((__FnPtr<int (IntPtr)>) *(long*) (^(long&) ref wxDirDialog + 1528L))((IntPtr) ref local1) == 5100)
      {
        ref wxDirDialog local2 = ref wxDirDialog;
        wxString wxString2;
        ref wxString local3 = ref wxString2;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        long num = (long) __calli((__FnPtr<wxString* (IntPtr, wxString*)>) *(long*) (^(long&) ref wxDirDialog + 1600L))((wxString*) ref local2, (IntPtr) ref local3);
        // ISSUE: fault handler
        try
        {
          FString fstring;
          FString* fstringPtr = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, \u003CModule\u003E.wxString\u002E\u002EPEB_W((wxString*) num));
          // ISSUE: fault handler
          try
          {
            this.ExportPathTextBox.Text = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString2);
        }
        \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString2);
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxDirDialog\u002E\u007Bdtor\u007D), (void*) &wxDirDialog);
    }
    \u003CModule\u003E.wxDirDialog\u002E\u007Bdtor\u007D(&wxDirDialog);
  }

  private unsafe void InitializeFilter()
  {
    if ((IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA == IntPtr.Zero)
      return;
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    List<string> OutTags1 = (List<string>) null;
    \u003CModule\u003E.FGameAssetDatabase\u002EQueryAllTags(database0PeaV1Ea, out OutTags1, (ETagQueryOptions.Type) 2);
    List<string> OutTags2 = (List<string>) null;
    \u003CModule\u003E.FGameAssetDatabase\u002EQueryAllTags(database0PeaV1Ea, out OutTags2, (ETagQueryOptions.Type) 3);
    List<string> stringList = new List<string>((IEnumerable<string>) OutTags1);
    List<string>.Enumerator enumerator1 = OutTags2.GetEnumerator();
    if (enumerator1.MoveNext())
    {
      do
      {
        string current = enumerator1.Current;
        if ((current.Length <= 0 || current[0] != '[' || \u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagType(current) != ESystemTagType.PrivateCollection ? 0 : 1) == 0 || \u003CModule\u003E.FGameAssetDatabase\u002EIsMyPrivateCollection(current))
          stringList.Add(current);
      }
      while (enumerator1.MoveNext());
    }
    stringList.Sort();
    List<string>.Enumerator enumerator2 = stringList.GetEnumerator();
    if (!enumerator2.MoveNext())
      return;
    do
    {
      this.ListViewItemSource.Add(new ExportFilterCheckBoxListViewItem(enumerator2.Current));
    }
    while (enumerator2.MoveNext());
  }

  private unsafe void PopulateOptions()
  {
    *(int*) ((IntPtr) this.OptionsToPopulate + 36L) = !this.ExportBinariesCheckBox.IsChecked.HasValue ? 0 : (this.ExportBinariesCheckBox.IsChecked.Value ? 1 : 0);
    *(int*) ((IntPtr) this.OptionsToPopulate + 40L) = !this.CompareDiffsCheckBox.IsChecked.HasValue ? 0 : (this.CompareDiffsCheckBox.IsChecked.Value ? 1 : 0);
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.ExportPathTextBox.Text);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u003D((FString*) ((IntPtr) this.OptionsToPopulate + 20L), fstring2);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    FLocalizationExportFilter.ETagFilterType etagFilterType = (FLocalizationExportFilter.ETagFilterType) 2;
    if (this.MatchAllRadioButton.IsChecked.HasValue && this.MatchAllRadioButton.IsChecked.Value)
      etagFilterType = (FLocalizationExportFilter.ETagFilterType) 1;
    else if (this.MatchAnyRadioButton.IsChecked.HasValue)
      etagFilterType = this.MatchAnyRadioButton.IsChecked.Value ? (FLocalizationExportFilter.ETagFilterType) 0 : etagFilterType;
    \u003CModule\u003E.FLocalizationExportFilter\u002ESetTagFilterType((FLocalizationExportFilter*) this.OptionsToPopulate, etagFilterType);
    TArray\u003CFString\u002CFDefaultAllocator\u003E* filterTags = \u003CModule\u003E.FLocalizationExportFilter\u002EGetFilterTags((FLocalizationExportFilter*) this.OptionsToPopulate);
    foreach (ExportFilterCheckBoxListViewItem checkBoxListViewItem in (Collection<ExportFilterCheckBoxListViewItem>) this.ListViewItemSource)
    {
      if (checkBoxListViewItem.Selected)
      {
        FString fstring3;
        FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, checkBoxListViewItem.Text);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(filterTags, fstring4);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      }
    }
  }
}
