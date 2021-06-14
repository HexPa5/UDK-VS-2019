// Decompiled with JetBrains decompiler
// Type: MStartPageControl
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Navigation;

internal class MStartPageControl : IDisposable
{
  protected WebBrowser WebBrowserCtrl;
  protected HwndSource InteropWindow;
  protected Uri MainURI;
  protected Uri BackupURI;
  protected Uri CurrentURI;
  protected uint bDefaultLoadComplete;
  protected uint bFirstFocus;

  public unsafe MStartPageControl()
  {
    this.MainURI = new Uri("http://www.unrealengine.com/udk/documentation/");
    FString fstring1;
    FString* fstringPtr = \u003CModule\u003E.appEngineDir(&fstring1);
    string str1;
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      long num = (long) __calli((__FnPtr<FString* (IntPtr, FString*, char*)>) *(long*) (*(long*) \u003CModule\u003E.GFileManager + 168L))((char*) \u003CModule\u003E.GFileManager, &fstring2, (IntPtr) \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
      // ISSUE: fault handler
      try
      {
        FString fstring3;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, \u003CModule\u003E.FString\u002E\u002A((FString*) num));
        // ISSUE: fault handler
        try
        {
          str1 = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring3), 0, \u003CModule\u003E.FString\u002ELen(&fstring3));
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
    string str2 = "EditorResources\\UDKOffline.html";
    this.BackupURI = new Uri(str1 + str2);
    MStartPageControl mstartPageControl = this;
    mstartPageControl.CurrentURI = mstartPageControl.MainURI;
    this.bDefaultLoadComplete = 1U;
    this.bFirstFocus = 1U;
  }

  private void \u007EMStartPageControl()
  {
    HwndSource interopWindow = this.InteropWindow;
    if (interopWindow == null)
      return;
    interopWindow.Dispose();
    this.InteropWindow = (HwndSource) null;
  }

  private void \u0021MStartPageControl()
  {
  }

  protected void DisposeOfInteropWindow()
  {
    HwndSource interopWindow = this.InteropWindow;
    if (interopWindow == null)
      return;
    interopWindow.Dispose();
    this.InteropWindow = (HwndSource) null;
  }

  public unsafe uint InitStartPage(WxStartPageHost* InParent, HWND__* InParentWindowHandle)
  {
    HwndSourceParameters parameters = new HwndSourceParameters("StartPageHost");
    parameters.PositionX = 0;
    parameters.PositionY = 0;
    IntPtr num = (IntPtr) (void*) InParentWindowHandle;
    parameters.ParentWindow = num;
    parameters.WindowStyle = 1342177280;
    HwndSource hwndSource = new HwndSource(parameters);
    this.InteropWindow = hwndSource;
    hwndSource.SizeToContent = SizeToContent.Manual;
    \u003CModule\u003E.WxUnrealEdApp\u002EInstallHooksWPF();
    this.InteropWindow.AddHook(new HwndSourceHook(this.MessageHookFunction));
    \u003CModule\u003E.ShowWindow((HWND__*) this.InteropWindow.Handle.ToPointer(), 5);
    return 1;
  }

  public unsafe void Resize(HWND__* hWndParent, int x, int y, int Width, int Height) => \u003CModule\u003E.SetWindowPos((HWND__*) this.InteropWindow.Handle.ToPointer(), (HWND__*) 0L, 0, 0, Width, Height, 6U);

  public void SetFocus()
  {
    if (this.bFirstFocus != 0U)
    {
      this.RebuildWebBrowserControl(1U);
      this.bFirstFocus = 0U;
    }
    if (this.InteropWindow == null)
      return;
    this.WebBrowserCtrl.Focus();
  }

