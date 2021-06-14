// Decompiled with JetBrains decompiler
// Type: MWPFWindowWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using msclr;
using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

internal class MWPFWindowWrapper : IDisposable
{
  protected int FakeTitleBarHeight;
  protected int FakeTitleBarButtonWidth;
  protected readonly auto_handle\u003CSystem\u003A\u003AWindows\u003A\u003AInterop\u003A\u003AHwndSource\u003E InteropWindow;

  public MWPFWindowWrapper()
  {
    auto_handle\u003CSystem\u003A\u003AWindows\u003A\u003AInterop\u003A\u003AHwndSource\u003E interopHwndSource = new auto_handle\u003CSystem\u003A\u003AWindows\u003A\u003AInterop\u003A\u003AHwndSource\u003E();
    // ISSUE: fault handler
    try
    {
      this.InteropWindow = interopHwndSource;
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }
    __fault
    {
      this.InteropWindow.Dispose();
    }
  }

  private void \u007EMWPFWindowWrapper() => this.InteropWindow.reset((HwndSource) null);

  private void \u0021MWPFWindowWrapper()
  {
  }

  protected void DisposeOfInteropWindow() => this.InteropWindow.reset((HwndSource) null);

  public unsafe uint InitWindow(
    HWND__* InParentWindowHandle,
    string InWindowTitle,
    string InWPFXamlFileName,
    int InPositionX,
    int InPositionY,
    [MarshalAs(UnmanagedType.U1)] bool bCenterWindow,
    int InFakeTitleBarHeight,
    int bInIsTopmost)
  {
    int window = (int) this.CreateWindow(InParentWindowHandle, InWindowTitle, InWPFXamlFileName, InPositionX, InPositionY, 0, 0, InFakeTitleBarHeight, 0, 1, bInIsTopmost);
    this.FinalizeLayout(bCenterWindow);
    return (uint) window;
  }

  public unsafe uint InitWindow(
    HWND__* InParentWindowHandle,
    string InWindowTitle,
    string InWPFXamlFileName,
    int InPositionX,
    int InPositionY,
    int InWidth,
    int InHeight,
    [MarshalAs(UnmanagedType.U1)] bool bCenterWindow,
    int InFakeTitleBarHeight,
    int bInIsTopmost)
  {
    int window = (int) this.CreateWindow(InParentWindowHandle, InWindowTitle, InWPFXamlFileName, InPositionX, InPositionY, InWidth, InHeight, InFakeTitleBarHeight, 0, 1, bInIsTopmost);
    this.FinalizeLayout(bCenterWindow);
    return (uint) window;
  }

  public unsafe void ShowWindow([MarshalAs(UnmanagedType.U1)] bool bShouldShow) => \u003CModule\u003E.ShowWindow((HWND__*) this.InteropWindow.op_MemberSelection().Handle.ToPointer(), bShouldShow ? 5 : 0);

  public unsafe void EnableWindow([MarshalAs(UnmanagedType.U1)] bool bEnable) => \u003CModule\u003E.EnableWindow((HWND__*) this.InteropWindow.op_MemberSelection().Handle.ToPointer(), bEnable ? 1 : 0);

  public unsafe HWND__* GetWindowHandle() => (HWND__*) this.InteropWindow.op_MemberSelection().Handle.ToPointer();

  public Visual GetRootVisual() => this.InteropWindow.op_MemberSelection().RootVisual;

