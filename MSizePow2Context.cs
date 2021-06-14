// Decompiled with JetBrains decompiler
// Type: MSizePow2Context
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Windows.Controls;

internal class MSizePow2Context : MInputDataContext\u003Cint\u003E
{
  public CheckBox mRatioLock;
  public ComboBox mOtherSize;
  public bool mSkipUpdate;

  public MSizePow2Context()
  {
    this.mInputPtr = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E();
    this.mGraphPtr = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
