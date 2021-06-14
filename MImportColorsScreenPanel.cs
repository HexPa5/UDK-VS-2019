// Decompiled with JetBrains decompiler
// Type: MImportColorsScreenPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using UnrealEd;

internal class MImportColorsScreenPanel : MWPFPanel
{
  private string ImportTGAFileNameValue;
  private int ImportUVValue;
  private int ImportLODValue;
  private bool ImportRedValue;
  private bool ImportGreenValue;
  private bool ImportBlueValue;
  private bool ImportAlphaValue;

  public MImportColorsScreenPanel(string InXaml)
    : base(InXaml)
  {
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ImportTGAFileNameText"), TextBox.TextProperty, (object) this, nameof (ImportTGAFileName));
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ImportTGAFileButton")).Click += new RoutedEventHandler(this.ImportTGAFileButton_Click);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ImportLODCombo"), Selector.SelectedIndexProperty, (object) this, nameof (ImportLOD), (IValueConverter) new IntToIntOffsetConverter(0));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ImportRedCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (ImportRed));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ImportGreenCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (ImportGreen));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ImportBlueCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (ImportBlue));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ImportAlphaCheckBox"), ToggleButton.IsCheckedProperty, (object) this, nameof (ImportAlpha));
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ImportVertexColors")).Click += new RoutedEventHandler(this.ImportVertexColorsButton_Click);
    Button logicalNode = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ImportColorsCloseButton");
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.OnCloseClicked);
  }

  public string ImportTGAFileName
  {
    get => this.ImportTGAFileNameValue;
    set
    {
      if (!(this.ImportTGAFileNameValue != value))
        return;
      this.ImportTGAFileNameValue = value;
      this.OnPropertyChanged(nameof (ImportTGAFileName));
    }
  }

  public int ImportUV
  {
    get => this.ImportUVValue;
    set
    {
      if (this.ImportUVValue == value)
        return;
      this.ImportUVValue = value;
      this.OnPropertyChanged(nameof (ImportUV));
    }
  }

  public int ImportLOD
  {
    get => this.ImportLODValue;
    set
    {
      if (this.ImportLODValue == value)
        return;
      this.ImportLODValue = value;
      this.OnPropertyChanged(nameof (ImportLOD));
    }
  }

  public bool ImportRed
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.ImportRedValue;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (this.ImportRedValue == value)
        return;
      this.ImportRedValue = value;
      this.OnPropertyChanged(nameof (ImportRed));
    }
  }

  public bool ImportGreen
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.ImportGreenValue;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (this.ImportGreenValue == value)
        return;
      this.ImportGreenValue = value;
      this.OnPropertyChanged(nameof (ImportGreen));
    }
  }

  public bool ImportBlue
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.ImportBlueValue;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (this.ImportBlueValue == value)
        return;
      this.ImportBlueValue = value;
      this.OnPropertyChanged(nameof (ImportBlue));
    }
  }

  public bool ImportAlpha
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.ImportAlphaValue;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if (this.ImportAlphaValue == value)
        return;
      this.ImportAlphaValue = value;
      this.OnPropertyChanged(nameof (ImportAlpha));
    }
  }

  private void OnCloseClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(0);

  public unsafe void ImportTGAFileButton_Click(object Owner, RoutedEventArgs Args)
  {
    wxString wxString1;
    \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CA\u0040DGIBDPIB\u0040\u003F\u0024AAT\u003F\u0024AAg\u003F\u0024AAa\u003F\u0024AA\u003F5\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F\u0024HM\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAt\u003F\u0024AAg\u003F\u0024AAa\u003F\u0024AA\u003F\u0024AA\u0040);
    WxFileDialog wxFileDialog;
    // ISSUE: fault handler
    try
    {
      wxString wxString2;
      \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
      // ISSUE: fault handler
      try
      {
        wxString wxString3;
        \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
        // ISSUE: fault handler
        try
        {
          FString fstring;
          FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_04DNCDCIAE\u0040Open\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
          // ISSUE: fault handler
          try
          {
            wxString wxString4;
            \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString4, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
            // ISSUE: fault handler
            try
            {
              // ISSUE: cast to a reference type
              // ISSUE: explicit reference operation
              \u003CModule\u003E.WxFileDialog\u002E\u007Bctor\u007D(&wxFileDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString4, &wxString3, &wxString2, &wxString1, 49, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString4);
            }
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString4);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
            }
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
          }
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
          }
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
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
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
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
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
      ref WxFileDialog local1 = ref wxFileDialog;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      if (__calli((__FnPtr<int (IntPtr)>) *(long*) (^(long&) ref wxFileDialog + 1528L))((IntPtr) ref local1) == 5100)
      {
        wxArrayString wxArrayString;
        \u003CModule\u003E.wxArrayString\u002E\u007Bctor\u007D(&wxArrayString);
        // ISSUE: fault handler
        try
        {
          ref WxFileDialog local2 = ref wxFileDialog;
          ref wxArrayString local3 = ref wxArrayString;
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, wxArrayString*)>) *(long*) (^(long&) ref wxFileDialog + 1640L))((wxArrayString*) ref local2, (IntPtr) ref local3);
          FFilename ffilename;
          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.wxString\u002E\u002EPEB_W(\u003CModule\u003E.wxArrayString\u002E\u005B\u005D(&wxArrayString, 0UL)));
          // ISSUE: fault handler
          try
          {
            this.ImportTGAFileName = new string(\u003CModule\u003E.FString\u002E\u002A((FString*) &ffilename), 0, \u003CModule\u003E.FString\u002ELen((FString*) &ffilename));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename);
          }
          \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxArrayString\u002E\u007Bdtor\u007D), (void*) &wxArrayString);
        }
        \u003CModule\u003E.wxArrayString\u002E\u007Bdtor\u007D(&wxArrayString);
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
    }
    \u003CModule\u003E.wxFileDialog\u002E\u007Bdtor\u007D((wxFileDialog*) &wxFileDialog);
  }

  public unsafe void ImportVertexColorsButton_Click(object Owner, RoutedEventArgs Args)
  {
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.ImportTGAFileName);
    FString fstring3;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, \u003CModule\u003E.FString\u002E\u002A(fstring2));
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
      byte num1 = 0;
      byte num2 = this.ImportRed ? (byte) 1 : num1;
      if (this.ImportGreen)
        num2 |= (byte) 2;
      if (this.ImportBlue)
        num2 |= (byte) 4;
      if (this.ImportAlpha)
        num2 |= (byte) 8;
      ImportVertexTextureHelper vertexTextureHelper;
      \u003CModule\u003E.ImportVertexTextureHelper\u002EApply(&vertexTextureHelper, &fstring3, this.ImportUV, this.ImportLOD, num2);
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
