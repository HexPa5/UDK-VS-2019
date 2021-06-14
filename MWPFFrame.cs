// Decompiled with JetBrains decompiler
// Type: MWPFFrame
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

internal class MWPFFrame : MWPFWindowWrapper
{
  private uint bModalComplete;
  private int DialogResult;
  private Border EventBorder;
  private string HelpURL;
  private string ContextName;
  private unsafe wxDialog* WxDialog;
  private uint bCenterWindow;
  private uint bResizeable;
  private uint bUseSaveLayout;

  public unsafe MWPFFrame(
    wxWindow* InParentWindow,
    WPFFrameInitStruct InSettings,
    FString* InContextName)
  {
    // ISSUE: fault handler
    try
    {
      this.ContextName = new string(\u003CModule\u003E.FString\u002E\u002A(InContextName), 0, \u003CModule\u003E.FString\u002ELen(InContextName));
      HWND__* InParentWindowHandle = (HWND__*) 0L;
      if (InSettings.bUseWxDialog != 0U)
      {
        wxDialog* wxDialogPtr1 = (wxDialog*) \u003CModule\u003E.@new(688UL);
        wxDialog* wxDialogPtr2;
        // ISSUE: fault handler
        try
        {
          if ((IntPtr) wxDialogPtr1 != IntPtr.Zero)
          {
            \u003CModule\u003E.wxDialog\u002E\u007Bctor\u007D(wxDialogPtr1);
            *(long*) wxDialogPtr1 = (long) &\u003CModule\u003E.\u003F\u003F_SwxDialog\u0040\u00406B\u0040;
            wxDialogPtr2 = wxDialogPtr1;
          }
          else
            wxDialogPtr2 = (wxDialog*) 0L;
        }
        __fault
        {
          \u003CModule\u003E.delete((void*) wxDialogPtr1);
        }
        this.WxDialog = wxDialogPtr2;
        wxString wxString1;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, (char*) ^(long&) ref \u003CModule\u003E.__imp_wxDialogNameStr);
        // ISSUE: fault handler
        try
        {
          wxString wxString2;
          \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D157);
          // ISSUE: fault handler
          try
          {
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            \u003CModule\u003E.wxDialog\u002ECreate(this.WxDialog, InParentWindow, -1, &wxString2, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition, (wxSize*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultSize, 0, &wxString1);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString2);
          }
          \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString1);
        }
        \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString1);
        wxDialog* wxDialog = this.WxDialog;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        InParentWindowHandle = (HWND__*) __calli((__FnPtr<void* (IntPtr)>) *(long*) (*(long*) wxDialog + 944L))((IntPtr) wxDialog);
      }
      else
        this.WxDialog = (wxDialog*) 0L;
      int window = (int) this.CreateWindow(InParentWindowHandle, "WPFFrame", "EmptyFrame.xaml", InSettings.PositionX, InSettings.PositionY, 0, 0, 0, (int) InSettings.bShowInTaskBar, 0, (int) InSettings.bForceToFront);
      this.bModalComplete = 0U;
      ((ContentControl) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.InteropWindow.op_MemberSelection().RootVisual, "TitleLabel")).Content = (object) InSettings.WindowTitle;
      Button logicalNode1 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.InteropWindow.op_MemberSelection().RootVisual, "TitleBarCloseButton");
      logicalNode1.Click += new RoutedEventHandler(this.CloseButtonClicked);
      if (InSettings.bShowCloseButton == 0U)
        logicalNode1.Visibility = Visibility.Hidden;
      else
        this.FakeTitleBarButtonWidth = (int) (logicalNode1.ActualWidth + (double) this.FakeTitleBarButtonWidth);
      Button logicalNode2 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.InteropWindow.op_MemberSelection().RootVisual, "TitleBarHelpButton");
      logicalNode2.Click += new RoutedEventHandler(this.HelpButtonClicked);
      if (InSettings.WindowHelpURL == (string) null)
      {
        logicalNode2.Visibility = Visibility.Hidden;
      }
      else
      {
        this.HelpURL = InSettings.WindowHelpURL;
        this.FakeTitleBarButtonWidth = (int) (logicalNode2.ActualWidth + (double) this.FakeTitleBarButtonWidth);
      }
      logicalNode2.Visibility = Visibility.Hidden;
      MWPFFrame mwpfFrame = this;
      mwpfFrame.EventBorder = (Border) LogicalTreeHelper.FindLogicalNode((DependencyObject) mwpfFrame.InteropWindow.op_MemberSelection().RootVisual, nameof (EventBorder));
      this.InteropWindow.op_MemberSelection().AddHook(new HwndSourceHook(this.FrameMessageHookFunction));
      this.bCenterWindow = InSettings.bCenterWindow;
      this.bResizeable = InSettings.bResizable;
      this.bUseSaveLayout = InSettings.bUseSaveLayout;
    }
    __fault
    {
      base.Dispose(true);
    }
  }

  private unsafe void \u007EMWPFFrame()
  {
    if ((IntPtr) this.WxDialog == IntPtr.Zero)
      return;
    this.SaveLayout();
    wxDialog* wxDialog = this.WxDialog;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    int num = (int) __calli((__FnPtr<byte (IntPtr)>) *(long*) (*(long*) wxDialog + 112L))((IntPtr) wxDialog);
    this.WxDialog = (wxDialog*) 0L;
  }

  public unsafe int SetContentAndShowModal(MWPFPanel InPanel, int InDefaultDialogResult)
  {
    this.DialogResult = InDefaultDialogResult;
    this.LayoutWindow((ContentControl) InPanel);
    InPanel.SetParentFrame(this);
    InPanel.PostLayout();
    if ((IntPtr) this.WxDialog != IntPtr.Zero)
    {
      FCallbackEventObserver* gcallbackEvent1 = \u003CModule\u003E.GCallbackEvent;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, ECallbackEventType)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 72L))((ECallbackEventType) gcallbackEvent1, new IntPtr(65));
      wxDialog* wxDialog1 = this.WxDialog;
      wxDialog* wxDialogPtr1 = wxDialog1;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, byte)>) *(long*) (*(long*) wxDialog1 + 376L))((byte) wxDialogPtr1, new IntPtr(1));
      wxDialog* wxDialog2 = this.WxDialog;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      int num = __calli((__FnPtr<int (IntPtr)>) *(long*) (*(long*) wxDialog2 + 1528L))((IntPtr) wxDialog2);
      wxDialog* wxDialog3 = this.WxDialog;
      wxDialog* wxDialogPtr2 = wxDialog3;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, byte)>) *(long*) (*(long*) wxDialog3 + 376L))((byte) wxDialogPtr2, IntPtr.Zero);
      FCallbackEventObserver* gcallbackEvent2 = \u003CModule\u003E.GCallbackEvent;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, ECallbackEventType)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 72L))((ECallbackEventType) gcallbackEvent2, new IntPtr(66));
    }
    else
    {
      \u003CModule\u003E.ShowWindow(this.GetWindowHandle(), 5);
      if (this.bModalComplete == 0U)
      {
        do
        {
          tagMSG tagMsg;
          if (\u003CModule\u003E.PeekMessageW(&tagMsg, (HWND__*) 0L, 0U, 0U, 1U) != 0)
          {
            do
            {
              \u003CModule\u003E.TranslateMessage(&tagMsg);
              \u003CModule\u003E.DispatchMessageW(&tagMsg);
            }
            while (\u003CModule\u003E.PeekMessageW(&tagMsg, (HWND__*) 0L, 0U, 0U, 1U) != 0);
          }
        }
        while (this.bModalComplete == 0U);
      }
    }
    return this.DialogResult;
  }

  public unsafe void SetContentAndShow(MWPFPanel InPanel)
  {
    this.LayoutWindow((ContentControl) InPanel);
    InPanel.SetParentFrame(this);
    InPanel.PostLayout();
    wxDialog* wxDialog = this.WxDialog;
    if ((IntPtr) wxDialog != IntPtr.Zero)
    {
      wxDialog* wxDialogPtr = wxDialog;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      int num = (int) __calli((__FnPtr<byte (IntPtr, byte)>) *(long*) (*(long*) wxDialog + 304L))((byte) wxDialogPtr, new IntPtr(1));
    }
    else
      \u003CModule\u003E.ShowWindow(this.GetWindowHandle(), 5);
  }

  public unsafe void SetContentAndShowComposite(
    ContentControl InControl,
    List<MWPFPanel> InPaneList)
  {
    this.LayoutWindow(InControl);
    int index = 0;
    if (0 < InPaneList.Count)
    {
      do
      {
        MWPFPanel inPane = InPaneList[index];
        inPane.SetParentFrame(this);
        inPane.PostLayout();
        ++index;
      }
      while (index < InPaneList.Count);
    }
    wxDialog* wxDialog = this.WxDialog;
    if ((IntPtr) wxDialog != IntPtr.Zero)
    {
      wxDialog* wxDialogPtr = wxDialog;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      int num = (int) __calli((__FnPtr<byte (IntPtr, byte)>) *(long*) (*(long*) wxDialog + 304L))((byte) wxDialogPtr, new IntPtr(1));
    }
    else
      \u003CModule\u003E.ShowWindow(this.GetWindowHandle(), 5);
  }

  public unsafe void Close(int InDialogResult)
  {
    this.SaveLayout();
    \u003CModule\u003E.ShowWindow(this.GetWindowHandle(), 0);
    this.bModalComplete = 1U;
    this.DialogResult = InDialogResult;
    wxDialog* wxDialog1 = this.WxDialog;
    if ((IntPtr) wxDialog1 == IntPtr.Zero)
      return;
    wxDialog* wxDialogPtr1 = wxDialog1;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    if (__calli((__FnPtr<byte (IntPtr)>) *(long*) (*(long*) wxDialogPtr1 + 1544L))((IntPtr) wxDialogPtr1) != (byte) 0)
    {
      wxDialog* wxDialog2 = this.WxDialog;
      wxDialog* wxDialogPtr2 = wxDialog2;
      int dialogResult = this.DialogResult;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, int)>) *(long*) (*(long*) wxDialog2 + 1536L))((int) wxDialogPtr2, (IntPtr) dialogResult);
    }
    \u003CModule\u003E.wxWindowBase\u002EHide((wxWindowBase*) this.WxDialog);
  }

  public unsafe void Raise()
  {
    wxDialog* wxDialog = this.WxDialog;
    if ((IntPtr) wxDialog == IntPtr.Zero)
      return;
    wxDialog* wxDialogPtr = wxDialog;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) wxDialogPtr + 176L))((IntPtr) wxDialogPtr);
  }

  public unsafe void SaveLayout()
  {
    if (this.bUseSaveLayout == 0U)
      return;
    wxDialog* wxDialog = this.WxDialog;
    if ((IntPtr) wxDialog == IntPtr.Zero)
      return;
    wxDialog* wxDialogPtr = wxDialog;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    if (__calli((__FnPtr<byte (IntPtr)>) *(long*) (*(long*) wxDialogPtr + 320L))((IntPtr) wxDialogPtr) == (byte) 0)
      return;
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.ContextName);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FWindowUtil\u002ESavePosSize(fstring2, (wxTopLevelWindow*) this.WxDialog);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
  }

  public Border GetEventBorder() => this.EventBorder;

  public void CloseButtonClicked(object Owner, RoutedEventArgs Args)
  {
    MWPFFrame mwpfFrame = this;
    mwpfFrame.Close(mwpfFrame.DialogResult);
  }

  public unsafe void HelpButtonClicked(object Owner, RoutedEventArgs Args)
  {
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.HelpURL);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.appLaunchURL(\u003CModule\u003E.FString\u002E\u002A(fstring2), (char*) 0L, (FString*) 0L);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
  }

  private unsafe void LayoutWindow(ContentControl InPanel)
  {
    ((Decorator) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.InteropWindow.op_MemberSelection().RootVisual, "ContentBorder")).Child = (UIElement) InPanel;
    this.FinalizeLayout(this.bCenterWindow != 0U);
    \u003CModule\u003E.ShowWindow(this.GetWindowHandle(), 5);
    this.FakeTitleBarHeight = (int) ((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.InteropWindow.op_MemberSelection().RootVisual, "TitlePanel")).ActualHeight;
    if ((IntPtr) this.WxDialog == IntPtr.Zero)
      return;
    tagRECT tagRect;
    \u003CModule\u003E.GetWindowRect((HWND__*) this.InteropWindow.op_MemberSelection().Handle.ToPointer(), &tagRect);
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
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    \u003CModule\u003E.wxWindowBase\u002ESetSize((wxWindowBase*) this.WxDialog, ^(int&) ref tagRect, ^(int&) ((IntPtr) &tagRect + 4), num1, num2, 3);
    if (this.bUseSaveLayout != 0U)
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.ContextName);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FWindowUtil\u002ELoadPosSize(fstring2, (wxTopLevelWindow*) this.WxDialog, -1, -1, -1, -1);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    }
    wxPoint wxPoint1;
    wxPoint* position = \u003CModule\u003E.wxWindowBase\u002EGetPosition((wxWindowBase*) this.WxDialog, &wxPoint1);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ^(int&) ref tagRect = *(int*) position;
    wxPoint wxPoint2;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ^(int&) ((IntPtr) &tagRect + 4) = *(int*) ((IntPtr) \u003CModule\u003E.wxWindowBase\u002EGetPosition((wxWindowBase*) this.WxDialog, &wxPoint2) + 4L);
    if (this.bResizeable != 0U)
    {
      wxSize wxSize1;
      num1 = \u003CModule\u003E.wxSize\u002EGetWidth(\u003CModule\u003E.wxWindowBase\u002EGetSize((wxWindowBase*) this.WxDialog, &wxSize1));
      wxSize wxSize2;
      num2 = \u003CModule\u003E.wxSize\u002EGetHeight(\u003CModule\u003E.wxWindowBase\u002EGetSize((wxWindowBase*) this.WxDialog, &wxSize2));
    }
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ^(int&) ((IntPtr) &tagRect + 8) = ^(int&) ref tagRect + num1;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ^(int&) ((IntPtr) &tagRect + 12) = ^(int&) ((IntPtr) &tagRect + 4) + num2;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    \u003CModule\u003E.SetWindowPos((HWND__*) this.InteropWindow.op_MemberSelection().Handle.ToPointer(), (HWND__*) 0L, ^(int&) ref tagRect, ^(int&) ((IntPtr) &tagRect + 4), num1, num2, 4U);
  }

  private unsafe IntPtr FrameMessageHookFunction(
    IntPtr HWnd,
    int Msg,
    IntPtr WParam,
    IntPtr LParam,
    ref bool OutHandled)
  {
    OutHandled = false;
    if ((IntPtr) this.WxDialog != IntPtr.Zero)
    {
      if (Msg == 71 || Msg == 70)
      {
        tagRECT tagRect;
        \u003CModule\u003E.GetWindowRect((HWND__*) this.InteropWindow.op_MemberSelection().Handle.ToPointer(), &tagRect);
        wxRect wxRect;
        \u003CModule\u003E.wxWindowBase\u002EGetRect((wxWindowBase*) this.WxDialog, &wxRect);
        int left = \u003CModule\u003E.wxRect\u002EGetLeft(&wxRect);
        int top = \u003CModule\u003E.wxRect\u002EGetTop(&wxRect);
        int num1 = \u003CModule\u003E.wxRect\u002EGetWidth(&wxRect) + left;
        int num2 = \u003CModule\u003E.wxRect\u002EGetHeight(&wxRect) + top;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        if (left != ^(int&) ref tagRect || top != ^(int&) ((IntPtr) &tagRect + 4) || (num1 != ^(int&) ((IntPtr) &tagRect + 8) || num2 != ^(int&) ((IntPtr) &tagRect + 12)))
        {
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
          \u003CModule\u003E.wxWindowBase\u002ESetSize((wxWindowBase*) this.WxDialog, ^(int&) ref tagRect, ^(int&) ((IntPtr) &tagRect + 4), ^(int&) ((IntPtr) &tagRect + 8) - ^(int&) ref tagRect, ^(int&) ((IntPtr) &tagRect + 12) - ^(int&) ((IntPtr) &tagRect + 4), 3);
          wxDialog* wxDialog = this.WxDialog;
          if ((IntPtr) wxDialog != IntPtr.Zero)
          {
            wxDialog* wxDialogPtr = wxDialog;
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) wxDialogPtr + 176L))((IntPtr) wxDialogPtr);
          }
        }
        OutHandled = true;
      }
      if (Msg == 33)
      {
        wxDialog* wxDialog = this.WxDialog;
        if ((IntPtr) wxDialog != IntPtr.Zero)
        {
          wxDialog* wxDialogPtr = wxDialog;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) wxDialogPtr + 176L))((IntPtr) wxDialogPtr);
        }
      }
    }
    return (IntPtr) 0;
  }

  [HandleProcessCorruptedStateExceptions]
  protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      try
      {
        this.\u007EMWPFFrame();
      }
      finally
      {
        base.Dispose(true);
      }
    }
    else
      base.Dispose(false);
  }
}
