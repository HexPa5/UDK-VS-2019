// Decompiled with JetBrains decompiler
// Type: MatineeWindows.MDirectorViewportLayoutPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MatineeWindows
{
  internal class MDirectorViewportLayoutPanel : MWPFPanel
  {
    private DockPanel ViewportDockPanel;

    public MDirectorViewportLayoutPanel(string InXamlName)
      : base(InXamlName)
    {
      MDirectorViewportLayoutPanel viewportLayoutPanel = this;
      viewportLayoutPanel.ViewportDockPanel = (DockPanel) LogicalTreeHelper.FindLogicalNode((DependencyObject) viewportLayoutPanel, nameof (ViewportDockPanel));
    }

    public override void SetParentFrame(MWPFFrame InParentFrame) => base.SetParentFrame(InParentFrame);

    public void SetPreviewViewport(MViewportPanel InNewPreviewPanel) => ((Decorator) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "PreviewBorder")).Child = (UIElement) InNewPreviewPanel;

    public void SetControlPanel(MDirectorControlPanel InNewControlPanel) => ((Decorator) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ControlBorder")).Child = (UIElement) InNewControlPanel;

    public void AddViewport(MViewportPanel InNewViewportPanel) => this.ViewportDockPanel.Children.Add((UIElement) InNewViewportPanel);

    public void OnKeyPressed(object Sender, KeyEventArgs EventArgs)
    {
    }
  }
}
