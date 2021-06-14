// Decompiled with JetBrains decompiler
// Type: MGameAssetJournalClient
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using msclr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;

internal class MGameAssetJournalClient : MGameAssetJournalBase, IDisposable
{
  private readonly auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlConnection\u003E MySqlConnection;

  public MGameAssetJournalClient()
  {
    auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlConnection\u003E clientSqlConnection = new auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlConnection\u003E();
    // ISSUE: fault handler
    try
    {
      this.MySqlConnection = clientSqlConnection;
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }
    __fault
    {
      this.MySqlConnection.Dispose();
    }
  }

  private unsafe void \u007EMGameAssetJournalClient()
  {
    if (this.DisconnectFromServer())
      return;
    FString* fstringPtr = (FString*) ((IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA + 8L);
    // ISSUE: cast to a reference type
    // ISSUE: variable of a reference type
    byte* local = (byte*) string.Format("MGameAssetJournalClient: Error while disconnecting from database in destructor.  Details: {0}", (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr)));
    if (local != null)
      local = (long) (uint) RuntimeHelpers.OffsetToStringData + local;
    // ISSUE: explicit reference operation
    fixed (byte* numPtr = &^local)
      \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (char*) numPtr);
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public override unsafe bool QueryJournalEntries(
    out List<MGameAssetJournalEntry> OutJournalEntries,
    [MarshalAs(UnmanagedType.U1)] bool bFilterBranchAndGame)
  {
    if (MGameAssetJournalBase.QueryBranchName().Length == 0 || !this.ConnectToServer())
      return false;
    bool flag = this._QueryJournalEntries(out OutJournalEntries, bFilterBranchAndGame);
    if (!this.DisconnectFromServer())
    {
      FString* fstringPtr = (FString*) ((IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA + 8L);
      // ISSUE: cast to a reference type
      // ISSUE: variable of a reference type
      byte* local = (byte*) string.Format("MGameAssetJournalClient: Error while disconnecting from database in QueryJournalEntries.  Details: {0}", (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr)));
      if (local != null)
        local = (long) (uint) RuntimeHelpers.OffsetToStringData + local;
      // ISSUE: explicit reference operation
      fixed (byte* numPtr = &^local)
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (char*) numPtr);
    }
    return flag;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public override unsafe bool SendJournalEntries(List<MGameAssetJournalEntry> JournalEntries)
  {
    if (MGameAssetJournalBase.QueryBranchName().Length == 0 || !this.ConnectToServer())
      return false;
    bool flag = this._SendJournalEntries(JournalEntries);
    if (!this.DisconnectFromServer())
    {
      FString* fstringPtr = (FString*) ((IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA + 8L);
      // ISSUE: cast to a reference type
      // ISSUE: variable of a reference type
      byte* local = (byte*) string.Format("MGameAssetJournalClient: Error while disconnecting from database in SendJournalEntry.  Details: {0}", (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr)));
      if (local != null)
        local = (long) (uint) RuntimeHelpers.OffsetToStringData + local;
      // ISSUE: explicit reference operation
      fixed (byte* numPtr = &^local)
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (char*) numPtr);
    }
    return flag;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool DeleteJournalEntries(List<int> DatabaseIndices)
  {
    if (DatabaseIndices.Count < 1 || MGameAssetJournalBase.QueryBranchName().Length == 0 || !this.ConnectToServer())
      return false;
    bool flag = this._DeleteJournalEntries(DatabaseIndices);
    if (!this.DisconnectFromServer())
      \u003CModule\u003E.CLRTools\u002ELogWarningMessage(string.Format("MGameAssetJournalClient: Error while disconnecting from database in DeleteJournalEntries.  Details: {0}", (object) \u003CModule\u003E.FGameAssetDatabase\u002EGetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA)));
    return flag;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool ConnectToServer()
  {
    FString fstring1;
    FString* str1 = \u003CModule\u003E.FConfigCacheIni\u002EGetStr(\u003CModule\u003E.GConfig, &fstring1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D100, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D99, (char*) &\u003CModule\u003E.GEditorIni);
    string StrParam0;
    // ISSUE: fault handler
    try
    {
      StrParam0 = new string(\u003CModule\u003E.FString\u002E\u002A(str1));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    FString fstring2;
    FString* str2 = \u003CModule\u003E.FConfigCacheIni\u002EGetStr(\u003CModule\u003E.GConfig, &fstring2, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D102, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D101, (char*) &\u003CModule\u003E.GEditorIni);
    string StrParam1;
    // ISSUE: fault handler
    try
    {
      StrParam1 = new string(\u003CModule\u003E.FString\u002E\u002A(str2));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
    if (StrParam0.Length != 0 && StrParam1.Length != 0)
    {
      uint num1 = 1;
      int num2 = (int) \u003CModule\u003E.FConfigCacheIni\u002EGetBool(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D104, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D103, &num1, (char*) &\u003CModule\u003E.GEditorIni);
      FString fstring3;
      FString* str3 = \u003CModule\u003E.FConfigCacheIni\u002EGetStr(\u003CModule\u003E.GConfig, &fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D106, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D105, (char*) &\u003CModule\u003E.GEditorIni);
      string str4;
      // ISSUE: fault handler
      try
      {
        str4 = new string(\u003CModule\u003E.FString\u002E\u002A(str3));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      FString fstring4;
      FString* str5 = \u003CModule\u003E.FConfigCacheIni\u002EGetStr(\u003CModule\u003E.GConfig, &fstring4, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D108, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D107, (char*) &\u003CModule\u003E.GEditorIni);
      string str6;
      // ISSUE: fault handler
      try
      {
        str6 = new string(\u003CModule\u003E.FString\u002E\u002A(str5));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
      if (num1 == 0U && (str4.Length == 0 || str6.Length == 0))
      {
        \u003CModule\u003E.FGameAssetDatabase\u002ESetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_JournalLoginNotSpecified", (string) null, (string) null, (string) null));
        FString* fstringPtr = (FString*) ((IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA + 8L);
        // ISSUE: cast to a reference type
        // ISSUE: variable of a reference type
        byte* local = (byte*) string.Format("MGameAssetJournalClient::ConnectToServer: {0}", (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr)));
        if (local != null)
          local = (long) (uint) RuntimeHelpers.OffsetToStringData + local;
        // ISSUE: explicit reference operation
        fixed (byte* numPtr = &^local)
        {
          \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (char*) numPtr);
          return false;
        }
      }
      else
      {
        try
        {
          string str7 = string.Format("Data Source={0};" + "Initial Catalog={1};" + "Pooling=True;" + "Asynchronous Processing=True;" + "Connection Timeout=4", (object) StrParam0, (object) StrParam1);
          this.MySqlConnection.reset(new SqlConnection(num1 == 0U ? str7 + string.Format(";User ID={0};Password={1}", (object) str4, (object) str6) : str7 + ";Integrated Security=True"));
          this.MySqlConnection.op_MemberSelection().Open();
        }
        catch (Exception ex)
        {
          this.MySqlConnection.reset();
          \u003CModule\u003E.FGameAssetDatabase\u002ESetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_ErrorConnectingToJournalServer_F", StrParam0, StrParam1, ex.ToString()));
          \u003CModule\u003E.CLRTools\u002ELogWarningMessage(string.Format("MGameAssetJournalClient::ConnectToServer: {0}", (object) \u003CModule\u003E.FGameAssetDatabase\u002EGetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA)));
          return false;
        }
        return true;
      }
    }
    else
    {
      FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
      string InCLRString = \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_JournalServerNotSpecified", (string) null, (string) null, (string) null);
      FString fstring3;
      FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, InCLRString);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002E\u003D((FString*) ((IntPtr) database0PeaV1Ea + 8L), fstring4);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      FString* fstringPtr = (FString*) ((IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA + 8L);
      // ISSUE: cast to a reference type
      // ISSUE: variable of a reference type
      byte* local = (byte*) string.Format("MGameAssetJournalClient::ConnectToServer: {0}", (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr)));
      if (local != null)
        local = (long) (uint) RuntimeHelpers.OffsetToStringData + local;
      // ISSUE: explicit reference operation
      fixed (byte* numPtr = &^local)
      {
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (char*) numPtr);
        return false;
      }
    }
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool DisconnectFromServer()
  {
    if (this.MySqlConnection.op_Implicit() != null)
    {
      try
      {
        this.MySqlConnection.op_MemberSelection().Close();
      }
      catch (Exception ex)
      {
        \u003CModule\u003E.FGameAssetDatabase\u002ESetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_ErrorDisconnectingFromJournalServer_F", ex.ToString(), (string) null, (string) null));
        \u003CModule\u003E.CLRTools\u002ELogWarningMessage(string.Format("MGameAssetJournalClient::DisconnectFromServer: {0}", (object) \u003CModule\u003E.FGameAssetDatabase\u002EGetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA)));
        return false;
      }
      this.MySqlConnection.reset((SqlConnection) null);
    }
    return true;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  protected unsafe bool _QueryJournalEntries(
    out List<MGameAssetJournalEntry> OutJournalEntries,
    [MarshalAs(UnmanagedType.U1)] bool bFilterBranchAndGame)
  {
    string str1 = MGameAssetJournalBase.QueryBranchName();
    if (str1.Length == 0)
      return false;
    OutJournalEntries = new List<MGameAssetJournalEntry>();
    List<string> stringList = new List<string>();
    TObjectIterator\u003CUClass\u003E tobjectIteratorUclass;
    \u003CModule\u003E.TObjectIterator\u003CUClass\u003E\u002E\u007Bctor\u007D(&tobjectIteratorUclass, 0U);
    if (\u003CModule\u003E.FObjectIterator\u002E\u002E_N((FObjectIterator*) &tobjectIteratorUclass))
    {
      do
      {
        FString fstring;
        FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) \u003CModule\u003E.TObjectIterator\u003CUClass\u003E\u002E\u002D\u003E(&tobjectIteratorUclass), &fstring);
        // ISSUE: fault handler
        try
        {
          string str2 = new string(\u003CModule\u003E.FString\u002E\u002A(name), 0, \u003CModule\u003E.FString\u002ELen(name));
          stringList.Add(str2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
        \u003CModule\u003E.FObjectIterator\u002E\u002B\u002B((FObjectIterator*) &tobjectIteratorUclass);
      }
      while (\u003CModule\u003E.FObjectIterator\u002E\u002E_N((FObjectIterator*) &tobjectIteratorUclass));
    }
    FString fstring1;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.GGameName);
    string str3;
    // ISSUE: fault handler
    try
    {
      str3 = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring1), 0, \u003CModule\u003E.FString\u002ELen(&fstring1));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    try
    {
      string cmdText;
      if (bFilterBranchAndGame)
        cmdText = string.Format("select * from dbo.Entries where (substring(Text, {0}, {2}) = '{1}') and (substring(Text, {3}, {5}) = '{4}')", (object) 3, (object) str1, (object) str1.Length, (object) (str1.Length + 4), (object) str3, (object) str3.Length);
      else
        cmdText = "select * from dbo.Entries";
      auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlCommand\u003E clientSqlCommand1 = new auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlCommand\u003E(new SqlCommand(cmdText, this.MySqlConnection.get()));
      auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlCommand\u003E clientSqlCommand2;
      // ISSUE: fault handler
      try
      {
        clientSqlCommand2 = clientSqlCommand1;
        auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlDataReader\u003E clientSqlDataReader1 = new auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlDataReader\u003E(clientSqlCommand2.op_MemberSelection().ExecuteReader());
        auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlDataReader\u003E clientSqlDataReader2;
        // ISSUE: fault handler
        try
        {
          clientSqlDataReader2 = clientSqlDataReader1;
          while (clientSqlDataReader2.op_MemberSelection().Read())
          {
            int num1 = (int) clientSqlDataReader2.get()[0];
            string Text = (string) clientSqlDataReader2.get()[1];
            MGameAssetJournalEntry assetJournalEntry = (MGameAssetJournalEntry) null;
            List<string> AllClassNames = stringList;
            ref MGameAssetJournalEntry local = ref assetJournalEntry;
            int num2 = bFilterBranchAndGame ? 1 : 0;
            if (MGameAssetJournalBase.CreateJournalEntryFromString(Text, AllClassNames, out local, num2 != 0))
            {
              assetJournalEntry.IsOfflineEntry = false;
              assetJournalEntry.DatabaseIndex = num1;
              OutJournalEntries.Add(assetJournalEntry);
            }
          }
        }
        __fault
        {
          clientSqlDataReader2.Dispose();
        }
        clientSqlDataReader2.Dispose();
      }
      __fault
      {
        clientSqlCommand2.Dispose();
      }
      clientSqlCommand2.Dispose();
    }
    catch (Exception ex)
    {
      \u003CModule\u003E.FGameAssetDatabase\u002ESetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_ErrorExecutingSQLCommand_F", ex.ToString(), (string) null, (string) null));
      \u003CModule\u003E.CLRTools\u002ELogWarningMessage(string.Format("MGameAssetJournalClient::QueryJournalEntries: {0}", (object) \u003CModule\u003E.FGameAssetDatabase\u002EGetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA)));
      return false;
    }
    return true;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  protected unsafe bool _SendJournalEntries(List<MGameAssetJournalEntry> JournalEntries)
  {
    string OutString = (string) null;
    DataTable table = new DataTable();
    table.Columns.Add(new DataColumn()
    {
      DataType = Type.GetType("System.Int32"),
      ColumnName = "DatabaseIndex"
    });
    table.Columns.Add(new DataColumn()
    {
      DataType = Type.GetType("System.String"),
      ColumnName = "Text"
    });
    List<MGameAssetJournalEntry>.Enumerator enumerator = JournalEntries.GetEnumerator();
    if (enumerator.MoveNext())
    {
      while (MGameAssetJournalBase.CreateStringFromJournalEntry(enumerator.Current, out OutString))
      {
        DataRow row = table.NewRow();
        row["Text"] = (object) OutString;
        row["DatabaseIndex"] = (object) 0;
        table.Rows.Add(row);
        if (!enumerator.MoveNext())
          goto label_4;
      }
      return false;
    }
label_4:
    if (table.Rows.Count < 4)
    {
      foreach (DataRow row in table.Rows)
      {
        bool flag;
        try
        {
          auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlCommand\u003E clientSqlCommand1 = new auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlCommand\u003E(new SqlCommand(string.Format("insert into dbo.Entries (Text) values ('{0}')", (object) row["Text"].ToString()), this.MySqlConnection.get()));
          auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlCommand\u003E clientSqlCommand2;
          // ISSUE: fault handler
          try
          {
            clientSqlCommand2 = clientSqlCommand1;
            if (clientSqlCommand2.op_MemberSelection().ExecuteNonQuery() == 0)
            {
              \u003CModule\u003E.FGameAssetDatabase\u002ESetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_ErrorExecutingSQLCommand_F", "No rows were affected by SQL command", (string) null, (string) null));
              FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
              \u003CModule\u003E.CLRTools\u002ELogWarningMessage(string.Format("MGameAssetJournalClient::SendJournalEntry: {0}", (object) \u003CModule\u003E.FGameAssetDatabase\u002EGetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA)));
            }
            else
              goto label_13;
          }
          __fault
          {
            clientSqlCommand2.Dispose();
          }
          clientSqlCommand2.Dispose();
          return false;
label_13:
          clientSqlCommand2.Dispose();
          continue;
        }
        catch (Exception ex)
        {
          \u003CModule\u003E.FGameAssetDatabase\u002ESetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_ErrorExecutingSQLCommand_F", ex.ToString(), (string) null, (string) null));
          FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
          \u003CModule\u003E.CLRTools\u002ELogWarningMessage(string.Format("MGameAssetJournalClient::SendJournalEntry: {0}", (object) \u003CModule\u003E.FGameAssetDatabase\u002EGetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA)));
          flag = false;
        }
        return flag;
      }
    }
    else
    {
      SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(this.MySqlConnection.get(), SqlBulkCopyOptions.TableLock, (SqlTransaction) null);
      sqlBulkCopy.BatchSize = table.Rows.Count;
      sqlBulkCopy.DestinationTableName = "dbo.Entries";
      try
      {
        sqlBulkCopy.WriteToServer(table);
      }
      catch (Exception ex)
      {
        \u003CModule\u003E.CLRTools\u002ELogWarningMessage(ex.ToString());
      }
      finally
      {
        sqlBulkCopy.Close();
      }
    }
    return true;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  protected unsafe bool _DeleteJournalEntries(List<int> DatabaseIndices)
  {
    int index = 0;
    while (index < DatabaseIndices.Count)
    {
      try
      {
        StringBuilder stringBuilder = new StringBuilder();
        int num = 0;
        while (index < DatabaseIndices.Count && num < 1024)
        {
          int databaseIndex = DatabaseIndices[index];
          stringBuilder.Append(databaseIndex.ToString());
          ++index;
          ++num;
          if (index < DatabaseIndices.Count && num < 1024)
            stringBuilder.Append(", ");
        }
        auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlCommand\u003E clientSqlCommand1 = new auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlCommand\u003E(new SqlCommand(string.Format("delete from dbo.Entries where DatabaseIndex in ({0})", (object) stringBuilder.ToString()), this.MySqlConnection.get()));
        auto_handle\u003CSystem\u003A\u003AData\u003A\u003ASqlClient\u003A\u003ASqlCommand\u003E clientSqlCommand2;
        // ISSUE: fault handler
        try
        {
          clientSqlCommand2 = clientSqlCommand1;
          if (clientSqlCommand2.op_MemberSelection().ExecuteNonQuery() != num)
          {
            \u003CModule\u003E.FGameAssetDatabase\u002ESetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_ErrorExecutingSQLCommand_F", "The number of affected rows did not match what we were expecting while tring to delete rows", (string) null, (string) null));
            FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
            \u003CModule\u003E.CLRTools\u002ELogWarningMessage(string.Format("MGameAssetJournalClient::DeleteJournalEntries: {0}", (object) \u003CModule\u003E.FGameAssetDatabase\u002EGetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA)));
          }
          else
            goto label_11;
        }
        __fault
        {
          clientSqlCommand2.Dispose();
        }
        clientSqlCommand2.Dispose();
        return false;
label_11:
        clientSqlCommand2.Dispose();
      }
      catch (Exception ex)
      {
        \u003CModule\u003E.FGameAssetDatabase\u002ESetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, \u003CModule\u003E.CLRTools\u002ELocalizeString("GameAssetDatabase_ErrorExecutingSQLCommand_F", ex.ToString(), (string) null, (string) null));
        \u003CModule\u003E.CLRTools\u002ELogWarningMessage(string.Format("MGameAssetJournalClient::DeleteJournalEntries: {0}", (object) \u003CModule\u003E.FGameAssetDatabase\u002EGetErrorMessageText(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA)));
        return false;
      }
    }
    return true;
  }

  [HandleProcessCorruptedStateExceptions]
  protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      try
      {
        this.\u007EMGameAssetJournalClient();
      }
      finally
      {
        this.MySqlConnection.Dispose();
      }
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
