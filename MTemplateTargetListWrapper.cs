// Decompiled with JetBrains decompiler
// Type: MTemplateTargetListWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class MTemplateTargetListWrapper : INotifyPropertyChanged
{
  private int ListIndex;
  private unsafe FTemplateTargetListInfo* TemplateTargetInfo;

  public virtual event PropertyChangedEventHandler PropertyChanged;

  [SpecialName]
  protected virtual void raise_PropertyChanged(object value0, PropertyChangedEventArgs value1)
  {
    PropertyChangedEventHandler storePropertyChanged = this.\u003Cbacking_store\u003EPropertyChanged;
    if (storePropertyChanged == null)
      return;
    storePropertyChanged(value0, value1);
  }

  public unsafe MTemplateTargetListWrapper(int InIndex, FTemplateTargetListInfo* InTargetInfo)
  {
    this.ListIndex = InIndex;
    this.TemplateTargetInfo = InTargetInfo;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public int Index => this.ListIndex;

  public unsafe string TargetName
  {
    get
    {
      FString fstring;
      FString* name = \u003CModule\u003E.FProjWizTemplate\u002EGetName((FProjWizTemplate*) *(long*) this.TemplateTargetInfo, &fstring);
      string str;
      try
      {
        str = new string(\u003CModule\u003E.FString\u002E\u002A(name), 0, \u003CModule\u003E.FString\u002ELen(name));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      return str;
    }
  }

  public unsafe string Description
  {
    get
    {
      FString fstring;
      FString* description = \u003CModule\u003E.FProjWizTemplate\u002EGetDescription((FProjWizTemplate*) *(long*) this.TemplateTargetInfo, &fstring);
      string str;
      try
      {
        str = new string(\u003CModule\u003E.FString\u002E\u002A(description), 0, \u003CModule\u003E.FString\u002ELen(description));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      return str;
    }
  }

  public unsafe string KiloByteSize
  {
    get
    {
      char* chPtr = (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1M\u0040HAMADPKO\u0040\u003F\u0024AAK\u003F\u0024AAB\u003F\u0024AAy\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040;
      float num = (float) \u003CModule\u003E.FProjWizTemplate\u002EGetInstallSize((FProjWizTemplate*) *(long*) this.TemplateTargetInfo) * 0.0009765625f;
      if ((double) num > 1024.0)
      {
        chPtr = (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1M\u0040JPPNJKEO\u0040\u003F\u0024AAM\u003F\u0024AAB\u003F\u0024AAy\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040;
        num *= 0.0009765625f;
        if ((double) num > 1024.0)
        {
          chPtr = (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1M\u0040HFMKHCCP\u0040\u003F\u0024AAG\u003F\u0024AAB\u003F\u0024AAy\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040;
          num *= 0.0009765625f;
        }
      }
      FString fstring;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cfloat\u002Cwchar_t\u0020\u002A\u003E(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040FPJAHJMF\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AA5\u003F\u0024AA\u003F4\u003F\u0024AA2\u003F\u0024AAf\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA\u003F\u0024AA\u0040, num, chPtr);
      string str;
      try
      {
        str = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      return str;
    }
  }

  public unsafe bool IsSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) this.TemplateTargetInfo + 8L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      *(int*) ((IntPtr) this.TemplateTargetInfo + 8L) = value ? 1 : 0;
      MTemplateTargetListWrapper targetListWrapper = this;
      targetListWrapper.raise_PropertyChanged((object) targetListWrapper, new PropertyChangedEventArgs(nameof (IsSelected)));
    }
  }
}
