// Decompiled with JetBrains decompiler
// Type: MFileSystemNotificationWrapper
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Collections.Generic;
using System.IO;

internal class MFileSystemNotificationWrapper
{
  private List<FileSystemWatcher> Watchers;
  private List<FFileFilter> FileFilters;
  private List<string> ChangedEventQueue;

  public unsafe MFileSystemNotificationWrapper()
  {
    this.Watchers = new List<FileSystemWatcher>();
    this.FileFilters = new List<FFileFilter>();
    this.ChangedEventQueue = new List<string>();
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FConfigCacheIni\u002EGetSingleLineArray(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BK\u0040BLCEKPGK\u0040\u003F\u0024AAF\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAL\u003F\u0024AAi\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1EE\u0040BHFOPCJF\u0040\u003F\u0024AAA\u003F\u0024AAd\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAF\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAL\u003F\u0024AAi\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAD\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAc\u003F\u0024AAt\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAi\u003F\u0024AAe\u0040, &fdefaultAllocator, (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
      if (\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator) < 2)
        \u003CModule\u003E.FConfigCacheIni\u002EGetArray(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BK\u0040BLCEKPGK\u0040\u003F\u0024AAF\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAL\u003F\u0024AAi\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1EE\u0040BHFOPCJF\u0040\u003F\u0024AAA\u003F\u0024AAd\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAF\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAL\u003F\u0024AAi\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAD\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAc\u003F\u0024AAt\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAi\u003F\u0024AAe\u0040, &fdefaultAllocator, (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
      FString fstring1;
      FString* fstringPtr1 = \u003CModule\u003E.appRootDir(&fstring1);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, fstringPtr1);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      int num = 0;
      if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator))
      {
        do
        {
          FString* fstringPtr2 = \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num);
          string path = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr2), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr2));
          if (Directory.Exists(path))
          {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = path;
            fileSystemWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            fileSystemWatcher.Changed += new FileSystemEventHandler(this.OnFileChanged);
            fileSystemWatcher.Renamed += new RenamedEventHandler(this.OnFileRenamed);
            fileSystemWatcher.EnableRaisingEvents = true;
            fileSystemWatcher.IncludeSubdirectories = true;
            this.Watchers.Add(fileSystemWatcher);
          }
          else
          {
            FString fstring2;
            FString* fstringPtr3 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FA\u0040IKJIEMA\u0040\u003F\u0024AAI\u003F\u0024AAn\u003F\u0024AAv\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAi\u003F\u0024AAd\u003F\u0024AA\u003F5\u003F\u0024AAF\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AA\u003F5\u003F\u0024AAN\u003F\u0024AAo\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AA\u003F5\u003F\u0024AAD\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAc\u003F\u0024AAt\u0040, \u003CModule\u003E.FString\u002E\u002A(\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num)));
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, (EName) 767, \u003CModule\u003E.FString\u002E\u002A(fstringPtr3));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          }
          ++num;
        }
        while (num < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator));
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

  public unsafe void ProcessEvents()
  {
    int index = this.ChangedEventQueue.Count - 1;
    if (index < 0)
      return;
    do
    {
      FString fstring1;
      \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.ChangedEventQueue[index]);
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        long num = (long) __calli((__FnPtr<FString* (IntPtr, FString*, char*)>) *(long*) (*(long*) \u003CModule\u003E.GFileManager + 160L))((char*) \u003CModule\u003E.GFileManager, &fstring2, (IntPtr) \u003CModule\u003E.FString\u002E\u002A(&fstring1));
        FString fstring3;
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (FString*) num);
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
          if (File.Exists(this.ChangedEventQueue[index]))
          {
            FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
            ref FString local = ref fstring3;
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            __calli((__FnPtr<void (IntPtr, ECallbackEventType, FString*, UObject*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 24L))((UObject*) gcallbackEvent, (FString*) 73, (ECallbackEventType) ref local, IntPtr.Zero);
            this.ChangedEventQueue.RemoveAt(index);
          }
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
      index += -1;
    }
    while (index >= 0);
  }

  public void AddExtension(string InExtension)
  {
    int index = 0;
    if (0 < this.FileFilters.Count)
    {
      FFileFilter fileFilter;
      do
      {
        fileFilter = this.FileFilters[index];
        if (!(fileFilter.FilterString == InExtension))
          ++index;
        else
          goto label_3;
      }
      while (index < this.FileFilters.Count);
      goto label_4;
label_3:
      ++fileFilter.RefCount;
      return;
    }
label_4:
    this.FileFilters.Add(new FFileFilter()
    {
      FilterString = InExtension,
      RefCount = 1
    });
  }

  public void RemoveExtension(string InExtension)
  {
    int index = 0;
    if (0 >= this.FileFilters.Count)
      return;
    FFileFilter fileFilter;
    do
    {
      fileFilter = this.FileFilters[index];
      if (!(fileFilter.FilterString == InExtension))
        ++index;
      else
        goto label_4;
    }
    while (index < this.FileFilters.Count);
    return;
label_4:
    if (--fileFilter.RefCount != 0)
      return;
    this.FileFilters.RemoveAt(index);
  }

  protected unsafe void HandleFileModified(FString* FullPath)
  {
    FString fstring1;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    long num = (long) __calli((__FnPtr<FString* (IntPtr, FString*, char*)>) *(long*) (*(long*) \u003CModule\u003E.GFileManager + 160L))((char*) \u003CModule\u003E.GFileManager, &fstring1, (IntPtr) \u003CModule\u003E.FString\u002E\u002A(FullPath));
    FString fstring2;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, (FString*) num);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    FFilename ffilename;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, &fstring2);
      // ISSUE: fault handler
      try
      {
        FString fstring3;
        FString* extension = \u003CModule\u003E.FFilename\u002EGetExtension(&ffilename, &fstring3, 0U);
        string str1;
        // ISSUE: fault handler
        try
        {
          FString fstring4;
          FString* lower = \u003CModule\u003E.FString\u002EToLower(extension, &fstring4);
          // ISSUE: fault handler
          try
          {
            str1 = new string(\u003CModule\u003E.FString\u002E\u002A(lower), 0, \u003CModule\u003E.FString\u002ELen(lower));
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
        string str2 = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
        int index = 0;
        if (0 < this.FileFilters.Count)
        {
          while (!(this.FileFilters[index].FilterString == str1))
          {
            ++index;
            if (index >= this.FileFilters.Count)
              goto label_19;
          }
          if (!this.ChangedEventQueue.Contains(str2))
            this.ChangedEventQueue.Add(str2);
        }
        else
          goto label_19;
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
    return;
label_19:
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
  }

  private unsafe void OnFileChanged(object Owner, FileSystemEventArgs Args)
  {
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Args.FullPath);
    // ISSUE: fault handler
    try
    {
      this.HandleFileModified(fstring2);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
  }

  private unsafe void OnFileRenamed(object Owner, RenamedEventArgs Args)
  {
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Args.FullPath);
    // ISSUE: fault handler
    try
    {
      this.HandleFileModified(fstring2);
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