  protected unsafe uint CreateWindow(
    HWND__* InParentWindowHandle,
    string InWindowTitle,
    string InWPFXamlFileName,
    int InPositionX,
    int InPositionY,
    int InWidth,
    int InHeight,
    int InFakeTitleBarHeight,
    int InShowInTaskBar,
    int InAllowFrameDraw,
    int bInIsTopMost)
  {
    this.FakeTitleBarHeight = InFakeTitleBarHeight;
    FString fstring;
    FString* editorResourcesDir = \u003CModule\u003E.GetEditorResourcesDir(&fstring);
    string XamlFileName;
    // ISSUE: fault handler
    try
    {
      XamlFileName = string.Format("{0}WPF\\Controls\\{1}", (object) \u003CModule\u003E.CLRTools\u002EToString(editorResourcesDir), (object) InWPFXamlFileName);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
    int num1 = 0;
    int num2 = (IntPtr) InParentWindowHandle != 0L ? 1073741824 : num1;
    int WindowStyle = InFakeTitleBarHeight > 0 || InAllowFrameDraw == 0 ? num2 | int.MinValue : num2 | 12582912;
    int ExtendedWindowStyle = InShowInTaskBar != 0 ? 262144 : 128;
    if (bInIsTopMost != 0)
      ExtendedWindowStyle |= 8;
    int num3 = InPositionX;
    int num4 = InPositionY;
    bool bSizeToContent = InHeight == 0 || InWidth == 0;
    int X = InPositionX == -1 ? int.MinValue : num3;
    int Y = InPositionY == -1 ? int.MinValue : num4;
    this.InteropWindow.reset(\u003CModule\u003E.CLRTools\u002ECreateWPFWindowFromXaml(InParentWindowHandle, XamlFileName, InWindowTitle, X, Y, InWidth, InHeight, WindowStyle, ExtendedWindowStyle, 0, false, bSizeToContent));
    return 1;
  }

  protected unsafe void FinalizeLayout([MarshalAs(UnmanagedType.U1)] bool bCenterWindow)
  {
    this.InteropWindow.op_MemberSelection().AddHook(new HwndSourceHook(this.StaticMessageHookFunction));
    Visual rootVisual = this.InteropWindow.op_MemberSelection().RootVisual;
    FrameworkElement frameworkElement = (FrameworkElement) rootVisual;
    Button logicalNode = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "CloseButton");
    if (logicalNode != null)
      logicalNode.Click += new RoutedEventHandler(this.Callback_CloseButtonClicked);
    frameworkElement.UpdateLayout();
    HWND__* pointer = (HWND__*) this.InteropWindow.op_MemberSelection().Handle.ToPointer();
    if (!bCenterWindow)
      return;
    tagRECT tagRect;
    \u003CModule\u003E.GetWindowRect(pointer, &tagRect);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    int num1 = ^(int&) ((IntPtr) &tagRect + 8) - ^(int&) ref tagRect;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    int num2 = ^(int&) ((IntPtr) &tagRect + 12) - ^(int&) ((IntPtr) &tagRect + 4);
    wxRect wxRect1;
    \u003CModule\u003E.wxRect\u002E\u007Bctor\u007D(&wxRect1);
    if ((IntPtr) \u003CModule\u003E.GApp != IntPtr.Zero)
    {
      WxUnrealEdApp* wxUnrealEdAppPtr = (WxUnrealEdApp*) ((IntPtr) \u003CModule\u003E.GApp + 172L);
      if (*(long*) wxUnrealEdAppPtr != 0L)
      {
        wxRect wxRect2;
        wxRect* rect = \u003CModule\u003E.wxWindowBase\u002EGetRect((wxWindowBase*) *(long*) wxUnrealEdAppPtr, &wxRect2);
        // ISSUE: cpblk instruction
        __memcpy(ref wxRect1, (IntPtr) rect, 16);
        goto label_7;
      }
    }
    \u003CModule\u003E.GetClientRect(\u003CModule\u003E.GetDesktopWindow(), &tagRect);
    wxRect wxRect3;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    wxRect* wxRectPtr = \u003CModule\u003E.wxRect\u002E\u007Bctor\u007D(&wxRect3, ^(int&) ref tagRect, ^(int&) ((IntPtr) &tagRect + 4), ^(int&) ((IntPtr) &tagRect + 8) - ^(int&) ref tagRect, ^(int&) ((IntPtr) &tagRect + 12) - ^(int&) ((IntPtr) &tagRect + 4));
    // ISSUE: cpblk instruction
    __memcpy(ref wxRect1, (IntPtr) wxRectPtr, 16);
label_7:
    int num3 = (\u003CModule\u003E.wxRect\u002EGetWidth(&wxRect1) - num1) / 2;
    int num4 = \u003CModule\u003E.wxRect\u002EGetX(&wxRect1) + num3;
    int num5 = (\u003CModule\u003E.wxRect\u002EGetHeight(&wxRect1) - num2) / 2;
    int num6 = \u003CModule\u003E.wxRect\u002EGetY(&wxRect1) + num5;
    \u003CModule\u003E.SetWindowPos(pointer, (HWND__*) 0L, num4, num6, 0, 0, 5U);
  }

  protected IntPtr StaticMessageHookFunction(
    IntPtr HWnd,
    int Msg,
    IntPtr WParam,
    IntPtr LParam,
    ref bool OutHandled)
  {
    return this.VirtualMessageHookFunction(HWnd, Msg, WParam, LParam, ref OutHandled);
  }

