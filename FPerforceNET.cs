// Decompiled with JetBrains decompiler
// Type: FPerforceNET
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using P4API;
using PerforceConstants;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

internal class FPerforceNET : IDisposable
{
  protected P4Connection p4;
  protected unsafe FPerforceSourceControlProvider* SourceControlProvider;
  protected uint bEstablishedConnnection;

  public unsafe FPerforceNET(
    FPerforceSourceControlProvider* InSourceControlProvider)
  {
    this.SourceControlProvider = InSourceControlProvider;
    FString* fstringPtr1 = (FString*) ((IntPtr) InSourceControlProvider + 12L);
    string InServerName = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr1), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr1));
    FString* fstringPtr2 = (FString*) ((IntPtr) InSourceControlProvider + 28L);
    string InUserName = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr2), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr2));
    FString* fstringPtr3 = (FString*) ((IntPtr) InSourceControlProvider + 44L);
    string InClientSpecName = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr3), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr3));
    FString* fstringPtr4 = (FString*) ((IntPtr) InSourceControlProvider + 60L);
    string InTicket = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr4), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr4));
    this.EstablishConnection(InServerName, InUserName, InClientSpecName, InTicket);
  }

  public unsafe FPerforceNET(
    string InServerName,
    string InUserName,
    string InClientSpec,
    string InTicket)
  {
    this.SourceControlProvider = (FPerforceSourceControlProvider*) 0L;
    this.EstablishConnection(InServerName, InUserName, InClientSpec, InTicket);
  }

  private unsafe void \u007EFPerforceNET()
  {
    try
    {
      this.p4.Disconnect();
    }
    catch (Exception ex)
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, ex.Message);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D162, \u003CModule\u003E.FString\u002E\u002A(fstring2));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    }
  }

  public unsafe FString* UpdateBranchName([In] FString* obj0)
  {
    uint num1;
    // ISSUE: fault handler
    try
    {
      num1 = 0U;
      FString fstring1;
      FString* str = \u003CModule\u003E.FConfigCacheIni\u002EGetStr(\u003CModule\u003E.GConfig, &fstring1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D211, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D210, (char*) &\u003CModule\u003E.GEditorIni);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(obj0, \u003CModule\u003E.FString\u002E\u002A(str));
        num1 = 1U;
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      if (\u003CModule\u003E.FString\u002ELen(obj0) != 0)
      {
        int num2 = \u003CModule\u003E.FString\u002EInStr(obj0, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D212, 0U, 0U, -1);
        if (-1 != num2)
        {
          FString fstring2;
          FString* fstringPtr = \u003CModule\u003E.FString\u002ELeft(obj0, &fstring2, num2);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FString\u002E\u003D(obj0, fstringPtr);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          \u003CModule\u003E.FConfigCacheIni\u002ESetString(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D222, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D221, \u003CModule\u003E.FString\u002E\u002A(obj0), (char*) &\u003CModule\u003E.GEditorIni);
        }
      }
      else
      {
        uint num2 = 0;
        TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator1;
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
        // ISSUE: fault handler
        try
        {
          TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
          // ISSUE: fault handler
          try
          {
            FString fstring2;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D213);
            P4RecordSet p4RecordSet;
            // ISSUE: fault handler
            try
            {
              p4RecordSet = this.RunCommand(&fstring2, &fdefaultAllocator1, &fdefaultAllocator2, 1U, 1U);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
            if (p4RecordSet != null && p4RecordSet.Records.Length > 0)
            {
              \u003CModule\u003E.appStrlen((char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D214);
              int index = 0;
              if (0 < p4RecordSet.Records.Length)
              {
                do
                {
                  P4Record record = p4RecordSet.Records[index];
                  if (record.Fields.ContainsKey("depotFile"))
                  {
                    string field = record.Fields["depotFile"];
                    FString fstring3;
                    \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, field);
                    // ISSUE: fault handler
                    try
                    {
                      FString fstring4;
                      FString* fstringPtr1 = \u003CModule\u003E.FString\u002ERight(&fstring3, &fstring4, \u003CModule\u003E.FString\u002ELen(&fstring3) - \u003CModule\u003E.appStrlen((char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D215));
                      // ISSUE: fault handler
                      try
                      {
                        \u003CModule\u003E.FString\u002E\u003D(&fstring3, fstringPtr1);
                      }
                      __fault
                      {
                        // ISSUE: method pointer
                        // ISSUE: cast to a function pointer type
                        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                      }
                      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
                      int num3 = \u003CModule\u003E.FString\u002EInStr(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D216, 0U, 0U, -1);
                      if (num3 != -1)
                      {
                        FString fstring5;
                        FString* fstringPtr2 = \u003CModule\u003E.FString\u002ELeft(&fstring3, &fstring5, num3);
                        // ISSUE: fault handler
                        try
                        {
                          \u003CModule\u003E.FString\u002E\u003D(&fstring3, fstringPtr2);
                        }
                        __fault
                        {
                          // ISSUE: method pointer
                          // ISSUE: cast to a function pointer type
                          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
                        }
                        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
                      }
                      \u003CModule\u003E.FString\u002E\u003D(obj0, &fstring3);
                      num2 = (uint) (-1 == \u003CModule\u003E.FString\u002EInStr(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D217, 0U, 0U, -1));
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
                    }
                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
                  }
                  ++index;
                }
                while (index < p4RecordSet.Records.Length);
                if (num2 != 0U)
                {
                  \u003CModule\u003E.FConfigCacheIni\u002ESetString(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D220, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D219, \u003CModule\u003E.FString\u002E\u002A(obj0), (char*) &\u003CModule\u003E.GEditorIni);
                  goto label_30;
                }
              }
            }
            \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GLog, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D218);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
          }
label_30:
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
        }
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
      }
      return obj0;
    }
    __fault
    {
      if (((int) num1 & 1) != 0)
      {
        uint num2 = num1 & 4294967294U;
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) obj0);
      }
    }
  }

  public static unsafe uint EnsureValidConnection(
    FString* InOutServerName,
    FString* InOutUserName,
    FString* InOutClientSpecName,
    FString* InTicket)
  {
    uint num = 0;
    string InOutPortName = new string(\u003CModule\u003E.FString\u002E\u002A(InOutServerName), 0, \u003CModule\u003E.FString\u002ELen(InOutServerName));
    string InOutUserName1 = new string(\u003CModule\u003E.FString\u002E\u002A(InOutUserName), 0, \u003CModule\u003E.FString\u002ELen(InOutUserName));
    string InOutClientSpecName1 = new string(\u003CModule\u003E.FString\u002E\u002A(InOutClientSpecName), 0, \u003CModule\u003E.FString\u002ELen(InOutClientSpecName));
    string str = new string(\u003CModule\u003E.FString\u002E\u002A(InTicket), 0, \u003CModule\u003E.FString\u002ELen(InTicket));
    P4Connection p4Connection = new P4Connection();
    FString fstring1;
    FString* fstringPtr = \u003CModule\u003E.appRootDir(&fstring1);
    // ISSUE: fault handler
    try
    {
      p4Connection.CWD = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    while (num == 0U)
    {
      if (InOutPortName.Length != 0 && InOutUserName1.Length != 0 && InOutClientSpecName1.Length != 0)
      {
        p4Connection.Port = InOutPortName;
        p4Connection.User = InOutUserName1;
        p4Connection.Client = InOutClientSpecName1;
        if (!string.IsNullOrEmpty(str))
          p4Connection.Password = str;
        try
        {
          num = 1U;
          p4Connection.Connect();
          if (!p4Connection.IsValidConnection(true, true))
          {
            num = 0U;
            FString fstring2;
            FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, str);
            // ISSUE: fault handler
            try
            {
              FString fstring4;
              FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, InOutClientSpecName1);
              // ISSUE: fault handler
              try
              {
                FString fstring6;
                FString* fstring7 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring6, InOutUserName1);
                // ISSUE: fault handler
                try
                {
                  FString fstring8;
                  FString* fstring9 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring8, InOutPortName);
                  // ISSUE: fault handler
                  try
                  {
                    \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D163, \u003CModule\u003E.FString\u002E\u002A(fstring9), \u003CModule\u003E.FString\u002E\u002A(fstring7), \u003CModule\u003E.FString\u002E\u002A(fstring5), \u003CModule\u003E.FString\u002E\u002A(fstring3));
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring8);
                  }
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring8);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          }
        }
        catch (Exception ex)
        {
          num = 0U;
          FString fstring2;
          FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, str);
          // ISSUE: fault handler
          try
          {
            FString fstring4;
            FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, InOutClientSpecName1);
            // ISSUE: fault handler
            try
            {
              FString fstring6;
              FString* fstring7 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring6, InOutUserName1);
              // ISSUE: fault handler
              try
              {
                FString fstring8;
                FString* fstring9 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring8, InOutPortName);
                // ISSUE: fault handler
                try
                {
                  FString fstring10;
                  FString* fstring11 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring10, ex.Message);
                  // ISSUE: fault handler
                  try
                  {
                    \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D164, \u003CModule\u003E.FString\u002E\u002A(fstring11), \u003CModule\u003E.FString\u002E\u002A(fstring9), \u003CModule\u003E.FString\u002E\u002A(fstring7), \u003CModule\u003E.FString\u002E\u002A(fstring5), \u003CModule\u003E.FString\u002E\u002A(fstring3));
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring10);
                  }
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring10);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring8);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring8);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        }
        try
        {
          p4Connection.Disconnect();
        }
        catch (Exception ex)
        {
          num = 0U;
          FString fstring2;
          FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, ex.Message);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D165, \u003CModule\u003E.FString\u002E\u002A(fstring3));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        }
      }
      if (InOutPortName.Length == 0)
        InOutPortName = p4Connection.Port;
      if (InOutUserName1.Length == 0)
        InOutUserName1 = p4Connection.User;
      if (InOutClientSpecName1.Length == 0)
        InOutClientSpecName1 = p4Connection.Client;
      if (num == 0U && FPerforceNET.GetPerforceLogin(ref InOutPortName, ref InOutUserName1, ref InOutClientSpecName1, str) == (LoginResults) 1)
        goto label_62;
    }
    FString fstring12;
    FString* fstring13 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring12, InOutPortName);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u003D(InOutServerName, fstring13);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring12);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring12);
    FString fstring14;
    FString* fstring15 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring14, InOutUserName1);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u003D(InOutUserName, fstring15);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring14);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring14);
    FString fstring16;
    FString* fstring17 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring16, InOutClientSpecName1);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u003D(InOutClientSpecName, fstring17);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring16);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring16);
