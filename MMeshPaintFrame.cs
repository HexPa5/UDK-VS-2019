// Decompiled with JetBrains decompiler
// Type: MMeshPaintFrame
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;

internal class MMeshPaintFrame : MWPFFrame
{
  protected unsafe FEdModeMeshPaint* MeshPaintSystem;

  public unsafe MMeshPaintFrame(
    FEdModeMeshPaint* InMeshPaintSystem,
    wxWindow* InParentWindow,
    WPFFrameInitStruct InSettings,
    FString* InContextName)
    : base(InParentWindow, InSettings, InContextName)
  {
    // ISSUE: fault handler
    try
    {
      this.MeshPaintSystem = InMeshPaintSystem;
    }
    __fault
    {
      this.Dispose(true);
    }
  }

  protected override unsafe IntPtr VirtualMessageHookFunction(
    IntPtr HWnd,
    int Msg,
    IntPtr WParam,
    IntPtr LParam,
    ref bool OutHandled)
  {
    OutHandled = false;
    if (Msg >= 256 && (Msg <= 257 || Msg > 259 && (Msg <= 261 || Msg == 786)))
    {
      long num1 = (long) WParam;
      long num2 = (long) LParam;
      uint num3 = (uint) (int) num1;
      if ((num3 < 96U || num3 > 105U) && (num3 < 48U || num3 > 57U))
        \u003CModule\u003E.FEdModeMeshPaint\u002EAddWindowMessage(this.MeshPaintSystem, (uint) Msg, (ulong) num1, num2);
      if (OutHandled)
        return (IntPtr) 0;
    }
    return base.VirtualMessageHookFunction(HWnd, Msg, WParam, LParam, ref OutHandled);
  }
}
