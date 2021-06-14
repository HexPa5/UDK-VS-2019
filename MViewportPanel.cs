// Decompiled with JetBrains decompiler
// Type: MViewportPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

internal class MViewportPanel : MWPFPanel, IDisposable
{
  private unsafe WxInterpEd* InterpEd;
  private MLevelViewportHwndHost ViewportHost;
  private Border ViewportBorder;

  public unsafe MViewportPanel(string InXamlName, TStaticBitArray\u003C128\u003E InShowFlags)
    : base(InXamlName)
  {
    this.InterpEd = (WxInterpEd*) 0L;
    MViewportPanel mviewportPanel = this;
    mviewportPanel.ViewportBorder = (Border) LogicalTreeHelper.FindLogicalNode((DependencyObject) mviewportPanel, nameof (ViewportBorder));
    MLevelViewportHwndHost viewportHwndHost = new MLevelViewportHwndHost((ELevelViewportType) 3, InShowFlags);
    this.ViewportHost = viewportHwndHost;
    this.ViewportBorder.Child = (UIElement) viewportHwndHost;
  }

  private void \u007EMViewportPanel()
  {
    MLevelViewportHwndHost viewportHost = this.ViewportHost;
    if (viewportHost == null)
      return;
    viewportHost.Dispose();
    this.ViewportHost = (MLevelViewportHwndHost) null;
  }

  public override void SetParentFrame(MWPFFrame InParentFrame) => base.SetParentFrame(InParentFrame);

  public unsafe void ConnectToMatineeCamera(WxInterpEd* InInterpEd, int InCameraIndex)
  {
    this.InterpEd = InInterpEd;
    AActor* cameraActor = (AActor*) \u003CModule\u003E.WxInterpEd\u002EGetCameraActor(InInterpEd, InCameraIndex);
    \u003CModule\u003E.WxInterpEd\u002EAddExtraViewport(this.InterpEd, this.ViewportHost.GetLevelViewportClient(), cameraActor);
    *(int*) ((IntPtr) this.ViewportHost.GetLevelViewportClient() + 1052L) = 0;
    *(int*) ((IntPtr) this.ViewportHost.GetLevelViewportClient() + 1080L) = 1;
    \u003CModule\u003E.FEditorLevelViewportClient\u002ESetAllowMatineePreview(this.ViewportHost.GetLevelViewportClient(), 1U);
  }

  public unsafe void EnableMatineeRecording()
  {
    this.ViewportHost.CaptureJoystickInput(1U);
    \u003CModule\u003E.FEditorLevelViewportClient\u002ESetMatineeRecordingWindow(this.ViewportHost.GetLevelViewportClient(), this.InterpEd);
  }

  protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      this.\u007EMViewportPanel();
    }
    else
    {
      // ISSUE: explicit finalizer call
      this.Finalize();
    }
  }

  public virtual void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }
}
