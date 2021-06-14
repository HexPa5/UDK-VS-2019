// Decompiled with JetBrains decompiler
// Type: MLevelViewportHwndHost
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;

internal class MLevelViewportHwndHost : HwndHost
{
  private ELevelViewportType InitialViewportType;
  private unsafe FEditorLevelViewportClient* LevelViewportClient;
  private uint bUseJoystickCatpure;

  public unsafe MLevelViewportHwndHost(
    ELevelViewportType InViewportType,
    TStaticBitArray\u003C128\u003E InShowFlags)
  {
    this.InitialViewportType = InViewportType;
    this.LevelViewportClient = (FEditorLevelViewportClient*) 0L;
    this.bUseJoystickCatpure = 0U;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    // ISSUE: fault handler
    try
    {
      FEditorLevelViewportClient* levelViewportClientPtr1 = (FEditorLevelViewportClient*) \u003CModule\u003E.@new(1424UL);
      FEditorLevelViewportClient* levelViewportClientPtr2;
      // ISSUE: fault handler
      try
      {
        levelViewportClientPtr2 = (IntPtr) levelViewportClientPtr1 == IntPtr.Zero ? (FEditorLevelViewportClient*) 0L : \u003CModule\u003E.FEditorLevelViewportClient\u002E\u007Bctor\u007D(levelViewportClientPtr1, (UClass*) 0L);
      }
      __fault
      {
        \u003CModule\u003E.delete((void*) levelViewportClientPtr1);
      }
      this.LevelViewportClient = levelViewportClientPtr2;
      *(int*) ((IntPtr) levelViewportClientPtr2 + 80L) = (int) this.InitialViewportType;
      *(int*) ((IntPtr) this.LevelViewportClient + 1044L) = 0;
      // ISSUE: cpblk instruction
      __memcpy((IntPtr) this.LevelViewportClient + 96L, ref InShowFlags, 16);
      // ISSUE: cpblk instruction
      __memcpy((IntPtr) this.LevelViewportClient + 112L, ref InShowFlags, 16);
      \u003CModule\u003E.FEditorLevelViewportClient\u002ESetRealtime(this.LevelViewportClient, 1U, 0U);
      // ISSUE: cpblk instruction
      __memcpy((IntPtr) this.LevelViewportClient + 40L, ref \u003CModule\u003E.EditorViewportDefs\u002E\u003FA0x3a4a4fc4\u002EDefaultPerspectiveViewLocation, 12);
      // ISSUE: cpblk instruction
      __memcpy((IntPtr) this.LevelViewportClient + 64L, ref \u003CModule\u003E.EditorViewportDefs\u002E\u003FA0x3a4a4fc4\u002EDefaultPerspectiveViewRotation, 12);
    }
    __fault
    {
      this.Dispose(true);
    }
  }

  public unsafe FEditorLevelViewportClient* GetLevelViewportClient() => this.LevelViewportClient;

  public unsafe void CaptureJoystickInput(uint bInJoystickCapture)
  {
    this.bUseJoystickCatpure = bInJoystickCapture;
    ulong num1 = (ulong) *(long*) ((IntPtr) this.LevelViewportClient + 32L);
    if (num1 == 0UL)
      return;
    long num2 = (long) num1;
    int num3 = (int) bInJoystickCapture;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    int num4 = (int) __calli((__FnPtr<uint (IntPtr, uint)>) *(long*) (*(long*) num1 + 128L))((uint) num2, (IntPtr) num3);
  }

  protected override unsafe HandleRef BuildWindowCore(HandleRef hwndParent)
  {
    IntPtr handle = hwndParent.Handle;
    long num1 = *(long*) *(long*) ((IntPtr) \u003CModule\u003E.GEngine + 1732L) + 648L;
    IntPtr num2 = (IntPtr) this.LevelViewportClient + 32L;
    long num3 = *(long*) ((IntPtr) \u003CModule\u003E.GEngine + 1732L);
    FEditorLevelViewportClient* levelViewportClient = this.LevelViewportClient;
    long num4 = (long) handle;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    FViewport* fviewportPtr = __calli((__FnPtr<FViewport* (IntPtr, FViewportClient*, void*, uint, uint, int, int)>) *(long*) num1)((int) num3, (int) levelViewportClient, (uint) num4, 0U, (void*) 0, (FViewportClient*) -1, new IntPtr(-1));
    *(long*) num2 = (long) fviewportPtr;
    MLevelViewportHwndHost viewportHwndHost = this;
    viewportHwndHost.CaptureJoystickInput(viewportHwndHost.bUseJoystickCatpure);
    long num5 = *(long*) ((IntPtr) this.LevelViewportClient + 32L);
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    return new HandleRef((object) this, (IntPtr) (long) __calli((__FnPtr<void* (IntPtr)>) *(long*) (*(long*) num5 + 56L))((IntPtr) num5));
  }

  protected override unsafe void DestroyWindowCore(HandleRef hwnd)
  {
    long num1 = *(long*) ((IntPtr) \u003CModule\u003E.GEngine + 1732L);
    long num2 = num1;
    long num3 = *(long*) ((IntPtr) this.LevelViewportClient + 32L);
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr, FViewport*)>) *(long*) (*(long*) num1 + 656L))((FViewport*) num2, (IntPtr) num3);
    *(long*) ((IntPtr) this.LevelViewportClient + 32L) = 0L;
    FEditorLevelViewportClient* levelViewportClient = this.LevelViewportClient;
    if ((IntPtr) levelViewportClient != IntPtr.Zero)
    {
      FEditorLevelViewportClient* levelViewportClientPtr1 = (FEditorLevelViewportClient*) ((IntPtr) levelViewportClient + 16L);
      FEditorLevelViewportClient* levelViewportClientPtr2 = levelViewportClientPtr1;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      void* voidPtr = __calli((__FnPtr<void* (IntPtr, uint)>) *(long*) *(long*) levelViewportClientPtr1)((uint) levelViewportClientPtr2, new IntPtr(1));
    }
    this.LevelViewportClient = (FEditorLevelViewportClient*) 0L;
  }

  protected override IntPtr WndProc(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    return IntPtr.Zero;
  }
}
