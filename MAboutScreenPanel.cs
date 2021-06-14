// Decompiled with JetBrains decompiler
// Type: MAboutScreenPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

internal class MAboutScreenPanel : MWPFPanel
{
  public string AppName;

  public unsafe MAboutScreenPanel(string InXaml)
    : base(InXaml)
  {
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CloseWindowButton")).Click += new RoutedEventHandler(this.OnCloseClicked);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "FacebookButton")).Click += new RoutedEventHandler(this.OnFacebookButtonClicked);
    FString fstring1;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
    // ISSUE: fault handler
    try
    {
      if (\u003CModule\u003E.appGetSplashPath((char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CA\u0040EKOJHNNP\u0040\u003F\u0024AAP\u003F\u0024AAC\u003F\u0024AA\u003F2\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AAS\u003F\u0024AAp\u003F\u0024AAl\u003F\u0024AAa\u003F\u0024AAs\u003F\u0024AAh\u003F\u0024AA\u003F4\u003F\u0024AAb\u003F\u0024AAm\u003F\u0024AAp\u003F\u0024AA\u003F\u0024AA\u0040, &fstring1) != 0U)
      {
        Image logicalNode = (Image) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "AboutScreenSplash");
        FString fstring2;
        FString* full = \u003CModule\u003E.appConvertRelativePathToFull(&fstring2, &fstring1);
        // ISSUE: fault handler
        try
        {
          string uriString = new string(\u003CModule\u003E.FString\u002E\u002A(full), 0, \u003CModule\u003E.FString\u002ELen(full));
          logicalNode.Source = (ImageSource) new BitmapImage(new Uri(uriString, UriKind.Absolute));
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
      FString* fstringPtr1 = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_08HEMPMHEM\u0040UDKTitle\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
      // ISSUE: fault handler
      try
      {
        this.AppName = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr1), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr1));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      TextBlock logicalNode1 = (TextBlock) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "AboutScreenTitle");
      FString fstring4;
      FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, this.AppName);
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        FString* fstring6 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, this.AppName);
        // ISSUE: fault handler
        try
        {
          FString fstring7;
          FString* fstringPtr2 = \u003CModule\u003E.LocalizeUnrealEd(&fstring7, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BF\u0040INEMABHN\u0040UnrealEdVersionTitle\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
          // ISSUE: fault handler
          try
          {
            FString fstring8;
            FString* fstringPtr3 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring8, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr2)), \u003CModule\u003E.FString\u002E\u002A(fstring6)), \u003CModule\u003E.FString\u002E\u002A(fstring5));
            // ISSUE: fault handler
            try
            {
              FString fstring9;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring9, \u003CModule\u003E.FString\u002E\u002A(fstringPtr3));
              // ISSUE: fault handler
              try
              {
                logicalNode1.Text = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring9), 0, \u003CModule\u003E.FString\u002ELen(&fstring9));
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring9);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring9);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring8);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring8);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring7);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring7);
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
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
      TextBlock logicalNode2 = (TextBlock) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "AboutScreenVersion");
      FString fstring10;
      FString* fstringPtr4 = \u003CModule\u003E.LocalizeUnrealEd(&fstring10, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BA\u0040MKHFAHFE\u0040UnrealEdVersion\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        FString* fstringPtr2 = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u002Cint\u003E(&fstring2, \u003CModule\u003E.FormatLocalizedString\u003Cint\u002Cint\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr4)), \u003CModule\u003E.GEngineVersion, \u003CModule\u003E.GBuiltFromChangeList), \u003CModule\u003E.GEngineVersion, \u003CModule\u003E.GBuiltFromChangeList);
        // ISSUE: fault handler
        try
        {
          FString fstring6;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring6, \u003CModule\u003E.FString\u002E\u002A(fstringPtr2));
          // ISSUE: fault handler
          try
          {
            logicalNode2.Text = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring6), 0, \u003CModule\u003E.FString\u002ELen(&fstring6));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
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
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring10);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring10);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.OnCloseClicked);
  }

  private void OnCloseClicked(object Owner, RoutedEventArgs Args) => this.ParentFrame.Close(0);

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
}
