// Decompiled with JetBrains decompiler
// Type: MGameAssetJournalFile
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using msclr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

internal class MGameAssetJournalFile : MGameAssetJournalBase, IDisposable
{
  private void \u007EMGameAssetJournalFile()
  {
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public override unsafe bool QueryJournalEntries(
    out List<MGameAssetJournalEntry> OutJournalEntries,
    [MarshalAs(UnmanagedType.U1)] bool bFilterBranchAndGame)
  {
    OutJournalEntries = new List<MGameAssetJournalEntry>();
    FString fstring1;
    FString* fstringPtr1 = \u003CModule\u003E.appGameDir(&fstring1);
    string path;
    // ISSUE: fault handler
    try
    {
      path = string.Format("{0}Content\\GameAssetDatabase.journal", (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr1)));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    auto_handle\u003CSystem\u003A\u003AIO\u003A\u003AStreamReader\u003E systemIoStreamReader1 = new auto_handle\u003CSystem\u003A\u003AIO\u003A\u003AStreamReader\u003E();
    auto_handle\u003CSystem\u003A\u003AIO\u003A\u003AStreamReader\u003E systemIoStreamReader2;
    int num1;
    // ISSUE: fault handler
    try
    {
      systemIoStreamReader2 = systemIoStreamReader1;
      if (File.Exists(path))
      {
        try
        {
          systemIoStreamReader2.reset(new StreamReader(path, (Encoding) new UnicodeEncoding()));
        }
        catch (FileNotFoundException ex)
        {
          systemIoStreamReader2.reset();
        }
        catch (DirectoryNotFoundException ex)
        {
          systemIoStreamReader2.reset();
        }
      }
      if (systemIoStreamReader2.op_Implicit() != null)
      {
        if (systemIoStreamReader2.op_MemberSelection().Peek() >= 0)
        {
          string[] strArray = systemIoStreamReader2.op_MemberSelection().ReadLine().Split('-', '\u0002');
          if (strArray.Length >= 2 && strArray[0].Equals("JOURNAL"))
          {
            num1 = int.Parse(strArray[1]);
            if (num1 != -1)
              goto label_20;
          }
        }
        FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
        string InCLRString = \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_InvalidJournalFile", (string) null, (string) null, (string) null);
        FString fstring2;
        FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, InCLRString);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FString\u002E\u003D((FString*) ((IntPtr) database0PeaV1Ea + 8L), fstring3);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        FString* fstringPtr2 = (FString*) ((IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA + 8L);
        // ISSUE: cast to a reference type
        // ISSUE: variable of a reference type
        byte* local = (byte*) string.Format("MGameAssetJournalFile::QueryJournalEntries: {0}", (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr2), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr2)));
        if (local != null)
          local = (long) (uint) RuntimeHelpers.OffsetToStringData + local;
        // ISSUE: explicit reference operation
        fixed (byte* numPtr = &^local)
          \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (char*) numPtr);
      }
      else
        goto label_32;
    }
    __fault
    {
      systemIoStreamReader2.Dispose();
    }
    systemIoStreamReader2.Dispose();
    return false;
