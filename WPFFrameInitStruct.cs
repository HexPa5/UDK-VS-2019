// Decompiled with JetBrains decompiler
// Type: WPFFrameInitStruct
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

internal class WPFFrameInitStruct
{
  public string WindowTitle;
  public string WindowHelpURL;
  public int PositionX;
  public int PositionY;
  public uint bCenterWindow;
  public uint bShowInTaskBar;
  public uint bShowCloseButton;
  public uint bResizable;
  public uint bForceToFront;
  public uint bUseWxDialog;
  public uint bUseSaveLayout;

  public WPFFrameInitStruct()
  {
    this.PositionX = 0;
    this.PositionY = 0;
    this.bCenterWindow = 1U;
    this.bShowInTaskBar = 0U;
    this.bShowCloseButton = 1U;
    this.bResizable = 0U;
    this.bForceToFront = 0U;
    this.bUseWxDialog = 1U;
    this.bUseSaveLayout = 1U;
  }
}
