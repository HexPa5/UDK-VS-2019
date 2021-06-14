// Decompiled with JetBrains decompiler
// Type: MWelcomeScreenPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

internal class MWelcomeScreenPanel : MWPFPanel
{
  private CheckBox ShowAtStartupCheckBox;

  public unsafe MWelcomeScreenPanel(string InXaml)
    : base(InXaml)
  {
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CloseWindowButton")).Click += new RoutedEventHandler(this.OnCloseClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "GettingStartedButton")).Click += new RoutedEventHandler(this.OnGettingStartedClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "TutorialsButton")).Click += new RoutedEventHandler(this.OnTutorialsClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ForumsButton")).Click += new RoutedEventHandler(this.OnForumsClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "NewsButton")).Click += new RoutedEventHandler(this.OnNewsClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "FacebookButton")).Click += new RoutedEventHandler(this.OnFacebookButtonClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "NewMapButton")).Click += new RoutedEventHandler(this.OnNewMapClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "OpenMapButton")).Click += new RoutedEventHandler(this.OnOpenMapClicked);
    MWelcomeScreenPanel mwelcomeScreenPanel = this;
    mwelcomeScreenPanel.ShowAtStartupCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mwelcomeScreenPanel, nameof (ShowAtStartupCheckBox));
    uint num1 = 1;
    int num2 = (int) \u003CModule\u003E.FConfigCacheIni\u002EGetBool(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040HKLKNCGP\u0040\u003F\u0024AAW\u003F\u0024AAe\u003F\u0024AAl\u003F\u0024AAc\u003F\u0024AAo\u003F\u0024AAm\u003F\u0024AAe\u003F\u0024AAS\u003F\u0024AAc\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BO\u0040HIJHGGBN\u0040\u003F\u0024AAb\u003F\u0024AAS\u003F\u0024AAh\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AAA\u003F\u0024AAt\u003F\u0024AAS\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAr\u003F\u0024AAt\u003F\u0024AAu\u003F\u0024AAp\u003F\u0024AA\u003F\u0024AA\u0040, &num1, (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
    this.ShowAtStartupCheckBox.IsChecked = (bool?) (num1 == 1U);
    this.ShowAtStartupCheckBox.Checked += new RoutedEventHandler(this.OnStartupCheckBoxToggle);
    this.ShowAtStartupCheckBox.Unchecked += new RoutedEventHandler(this.OnStartupCheckBoxToggle);
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.OnCloseClicked);
  }

  private void OnCloseClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(0);

  private unsafe void OnGettingStartedClicked(object Owner, RoutedEventArgs Args)
  {
    FString fstring;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1GO\u0040PNKHGKJL\u0040\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAt\u003F\u0024AAp\u003F\u0024AA\u003F3\u003F\u0024AA\u003F1\u003F\u0024AA\u003F1\u003F\u0024AAu\u003F\u0024AAd\u003F\u0024AAn\u003F\u0024AA\u003F4\u003F\u0024AAe\u003F\u0024AAp\u003F\u0024AAi\u003F\u0024AAc\u003F\u0024AAg\u003F\u0024AAa\u003F\u0024AAm\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F4\u003F\u0024AAc\u003F\u0024AAo\u003F\u0024AAm\u003F\u0024AA\u003F1\u003F\u0024AAT\u003F\u0024AAh\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAe\u003F\u0024AA\u003F1\u003F\u0024AAD\u0040);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.appLaunchURL(\u003CModule\u003E.FString\u002E\u002A(&fstring), (char*) 0L, (FString*) 0L);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  private unsafe void OnTutorialsClicked(object Owner, RoutedEventArgs Args)
  {
    FString fstring;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1GG\u0040HEGHJACO\u0040\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAt\u003F\u0024AAp\u003F\u0024AA\u003F3\u003F\u0024AA\u003F1\u003F\u0024AA\u003F1\u003F\u0024AAu\u003F\u0024AAd\u003F\u0024AAn\u003F\u0024AA\u003F4\u003F\u0024AAe\u003F\u0024AAp\u003F\u0024AAi\u003F\u0024AAc\u003F\u0024AAg\u003F\u0024AAa\u003F\u0024AAm\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F4\u003F\u0024AAc\u003F\u0024AAo\u003F\u0024AAm\u003F\u0024AA\u003F1\u003F\u0024AAT\u003F\u0024AAh\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAe\u003F\u0024AA\u003F1\u003F\u0024AAV\u0040);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.appLaunchURL(\u003CModule\u003E.FString\u002E\u002A(&fstring), (char*) 0L, (FString*) 0L);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  private unsafe void OnForumsClicked(object Owner, RoutedEventArgs Args)
  {
    FString fstring;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FG\u0040IHJOFBJM\u0040\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAt\u003F\u0024AAp\u003F\u0024AA\u003F3\u003F\u0024AA\u003F1\u003F\u0024AA\u003F1\u003F\u0024AAf\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAu\u003F\u0024AAm\u003F\u0024AAs\u003F\u0024AA\u003F4\u003F\u0024AAe\u003F\u0024AAp\u003F\u0024AAi\u003F\u0024AAc\u003F\u0024AAg\u003F\u0024AAa\u003F\u0024AAm\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F4\u003F\u0024AAc\u003F\u0024AAo\u003F\u0024AAm\u003F\u0024AA\u003F1\u003F\u0024AAf\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAu\u0040);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.appLaunchURL(\u003CModule\u003E.FString\u002E\u002A(&fstring), (char*) 0L, (FString*) 0L);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  private unsafe void OnNewsClicked(object Owner, RoutedEventArgs Args)
  {
    FString fstring;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1HA\u0040PFGEAIMJ\u0040\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAt\u003F\u0024AAp\u003F\u0024AA\u003F3\u003F\u0024AA\u003F1\u003F\u0024AA\u003F1\u003F\u0024AAw\u003F\u0024AAw\u003F\u0024AAw\u003F\u0024AA\u003F4\u003F\u0024AAu\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAg\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAe\u003F\u0024AA\u003F4\u003F\u0024AAc\u003F\u0024AAo\u003F\u0024AAm\u003F\u0024AA\u003F1\u003F\u0024AAn\u003F\u0024AAe\u003F\u0024AAw\u003F\u0024AAs\u0040);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.appLaunchURL(\u003CModule\u003E.FString\u002E\u002A(&fstring), (char*) 0L, (FString*) 0L);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  private unsafe void OnFacebookButtonClicked(object Owner, RoutedEventArgs Args)
  {
    FString fstring;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1EK\u0040LENMEHCL\u0040\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAt\u003F\u0024AAp\u003F\u0024AA\u003F3\u003F\u0024AA\u003F1\u003F\u0024AA\u003F1\u003F\u0024AAw\u003F\u0024AAw\u003F\u0024AAw\u003F\u0024AA\u003F4\u003F\u0024AAf\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAb\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAk\u003F\u0024AA\u003F4\u003F\u0024AAc\u003F\u0024AAo\u003F\u0024AAm\u003F\u0024AA\u003F1\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAn\u0040);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.appLaunchURL(\u003CModule\u003E.FString\u002E\u002A(&fstring), (char*) 0L, (FString*) 0L);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  private void OnNewMapClicked(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEditorFileUtils\u002ENewMapInteractive();

  private void OnOpenMapClicked(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEditorFileUtils\u002ELoadMap();

  private unsafe void OnStartupCheckBoxToggle(object Owner, RoutedEventArgs Args)
  {
    uint num = !this.ShowAtStartupCheckBox.IsChecked.HasValue || !this.ShowAtStartupCheckBox.IsChecked.Value ? 0U : 1U;
    \u003CModule\u003E.FConfigCacheIni\u002ESetBool(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040HKLKNCGP\u0040\u003F\u0024AAW\u003F\u0024AAe\u003F\u0024AAl\u003F\u0024AAc\u003F\u0024AAo\u003F\u0024AAm\u003F\u0024AAe\u003F\u0024AAS\u003F\u0024AAc\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BO\u0040HIJHGGBN\u0040\u003F\u0024AAb\u003F\u0024AAS\u003F\u0024AAh\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AAA\u003F\u0024AAt\u003F\u0024AAS\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAr\u003F\u0024AAt\u003F\u0024AAu\u003F\u0024AAp\u003F\u0024AA\u003F\u0024AA\u0040, num, (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
  }
}