  public unsafe void OnURIBeginLoad(object Owner, NavigatingCancelEventArgs Args)
  {
    FString fstring1;
    \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.MainURI.AbsoluteUri);
    FString fstring2;
    FString fstring3;
    FString fstring4;
    int num1;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, this.BackupURI.AbsoluteUri);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, Args.Uri.AbsoluteUri);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, this.CurrentURI.AbsoluteUri);
          // ISSUE: fault handler
          try
          {
            num1 = \u003CModule\u003E.FString\u002EInStr(&fstring3, &fstring1, 0U, 1U, -1);
            int num2 = num1 != -1 ? 1 : 0;
            uint num3 = \u003CModule\u003E.FString\u002EInStr(&fstring3, &fstring2, 0U, 1U, -1) != -1 ? 1U : 0U;
            if (num2 == 0 && num3 == 0U)
            {
              FString fstring5;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring5, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0P\u0040BMEEIAJH\u0040http\u003F3\u003F1\u003F1udk\u003F4com\u003F\u0024AA\u0040);
              int num4;
              // ISSUE: fault handler
              try
              {
                num4 = \u003CModule\u003E.FString\u002EInStr(&fstring3, &fstring5, 0U, 1U, -1);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
              uint num5 = (uint) (num4 == 0);
              FString fstring6;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring6, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0O\u0040JMIFCMPP\u0040documentation\u003F\u0024AA\u0040);
              int num6;
              // ISSUE: fault handler
              try
              {
                num6 = \u003CModule\u003E.FString\u002EInStr(&fstring3, &fstring6, 0U, 1U, -1);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
              uint num7 = num6 != -1 ? 1U : 0U;
              if (num5 != 0U && num7 != 0U)
              {
                if (this.CurrentURI != Args.Uri)
                {
                  this.CurrentURI = Args.Uri;
                  goto label_44;
                }
                else
                  goto label_44;
              }
              else
              {
                Uri uri = Args.Uri;
                Args.Cancel = true;
                FString fstring7;
                \u003CModule\u003E.CLRTools\u002EToFString(&fstring7, uri.AbsoluteUri);
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.appLaunchURL(\u003CModule\u003E.FString\u002E\u002A(&fstring7), (char*) 0L, (FString*) 0L);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring7);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring7);
                goto label_44;
              }
            }
            else
            {
              int num4 = \u003CModule\u003E.FString\u002EInStr(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_13GMDMCADD\u0040\u003F\u0024AA\u003F\u0024CD\u003F\u0024AA\u003F\u0024AA\u0040, 0U, 1U, -1);
              int num5 = \u003CModule\u003E.FString\u002EInStr(&fstring4, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_13GMDMCADD\u0040\u003F\u0024AA\u003F\u0024CD\u003F\u0024AA\u003F\u0024AA\u0040, 0U, 1U, -1);
              if (num4 != -1)
              {
                if (num5 != -1)
                {
                  FString fstring5;
                  FString* fstringPtr1 = \u003CModule\u003E.FString\u002ELeft(&fstring4, &fstring5, num5);
                  uint num6;
                  // ISSUE: fault handler
                  try
                  {
                    FString fstring6;
                    FString* fstringPtr2 = \u003CModule\u003E.FString\u002ELeft(&fstring3, &fstring6, num4);
                    // ISSUE: fault handler
                    try
                    {
                      num6 = \u003CModule\u003E.FString\u002E\u003D\u003D(fstringPtr2, fstringPtr1);
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
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
                  }
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
                  if (num6 == 0U)
                    goto label_35;
                }
                else
                  goto label_35;
              }
              else
                goto label_35;
            }
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
    return;
label_35:
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        // ISSUE: fault handler
        try
        {
          // ISSUE: fault handler
          try
          {
            if (num1 == 0)
            {
              uint bDestroyPreviousBrowser = (uint) (this.CurrentURI == this.BackupURI);
              bool flag = bDestroyPreviousBrowser != 0U;
              Args.Cancel = flag;
              this.CurrentURI = Args.Uri;
              this.RebuildWebBrowserControl(bDestroyPreviousBrowser);
            }
            else if (Args.Uri != this.CurrentURI)
            {
              this.bDefaultLoadComplete = 1U;
              MStartPageControl mstartPageControl = this;
              mstartPageControl.CurrentURI = mstartPageControl.BackupURI;
              Args.Cancel = true;
              this.RebuildWebBrowserControl(1U);
            }
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
label_44:
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        // ISSUE: fault handler
        try
        {
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
  }

  public void OnURIBeginDownload(object Owner, NavigationEventArgs Args)
  {
  }

  public void OnURILoadCompleted(object Owner, NavigationEventArgs Args) => this.bDefaultLoadComplete = 1U;

  public IntPtr MessageHookFunction(
    IntPtr HWnd,
    int Msg,
    IntPtr WParam,
    IntPtr LParam,
    ref bool OutHandled)
  {
    IntPtr num = (IntPtr) 0;
    OutHandled = false;
    switch (Msg)
    {
      case 61:
        OutHandled = true;
        num = (IntPtr) 0;
        break;
      case 135:
        OutHandled = true;
        num = new IntPtr(4);
        break;
    }
    return num;
  }

  protected void RebuildWebBrowserControl(uint bDestroyPreviousBrowser)
  {
    if (this.bDefaultLoadComplete == 0U)
      return;
    if (this.WebBrowserCtrl == null || bDestroyPreviousBrowser != 0U)
    {
      this.WebBrowserCtrl = new WebBrowser();
      this.WebBrowserCtrl.Navigating += new NavigatingCancelEventHandler(this.OnURIBeginLoad);
      this.WebBrowserCtrl.Navigated += new NavigatedEventHandler(this.OnURIBeginDownload);
      this.WebBrowserCtrl.LoadCompleted += new LoadCompletedEventHandler(this.OnURILoadCompleted);
      this.InteropWindow.RootVisual = (Visual) this.WebBrowserCtrl;
    }
    this.bDefaultLoadComplete = 0U;
    this.WebBrowserCtrl.Navigate(this.CurrentURI);
  }

  [HandleProcessCorruptedStateExceptions]
  protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      HwndSource interopWindow = this.InteropWindow;
      if (interopWindow == null)
        return;
      interopWindow.Dispose();
      this.InteropWindow = (HwndSource) null;
    }
    else
    {
      try
      {
      }
      finally
      {
        // ISSUE: explicit finalizer call
        base.Finalize();
      }
    }
  }

  public virtual void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  ~MStartPageControl() => this.Dispose(false);
}