  protected virtual unsafe IntPtr VirtualMessageHookFunction(
    IntPtr HWnd,
    int Msg,
    IntPtr WParam,
    IntPtr LParam,
    ref bool OutHandled)
  {
    OutHandled = false;
    int num1 = 0;
    switch (Msg)
    {
      case 16:
        this.InteropWindow.reset((HwndSource) null);
        OutHandled = true;
        break;
      case 61:
        num1 = 0;
        OutHandled = true;
        break;
      case 135:
        num1 = 4;
        OutHandled = true;
        break;
    }
    if (this.FakeTitleBarHeight > 0 && Msg == 132)
    {
      if ((ushort) ((uint) \u003CModule\u003E.GetAsyncKeyState(1) & 32768U) != (ushort) 0 && \u003CModule\u003E.GetSystemMetrics(23) == 0 || (ushort) ((uint) \u003CModule\u003E.GetAsyncKeyState(2) & 32768U) != (ushort) 0 && \u003CModule\u003E.GetSystemMetrics(23) != 0)
      {
        HWND__* hwndPtr = (HWND__*) (long) HWnd;
        long num2 = (long) WParam;
        long num3 = (long) LParam;
        num1 = (int) \u003CModule\u003E.DefWindowProcW(hwndPtr, 132U, (ulong) num2, num3);
        OutHandled = true;
        if (num1 == 1)
        {
          tagRECT tagRect;
          \u003CModule\u003E.GetWindowRect(hwndPtr, &tagRect);
          int num4 = (int) (short) (uint) num3;
          int num5 = (int) (short) (uint) ((ulong) num3 >> 16);
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          if (num4 >= ^(int&) ref tagRect && num4 < ^(int&) ((IntPtr) &tagRect + 8) - this.FakeTitleBarButtonWidth && (num5 >= ^(int&) ((IntPtr) &tagRect + 4) && num5 < this.FakeTitleBarHeight + ^(int&) ((IntPtr) &tagRect + 4)))
            num1 = 2;
        }
      }
    }
    else if (Msg == 256 || Msg == 260)
    {
      uint num2 = (uint) (int) (long) WParam;
      uint num3 = Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.LeftCtrl) ? 1U : 0U;
      uint num4 = Keyboard.IsKeyDown(Key.RightShift) || Keyboard.IsKeyDown(Key.LeftShift) ? 1U : 0U;
      uint num5 = Keyboard.IsKeyDown(Key.RightAlt) || Keyboard.IsKeyDown(Key.LeftAlt) ? 1U : 0U;
      FName fname1;
      \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname1);
      switch (num2)
      {
        case 9:
          FName fname2;
          FName* fnamePtr1 = \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_17BJDGDONN\u0040\u003F\u0024AAT\u003F\u0024AAa\u003F\u0024AAb\u003F\u0024AA\u003F\u0024AA\u0040, (EFindName) 1, 1U);
          // ISSUE: cpblk instruction
          __memcpy(ref fname1, (IntPtr) fnamePtr1, 8);
          break;
        case 13:
          FName fname3;
          FName* fnamePtr2 = \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1M\u0040FCNBKECH\u0040\u003F\u0024AAE\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (EFindName) 1, 1U);
          // ISSUE: cpblk instruction
          __memcpy(ref fname1, (IntPtr) fnamePtr2, 8);
          break;
        case 70:
          FName fname4;
          FName* fnamePtr3 = \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname4, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_13GAMECHAC\u0040\u003F\u0024AAF\u003F\u0024AA\u003F\u0024AA\u0040, (EFindName) 1, 1U);
          // ISSUE: cpblk instruction
          __memcpy(ref fname1, (IntPtr) fnamePtr3, 8);
          break;
        case 122:
          FName fname5;
          FName* fnamePtr4 = \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname5, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_17PCJOKADA\u0040\u003F\u0024AAF\u003F\u0024AA1\u003F\u0024AA1\u003F\u0024AA\u003F\u0024AA\u0040, (EFindName) 1, 1U);
          // ISSUE: cpblk instruction
          __memcpy(ref fname1, (IntPtr) fnamePtr4, 8);
          break;
        default:
          goto label_16;
      }
      int num6 = (int) \u003CModule\u003E.WxUnrealEdApp\u002ECheckIfGlobalHotkey(fname1, num3, num4, num5);
    }
label_16:
    return (IntPtr) num1;
  }

  protected void Callback_CloseButtonClicked(object Sender, RoutedEventArgs Args) => this.InteropWindow.reset((HwndSource) null);

  [HandleProcessCorruptedStateExceptions]
  protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      try
      {
        this.\u007EMWPFWindowWrapper();
      }
      finally
      {
        this.InteropWindow.Dispose();
      }
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

  ~MWPFWindowWrapper() => this.Dispose(false);
}