label_20:
    // ISSUE: fault handler
    try
    {
      if (num1 > GADDefs.JournalFileVersionNumber)
        throw new SystemException("The journal file was created with a newer version of the application that is currently loaded.");
      List<string> stringList = new List<string>();
      TObjectIterator\u003CUClass\u003E tobjectIteratorUclass;
      \u003CModule\u003E.TObjectIterator\u003CUClass\u003E\u002E\u007Bctor\u007D(&tobjectIteratorUclass, 0U);
      if (\u003CModule\u003E.FObjectIterator\u002E\u002E_N((FObjectIterator*) &tobjectIteratorUclass))
      {
        do
        {
          FString fstring2;
          FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) \u003CModule\u003E.TObjectIterator\u003CUClass\u003E\u002E\u002D\u003E(&tobjectIteratorUclass), &fstring2);
          // ISSUE: fault handler
          try
          {
            string str = new string(\u003CModule\u003E.FString\u002E\u002A(name), 0, \u003CModule\u003E.FString\u002ELen(name));
            stringList.Add(str);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          \u003CModule\u003E.FObjectIterator\u002E\u002B\u002B((FObjectIterator*) &tobjectIteratorUclass);
        }
        while (\u003CModule\u003E.FObjectIterator\u002E\u002E_N((FObjectIterator*) &tobjectIteratorUclass));
      }
      int num2 = 0;
      if (systemIoStreamReader2.op_MemberSelection().Peek() >= 0)
      {
        do
        {
          string Text = systemIoStreamReader2.op_MemberSelection().ReadLine();
          MGameAssetJournalEntry assetJournalEntry = (MGameAssetJournalEntry) null;
          List<string> AllClassNames = stringList;
          ref MGameAssetJournalEntry local = ref assetJournalEntry;
          int num3 = bFilterBranchAndGame ? 1 : 0;
          if (MGameAssetJournalBase.CreateJournalEntryFromString(Text, AllClassNames, out local, num3 != 0))
          {
            assetJournalEntry.IsOfflineEntry = true;
            assetJournalEntry.DatabaseIndex = num2;
            OutJournalEntries.Add(assetJournalEntry);
          }
          ++num2;
        }
        while (systemIoStreamReader2.op_MemberSelection().Peek() >= 0);
      }
    }
    __fault
    {
      systemIoStreamReader2.Dispose();
    }
