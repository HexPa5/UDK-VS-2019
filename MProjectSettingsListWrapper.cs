// Decompiled with JetBrains decompiler
// Type: MProjectSettingsListWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class MProjectSettingsListWrapper : INotifyPropertyChanged
{
  private int ListIndex;
  private unsafe FUserProjectSettingsListInfo* ProjectSettingsInfo;

  public virtual event PropertyChangedEventHandler PropertyChanged;

  [SpecialName]
  protected virtual void raise_PropertyChanged(object value0, PropertyChangedEventArgs value1)
  {
    PropertyChangedEventHandler storePropertyChanged = this.\u003Cbacking_store\u003EPropertyChanged;
    if (storePropertyChanged == null)
      return;
    storePropertyChanged(value0, value1);
  }

  public unsafe MProjectSettingsListWrapper(int InIndex, FUserProjectSettingsListInfo* InListInfo)
  {
    this.ListIndex = InIndex;
    this.ProjectSettingsInfo = InListInfo;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public int Index => this.ListIndex;

  public unsafe string SettingKey
  {
    get
    {
      FString* fstringPtr = (FString*) *(long*) this.ProjectSettingsInfo;
      return new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
    }
    set
    {
    }
  }

  public unsafe string SettingKeyDisplayName
  {
    get
    {
      FString fstring;
      FString* settingDisplayName = \u003CModule\u003E.FUserProjSetting\u002EGetSettingDisplayName((FUserProjSetting*) *(long*) this.ProjectSettingsInfo, &fstring);
      string str;
      try
      {
        str = new string(\u003CModule\u003E.FString\u002E\u002A(settingDisplayName), 0, \u003CModule\u003E.FString\u002ELen(settingDisplayName));
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      return str;
    }
    set
    {
    }
  }

  public unsafe string SettingValue
  {
    get
    {
      FString* fstringPtr = (FString*) (*(long*) this.ProjectSettingsInfo + 16L);
      return new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
    }
    set
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, value);
      try
      {
        \u003CModule\u003E.FString\u002E\u003D((FString*) (*(long*) this.ProjectSettingsInfo + 16L), fstring2);
      }
      __fault
      {
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    }
  }

  public unsafe bool IsSelected
  {
    [return: MarshalAs(UnmanagedType.U1)] get => *(int*) ((IntPtr) this.ProjectSettingsInfo + 8L) != 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      *(int*) ((IntPtr) this.ProjectSettingsInfo + 8L) = value ? 1 : 0;
      MProjectSettingsListWrapper settingsListWrapper = this;
      settingsListWrapper.raise_PropertyChanged((object) settingsListWrapper, new PropertyChangedEventArgs(nameof (IsSelected)));
    }
  }
}
