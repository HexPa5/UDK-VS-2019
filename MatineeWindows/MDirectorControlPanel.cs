// Decompiled with JetBrains decompiler
// Type: MatineeWindows.MDirectorControlPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

namespace MatineeWindows
{
  internal class MDirectorControlPanel : MWPFPanel
  {
    private unsafe WxInterpEd* InterpEd;

    public MDirectorControlPanel(string InXamlName)
      : base(InXamlName)
    {
    }

    public override void SetParentFrame(MWPFFrame InParentFrame) => base.SetParentFrame(InParentFrame);

    public unsafe void SetMatinee(WxInterpEd* InInterpEd) => this.InterpEd = InInterpEd;
  }
}
