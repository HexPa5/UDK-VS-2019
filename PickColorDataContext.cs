// Decompiled with JetBrains decompiler
// Type: PickColorDataContext
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using CustomControls;

internal class PickColorDataContext
{
  public DragSlider mSliderRed;
  public DragSlider mSliderGreen;
  public DragSlider mSliderBlue;
  public DragSlider mSliderAlpha;
  public double StartR;
  public double StartG;
  public double StartB;
  public double StartA;
  public readonly MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E mInputPtr = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E();
  public readonly MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E mGraphPtr = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E();
  public uint ColorPickerIndex;
  public bool bSyncEnabled;
}
