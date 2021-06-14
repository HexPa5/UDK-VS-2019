// Decompiled with JetBrains decompiler
// Type: MPerforceLoginPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using UnrealEd;

internal class MPerforceLoginPanel : MWPFPanel
{
  private Button OKButton;
  private Button ReconnectButton;
  private TextBox ServerNameTextCtrl;
  private TextBox UserNameTextCtrl;
  private TextBox ClientSpecNameTextCtrl;
  private Panel ErrorPanel;
  private TextBlock ErrorMessageTextBlock;
  private Button ClientSpecBrowseButton;
  private Popup ClientSpecPopup;
  private ListBox ClientSpecListBox;
  private uint bReadyForUse = 0;
  private string ServerNameValue;
  private string UserNameValue;
  private string ClientSpecNameValue;

  public MPerforceLoginPanel(
    string InXamlName,
    string InServerName,
    string InUserName,
    string InClientSpecName)
    : base(InXamlName)
  {
    MPerforceLoginPanel mperforceLoginPanel1 = this;
    mperforceLoginPanel1.OKButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mperforceLoginPanel1, nameof (OKButton));
    this.OKButton.Click += new RoutedEventHandler(this.OKClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CancelButton")).Click += new RoutedEventHandler(this.CancelClicked);
    Button logicalNode = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, nameof (ReconnectButton));
    this.ReconnectButton = logicalNode;
    logicalNode.Visibility = Visibility.Collapsed;
    this.ReconnectButton.Click += new RoutedEventHandler(this.ReconnectClicked);
    MPerforceLoginPanel mperforceLoginPanel2 = this;
    mperforceLoginPanel2.ClientSpecBrowseButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mperforceLoginPanel2, nameof (ClientSpecBrowseButton));
    this.ClientSpecBrowseButton.Click += new RoutedEventHandler(this.BrowseClientSpec);
    MPerforceLoginPanel mperforceLoginPanel3 = this;
    mperforceLoginPanel3.ClientSpecListBox = (ListBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mperforceLoginPanel3, nameof (ClientSpecListBox));
    this.ClientSpecListBox.SelectionChanged += new SelectionChangedEventHandler(this.SelectClientSpec);
    MPerforceLoginPanel mperforceLoginPanel4 = this;
    mperforceLoginPanel4.ClientSpecPopup = (Popup) LogicalTreeHelper.FindLogicalNode((DependencyObject) mperforceLoginPanel4, nameof (ClientSpecPopup));
    MPerforceLoginPanel mperforceLoginPanel5 = this;
    mperforceLoginPanel5.ServerNameTextCtrl = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mperforceLoginPanel5, nameof (ServerName));
    MPerforceLoginPanel mperforceLoginPanel6 = this;
    mperforceLoginPanel6.UserNameTextCtrl = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mperforceLoginPanel6, nameof (UserName));
    MPerforceLoginPanel mperforceLoginPanel7 = this;
    mperforceLoginPanel7.ClientSpecNameTextCtrl = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mperforceLoginPanel7, nameof (ClientSpecName));
    MPerforceLoginPanel mperforceLoginPanel8 = this;
    mperforceLoginPanel8.ErrorPanel = (Panel) LogicalTreeHelper.FindLogicalNode((DependencyObject) mperforceLoginPanel8, nameof (ErrorPanel));
    MPerforceLoginPanel mperforceLoginPanel9 = this;
    mperforceLoginPanel9.ErrorMessageTextBlock = (TextBlock) LogicalTreeHelper.FindLogicalNode((DependencyObject) mperforceLoginPanel9, nameof (ErrorMessageTextBlock));
    this.ServerName = InServerName;
    this.UserName = InUserName;
    this.ClientSpecName = InClientSpecName;
    MPerforceLoginPanel mperforceLoginPanel10 = this;
    mperforceLoginPanel10.PropertyChanged += new PropertyChangedEventHandler(mperforceLoginPanel10.OnLoginPropertyChanged);
    Utils.CreateBinding((FrameworkElement) this.ServerNameTextCtrl, TextBox.TextProperty, (object) this, nameof (ServerName));
    Utils.CreateBinding((FrameworkElement) this.UserNameTextCtrl, TextBox.TextProperty, (object) this, nameof (UserName));
    Utils.CreateBinding((FrameworkElement) this.ClientSpecNameTextCtrl, TextBox.TextProperty, (object) this, nameof (ClientSpecName));
    this.ServerNameTextCtrl.KeyUp += new KeyEventHandler(this.OnKeyUp);
    this.UserNameTextCtrl.KeyUp += new KeyEventHandler(this.OnKeyUp);
    this.ClientSpecNameTextCtrl.KeyUp += new KeyEventHandler(this.OnKeyUp);
    this.bReadyForUse = 1U;
    this.AttemptReconnectAndRefreshClientSpecList();
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.CancelClicked);
  }

  public void SetClientSpecName(string InClientSpecName) => this.ClientSpecNameTextCtrl.Text = InClientSpecName;

  public void GetResult(
    ref string OutServerName,
    ref string OutUserName,
    ref string OutClientSpecName)
  {
    OutServerName = this.ServerName;
    OutUserName = this.UserName;
    OutClientSpecName = this.ClientSpecName;
  }

  private unsafe void AttemptReconnectAndRefreshClientSpecList()
  {
    if (this.bReadyForUse == 0U)
      return;
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      FPerforceNET fperforceNet1 = new FPerforceNET(this.ServerName, this.UserName, (string) null, (string) null);
      FPerforceNET fperforceNet2;
      // ISSUE: fault handler
      try
      {
        fperforceNet2 = fperforceNet1;
        List<string> clientSpecList = fperforceNet2.GetClientSpecList(this.UserNameTextCtrl.Text, &fdefaultAllocator);
        if (clientSpecList.Count > 0)
        {
          this.ClientSpecListBox.Items.Clear();
          int index = 0;
          if (0 < clientSpecList.Count)
          {
            do
            {
              this.ClientSpecListBox.Items.Add((object) clientSpecList[index]);
              ++index;
            }
            while (index < clientSpecList.Count);
          }
          if (clientSpecList.Count == 1)
          {
            this.ClientSpecName = clientSpecList[0];
            this.ClientSpecBrowseButton.IsEnabled = false;
            this.ClientSpecNameTextCtrl.IsEnabled = false;
          }
          else
          {
            this.ClientSpecBrowseButton.IsEnabled = true;
            this.ClientSpecNameTextCtrl.IsEnabled = true;
          }
          FString fstring;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
          // ISSUE: fault handler
          try
          {
            this.SetErrorMessage(&fstring);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
          this.OKButton.IsEnabled = true;
          this.ReconnectButton.Visibility = Visibility.Collapsed;
        }
        else
        {
          this.ClientSpecName = string.Empty;
          FString fstring1;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
          // ISSUE: fault handler
          try
          {
            if (\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator) > 0)
            {
              int num = 0;
              if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator))
              {
                do
                {
                  FString fstring2;
                  FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_17MJEANDKP\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA\u003F6\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.FString\u002E\u002A(\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num)));
                  // ISSUE: fault handler
                  try
                  {
                    \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring1, fstringPtr);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
                  }
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
                  ++num;
                }
                while (num < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator));
              }
            }
            else
            {
              FString fstring2;
              FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring2, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0CM\u0040OGICJLGM\u0040PerforceLogin_Error_UnableToConn\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.FString\u002E\u003D(&fstring1, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
            }
            FString fstring3;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, \u003CModule\u003E.FString\u002E\u002A(&fstring1));
            // ISSUE: fault handler
            try
            {
              this.SetErrorMessage(&fstring3);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
            this.OKButton.IsEnabled = false;
            this.ClientSpecBrowseButton.IsEnabled = false;
            this.ClientSpecNameTextCtrl.IsEnabled = false;
            this.ReconnectButton.Visibility = Visibility.Visible;
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        }
      }
      __fault
      {
        fperforceNet2.Dispose();
      }
      fperforceNet2.Dispose();
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  private void OnLoginPropertyChanged(object Owner, PropertyChangedEventArgs Args) => this.AttemptReconnectAndRefreshClientSpecList();

  private void OnKeyUp(object Owner, KeyEventArgs Args)
  {
    if (Args.Key != Key.Return)
      return;
    ((FrameworkElement) Args.Source)?.GetBindingExpression(TextBox.TextProperty).UpdateSource();
  }

  private void OKClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(0);

  private void CancelClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(1);

  private void ReconnectClicked(object Owner, RoutedEventArgs Args) => this.AttemptReconnectAndRefreshClientSpecList();

  private void BrowseClientSpec(object Owner, RoutedEventArgs Args)
  {
    if (this.ClientSpecListBox.Items.Count == 0)
      return;
    this.ClientSpecPopup.IsOpen = true;
  }

  private void SelectClientSpec(object Owner, SelectionChangedEventArgs Args)
  {
    if (Args.AddedItems.Count != 1)
      return;
    this.ClientSpecName = (string) Args.AddedItems[0];
    this.ClientSpecPopup.IsOpen = false;
  }

  private unsafe void SetErrorMessage(FString* InErrorMessage)
  {
    if (\u003CModule\u003E.FString\u002ELen(InErrorMessage) > 0)
    {
      this.ErrorPanel.Visibility = Visibility.Visible;
      FString fstring;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, \u003CModule\u003E.FString\u002E\u002A(InErrorMessage));
      // ISSUE: fault handler
      try
      {
        this.ErrorMessageTextBlock.Text = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring), 0, \u003CModule\u003E.FString\u002ELen(&fstring));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
    }
    else
      this.ErrorPanel.Visibility = Visibility.Collapsed;
  }

  public string ServerName
  {
    get => this.ServerNameValue;
    set
    {
      if (!(this.ServerNameValue != value))
        return;
      this.ServerNameValue = value;
      this.OnPropertyChanged(nameof (ServerName));
    }
  }

  public string UserName
  {
    get => this.UserNameValue;
    set
    {
      if (!(this.UserNameValue != value))
        return;
      this.UserNameValue = value;
      this.OnPropertyChanged(nameof (UserName));
    }
  }

  public string ClientSpecName
  {
    get => this.ClientSpecNameValue;
    set
    {
      if (!(this.ClientSpecNameValue != value))
        return;
      this.ClientSpecNameValue = value;
      this.OnPropertyChanged(nameof (ClientSpecName));
    }
  }
}
