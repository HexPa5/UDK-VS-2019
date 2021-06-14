// Decompiled with JetBrains decompiler
// Type: MNewProjectPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using UnrealEd;

internal class MNewProjectPanel : MWPFPanel
{
  private TabControl NavigationTabControl;
  private unsafe FNewUDKProjectWizard* \u003Cbacking_store\u003EProjWizSystem;
  private uint \u003Cbacking_store\u003EShowSuccessScreen;
  public ComboBox TemplateTargetComboBox;
  public Button YesButton;
  public Button NoButton;
  public Button CloseWindowButton;
  public Button FinishButton;
  public Button NextPanelButton;
  public Button PrevPanelButton;
  public MEnumerableTArrayWrapper\u003CMTemplateTargetListWrapper\u002CFTemplateTargetListInfo\u003E TemplateTargetList;
  public MEnumerableTArrayWrapper\u003CMProjectSettingsListWrapper\u002CFUserProjectSettingsListInfo\u003E UserSettingsList;

  public unsafe FNewUDKProjectWizard* ProjWizSystem
  {
    get => this.\u003Cbacking_store\u003EProjWizSystem;
    set => this.\u003Cbacking_store\u003EProjWizSystem = value;
  }

  public uint ShowSuccessScreen
  {
    get => this.\u003Cbacking_store\u003EShowSuccessScreen;
    set => this.\u003Cbacking_store\u003EShowSuccessScreen = value;
  }