label_62:
    return num;
  }

  public unsafe uint ExecuteCommand(FSourceControlCommand* InCommand)
  {
    P4RecordSet Records = (P4RecordSet) null;
    if (this.bEstablishedConnnection != 0U)
    {
      switch (*(int*) ((IntPtr) InCommand + 40L))
      {
        case 0:
          FString fstring1;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D166);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring1, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 60L), (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L), 1U, 1U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          break;
        case 1:
          P4PendingChangelist pendingChangelist1 = this.p4.CreatePendingChangelist(\u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) InCommand + 44L)));
          FString fstring2;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D167);
          FSourceControlCommand* fsourceControlCommandPtr1;
          // ISSUE: fault handler
          try
          {
            fsourceControlCommandPtr1 = (FSourceControlCommand*) ((IntPtr) InCommand + 60L);
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr1, &fstring2, 0);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          int number1 = pendingChangelist1.Number;
          FString fstring3;
          FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, number1.ToString());
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr1, fstring4, 1);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          FString fstring5;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring5, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D168);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring5, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr1, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L), 1U, 1U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
          pendingChangelist1.Submit();
          break;
        case 2:
          FString fstring6;
          \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring6, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D169, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) InCommand + 44L)));
          // ISSUE: fault handler
          try
          {
            P4PendingChangelist pendingChangelist2 = this.p4.CreatePendingChangelist(new string(\u003CModule\u003E.FString\u002E\u002A(&fstring6), 0, \u003CModule\u003E.FString\u002ELen(&fstring6)));
            FString fstring7;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring7, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D170);
            FSourceControlCommand* fsourceControlCommandPtr2;
            // ISSUE: fault handler
            try
            {
              fsourceControlCommandPtr2 = (FSourceControlCommand*) ((IntPtr) InCommand + 60L);
              \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr2, &fstring7, 0);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring7);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring7);
            int number2 = pendingChangelist2.Number;
            FString fstring8;
            FString* fstring9 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring8, number2.ToString());
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr2, fstring9, 1);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring8);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring8);
            FString fstring10;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring10, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D171);
            // ISSUE: fault handler
            try
            {
              Records = this.RunCommand(&fstring10, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr2, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L), 1U, 1U);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring10);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring10);
            pendingChangelist2.Submit();
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
          break;
        case 3:
          FString fstring11;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring11, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D172);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring11, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 60L), (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L), 1U, 1U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring11);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring11);
          break;
        case 4:
          FString fstring12;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring12, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D173);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring12, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 60L), (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L), 1U, 1U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring12);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring12);
          break;
        case 5:
          FString fstring13;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring13, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D174);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring13, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 60L), (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
          break;
        case 6:
          FString fstring14;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring14, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D175);
          FSourceControlCommand* fsourceControlCommandPtr3;
          // ISSUE: fault handler
          try
          {
            fsourceControlCommandPtr3 = (FSourceControlCommand*) ((IntPtr) InCommand + 60L);
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr3, &fstring14, 0);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring14);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring14);
          FString fstring15;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring15, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D176);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring15, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr3, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring15);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring15);
          break;
        case 7:
          FString fstring16;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring16, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D181);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring16, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 60L), (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L), 0U, 0U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring16);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring16);
          this.ParseUpdateStatusResults(InCommand, Records);
          break;
        case 8:
          FString fstring17;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring17, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D182);
          FSourceControlCommand* fsourceControlCommandPtr4;
          // ISSUE: fault handler
          try
          {
            fsourceControlCommandPtr4 = (FSourceControlCommand*) ((IntPtr) InCommand + 60L);
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr4, &fstring17, 0);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring17);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring17);
          FString fstring18;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring18, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D183);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr4, &fstring18, 0);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring18);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring18);
          FString fstring19;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring19, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D184);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr4, &fstring19, 0);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring19);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring19);
          FString fstring20;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring20, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D185);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr4, &fstring20, 0);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring20);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring20);
          FString fstring21;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring21, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D186);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr4, &fstring21, 0);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring21);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring21);
          FString fstring22;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring22, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D187);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr4, &fstring22, 1);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring22);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring22);
          FString fstring23;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring23, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D188);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring23, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr4, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring23);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring23);
          this.ParseHistoryResults(InCommand, Records);
          break;
        case 9:
          FString fstring24;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring24, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D177);
          FSourceControlCommand* fsourceControlCommandPtr5;
          // ISSUE: fault handler
          try
          {
            fsourceControlCommandPtr5 = (FSourceControlCommand*) ((IntPtr) InCommand + 60L);
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr5, &fstring24, 0);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring24);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring24);
          FString fstring25;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring25, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D178);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring25, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr5, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring25);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring25);
          this.ParseDiffResults(InCommand, Records);
          break;
        case 10:
          FString fstring26;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring26, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D179);
          FSourceControlCommand* fsourceControlCommandPtr6;
          // ISSUE: fault handler
          try
          {
            fsourceControlCommandPtr6 = (FSourceControlCommand*) ((IntPtr) InCommand + 60L);
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr6, &fstring26, 0);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring26);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring26);
          FString fstring27;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring27, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D180);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring27, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr6, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring27);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring27);
          this.ParseDiffResults(InCommand, Records);
          break;
        case 11:
          FString fstring28;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring28, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D189);
          FSourceControlCommand* fsourceControlCommandPtr7;
          // ISSUE: fault handler
          try
          {
            fsourceControlCommandPtr7 = (FSourceControlCommand*) ((IntPtr) InCommand + 60L);
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EInsertItem((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr7, &fstring28, 0);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring28);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring28);
          FString fstring29;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring29, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D190);
          // ISSUE: fault handler
          try
          {
            Records = this.RunCommand(&fstring29, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr7, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring29);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring29);
          break;
      }
      if (\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFString\u002CFDefaultAllocator\u003E*) ((IntPtr) InCommand + 76L)) > 0)
        *(int*) ((IntPtr) InCommand + 20L) = 2;
      return Records == null ? 0U : 1U;
    }
    *(int*) ((IntPtr) InCommand + 20L) = 1;
    return 0;
  }

  public unsafe List<string> GetClientSpecList(
    string InUserName,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* OutErrorMessage)
  {
    List<string> stringList = new List<string>();
    if (this.bEstablishedConnnection != 0U)
    {
      TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
      // ISSUE: fault handler
      try
      {
        uint num1 = (uint) (\u003CModule\u003E.GIsBuildMachine == 0U);
        FString fstring1;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D191);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, &fstring1);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        FString fstring2;
        FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, InUserName);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, fstring3);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        FString fstring4;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring4, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D192);
        P4RecordSet p4RecordSet;
        // ISSUE: fault handler
        try
        {
          p4RecordSet = this.RunCommand(&fstring4, &fdefaultAllocator, OutErrorMessage, 1U, 1U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
        if (p4RecordSet != null)
        {
          if (p4RecordSet.Records.Length > 0)
          {
            FString fstring5;
            FString* fstringPtr = \u003CModule\u003E.appRootDir(&fstring5);
            string str1;
            // ISSUE: fault handler
            try
            {
              str1 = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr)).ToLower();
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
            string str2 = Environment.GetEnvironmentVariable("P4HOST");
            if (!(str2 == (string) null) && !(str2 == ""))
            {
              str2 = str2.ToLower();
            }
            else
            {
              FString fstring6;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring6, \u003CModule\u003E.appComputerName());
              // ISSUE: fault handler
              try
              {
                str2 = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring6), 0, \u003CModule\u003E.FString\u002ELen(&fstring6)).ToLower();
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
            }
            int index = 0;
            if (0 < p4RecordSet.Records.Length)
            {
              do
              {
                P4Record record = p4RecordSet.Records[index];
                string field1 = record.Fields["client"];
                string field2 = record.Fields["Host"];
                string lower = record.Fields["Root"].ToLower();
                int num2 = str2 == field2.ToLower() ? 1 : 0;
                uint num3 = (uint) (field2 == "");
                if (num2 == 0 && (num3 == 0U || num1 == 0U))
                {
                  FString fstring6;
                  FString* fstring7 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring6, field2);
                  // ISSUE: fault handler
                  try
                  {
                    FString fstring8;
                    FString* fstring9 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring8, field1);
                    // ISSUE: fault handler
                    try
                    {
                      \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D194, \u003CModule\u003E.FString\u002E\u002A(fstring9), \u003CModule\u003E.FString\u002E\u002A(fstring7));
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring8);
                    }
                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring8);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
                  }
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
                }
                else
                {
                  string InCLRString = lower.Replace("/", "\\");
                  str1 = str1.Replace("/", "\\");
                  if (!InCLRString.EndsWith("\\"))
                    InCLRString += "\\";
                  if (str1.IndexOf(InCLRString) != -1)
                  {
                    stringList.Add(field1);
                  }
                  else
                  {
                    FString fstring6;
                    FString* fstring7 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring6, InCLRString);
                    // ISSUE: fault handler
                    try
                    {
                      FString fstring8;
                      FString* fstring9 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring8, field1);
                      // ISSUE: fault handler
                      try
                      {
                        \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D193, \u003CModule\u003E.FString\u002E\u002A(fstring9), \u003CModule\u003E.FString\u002E\u002A(fstring7));
                      }
                      __fault
                      {
                        // ISSUE: method pointer
                        // ISSUE: cast to a function pointer type
                        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring8);
                      }
                      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring8);
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
                    }
                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
                  }
                }
                ++index;
              }
              while (index < p4RecordSet.Records.Length);
            }
          }
        }
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
      }
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    }
    return stringList;
  }

  protected unsafe P4RecordSet RunCommand(
    FString* InCommand,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* InParameters,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* OutErrorMessage,
    uint bInStandardDebugOutput,
    uint bInAllowRetry)
  {
    P4RecordSet p4RecordSet = (P4RecordSet) null;
    bool flag = false;
    int num = 0;
    List<string> stringArray = \u003CModule\u003E.CLRTools\u002EToStringArray(InParameters);
    string str = new string(\u003CModule\u003E.FString\u002E\u002A(InCommand), 0, \u003CModule\u003E.FString\u002ELen(InCommand));
    StringBuilder stringBuilder = new StringBuilder(str);
    int index = 0;
    if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InParameters))
    {
      do
      {
        stringBuilder.Append(" ");
        stringBuilder.Append(stringArray[index]);
        ++index;
      }
      while (index < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(InParameters));
    }
    string InCLRString = stringBuilder.ToString();
    while (!flag)
    {
      try
      {
        if (bInStandardDebugOutput != 0U)
        {
          FString fstring1;
          FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, InCLRString);
          // ISSUE: fault handler
          try
          {
            FString fstring3;
            FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D195, \u003CModule\u003E.FString\u002E\u002A(fstring2));
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(OutErrorMessage, fstringPtr);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          if (num > 0)
          {
            FString fstring3;
            FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D196, num);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(OutErrorMessage, fstringPtr);
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
        p4RecordSet = this.p4.Run(str, stringArray.ToArray());
        flag = true;
      }
      catch (Exception ex)
      {
        FString fstring1;
        \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, InCLRString);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FString\u002EReplaceInline(&fstring1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D198, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D197);
          FString fstring2;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, ex.Message);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FString\u002EReplaceInline(&fstring2, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D200, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D199);
            FString fstring3;
            FString* fstringPtr1 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D201, \u003CModule\u003E.FString\u002E\u002A(&fstring1));
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(OutErrorMessage, fstringPtr1);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
            FString fstring4;
            FString* fstringPtr2 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring4, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D202, \u003CModule\u003E.FString\u002E\u002A(&fstring2));
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(OutErrorMessage, fstringPtr2);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
            if (num < 5)
              ++num;
            else
              flag = true;
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      }
      if (bInAllowRetry == 0U)
        flag = true;
    }
    return p4RecordSet;
  }

  protected unsafe P4RecordSet RunCommand(
    FString* InCommand,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* InParameters,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* OutErrorMessage)
  {
    return this.RunCommand(InCommand, InParameters, OutErrorMessage, 1U, 1U);
  }

  protected unsafe void EstablishConnection(
    string InServerName,
    string InUserName,
    string InClientSpecName,
    string InTicket)
  {
    this.bEstablishedConnnection = 1U;
    try
    {
      P4Connection p4Connection = new P4Connection();
      this.p4 = p4Connection;
      p4Connection.Port = InServerName;
      this.p4.User = InUserName;
      if (!string.IsNullOrEmpty(InClientSpecName))
        this.p4.Client = InClientSpecName;
      if (!string.IsNullOrEmpty(InTicket))
        this.p4.Password = InTicket;
      FString fstring;
      FString* InFString = \u003CModule\u003E.appRootDir(&fstring);
      // ISSUE: fault handler
      try
      {
        this.p4.CWD = \u003CModule\u003E.CLRTools\u002EToString(InFString);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      this.p4.ExceptionLevel = (P4ExceptionLevels) 0;
      this.p4.Connect();
      if (this.p4.IsValidConnection(true, false))
        return;
      this.bEstablishedConnnection = 0U;
      \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D203);
    }
    catch (Exception ex)
    {
      this.bEstablishedConnnection = 0U;
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, ex.Message);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D204, \u003CModule\u003E.FString\u002E\u002A(fstring2));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    }
  }

  protected unsafe void ParseUpdateStatusResults(
    FSourceControlCommand* InCommand,
    P4RecordSet Records)
  {
    if (Records == null || Records.Records.Length <= 0)
      return;
    int index = 0;
    if (0 >= Records.Records.Length)
      return;
    FSourceControlCommand* fsourceControlCommandPtr = (FSourceControlCommand*) ((IntPtr) InCommand + 92L);
    do
    {
      P4Record record = Records.Records[index];
      string field1 = record.Fields["clientFile"];
      string field2 = record.Fields["headRev"];
      string field3 = record.Fields["haveRev"];
      string field4 = record.Fields["otherOpen"];
      string field5 = record.Fields["type"];
      string field6 = record.Fields["headAction"];
      TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
      \u003CModule\u003E.TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
      // ISSUE: fault handler
      try
      {
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, field1);
        FFilename ffilename;
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, fstring2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          if (field2 != (string) null)
          {
            FString fstring3;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D205);
            // ISSUE: fault handler
            try
            {
              FString fstring4;
              FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, field2);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring3, fstring5);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
          if (field3 != (string) null)
          {
            FString fstring3;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D206);
            // ISSUE: fault handler
            try
            {
              FString fstring4;
              FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, field3);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring3, fstring5);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
          if (field6 != (string) null)
          {
            FString fstring3;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D207);
            // ISSUE: fault handler
            try
            {
              FString fstring4;
              FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, field6);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring3, fstring5);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
          if (field4 != (string) null)
          {
            FString fstring3;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D208);
            // ISSUE: fault handler
            try
            {
              FString fstring4;
              FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, field4);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring3, fstring5);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
          if (field5 != (string) null)
          {
            FString fstring3;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D209);
            // ISSUE: fault handler
            try
            {
              FString fstring4;
              FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, field5);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring3, fstring5);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
          FString fstring6;
          FString* baseFilename = \u003CModule\u003E.FFilename\u002EGetBaseFilename(&ffilename, &fstring6, 1U);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TMapBase\u003CFString\u002CTMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CTMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) fsourceControlCommandPtr, baseFilename, &fdefaultSetAllocator);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename);
        }
        \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
      }
      \u003CModule\u003E.TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator);
      ++index;
    }
    while (index < Records.Records.Length);
  }

  protected unsafe void ParseHistoryResults(FSourceControlCommand* InCommand, P4RecordSet Records)
  {
    if (Records == null || Records.Records.Length <= 0)
      return;
    int num = \u003CModule\u003E.appStrlen((char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D223);
    int index1 = 0;
    if (0 >= Records.Records.Length)
      return;
    FSourceControlCommand* fsourceControlCommandPtr = (FSourceControlCommand*) ((IntPtr) InCommand + 92L);
    do
    {
      P4Record record = Records.Records[index1];
      string field = record.Fields["depotFile"];
      FString fstring1;
      \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, field);
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        FString* fstringPtr1 = \u003CModule\u003E.FString\u002ERight(&fstring1, &fstring2, \u003CModule\u003E.FString\u002ELen(&fstring1) - num);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FString\u002E\u003D(&fstring1, fstringPtr1);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        string[] arrayField1 = record.ArrayFields["rev"];
        string[] arrayField2 = record.ArrayFields["user"];
        string[] arrayField3 = record.ArrayFields["time"];
        string[] arrayField4 = record.ArrayFields["change"];
        string[] arrayField5 = record.ArrayFields["desc"];
        string[] arrayField6 = record.ArrayFields["fileSize"];
        string[] arrayField7 = record.ArrayFields["client"];
        string[] arrayField8 = record.ArrayFields["action"];
        FString fstring3;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3);
        // ISSUE: fault handler
        try
        {
          FString fstring4;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring4);
          // ISSUE: fault handler
          try
          {
            FString fstring5;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring5);
            // ISSUE: fault handler
            try
            {
              FString fstring6;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring6);
              // ISSUE: fault handler
              try
              {
                FString fstring7;
                \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring7);
                // ISSUE: fault handler
                try
                {
                  FString fstring8;
                  \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring8);
                  // ISSUE: fault handler
                  try
                  {
                    FString fstring9;
                    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring9);
                    // ISSUE: fault handler
                    try
                    {
                      FString fstring10;
                      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring10);
                      // ISSUE: fault handler
                      try
                      {
                        char* fsourceControl2PebWeb = \u003CModule\u003E.\u003FFILE_HISTORY_ITEM_DELIMITER\u0040FSourceControlFileHistoryInfo\u0040FSourceControl\u0040\u00402PEB_WEB;
                        int index2 = 0;
                        int index3 = 0;
                        if (0 < arrayField1.Length)
                        {
                          do
                          {
                            FString fstring11;
                            FString* fstring12 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring11, arrayField1[index3]);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring13;
                              FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B(fstring12, &fstring13, fsourceControl2PebWeb);
                              // ISSUE: fault handler
                              try
                              {
                                \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring3, fstringPtr2);
                              }
                              __fault
                              {
                                // ISSUE: method pointer
                                // ISSUE: cast to a function pointer type
                                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
                              }
                              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
                            }
                            __fault
                            {
                              // ISSUE: method pointer
                              // ISSUE: cast to a function pointer type
                              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring11);
                            }
                            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring11);
                            FString fstring14;
                            FString* fstring15 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring14, arrayField2[index3]);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring13;
                              FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B(fstring15, &fstring13, fsourceControl2PebWeb);
                              // ISSUE: fault handler
                              try
                              {
                                \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring4, fstringPtr2);
                              }
                              __fault
                              {
                                // ISSUE: method pointer
                                // ISSUE: cast to a function pointer type
                                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
                              }
                              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
                            }
                            __fault
                            {
                              // ISSUE: method pointer
                              // ISSUE: cast to a function pointer type
                              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring14);
                            }
                            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring14);
                            FString fstring16;
                            FString* fstring17 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring16, arrayField3[index3]);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring13;
                              FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B(fstring17, &fstring13, fsourceControl2PebWeb);
                              // ISSUE: fault handler
                              try
                              {
                                \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring5, fstringPtr2);
                              }
                              __fault
                              {
                                // ISSUE: method pointer
                                // ISSUE: cast to a function pointer type
                                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
                              }
                              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
                            }
                            __fault
                            {
                              // ISSUE: method pointer
                              // ISSUE: cast to a function pointer type
                              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring16);
                            }
                            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring16);
                            FString fstring18;
                            FString* fstring19 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring18, arrayField4[index3]);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring13;
                              FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B(fstring19, &fstring13, fsourceControl2PebWeb);
                              // ISSUE: fault handler
                              try
                              {
                                \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring6, fstringPtr2);
                              }
                              __fault
                              {
                                // ISSUE: method pointer
                                // ISSUE: cast to a function pointer type
                                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
                              }
                              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
                            }
                            __fault
                            {
                              // ISSUE: method pointer
                              // ISSUE: cast to a function pointer type
                              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring18);
                            }
                            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring18);
                            FString fstring20;
                            FString* fstring21 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring20, arrayField5[index3]);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring13;
                              FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B(fstring21, &fstring13, fsourceControl2PebWeb);
                              // ISSUE: fault handler
                              try
                              {
                                \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring7, fstringPtr2);
                              }
                              __fault
                              {
                                // ISSUE: method pointer
                                // ISSUE: cast to a function pointer type
                                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
                              }
                              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
                            }
                            __fault
                            {
                              // ISSUE: method pointer
                              // ISSUE: cast to a function pointer type
                              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring20);
                            }
                            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring20);
                            if (arrayField6[index2] == (string) null)
                            {
                              while (index2 < arrayField6.Length)
                              {
                                ++index2;
                                if (!(arrayField6[index2] == (string) null))
                                  break;
                              }
                            }
                            if (index2 < arrayField6.Length && !string.IsNullOrEmpty(arrayField6[index2]))
                            {
                              FString fstring13;
                              FString* fstring22 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring13, arrayField6[index2]);
                              // ISSUE: fault handler
                              try
                              {
                                FString fstring23;
                                FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B(fstring22, &fstring23, fsourceControl2PebWeb);
                                // ISSUE: fault handler
                                try
                                {
                                  \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring8, fstringPtr2);
                                }
                                __fault
                                {
                                  // ISSUE: method pointer
                                  // ISSUE: cast to a function pointer type
                                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring23);
                                }
                                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring23);
                              }
                              __fault
                              {
                                // ISSUE: method pointer
                                // ISSUE: cast to a function pointer type
                                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
                              }
                              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
                            }
                            else
                            {
                              FString fstring13;
                              FString* fstringPtr2 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring13, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D224, fsourceControl2PebWeb);
                              // ISSUE: fault handler
                              try
                              {
                                \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring8, fstringPtr2);
                              }
                              __fault
                              {
                                // ISSUE: method pointer
                                // ISSUE: cast to a function pointer type
                                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
                              }
                              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
                            }
                            ++index2;
                            FString fstring24;
                            FString* fstring25 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring24, arrayField7[index3]);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring13;
                              FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B(fstring25, &fstring13, fsourceControl2PebWeb);
                              // ISSUE: fault handler
                              try
                              {
                                \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring9, fstringPtr2);
                              }
                              __fault
                              {
                                // ISSUE: method pointer
                                // ISSUE: cast to a function pointer type
                                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
                              }
                              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
                            }
                            __fault
                            {
                              // ISSUE: method pointer
                              // ISSUE: cast to a function pointer type
                              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring24);
                            }
                            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring24);
                            FString fstring26;
                            FString* fstring27 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring26, arrayField8[index3]);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring13;
                              FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B(fstring27, &fstring13, fsourceControl2PebWeb);
                              // ISSUE: fault handler
                              try
                              {
                                \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring10, fstringPtr2);
                              }
                              __fault
                              {
                                // ISSUE: method pointer
                                // ISSUE: cast to a function pointer type
                                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
                              }
                              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
                            }
                            __fault
                            {
                              // ISSUE: method pointer
                              // ISSUE: cast to a function pointer type
                              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring26);
                            }
                            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring26);
                            ++index3;
                          }
                          while (index3 < arrayField1.Length);
                        }
                        char* historyKeyString = \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 0);
                        TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
                        \u003CModule\u003E.TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
                        // ISSUE: fault handler
                        try
                        {
                          FString fstring11;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring11, \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 2));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring11, &fstring1);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring11);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring11);
                          FString fstring12;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring12, \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 1));
                          // ISSUE: fault handler
                          try
                          {
                            FString fstring13;
                            FString* fstringPtr2 = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring13, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D225, arrayField1.Length);
                            // ISSUE: fault handler
                            try
                            {
                              \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring12, fstringPtr2);
                            }
                            __fault
                            {
                              // ISSUE: method pointer
                              // ISSUE: cast to a function pointer type
                              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring13);
                            }
                            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring13);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring12);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring12);
                          FString fstring14;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring14, \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 3));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring14, &fstring3);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring14);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring14);
                          FString fstring15;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring15, \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 4));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring15, &fstring4);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring15);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring15);
                          FString fstring16;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring16, \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 5));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring16, &fstring5);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring16);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring16);
                          FString fstring17;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring17, \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 6));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring17, &fstring6);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring17);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring17);
                          FString fstring18;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring18, \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 7));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring18, &fstring7);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring18);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring18);
                          FString fstring19;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring19, \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 8));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring19, &fstring8);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring19);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring19);
                          FString fstring20;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring20, \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 9));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring20, &fstring9);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring20);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring20);
                          FString fstring21;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring21, \u003CModule\u003E.FSourceControl\u002EFSourceControlFileHistoryInfo\u002EGetFileHistoryKeyString((FSourceControl.FSourceControlFileHistoryInfo.EFileHistoryKeys) 10));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring21, &fstring10);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring21);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring21);
                          FString fstring22;
                          FString* fstringPtr3 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u002Cint\u003E(&fstring22, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D226, historyKeyString, index1);
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TMapBase\u003CFString\u002CTMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CTMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) fsourceControlCommandPtr, fstringPtr3, &fdefaultSetAllocator);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring22);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring22);
                        }
                        __fault
                        {
                          // ISSUE: method pointer
                          // ISSUE: cast to a function pointer type
                          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
                        }
                        \u003CModule\u003E.TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator);
                      }
                      __fault
                      {
                        // ISSUE: method pointer
                        // ISSUE: cast to a function pointer type
                        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring10);
                      }
                      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring10);
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring9);
                    }
                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring9);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring8);
                  }
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring8);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring7);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring7);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      ++index1;
    }
    while (index1 < Records.Records.Length);
  }

  protected unsafe void ParseDiffResults(FSourceControlCommand* InCommand, P4RecordSet Records)
  {
    if (Records == null || Records.Records.Length <= 0)
      return;
    int index = 0;
    if (0 >= Records.Records.Length)
      return;
    FSourceControlCommand* fsourceControlCommandPtr = (FSourceControlCommand*) ((IntPtr) InCommand + 92L);
    do
    {
      P4Record record = Records.Records[index];
      string field1 = record.Fields["clientFile"];
      string field2 = record.Fields["depotFile"];
      string field3 = record.Fields["rev"];
      string field4 = record.Fields["type"];
      TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
      \u003CModule\u003E.TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
      // ISSUE: fault handler
      try
      {
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, field1);
        FFilename ffilename;
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, fstring2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          if (field2 != (string) null)
          {
            FString fstring3;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D227);
            // ISSUE: fault handler
            try
            {
              FString fstring4;
              FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, field2);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring3, fstring5);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
          if (field3 != (string) null)
          {
            FString fstring3;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D228);
            // ISSUE: fault handler
            try
            {
              FString fstring4;
              FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, field3);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring3, fstring5);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
          if (field4 != (string) null)
          {
            FString fstring3;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D229);
            // ISSUE: fault handler
            try
            {
              FString fstring4;
              FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, field4);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, &fstring3, fstring5);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          }
          FString fstring6;
          FString* baseFilename = \u003CModule\u003E.FFilename\u002EGetBaseFilename(&ffilename, &fstring6, 1U);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TMapBase\u003CFString\u002CTMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002CTMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) fsourceControlCommandPtr, baseFilename, &fdefaultSetAllocator);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename);
        }
        \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
      }
      \u003CModule\u003E.TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator);
      ++index;
    }
    while (index < Records.Records.Length);
  }

  protected unsafe void DebugPrintRecordSet(P4RecordSet Records)
  {
    if (Records == null || Records.Records.Length <= 0)
      return;
    int index1 = 0;
    if (0 >= Records.Records.Length)
      return;
    do
    {
      P4Record record = Records.Records[index1];
      string[] keys1 = record.Fields.Keys;
      int index2 = 0;
      if (0 < keys1.Length)
      {
        do
        {
          string InCLRString = keys1[index2];
          FString fstring1;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, InCLRString);
          // ISSUE: fault handler
          try
          {
            FString fstring2;
            \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, record.Fields[InCLRString]);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cint\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D230, index1, \u003CModule\u003E.FString\u002E\u002A(&fstring1), \u003CModule\u003E.FString\u002E\u002A(&fstring2));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          ++index2;
        }
        while (index2 < keys1.Length);
      }
      string[] keys2 = record.ArrayFields.Keys;
      int index3 = 0;
      if (0 < keys2.Length)
      {
        do
        {
          string InCLRString1 = keys2[index3];
          FString fstring1;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, InCLRString1);
          // ISSUE: fault handler
          try
          {
            int num = 0;
            string[] arrayField = record.ArrayFields[InCLRString1];
            int index4 = 0;
            if (0 < arrayField.Length)
            {
              do
              {
                string InCLRString2 = arrayField[index4];
                if (InCLRString2 != (string) null)
                {
                  FString fstring2;
                  \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, InCLRString2);
                  // ISSUE: fault handler
                  try
                  {
                    \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cint\u002Cint\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D231, index1, num, \u003CModule\u003E.FString\u002E\u002A(&fstring1), \u003CModule\u003E.FString\u002E\u002A(&fstring2));
                    ++num;
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
                  }
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
                }
                ++index4;
              }
              while (index4 < arrayField.Length);
            }
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          ++index3;
        }
        while (index3 < keys2.Length);
      }
      ++index1;
    }
    while (index1 < Records.Records.Length);
  }

  protected static unsafe LoginResults GetPerforceLogin(
    ref string InOutPortName,
    ref string InOutUserName,
    ref string InOutClientSpecName,
    string InTicket)
  {
    FPerforceNET fperforceNet1 = (FPerforceNET) null;
    LoginResults loginResults = (LoginResults) 1;
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    List<string> clientSpecList;
    // ISSUE: fault handler
    try
    {
      FPerforceNET fperforceNet2 = new FPerforceNET(InOutPortName, InOutUserName, InOutClientSpecName, InTicket);
      // ISSUE: fault handler
      try
      {
        fperforceNet1 = fperforceNet2;
        clientSpecList = fperforceNet1.GetClientSpecList(InOutUserName, &fdefaultAllocator);
        if (clientSpecList.Count == 1)
          InOutClientSpecName = clientSpecList[0];
        else
          goto label_8;
      }
      __fault
      {
        fperforceNet1.Dispose();
      }
      fperforceNet1.Dispose();
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    return (LoginResults) 0;
label_8:
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D232);
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D233);
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D234);
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D235);
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D236);
        List<string>.Enumerator enumerator = clientSpecList.GetEnumerator();
        if (enumerator.MoveNext())
        {
          do
          {
            string current = enumerator.Current;
            FString fstring1;
            FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, current);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D237, \u003CModule\u003E.FString\u002E\u002A(fstring2));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          }
          while (enumerator.MoveNext());
        }
        if (\u003CModule\u003E.GIsUnattended == 0U && \u003CModule\u003E.GIsUCC == 0U)
        {
          WPFFrameInitStruct InSettings = new WPFFrameInitStruct();
          FString fstring1;
          FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring1, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D239, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D238, (char*) 0L);
          // ISSUE: fault handler
          try
          {
            FString fstring2;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
            // ISSUE: fault handler
            try
            {
              string str = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
              InSettings.WindowTitle = str;
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          InSettings.bForceToFront = 1U;
          InSettings.bUseWxDialog = 0U;
          FString fstring3;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D240);
          MWPFFrame mwpfFrame;
          // ISSUE: fault handler
          try
          {
            mwpfFrame = new MWPFFrame((wxWindow*) 0L, InSettings, &fstring3);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          FString fstring4;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring4, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D241);
          MPerforceLoginPanel mperforceLoginPanel;
          // ISSUE: fault handler
          try
          {
            mperforceLoginPanel = new MPerforceLoginPanel(new string(\u003CModule\u003E.FString\u002E\u002A(&fstring4), 0, \u003CModule\u003E.FString\u002ELen(&fstring4)), InOutPortName, InOutUserName, InOutClientSpecName);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
          loginResults = (LoginResults) mwpfFrame.SetContentAndShowModal((MWPFPanel) mperforceLoginPanel, 1);
          if (loginResults == (LoginResults) 0)
            mperforceLoginPanel.GetResult(ref InOutPortName, ref InOutUserName, ref InOutClientSpecName);
          if (InSettings is IDisposable disposable6)
            disposable6.Dispose();
          mwpfFrame?.Dispose();
        }
        else
          \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 795, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D242);
      }
      __fault
      {
        fperforceNet1.Dispose();
      }
      fperforceNet1.Dispose();
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    return loginResults;
  }

  protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      this.\u007EFPerforceNET();
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