label_32:
    systemIoStreamReader2.Dispose();
    return true;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public override unsafe bool SendJournalEntries(List<MGameAssetJournalEntry> JournalEntries)
  {
    string OutString = (string) null;
    FString fstring;
    FString* fstringPtr = \u003CModule\u003E.appGameDir(&fstring);
    string path;
    // ISSUE: fault handler
    try
    {
      path = string.Format("{0}Content\\GameAssetDatabase.journal", (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
    auto_handle\u003CSystem\u003A\u003AIO\u003A\u003AStreamWriter\u003E systemIoStreamWriter1 = new auto_handle\u003CSystem\u003A\u003AIO\u003A\u003AStreamWriter\u003E();
    auto_handle\u003CSystem\u003A\u003AIO\u003A\u003AStreamWriter\u003E systemIoStreamWriter2;
    bool flag1;
    bool flag2;
    bool flag3;
    // ISSUE: fault handler
    try
    {
      systemIoStreamWriter2 = systemIoStreamWriter1;
      flag1 = false;
      try
      {
        flag1 = !File.Exists(path);
        systemIoStreamWriter2.reset(new StreamWriter(path, true, (Encoding) new UnicodeEncoding()));
        goto label_10;
      }
      catch (IOException ex)
      {
        \u003CModule\u003E.FGameAssetDatabase\u002ESetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_JournalFileNotWritable", (string) null, (string) null, (string) null));
        \u003CModule\u003E.CLRTools\u002ELogWarningMessage(string.Format("MGameAssetJournalFile::SendJournalEntries: {0}", (object) \u003CModule\u003E.FGameAssetDatabase\u002EGetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA)));
        flag2 = false;
      }
      catch (UnauthorizedAccessException ex)
      {
        \u003CModule\u003E.FGameAssetDatabase\u002ESetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_JournalFileNotWritable", (string) null, (string) null, (string) null));
        \u003CModule\u003E.CLRTools\u002ELogWarningMessage(string.Format("MGameAssetJournalFile::SendJournalEntries: {0}", (object) \u003CModule\u003E.FGameAssetDatabase\u002EGetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA)));
        flag3 = false;
        goto label_18;
      }
    }
    __fault
    {
      systemIoStreamWriter2.Dispose();
    }
    systemIoStreamWriter2.Dispose();
    return flag2;
label_10:
    // ISSUE: fault handler
    try
    {
      if (flag1)
      {
        string str = string.Format("JOURNAL-{0}", (object) GADDefs.JournalFileVersionNumber);
        systemIoStreamWriter2.op_MemberSelection().WriteLine(str);
      }
      List<MGameAssetJournalEntry>.Enumerator enumerator = JournalEntries.GetEnumerator();
      if (enumerator.MoveNext())
      {
        while (MGameAssetJournalBase.CreateStringFromJournalEntry(enumerator.Current, out OutString))
        {
          systemIoStreamWriter2.op_MemberSelection().WriteLine(OutString);
          if (!enumerator.MoveNext())
            goto label_17;
        }
      }
      else
        goto label_17;
    }
    __fault
    {
      systemIoStreamWriter2.Dispose();
    }
    systemIoStreamWriter2.Dispose();
    return false;
label_17:
    systemIoStreamWriter2.Dispose();
    return true;
label_18:
    systemIoStreamWriter2.Dispose();
    return flag3;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool DeleteJournalFile()
  {
    FString fstring1;
    FString* fstringPtr1 = \u003CModule\u003E.appGameDir(&fstring1);
    string str1;
    // ISSUE: fault handler
    try
    {
      str1 = string.Format("{0}Content\\GameAssetDatabase.journal", (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr1)));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    auto_handle\u003CSystem\u003A\u003AIO\u003A\u003AStreamReader\u003E systemIoStreamReader1 = new auto_handle\u003CSystem\u003A\u003AIO\u003A\u003AStreamReader\u003E();
    auto_handle\u003CSystem\u003A\u003AIO\u003A\u003AStreamReader\u003E systemIoStreamReader2;
    bool flag1;
    bool flag2;
    // ISSUE: fault handler
    try
    {
      systemIoStreamReader2 = systemIoStreamReader1;
      try
      {
        if (File.Exists(str1))
        {
          FString fstring2;
          FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, str1);
          FFilename ffilename1;
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename1, \u003CModule\u003E.FString\u002E\u002A(fstring3));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
            FString fstring4;
            FString* extension = \u003CModule\u003E.FFilename\u002EGetExtension(&ffilename1, &fstring4, 0U);
            FFilename ffilename2;
            // ISSUE: fault handler
            try
            {
              FString fstring5;
              FString* baseFilename = \u003CModule\u003E.FFilename\u002EGetBaseFilename(&ffilename1, &fstring5, 0U);
              // ISSUE: fault handler
              try
              {
                FString fstring6;
                FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B(baseFilename, &fstring6, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D109);
                // ISSUE: fault handler
                try
                {
                  FString fstring7;
                  FString* fstringPtr3 = \u003CModule\u003E.FString\u002E\u002B(fstringPtr2, &fstring7, extension);
                  // ISSUE: fault handler
                  try
                  {
                    \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename2, fstringPtr3);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring7);
                  }
                  // ISSUE: fault handler
                  try
                  {
                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring7);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename2);
                  }
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
                }
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename2);
                }
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
              }
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename2);
              }
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
            }
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
              string str2 = \u003CModule\u003E.CLRTools\u002EToString((FString*) &ffilename2);
              File.Delete(str2);
              File.Copy(str1, str2);
              File.Delete(str1);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename2);
            }
            \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename1);
          }
          \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename1);
          goto label_33;
        }
        else
          goto label_33;
      }
      catch (IOException ex)
      {
        flag1 = false;
      }
      catch (UnauthorizedAccessException ex)
      {
        flag2 = false;
        goto label_34;
      }
    }
    __fault
    {
      systemIoStreamReader2.Dispose();
    }
    systemIoStreamReader2.Dispose();
    return flag1;
label_33:
    systemIoStreamReader2.Dispose();
    return true;
label_34:
    systemIoStreamReader2.Dispose();
    return flag2;
  }

  protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
      return;
    // ISSUE: explicit finalizer call
    this.Finalize();
  }

  public virtual void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }
}