  public unsafe string ProjectNameSetting
  {
    get
    {
      FString* fstringPtr = (FString*) ((IntPtr) \u003CModule\u003E.FNewUDKProjectSettings\u002EGet() + 20L);
      return new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
    }
    set
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, value);
      try
      {
        \u003CModule\u003E.FString\u002E\u003D((FString*) ((IntPtr) \u003CModule\u003E.FNewUDKProjectSettings\u002EGet() + 20L), fstring2);
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      this.OnPropertyChanged(nameof (ProjectNameSetting));
    }
  }

  public unsafe string ShortNameSetting
  {
    get
    {
      FString* fstringPtr = (FString*) ((IntPtr) \u003CModule\u003E.FNewUDKProjectSettings\u002EGet() + 36L);
      return new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
    }
    set
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, value);
      try
      {
        \u003CModule\u003E.FString\u002E\u003D((FString*) ((IntPtr) \u003CModule\u003E.FNewUDKProjectSettings\u002EGet() + 36L), fstring2);
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      this.OnPropertyChanged(nameof (ShortNameSetting));
    }
  }

  public unsafe string InstallDirectorySetting
  {
    get
    {
      FString* fstringPtr = (FString*) ((IntPtr) \u003CModule\u003E.FNewUDKProjectSettings\u002EGet() + 52L);
      return new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
    }
    set
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, value);
      try
      {
        \u003CModule\u003E.FString\u002E\u003D((FString*) ((IntPtr) \u003CModule\u003E.FNewUDKProjectSettings\u002EGet() + 52L), fstring2);
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      this.OnPropertyChanged(nameof (InstallDirectorySetting));
    }
  }

  public MEnumerableTArrayWrapper\u003CMTemplateTargetListWrapper\u002CFTemplateTargetListInfo\u003E TemplateTargetProperty
  {
    get => this.TemplateTargetList;
    set
    {
      if (value == this.TemplateTargetList)
        return;
      this.TemplateTargetList = value;
      this.OnPropertyChanged(nameof (TemplateTargetProperty));
    }
  }

  public MEnumerableTArrayWrapper\u003CMProjectSettingsListWrapper\u002CFUserProjectSettingsListInfo\u003E UserProjectSettingsProperty
  {
    get => this.UserSettingsList;
    set
    {
      if (value == this.UserSettingsList)
        return;
      this.UserSettingsList = value;
      this.OnPropertyChanged(nameof (UserProjectSettingsProperty));
    }
  }

  public bool IsNotEndOfTabList
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.NavigationTabControl.SelectedIndex != this.NavigationTabControl.Items.Count - 3;
  }

  public bool IsNotStartOfTabList
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.NavigationTabControl.SelectedIndex != 0;
  }

  public MNewProjectPanel(string InXaml)
    : base(InXaml)
  {
    MNewProjectPanel mnewProjectPanel1 = this;
    mnewProjectPanel1.PropertyChanged += new PropertyChangedEventHandler(mnewProjectPanel1.OnNewProjectPropertyChanged);
    MNewProjectPanel mnewProjectPanel2 = this;
    mnewProjectPanel2.YesButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mnewProjectPanel2, nameof (YesButton));
    this.YesButton.Click += new RoutedEventHandler(this.OnFinishClicked);
    MNewProjectPanel mnewProjectPanel3 = this;
    mnewProjectPanel3.NoButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mnewProjectPanel3, nameof (NoButton));
    this.NoButton.Click += new RoutedEventHandler(this.OnCloseClicked);
    MNewProjectPanel mnewProjectPanel4 = this;
    mnewProjectPanel4.CloseWindowButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mnewProjectPanel4, nameof (CloseWindowButton));
    this.CloseWindowButton.Click += new RoutedEventHandler(this.OnCloseClicked);
    MNewProjectPanel mnewProjectPanel5 = this;
    mnewProjectPanel5.FinishButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mnewProjectPanel5, nameof (FinishButton));
    this.FinishButton.Click += new RoutedEventHandler(this.OnFinishClicked);
    MNewProjectPanel mnewProjectPanel6 = this;
    mnewProjectPanel6.NavigationTabControl = (TabControl) LogicalTreeHelper.FindLogicalNode((DependencyObject) mnewProjectPanel6, nameof (NavigationTabControl));
    this.NavigationTabControl.SelectionChanged += new SelectionChangedEventHandler(this.OnTabSelectionChanged);
    MNewProjectPanel mnewProjectPanel7 = this;
    mnewProjectPanel7.NextPanelButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mnewProjectPanel7, nameof (NextPanelButton));
    Utils.CreateBinding((FrameworkElement) this.NextPanelButton, UIElement.IsEnabledProperty, (object) this, nameof (IsNotEndOfTabList));
    this.NextPanelButton.Click += new RoutedEventHandler(this.OnNextPanelButtonClicked);
    MNewProjectPanel mnewProjectPanel8 = this;
    mnewProjectPanel8.PrevPanelButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mnewProjectPanel8, nameof (PrevPanelButton));
    Utils.CreateBinding((FrameworkElement) this.PrevPanelButton, UIElement.IsEnabledProperty, (object) this, nameof (IsNotStartOfTabList));
    this.PrevPanelButton.Click += new RoutedEventHandler(this.OnPrevPanelButtonClicked);
    MNewProjectPanel mnewProjectPanel9 = this;
    mnewProjectPanel9.TemplateTargetComboBox = (ComboBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mnewProjectPanel9, nameof (TemplateTargetList));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ProjectNameTextBox"), TextBox.TextProperty, (object) this, nameof (ProjectNameSetting));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ShortNameTextBox"), TextBox.TextProperty, (object) this, nameof (ShortNameSetting));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "InstallDirectoryTextBox"), TextBox.TextProperty, (object) this, nameof (InstallDirectorySetting));
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "InstallDirectoryBrowseButton")).Click += new RoutedEventHandler(this.InstallDirectoryBrowseButtonClicked);
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    this.NavigationTabControl.SelectedIndex = 0;
    if (this.GetParentFrame() != InParentFrame)
    {
      base.SetParentFrame(InParentFrame);
      this.SetupItems();
    }
    this.SetDefaults();
    this.RefreshAllProperties();
  }

  public void RefreshTemplateTargetListProperties() => this.TemplateTargetProperty.NotifyChanged();

  protected void OnNewProjectPropertyChanged(object Owner, PropertyChangedEventArgs Args)
  {
  }

  private unsafe void SetupItems()
  {
    MNewProjectPanel mnewProjectPanel1 = this;
    mnewProjectPanel1.TemplateTargetList = new MEnumerableTArrayWrapper\u003CMTemplateTargetListWrapper\u002CFTemplateTargetListInfo\u003E(\u003CModule\u003E.FNewUDKProjectWizard\u002EGetTemplateTargetList(mnewProjectPanel1.ProjWizSystem));
    this.TemplateTargetList.PropertyChanged += new PropertyChangedEventHandler(this.OnTemplateTargetPropertyChanged);
    Utils.CreateBinding((FrameworkElement) this.TemplateTargetComboBox, ItemsControl.ItemsSourceProperty, (object) this, "TemplateTargetProperty");
    MNewProjectPanel mnewProjectPanel2 = this;
    mnewProjectPanel2.UserSettingsList = new MEnumerableTArrayWrapper\u003CMProjectSettingsListWrapper\u002CFUserProjectSettingsListInfo\u003E(\u003CModule\u003E.FNewUDKProjectWizard\u002EGetUserSettingsList(mnewProjectPanel2.ProjWizSystem));
    this.UserSettingsList.PropertyChanged += new PropertyChangedEventHandler(this.OnUserSettingListPropertyChanged);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "UserProjectSettingsListBox"), ItemsControl.ItemsSourceProperty, (object) this, "UserProjectSettingsProperty");
  }

  private void SetDefaults()
  {
    if (this.ShowSuccessScreen != 0U)
    {
      this.NavigationTabControl.SelectedIndex = 3;
      this.CloseWindowButton.Visibility = Visibility.Collapsed;
      this.FinishButton.Visibility = Visibility.Collapsed;
      this.YesButton.Visibility = Visibility.Visible;
      this.NoButton.Visibility = Visibility.Visible;
    }
    else
    {
      this.NavigationTabControl.SelectedIndex = 0;
      this.CloseWindowButton.Visibility = Visibility.Visible;
      this.FinishButton.Visibility = Visibility.Visible;
      this.YesButton.Visibility = Visibility.Collapsed;
      this.NoButton.Visibility = Visibility.Collapsed;
    }
  }

  private void OnCloseClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(0);

  private void OnFinishClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(1);

  private void OnNextPanelButtonClicked(object Owner, RoutedEventArgs Args)
  {
    if (this.NavigationTabControl.SelectedIndex >= this.NavigationTabControl.Items.Count - 2)
      return;
    ++this.NavigationTabControl.SelectedIndex;
  }

  private void OnPrevPanelButtonClicked(object Owner, RoutedEventArgs Args)
  {
    if (this.NavigationTabControl.SelectedIndex <= 0)
      return;
    --this.NavigationTabControl.SelectedIndex;
  }

  private void InstallDirectoryBrowseButtonClicked(object Owner, RoutedEventArgs Args) => this.PromptForInstallDirectory();

  private void OnTabSelectionChanged(object Owner, SelectionChangedEventArgs Args)
  {
    if (null == ((Selector) Owner).SelectedItem)
      return;
    this.RefreshAllProperties();
  }

  private void OnTemplateTargetPropertyChanged(object Owner, PropertyChangedEventArgs Args) => this.RefreshAllProperties();

  private void OnUserSettingListPropertyChanged(object Owner, PropertyChangedEventArgs Args)
  {
  }

  private unsafe void PromptForInstallDirectory()
  {
    FString fstring1;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_03LKILIBFM\u0040\u003F4\u003F4\u003F2\u003F\u0024AA\u0040);
    string InCLRString;
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr1 = \u003CModule\u003E.appRootDir(&fstring2);
      // ISSUE: fault handler
      try
      {
        FString fstring3;
        FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002A(fstringPtr1, &fstring3, &fstring1);
        // ISSUE: fault handler
        try
        {
          FString fstring4;
          FString* fstringPtr3 = \u003CModule\u003E.appCollapseRelativeDirectories(&fstring4, fstringPtr2);
          // ISSUE: fault handler
          try
          {
            InCLRString = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr3), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr3));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
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
    wxString wxString1;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, (char*) ^(long&) ref \u003CModule\u003E.__imp_wxDirDialogNameStr);
    wxDirDialog wxDirDialog;
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, InCLRString);
      // ISSUE: fault handler
      try
      {
        wxString wxString2;
        \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, \u003CModule\u003E.FString\u002E\u002A(fstring3));
        // ISSUE: fault handler
        try
        {
          FString fstring4;
          FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring4, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BB\u0040GPNJFID\u0040ChooseADirectory\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
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
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
          }
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
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
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
      }
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
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
          FString fstring2;
          FString* fstringPtr = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.wxString\u002E\u002EPEB_W((wxString*) num));
          // ISSUE: fault handler
          try
          {
            this.InstallDirectorySetting = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
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
}
