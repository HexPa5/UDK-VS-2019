// Decompiled with JetBrains decompiler
// Type: MGameAssetJournalBase
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

internal abstract class MGameAssetJournalBase
{
  protected static readonly string UnknownBranchName = "UNKNOWN_BRANCH";

  [return: MarshalAs(UnmanagedType.U1)]
  public abstract bool QueryJournalEntries(
    out List<MGameAssetJournalEntry> OutJournalEntries,
    [MarshalAs(UnmanagedType.U1)] bool bFilterBranchAndGame);

  [return: MarshalAs(UnmanagedType.U1)]
  public abstract bool SendJournalEntries(List<MGameAssetJournalEntry> JournalEntries);

  [return: MarshalAs(UnmanagedType.U1)]
  public bool SendJournalEntry(MGameAssetJournalEntry JournalEntry) => this.SendJournalEntries(new List<MGameAssetJournalEntry>(1)
  {
    JournalEntry
  });

  [return: MarshalAs(UnmanagedType.U1)]
  public static unsafe bool CreateStringFromJournalEntry(
    MGameAssetJournalEntry JournalEntry,
    out string OutString)
  {
    OutString = (string) null;
    string str1 = MGameAssetJournalBase.QueryBranchName();
    if (str1.Length == 0)
      return false;
    FString fstring1;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.GGameName);
    string str2;
    // ISSUE: fault handler
    try
    {
      str2 = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring1), 0, \u003CModule\u003E.FString\u002ELen(&fstring1));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    StringBuilder stringBuilder = new StringBuilder();
    int entryVersionNumber = GADDefs.JournalEntryVersionNumber;
    stringBuilder.Append(entryVersionNumber.ToString());
    stringBuilder.Append(GADDefs.JournalEntryFieldDelimiter);
    stringBuilder.Append(str1);
    stringBuilder.Append(GADDefs.JournalEntryFieldDelimiter);
    stringBuilder.Append(str2);
    stringBuilder.Append(GADDefs.JournalEntryFieldDelimiter);
    long ticks = DateTime.Now.Ticks;
    stringBuilder.Append(ticks.ToString());
    stringBuilder.Append(GADDefs.JournalEntryFieldDelimiter);
    FString fstring2;
    FString* localUserName = \u003CModule\u003E.FGameAssetDatabase\u002EGetLocalUserName(&fstring2);
    // ISSUE: fault handler
    try
    {
      stringBuilder.Append(new string(\u003CModule\u003E.FString\u002E\u002A(localUserName), 0, \u003CModule\u003E.FString\u002ELen(localUserName)));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
    stringBuilder.Append(GADDefs.JournalEntryFieldDelimiter);
    stringBuilder.Append(GADDefs.JournalEntryTypeNames[(int) JournalEntry.Type]);
    stringBuilder.Append(GADDefs.JournalEntryFieldDelimiter);
    switch (JournalEntry.Type)
    {
      case EJournalEntryType.AddTag:
      case EJournalEntryType.RemoveTag:
        stringBuilder.Append(JournalEntry.AssetFullName);
        stringBuilder.Append(GADDefs.JournalEntryFieldDelimiter);
        stringBuilder.Append(JournalEntry.Tag);
        break;
      case EJournalEntryType.CreateTag:
      case EJournalEntryType.DestroyTag:
        stringBuilder.Append(JournalEntry.Tag);
        break;
    }
    OutString = stringBuilder.ToString();
    return true;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public static unsafe bool CreateJournalEntryFromString(
    string Text,
    List<string> AllClassNames,
    out MGameAssetJournalEntry OutJournalEntry,
    [MarshalAs(UnmanagedType.U1)] bool bFilterBranchAndGame)
  {
    List<string> OutTags = (List<string>) null;
    OutJournalEntry = (MGameAssetJournalEntry) null;
    string str1 = MGameAssetJournalBase.QueryBranchName();
    if (str1.Length == 0)
      return false;
    FString fstring;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, (char*) &\u003CModule\u003E.GGameName);
    string str2;
    // ISSUE: fault handler
    try
    {
      str2 = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring), 0, \u003CModule\u003E.FString\u002ELen(&fstring));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
    char[] chArray = new char[1]
    {
      GADDefs.JournalEntryFieldDelimiter
    };
    string[] strArray = Text.Split(chArray);
    int int32 = Convert.ToInt32(strArray[0]);
    if (int32 <= GADDefs.JournalEntryVersionNumber)
    {
      string str3 = \u003CModule\u003E.ValidateBranchName(strArray[1]);
      int num1 = str3 == str1 || str3 == MGameAssetJournalBase.UnknownBranchName ? 1 : 0;
      string str4 = strArray[2];
      if (bFilterBranchAndGame && ((byte) num1 == (byte) 0 || !(str4 == str2)))
        return false;
      MGameAssetJournalEntry assetJournalEntry = new MGameAssetJournalEntry();
      assetJournalEntry.BranchName = str3;
      assetJournalEntry.GameName = str4;
      ulong uint64 = Convert.ToUInt64(strArray[3]);
      ValueType valueType = (ValueType) new DateTime();
      (DateTime) valueType = new DateTime((long) uint64);
      assetJournalEntry.TimeStamp = valueType;
      assetJournalEntry.UserName = strArray[4];
      string str5 = strArray[5];
      int num2 = Array.IndexOf<string>(GADDefs.JournalEntryTypeNames, str5);
      assetJournalEntry.Type = (EJournalEntryType) num2;
      assetJournalEntry.IsValidEntry = true;
      switch (num2)
      {
        case 1:
        case 2:
          if (int32 >= GADDefs.JournalEntryVersionNumber_AssetFullNames)
          {
            assetJournalEntry.AssetFullName = strArray[6];
          }
          else
          {
            string str6 = strArray[6];
            assetJournalEntry.IsValidEntry = false;
            List<string>.Enumerator enumerator = AllClassNames.GetEnumerator();
            if (enumerator.MoveNext())
            {
              string InAssetFullName;
              do
              {
                InAssetFullName = enumerator.Current + " " + str6;
                \u003CModule\u003E.FGameAssetDatabase\u002EQueryTagsForAsset(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, InAssetFullName, (ETagQueryOptions.Type) 1, out OutTags);
                if (OutTags.Count > 0)
                  goto label_15;
              }
              while (enumerator.MoveNext());
              goto label_16;
label_15:
              assetJournalEntry.AssetFullName = InAssetFullName;
              assetJournalEntry.IsValidEntry = true;
            }
label_16:
            if (assetJournalEntry.IsValidEntry)
              \u003CModule\u003E.CLRTools\u002ELogWarningMessage((EName) 1132, string.Format("    Repaired asset full name in journal entry that was missing a class name: {0} -> {1}", (object) str6, (object) assetJournalEntry.AssetFullName));
            else
              \u003CModule\u003E.CLRTools\u002ELogWarningMessage((EName) 1132, string.Format("    Found malformed or legacy journal entry (Text='{0}')", (object) Text));
          }
          assetJournalEntry.Tag = strArray[7];
          break;
        case 3:
        case 4:
          assetJournalEntry.Tag = strArray[6];
          break;
      }
      OutJournalEntry = assetJournalEntry;
      return true;
    }
    // ISSUE: cast to a reference type
    // ISSUE: variable of a reference type
    byte* local = (byte*) string.Format("    Ignored journal entry for newer version than we were built with! (OurVer={0}, Theirs={1}, Text='{2}')", (object) GADDefs.JournalEntryVersionNumber, (object) int32, (object) Text);
    if (local != null)
      local = (long) (uint) RuntimeHelpers.OffsetToStringData + local;
    // ISSUE: explicit reference operation
    fixed (byte* numPtr = &^local)
    {
      \u003CModule\u003E.FOutputDevice\u002ELog((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 1132, (char*) numPtr);
      return false;
    }
  }

  protected static unsafe string QueryBranchName()
  {
    FString fstring1;
    FString* str1 = \u003CModule\u003E.FConfigCacheIni\u002EGetStr(\u003CModule\u003E.GConfig, &fstring1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D94, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D93, (char*) &\u003CModule\u003E.GEditorIni);
    string str2;
    // ISSUE: fault handler
    try
    {
      str2 = new string(\u003CModule\u003E.FString\u002E\u002A(str1));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    if (str2.Length == 0)
    {
      FString fstring2;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2);
      // ISSUE: fault handler
      try
      {
        int num = (int) \u003CModule\u003E.Parse(\u003CModule\u003E.appCmdLine(), (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D95, &fstring2, 1U);
        str2 = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
        if (str2.Length == 0)
        {
          FString fstring3;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D96);
          // ISSUE: fault handler
          try
          {
            str2 = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring3), 0, \u003CModule\u003E.FString\u002ELen(&fstring3));
            \u003CModule\u003E.FConfigCacheIni\u002ESetString(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D98, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D97, \u003CModule\u003E.FString\u002E\u002A(&fstring3), (char*) &\u003CModule\u003E.GEditorIni);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
        }
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
    }
    return str2;
  }
}
