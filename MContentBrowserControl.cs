// Decompiled with JetBrains decompiler
// Type: MContentBrowserControl
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using \u003CCppImplementationDetails\u003E;
using ContentBrowser;
using CustomControls;
using msclr;
using ObjectTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UnrealEd;

internal class MContentBrowserControl : IContentBrowserBackendInterface, IDisposable
{
  public static string WarningPrefix = "_WARNING_";
  protected static bool RecentItemsInitialized = false;
  protected MainControl ContentBrowserCtrl;
  protected unsafe WxContentBrowserHost* ParentBrowserWindow;
  protected HwndSource InteropWindow;
  protected unsafe FContentBrowser* NativeBrowserPtr;
  protected readonly MScopedNativePointer\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E BrowsableObjectTypeList;
  protected readonly MScopedNativePointer\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E SharedThumbnailClasses;
  protected readonly MScopedNativePointer\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E ObjectFactoryClasses;
  protected readonly MScopedNativePointer\u003CTMap\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E BrowsableObjectTypeToClassMap;
  protected readonly MScopedNativePointer\u003CTMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E ClassToBrowsableObjectTypeMap;
  protected Dictionary<string, List<string>> ClassNameToBrowsableTypeNameMap;
  protected Dictionary<string, Color> ClassNameToBorderColorMap;
  protected NameSet AssetTypeNames;
  protected readonly MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E ReferencedObjects;
  protected EContentBrowserQueryState QueryEngineState;
  protected bool bIsSCCStateDirty;
  protected bool bPackageListUpdateRequested;
  protected bool bPackageListUpdateUIRequested;
  protected bool bPackageFilterUpdateRequested;
  protected bool bCollectionListUpdateRequested;
  protected bool bCollectionListUpdateUIRequested;
  protected bool bAssetViewUpdateRequested;
  protected bool bAssetViewUpdateUIRequested;
  protected bool bDoFullAssetViewUpdate;
  protected bool bAssetViewSyncRequested;
  protected bool bCollectionSyncRequested;
  protected uint AssetUpdateFlags;
  protected bool bHasInitializedTree;
  protected string LastExportPath;
  protected string LastImportPath;
  protected string LastOpenPath;
  protected string LastSavePath;
  protected int LastImportFilter;
  protected string LastPreviewedAssetFullName;
  protected readonly auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E CachedQueryData;
  protected readonly MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E CachedQueryAssetFullNameFNamesFromGAD;
  protected readonly MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E LastQueryAssetFullNameFNamesFromGAD;
  protected NameSet CachedQueryQuarantinedAssets;
  protected int CachedQueryIteratorIndex;
  protected readonly MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E CachedQueryObjects;
  protected readonly MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E CachedQueryLoadedAssetFullNames;
  protected readonly MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E LastQueryLoadedAssetFullNames;
  protected readonly MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E CallbackEventObjects;
  protected readonly MScopedNativePointer\u003CTArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E CallbackEventPackages;
  protected readonly MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E CallbackEventSyncObjects;
  protected List<MContentBrowserControl.CollectionSelectRequest> CollectionSelectRequests;
  protected static bool[] ShowConfirmationPrompt = new bool[4]
  {
    true,
    true,
    true,
    true
  };
  protected bool bIsExecutingMenuCommand;

  public unsafe MContentBrowserControl(FContentBrowser* InNativeBrowserPtr)
  {
    this.NativeBrowserPtr = InNativeBrowserPtr;
    MScopedNativePointer\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator1 = new MScopedNativePointer\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E();
    // ISSUE: fault handler
    try
    {
      this.BrowsableObjectTypeList = fdefaultAllocator1;
      MScopedNativePointer\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator2 = new MScopedNativePointer\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E();
      // ISSUE: fault handler
      try
      {
        this.SharedThumbnailClasses = fdefaultAllocator2;
        MScopedNativePointer\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator3 = new MScopedNativePointer\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E();
        // ISSUE: fault handler
        try
        {
          this.ObjectFactoryClasses = fdefaultAllocator3;
          MScopedNativePointer\u003CTMap\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E fdefaultSetAllocator1 = new MScopedNativePointer\u003CTMap\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E();
          // ISSUE: fault handler
          try
          {
            this.BrowsableObjectTypeToClassMap = fdefaultSetAllocator1;
            MScopedNativePointer\u003CTMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E fdefaultSetAllocator2 = new MScopedNativePointer\u003CTMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E();
            // ISSUE: fault handler
            try
            {
              this.ClassToBrowsableObjectTypeMap = fdefaultSetAllocator2;
              MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator4 = new MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E();
              // ISSUE: fault handler
              try
              {
                this.ReferencedObjects = fdefaultAllocator4;
                auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E cachedQueryDataType = new auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E();
                // ISSUE: fault handler
                try
                {
                  this.CachedQueryData = cachedQueryDataType;
                  MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E fdefaultSetAllocator3 = new MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E();
                  // ISSUE: fault handler
                  try
                  {
                    this.CachedQueryAssetFullNameFNamesFromGAD = fdefaultSetAllocator3;
                    MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E fdefaultSetAllocator4 = new MScopedNativePointer\u003CTLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u0020\u003E();
                    // ISSUE: fault handler
                    try
                    {
                      this.LastQueryAssetFullNameFNamesFromGAD = fdefaultSetAllocator4;
                      MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator5 = new MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E();
                      // ISSUE: fault handler
                      try
                      {
                        this.CachedQueryObjects = fdefaultAllocator5;
                        MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E fdefaultSetAllocator5 = new MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E();
                        // ISSUE: fault handler
                        try
                        {
                          this.CachedQueryLoadedAssetFullNames = fdefaultSetAllocator5;
                          MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E fdefaultSetAllocator6 = new MScopedNativePointer\u003CTSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E();
                          // ISSUE: fault handler
                          try
                          {
                            this.LastQueryLoadedAssetFullNames = fdefaultSetAllocator6;
                            MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator6 = new MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E();
                            // ISSUE: fault handler
                            try
                            {
                              this.CallbackEventObjects = fdefaultAllocator6;
                              MScopedNativePointer\u003CTArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator7 = new MScopedNativePointer\u003CTArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E();
                              // ISSUE: fault handler
                              try
                              {
                                this.CallbackEventPackages = fdefaultAllocator7;
                                MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator8 = new MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E();
                                // ISSUE: fault handler
                                try
                                {
                                  this.CallbackEventSyncObjects = fdefaultAllocator8;
                                  // ISSUE: explicit constructor call
                                  base.\u002Ector();
                                  this.LastPreviewedAssetFullName = (string) null;
                                }
                                __fault
                                {
                                  this.CallbackEventSyncObjects.Dispose();
                                }
                              }
                              __fault
                              {
                                this.CallbackEventPackages.Dispose();
                              }
                            }
                            __fault
                            {
                              this.CallbackEventObjects.Dispose();
                            }
                          }
                          __fault
                          {
                            this.LastQueryLoadedAssetFullNames.Dispose();
                          }
                        }
                        __fault
                        {
                          this.CachedQueryLoadedAssetFullNames.Dispose();
                        }
                      }
                      __fault
                      {
                        this.CachedQueryObjects.Dispose();
                      }
                    }
                    __fault
                    {
                      this.LastQueryAssetFullNameFNamesFromGAD.Dispose();
                    }
                  }
                  __fault
                  {
                    this.CachedQueryAssetFullNameFNamesFromGAD.Dispose();
                  }
                }
                __fault
                {
                  this.CachedQueryData.Dispose();
                }
              }
              __fault
              {
                this.ReferencedObjects.Dispose();
              }
            }
            __fault
            {
              this.ClassToBrowsableObjectTypeMap.Dispose();
            }
          }
          __fault
          {
            this.BrowsableObjectTypeToClassMap.Dispose();
          }
        }
        __fault
        {
          this.ObjectFactoryClasses.Dispose();
        }
      }
      __fault
      {
        this.SharedThumbnailClasses.Dispose();
      }
    }
    __fault
    {
      this.BrowsableObjectTypeList.Dispose();
    }
  }

  private unsafe void \u007EMContentBrowserControl()
  {
    this.NativeBrowserPtr = (FContentBrowser*) 0L;
    HwndSource interopWindow = this.InteropWindow;
    if (interopWindow == null)
      return;
    interopWindow.Dispose();
    this.InteropWindow = (HwndSource) null;
  }

  private void \u0021MContentBrowserControl()
  {
  }

  protected void DisposeOfInteropWindow()
  {
    HwndSource interopWindow = this.InteropWindow;
    if (interopWindow == null)
      return;
    interopWindow.Dispose();
    this.InteropWindow = (HwndSource) null;
  }

  public unsafe uint InitContentBrowser(
    WxContentBrowserHost* InParentBrowser,
    HWND__* InParentWindowHandle)
  {
    this.ParentBrowserWindow = InParentBrowser;
    this.QueryEngineState = EContentBrowserQueryState.Idle;
    this.bIsSCCStateDirty = false;
    FString* fstringPtr1 = (FString*) ((IntPtr) \u003CModule\u003E.GApp + 276L);
    this.LastExportPath = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr1), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr1));
    FString* fstringPtr2 = (FString*) ((IntPtr) \u003CModule\u003E.GApp + 260L);
    this.LastImportPath = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr2), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr2));
    FString* fstringPtr3 = (FString*) ((IntPtr) \u003CModule\u003E.GApp + 292L);
    this.LastOpenPath = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr3), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr3));
    FString* fstringPtr4 = (FString*) ((IntPtr) \u003CModule\u003E.GApp + 308L);
    this.LastSavePath = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr4), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr4));
    this.LastImportFilter = 0;
    this.InitBrowsableObjectTypeList();
    this.InitFactoryClassList();
    HwndSourceParameters parameters = new HwndSourceParameters("ContentBrowserHost");
    parameters.PositionX = 0;
    parameters.PositionY = 0;
    IntPtr num = (IntPtr) (void*) InParentWindowHandle;
    parameters.ParentWindow = num;
    parameters.WindowStyle = 1342177280;
    HwndSource hwndSource = new HwndSource(parameters);
    this.InteropWindow = hwndSource;
    hwndSource.SizeToContent = SizeToContent.Manual;
    \u003CModule\u003E.WxUnrealEdApp\u002EInstallHooksWPF();
    MainControl mainControl = new MainControl();
    this.ContentBrowserCtrl = mainControl;
    mainControl.Initialize((IContentBrowserBackendInterface) this);
    this.InteropWindow.RootVisual = (Visual) this.ContentBrowserCtrl;
    this.InitRecentObjectsList();
    this.InteropWindow.AddHook(new HwndSourceHook(this.MessageHookFunction));
    this.ContentBrowserCtrl.CloseButton.IsEnabled = true;
    this.ContentBrowserCtrl.CloseButton.Click += new RoutedEventHandler(this.OnCloseButtonClicked);
    this.ContentBrowserCtrl.CloneButton.IsEnabled = true;
    this.ContentBrowserCtrl.CloneButton.Click += new RoutedEventHandler(this.OnCloneButtonClicked);
    if ((IntPtr) this.ParentBrowserWindow != IntPtr.Zero)
    {
      this.ContentBrowserCtrl.FloatOrDockButton.IsEnabled = true;
      this.ContentBrowserCtrl.FloatOrDockButton.Click += new RoutedEventHandler(this.OnFloatOrDockButtonClicked);
    }
    else
    {
      this.ContentBrowserCtrl.FloatOrDockButton.IsEnabled = false;
      this.ContentBrowserCtrl.FloatOrDockButton.Visibility = Visibility.Collapsed;
    }
    ((UIElement) this.ContentBrowserCtrl).KeyDown += new KeyEventHandler(this.OnKeyPressed);
    ((UIElement) this.ContentBrowserCtrl).MouseDown += new MouseButtonEventHandler(this.OnMouseButtonPressed);
    this.UpdateCollectionsList();
    \u003CModule\u003E.ShowWindow((HWND__*) this.InteropWindow.Handle.ToPointer(), 5);
    return 1;
  }

  public unsafe WxContentBrowserHost* GetParentBrowserWindow() => this.ParentBrowserWindow;

  public void SetFocus()
  {
    if (this.InteropWindow == null)
      return;
    ((UIElement) this.ContentBrowserCtrl).Focus();
  }

  public void EnableWindow([MarshalAs(UnmanagedType.U1)] bool bInEnable)
  {
    MainControl contentBrowserCtrl = this.ContentBrowserCtrl;
    if (contentBrowserCtrl == null)
      return;
    ((UIElement) contentBrowserCtrl).IsEnabled = bInEnable;
  }

  public unsafe TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E* GetSharedThumbnailClasses()
  {
    MScopedNativePointer\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E thumbnailClasses = this.SharedThumbnailClasses;
    return !thumbnailClasses.IsValid() ? (TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L : thumbnailClasses.Get();
  }

  public unsafe TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* GetBrowsableObjectTypeMap() => this.ClassToBrowsableObjectTypeMap.Get();

  public virtual unsafe void BeginDragDrop(string SelectedAssetPaths)
  {
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, SelectedAssetPaths);
    wxTextDataObject wxTextDataObject;
    // ISSUE: fault handler
    try
    {
      wxString wxString;
      \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString, \u003CModule\u003E.FString\u002E\u002A(fstring2));
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.wxTextDataObject\u002E\u007Bctor\u007D(&wxTextDataObject, &wxString);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString);
      }
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxTextDataObject\u002E\u007Bdtor\u007D), (void*) &wxTextDataObject);
      }
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
      wxDropSource wxDropSource;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      \u003CModule\u003E.wxDropSource\u002E\u007Bctor\u007D(&wxDropSource, (wxDataObject*) &wxTextDataObject, (wxWindow*) this.ParentBrowserWindow, (wxCursor*) ^(long&) ref \u003CModule\u003E.__imp_wxNullCursor, (wxCursor*) ^(long&) ref \u003CModule\u003E.__imp_wxNullCursor, (wxCursor*) ^(long&) ref \u003CModule\u003E.__imp_wxNullCursor);
      // ISSUE: fault handler
      try
      {
        ref wxDropSource local = ref wxDropSource;
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        int num = (int) __calli((__FnPtr<wxDragResult (IntPtr, int)>) *(long*) (^(long&) ref wxDropSource + 8L))((int) ref local, IntPtr.Zero);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxDropSource\u002E\u007Bdtor\u007D), (void*) &wxDropSource);
      }
      \u003CModule\u003E.wxDropSource\u002E\u007Bdtor\u007D(&wxDropSource);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxTextDataObject\u002E\u007Bdtor\u007D), (void*) &wxTextDataObject);
    }
    \u003CModule\u003E.wxTextDataObject\u002E\u007Bdtor\u007D(&wxTextDataObject);
  }

  public virtual unsafe void BeginDragDropForImport(List<string> DroppedFiles)
  {
    wxArrayString wxArrayString;
    \u003CModule\u003E.wxArrayString\u002E\u007Bctor\u007D(&wxArrayString);
    // ISSUE: fault handler
    try
    {
      List<string>.Enumerator enumerator = DroppedFiles.GetEnumerator();
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
            wxString wxString;
            \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString, \u003CModule\u003E.FString\u002E\u002A(fstring2));
            // ISSUE: fault handler
            try
            {
              long num = (long) \u003CModule\u003E.wxArrayString\u002EAdd(&wxArrayString, &wxString, 1UL);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString);
            }
            \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString);
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
      if (\u003CModule\u003E.wxArrayString\u002EGetCount(&wxArrayString) != 0UL)
        goto label_12;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxArrayString\u002E\u007Bdtor\u007D), (void*) &wxArrayString);
    }
    \u003CModule\u003E.wxArrayString\u002E\u007Bdtor\u007D(&wxArrayString);
    return;
label_12:
    // ISSUE: fault handler
    try
    {
      FString fstring1;
      FString* fstringPtr1 = \u003CModule\u003E.LocalizeUnrealEd(&fstring1, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_09GGDLDJIK\u0040Importing\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
      // ISSUE: fault handler
      try
      {
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, char*, uint, uint)>) *(long*) (*(long*) \u003CModule\u003E.GWarn + 40L))((uint) \u003CModule\u003E.GWarn, (uint) \u003CModule\u003E.FString\u002E\u002A(fstringPtr1), (char*) 1, IntPtr.Zero);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      TArray\u003CUFactory\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
      \u003CModule\u003E.TArray\u003CUFactory\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2);
        // ISSUE: fault handler
        try
        {
          FString fstring3;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3);
          // ISSUE: fault handler
          try
          {
            TMultiMap\u003Cint\u002CUFactory\u0020\u002A\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
            \u003CModule\u003E.TMultiMap\u003Cint\u002CUFactory\u0020\u002A\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.ObjectTools\u002EAssembleListOfImportFactories(&fdefaultAllocator, &fstring2, &fstring3, &fdefaultSetAllocator);
              FString fstring4;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring4, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BE\u0040OIOADBNO\u0040\u003F\u0024AAM\u003F\u0024AAy\u003F\u0024AAP\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAk\u003F\u0024AAa\u003F\u0024AAg\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040);
              // ISSUE: fault handler
              try
              {
                FString fstring5;
                \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring5);
                // ISSUE: fault handler
                try
                {
                  this.GetSelectedPackageAndGroupName(&fstring4, &fstring5);
                  FString fstring6;
                  FString* fstringPtr2 = &fstring6;
                  FString* fstringPtr3 = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring6, &fstring5);
                  FString* fstringPtr4;
                  // ISSUE: fault handler
                  try
                  {
                    FString fstring7;
                    FString* fstringPtr5 = &fstring7;
                    fstringPtr4 = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring7, &fstring4);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) fstringPtr2);
                  }
                  if (\u003CModule\u003E.ObjectTools\u002EImportFiles(&wxArrayString, &fdefaultAllocator, (FString*) 0L, fstringPtr4, fstringPtr3) != 0U)
                    \u003CModule\u003E.UObject\u002ECollectGarbage(\u003CModule\u003E.GIsEditor != 0U ? 290482175965396992UL : 288230376151711744UL, 1U);
                  FFeedbackContext* gwarn = \u003CModule\u003E.GWarn;
                  // ISSUE: cast to a function pointer type
                  // ISSUE: function pointer call
                  __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) gwarn + 48L))((IntPtr) gwarn);
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
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TMultiMap\u003Cint\u002CUFactory\u0020\u002A\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
            }
            \u003CModule\u003E.TSet\u003CTMapBase\u003Cint\u002CUFactory\u0020\u002A\u002C1\u002CFDefaultSetAllocator\u003E\u003A\u003AFPair\u002CTMapBase\u003Cint\u002CUFactory\u0020\u002A\u002C1\u002CFDefaultSetAllocator\u003E\u003A\u003AKeyFuncs\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D((TSet\u003CTMapBase\u003Cint\u002CUFactory\u0020\u002A\u002C1\u002CFDefaultSetAllocator\u003E\u003A\u003AFPair\u002CTMapBase\u003Cint\u002CUFactory\u0020\u002A\u002C1\u002CFDefaultSetAllocator\u003E\u003A\u003AKeyFuncs\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator);
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
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUFactory\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
      }
      \u003CModule\u003E.TArray\u003CUFactory\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxArrayString\u002E\u007Bdtor\u007D), (void*) &wxArrayString);
    }
    \u003CModule\u003E.wxArrayString\u002E\u007Bdtor\u007D(&wxArrayString);
  }

  public virtual unsafe void UpdateTagsCatalogue()
  {
    List<string> OutTags = new List<string>();
    ETagQueryOptions.Type InOptions = CBDefs.ShowSystemTags ? (ETagQueryOptions.Type) 4 : (ETagQueryOptions.Type) 2;
    \u003CModule\u003E.FGameAssetDatabase\u002EQueryAllTags(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, out OutTags, InOptions);
    this.ContentBrowserCtrl.SetTagsCatalog(OutTags);
  }

  public virtual void UpdateAssetsInView()
  {
    this.bDoFullAssetViewUpdate = true;
    this.StartAssetQuery();
  }

  public virtual TagUtils.EngineTagDefs GetTagDefs() => new TagUtils.EngineTagDefs(GADDefs.MaxTagLength, '[', ']');

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool CreateTag(string InTag)
  {
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    if (\u003CModule\u003E.FGameAssetDatabase\u002ECreateTag(database0PeaV1Ea, InTag))
      return true;
    \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) database0PeaV1Ea + 8L)));
    this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedCreateTag"));
    return false;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool DestroyTag(string InTag)
  {
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    if (\u003CModule\u003E.FGameAssetDatabase\u002EDestroyTag(database0PeaV1Ea, InTag))
      return true;
    \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) database0PeaV1Ea + 8L)));
    this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedDestroyTag"));
    return false;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool CopyTag(string InCurrentTagName, string InNewTagName, [MarshalAs(UnmanagedType.U1)] bool bInMove)
  {
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    if (\u003CModule\u003E.FGameAssetDatabase\u002ECopyTag(database0PeaV1Ea, InCurrentTagName, InNewTagName, bInMove))
      return true;
    \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) database0PeaV1Ea + 8L)));
    this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedCopyOrRenameTag"));
    return false;
  }

  public static EGADCollection.Type BrowserCollectionTypeToGADType(EBrowserCollectionType InType)
  {
    EGADCollection.Type type = (EGADCollection.Type) 0;
    if (InType != null)
    {
      if (InType != 1)
      {
        if (InType == 2)
          type = (EGADCollection.Type) 2;
      }
      else
        type = (EGADCollection.Type) 1;
    }
    else
      type = (EGADCollection.Type) 0;
    return type;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool CreateCollection(
    string InCollectionName,
    EBrowserCollectionType InType)
  {
    EGADCollection.Type InType1 = (EGADCollection.Type) 0;
    if (InType != null)
    {
      if (InType != 1)
      {
        if (InType == 2)
          InType1 = (EGADCollection.Type) 2;
      }
      else
        InType1 = (EGADCollection.Type) 1;
    }
    else
      InType1 = (EGADCollection.Type) 0;
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    if (\u003CModule\u003E.FGameAssetDatabase\u002ECreateCollection(database0PeaV1Ea, InCollectionName, InType1))
    {
      this.bCollectionListUpdateUIRequested = true;
      this.bCollectionListUpdateRequested = true;
      return true;
    }
    \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) database0PeaV1Ea + 8L)));
    this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedCreateCollection"));
    return false;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool DestroyCollection(
    string InCollectionName,
    EBrowserCollectionType InType)
  {
    bool flag = false;
    EGADCollection.Type InType1 = (EGADCollection.Type) 0;
    if (InType != null)
    {
      if (InType != 1)
      {
        if (InType == 2)
          InType1 = (EGADCollection.Type) 2;
      }
      else
        InType1 = (EGADCollection.Type) 1;
    }
    else
      InType1 = (EGADCollection.Type) 0;
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    if (\u003CModule\u003E.FGameAssetDatabase\u002EDestroyCollection(database0PeaV1Ea, InCollectionName, InType1))
    {
      this.bCollectionListUpdateUIRequested = true;
      this.bCollectionListUpdateRequested = true;
      flag = true;
    }
    else
    {
      \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) database0PeaV1Ea + 8L)));
      this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedDestroyCollection"));
    }
    return flag;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool CopyCollection(
    string InCurrentCollectionName,
    EBrowserCollectionType InCurrentType,
    string InNewCollectionName,
    EBrowserCollectionType InNewType,
    [MarshalAs(UnmanagedType.U1)] bool bInMove)
  {
    EGADCollection.Type InCurrentType1 = (EGADCollection.Type) 0;
    if (InCurrentType != null)
    {
      if (InCurrentType != 1)
      {
        if (InCurrentType == 2)
          InCurrentType1 = (EGADCollection.Type) 2;
      }
      else
        InCurrentType1 = (EGADCollection.Type) 1;
    }
    else
      InCurrentType1 = (EGADCollection.Type) 0;
    EGADCollection.Type InNewType1 = (EGADCollection.Type) 0;
    if (InNewType != null)
    {
      if (InNewType != 1)
      {
        if (InNewType == 2)
          InNewType1 = (EGADCollection.Type) 2;
      }
      else
        InNewType1 = (EGADCollection.Type) 1;
    }
    else
      InNewType1 = (EGADCollection.Type) 0;
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    if (\u003CModule\u003E.FGameAssetDatabase\u002ECopyCollection(database0PeaV1Ea, InCurrentCollectionName, InCurrentType1, InNewCollectionName, InNewType1, bInMove))
    {
      this.bCollectionListUpdateUIRequested = true;
      this.bCollectionListUpdateRequested = true;
      return true;
    }
    \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) database0PeaV1Ea + 8L)));
    this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedCopyOrRenameCollection"));
    return false;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool AddAssetsToCollection(
    ICollection<string> InAssetFullNames,
    Collection InCollection,
    EBrowserCollectionType InType)
  {
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    bool flag = false;
    EGADCollection.Type InType1 = (EGADCollection.Type) 0;
    if (InType != null)
    {
      if (InType != 1)
      {
        if (InType == 2)
          InType1 = (EGADCollection.Type) 2;
      }
      else
        InType1 = (EGADCollection.Type) 1;
    }
    else
      InType1 = (EGADCollection.Type) 0;
    if ((*(int*) ((IntPtr) database0PeaV1Ea + 248L) != 0 || *(int*) ((IntPtr) database0PeaV1Ea + 260L) != 0 || \u003CModule\u003E.GIsUnitTesting != 0U ? 0 : 1) != 0 && InType1 != (EGADCollection.Type) 2)
    {
      this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedAddToCollection"));
    }
    else
    {
      flag = \u003CModule\u003E.FGameAssetDatabase\u002EAddAssetsToCollection(database0PeaV1Ea, InCollection.Name, InType1, InAssetFullNames);
      if (flag)
      {
        FContentBrowser* nativeBrowserPtr = this.NativeBrowserPtr;
        FContentBrowser* fcontentBrowserPtr = (IntPtr) nativeBrowserPtr == IntPtr.Zero ? (FContentBrowser*) 0L : (FContentBrowser*) ((IntPtr) nativeBrowserPtr + 16L);
        FCallbackEventParameters fcallbackEventParameters;
        \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters, (FCallbackEventDevice*) fcontentBrowserPtr, (ECallbackEventType) 23, 34U);
        FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
        ref FCallbackEventParameters local = ref fcallbackEventParameters;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) gcallbackEvent, (IntPtr) ref local);
      }
      else
      {
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) database0PeaV1Ea + 8L)));
        this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedAddToCollection"));
      }
    }
    return flag;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool RemoveAssetsFromCollection(
    ICollection<string> InAssetFullNames,
    Collection InCollection,
    EBrowserCollectionType InType)
  {
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    bool flag = false;
    EGADCollection.Type InType1 = (EGADCollection.Type) 0;
    if (InType != null)
    {
      if (InType != 1)
      {
        if (InType == 2)
          InType1 = (EGADCollection.Type) 2;
      }
      else
        InType1 = (EGADCollection.Type) 1;
    }
    else
      InType1 = (EGADCollection.Type) 0;
    if ((*(int*) ((IntPtr) database0PeaV1Ea + 248L) != 0 || *(int*) ((IntPtr) database0PeaV1Ea + 260L) != 0 || \u003CModule\u003E.GIsUnitTesting != 0U ? 0 : 1) != 0 && InType1 != (EGADCollection.Type) 2)
    {
      this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedRemoveFromCollection"));
    }
    else
    {
      flag = \u003CModule\u003E.FGameAssetDatabase\u002ERemoveAssetsFromCollection(database0PeaV1Ea, InCollection.Name, InType1, InAssetFullNames);
      if (flag)
      {
        FContentBrowser* nativeBrowserPtr = this.NativeBrowserPtr;
        FContentBrowser* fcontentBrowserPtr = (IntPtr) nativeBrowserPtr == IntPtr.Zero ? (FContentBrowser*) 0L : (FContentBrowser*) ((IntPtr) nativeBrowserPtr + 16L);
        FCallbackEventParameters fcallbackEventParameters;
        \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters, (FCallbackEventDevice*) fcontentBrowserPtr, (ECallbackEventType) 23, 34U);
        FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
        ref FCallbackEventParameters local = ref fcallbackEventParameters;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) gcallbackEvent, (IntPtr) ref local);
      }
      else
      {
        \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) database0PeaV1Ea + 8L)));
        this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedRemoveFromCollection"));
      }
    }
    return flag;
  }

  public void SelectCollection(string InCollectionName, EBrowserCollectionType InType)
  {
    if (this.CollectionSelectRequests == null)
      this.CollectionSelectRequests = new List<MContentBrowserControl.CollectionSelectRequest>();
    this.CollectionSelectRequests.Add(new MContentBrowserControl.CollectionSelectRequest()
    {
      CollectionName = InCollectionName,
      CollectionType = InType
    });
    this.bCollectionSyncRequested = true;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual bool QuarantineAssets(ICollection<AssetItem> AssetsToQuarantine)
  {
    string str = "";
    string TagToAdd = '['.ToString() + GADDefs.SystemTagTypeNames[10] + (object) ']' + str;
    return this.AddTagToAssets(AssetsToQuarantine, TagToAdd);
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual bool LiftQuarantine(ICollection<AssetItem> AssetsToRelease)
  {
    string str = "";
    string TagToRemove = '['.ToString() + GADDefs.SystemTagTypeNames[10] + (object) ']' + str;
    return this.RemoveTagFromAssets(AssetsToRelease, TagToRemove);
  }

  public unsafe int GenerateSelectedAssetString(FString* out_ResultString)
  {
    int num = 0;
    MainControl contentBrowserCtrl = this.ContentBrowserCtrl;
    if (contentBrowserCtrl != null && contentBrowserCtrl.AssetView != null && (IntPtr) out_ResultString != IntPtr.Zero)
    {
      MContentBrowserControl mcontentBrowserControl = this;
      string InCLRString = mcontentBrowserControl.MarshalAssetItems((ICollection<AssetItem>) mcontentBrowserControl.ContentBrowserCtrl.AssetView.SelectedAssets);
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, InCLRString);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002E\u003D(out_ResultString, fstring2);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      num = this.ContentBrowserCtrl.AssetView.SelectedAssets.Count;
    }
    return num;
  }

  public virtual string MarshalAssetItems(ICollection<AssetItem> InAssetItems)
  {
    StringBuilder stringBuilder = new StringBuilder();
    foreach (AssetItem inAssetItem in (IEnumerable<AssetItem>) InAssetItems)
    {
      if (stringBuilder.Length > 0)
        stringBuilder.Append('|');
      stringBuilder.Append(inAssetItem.AssetType);
      stringBuilder.Append(',');
      stringBuilder.Append(inAssetItem.FullyQualifiedPath);
    }
    return stringBuilder.ToString();
  }

  public virtual List<string> UnmarshalAssetFullNames(string MarshaledAssets)
  {
    char[] separator = new char[2]{ '|', ',' };
    string[] strArray = MarshaledAssets.Split(separator, StringSplitOptions.RemoveEmptyEntries);
    List<string> stringList = new List<string>(strArray.Length / 2);
    int index1 = 0;
    if (0 < strArray.Length)
    {
      do
      {
        string str1 = strArray[index1];
        int index2 = index1 + 1;
        string str2 = strArray[index2];
        index1 = index2 + 1;
        stringList.Add(Utils.MakeFullName(str1, str2));
      }
      while (index1 < strArray.Length);
    }
    return stringList;
  }

  public virtual unsafe void UpdateSourcesList([MarshalAs(UnmanagedType.U1)] bool ShouldUpdateSCC)
  {
    uint num1 = 247;
    uint num2 = ShouldUpdateSCC ? 503U : num1;
    FContentBrowser* nativeBrowserPtr = this.NativeBrowserPtr;
    FContentBrowser* fcontentBrowserPtr = (IntPtr) nativeBrowserPtr == IntPtr.Zero ? (FContentBrowser*) 0L : (FContentBrowser*) ((IntPtr) nativeBrowserPtr + 16L);
    FCallbackEventParameters fcallbackEventParameters;
    \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters, (FCallbackEventDevice*) fcontentBrowserPtr, (ECallbackEventType) 23, num2);
    FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
    ref FCallbackEventParameters local = ref fcallbackEventParameters;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) gcallbackEvent, (IntPtr) ref local);
  }

  public virtual unsafe void ExpandDefaultPackages()
  {
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      if (\u003CModule\u003E.FConfigCacheIni\u002EGetArray(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BI\u0040MLKPIDDG\u0040\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AA\u003F4\u003F\u0024AAS\u003F\u0024AAy\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAm\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1M\u0040DDEDBBPN\u0040\u003F\u0024AAP\u003F\u0024AAa\u003F\u0024AAt\u003F\u0024AAh\u003F\u0024AAs\u003F\u0024AA\u003F\u0024AA\u0040, &fdefaultAllocator, (char*) &\u003CModule\u003E.GEngineIni) > 0)
      {
        int num = 0;
        if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator))
        {
          do
          {
            SourcesPanelModel mySources = this.ContentBrowserCtrl.MySources;
            FString* fstringPtr = \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num);
            string str = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
            ((AbstractTreeNode) mySources.FindFolder(str))?.ExpandToRoot();
            ++num;
          }
          while (num < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator));
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

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool IsGameAssetDatabaseReadonly() => *(int*) ((IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA + 248L) == 0 && *(int*) ((IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA + 260L) == 0 && \u003CModule\u003E.GIsUnitTesting == 0U;

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool DoObjectsPassObjectTypeTest(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InObjects)
  {
    bool flag = true;
    int num1 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InObjects))
    {
      do
      {
        UObject* uobjectPtr1 = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InObjects, num1);
        FString fstring1;
        FString* name1 = \u003CModule\u003E.UObject\u002EGetName((UObject*) \u003CModule\u003E.UObject\u002EGetClass(uobjectPtr1), &fstring1);
        string str1;
        // ISSUE: fault handler
        try
        {
          str1 = new string(\u003CModule\u003E.FString\u002E\u002A(name1), 0, \u003CModule\u003E.FString\u002ELen(name1));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        FString fstring2;
        FString* name2 = \u003CModule\u003E.UObject\u002EGetName(uobjectPtr1, &fstring2);
        string str2;
        // ISSUE: fault handler
        try
        {
          str2 = new string(\u003CModule\u003E.FString\u002E\u002A(name2), 0, \u003CModule\u003E.FString\u002ELen(name2));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        int num2;
        if (\u003CModule\u003E.UObject\u002EHasAllFlags(uobjectPtr1, 1024UL) != 0U)
        {
          UObject* uobjectPtr2 = uobjectPtr1;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          if (__calli((__FnPtr<uint (IntPtr, UObject**)>) *(long*) (*(long*) uobjectPtr1 + 376L))((UObject**) uobjectPtr2, IntPtr.Zero) == 0U)
          {
            num2 = 1;
            goto label_11;
          }
        }
        num2 = 0;
label_11:
        if (this.ContentBrowserCtrl.AssetView.PassesObjectTypeFilter(str1, num2 != 0) && this.ContentBrowserCtrl.AssetView.PassesShowFlattenedTextureFilter(str1, str2))
          ++num1;
        else
          goto label_13;
      }
      while (num1 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InObjects));
      goto label_14;
label_13:
      flag = false;
    }
label_14:
    return flag;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual bool IsAssetAnyOfBrowsableTypes(
    string AssetType,
    [MarshalAs(UnmanagedType.U1)] bool IsArchetype,
    ICollection<string> BrowsableTypeNames)
  {
    List<string> stringList = (List<string>) null;
    this.ClassNameToBrowsableTypeNameMap.TryGetValue(AssetType, out stringList);
    if (IsArchetype)
    {
      if (stringList == null)
        stringList = new List<string>();
      stringList.Add("Archetypes");
    }
    return stringList != null && TagUtils.AnyElementsInCommon(BrowsableTypeNames, (ICollection<string>) stringList);
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual bool IsAssetAnyOfBrowsableTypes(
    AssetItem ItemToCheck,
    ICollection<string> BrowsableTypeNames)
  {
    return this.IsAssetAnyOfBrowsableTypes(ItemToCheck.AssetType, ItemToCheck.IsArchetype, BrowsableTypeNames);
  }

  public virtual unsafe void LoadSelectedObjectsIfNeeded()
  {
    uint num1 = 1;
    TGuardValue\u003Cunsigned\u0020int\u003E valueUnsignedInt;
    \u003CModule\u003E.TGuardValue\u003Cunsigned\u0020int\u003E\u002E\u007Bctor\u007D(&valueUnsignedInt, &\u003CModule\u003E.GIsWatchingEndLoad, &num1);
    bool flag1;
    List<AssetItem> assetItemList;
    int count;
    // ISSUE: fault handler
    try
    {
      flag1 = false;
      assetItemList = new List<AssetItem>();
      foreach (AssetItem selectedItem in (IEnumerable) ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems)
      {
        UObject* uobjectPtr = (UObject*) 0L;
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, selectedItem.AssetType);
        UClass* objectClassUclass;
        // ISSUE: fault handler
        try
        {
          objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        if ((IntPtr) objectClassUclass != IntPtr.Zero)
        {
          FString fstring3;
          FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, selectedItem.FullyQualifiedPath);
          // ISSUE: fault handler
          try
          {
            uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          if ((IntPtr) uobjectPtr != IntPtr.Zero)
          {
            this.UpdateAssetStatus(selectedItem, (AssetStatusUpdateFlags) 1);
            flag1 = true;
            continue;
          }
        }
        assetItemList.Add(selectedItem);
      }
      count = assetItemList.Count;
      if (count > 20)
      {
        string InCLRString = Utils.Localize("ContentBrowser_Questions_ConfirmLoadAssets", (object) count, (object) Environment.NewLine);
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, InCLRString);
        bool flag2;
        // ISSUE: fault handler
        try
        {
          flag2 = \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf((EAppMsgType) 1, \u003CModule\u003E.FString\u002E\u002A(fstring2)) == 0U;
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        if (!flag2)
          goto label_23;
      }
      else
        goto label_23;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TGuardValue\u003Cunsigned\u0020int\u003E\u002E\u007Bdtor\u007D), (void*) &valueUnsignedInt);
    }
    \u003CModule\u003E.TGuardValue\u003Cunsigned\u0020int\u003E\u002E\u007Bdtor\u007D(&valueUnsignedInt);
    return;
label_23:
    // ISSUE: fault handler
    try
    {
      if (count > 0)
      {
        uint num2 = (uint) (count > 20);
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Utils.Localize("ContentBrowser_TaskProgress_LoadingObjects"));
        // ISSUE: fault handler
        try
        {
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, char*, uint, uint)>) *(long*) (*(long*) \u003CModule\u003E.GWarn + 40L))((uint) \u003CModule\u003E.GWarn, (uint) \u003CModule\u003E.FString\u002E\u002A(fstring2), (char*) num2, IntPtr.Zero);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        int index = 0;
        if (0 < count)
        {
          do
          {
            AssetItem assetItem = assetItemList[index];
            if (this.IsAssetValidForLoading(assetItem.FullyQualifiedPath))
            {
              FString fstring3;
              FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, assetItem.AssetType);
              UClass* uclassPtr;
              // ISSUE: fault handler
              try
              {
                uclassPtr = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
              if ((IntPtr) uclassPtr == IntPtr.Zero)
                uclassPtr = \u003CModule\u003E.UObject\u002EStaticClass();
              FString fstring5;
              \u003CModule\u003E.CLRTools\u002EToFString(&fstring5, assetItem.FullyQualifiedPath);
              // ISSUE: fault handler
              try
              {
                UObject* uobjectPtr = \u003CModule\u003E.UObject\u002EStaticLoadObject(uclassPtr, (UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(&fstring5), (char*) 0L, 131072U, (UPackageMap*) 0L, 1U);
                if ((IntPtr) uobjectPtr != IntPtr.Zero)
                {
                  FCallbackEventParameters fcallbackEventParameters1;
                  \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters1, (FCallbackEventDevice*) 0L, (ECallbackEventType) 23, 4U, uobjectPtr);
                  FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
                  ref FCallbackEventParameters local = ref fcallbackEventParameters1;
                  // ISSUE: cast to a function pointer type
                  // ISSUE: function pointer call
                  __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) gcallbackEvent, (IntPtr) ref local);
                  UPackage* outermost = \u003CModule\u003E.UObject\u002EGetOutermost(uobjectPtr);
                  if (this.UPackageToPackage(outermost) is Package package13)
                  {
                    if (\u003CModule\u003E.UPackage\u002EIsFullyLoaded(outermost) != 0U)
                    {
                      FCallbackEventParameters fcallbackEventParameters2;
                      // ISSUE: cast to a function pointer type
                      // ISSUE: function pointer call
                      __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) \u003CModule\u003E.GCallbackEvent, (IntPtr) \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters2, (FCallbackEventDevice*) 0L, (ECallbackEventType) 23, 1U, (UObject*) outermost));
                    }
                    flag1 = true;
                    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
                    \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
                    // ISSUE: fault handler
                    try
                    {
                      UObject* outer = \u003CModule\u003E.UObject\u002EGetOuter(uobjectPtr);
                      if ((IntPtr) outer != IntPtr.Zero)
                      {
                        while (outer != outermost)
                        {
                          UPackage* upackagePtr = \u003CModule\u003E.Cast\u003Cclass\u0020UPackage\u003E(outer);
                          if ((IntPtr) upackagePtr != IntPtr.Zero)
                            \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EInsertItem(&fdefaultAllocator, &upackagePtr, 0);
                          outer = \u003CModule\u003E.UObject\u002EGetOuter(outer);
                          if ((IntPtr) outer == IntPtr.Zero)
                            break;
                        }
                      }
                      ObjectContainerNode objectContainerNode1 = (ObjectContainerNode) package13;
                      int num3 = 0;
                      if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator))
                      {
                        do
                        {
                          FString fstring6;
                          FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num3), &fstring6);
                          string str;
                          // ISSUE: fault handler
                          try
                          {
                            str = new string(\u003CModule\u003E.FString\u002E\u002A(name), 0, \u003CModule\u003E.FString\u002ELen(name));
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
                          }
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
                          ObjectContainerNode objectContainerNode2 = ((SourceTreeNode) objectContainerNode1).FindPackage(str);
                          if (objectContainerNode2 == null)
                          {
                            ObjectContainerNode objectContainerNode3 = objectContainerNode1;
                            objectContainerNode2 = (ObjectContainerNode) ((SourceTreeNode) objectContainerNode3).AddChildNode<GroupPackage>((M0) new GroupPackage((SourceTreeNode) objectContainerNode3, str));
                            if (objectContainerNode2 == null)
                              break;
                          }
                          objectContainerNode1 = objectContainerNode2;
                          ++num3;
                        }
                        while (num3 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator));
                      }
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
                    }
                    \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
                  }
                }
                else
                {
                  this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_LoadObjectFailed", (object) assetItem.FullyQualifiedPath));
                  \u003CModule\u003E.FGameAssetDatabase\u002EAddTagMapping(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, assetItem.FullName, \u003CModule\u003E.FGameAssetDatabase\u002EMakeSystemTag(ESystemTagType.Unverified, ""), true);
                  assetItem.IsVerified = false;
                }
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
            }
            if (num2 != 0U)
            {
              FFeedbackContext* gwarn = \u003CModule\u003E.GWarn;
              int num3 = index;
              int num4 = count;
              // ISSUE: cast to a function pointer type
              // ISSUE: function pointer call
              __calli((__FnPtr<void (IntPtr, int, int)>) *(long*) (*(long*) \u003CModule\u003E.GWarn + 72L))((int) gwarn, num3, (IntPtr) num4);
            }
            ++index;
          }
          while (index < count);
        }
        FFeedbackContext* gwarn1 = \u003CModule\u003E.GWarn;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) gwarn1 + 48L))((IntPtr) gwarn1);
      }
      if (flag1)
        this.SyncSelectedObjectsWithGlobalSelectionSet();
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TGuardValue\u003Cunsigned\u0020int\u003E\u002E\u007Bdtor\u007D), (void*) &valueUnsignedInt);
    }
    \u003CModule\u003E.TGuardValue\u003Cunsigned\u0020int\u003E\u002E\u007Bdtor\u007D(&valueUnsignedInt);
  }

  public virtual unsafe void SyncSelectedObjectsWithGlobalSelectionSet()
  {
    USelection* selectedObjects = \u003CModule\u003E.UEditorEngine\u002EGetSelectedObjects(\u003CModule\u003E.GEditor);
    \u003CModule\u003E.USelection\u002EBeginBatchSelectOperation(selectedObjects);
    TSet\u003CUObject\u0020\u002A\u002CDefaultKeyFuncs\u003CUObject\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
    \u003CModule\u003E.TSet\u003CUObject\u0020\u002A\u002CDefaultKeyFuncs\u003CUObject\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
    // ISSUE: fault handler
    try
    {
      foreach (AssetItem selectedItem in (IEnumerable) ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems)
      {
        UObject* uobjectPtr = (UObject*) 0L;
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, selectedItem.AssetType);
        UClass* objectClassUclass;
        // ISSUE: fault handler
        try
        {
          objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        if ((IntPtr) objectClassUclass != IntPtr.Zero)
        {
          FString fstring3;
          FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, selectedItem.FullyQualifiedPath);
          // ISSUE: fault handler
          try
          {
            uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          if ((IntPtr) uobjectPtr != IntPtr.Zero)
          {
            FSetElementId fsetElementId;
            \u003CModule\u003E.TSet\u003CUObject\u0020\u002A\u002CDefaultKeyFuncs\u003CUObject\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EAdd(&fdefaultSetAllocator, &fsetElementId, uobjectPtr, (uint*) 0L);
            \u003CModule\u003E.USelection\u002ESelect(selectedObjects, uobjectPtr);
          }
        }
      }
      int num = 0;
      if (0 < \u003CModule\u003E.USelection\u002ENum(selectedObjects))
      {
        do
        {
          UObject* uobjectPtr = \u003CModule\u003E.USelection\u002E\u0028\u0029(selectedObjects, num);
          if ((IntPtr) uobjectPtr != IntPtr.Zero && \u003CModule\u003E.TSet\u003CUObject\u0020\u002A\u002CDefaultKeyFuncs\u003CUObject\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EContains(&fdefaultSetAllocator, uobjectPtr) == 0U)
            \u003CModule\u003E.USelection\u002EDeselect(selectedObjects, uobjectPtr);
          ++num;
        }
        while (num < \u003CModule\u003E.USelection\u002ENum(selectedObjects));
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TSet\u003CUObject\u0020\u002A\u002CDefaultKeyFuncs\u003CUObject\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
    }
    \u003CModule\u003E.TSet\u003CUObject\u0020\u002A\u002CDefaultKeyFuncs\u003CUObject\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator);
    \u003CModule\u003E.USelection\u002EEndBatchSelectOperation(selectedObjects);
  }

  public unsafe void NotifySelectionChanged(USelection* ModifiedSelection)
  {
    USelection* selectedObjects = \u003CModule\u003E.UEditorEngine\u002EGetSelectedObjects(\u003CModule\u003E.GEditor);
    if (ModifiedSelection != selectedObjects || this.ContentBrowserCtrl.AssetView.AssetListView.IsNotifyingSelectionChange)
      return;
    \u003CModule\u003E.USelection\u002EBeginBatchSelectOperation(selectedObjects);
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.USelection\u002EGetSelectedObjects(ModifiedSelection, &fdefaultAllocator);
      List<AssetItem> assetItemList = new List<AssetItem>();
      int num = 0;
      if (0 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator))
      {
        do
        {
          UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num);
          if ((IntPtr) uobjectPtr != IntPtr.Zero)
          {
            FString fstring;
            FString* fullName = \u003CModule\u003E.UObject\u002EGetFullName(uobjectPtr, &fstring, (UObject*) 0L);
            string str;
            // ISSUE: fault handler
            try
            {
              str = new string(\u003CModule\u003E.FString\u002E\u002A(fullName), 0, \u003CModule\u003E.FString\u002ELen(fullName));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
            AssetItem assetItem = this.ContentBrowserCtrl.AssetView.FindAssetItem(str);
            if (assetItem != null)
              assetItemList.Add(assetItem);
          }
          ++num;
        }
        while (num < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator));
      }
      this.ContentBrowserCtrl.AssetView.SelectMultipleAssets((ICollection) assetItemList, false);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    \u003CModule\u003E.USelection\u002EEndBatchSelectOperation(selectedObjects);
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool AddTagToAssets(ICollection<AssetItem> InAssets, string TagToAdd)
  {
    List<string> OutTags = (List<string>) null;
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    bool flag = false;
    if ((*(int*) ((IntPtr) database0PeaV1Ea + 248L) != 0 || *(int*) ((IntPtr) database0PeaV1Ea + 260L) != 0 || \u003CModule\u003E.GIsUnitTesting != 0U ? 0 : 1) != 0)
    {
      this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedTagAsset"));
    }
    else
    {
      List<string> stringList = new List<string>();
      foreach (AssetItem inAsset in (IEnumerable<AssetItem>) InAssets)
      {
        string fullName = inAsset.FullName;
        \u003CModule\u003E.FGameAssetDatabase\u002EQueryTagsForAsset(database0PeaV1Ea, fullName, (ETagQueryOptions.Type) 4, out OutTags);
        if (!OutTags.Contains(TagToAdd))
          stringList.Add(fullName);
      }
      flag = \u003CModule\u003E.FGameAssetDatabase\u002EAddTagToAssets(database0PeaV1Ea, (ICollection<string>) stringList, TagToAdd);
      if (flag)
        goto label_11;
    }
    \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) database0PeaV1Ea + 8L)));
    this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedTagAsset"));
label_11:
    return flag;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool RemoveTagFromAssets(
    ICollection<AssetItem> InAssets,
    string TagToRemove)
  {
    List<string> OutTags = (List<string>) null;
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    bool flag = false;
    if ((*(int*) ((IntPtr) database0PeaV1Ea + 248L) != 0 || *(int*) ((IntPtr) database0PeaV1Ea + 260L) != 0 || \u003CModule\u003E.GIsUnitTesting != 0U ? 0 : 1) != 0)
    {
      this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedUntagAsset"));
    }
    else
    {
      List<string> stringList = new List<string>();
      foreach (AssetItem inAsset in (IEnumerable<AssetItem>) InAssets)
      {
        string fullName = inAsset.FullName;
        \u003CModule\u003E.FGameAssetDatabase\u002EQueryTagsForAsset(database0PeaV1Ea, fullName, (ETagQueryOptions.Type) 4, out OutTags);
        if (OutTags.Contains(TagToRemove))
          stringList.Add(fullName);
      }
      flag = \u003CModule\u003E.FGameAssetDatabase\u002ERemoveTagFromAssets(database0PeaV1Ea, (ICollection<string>) stringList, TagToRemove);
      if (flag)
        goto label_11;
    }
    \u003CModule\u003E.FOutputDevice\u002ELogf((FOutputDevice*) \u003CModule\u003E.GWarn, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) database0PeaV1Ea + 8L)));
    this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedUntagAsset"));
label_11:
    return flag;
  }

  public virtual unsafe void UpdateAssetStatus(AssetItem Asset, AssetStatusUpdateFlags UpdateFlags)
  {
    List<string> stringList1 = (List<string>) null;
    List<string> stringList2 = (List<string>) null;
    if ((UpdateFlags & 1) == 1)
    {
      uint num = Asset.LoadedStatus != 0 ? 1U : 0U;
      UObject* uobjectPtr = (UObject*) 0L;
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Asset.AssetType);
      UClass* objectClassUclass;
      // ISSUE: fault handler
      try
      {
        objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      if ((IntPtr) objectClassUclass != IntPtr.Zero)
      {
        FString fstring3;
        FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, Asset.FullyQualifiedPath);
        // ISSUE: fault handler
        try
        {
          uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
        if ((IntPtr) uobjectPtr != IntPtr.Zero)
        {
          Asset.LoadedStatus = \u003CModule\u003E.UPackage\u002EIsDirty(\u003CModule\u003E.UObject\u002EGetOutermost(uobjectPtr)) == 0U ? (AssetItem.LoadedStatusType) 1 : (AssetItem.LoadedStatusType) 2;
          goto label_11;
        }
      }
      Asset.LoadedStatus = (AssetItem.LoadedStatusType) 0;
label_11:
      if (num == 0U && (IntPtr) uobjectPtr != IntPtr.Zero)
      {
        if (!Asset.IsVerified)
        {
          Asset.IsVerified = true;
          \u003CModule\u003E.FGameAssetDatabase\u002ERemoveTagMapping(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, Asset.FullName, \u003CModule\u003E.FGameAssetDatabase\u002EMakeSystemTag(ESystemTagType.Unverified, ""));
        }
        AssetVisual visual = (AssetVisual) Asset.Visual;
        if (visual != null && visual.Thumbnail != null)
          ((AssetVisual) Asset.Visual).ShouldRefreshThumbnail = (__Null) 2;
        Asset.MarkCustomLabelsAsDirty();
        Asset.MarkCustomDataColumnsAsDirty();
        Asset.UpdateCustomLabelsIfNeeded();
        Asset.UpdateCustomDataColumnsIfNeeded();
      }
    }
    if ((UpdateFlags & 2) == 2)
    {
      ETagQueryOptions.Type type = CBDefs.ShowSystemTags ? (ETagQueryOptions.Type) 4 : (ETagQueryOptions.Type) 2;
      FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
      // ISSUE: cast to a reference type
      // ISSUE: variable of a reference type
      byte* local1 = (byte*) Asset.FullName;
      if (local1 != null)
        local1 = (long) (uint) RuntimeHelpers.OffsetToStringData + local1;
      // ISSUE: explicit reference operation
      fixed (byte* numPtr = &^local1)
      {
        FName fname;
        \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (char*) numPtr, (EFindName) 1, 1U);
        FName InAssetFullNameFName = fname;
        int num = (int) type;
        ref List<string> local2 = ref stringList1;
        \u003CModule\u003E.FGameAssetDatabase\u002EQueryTagsForAsset(database0PeaV1Ea, InAssetFullNameFName, (ETagQueryOptions.Type) num, out local2);
        stringList1.Sort();
        Asset.Tags = stringList1;
      }
    }
    if ((UpdateFlags & 4) != 4)
      return;
    FGameAssetDatabase* database0PeaV1Ea1 = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    // ISSUE: cast to a reference type
    // ISSUE: variable of a reference type
    byte* local3 = (byte*) Asset.FullName;
    if (local3 != null)
      local3 = (long) (uint) RuntimeHelpers.OffsetToStringData + local3;
    // ISSUE: explicit reference operation
    fixed (byte* numPtr = &^local3)
    {
      FName fname;
      \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (char*) numPtr, (EFindName) 1, 1U);
      FName InAssetFullNameFName = fname;
      ref List<string> local1 = ref stringList2;
      \u003CModule\u003E.FGameAssetDatabase\u002EQueryTagsForAsset(database0PeaV1Ea1, InAssetFullNameFName, (ETagQueryOptions.Type) 4, out local1);
      string str1 = "";
      string str2 = '['.ToString() + GADDefs.SystemTagTypeNames[10] + (object) ']' + str1;
      Asset.IsQuarantined = stringList2.Contains(str2);
    }
  }

  public virtual unsafe void PopulateObjectFactoryContextMenu(ContextMenu ctxMenu)
  {
    string str = Utils.Localize("ContentBrowser_AssetView_NewObject");
    if (!this.ObjectFactoryClasses.op_Implicit())
      return;
    ctxMenu.Closed += new RoutedEventHandler(this.OnObjectFactoryContextMenuClosed);
    TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = this.ObjectFactoryClasses.Get();
    int num = 0;
    if (0 >= \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr))
      return;
    do
    {
      FString* fstringPtr = (FString*) ((IntPtr) \u003CModule\u003E.UClass\u002EGetDefaultObject\u003Cclass\u0020UFactory\u003E((UClass*) *(long*) \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, num), 0U) + 112L);
      string name = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
      MenuItem menuItem = new MenuItem();
      RoutedUICommand routedUiCommand = new RoutedUICommand(string.Concat<char>((IEnumerable<char>) name), name, typeof (ObjectFactoryCommands));
      ((UIElement) this.ContentBrowserCtrl.AssetView).CommandBindings.Add(new CommandBinding((ICommand) routedUiCommand, new ExecutedRoutedEventHandler(this.ExecuteMenuCommand), new CanExecuteRoutedEventHandler(this.CanExecuteMenuCommand)));
      menuItem.Header = (object) (str + name);
      menuItem.Command = (ICommand) routedUiCommand;
      menuItem.CommandParameter = (object) (num + 21366);
      menuItem.IsEnabled = true;
      ctxMenu.Items.Add((object) menuItem);
      ++num;
    }
    while (num < \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr));
  }

  public virtual unsafe void PopulatePackageListMenuItems(
    ItemCollection OutPackageListMenuItems,
    CommandBindingCollection OutCommandBindings,
    System.Type InTypeId,
    ExecutedRoutedEventHandler InEventHandler,
    CanExecuteRoutedEventHandler InCanExecuteEventHandler)
  {
    ContextMenu resource = (ContextMenu) ((FrameworkElement) this.ContentBrowserCtrl.MySourcesPanel).FindResource((object) "PackageListContextMenu");
    if (resource != null)
    {
      IEnumerator enumerator1 = ((IEnumerable) resource.Items).GetEnumerator();
label_2:
      try
      {
        while (enumerator1.MoveNext())
        {
          object current1 = enumerator1.Current;
          if (current1 is Separator)
            OutPackageListMenuItems.Add((object) new Separator());
          else if (current1 is MenuItem menuItem27)
          {
            MenuItem menuItem1 = new MenuItem();
            menuItem1.Command = menuItem27.Command;
            menuItem1.Header = menuItem27.Header;
            OutPackageListMenuItems.Add((object) menuItem1);
            if (menuItem1.Command != null && (MulticastDelegate) InEventHandler != (MulticastDelegate) null && (MulticastDelegate) InCanExecuteEventHandler != (MulticastDelegate) null)
            {
              CommandBinding commandBinding = new CommandBinding(menuItem1.Command, InEventHandler, InCanExecuteEventHandler);
              OutCommandBindings.Add(commandBinding);
            }
            if (menuItem27.Items.Count > 0)
            {
              IEnumerator enumerator2 = ((IEnumerable) menuItem27.Items).GetEnumerator();
              try
              {
                while (true)
                {
                  MenuItem menuItem2;
                  do
                  {
                    object current2;
                    do
                    {
                      if (enumerator2.MoveNext())
                      {
                        current2 = enumerator2.Current;
                        if (current2 is Separator)
                          menuItem1.Items.Add((object) new Separator());
                      }
                      else
                        goto label_2;
                    }
                    while (!(current2 is MenuItem menuItem28) || menuItem28.Command is RoutedCommand command17 && !(command17.OwnerType == typeof (SourceControlCommands)));
                    menuItem2 = new MenuItem();
                    menuItem2.Command = menuItem28.Command;
                    menuItem2.Header = menuItem28.Header;
                    menuItem1.Items.Add((object) menuItem2);
                  }
                  while (menuItem2.Command == null || !((MulticastDelegate) InEventHandler != (MulticastDelegate) null) || !((MulticastDelegate) InCanExecuteEventHandler != (MulticastDelegate) null));
                  CommandBinding commandBinding = new CommandBinding(menuItem2.Command, InEventHandler, InCanExecuteEventHandler);
                  OutCommandBindings.Add(commandBinding);
                }
              }
              finally
              {
                if (enumerator2 is IDisposable disposable16)
                  disposable16.Dispose();
              }
            }
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable disposable17)
          disposable17.Dispose();
      }
    }
    List<object> OutMenuItems = new List<object>();
    TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      this.QueryPackageTreeContextMenuItems(&fdefaultAllocator);
      this.BuildContextMenu(&fdefaultAllocator, -1, InTypeId, OutCommandBindings, ref OutMenuItems);
      OutPackageListMenuItems.Add((object) new Separator());
      List<object>.Enumerator enumerator = OutMenuItems.GetEnumerator();
      if (enumerator.MoveNext())
      {
        do
        {
          object current = enumerator.Current;
          OutPackageListMenuItems.Add(current);
        }
        while (enumerator.MoveNext());
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  public void OnObjectFactoryContextMenuClosed(object Sender, RoutedEventArgs CloseEventArgs)
  {
    int index = ((UIElement) this.ContentBrowserCtrl.AssetView).CommandBindings.Count - 1;
    if (index < 0)
      return;
    do
    {
      if (((UIElement) this.ContentBrowserCtrl.AssetView).CommandBindings[index].Command is RoutedCommand)
        ((UIElement) this.ContentBrowserCtrl.AssetView).CommandBindings.RemoveAt(index);
      index += -1;
    }
    while (index >= 0);
  }

  public unsafe void OpenObjectEditorFor(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InObjects)
  {
    TIndexedContainerIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
    \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, InObjects);
    if (!\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      return;
    do
    {
      UObject* uobjectPtr1 = (UObject*) *(long*) \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
      if ((IntPtr) uobjectPtr1 != IntPtr.Zero)
      {
        TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) this.ClassToBrowsableObjectTypeMap.op_MemberSelection(), \u003CModule\u003E.UObject\u002EGetClass(uobjectPtr1));
        if ((IntPtr) fdefaultAllocatorPtr != IntPtr.Zero)
        {
          int num = 0;
          if (0 < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr))
          {
            do
            {
              UGenericBrowserType* ugenericBrowserTypePtr1 = (UGenericBrowserType*) *(long*) \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, num);
              if (\u003CModule\u003E.UGenericBrowserType\u002ESupports(ugenericBrowserTypePtr1, uobjectPtr1) != 0U)
              {
                UGenericBrowserType* ugenericBrowserTypePtr2 = ugenericBrowserTypePtr1;
                UObject* uobjectPtr2 = uobjectPtr1;
                // ISSUE: cast to a function pointer type
                // ISSUE: function pointer call
                if (__calli((__FnPtr<uint (IntPtr, UObject*)>) *(long*) (*(long*) ugenericBrowserTypePtr1 + 640L))((UObject*) ugenericBrowserTypePtr2, (IntPtr) uobjectPtr2) != 0U)
                  break;
              }
              ++num;
            }
            while (num < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr));
          }
        }
      }
      \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
    }
    while (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
  }

  public virtual unsafe void QueryAssetViewContextMenuItems(ref List<object> OutMenuItems)
  {
    this.LoadSelectedObjectsIfNeeded();
    TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      int InDefaultCommandId;
      this.QuerySupportedCommands(&fdefaultAllocator, &InDefaultCommandId);
      this.BuildContextMenu(&fdefaultAllocator, InDefaultCommandId, typeof (AssetView), ((UIElement) this.ContentBrowserCtrl.AssetView).CommandBindings, ref OutMenuItems);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  public unsafe void QueryPackageTreeContextMenuItems(
    TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E* OutSupportedCommands)
  {
    \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EEmpty(OutSupportedCommands, 0);
    FString fstring1;
    FString* fstringPtr1 = \u003CModule\u003E.LocalizeUnrealEd(&fstring1, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D46, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D45, (char*) 0L);
    FObjectSupportedCommandType supportedCommandType1;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FObjectSupportedCommandType\u002E\u007Bctor\u007D(&supportedCommandType1, 22904, fstringPtr1, 1U, -1);
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
      int num = \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EAddItem(OutSupportedCommands, &supportedCommandType1);
      \u003CModule\u003E.UEditorEngine\u002ECreateSoundClassMenuForContentBrowser(\u003CModule\u003E.GEditor, OutSupportedCommands, num);
      FString fstring2;
      FString* fstringPtr2 = \u003CModule\u003E.LocalizeUnrealEd(&fstring2, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D48, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D47, (char*) 0L);
      FObjectSupportedCommandType supportedCommandType2;
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FObjectSupportedCommandType\u002E\u007Bctor\u007D(&supportedCommandType2, 23110, fstringPtr2, 1U, num);
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
        FString fstring3;
        FString* fstringPtr3 = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D50, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D49, (char*) 0L);
        FObjectSupportedCommandType supportedCommandType3;
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FObjectSupportedCommandType\u002E\u007Bctor\u007D(&supportedCommandType3, 23111, fstringPtr3, 1U, num);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          FString fstring4;
          FString* fstringPtr4 = \u003CModule\u003E.LocalizeUnrealEd(&fstring4, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D52, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D51, (char*) 0L);
          FObjectSupportedCommandType supportedCommandType4;
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FObjectSupportedCommandType\u002E\u007Bctor\u007D(&supportedCommandType4, 23112, fstringPtr4, 1U, num);
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
            \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EAddItem(OutSupportedCommands, &supportedCommandType2);
            \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EAddItem(OutSupportedCommands, &supportedCommandType3);
            \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EAddItem(OutSupportedCommands, &supportedCommandType4);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectSupportedCommandType\u002E\u007Bdtor\u007D), (void*) &supportedCommandType4);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &supportedCommandType4 + 8));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectSupportedCommandType\u002E\u007Bdtor\u007D), (void*) &supportedCommandType3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &supportedCommandType3 + 8));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectSupportedCommandType\u002E\u007Bdtor\u007D), (void*) &supportedCommandType2);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &supportedCommandType2 + 8));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectSupportedCommandType\u002E\u007Bdtor\u007D), (void*) &supportedCommandType1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &supportedCommandType1 + 8));
  }

  public unsafe void QuerySupportedCommands(
    TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E* OutSupportedCommands,
    int* DefaultCommandID)
  {
    \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EEmpty(OutSupportedCommands, 0);
    TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
    \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
    // ISSUE: fault handler
    try
    {
      IEnumerator enumerator = ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems.GetEnumerator();
label_2:
      try
      {
        while (enumerator.MoveNext())
        {
          AssetItem current = (AssetItem) enumerator.Current;
          UObject* uobjectPtr = (UObject*) 0L;
          FString fstring1;
          FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, current.AssetType);
          UClass* objectClassUclass;
          // ISSUE: fault handler
          try
          {
            objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          if ((IntPtr) objectClassUclass != IntPtr.Zero)
          {
            FString fstring3;
            FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, current.FullyQualifiedPath);
            // ISSUE: fault handler
            try
            {
              uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
            if ((IntPtr) uobjectPtr != IntPtr.Zero)
            {
              TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) this.ClassToBrowsableObjectTypeMap.op_MemberSelection(), \u003CModule\u003E.UObject\u002EGetClass(uobjectPtr));
              if ((IntPtr) fdefaultAllocatorPtr != IntPtr.Zero)
              {
                int num = 0;
                UGenericBrowserType* ugenericBrowserTypePtr;
                while (true)
                {
                  if (num < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr))
                  {
                    ugenericBrowserTypePtr = (UGenericBrowserType*) *(long*) \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, num);
                    if (\u003CModule\u003E.UGenericBrowserType\u002ESupports(ugenericBrowserTypePtr, uobjectPtr) == 0U)
                      ++num;
                    else
                      break;
                  }
                  else
                    goto label_2;
                }
                \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(&fdefaultAllocator1, &ugenericBrowserTypePtr);
              }
            }
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable disposable4)
          disposable4.Dispose();
      }
      *DefaultCommandID = -1;
      if (\u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1) == 1)
      {
        UGenericBrowserType* ugenericBrowserTypePtr1 = (UGenericBrowserType*) *(long*) \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, 0);
        bool flag = false;
        foreach (AssetItem selectedItem in (IEnumerable) ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems)
        {
          UObject* uobjectPtr = (UObject*) 0L;
          FString fstring1;
          FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, selectedItem.AssetType);
          UClass* objectClassUclass;
          // ISSUE: fault handler
          try
          {
            objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          if ((IntPtr) objectClassUclass != IntPtr.Zero)
          {
            FString fstring3;
            FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, selectedItem.FullyQualifiedPath);
            // ISSUE: fault handler
            try
            {
              uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
            if ((IntPtr) uobjectPtr != IntPtr.Zero && \u003CModule\u003E.UGenericBrowserType\u002ESupports(ugenericBrowserTypePtr1, uobjectPtr) != 0U)
            {
              flag = true;
              break;
            }
          }
        }
        if (flag)
        {
          USelection* selectedObjects = \u003CModule\u003E.UEditorEngine\u002EGetSelectedObjects(\u003CModule\u003E.GEditor);
          UGenericBrowserType* ugenericBrowserTypePtr2 = ugenericBrowserTypePtr1;
          USelection* uselectionPtr = selectedObjects;
          TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = OutSupportedCommands;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, USelection*, TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E*)>) *(long*) (*(long*) ugenericBrowserTypePtr1 + 664L))((TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E*) ugenericBrowserTypePtr2, uselectionPtr, (IntPtr) fdefaultAllocatorPtr);
          TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator2;
          \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.USelection\u002EGetSelectedObjects(selectedObjects, &fdefaultAllocator2);
            int* numPtr = DefaultCommandID;
            UGenericBrowserType* ugenericBrowserTypePtr3 = ugenericBrowserTypePtr1;
            ref TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E local = ref fdefaultAllocator2;
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            int num = __calli((__FnPtr<int (IntPtr, TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*)>) *(long*) (*(long*) ugenericBrowserTypePtr1 + 672L))((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ugenericBrowserTypePtr3, (IntPtr) ref local);
            *numPtr = num;
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
          }
          \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
        }
      }
      if (\u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1) > 0)
      {
        if (\u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002ENum(OutSupportedCommands) > 0)
        {
          FString fstring;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D53);
          // ISSUE: fault handler
          try
          {
            FObjectSupportedCommandType supportedCommandType;
            FObjectSupportedCommandType* supportedCommandTypePtr = \u003CModule\u003E.FObjectSupportedCommandType\u002E\u007Bctor\u007D(&supportedCommandType, -1, &fstring, 1U, -1);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EAddItem(OutSupportedCommands, supportedCommandTypePtr);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectSupportedCommandType\u002E\u007Bdtor\u007D), (void*) &supportedCommandType);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &supportedCommandType + 8));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
        }
        \u003CModule\u003E.UGenericBrowserType\u002EQueryStandardSupportedCommands(\u003CModule\u003E.UEditorEngine\u002EGetSelectedObjects(\u003CModule\u003E.GEditor), OutSupportedCommands);
        FString fstring1;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D54);
        // ISSUE: fault handler
        try
        {
          FObjectSupportedCommandType supportedCommandType;
          FObjectSupportedCommandType* supportedCommandTypePtr = \u003CModule\u003E.FObjectSupportedCommandType\u002E\u007Bctor\u007D(&supportedCommandType, -1, &fstring1, 1U, -1);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EAddItem(OutSupportedCommands, supportedCommandTypePtr);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectSupportedCommandType\u002E\u007Bdtor\u007D), (void*) &supportedCommandType);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &supportedCommandType + 8));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        char* chPtr1 = \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1) != 1 ? (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D55 : \u003CModule\u003E.FString\u002E\u002A((FString*) (*(long*) \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, 0) + 96L));
        char* chPtr2 = \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1) != 1 ? (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D56 : \u003CModule\u003E.FString\u002E\u002A((FString*) (*(long*) \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, 0) + 96L));
        FString fstring2;
        FString* fstringPtr1 = \u003CModule\u003E.LocalizeUnrealEd(&fstring2, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D58, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D57, (char*) 0L);
        // ISSUE: fault handler
        try
        {
          FString fstring3;
          FString* fstringPtr2 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring3, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr1)), chPtr2), chPtr1);
          // ISSUE: fault handler
          try
          {
            FString fstring4;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring4, \u003CModule\u003E.FString\u002E\u002A(fstringPtr2));
            // ISSUE: fault handler
            try
            {
              FObjectSupportedCommandType supportedCommandType;
              FObjectSupportedCommandType* supportedCommandTypePtr = \u003CModule\u003E.FObjectSupportedCommandType\u002E\u007Bctor\u007D(&supportedCommandType, 11296, &fstring4, 1U, -1);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EAddItem(OutSupportedCommands, supportedCommandTypePtr);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectSupportedCommandType\u002E\u007Bdtor\u007D), (void*) &supportedCommandType);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &supportedCommandType + 8));
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
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
      }
      uint num1 = 0;
      foreach (AssetItem selectedItem in (IEnumerable) ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems)
        num1 = num1 != 0U || this.AssetUsesSharedThumbnail(selectedItem) ? 1U : 0U;
      if (num1 != 0U)
      {
        bool flag1 = (IntPtr) \u003CModule\u003E.GCurrentLevelEditingViewportClient != 0L;
        FString fstring1;
        FString* fstringPtr1 = \u003CModule\u003E.LocalizeUnrealEd(&fstring1, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D60, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D59, (char*) 0L);
        // ISSUE: fault handler
        try
        {
          FString fstring2;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(fstringPtr1));
          // ISSUE: fault handler
          try
          {
            FObjectSupportedCommandType supportedCommandType;
            FObjectSupportedCommandType* supportedCommandTypePtr = \u003CModule\u003E.FObjectSupportedCommandType\u002E\u007Bctor\u007D(&supportedCommandType, 11293, &fstring2, (uint) flag1, -1);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EAddItem(OutSupportedCommands, supportedCommandTypePtr);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectSupportedCommandType\u002E\u007Bdtor\u007D), (void*) &supportedCommandType);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &supportedCommandType + 8));
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
        long num2 = *(long*) ((IntPtr) \u003CModule\u003E.GEditor + 1732L);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        bool flag2 = (IntPtr) __calli((__FnPtr<FViewport* (IntPtr)>) *(long*) (*(long*) num2 + 672L))((IntPtr) num2) != 0L;
        FString fstring3;
        FString* fstringPtr2 = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D62, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D61, (char*) 0L);
        // ISSUE: fault handler
        try
        {
          FString fstring2;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(fstringPtr2));
          // ISSUE: fault handler
          try
          {
            FObjectSupportedCommandType supportedCommandType;
            FObjectSupportedCommandType* supportedCommandTypePtr = \u003CModule\u003E.FObjectSupportedCommandType\u002E\u007Bctor\u007D(&supportedCommandType, 11294, &fstring2, (uint) flag2, -1);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EAddItem(OutSupportedCommands, supportedCommandTypePtr);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectSupportedCommandType\u002E\u007Bdtor\u007D), (void*) &supportedCommandType);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &supportedCommandType + 8));
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
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
        FString fstring4;
        FString* fstringPtr3 = \u003CModule\u003E.LocalizeUnrealEd(&fstring4, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D64, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D63, (char*) 0L);
        // ISSUE: fault handler
        try
        {
          FString fstring2;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(fstringPtr3));
          // ISSUE: fault handler
          try
          {
            FObjectSupportedCommandType supportedCommandType;
            FObjectSupportedCommandType* supportedCommandTypePtr = \u003CModule\u003E.FObjectSupportedCommandType\u002E\u007Bctor\u007D(&supportedCommandType, 11295, &fstring2, 1U, -1);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002EAddItem(OutSupportedCommands, supportedCommandTypePtr);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectSupportedCommandType\u002E\u007Bdtor\u007D), (void*) &supportedCommandType);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &supportedCommandType + 8));
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
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
      }
      *DefaultCommandID = this.DetermineDefaultCommand(*DefaultCommandID, OutSupportedCommands);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
  }

  public unsafe void BuildContextMenu(
    TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E* InCommands,
    int InDefaultCommandId,
    System.Type InTypeID,
    CommandBindingCollection InOutCommandBindingList,
    ref List<object> OutMenuItems)
  {
    Dictionary<int, MenuItem> dictionary = new Dictionary<int, MenuItem>();
    OutMenuItems = new List<object>();
    int key1 = 0;
    if (0 >= \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002ENum(InCommands))
      return;
    do
    {
      FObjectSupportedCommandType* supportedCommandTypePtr = \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InCommands, key1);
      if (*(int*) supportedCommandTypePtr != -1)
      {
        MenuItem menuItem = new MenuItem();
        menuItem.Command = (ICommand) new RoutedUICommand(\u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) supportedCommandTypePtr + 8L)), "CustomObjectCommand", InTypeID);
        InOutCommandBindingList.Add(new CommandBinding(menuItem.Command, new ExecutedRoutedEventHandler(this.OnCustomObjectCommand), new CanExecuteRoutedEventHandler(this.CanExecuteCustomObjectCommand)));
        menuItem.CommandParameter = (object) *(int*) supportedCommandTypePtr;
        if (InDefaultCommandId != -1 && *(int*) supportedCommandTypePtr == InDefaultCommandId)
        {
          FontWeight bold = FontWeights.Bold;
          menuItem.FontWeight = bold;
        }
        menuItem.IsEnabled = (*(int*) ((IntPtr) supportedCommandTypePtr + 24L) & 1) != 0;
        dictionary.Add(key1, menuItem);
        int key2 = *(int*) ((IntPtr) supportedCommandTypePtr + 4L);
        if (key2 == -1)
          OutMenuItems.Add((object) menuItem);
        else
          dictionary[key2]?.Items.Add((object) menuItem);
      }
      else
      {
        Separator separator = new Separator();
        OutMenuItems.Add((object) separator);
      }
      ++key1;
    }
    while (key1 < \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002ENum(InCommands));
  }

  public virtual unsafe List<string> QueryCollectionsForAsset(
    string InFullName,
    EBrowserCollectionType InType)
  {
    List<string> stringList1 = (List<string>) null;
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    // ISSUE: cast to a reference type
    // ISSUE: variable of a reference type
    byte* local1 = (byte*) InFullName;
    if (local1 != null)
      local1 = (long) (uint) RuntimeHelpers.OffsetToStringData + local1;
    // ISSUE: explicit reference operation
    fixed (byte* numPtr = &^local1)
    {
      FName fname;
      \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (char*) numPtr, (EFindName) 1, 1U);
      FName InAssetFullNameFName = fname;
      ref List<string> local2 = ref stringList1;
      \u003CModule\u003E.FGameAssetDatabase\u002EQueryTagsForAsset(database0PeaV1Ea, InAssetFullNameFName, (ETagQueryOptions.Type) 3, out local2);
      ESystemTagType esystemTagType = InType == 0 ? ESystemTagType.SharedCollection : ESystemTagType.PrivateCollection;
      List<string> stringList2 = new List<string>();
      List<string>.Enumerator enumerator = stringList1.GetEnumerator();
      long num = (long) esystemTagType;
      if (enumerator.MoveNext())
      {
        do
        {
          string current = enumerator.Current;
          if (\u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagType(current) == esystemTagType && (num != 4L || \u003CModule\u003E.FGameAssetDatabase\u002EIsMyPrivateCollection(current)))
          {
            string systemTagValue = \u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagValue(current);
            stringList2.Add(systemTagValue);
          }
        }
        while (enumerator.MoveNext());
      }
      stringList2.Sort();
      return stringList2;
    }
  }

  public virtual void OnAssetSelectionChanged(
    object Sender,
    AssetView.AssetSelectionChangedEventArgs Args)
  {
    this.SyncSelectedObjectsWithGlobalSelectionSet();
  }

  public virtual unsafe void LoadAndActivateSelectedAssets()
  {
    this.LoadSelectedObjectsIfNeeded();
    TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      int InCommandId;
      this.QuerySupportedCommands(&fdefaultAllocator, &InCommandId);
      this.ExecuteCustomObjectCommand(InCommandId);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  public virtual unsafe void LoadAndDisplayPropertiesForSelectedAssets()
  {
    this.LoadSelectedObjectsIfNeeded();
    TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      int num;
      this.QuerySupportedCommands(&fdefaultAllocator, &num);
      TIndexedContainerConstIterator\u003CTArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, &fdefaultAllocator);
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        while (*(int*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt) != 11274)
        {
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
          if (!\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
            goto label_6;
        }
        this.ExecuteCustomObjectCommand(11274);
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
label_6:
    \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool PreviewLoadedAsset(string ObjectFullName)
  {
    bool flag1 = false;
    if (ObjectFullName != (string) null)
    {
      FString fstring1;
      \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Utils.GetClassNameFromFullName(ObjectFullName));
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, Utils.GetPathFromFullName(ObjectFullName));
        // ISSUE: fault handler
        try
        {
          UClass* objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(&fstring1), 0U);
          if ((IntPtr) objectClassUclass != IntPtr.Zero)
          {
            UObject* uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(&fstring2), 0U);
            if ((IntPtr) uobjectPtr != IntPtr.Zero)
            {
              TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) this.ClassToBrowsableObjectTypeMap.op_MemberSelection(), \u003CModule\u003E.UObject\u002EGetClass(uobjectPtr));
              if ((IntPtr) fdefaultAllocatorPtr != IntPtr.Zero)
              {
                int num = 0;
                if (0 < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr))
                {
                  UGenericBrowserType* ugenericBrowserTypePtr;
                  bool flag2;
                  UGenericBrowserType_Sounds* browserTypeSoundsPtr;
                  USoundCue* usoundCuePtr;
                  USoundNode* usoundNodePtr;
                  do
                  {
                    ugenericBrowserTypePtr = (UGenericBrowserType*) *(long*) \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, num);
                    if (\u003CModule\u003E.UObject\u002EIsA((UObject*) ugenericBrowserTypePtr, \u003CModule\u003E.UGenericBrowserType_Sounds\u002EStaticClass()) != 0U)
                    {
                      flag2 = string.Equals(ObjectFullName, this.LastPreviewedAssetFullName, StringComparison.OrdinalIgnoreCase);
                      browserTypeSoundsPtr = \u003CModule\u003E.Cast\u003Cclass\u0020UGenericBrowserType_Sounds\u003E((UObject*) ugenericBrowserTypePtr);
                      usoundCuePtr = \u003CModule\u003E.Cast\u003Cclass\u0020USoundCue\u003E(uobjectPtr);
                      usoundNodePtr = (USoundNode*) \u003CModule\u003E.Cast\u003Cclass\u0020USoundNodeWave\u003E(uobjectPtr);
                      if ((IntPtr) usoundCuePtr == IntPtr.Zero)
                      {
                        if ((IntPtr) usoundNodePtr != IntPtr.Zero)
                          goto label_14;
                      }
                      else
                        goto label_11;
                    }
                    ++num;
                  }
                  while (num < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr));
                  goto label_18;
label_11:
                  if (\u003CModule\u003E.UGenericBrowserType_Sounds\u002EIsPlaying(browserTypeSoundsPtr, usoundCuePtr) && flag2)
                  {
                    \u003CModule\u003E.UGenericBrowserType_Sounds\u002EStop(browserTypeSoundsPtr);
                    goto label_18;
                  }
                  else
                  {
                    flag1 = true;
                    \u003CModule\u003E.UGenericBrowserType_Sounds\u002EPlay(\u003CModule\u003E.Cast\u003Cclass\u0020UGenericBrowserType_Sounds\u003E((UObject*) ugenericBrowserTypePtr), usoundCuePtr);
                    this.LastPreviewedAssetFullName = ObjectFullName;
                    goto label_18;
                  }
label_14:
                  if (\u003CModule\u003E.UGenericBrowserType_Sounds\u002EIsPlaying(browserTypeSoundsPtr, usoundNodePtr) && flag2)
                  {
                    \u003CModule\u003E.UGenericBrowserType_Sounds\u002EStop(browserTypeSoundsPtr);
                  }
                  else
                  {
                    flag1 = true;
                    \u003CModule\u003E.UGenericBrowserType_Sounds\u002EPlay(\u003CModule\u003E.Cast\u003Cclass\u0020UGenericBrowserType_Sounds\u003E((UObject*) ugenericBrowserTypePtr), usoundNodePtr);
                    this.LastPreviewedAssetFullName = ObjectFullName;
                  }
                }
              }
            }
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
label_18:
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
    return flag1;
  }

  public virtual unsafe List<string> GetObjectTypeFilterList()
  {
    List<string> stringList = new List<string>();
    int num = 0;
    if (0 < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.BrowsableObjectTypeList.op_MemberSelection()))
    {
      do
      {
        FString* browserTypeDescription = \u003CModule\u003E.UGenericBrowserType\u002EGetBrowserTypeDescription((UGenericBrowserType*) *(long*) \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(this.BrowsableObjectTypeList.Get(), num));
        string str = new string(\u003CModule\u003E.FString\u002E\u002A(browserTypeDescription), 0, \u003CModule\u003E.FString\u002ELen(browserTypeDescription));
        stringList.Add(str);
        ++num;
      }
      while (num < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.BrowsableObjectTypeList.op_MemberSelection()));
    }
    return stringList;
  }

  public virtual List<string> GetBrowsableTypeNameList(List<string> ClassNameList)
  {
    List<string> stringList = new List<string>();
    int count1 = ClassNameList.Count;
    int index1 = 0;
    if (0 < count1)
    {
      do
      {
        List<string> browsableTypeName = this.ClassNameToBrowsableTypeNameMap[ClassNameList[index1]];
        int count2 = browsableTypeName.Count;
        int index2 = 0;
        if (0 < count2)
        {
          do
          {
            if (!stringList.Contains(browsableTypeName[index2]))
              stringList.Add(browsableTypeName[index2]);
            ++index2;
          }
          while (index2 < count2);
        }
        ++index1;
      }
      while (index1 < count1);
    }
    return stringList;
  }

  public virtual unsafe void SaveContentBrowserUIState(ContentBrowserUIState SaveMe)
  {
    PropertyInfo[] properties = typeof (ContentBrowserUIState).GetProperties(BindingFlags.Instance | BindingFlags.Public);
    FString fstring1;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CM\u0040PKKKPCEN\u0040\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAr\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AAs\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAU\u003F\u0024AAI\u003F\u0024AAS\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040);
    // ISSUE: fault handler
    try
    {
      int index = 0;
      if (0 < properties.Length)
      {
        do
        {
          FString fstring2;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, properties[index].Name);
          // ISSUE: fault handler
          try
          {
            if (properties[index].PropertyType == typeof (bool))
              \u003CModule\u003E.FConfigCacheIni\u002ESetBool(\u003CModule\u003E.GConfig, \u003CModule\u003E.FString\u002E\u002A(&fstring1), \u003CModule\u003E.FString\u002E\u002A(&fstring2), (uint) (bool) properties[index].GetValue((object) SaveMe, (object[]) null), (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
            else if (properties[index].PropertyType == typeof (double))
              \u003CModule\u003E.FConfigCacheIni\u002ESetDouble(\u003CModule\u003E.GConfig, \u003CModule\u003E.FString\u002E\u002A(&fstring1), \u003CModule\u003E.FString\u002E\u002A(&fstring2), (double) properties[index].GetValue((object) SaveMe, (object[]) null), (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
            else if (properties[index].PropertyType == typeof (string))
            {
              string InCLRString = (string) properties[index].GetValue((object) SaveMe, (object[]) null);
              FString fstring3;
              FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, InCLRString);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.FConfigCacheIni\u002ESetString(\u003CModule\u003E.GConfig, \u003CModule\u003E.FString\u002E\u002A(&fstring1), \u003CModule\u003E.FString\u002E\u002A(&fstring2), \u003CModule\u003E.FString\u002E\u002A(fstring4), (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
            }
            else
              \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GError, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1JK\u0040BLOEMIIA\u0040\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAr\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AAs\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAU\u003F\u0024AAI\u003F\u0024AAS\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AA\u003F4\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA\u003F5\u003F\u0024AAc\u003F\u0024AAo\u003F\u0024AAu\u003F\u0024AAl\u003F\u0024AAd\u003F\u0024AA\u003F5\u003F\u0024AAn\u0040, \u003CModule\u003E.FString\u002E\u002A(&fstring2));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          ++index;
        }
        while (index < properties.Length);
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
  }

  public virtual unsafe void LoadContentBrowserUIState(ContentBrowserUIState LoadMe)
  {
    LoadMe.SetToDefault();
    PropertyInfo[] properties = typeof (ContentBrowserUIState).GetProperties(BindingFlags.Instance | BindingFlags.Public);
    FString fstring1;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CM\u0040PKKKPCEN\u0040\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAr\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AAs\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAU\u003F\u0024AAI\u003F\u0024AAS\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040);
    // ISSUE: fault handler
    try
    {
      int index = 0;
      if (0 < properties.Length)
      {
        do
        {
          FString fstring2;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, properties[index].Name);
          // ISSUE: fault handler
          try
          {
            if (properties[index].PropertyType == typeof (bool))
            {
              uint num1;
              if (\u003CModule\u003E.FConfigCacheIni\u002EGetBool(\u003CModule\u003E.GConfig, \u003CModule\u003E.FString\u002E\u002A(&fstring1), \u003CModule\u003E.FString\u002E\u002A(&fstring2), &num1, (char*) &\u003CModule\u003E.GEditorUserSettingsIni) != 0U)
              {
                int num2 = num1 == 1U ? 1 : 0;
                properties[index].SetValue((object) LoadMe, (object) (bool) num2, (object[]) null);
              }
            }
            else if (properties[index].PropertyType == typeof (double))
            {
              double num;
              if (\u003CModule\u003E.FConfigCacheIni\u002EGetDouble(\u003CModule\u003E.GConfig, \u003CModule\u003E.FString\u002E\u002A(&fstring1), \u003CModule\u003E.FString\u002E\u002A(&fstring2), &num, (char*) &\u003CModule\u003E.GEditorUserSettingsIni) != 0U)
              {
                num = \u003CModule\u003E.Max\u003Cdouble\u003E(num, 0.0);
                properties[index].SetValue((object) LoadMe, (object) num, (object[]) null);
              }
            }
            else if (properties[index].PropertyType == typeof (string))
            {
              FString fstring3;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3);
              // ISSUE: fault handler
              try
              {
                if (\u003CModule\u003E.FConfigCacheIni\u002EGetString(\u003CModule\u003E.GConfig, \u003CModule\u003E.FString\u002E\u002A(&fstring1), \u003CModule\u003E.FString\u002E\u002A(&fstring2), &fstring3, (char*) &\u003CModule\u003E.GEditorUserSettingsIni) != 0U)
                {
                  string str = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring3), 0, \u003CModule\u003E.FString\u002ELen(&fstring3));
                  properties[index].SetValue((object) LoadMe, (object) str, (object[]) null);
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
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          ++index;
        }
        while (index < properties.Length);
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
  }

  public unsafe void OnCloseButtonClicked(object Sender, RoutedEventArgs CloseEventArgs)
  {
    WxContentBrowserHost* parentBrowserWindow = this.ParentBrowserWindow;
    if ((IntPtr) parentBrowserWindow == IntPtr.Zero || \u003CModule\u003E.WxBrowser\u002EIsFloating((WxBrowser*) parentBrowserWindow) == 0U && \u003CModule\u003E.UBrowserManager\u002EIsCanonicalBrowser(\u003CModule\u003E.UUnrealEdEngine\u002EGetBrowserManager(\u003CModule\u003E.GUnrealEd), \u003CModule\u003E.WxBrowser\u002EGetDockID((WxBrowser*) this.ParentBrowserWindow)) != 0U)
      return;
    \u003CModule\u003E.FContentBrowser\u002EMakeAppropriateContentBrowserActive(this.NativeBrowserPtr);
    WxDockEvent wxDockEvent;
    \u003CModule\u003E.WxDockEvent\u002E\u007Bctor\u007D(&wxDockEvent, \u003CModule\u003E.WxBrowser\u002EGetDockID((WxBrowser*) this.ParentBrowserWindow), (EDockingChangeType) 3);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.wxEvent\u002ESetEventType((wxEvent*) &wxDockEvent, \u003CModule\u003E.wxEVT_DOCKINGCHANGE);
      \u003CModule\u003E.wxPostEvent((wxEvtHandler*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), (wxEvent*) &wxDockEvent);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxDockEvent\u002E\u007Bdtor\u007D), (void*) &wxDockEvent);
    }
    \u003CModule\u003E.WxDockEvent\u002E\u007Bdtor\u007D(&wxDockEvent);
  }

  public unsafe void OnCloneButtonClicked(object Sender, RoutedEventArgs CloseEventArgs)
  {
    \u003CModule\u003E.UBrowserManager\u002EShowDockingContainer(\u003CModule\u003E.UUnrealEdEngine\u002EGetBrowserManager(\u003CModule\u003E.GUnrealEd));
    WxContentBrowserHost* parentBrowserWindow = this.ParentBrowserWindow;
    if ((IntPtr) parentBrowserWindow == IntPtr.Zero)
      return;
    WxDockEvent wxDockEvent;
    \u003CModule\u003E.WxDockEvent\u002E\u007Bctor\u007D(&wxDockEvent, \u003CModule\u003E.WxBrowser\u002EGetDockID((WxBrowser*) parentBrowserWindow), (EDockingChangeType) 2);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.wxEvent\u002ESetEventType((wxEvent*) &wxDockEvent, \u003CModule\u003E.wxEVT_DOCKINGCHANGE);
      \u003CModule\u003E.wxPostEvent((wxEvtHandler*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), (wxEvent*) &wxDockEvent);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxDockEvent\u002E\u007Bdtor\u007D), (void*) &wxDockEvent);
    }
    \u003CModule\u003E.WxDockEvent\u002E\u007Bdtor\u007D(&wxDockEvent);
  }

  public unsafe void OnFloatOrDockButtonClicked(object Sender, RoutedEventArgs CloseEventArgs)
  {
    WxContentBrowserHost* parentBrowserWindow = this.ParentBrowserWindow;
    if ((IntPtr) parentBrowserWindow == IntPtr.Zero)
      return;
    EDockingChangeType edockingChangeType = \u003CModule\u003E.WxBrowser\u002EIsDocked((WxBrowser*) parentBrowserWindow) != 0U ? (EDockingChangeType) 1 : (EDockingChangeType) 0;
    WxDockEvent wxDockEvent;
    \u003CModule\u003E.WxDockEvent\u002E\u007Bctor\u007D(&wxDockEvent, \u003CModule\u003E.WxBrowser\u002EGetDockID((WxBrowser*) this.ParentBrowserWindow), edockingChangeType);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.wxEvent\u002ESetEventType((wxEvent*) &wxDockEvent, \u003CModule\u003E.wxEVT_DOCKINGCHANGE);
      \u003CModule\u003E.wxPostEvent((wxEvtHandler*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), (wxEvent*) &wxDockEvent);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxDockEvent\u002E\u007Bdtor\u007D), (void*) &wxDockEvent);
    }
    \u003CModule\u003E.WxDockEvent\u002E\u007Bdtor\u007D(&wxDockEvent);
  }

  public unsafe void OnKeyPressed(object Sender, KeyEventArgs EventArgs)
  {
    uint num1 = Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.LeftCtrl) ? 1U : 0U;
    uint num2 = Keyboard.IsKeyDown(Key.RightShift) || Keyboard.IsKeyDown(Key.LeftShift) ? 1U : 0U;
    uint num3 = Keyboard.IsKeyDown(Key.RightAlt) || Keyboard.IsKeyDown(Key.LeftAlt) ? 1U : 0U;
    uint num4 = Keyboard.IsKeyDown(Key.Return) || Keyboard.IsKeyDown(Key.Return) ? 1U : 0U;
    FString fstring;
    \u003CModule\u003E.CLRTools\u002EToFString(&fstring, EventArgs.Key.ToString());
    // ISSUE: fault handler
    try
    {
      FName fname1;
      FName fname2;
      FName* fnamePtr = num4 == 0U ? \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname2, \u003CModule\u003E.FString\u002E\u002A(&fstring), (EFindName) 1, 1U) : \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1M\u0040FCNBKECH\u0040\u003F\u0024AAE\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (EFindName) 1, 1U);
      FName fname3;
      // ISSUE: cpblk instruction
      __memcpy(ref fname3, (IntPtr) fnamePtr, 8);
      int num5 = (int) \u003CModule\u003E.WxUnrealEdApp\u002ECheckIfGlobalHotkey(fname3, num1, num2, num3);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  public void OnMouseButtonPressed(object Sender, MouseButtonEventArgs EventArgs)
  {
    switch (EventArgs.ChangedButton)
    {
      case MouseButton.XButton1:
        this.ContentBrowserCtrl.HistoryGoBack();
        break;
      case MouseButton.XButton2:
        this.ContentBrowserCtrl.HistoryGoForward();
        break;
    }
  }

  public unsafe void CopyThumbnailToWriteableBitmap(
    FObjectThumbnail* InThumbnail,
    WriteableBitmap WriteableBitmap)
  {
    \u003CModule\u003E.ThumbnailToolsCLR\u002ECopyThumbnailToWriteableBitmap(InThumbnail, WriteableBitmap);
  }

  public unsafe WriteableBitmap CreateWriteableBitmapForThumbnail(
    FObjectThumbnail* InThumbnail)
  {
    PixelFormat bgr32 = PixelFormats.Bgr32;
    WriteableBitmap WriteableBitmap = new WriteableBitmap(\u003CModule\u003E.FObjectThumbnail\u002EGetImageWidth(InThumbnail), \u003CModule\u003E.FObjectThumbnail\u002EGetImageHeight(InThumbnail), 96.0, 96.0, bgr32, (BitmapPalette) null);
    \u003CModule\u003E.ThumbnailToolsCLR\u002ECopyThumbnailToWriteableBitmap(InThumbnail, WriteableBitmap);
    return WriteableBitmap;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool AssetUsesSharedThumbnail(AssetItem Asset)
  {
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Asset.AssetType);
    UClass* objectClassUclass;
    // ISSUE: fault handler
    try
    {
      objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 1U);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    if (Asset.IsArchetype)
    {
      if ((IntPtr) objectClassUclass != IntPtr.Zero)
      {
        FString fstring3;
        FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, Asset.FullyQualifiedPath);
        UObject* uobjectPtr;
        // ISSUE: fault handler
        try
        {
          uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
        if ((IntPtr) uobjectPtr != IntPtr.Zero)
        {
          FThumbnailRenderingInfo* renderingInfo = \u003CModule\u003E.UThumbnailManager\u002EGetRenderingInfo(\u003CModule\u003E.UUnrealEdEngine\u002EGetThumbnailManager(\u003CModule\u003E.GUnrealEd), uobjectPtr);
          if ((IntPtr) renderingInfo != IntPtr.Zero && \u003CModule\u003E.UObject\u002EGetClass((UObject*) *(long*) ((IntPtr) renderingInfo + 40L)) != \u003CModule\u003E.UArchetypeThumbnailRenderer\u002EStaticClass())
            goto label_16;
        }
      }
    }
    else if ((IntPtr) objectClassUclass != IntPtr.Zero)
    {
      MScopedNativePointer\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E thumbnailClasses = this.SharedThumbnailClasses;
      if (thumbnailClasses.IsValid())
      {
        int num = 0;
        if (0 < \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(thumbnailClasses.op_MemberSelection()))
        {
          do
          {
            UClass* uclassPtr = (UClass*) *(long*) \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(this.SharedThumbnailClasses.Get(), num);
            if (\u003CModule\u003E.UStruct\u002EIsChildOf((UStruct*) objectClassUclass, (UStruct*) uclassPtr) == 0U)
              ++num;
            else
              goto label_15;
          }
          while (num < \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.SharedThumbnailClasses.op_MemberSelection()));
          goto label_16;
        }
        else
          goto label_16;
      }
      else
        goto label_16;
    }
    else
      goto label_16;
label_15:
    bool flag = true;
    goto label_17;
label_16:
    flag = false;
label_17:
    return flag;
  }

  public unsafe void CaptureThumbnailFromViewport(
    FViewport* InViewport,
    List<AssetItem> InAssetsToAssign)
  {
    FViewport* fviewportPtr1 = InViewport;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    uint num1 = __calli((__FnPtr<uint (IntPtr)>) *(long*) (*(long*) fviewportPtr1 + 16L))((IntPtr) fviewportPtr1);
    FViewport* fviewportPtr2 = InViewport;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    uint num2 = __calli((__FnPtr<uint (IntPtr)>) *(long*) (*(long*) fviewportPtr2 + 24L))((IntPtr) fviewportPtr2);
    TArray\u003CFColor\u002CFDefaultAllocator\u003E fdefaultAllocator1;
    \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
    // ISSUE: fault handler
    try
    {
      FReadSurfaceDataFlags surfaceDataFlags;
      if (\u003CModule\u003E.FRenderTarget\u002EReadPixels((FRenderTarget*) InViewport, &fdefaultAllocator1, *\u003CModule\u003E.FReadSurfaceDataFlags\u002E\u007Bctor\u007D(&surfaceDataFlags, (ERangeCompressionMode) 0, (ECubeFace) 6)) != 0U)
      {
        int num3 = (int) \u003CModule\u003E.Min\u003Cunsigned\u0020long\u003E(num1, num2);
        int num4 = (int) \u003CModule\u003E.Min\u003Cunsigned\u0020long\u003E(256U, (uint) num3);
        TArray\u003CFColor\u002CFDefaultAllocator\u003E fdefaultAllocator2;
        \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          ref TArray\u003CFColor\u002CFDefaultAllocator\u003E local1 = ref fdefaultAllocator2;
          int num5 = num3;
          int num6 = num5 * num5;
          \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002EAdd((TArray\u003CFColor\u002CFDefaultAllocator\u003E*) ref local1, num6);
          int num7 = (int) (num2 - (uint) num3 >> 1);
          int num8 = (int) (num1 - (uint) num3 >> 1);
          if (0 < num3)
          {
            ulong num9 = (ulong) (num3 * 4);
            int num10 = 0;
            int num11 = num7 * (int) num1 + num8;
            int num12 = num3;
            do
            {
              void* voidPtr = (void*) \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, num11);
              // ISSUE: cpblk instruction
              __memcpy((IntPtr) \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator2, num10), (IntPtr) voidPtr, (long) num9);
              num11 += (int) num1;
              num10 += num3;
              num12 += -1;
            }
            while ((uint) num12 > 0U);
          }
          TArray\u003CFColor\u002CFDefaultAllocator\u003E fdefaultAllocator3;
          \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator3);
          // ISSUE: fault handler
          try
          {
            if (num4 < num3)
            {
              int num9 = num3;
              ref TArray\u003CFColor\u002CFDefaultAllocator\u003E local2 = ref fdefaultAllocator2;
              int num10 = num4;
              ref TArray\u003CFColor\u002CFDefaultAllocator\u003E local3 = ref fdefaultAllocator3;
              \u003CModule\u003E.FImageUtils\u002EImageResize(num9, num9, (TArray\u003CFColor\u002CFDefaultAllocator\u003E*) ref local2, num10, num10, (TArray\u003CFColor\u002CFDefaultAllocator\u003E*) ref local3, 1U);
            }
            else
              \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u003D(&fdefaultAllocator3, &fdefaultAllocator2);
            FObjectThumbnail fobjectThumbnail;
            \u003CModule\u003E.FObjectThumbnail\u002E\u007Bctor\u007D(&fobjectThumbnail);
            // ISSUE: fault handler
            try
            {
              ref FObjectThumbnail local2 = ref fobjectThumbnail;
              int num9 = num4;
              \u003CModule\u003E.FObjectThumbnail\u002ESetImageSize((FObjectThumbnail*) ref local2, num9, num9);
              TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = \u003CModule\u003E.FObjectThumbnail\u002EAccessImageData(&fobjectThumbnail);
              int num10 = num4;
              int num11 = (int) ((long) (num10 * num10) * 4L);
              \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002EAdd(fdefaultAllocatorPtr, num11);
              // ISSUE: cpblk instruction
              __memcpy((IntPtr) \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, 0), (IntPtr) \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator3, 0), (long) num11);
              List<AssetItem>.Enumerator enumerator = InAssetsToAssign.GetEnumerator();
              if (enumerator.MoveNext())
              {
                do
                {
                  AssetItem current = enumerator.Current;
                  if (this.AssetUsesSharedThumbnail(current))
                  {
                    FString fstring1;
                    \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, current.FullName);
                    // ISSUE: fault handler
                    try
                    {
                      FString fstring2;
                      \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, current.PackageName);
                      // ISSUE: fault handler
                      try
                      {
                        UPackage* objectClassUpackage = \u003CModule\u003E.FindObject\u003Cclass\u0020UPackage\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(&fstring2), 0U);
                        FObjectThumbnail* fobjectThumbnailPtr = \u003CModule\u003E.ThumbnailTools\u002ECacheThumbnail(&fstring1, &fobjectThumbnail, objectClassUpackage);
                        UPackage* upackagePtr = objectClassUpackage;
                        // ISSUE: cast to a function pointer type
                        // ISSUE: function pointer call
                        __calli((__FnPtr<void (IntPtr, uint)>) *(long*) (*(long*) objectClassUpackage + 464L))((uint) upackagePtr, new IntPtr(1));
                        \u003CModule\u003E.FObjectThumbnail\u002EMarkAsDirty(fobjectThumbnailPtr);
                        AssetVisual visual = (AssetVisual) current.Visual;
                        if (visual != null)
                          visual.ShouldRefreshThumbnail = (__Null) 3;
                        \u003CModule\u003E.FObjectThumbnail\u002ESetCreatedAfterCustomThumbsEnabled(fobjectThumbnailPtr);
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
                }
                while (enumerator.MoveNext());
              }
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectThumbnail\u002E\u007Bdtor\u007D), (void*) &fobjectThumbnail);
            }
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D((TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E*) ((IntPtr) &fobjectThumbnail + 24));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) (ref fobjectThumbnail + 8L));
            }
            \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D((TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E*) ((IntPtr) &fobjectThumbnail + 8));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
          }
          \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003CFColor\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
  }

  public unsafe void ClearCustomThumbnails(List<AssetItem> InAssetsToAssign)
  {
    List<AssetItem>.Enumerator enumerator = InAssetsToAssign.GetEnumerator();
    if (!enumerator.MoveNext())
      return;
    do
    {
      AssetItem current = enumerator.Current;
      if (this.AssetUsesSharedThumbnail(current))
      {
        FString fstring1;
        \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, current.FullName);
        // ISSUE: fault handler
        try
        {
          FString fstring2;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, current.PackageName);
          // ISSUE: fault handler
          try
          {
            UPackage* objectClassUpackage = \u003CModule\u003E.FindObject\u003Cclass\u0020UPackage\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(&fstring2), 0U);
            \u003CModule\u003E.ThumbnailTools\u002ECacheEmptyThumbnail(&fstring1, objectClassUpackage);
            UPackage* upackagePtr = objectClassUpackage;
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            __calli((__FnPtr<void (IntPtr, uint)>) *(long*) (*(long*) objectClassUpackage + 464L))((uint) upackagePtr, new IntPtr(1));
            AssetVisual visual = (AssetVisual) current.Visual;
            if (visual != null)
              visual.ShouldRefreshThumbnail = (__Null) 3;
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
    }
    while (enumerator.MoveNext());
  }

  public void FilterSelectedObjectTypes(List<AssetItem> SelectedItems)
  {
    List<string> ClassNameList = new List<string>();
    List<AssetItem>.Enumerator enumerator = SelectedItems.GetEnumerator();
    if (enumerator.MoveNext())
    {
      do
      {
        AssetItem current = enumerator.Current;
        if (!ClassNameList.Contains(current.AssetType))
          ClassNameList.Add(current.AssetType);
      }
      while (enumerator.MoveNext());
    }
    this.ContentBrowserCtrl.FilterPanel.ObjectTypeFilterTier.SetSelectedOptions(this.GetBrowsableTypeNameList(ClassNameList));
  }

  public virtual unsafe BitmapSource GenerateThumbnailForAsset(
    AssetItem Asset,
    ref bool OutFailedToLoadThumbnail)
  {
    BitmapSource bitmapSource = (BitmapSource) null;
    OutFailedToLoadThumbnail = false;
    FString fstring1;
    \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Asset.FullyQualifiedPath);
    // ISSUE: fault handler
    try
    {
      uint num = (uint) this.AssetUsesSharedThumbnail(Asset);
      TMap\u003CFName\u002CFObjectThumbnail\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
      \u003CModule\u003E.TMap\u003CFName\u002CFObjectThumbnail\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, Asset.FullName);
        // ISSUE: fault handler
        try
        {
          FObjectThumbnail* InThumbnail = \u003CModule\u003E.ThumbnailTools\u002EFindCachedThumbnail(&fstring2);
          if ((IntPtr) InThumbnail != IntPtr.Zero)
          {
            if (\u003CModule\u003E.FObjectThumbnail\u002EIsEmpty(InThumbnail) != 0U)
              InThumbnail = (FObjectThumbnail*) 0L;
            else if (\u003CModule\u003E.FObjectThumbnail\u002EIsDirty(InThumbnail) == 0U)
              goto label_25;
          }
          FString fstring3;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, Asset.AssetType);
          // ISSUE: fault handler
          try
          {
            UObject* uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(\u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(&fstring3), 1U), (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(&fstring1), 0U);
            if (num == 0U && (IntPtr) uobjectPtr != IntPtr.Zero)
              InThumbnail = \u003CModule\u003E.ThumbnailTools\u002EGenerateThumbnailForObject(uobjectPtr);
            if ((IntPtr) InThumbnail == IntPtr.Zero)
            {
              TArray\u003CFName\u002CFDefaultAllocator\u003E fdefaultAllocator;
              \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
              // ISSUE: fault handler
              try
              {
                FName fname;
                \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, \u003CModule\u003E.FString\u002E\u002A(&fstring2), (EFindName) 1, 1U);
                \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, &fname);
                if (\u003CModule\u003E.ThumbnailTools\u002ELoadThumbnailsForObjects(&fdefaultAllocator, &fdefaultSetAllocator) != 0U)
                {
                  InThumbnail = \u003CModule\u003E.TMapBase\u003CFName\u002CFObjectThumbnail\u002C0\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003CFName\u002CFObjectThumbnail\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, fname);
                  if ((IntPtr) InThumbnail == IntPtr.Zero)
                  {
                    OutFailedToLoadThumbnail = true;
                    if ((IntPtr) uobjectPtr == IntPtr.Zero)
                      Asset.IsVerified = false;
                  }
                }
                else
                  OutFailedToLoadThumbnail = true;
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
              }
              \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
            }
            if (num != 0U)
            {
              if ((IntPtr) InThumbnail != IntPtr.Zero)
              {
                if (\u003CModule\u003E.FObjectThumbnail\u002EIsCreatedAfterCustomThumbsEnabled(InThumbnail) == 0U)
                {
                  \u003CModule\u003E.FObjectThumbnail\u002ESetImageSize(InThumbnail, 0, 0);
                  \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002EEmpty(\u003CModule\u003E.FObjectThumbnail\u002EAccessImageData(InThumbnail), 0);
                  InThumbnail = (FObjectThumbnail*) 0L;
                  Asset.IsVerified = true;
                }
              }
            }
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
label_25:
          if ((IntPtr) InThumbnail != IntPtr.Zero)
            bitmapSource = \u003CModule\u003E.ThumbnailToolsCLR\u002ECreateBitmapSourceForThumbnail(InThumbnail);
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
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TMap\u003CFName\u002CFObjectThumbnail\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
      }
      \u003CModule\u003E.TSet\u003CTMapBase\u003CFName\u002CFObjectThumbnail\u002C0\u002CFDefaultSetAllocator\u003E\u003A\u003AFPair\u002CTMapBase\u003CFName\u002CFObjectThumbnail\u002C0\u002CFDefaultSetAllocator\u003E\u003A\u003AKeyFuncs\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D((TSet\u003CTMapBase\u003CFName\u002CFObjectThumbnail\u002C0\u002CFDefaultSetAllocator\u003E\u003A\u003AFPair\u002CTMapBase\u003CFName\u002CFObjectThumbnail\u002C0\u002CFDefaultSetAllocator\u003E\u003A\u003AKeyFuncs\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    return bitmapSource;
  }

  public virtual unsafe BitmapSource GeneratePreviewThumbnailForAsset(
    string ObjectFullName,
    int PreferredSize,
    [MarshalAs(UnmanagedType.U1)] bool IsAnimating,
    BitmapSource ExistingThumbnail)
  {
    BitmapSource bitmapSource = (BitmapSource) null;
    FString fstring1;
    \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Utils.GetClassNameFromFullName(ObjectFullName));
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, Utils.GetPathFromFullName(ObjectFullName));
      // ISSUE: fault handler
      try
      {
        FObjectThumbnail fobjectThumbnail;
        \u003CModule\u003E.FObjectThumbnail\u002E\u007Bctor\u007D(&fobjectThumbnail);
        // ISSUE: fault handler
        try
        {
          UClass* objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(&fstring1), 0U);
          if ((IntPtr) objectClassUclass != IntPtr.Zero)
          {
            UObject* uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(&fstring2), 0U);
            if ((IntPtr) uobjectPtr != IntPtr.Zero)
            {
              if ((IntPtr) \u003CModule\u003E.UThumbnailManager\u002EGetRenderingInfo(\u003CModule\u003E.UUnrealEdEngine\u002EGetThumbnailManager(\u003CModule\u003E.GUnrealEd), uobjectPtr) != IntPtr.Zero)
              {
                int num1 = 2048;
                int num2 = 2048;
                if (2048 > AssetCanvasDefs.NormalThumbnailResolution)
                {
                  do
                  {
                    int num3 = num1 / 2;
                    if (num3 >= PreferredSize)
                    {
                      num1 = num3;
                      num2 /= 2;
                    }
                    else
                      break;
                  }
                  while (num1 > AssetCanvasDefs.NormalThumbnailResolution);
                }
                \u003CModule\u003E.ThumbnailTools\u002ERenderThumbnail(uobjectPtr, (uint) num1, (uint) num2, (ThumbnailTools.EThumbnailTextureFlushMode.Type) 0, &fobjectThumbnail);
                if (IsAnimating)
                {
                  WriteableBitmap WriteableBitmap = (WriteableBitmap) null;
                  if (ExistingThumbnail != null && ExistingThumbnail is WriteableBitmap writeableBitmap13 && (writeableBitmap13.Width == (double) \u003CModule\u003E.FObjectThumbnail\u002EGetImageWidth(&fobjectThumbnail) && writeableBitmap13.Height == (double) \u003CModule\u003E.FObjectThumbnail\u002EGetImageHeight(&fobjectThumbnail)))
                    WriteableBitmap = writeableBitmap13;
                  if (WriteableBitmap == null)
                    WriteableBitmap = this.CreateWriteableBitmapForThumbnail(&fobjectThumbnail);
                  else
                    \u003CModule\u003E.ThumbnailToolsCLR\u002ECopyThumbnailToWriteableBitmap(&fobjectThumbnail, WriteableBitmap);
                  bitmapSource = (BitmapSource) WriteableBitmap;
                }
                else
                  bitmapSource = \u003CModule\u003E.ThumbnailToolsCLR\u002ECreateBitmapSourceForThumbnail(&fobjectThumbnail);
              }
            }
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FObjectThumbnail\u002E\u007Bdtor\u007D), (void*) &fobjectThumbnail);
        }
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D((TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E*) ((IntPtr) &fobjectThumbnail + 24));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) (ref fobjectThumbnail + 8L));
        }
        \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D((TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E*) ((IntPtr) &fobjectThumbnail + 8));
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
    return bitmapSource;
  }

  public virtual unsafe void ClearCachedThumbnailForAsset(string AssetFullName)
  {
    FString fstring1;
    \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, AssetFullName);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2);
      // ISSUE: fault handler
      try
      {
        if (\u003CModule\u003E.ThumbnailTools\u002EQueryPackageFileNameForObject(&fstring1, &fstring2) != 0U)
        {
          FString fstring3;
          FString* fstringPtr = \u003CModule\u003E.FPackageFileCache\u002EPackageFromPath(&fstring3, \u003CModule\u003E.FString\u002E\u002A(&fstring2));
          UPackage* package;
          // ISSUE: fault handler
          try
          {
            package = \u003CModule\u003E.UObject\u002EFindPackage((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          \u003CModule\u003E.ThumbnailTools\u002ECacheThumbnail(&fstring1, (FObjectThumbnail*) 0L, package);
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
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
  }

  public virtual unsafe void LocallyTagAssetAsGhost(AssetItem Asset)
  {
    string str = DateTime.Now.Ticks.ToString();
    string InTag = '['.ToString() + GADDefs.SystemTagTypeNames[7] + (object) ']' + str;
    \u003CModule\u003E.FGameAssetDatabase\u002EAddTagMapping(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, Asset.FullName, InTag, true);
  }

  public virtual unsafe void LocallyRemoveUnverifiedTagFromAsset(AssetItem Asset)
  {
    string str = "";
    string InTag = '['.ToString() + GADDefs.SystemTagTypeNames[6] + (object) ']' + str;
    \u003CModule\u003E.FGameAssetDatabase\u002ERemoveTagMapping(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, Asset.FullName, InTag);
  }

  public virtual unsafe void ApplyAssetSelectionToViewport()
  {
    this.LoadSelectedObjectsIfNeeded();
    USelection* selectedObjects = \u003CModule\u003E.UEditorEngine\u002EGetSelectedObjects(\u003CModule\u003E.GEditor);
    if (\u003CModule\u003E.USelection\u002ENum(selectedObjects) != 1 || (IntPtr) \u003CModule\u003E.USelection\u002EGetTop(selectedObjects, \u003CModule\u003E.UMaterialInterface\u002EStaticClass()) == IntPtr.Zero)
      return;
    UUnrealEdEngine* uunrealEdEnginePtr1 = (UUnrealEdEngine*) ((IntPtr) \u003CModule\u003E.GUnrealEd + 96L);
    UUnrealEdEngine* uunrealEdEnginePtr2 = uunrealEdEnginePtr1;
    ref \u0024ArrayType\u0024\u0024\u0024BY0BB\u0040\u0024\u0024CB_W local = ref \u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D65;
    FOutputDeviceRedirectorBase* glog = \u003CModule\u003E.GLog;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    int num = (int) __calli((__FnPtr<uint (IntPtr, char*, FOutputDevice*)>) *(long*) *(long*) uunrealEdEnginePtr1)((FOutputDevice*) uunrealEdEnginePtr2, (char*) ref local, (IntPtr) glog);
  }

  public virtual NameSet GetAssetTypeNames() => this.AssetTypeNames;

  public virtual unsafe List<string> LoadTypeFilterFavorites()
  {
    FString fstring;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring);
    List<string> stringList1;
    // ISSUE: fault handler
    try
    {
      if (\u003CModule\u003E.FConfigCacheIni\u002EGetString(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CK\u0040PIPBOMPF\u0040\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAr\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AAs\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAF\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CA\u0040OIGHNOMD\u0040\u003F\u0024AAF\u003F\u0024AAa\u003F\u0024AAv\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAT\u003F\u0024AAy\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA_\u003F\u0024AA0\u003F\u0024AA\u003F\u0024AA\u0040, &fstring, (char*) &\u003CModule\u003E.GEditorUserSettingsIni) != 0U)
      {
        string[] strArray = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring), 0, \u003CModule\u003E.FString\u002ELen(&fstring)).Split(new char[1]
        {
          ';'
        }, StringSplitOptions.RemoveEmptyEntries);
        List<string> objectTypeFilterList = this.GetObjectTypeFilterList();
        stringList1 = new List<string>();
        int index = 0;
        if (0 < strArray.Length)
        {
          do
          {
            string str = strArray[index];
            if (objectTypeFilterList.Contains(str))
              stringList1.Add(str);
            ++index;
          }
          while (index < strArray.Length);
        }
      }
      else
        goto label_8;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
    return stringList1;
label_8:
    List<string> stringList2;
    // ISSUE: fault handler
    try
    {
      stringList2 = new List<string>(0);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
    return stringList2;
  }

  public virtual unsafe void SaveTypeFilterFavorites(List<string> InFavorites)
  {
    string InCLRString = string.Join(";", InFavorites.ToArray());
    FString fstring;
    \u003CModule\u003E.CLRTools\u002EToFString(&fstring, InCLRString);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FConfigCacheIni\u002ESetString(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CK\u0040PIPBOMPF\u0040\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAr\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AAs\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAF\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CA\u0040OIGHNOMD\u0040\u003F\u0024AAF\u003F\u0024AAa\u003F\u0024AAv\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAT\u003F\u0024AAy\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA_\u003F\u0024AA0\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.FString\u002E\u002A(&fstring), (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  public virtual void TagInUseObjects()
  {
    EInUseSearchOption einUseSearchOption = (EInUseSearchOption) 0;
    \u003CModule\u003E.ObjectTools\u002ETagInUseObjects(!this.ContentBrowserCtrl.Filter.ShowVisibleLevelsInUse ? (this.ContentBrowserCtrl.Filter.ShowLoadedLevelsInUse ? (EInUseSearchOption) 2 : einUseSearchOption) : (EInUseSearchOption) 1);
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool IsObjectInUse(AssetItem Asset)
  {
    bool flag = false;
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Asset.AssetType);
    UClass* objectClassUclass;
    // ISSUE: fault handler
    try
    {
      objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    if ((IntPtr) objectClassUclass != IntPtr.Zero)
    {
      FString fstring3;
      FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, Asset.FullyQualifiedPath);
      UObject* uobjectPtr1;
      // ISSUE: fault handler
      try
      {
        uobjectPtr1 = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      if ((IntPtr) uobjectPtr1 != IntPtr.Zero)
      {
        uint num1 = (uint) (\u003CModule\u003E.UObject\u002EHasAnyFlags(uobjectPtr1, 68719476736UL) == 0U);
        uint num2 = \u003CModule\u003E.UObject\u002EHasAnyFlags(uobjectPtr1, 34359738368UL);
        if ((IntPtr) \u003CModule\u003E.UObject\u002EGetOuter(uobjectPtr1) != IntPtr.Zero && \u003CModule\u003E.UObject\u002EHasAnyFlags(uobjectPtr1, 70368744177664UL) == 0U)
        {
          UObject* uobjectPtr2 = uobjectPtr1;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          if (__calli((__FnPtr<uint (IntPtr)>) *(long*) (*(long*) uobjectPtr2 + 112L))((IntPtr) uobjectPtr2) == 0U && num1 == 0U && num2 == 0U)
            flag = \u003CModule\u003E.UObject\u002EHasAnyFlags(uobjectPtr1, 17179869184UL) != 0U || flag;
        }
      }
    }
    return flag;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool IsUserTagAdmin()
  {
    uint num1 = 1;
    int num2 = (int) \u003CModule\u003E.FConfigCacheIni\u002EGetBool(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CO\u0040GNOMGEAA\u0040\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAr\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AAs\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAS\u003F\u0024AAe\u003F\u0024AAc\u003F\u0024AAu\u003F\u0024AAr\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAy\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CA\u0040LCMCLLAC\u0040\u003F\u0024AAb\u003F\u0024AAI\u003F\u0024AAs\u003F\u0024AAU\u003F\u0024AAs\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAT\u003F\u0024AAa\u003F\u0024AAg\u003F\u0024AAA\u003F\u0024AAd\u003F\u0024AAm\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AA\u003F\u0024AA\u0040, &num1, (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
    return num1 != 0U;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool IsUserCollectionsAdmin()
  {
    uint num1 = 1;
    int num2 = (int) \u003CModule\u003E.FConfigCacheIni\u002EGetBool(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CO\u0040GNOMGEAA\u0040\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAt\u003F\u0024AAB\u003F\u0024AAr\u003F\u0024AAo\u003F\u0024AAw\u003F\u0024AAs\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAS\u003F\u0024AAe\u003F\u0024AAc\u003F\u0024AAu\u003F\u0024AAr\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAy\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1DA\u0040GCFDMHPE\u0040\u003F\u0024AAb\u003F\u0024AAI\u003F\u0024AAs\u003F\u0024AAU\u003F\u0024AAs\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAC\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAc\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AAs\u003F\u0024AAA\u003F\u0024AAd\u003F\u0024AAm\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AA\u003F\u0024AA\u0040, &num1, (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
    return num1 != 0U;
  }

  public unsafe uint ContainsCookedPackageInSet(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* Packages)
  {
    int num = 0;
    if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(Packages))
    {
      do
      {
        UPackage* upackagePtr = (UPackage*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(Packages, num);
        if ((IntPtr) upackagePtr == IntPtr.Zero || (*(int*) ((IntPtr) upackagePtr + 280L) & 8) == 0)
          ++num;
        else
          goto label_3;
      }
      while (num < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(Packages));
      goto label_4;
label_3:
      return 1;
    }
label_4:
    return 0;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool FullyLoadPackage(string PackageName)
  {
    int num;
    if (this.IsAssetValidForLoading(PackageName))
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, PackageName);
      UPackage* upackagePtr;
      // ISSUE: fault handler
      try
      {
        upackagePtr = \u003CModule\u003E.FindObject\u003Cclass\u0020UPackage\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      if ((IntPtr) upackagePtr != IntPtr.Zero)
      {
        \u003CModule\u003E.UPackage\u002EFullyLoad(upackagePtr);
      }
      else
      {
        FFilename ffilename;
        FFilename* ffilenamePtr = &ffilename;
        FString fstring3;
        FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, PackageName);
        // ISSUE: fault handler
        try
        {
          upackagePtr = \u003CModule\u003E.PackageTools\u002ELoadPackage(\u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, fstring4));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      }
      if ((IntPtr) upackagePtr != IntPtr.Zero && \u003CModule\u003E.UPackage\u002EIsFullyLoaded(upackagePtr) != 0U)
      {
        num = 1;
        goto label_13;
      }
    }
    num = 0;
label_13:
    return num != 0;
  }

  public virtual Color GetAssetVisualBorderColorForObjectTypeName(string InObjectTypeName)
  {
    Color color = new Color();
    return this.ClassNameToBorderColorMap.TryGetValue(InObjectTypeName, out color) ? color : Colors.Black;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public static bool IsWarning(string IsThisAWarning) => IsThisAWarning.StartsWith(MContentBrowserControl.WarningPrefix);

  public virtual unsafe List<string> GenerateCustomLabelsForAsset(AssetItem InAssetItem)
  {
    List<string> stringList = new List<string>();
    if (InAssetItem.LoadedStatus != null)
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, InAssetItem.AssetType);
      UClass* objectClassUclass;
      // ISSUE: fault handler
      try
      {
        objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      if ((IntPtr) objectClassUclass != IntPtr.Zero)
      {
        FString fstring3;
        FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, InAssetItem.FullyQualifiedPath);
        UObject* uobjectPtr1;
        // ISSUE: fault handler
        try
        {
          uobjectPtr1 = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
        if ((IntPtr) uobjectPtr1 != IntPtr.Zero)
        {
          TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
          // ISSUE: fault handler
          try
          {
            FThumbnailRenderingInfo* renderingInfo = \u003CModule\u003E.UThumbnailManager\u002EGetRenderingInfo(\u003CModule\u003E.UUnrealEdEngine\u002EGetThumbnailManager(\u003CModule\u003E.GUnrealEd), uobjectPtr1);
            if ((IntPtr) renderingInfo != IntPtr.Zero)
            {
              ulong num = (ulong) *(long*) ((IntPtr) renderingInfo + 64L);
              if (num != 0UL)
              {
                UThumbnailLabelRenderer* uthumbnailLabelRendererPtr1 = (UThumbnailLabelRenderer*) num;
                UThumbnailLabelRenderer.ThumbnailOptions thumbnailOptions;
                \u003CModule\u003E.UThumbnailLabelRenderer\u002EThumbnailOptions\u002E\u007Bctor\u007D(&thumbnailOptions);
                UThumbnailLabelRenderer* uthumbnailLabelRendererPtr2 = uthumbnailLabelRendererPtr1;
                UObject* uobjectPtr2 = uobjectPtr1;
                ref UThumbnailLabelRenderer.ThumbnailOptions local1 = ref thumbnailOptions;
                ref TArray\u003CFString\u002CFDefaultAllocator\u003E local2 = ref fdefaultAllocator;
                // ISSUE: cast to a function pointer type
                // ISSUE: function pointer call
                __calli((__FnPtr<void (IntPtr, UObject*, UThumbnailLabelRenderer.ThumbnailOptions*, TArray\u003CFString\u002CFDefaultAllocator\u003E*)>) *(long*) (*(long*) uthumbnailLabelRendererPtr1 + 616L))((TArray\u003CFString\u002CFDefaultAllocator\u003E*) uthumbnailLabelRendererPtr2, (UThumbnailLabelRenderer.ThumbnailOptions*) uobjectPtr2, (UObject*) ref local1, (IntPtr) ref local2);
              }
            }
            int num1 = 1;
            if (1 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator))
            {
              do
              {
                FString* fstringPtr = \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num1);
                string str = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
                if (str.Length > 0 && (stringList.Count < 4 || str.StartsWith(MContentBrowserControl.WarningPrefix)))
                  stringList.Add(str);
                ++num1;
              }
              while (num1 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator));
            }
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
          }
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
          if (stringList.Count == 0)
          {
            UObject* uobjectPtr2 = uobjectPtr1;
            FString fstring5;
            ref FString local = ref fstring5;
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            long num = (long) __calli((__FnPtr<FString* (IntPtr, FString*)>) *(long*) (*(long*) uobjectPtr1 + 432L))((FString*) uobjectPtr2, (IntPtr) ref local);
            string str;
            // ISSUE: fault handler
            try
            {
              str = new string(\u003CModule\u003E.FString\u002E\u002A((FString*) num), 0, \u003CModule\u003E.FString\u002ELen((FString*) num));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
            if (str.Length > 0)
              stringList.Add(str);
          }
        }
      }
    }
    if (stringList.Count < 4)
    {
      do
      {
        stringList.Add("");
      }
      while (stringList.Count < 4);
    }
    int num2 = 0;
    int index = 0;
    if (0 < stringList.Count)
    {
      do
      {
        string str1 = stringList[index];
        if (str1.StartsWith(MContentBrowserControl.WarningPrefix))
        {
          string str2 = str1.Substring(MContentBrowserControl.WarningPrefix.Length);
          stringList[index] = str2;
          if (num2 == 0)
            stringList.Add(str2);
          else
            stringList[4] = (num2 + 1).ToString() + " WARNINGS!";
          ++num2;
        }
        ++index;
      }
      while (index < stringList.Count);
    }
    if (stringList.Count == 4)
      stringList.Add("");
    return stringList;
  }

  public virtual unsafe List<string> GenerateCustomDataColumnsForAsset(AssetItem InAssetItem)
  {
    List<string> stringList = new List<string>();
    if (InAssetItem.LoadedStatus != null)
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, InAssetItem.AssetType);
      UClass* objectClassUclass;
      // ISSUE: fault handler
      try
      {
        objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      if ((IntPtr) objectClassUclass != IntPtr.Zero)
      {
        FString fstring3;
        FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, InAssetItem.FullyQualifiedPath);
        UObject* uobjectPtr1;
        // ISSUE: fault handler
        try
        {
          uobjectPtr1 = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
        if ((IntPtr) uobjectPtr1 != IntPtr.Zero)
        {
          int num1 = 0;
          do
          {
            UObject* uobjectPtr2 = uobjectPtr1;
            FString fstring5;
            ref FString local = ref fstring5;
            int num2 = num1;
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            long num3 = (long) __calli((__FnPtr<FString* (IntPtr, FString*, int)>) *(long*) (*(long*) uobjectPtr1 + 440L))((int) uobjectPtr2, (FString*) ref local, (IntPtr) num2);
            string str;
            // ISSUE: fault handler
            try
            {
              str = new string(\u003CModule\u003E.FString\u002E\u002A((FString*) num3), 0, \u003CModule\u003E.FString\u002ELen((FString*) num3));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
            if (num1 > stringList.Count)
            {
              do
              {
                stringList.Add("");
              }
              while (num1 > stringList.Count);
            }
            stringList.Add(str);
            ++num1;
          }
          while (num1 < 10);
        }
      }
    }
    if (stringList.Count < 10)
    {
      do
      {
        stringList.Add("");
      }
      while (stringList.Count < 10);
    }
    return stringList;
  }

  public virtual unsafe DateTime GenerateDateAddedForAsset(AssetItem InAssetItem)
  {
    List<string> stringList = (List<string>) null;
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    // ISSUE: cast to a reference type
    // ISSUE: variable of a reference type
    byte* local1 = (byte*) InAssetItem.FullName;
    if (local1 != null)
      local1 = (long) (uint) RuntimeHelpers.OffsetToStringData + local1;
    // ISSUE: explicit reference operation
    fixed (byte* numPtr = &^local1)
    {
      FName fname;
      \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (char*) numPtr, (EFindName) 1, 1U);
      FName InAssetFullNameFName = fname;
      ref List<string> local2 = ref stringList;
      \u003CModule\u003E.FGameAssetDatabase\u002EQueryTagsForAsset(database0PeaV1Ea, InAssetFullNameFName, (ETagQueryOptions.Type) 1, out local2);
      List<string>.Enumerator enumerator = stringList.GetEnumerator();
      if (enumerator.MoveNext())
      {
        string current;
        do
        {
          current = enumerator.Current;
          if (\u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagType(current) == ESystemTagType.DateAdded)
            goto label_5;
        }
        while (enumerator.MoveNext());
        goto label_6;
label_5:
        return new DateTime((long) Convert.ToUInt64(\u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagValue(current)));
      }
label_6:
      return DateTime.Today;
    }
  }

  public virtual unsafe int CalculateMemoryUsageForAsset(AssetItem InAssetItem)
  {
    int num = -1;
    if (InAssetItem.LoadedStatus != null)
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, InAssetItem.AssetType);
      UClass* objectClassUclass;
      // ISSUE: fault handler
      try
      {
        objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      if ((IntPtr) objectClassUclass != IntPtr.Zero)
      {
        FString fstring3;
        FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, InAssetItem.FullyQualifiedPath);
        UObject* uobjectPtr1;
        // ISSUE: fault handler
        try
        {
          uobjectPtr1 = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
        if ((IntPtr) uobjectPtr1 != IntPtr.Zero)
        {
          UObject* uobjectPtr2 = uobjectPtr1;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          num = __calli((__FnPtr<int (IntPtr)>) *(long*) (*(long*) uobjectPtr2 + 496L))((IntPtr) uobjectPtr2);
        }
      }
    }
    return num;
  }

  public unsafe UPackage* PackageToUPackage(ObjectContainerNode Pkg)
  {
    UPackage* upackagePtr = (UPackage*) 0L;
    if (Pkg != null)
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Pkg.ObjectPathName);
      // ISSUE: fault handler
      try
      {
        upackagePtr = \u003CModule\u003E.FindObject\u003Cclass\u0020UPackage\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    }
    return upackagePtr;
  }

  public unsafe ObjectContainerNode UPackageToPackage(UPackage* Pkg)
  {
    ObjectContainerNode objectContainerNode = (ObjectContainerNode) null;
    if ((IntPtr) Pkg != IntPtr.Zero && this.ContentBrowserCtrl != null)
    {
      FString fstring;
      FString* pathName = \u003CModule\u003E.UObject\u002EGetPathName((UObject*) Pkg, &fstring, (UObject*) 0L);
      string str;
      // ISSUE: fault handler
      try
      {
        str = new string(\u003CModule\u003E.FString\u002E\u002A(pathName), 0, \u003CModule\u003E.FString\u002ELen(pathName));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      objectContainerNode = this.ContentBrowserCtrl.MySources.FindPackage(str);
    }
    return objectContainerNode;
  }

  public unsafe void GeneratePackageList(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InObjects,
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* out_Packages)
  {
    \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(out_Packages, 0);
    int num = 0;
    if (0 >= \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InObjects))
      return;
    do
    {
      UPackage* upackagePtr = \u003CModule\u003E.Cast\u003Cclass\u0020UPackage\u003E(\u003CModule\u003E.UObject\u002EGetOuter((UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InObjects, num)));
      if ((IntPtr) upackagePtr != IntPtr.Zero)
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(out_Packages, &upackagePtr);
      ++num;
    }
    while (num < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InObjects));
  }

  public virtual unsafe void UpdatePackagesTree([MarshalAs(UnmanagedType.U1)] bool IsUsingFlatView)
  {
    if (!this.ContentBrowserCtrl.bIsLoaded)
    {
      this.bPackageListUpdateRequested = true;
      this.bPackageFilterUpdateRequested = true;
    }
    else
    {
      SourcesPanelModel mySources = this.ContentBrowserCtrl.MySources;
      FString fstring1;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, \u003CModule\u003E.appBaseDir());
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FPackageFileCache\u002ENormalizePathSeparators(&fstring1);
        mySources.SetRootDirectoryPath(new string(\u003CModule\u003E.FString\u002E\u002A(&fstring1), 0, \u003CModule\u003E.FString\u002ELen(&fstring1)));
        FPackageFileCache* gpackageFileCache = \u003CModule\u003E.GPackageFileCache;
        TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator1;
        ref TArray\u003CFString\u002CFDefaultAllocator\u003E local = ref fdefaultAllocator1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        long num1 = (long) __calli((__FnPtr<TArray\u003CFString\u002CFDefaultAllocator\u003E* (IntPtr, TArray\u003CFString\u002CFDefaultAllocator\u003E*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 40L))((TArray\u003CFString\u002CFDefaultAllocator\u003E*) gpackageFileCache, (IntPtr) ref local);
        TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) num1);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
        }
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
          Dictionary<string, ObjectContainerNode> dictionary1 = new Dictionary<string, ObjectContainerNode>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
          int num2 = 0;
          if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator2))
          {
            do
            {
              FString fstring2;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator2, num2)));
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.FPackageFileCache\u002ENormalizePathSeparators(&fstring2);
                if (\u003CModule\u003E.PackageTools\u002EIsPackagePathExternal(&fstring2) == 0U)
                  goto label_11;
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
              goto label_14;
label_11:
              // ISSUE: fault handler
              try
              {
                string str = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
                Package package = mySources.AddPackage(str, IsUsingFlatView);
                dictionary1.Add(package.Name, (ObjectContainerNode) package);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
label_14:
              ++num2;
            }
            while (num2 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator2));
          }
          TSet\u003CUPackage\u0020const\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020const\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator1;
          \u003CModule\u003E.TSet\u003CUPackage\u0020const\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020const\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator1);
          // ISSUE: fault handler
          try
          {
            TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator3;
            \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator3);
            // ISSUE: fault handler
            try
            {
              TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator2;
              \u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator2);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.PackageTools\u002EGetFilteredPackageList((TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E*) 0L, &fdefaultSetAllocator1, &fdefaultSetAllocator2, &fdefaultAllocator3);
                Dictionary<IntPtr, ObjectContainerNode> dictionary2 = new Dictionary<IntPtr, ObjectContainerNode>();
                FString fstring2;
                \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CG\u0040DCPDBNEJ\u0040\u003F\u0024AA\u003F4\u003F\u0024AA\u003F4\u003F\u0024AA\u003F2\u003F\u0024AA\u003F4\u003F\u0024AA\u003F4\u003F\u0024AA\u003F2\u003F\u0024AAN\u003F\u0024AAe\u003F\u0024AAw\u003F\u0024AAP\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAk\u003F\u0024AAa\u003F\u0024AAg\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AA\u003F\u0024AA\u0040);
                // ISSUE: fault handler
                try
                {
                  FString fstring3;
                  \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CA\u0040ICKGFOFN\u0040\u003F\u0024AA\u003F4\u003F\u0024AA\u003F4\u003F\u0024AA\u003F2\u003F\u0024AA\u003F4\u003F\u0024AA\u003F4\u003F\u0024AA\u003F2\u003F\u0024AAE\u003F\u0024AAx\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAn\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AA\u003F2\u003F\u0024AA\u003F\u0024AA\u0040);
                  // ISSUE: fault handler
                  try
                  {
                    int num3 = 0;
                    if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator3))
                    {
                      do
                      {
                        FString fstring4;
                        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring4);
                        UPackage* UnrealPackage;
                        FString fstring5;
                        Package package;
                        // ISSUE: fault handler
                        try
                        {
                          UnrealPackage = (UPackage*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator3, num3);
                          \u003CModule\u003E.UObject\u002EGetName((UObject*) UnrealPackage, &fstring5);
                          // ISSUE: fault handler
                          try
                          {
                            FGuid fguid;
                            \u003CModule\u003E.UPackage\u002EGetGuid(UnrealPackage, &fguid);
                            // ISSUE: cast to a function pointer type
                            // ISSUE: function pointer call
                            int num4 = (int) __calli((__FnPtr<uint (IntPtr, char*, FGuid*, FString*, char*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 16L))((char*) \u003CModule\u003E.GPackageFileCache, (FString*) \u003CModule\u003E.FString\u002E\u002A(&fstring5), &fguid, (char*) &fstring4, IntPtr.Zero);
                            if (\u003CModule\u003E.FString\u002ELen(&fstring4) == 0)
                            {
                              FString fstring6;
                              FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) UnrealPackage, &fstring6);
                              // ISSUE: fault handler
                              try
                              {
                                FString fstring7;
                                FString* fstringPtr = \u003CModule\u003E.FString\u002E\u002B(&fstring2, &fstring7, name);
                                // ISSUE: fault handler
                                try
                                {
                                  \u003CModule\u003E.FString\u002E\u003D(&fstring4, fstringPtr);
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
                            else if (\u003CModule\u003E.PackageTools\u002EIsPackageExternal(UnrealPackage) != 0U)
                            {
                              FString fstring6;
                              FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) UnrealPackage, &fstring6);
                              // ISSUE: fault handler
                              try
                              {
                                FString fstring7;
                                FString* fstringPtr = \u003CModule\u003E.FString\u002E\u002B(&fstring3, &fstring7, name);
                                // ISSUE: fault handler
                                try
                                {
                                  \u003CModule\u003E.FString\u002E\u003D(&fstring4, fstringPtr);
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
                            if (\u003CModule\u003E.FString\u002ELen(&fstring4) != 0)
                            {
                              string str = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring4), 0, \u003CModule\u003E.FString\u002ELen(&fstring4));
                              package = mySources.AddPackage(str, IsUsingFlatView);
                              if (package != null)
                                goto label_45;
                            }
                            else
                              goto label_49;
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
                        goto label_53;
label_45:
                        // ISSUE: fault handler
                        try
                        {
                          // ISSUE: fault handler
                          try
                          {
                            IntPtr key = (IntPtr) (void*) UnrealPackage;
                            dictionary2.Add(key, (ObjectContainerNode) package);
                            if (!this.bPackageListUpdateUIRequested)
                              this.UpdatePackagesTreeUI((ObjectContainerNode) package, UnrealPackage);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
                          }
                        }
                        __fault
                        {
                          // ISSUE: method pointer
                          // ISSUE: cast to a function pointer type
                          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                        }
label_49:
                        // ISSUE: fault handler
                        try
                        {
                          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
                        }
                        __fault
                        {
                          // ISSUE: method pointer
                          // ISSUE: cast to a function pointer type
                          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                        }
                        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
label_53:
                        ++num3;
                      }
                      while (num3 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator3));
                    }
                    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator4;
                    \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator4);
                    // ISSUE: fault handler
                    try
                    {
                      TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TIterator titerator;
                      \u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bctor\u007D(&titerator, &fdefaultSetAllocator2, 0);
                      if (\u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002E_N((TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator))
                      {
                        do
                        {
                          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator4, \u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002A((TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator));
                          \u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002B\u002B((TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator);
                        }
                        while (\u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002E_N((TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator));
                      }
                      if (\u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator4) != 0)
                      {
                        do
                        {
                          int num4 = 0;
                          if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator4))
                          {
                            do
                            {
                              UPackage* upackagePtr = (UPackage*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator4, num4);
                              IntPtr key1 = (IntPtr) (void*) upackagePtr;
                              if (dictionary2.ContainsKey(key1))
                              {
                                \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ERemove(&fdefaultAllocator4, num4, 1);
                                num4 += -1;
                              }
                              else
                              {
                                IntPtr outer1 = (IntPtr) (void*) \u003CModule\u003E.UObject\u002EGetOuter((UObject*) upackagePtr);
                                if (dictionary2.ContainsKey(outer1))
                                {
                                  IntPtr outer2 = (IntPtr) (void*) \u003CModule\u003E.UObject\u002EGetOuter((UObject*) upackagePtr);
                                  ObjectContainerNode objectContainerNode = dictionary2[outer2];
                                  FString fstring4;
                                  FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) upackagePtr, &fstring4);
                                  GroupPackage groupPackage;
                                  // ISSUE: fault handler
                                  try
                                  {
                                    string str = new string(\u003CModule\u003E.FString\u002E\u002A(name), 0, \u003CModule\u003E.FString\u002ELen(name));
                                    groupPackage = new GroupPackage((SourceTreeNode) objectContainerNode, str);
                                  }
                                  __fault
                                  {
                                    // ISSUE: method pointer
                                    // ISSUE: cast to a function pointer type
                                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                                  }
                                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
                                  groupPackage = (GroupPackage) ((SourceTreeNode) objectContainerNode).AddChildNode<GroupPackage>((M0) groupPackage);
                                  IntPtr key2 = (IntPtr) (void*) upackagePtr;
                                  dictionary2.Add(key2, (ObjectContainerNode) groupPackage);
                                  \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ERemove(&fdefaultAllocator4, num4, 1);
                                  num4 += -1;
                                }
                              }
                              ++num4;
                            }
                            while (num4 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator4));
                          }
                        }
                        while (\u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator4) != 0);
                      }
                      Dictionary<string, int>.KeyCollection.Enumerator enumerator = \u003CModule\u003E.gcroot\u003CSystem\u003A\u003ACollections\u003A\u003AGeneric\u003A\u003ADictionary\u003CSystem\u003A\u003AString\u0020\u005E\u002Cint\u003E\u0020\u005E\u003E\u002E\u002EPE\u0024AAV\u003F\u0024Dictionary\u0040PE\u0024AAVString\u0040System\u0040\u0040H\u0040Generic\u0040Collections\u0040System\u0040\u0040((gcroot\u003CSystem\u003A\u003ACollections\u003A\u003AGeneric\u003A\u003ADictionary\u003CSystem\u003A\u003AString\u0020\u005E\u002Cint\u003E\u0020\u005E\u003E*) ((IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA + 240L)).Keys.GetEnumerator();
                      if (enumerator.MoveNext())
                      {
                        do
                        {
                          string[] strArray = enumerator.Current.Split('.');
                          string key = strArray[0];
                          int index = 1;
                          ObjectContainerNode objectContainerNode1 = (ObjectContainerNode) null;
                          if (dictionary1.TryGetValue(key, out objectContainerNode1) && 1 < strArray.Length)
                          {
                            do
                            {
                              string str = strArray[index];
                              ObjectContainerNode objectContainerNode2 = (ObjectContainerNode) ((SourceTreeNode) objectContainerNode1).FindChildNode<ObjectContainerNode>(str, false);
                              if (objectContainerNode2 == null)
                              {
                                GroupPackage groupPackage = new GroupPackage((SourceTreeNode) objectContainerNode1, str);
                                objectContainerNode2 = (ObjectContainerNode) ((SourceTreeNode) objectContainerNode1).AddChildNode<GroupPackage>((M0) groupPackage);
                              }
                              objectContainerNode1 = objectContainerNode2;
                              ++index;
                            }
                            while (index < strArray.Length);
                          }
                        }
                        while (enumerator.MoveNext());
                      }
                      this.PurgeInvalidNodesFromTree(&fdefaultAllocator2, &fdefaultAllocator3, &fdefaultSetAllocator2);
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator4);
                    }
                    \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator4);
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
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator2);
              }
              \u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator2);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
            }
            \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TSet\u003CUPackage\u0020const\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020const\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator1);
          }
          \u003CModule\u003E.TSet\u003CUPackage\u0020const\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020const\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator1);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
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

  public unsafe uint AllowPackageSave(UPackage* PackageToSave) => 1;

  public virtual unsafe uint SavePackages(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* PackagesToSave,
    uint bUnloadPackagesAfterSave)
  {
    if (\u003CModule\u003E.\u003FA0x3a4a4fc4\u002ECloseFaceFX() == 0U)
      return 0;
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
    \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
    FString fstring1;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
      // ISSUE: fault handler
      try
      {
        if (\u003CModule\u003E.PackageTools\u002ECheckForReferencesToExternalPackages(PackagesToSave, &fdefaultAllocator1, (ULevel*) 0L, (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L) != 0U)
        {
          int num1 = 0;
          if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1))
          {
            do
            {
              FString fstring2;
              FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, num1), &fstring2);
              // ISSUE: fault handler
              try
              {
                FString fstring3;
                FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D66, \u003CModule\u003E.FString\u002E\u002A(name));
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring1, fstringPtr);
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
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
              ++num1;
            }
            while (num1 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1));
          }
          FString fstring4;
          FString* fstringPtr1 = \u003CModule\u003E.LocalizeUnrealEd(&fstring4, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D68, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D67, (char*) 0L);
          uint num2;
          // ISSUE: fault handler
          try
          {
            num2 = \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 1, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr1)), \u003CModule\u003E.FString\u002E\u002A(&fstring1)), \u003CModule\u003E.FString\u002E\u002A(&fstring1));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
          if (num2 != 0U)
            goto label_21;
        }
        else
          goto label_21;
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    return 0;
label_21:
    uint num;
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, this.LastSavePath);
        // ISSUE: fault handler
        try
        {
          TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator2;
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
          // ISSUE: fault handler
          try
          {
            num = \u003CModule\u003E.FEditorFileUtils\u002EPromptToCheckoutPackages(0U, PackagesToSave, &fdefaultAllocator2, 0U, 0U);
            TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr;
            if (num == 0U)
            {
              if (\u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator2) > 0)
                fdefaultAllocatorPtr = &fdefaultAllocator2;
              else
                goto label_31;
            }
            else
              fdefaultAllocatorPtr = PackagesToSave;
            num = \u003CModule\u003E.PackageTools\u002ESavePackages(fdefaultAllocatorPtr, bUnloadPackagesAfterSave, &fstring2, this.BrowsableObjectTypeList.Get());
            if (num != 0U)
              this.LastSavePath = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
          }
label_31:
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
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
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    return num;
  }

  public unsafe void GetPackagesForSelectedAssetItems(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* out_Packages,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* out_PackageNames)
  {
    foreach (AssetItem selectedItem in (IEnumerable) ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems)
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, selectedItem.PackageName);
      FString fstring3;
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3, \u003CModule\u003E.FString\u002E\u002A(fstring2));
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
        FString fstring4;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring4, \u003CModule\u003E.FString\u002E\u002A(&fstring3));
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(out_PackageNames, &fstring4);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
        UPackage* objectClassUpackage = \u003CModule\u003E.FindObject\u003Cclass\u0020UPackage\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(&fstring3), 0U);
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(out_Packages, &objectClassUpackage);
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

  public unsafe void GetSelectedRootPackages(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* OutPackageList,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* pOutPackageNames,
    uint bCullNullPackages)
  {
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      TArray\u003CFString\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = (IntPtr) pOutPackageNames != 0L ? pOutPackageNames : &fdefaultAllocator;
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(OutPackageList, 0);
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EEmpty(fdefaultAllocatorPtr, 0);
      ReadOnlyCollection<Package> readOnlyCollection = this.ContentBrowserCtrl.MySourcesPanel.MakeSelectedTopLevelPackageList();
      int index = 0;
      if (0 < readOnlyCollection.Count)
      {
        do
        {
          Package package = readOnlyCollection[index];
          UPackage* upackagePtr1 = (UPackage*) 0L;
          if (package != null)
          {
            FString fstring1;
            FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, ((ObjectContainerNode) package).ObjectPathName);
            // ISSUE: fault handler
            try
            {
              upackagePtr1 = \u003CModule\u003E.FindObject\u003Cclass\u0020UPackage\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          }
          UPackage* upackagePtr2 = upackagePtr1;
          if ((IntPtr) upackagePtr1 != IntPtr.Zero || bCullNullPackages == 0U)
            \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(OutPackageList, &upackagePtr2);
          FString fstring3;
          FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, package.Name);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(fdefaultAllocatorPtr, fstring4);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          ++index;
        }
        while (index < readOnlyCollection.Count);
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

  public unsafe void GetSelectedRootPackages(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* OutPackageList)
  {
    this.GetSelectedRootPackages(OutPackageList, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) 0L, 1U);
  }

  public unsafe void GetSelectedPackages(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* OutPackageList,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* pOutPackageNames,
    uint bCullNullPackages)
  {
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      TArray\u003CFString\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = (IntPtr) pOutPackageNames != 0L ? pOutPackageNames : &fdefaultAllocator;
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(OutPackageList, 0);
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EEmpty(fdefaultAllocatorPtr, 0);
      ReadOnlyCollection<ObjectContainerNode> readOnlyCollection = this.ContentBrowserCtrl.MySourcesPanel.MakeSelectedPackageAndGroupList();
      int index = 0;
      if (0 < readOnlyCollection.Count)
      {
        do
        {
          ObjectContainerNode objectContainerNode = readOnlyCollection[index];
          UPackage* upackagePtr1 = (UPackage*) 0L;
          if (objectContainerNode != null)
          {
            FString fstring1;
            FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, objectContainerNode.ObjectPathName);
            // ISSUE: fault handler
            try
            {
              upackagePtr1 = \u003CModule\u003E.FindObject\u003Cclass\u0020UPackage\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          }
          UPackage* upackagePtr2 = upackagePtr1;
          if ((IntPtr) upackagePtr1 != IntPtr.Zero || bCullNullPackages == 0U)
            \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(OutPackageList, &upackagePtr2);
          FString fstring3;
          FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, ((SourceTreeNode) objectContainerNode).Name);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(fdefaultAllocatorPtr, fstring4);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          ++index;
        }
        while (index < readOnlyCollection.Count);
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

  public unsafe void GetSelectedPackages(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* OutPackageList)
  {
    this.GetSelectedPackages(OutPackageList, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) 0L, 1U);
  }

  public unsafe void LoadSelectedPackages(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* Packages,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* PackageNames)
  {
    TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
    \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, PackageNames);
    if (!\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      return;
    do
    {
      UPackage* upackagePtr = \u003CModule\u003E.FindObject\u003Cclass\u0020UPackage\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt)), 0U);
      if ((IntPtr) upackagePtr == IntPtr.Zero)
      {
        FFilename ffilename;
        FFilename* ffilenamePtr = &ffilename;
        upackagePtr = \u003CModule\u003E.PackageTools\u002ELoadPackage(\u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt)));
        if ((IntPtr) upackagePtr == IntPtr.Zero)
          goto label_4;
      }
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(Packages, &upackagePtr);
label_4:
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
    }
    while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
  }

  public unsafe void GetSelectedPackageAndGroupName(
    FString* SelectedPackageName,
    FString* SelectedGroupName)
  {
    if (!this.ContentBrowserCtrl.MySourcesPanel.AnyNodesSelected())
      return;
    ReadOnlyCollection<ObjectContainerNode> readOnlyCollection = this.ContentBrowserCtrl.MySourcesPanel.MakeSelectedPackageAndGroupList();
    if (readOnlyCollection.Count <= 0)
      return;
    int index1 = 0;
    if (0 < readOnlyCollection.Count)
    {
      ObjectContainerNode parent;
      do
      {
        parent = readOnlyCollection[index1];
        if (!((AbstractTreeNode) parent).IsSelected || !(((object) parent).GetType() == typeof (GroupPackage)))
          ++index1;
        else
          goto label_6;
      }
      while (index1 < readOnlyCollection.Count);
      goto label_29;
label_6:
      FString fstring1;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D69);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002E\u003D(SelectedGroupName, &fstring1);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      if (((AbstractTreeNode) parent).Parent != null)
      {
        while (((object) parent).GetType() == typeof (GroupPackage))
        {
          FString fstring2;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, ((SourceTreeNode) parent).Name);
          // ISSUE: fault handler
          try
          {
            if (\u003CModule\u003E.FString\u002ELen(SelectedGroupName) == 0)
            {
              \u003CModule\u003E.FString\u002E\u003D(SelectedGroupName, &fstring2);
            }
            else
            {
              FString fstring3;
              FString* fstringPtr1 = \u003CModule\u003E.FString\u002E\u002B(&fstring2, &fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D70);
              // ISSUE: fault handler
              try
              {
                FString fstring4;
                FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u002B(fstringPtr1, &fstring4, SelectedGroupName);
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.FString\u002E\u003D(SelectedGroupName, fstringPtr2);
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
            parent = (ObjectContainerNode) ((AbstractTreeNode) parent).Parent;
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          if (((AbstractTreeNode) parent).Parent == null)
            break;
        }
      }
      if (parent == null || !(((object) parent).GetType() == typeof (Package)))
        return;
      FString fstring5;
      FString* fstring6 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring5, ((SourceTreeNode) parent).Name);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002E\u003D(SelectedPackageName, fstring6);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
      return;
    }
label_29:
    int index2 = 0;
    if (0 >= readOnlyCollection.Count)
      return;
    ObjectContainerNode objectContainerNode;
    do
    {
      objectContainerNode = readOnlyCollection[index2];
      if (!(((object) objectContainerNode).GetType() == typeof (Package)))
        ++index2;
      else
        goto label_33;
    }
    while (index2 < readOnlyCollection.Count);
    return;
label_33:
    FString fstring7;
    FString* fstring8 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring7, ((SourceTreeNode) objectContainerNode).Name);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u003D(SelectedPackageName, fstring8);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring7);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring7);
  }

  public static unsafe BitmapSource CreateBitmapSourceForThumbnail(
    FObjectThumbnail* InThumbnail)
  {
    return \u003CModule\u003E.ThumbnailToolsCLR\u002ECreateBitmapSourceForThumbnail(InThumbnail);
  }

  protected unsafe void CheckOutRootPackages(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* Packages)
  {
    \u003CModule\u003E.PackageTools\u002ECheckOutRootPackages(Packages);
  }

  protected unsafe void OnCanExecutePackageCommand(
    object Sender,
    CanExecuteRoutedEventArgs EvtArgs,
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* Packages,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* PackageNames)
  {
    EvtArgs.Handled = true;
    bool flag = true;
    if (EvtArgs.Command == PackageCommands.FullyLoadPackage)
    {
      flag = false;
      int num = 0;
      if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(Packages))
      {
        do
        {
          UPackage* upackagePtr = (UPackage*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(Packages, num);
          if ((IntPtr) upackagePtr == IntPtr.Zero)
          {
            FString* fstringPtr = \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(PackageNames, num);
            if (this.IsAssetValidForLoading(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr))))
              goto label_6;
          }
          else if (\u003CModule\u003E.UPackage\u002EIsFullyLoaded(upackagePtr) == 0U)
            goto label_7;
          ++num;
        }
        while (num < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(Packages));
        goto label_13;
label_6:
        flag = true;
        goto label_13;
label_7:
        flag = true;
      }
    }
    else if (EvtArgs.Command == PackageCommands.UnloadPackage || EvtArgs.Command == ApplicationCommands.Save || (EvtArgs.Command == PackageCommands.SaveAsset || EvtArgs.Command == PackageCommands.CheckErrors))
    {
      flag = false;
      int num = 0;
      if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(Packages))
      {
        while (*(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(Packages, num) == 0L)
        {
          ++num;
          if (num >= \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(Packages))
            goto label_13;
        }
        flag = true;
      }
    }
label_13:
    EvtArgs.CanExecute = flag;
  }

  protected unsafe void OnCanExecuteSCCCommand(
    object Sender,
    CanExecuteRoutedEventArgs EvtArgs,
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* Packages,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* PackageNames)
  {
    EvtArgs.Handled = true;
    bool flag = false;
    if (\u003CModule\u003E.FSourceControl\u002EIsEnabled() != 0U)
    {
      if (EvtArgs.Command == SourceControlCommands.CheckInSCC)
      {
        int num = 0;
        if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames))
        {
          do
          {
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            switch (__calli((__FnPtr<int (IntPtr, char*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 32L))((char*) \u003CModule\u003E.GPackageFileCache, (IntPtr) \u003CModule\u003E.FString\u002E\u002A(\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(PackageNames, num))))
            {
              case 1:
              case 4:
                goto label_5;
              default:
                ++num;
                continue;
            }
          }
          while (num < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames));
          goto label_21;
label_5:
          flag = true;
        }
      }
      else if (EvtArgs.Command == SourceControlCommands.CheckOutSCC)
      {
        int num = 0;
        if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames))
        {
          do
          {
            FPackageFileCache* gpackageFileCache = \u003CModule\u003E.GPackageFileCache;
            char* chPtr = \u003CModule\u003E.FString\u002E\u002A(\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(PackageNames, num));
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            if (__calli((__FnPtr<int (IntPtr, char*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 32L))((char*) gpackageFileCache, (IntPtr) chPtr) != 2)
              ++num;
            else
              goto label_10;
          }
          while (num < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames));
          goto label_21;
label_10:
          flag = true;
        }
      }
      else if (EvtArgs.Command == SourceControlCommands.RevertSCC)
      {
        int num = 0;
        if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames))
        {
          do
          {
            FPackageFileCache* gpackageFileCache = \u003CModule\u003E.GPackageFileCache;
            char* chPtr = \u003CModule\u003E.FString\u002E\u002A(\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(PackageNames, num));
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            if (__calli((__FnPtr<int (IntPtr, char*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 32L))((char*) gpackageFileCache, (IntPtr) chPtr) != 1)
              ++num;
            else
              goto label_15;
          }
          while (num < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames));
          goto label_21;
label_15:
          flag = true;
        }
      }
      else if (EvtArgs.Command == SourceControlCommands.RevisionHistorySCC)
      {
        if (\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames) == 1)
        {
          FPackageFileCache* gpackageFileCache = \u003CModule\u003E.GPackageFileCache;
          char* chPtr = \u003CModule\u003E.FString\u002E\u002A(\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(PackageNames, 0));
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          if (__calli((__FnPtr<int (IntPtr, char*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 32L))((char*) gpackageFileCache, (IntPtr) chPtr) != 4)
            flag = true;
        }
      }
      else
        flag = true;
    }
label_21:
    EvtArgs.CanExecute = flag;
  }

  protected unsafe void ExecutePackageCommand(
    object Sender,
    ExecutedRoutedEventArgs EvtArgs,
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* Packages,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* PackageNames)
  {
    EvtArgs.Handled = true;
    RoutedCommand command = (RoutedCommand) EvtArgs.Command;
    if (command != ApplicationCommands.Save && command != PackageCommands.SaveAsset)
    {
      if (command == PackageCommands.FullyLoadPackage)
      {
        EvtArgs.Handled = true;
        uint num1;
        if (\u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(Packages) <= 0 && \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames) <= 0)
        {
          num1 = 0U;
        }
        else
        {
          num1 = 1U;
          FString fstring;
          FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D72, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D71, (char*) 0L);
          // ISSUE: fault handler
          try
          {
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            __calli((__FnPtr<void (IntPtr, char*, uint, uint)>) *(long*) (*(long*) \u003CModule\u003E.GWarn + 40L))((uint) \u003CModule\u003E.GWarn, (uint) \u003CModule\u003E.FString\u002E\u002A(fstringPtr), (char*) 1, IntPtr.Zero);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
        }
        if (\u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(Packages) > 0)
        {
          int num2 = 0;
          if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(Packages))
          {
            do
            {
              UPackage* upackagePtr = (UPackage*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(Packages, num2);
              if ((IntPtr) upackagePtr != IntPtr.Zero)
                \u003CModule\u003E.UPackage\u002EFullyLoad(upackagePtr);
              ++num2;
            }
            while (num2 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(Packages));
          }
        }
        if (\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames) > 0)
        {
          int num2 = 0;
          if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames))
          {
            do
            {
              this.FullyLoadPackage(\u003CModule\u003E.CLRTools\u002EToString(\u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(PackageNames, num2)));
              ++num2;
            }
            while (num2 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNames));
          }
        }
        if (num1 == 0U)
          return;
        FFeedbackContext* gwarn = \u003CModule\u003E.GWarn;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) gwarn + 48L))((IntPtr) gwarn);
        this.SetFocus();
      }
      else if (command == PackageCommands.UnloadPackage)
      {
        EvtArgs.Handled = true;
        int num = (int) \u003CModule\u003E.PackageTools\u002EUnloadPackages(Packages);
      }
      else if (command == PackageCommands.ImportAsset)
      {
        EvtArgs.Handled = true;
        FString fstring1;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
        // ISSUE: fault handler
        try
        {
          FString fstring2;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2);
          // ISSUE: fault handler
          try
          {
            TArray\u003CUFactory\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
            \u003CModule\u003E.TArray\u003CUFactory\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
            // ISSUE: fault handler
            try
            {
              TMultiMap\u003Cint\u002CUFactory\u0020\u002A\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
              \u003CModule\u003E.TMultiMap\u003Cint\u002CUFactory\u0020\u002A\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.ObjectTools\u002EAssembleListOfImportFactories(&fdefaultAllocator, &fstring1, &fstring2, &fdefaultSetAllocator);
                FString fstring3;
                FString* fstringPtr1 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E(&fstring3, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D73, \u003CModule\u003E.FString\u002E\u002A(&fstring2), \u003CModule\u003E.FString\u002E\u002A(&fstring2), \u003CModule\u003E.FString\u002E\u002A(&fstring1));
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.FString\u002E\u003D(&fstring1, fstringPtr1);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
                wxString wxString1;
                \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, \u003CModule\u003E.FString\u002E\u002A(&fstring1));
                WxFileDialog wxFileDialog;
                // ISSUE: fault handler
                try
                {
                  wxString wxString2;
                  \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D74);
                  // ISSUE: fault handler
                  try
                  {
                    FString fstring4;
                    FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, this.LastImportPath);
                    // ISSUE: fault handler
                    try
                    {
                      wxString wxString3;
                      \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString3, \u003CModule\u003E.FString\u002E\u002A(fstring5));
                      // ISSUE: fault handler
                      try
                      {
                        FString fstring6;
                        FString* fstringPtr2 = \u003CModule\u003E.LocalizeUnrealEd(&fstring6, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D76, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D75, (char*) 0L);
                        // ISSUE: fault handler
                        try
                        {
                          wxString wxString4;
                          \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString4, \u003CModule\u003E.FString\u002E\u002A(fstringPtr2));
                          // ISSUE: fault handler
                          try
                          {
                            // ISSUE: cast to a reference type
                            // ISSUE: explicit reference operation
                            \u003CModule\u003E.WxFileDialog\u002E\u007Bctor\u007D(&wxFileDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString4, &wxString3, &wxString2, &wxString1, 49, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString4);
                          }
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString4);
                          }
                          __fault
                          {
                            // ISSUE: method pointer
                            // ISSUE: cast to a function pointer type
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
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
                          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
                        }
                      }
                      __fault
                      {
                        // ISSUE: method pointer
                        // ISSUE: cast to a function pointer type
                        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString3);
                      }
                      // ISSUE: fault handler
                      try
                      {
                        \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString3);
                      }
                      __fault
                      {
                        // ISSUE: method pointer
                        // ISSUE: cast to a function pointer type
                        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
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
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
                    }
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString2);
                  }
                  // ISSUE: fault handler
                  try
                  {
                    \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString2);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
                  }
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString1);
                }
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString1);
                  ref WxFileDialog local1 = ref wxFileDialog;
                  int lastImportFilter = this.LastImportFilter;
                  // ISSUE: cast to a reference type
                  // ISSUE: explicit reference operation
                  // ISSUE: cast to a function pointer type
                  // ISSUE: function pointer call
                  __calli((__FnPtr<void (IntPtr, int)>) *(long*) (^(long&) ref wxFileDialog + 1616L))((int) ref local1, (IntPtr) lastImportFilter);
                  ref WxFileDialog local2 = ref wxFileDialog;
                  // ISSUE: cast to a reference type
                  // ISSUE: explicit reference operation
                  // ISSUE: cast to a function pointer type
                  // ISSUE: function pointer call
                  if (__calli((__FnPtr<int (IntPtr)>) *(long*) (^(long&) ref wxFileDialog + 1528L))((IntPtr) ref local2) == 5100)
                  {
                    FString fstring4;
                    FString* fstringPtr2 = \u003CModule\u003E.LocalizeUnrealEd(&fstring4, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D78, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D77, (char*) 0L);
                    // ISSUE: fault handler
                    try
                    {
                      // ISSUE: cast to a function pointer type
                      // ISSUE: function pointer call
                      __calli((__FnPtr<void (IntPtr, char*, uint, uint)>) *(long*) (*(long*) \u003CModule\u003E.GWarn + 40L))((uint) \u003CModule\u003E.GWarn, (uint) \u003CModule\u003E.FString\u002E\u002A(fstringPtr2), (char*) 1, IntPtr.Zero);
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                    }
                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
                    ref WxFileDialog local3 = ref wxFileDialog;
                    // ISSUE: cast to a reference type
                    // ISSUE: explicit reference operation
                    // ISSUE: cast to a function pointer type
                    // ISSUE: function pointer call
                    int num = __calli((__FnPtr<int (IntPtr)>) *(long*) (^(long&) ref wxFileDialog + 1680L))((IntPtr) ref local3);
                    this.LastImportFilter = num;
                    if (num != 0)
                    {
                      UFactory** ufactoryPtr = \u003CModule\u003E.TMapBase\u003Cint\u002CUFactory\u0020\u002A\u002C1\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003Cint\u002CUFactory\u0020\u002A\u002C1\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, num);
                      if ((IntPtr) ufactoryPtr != IntPtr.Zero)
                      {
                        \u003CModule\u003E.TArray\u003CUFactory\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(&fdefaultAllocator, 0);
                        \u003CModule\u003E.TArray\u003CUFactory\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, ufactoryPtr);
                      }
                    }
                    wxArrayString wxArrayString;
                    \u003CModule\u003E.wxArrayString\u002E\u007Bctor\u007D(&wxArrayString);
                    // ISSUE: fault handler
                    try
                    {
                      ref WxFileDialog local4 = ref wxFileDialog;
                      ref wxArrayString local5 = ref wxArrayString;
                      // ISSUE: cast to a reference type
                      // ISSUE: explicit reference operation
                      // ISSUE: cast to a function pointer type
                      // ISSUE: function pointer call
                      __calli((__FnPtr<void (IntPtr, wxArrayString*)>) *(long*) (^(long&) ref wxFileDialog + 1640L))((wxArrayString*) ref local4, (IntPtr) ref local5);
                      FString fstring5;
                      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring5, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D79);
                      // ISSUE: fault handler
                      try
                      {
                        FString fstring6;
                        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring6);
                        // ISSUE: fault handler
                        try
                        {
                          this.GetSelectedPackageAndGroupName(&fstring5, &fstring6);
                          FString fstring7;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring7);
                          // ISSUE: fault handler
                          try
                          {
                            FString fstring8;
                            FString* fstringPtr3 = &fstring8;
                            FString* fstringPtr4 = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring8, &fstring6);
                            FString* fstringPtr5;
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring9;
                              FString* fstringPtr6 = &fstring9;
                              fstringPtr5 = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring9, &fstring5);
                            }
                            __fault
                            {
                              // ISSUE: method pointer
                              // ISSUE: cast to a function pointer type
                              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) fstringPtr3);
                            }
                            if (\u003CModule\u003E.ObjectTools\u002EImportFiles(&wxArrayString, &fdefaultAllocator, &fstring7, fstringPtr5, fstringPtr4) != 0U)
                              this.LastImportPath = \u003CModule\u003E.CLRTools\u002EToString(&fstring7);
                            FFeedbackContext* gwarn = \u003CModule\u003E.GWarn;
                            // ISSUE: cast to a function pointer type
                            // ISSUE: function pointer call
                            __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) gwarn + 48L))((IntPtr) gwarn);
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
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxArrayString\u002E\u007Bdtor\u007D), (void*) &wxArrayString);
                    }
                    \u003CModule\u003E.wxArrayString\u002E\u007Bdtor\u007D(&wxArrayString);
                  }
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
                }
                \u003CModule\u003E.WxFileDialog\u002E\u007Bdtor\u007D(&wxFileDialog);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TMultiMap\u003Cint\u002CUFactory\u0020\u002A\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
              }
              \u003CModule\u003E.TMultiMap\u003Cint\u002CUFactory\u0020\u002A\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUFactory\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
            }
            \u003CModule\u003E.TArray\u003CUFactory\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
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
      else if (command == PackageCommands.OpenPackage)
      {
        wxString wxString1;
        \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D80);
        WxFileDialog wxFileDialog;
        // ISSUE: fault handler
        try
        {
          wxString wxString2;
          \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D81);
          // ISSUE: fault handler
          try
          {
            FString fstring1;
            FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.LastOpenPath);
            // ISSUE: fault handler
            try
            {
              wxString wxString3;
              \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString3, \u003CModule\u003E.FString\u002E\u002A(fstring2));
              // ISSUE: fault handler
              try
              {
                FString fstring3;
                FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D83, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D82, (char*) 0L);
                // ISSUE: fault handler
                try
                {
                  wxString wxString4;
                  \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString4, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
                  // ISSUE: fault handler
                  try
                  {
                    // ISSUE: cast to a reference type
                    // ISSUE: explicit reference operation
                    \u003CModule\u003E.WxFileDialog\u002E\u007Bctor\u007D(&wxFileDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString4, &wxString3, &wxString2, &wxString1, 49, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString4);
                  }
                  // ISSUE: fault handler
                  try
                  {
                    \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString4);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
                  }
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
                }
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
                }
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString3);
              }
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString3);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
              }
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
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
            }
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString2);
          }
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxString\u002E\u007Bdtor\u007D), (void*) &wxString1);
        }
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.wxString\u002E\u007Bdtor\u007D(&wxString1);
          ref WxFileDialog local1 = ref wxFileDialog;
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          if (__calli((__FnPtr<int (IntPtr)>) *(long*) (^(long&) ref wxFileDialog + 1528L))((IntPtr) ref local1) == 5100)
          {
            FScopedBusyCursor fscopedBusyCursor;
            \u003CModule\u003E.FScopedBusyCursor\u002E\u007Bctor\u007D(&fscopedBusyCursor);
            // ISSUE: fault handler
            try
            {
              FString fstring1;
              FString* fstringPtr1 = \u003CModule\u003E.LocalizeUnrealEd(&fstring1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D85, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D84, (char*) 0L);
              // ISSUE: fault handler
              try
              {
                // ISSUE: cast to a function pointer type
                // ISSUE: function pointer call
                __calli((__FnPtr<void (IntPtr, char*, uint, uint)>) *(long*) (*(long*) \u003CModule\u003E.GWarn + 40L))((uint) \u003CModule\u003E.GWarn, (uint) \u003CModule\u003E.FString\u002E\u002A(fstringPtr1), (char*) 1, IntPtr.Zero);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
              wxArrayString wxArrayString;
              \u003CModule\u003E.wxArrayString\u002E\u007Bctor\u007D(&wxArrayString);
              // ISSUE: fault handler
              try
              {
                ref WxFileDialog local2 = ref wxFileDialog;
                ref wxArrayString local3 = ref wxArrayString;
                // ISSUE: cast to a reference type
                // ISSUE: explicit reference operation
                // ISSUE: cast to a function pointer type
                // ISSUE: function pointer call
                __calli((__FnPtr<void (IntPtr, wxArrayString*)>) *(long*) (^(long&) ref wxFileDialog + 1640L))((wxArrayString*) ref local2, (IntPtr) ref local3);
                FPackageFileCache* gpackageFileCache = \u003CModule\u003E.GPackageFileCache;
                TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator1;
                ref TArray\u003CFString\u002CFDefaultAllocator\u003E local4 = ref fdefaultAllocator1;
                // ISSUE: cast to a function pointer type
                // ISSUE: function pointer call
                long num1 = (long) __calli((__FnPtr<TArray\u003CFString\u002CFDefaultAllocator\u003E* (IntPtr, TArray\u003CFString\u002CFDefaultAllocator\u003E*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 40L))((TArray\u003CFString\u002CFDefaultAllocator\u003E*) gpackageFileCache, (IntPtr) ref local4);
                TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) num1);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
                }
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
                  List<ObjectContainerNode> objectContainerNodeList = new List<ObjectContainerNode>();
                  uint num2 = 0;
                  if (0UL < \u003CModule\u003E.wxArrayString\u002EGetCount(&wxArrayString))
                  {
                    ulong num3 = 0;
                    do
                    {
                      FFilename ffilename1;
                      \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename1, \u003CModule\u003E.wxStringBase\u002Ec_str((wxStringBase*) \u003CModule\u003E.wxArrayString\u002E\u005B\u005D(&wxArrayString, num3)));
                      // ISSUE: fault handler
                      try
                      {
                        FString fstring2;
                        \u003CModule\u003E.FFilename\u002EGetBaseFilename(&ffilename1, &fstring2, 1U);
                        // ISSUE: fault handler
                        try
                        {
                          ObjectContainerNode package1 = this.ContentBrowserCtrl.MySources.FindPackage(\u003CModule\u003E.CLRTools\u002EToString(&fstring2));
                          if (package1 != null)
                          {
                            FString fstring3;
                            FString* fstringPtr2 = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D87, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D86, (char*) 0L);
                            // ISSUE: fault handler
                            try
                            {
                              int num4 = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 0, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr2)), \u003CModule\u003E.FString\u002E\u002A(&fstring2)), \u003CModule\u003E.FString\u002E\u002A(&fstring2));
                            }
                            __fault
                            {
                              // ISSUE: method pointer
                              // ISSUE: cast to a function pointer type
                              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
                            }
                            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
                            objectContainerNodeList.Add(package1);
                          }
                          else
                          {
                            FString fstring3;
                            FString* fstringPtr2 = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D89, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D88, (char*) 0L);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring4;
                              FString* fstringPtr3 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring4, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr2)), \u003CModule\u003E.FString\u002E\u002A(&fstring2)), \u003CModule\u003E.FString\u002E\u002A(&fstring2));
                              // ISSUE: fault handler
                              try
                              {
                                int num4 = (int) \u003CModule\u003E.FFeedbackContext\u002EStatusUpdatef(\u003CModule\u003E.GWarn, 0, 0, \u003CModule\u003E.FString\u002E\u002A(fstringPtr3));
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
                            FFilename ffilename2;
                            FFilename* ffilenamePtr = &ffilename2;
                            UPackage* Pkg = \u003CModule\u003E.PackageTools\u002ELoadPackage(\u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename2, &ffilename1));
                            if ((IntPtr) Pkg != IntPtr.Zero)
                            {
                              ObjectContainerNode package2 = this.UPackageToPackage(Pkg);
                              if (package2 != null)
                                objectContainerNodeList.Add(package2);
                            }
                          }
                          FString fstring5;
                          FString* path = \u003CModule\u003E.FFilename\u002EGetPath(&ffilename1, &fstring5);
                          // ISSUE: fault handler
                          try
                          {
                            this.LastOpenPath = \u003CModule\u003E.CLRTools\u002EToString(path);
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
                          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
                        }
                        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
                      }
                      __fault
                      {
                        // ISSUE: method pointer
                        // ISSUE: cast to a function pointer type
                        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename1);
                      }
                      \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename1);
                      ++num2;
                      num3 = (ulong) num2;
                    }
                    while (num3 < \u003CModule\u003E.wxArrayString\u002EGetCount(&wxArrayString));
                  }
                  this.ContentBrowserCtrl.MySourcesPanel.SetSelectedPackages(objectContainerNodeList);
                  this.RequestPackageListUpdate(false, (UObject*) 0L);
                  FFeedbackContext* gwarn = \u003CModule\u003E.GWarn;
                  // ISSUE: cast to a function pointer type
                  // ISSUE: function pointer call
                  __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) gwarn + 48L))((IntPtr) gwarn);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
                }
                \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxArrayString\u002E\u007Bdtor\u007D), (void*) &wxArrayString);
              }
              \u003CModule\u003E.wxArrayString\u002E\u007Bdtor\u007D(&wxArrayString);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FScopedBusyCursor\u002E\u007Bdtor\u007D), (void*) &fscopedBusyCursor);
            }
            \u003CModule\u003E.FScopedBusyCursor\u002E\u007Bdtor\u007D(&fscopedBusyCursor);
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
        }
        \u003CModule\u003E.WxFileDialog\u002E\u007Bdtor\u007D(&wxFileDialog);
      }
      else if (command == PackageCommands.BulkExport)
      {
        EvtArgs.Handled = true;
        TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAppend(&fdefaultAllocator, Packages);
          this.LoadSelectedPackages(&fdefaultAllocator, PackageNames);
          TSet\u003CUClass\u0020\u002A\u002CDefaultKeyFuncs\u003CUClass\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator1;
          \u003CModule\u003E.TSet\u003CUClass\u0020\u002A\u002CDefaultKeyFuncs\u003CUClass\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator1);
          // ISSUE: fault handler
          try
          {
            List<string> selectedOptions = this.ContentBrowserCtrl.FilterPanel.ObjectTypeFilterTier.GetSelectedOptions();
            if (selectedOptions.Count > 0)
            {
              TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator2;
              \u003CModule\u003E.TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator2);
              // ISSUE: fault handler
              try
              {
                List<string>.Enumerator enumerator = selectedOptions.GetEnumerator();
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
                      FSetElementId fsetElementId;
                      \u003CModule\u003E.TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EAdd(&fdefaultSetAllocator2, &fsetElementId, fstring2, (uint*) 0L);
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
                TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TConstIterator tconstIterator;
                \u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETConstIterator\u002E\u007Bctor\u007D(&tconstIterator, (TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) this.BrowsableObjectTypeToClassMap.Get(), 0);
                if (\u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator))
                {
                  do
                  {
                    UGenericBrowserType* ugenericBrowserTypePtr = (UGenericBrowserType*) *(long*) \u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002EKey((TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator);
                    if (\u003CModule\u003E.TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EContains(&fdefaultSetAllocator2, \u003CModule\u003E.UGenericBrowserType\u002EGetBrowserTypeDescription(ugenericBrowserTypePtr)) == 0U)
                      \u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002B\u002B((TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator);
                    else
                      goto label_168;
                  }
                  while (\u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator));
                  goto label_170;
label_168:
                  \u003CModule\u003E.TSet\u003CUClass\u0020\u002A\u002CDefaultKeyFuncs\u003CUClass\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EAdd(&fdefaultSetAllocator1, \u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002EValue((TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator));
                }
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator2);
              }
label_170:
              \u003CModule\u003E.TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator2);
            }
            // ISSUE: cast to a reference type
            TSet\u003CUClass\u0020\u002A\u002CDefaultKeyFuncs\u003CUClass\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr1 = \u003CModule\u003E.TSet\u003CUClass\u0020\u002A\u002CDefaultKeyFuncs\u003CUClass\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ENum(&fdefaultSetAllocator1) > 0 ? &fdefaultSetAllocator1 : (TSet\u003CUClass\u0020\u002A\u002CDefaultKeyFuncs\u003CUClass\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) (TSet\u003CUClass\u0020\u002A\u002CDefaultKeyFuncs\u003CUClass\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E&) 0L;
            FString fstring3;
            FString* fstringPtr = &fstring3;
            FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, this.LastExportPath);
            TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr2;
            // ISSUE: fault handler
            try
            {
              fdefaultSetAllocatorPtr2 = this.ClassToBrowsableObjectTypeMap.Get();
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) fstringPtr);
            }
            FString fstring5;
            FString* InFString = \u003CModule\u003E.PackageTools\u002EDoBulkExport(&fstring5, &fdefaultAllocator, fstring4, fdefaultSetAllocatorPtr2, fdefaultSetAllocatorPtr1, 0U, (FLocalizationExportFilter*) 0L);
            // ISSUE: fault handler
            try
            {
              this.LastExportPath = \u003CModule\u003E.CLRTools\u002EToString(InFString);
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
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TSet\u003CUClass\u0020\u002A\u002CDefaultKeyFuncs\u003CUClass\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator1);
          }
          \u003CModule\u003E.TSet\u003CUClass\u0020\u002A\u002CDefaultKeyFuncs\u003CUClass\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator1);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
      }
      else if (command == PackageCommands.BulkImport)
      {
        EvtArgs.Handled = true;
        FString fstring1;
        FString* fstringPtr = &fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.LastImportPath);
        FString fstring3;
        FString* InFString = \u003CModule\u003E.PackageTools\u002EDoBulkImport(&fstring3, fstring2);
        // ISSUE: fault handler
        try
        {
          this.LastImportPath = \u003CModule\u003E.CLRTools\u002EToString(InFString);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      }
      else if (command == PackageCommands.LocExport)
      {
        EvtArgs.Handled = true;
        TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAppend(&fdefaultAllocator, Packages);
          this.LoadSelectedPackages(&fdefaultAllocator, PackageNames);
          FString fstring1;
          FString* fstringPtr = &fstring1;
          FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.LastExportPath);
          TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr;
          // ISSUE: fault handler
          try
          {
            fdefaultSetAllocatorPtr = this.ClassToBrowsableObjectTypeMap.Get();
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) fstringPtr);
          }
          FString fstring3;
          FString* InFString = \u003CModule\u003E.PackageTools\u002EExportLocalization(&fstring3, &fdefaultAllocator, fstring2, fdefaultSetAllocatorPtr);
          // ISSUE: fault handler
          try
          {
            this.LastExportPath = \u003CModule\u003E.CLRTools\u002EToString(InFString);
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
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
      }
      else if (command == PackageCommands.CheckErrors)
      {
        EvtArgs.Handled = true;
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
        // ISSUE: fault handler
        try
        {
          TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator2;
          \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.UEditorEngine\u002ECheckForTrashcanReferences(\u003CModule\u003E.GEditor, Packages, &fdefaultAllocator1, &fdefaultAllocator2);
            FString fstring1;
            \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
            // ISSUE: fault handler
            try
            {
              if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1) > 0)
              {
                int num = 0;
                if (0 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1))
                {
                  do
                  {
                    UObject* uobjectPtr1 = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, num);
                    UObject* uobjectPtr2 = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator2, num);
                    FString fstring2;
                    FString* fullName1 = \u003CModule\u003E.UObject\u002EGetFullName(uobjectPtr2, &fstring2, (UObject*) 0L);
                    // ISSUE: fault handler
                    try
                    {
                      FString fstring3;
                      FString* fullName2 = \u003CModule\u003E.UObject\u002EGetFullName(uobjectPtr1, &fstring3, (UObject*) 0L);
                      // ISSUE: fault handler
                      try
                      {
                        FString fstring4;
                        FString* name1 = \u003CModule\u003E.UObject\u002EGetName((UObject*) \u003CModule\u003E.UObject\u002EGetOutermost(uobjectPtr2), &fstring4);
                        // ISSUE: fault handler
                        try
                        {
                          FString fstring5;
                          FString* name2 = \u003CModule\u003E.UObject\u002EGetName((UObject*) \u003CModule\u003E.UObject\u002EGetOutermost(uobjectPtr1), &fstring5);
                          // ISSUE: fault handler
                          try
                          {
                            FString fstring6;
                            FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E(&fstring6, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D91, \u003CModule\u003E.FString\u002E\u002A(name2), \u003CModule\u003E.FString\u002E\u002A(name1), \u003CModule\u003E.FString\u002E\u002A(fullName2), \u003CModule\u003E.FString\u002E\u002A(fullName1), (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D90);
                            // ISSUE: fault handler
                            try
                            {
                              \u003CModule\u003E.FString\u002E\u002B\u003D(&fstring1, fstringPtr);
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
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
                    }
                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
                    ++num;
                  }
                  while (num < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1));
                }
              }
              else
                \u003CModule\u003E.FString\u002E\u003D(&fstring1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D92);
              int num1 = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf((EAppMsgType) 0, \u003CModule\u003E.FString\u002E\u002A(&fstring1));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
          }
          \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
      }
      else
      {
        if (command != PackageCommands.SyncPackageView)
          return;
        EvtArgs.Handled = true;
        List<string> stringList = new List<string>();
        foreach (AssetItem selectedItem in (IEnumerable) ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems)
        {
          if (!stringList.Contains(selectedItem.PathOnly))
            stringList.Add(selectedItem.PathOnly);
        }
        List<ObjectContainerNode> objectContainerNodeList = new List<ObjectContainerNode>();
        List<string>.Enumerator enumerator = stringList.GetEnumerator();
        if (enumerator.MoveNext())
        {
          do
          {
            ObjectContainerNode package = this.ContentBrowserCtrl.MySources.FindPackage(enumerator.Current, (SourcesPanelModel.EPackageSearchOptions) 1);
            if (package != null && !objectContainerNodeList.Contains(package))
              objectContainerNodeList.Add(package);
          }
          while (enumerator.MoveNext());
        }
        this.ContentBrowserCtrl.MySourcesPanel.SetSelectedPackages(objectContainerNodeList);
        this.ContentBrowserCtrl.AssetView.StartDeferredAssetSelection(this.ContentBrowserCtrl.AssetView.CloneSelectedAssetFullNames());
      }
    }
    else
    {
      EvtArgs.Handled = true;
      int num = (int) this.SavePackages(Packages, 0U);
      this.bPackageListUpdateUIRequested = true;
      this.bPackageListUpdateRequested = true;
      this.ContentBrowserCtrl.MyAssets.UpdateStatusForAllAssetsInView((AssetStatusUpdateFlags) 1);
    }
  }

  protected unsafe void ExecuteSCCCommand(
    object Sender,
    ExecutedRoutedEventArgs EvtArgs,
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* Packages,
    TArray\u003CFString\u002CFDefaultAllocator\u003E* InPackageNames)
  {
    EvtArgs.Handled = true;
    if (\u003CModule\u003E.FSourceControl\u002EIsEnabled() == 0U)
      return;
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator, InPackageNames);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FSourceControl\u002EConvertPackageNamesToSourceControlPaths(&fdefaultAllocator);
      if (EvtArgs.Command == SourceControlCommands.RefreshSCC)
      {
        EvtArgs.Handled = true;
        FContentBrowser* nativeBrowserPtr = this.NativeBrowserPtr;
        \u003CModule\u003E.FSourceControl\u002EIssueUpdateState((IntPtr) nativeBrowserPtr == IntPtr.Zero ? (FSourceControlEventListener*) (ValueType) 0L : (FSourceControlEventListener*) (ValueType) ((IntPtr) nativeBrowserPtr + 24L), &fdefaultAllocator);
      }
      else if (EvtArgs.Command == SourceControlCommands.RevisionHistorySCC)
      {
        EvtArgs.Handled = true;
        \u003CModule\u003E.SourceControlWindows\u002EDisplayRevisionHistory(&fdefaultAllocator);
      }
      else if (EvtArgs.Command == SourceControlCommands.CheckInSCC)
      {
        EvtArgs.Handled = true;
        switch (\u003CModule\u003E.FEditorFileUtils\u002EPromptForCheckoutAndSave(Packages, 1U, 1U, (TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L))
        {
          case (FEditorFileUtils.EPromptReturnCode) 0:
          case (FEditorFileUtils.EPromptReturnCode) 2:
            FContentBrowser* nativeBrowserPtr = this.NativeBrowserPtr;
            int num1 = (int) \u003CModule\u003E.SourceControlWindows\u002EPromptForCheckin((IntPtr) nativeBrowserPtr == IntPtr.Zero ? (FSourceControlEventListener*) (ValueType) 0L : (FSourceControlEventListener*) (ValueType) ((IntPtr) nativeBrowserPtr + 24L), InPackageNames);
            break;
          case (FEditorFileUtils.EPromptReturnCode) 1:
            FString fstring;
            FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BE\u0040LBNJGNAP\u0040SCC_Checkin_Aborted\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
            // ISSUE: fault handler
            try
            {
              int num2 = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf((EAppMsgType) 0, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
            break;
        }
      }
      else if (EvtArgs.Command == SourceControlCommands.CheckOutSCC)
      {
        EvtArgs.Handled = true;
        FContentBrowser* nativeBrowserPtr = this.NativeBrowserPtr;
        int num = (int) \u003CModule\u003E.FSourceControl\u002ECheckOut((IntPtr) nativeBrowserPtr == IntPtr.Zero ? (FSourceControlEventListener*) (ValueType) 0L : (FSourceControlEventListener*) (ValueType) ((IntPtr) nativeBrowserPtr + 24L), &fdefaultAllocator, \u003CModule\u003E.GIsUCC);
      }
      else if (EvtArgs.Command == SourceControlCommands.RevertSCC)
      {
        EvtArgs.Handled = true;
        FContentBrowser* nativeBrowserPtr = this.NativeBrowserPtr;
        int num = (int) \u003CModule\u003E.SourceControlWindows\u002EPromptForRevert((IntPtr) nativeBrowserPtr == IntPtr.Zero ? (FSourceControlEventListener*) (ValueType) 0L : (FSourceControlEventListener*) (ValueType) ((IntPtr) nativeBrowserPtr + 24L), InPackageNames);
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

  protected unsafe void CanExecuteNewObjectCommand(
    object Sender,
    CanExecuteRoutedEventArgs EventArgs)
  {
    EventArgs.Handled = true;
    bool flag = false;
    if (((RoutedCommand) EventArgs.Command).OwnerType == typeof (ObjectFactoryCommands))
    {
      if (EventArgs.Parameter == null)
      {
        flag = true;
      }
      else
      {
        int num = (int) EventArgs.Parameter - 21366;
        MScopedNativePointer\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E objectFactoryClasses = this.ObjectFactoryClasses;
        if (objectFactoryClasses.IsValid() && num >= 0 && num < \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(objectFactoryClasses.op_MemberSelection()))
          flag = *(long*) \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(this.ObjectFactoryClasses.Get(), num) != 0L || flag;
      }
    }
    EventArgs.CanExecute = flag;
  }

  protected unsafe void ExecuteNewObjectCommand(object Sender, ExecutedRoutedEventArgs EventArgs)
  {
    EventArgs.Handled = true;
    if (!(((RoutedCommand) EventArgs.Command).OwnerType == typeof (ObjectFactoryCommands)))
      return;
    UClass* uclassPtr = (UClass*) 0L;
    if (EventArgs.Parameter != null)
    {
      int num = (int) EventArgs.Parameter - 21366;
      uclassPtr = (UClass*) *(long*) \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(this.ObjectFactoryClasses.Get(), num);
    }
    FString fstring1;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BE\u0040OIOADBNO\u0040\u003F\u0024AAM\u003F\u0024AAy\u003F\u0024AAP\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAk\u003F\u0024AAa\u003F\u0024AAg\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2);
      // ISSUE: fault handler
      try
      {
        this.GetSelectedPackageAndGroupName(&fstring1, &fstring2);
        WxDlgNewGeneric wxDlgNewGeneric;
        \u003CModule\u003E.WxDlgNewGeneric\u002E\u007Bctor\u007D(&wxDlgNewGeneric);
        // ISSUE: fault handler
        try
        {
          if (\u003CModule\u003E.WxDlgNewGeneric\u002EShowModal(&wxDlgNewGeneric, &fstring1, &fstring2, uclassPtr, this.BrowsableObjectTypeList.Get()) == 5100)
          {
            if ((IntPtr) uclassPtr == IntPtr.Zero)
              uclassPtr = \u003CModule\u003E.WxDlgNewGeneric\u002EGetFactoryClass(&wxDlgNewGeneric);
            if ((*(int*) ((IntPtr) \u003CModule\u003E.UClass\u002EGetDefaultObject\u003Cclass\u0020UFactory\u003E(uclassPtr, 0U) + 144L) & 2) != 0)
            {
              FScopedBusyCursor fscopedBusyCursor;
              \u003CModule\u003E.FScopedBusyCursor\u002E\u007Bctor\u007D(&fscopedBusyCursor);
              // ISSUE: fault handler
              try
              {
                UObject* createdObject = \u003CModule\u003E.WxDlgNewGeneric\u002EGetCreatedObject(&wxDlgNewGeneric);
                if ((IntPtr) createdObject != IntPtr.Zero)
                {
                  FCallbackEventParameters fcallbackEventParameters;
                  // ISSUE: cast to a function pointer type
                  // ISSUE: function pointer call
                  __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) \u003CModule\u003E.GCallbackEvent, (IntPtr) \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters, (FCallbackEventDevice*) 0L, (ECallbackEventType) 23, 16384U, createdObject));
                }
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FScopedBusyCursor\u002E\u007Bdtor\u007D), (void*) &fscopedBusyCursor);
              }
              \u003CModule\u003E.FScopedBusyCursor\u002E\u007Bdtor\u007D(&fscopedBusyCursor);
            }
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxDlgNewGeneric\u002E\u007Bdtor\u007D), (void*) &wxDlgNewGeneric);
        }
        \u003CModule\u003E.WxDlgNewGeneric\u002E\u007Bdtor\u007D(&wxDlgNewGeneric);
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

  protected void CanExecuteCollectionCommand(object Sender, CanExecuteRoutedEventArgs EventArgs)
  {
    EventArgs.Handled = true;
    bool flag1 = false;
    RoutedCommand command = (RoutedCommand) EventArgs.Command;
    if (command.OwnerType == typeof (CollectionCommands))
    {
      bool flag2 = false;
      ReadOnlyCollection<string> readOnlyCollection1 = this.ContentBrowserCtrl.MySourcesPanel.GetSelectedCollectionNames((EBrowserCollectionType) 0).AsReadOnly();
      ReadOnlyCollection<string> readOnlyCollection2 = this.ContentBrowserCtrl.MySourcesPanel.GetSelectedCollectionNames((EBrowserCollectionType) 1).AsReadOnly();
      ReadOnlyCollection<string> readOnlyCollection3 = this.ContentBrowserCtrl.MySourcesPanel.GetSelectedCollectionNames((EBrowserCollectionType) 2).AsReadOnly();
      int num1;
      if (readOnlyCollection1.Count <= 0)
      {
        if (readOnlyCollection2.Count <= 0 && readOnlyCollection3.Count > 0)
        {
          flag2 = true;
        }
        else
        {
          num1 = 1;
          goto label_6;
        }
      }
      num1 = 0;
label_6:
      bool flag3 = num1 != 0;
      int num2 = readOnlyCollection3.Count + readOnlyCollection2.Count;
      int num3 = readOnlyCollection1.Count + num2;
      if (num3 > 0)
      {
        if (command == CollectionCommands.Rename)
          flag1 = num3 == 1 && !flag2 && (flag3 || this.IsUserCollectionsAdmin());
        if (command == CollectionCommands.CreateSharedCopy)
          flag1 = num3 == 1;
        if (command == CollectionCommands.CreatePrivateCopy)
          flag1 = num3 == 1;
        if (command == CollectionCommands.Destroy)
          flag1 = flag2 || flag3 || this.IsUserCollectionsAdmin();
      }
    }
    EventArgs.CanExecute = flag1;
  }

  protected void ExecuteCollectionCommand(object Sender, ExecutedRoutedEventArgs EventArgs)
  {
    EventArgs.Handled = true;
    RoutedCommand command = (RoutedCommand) EventArgs.Command;
    if (!(command.OwnerType == typeof (CollectionCommands)))
      return;
    bool flag1 = false;
    bool flag2 = false;
    ReadOnlyCollection<string> readOnlyCollection1 = this.ContentBrowserCtrl.MySourcesPanel.GetSelectedCollectionNames((EBrowserCollectionType) 0).AsReadOnly();
    ReadOnlyCollection<string> readOnlyCollection2 = this.ContentBrowserCtrl.MySourcesPanel.GetSelectedCollectionNames((EBrowserCollectionType) 1).AsReadOnly();
    ReadOnlyCollection<string> readOnlyCollection3 = this.ContentBrowserCtrl.MySourcesPanel.GetSelectedCollectionNames((EBrowserCollectionType) 2).AsReadOnly();
    int num1;
    if (readOnlyCollection1.Count > 0)
    {
      flag1 = true;
    }
    else
    {
      if (readOnlyCollection2.Count > 0)
        flag1 = false;
      else if (readOnlyCollection3.Count > 0)
      {
        flag2 = true;
        goto label_8;
      }
      num1 = 1;
      goto label_9;
    }
label_8:
    num1 = 0;
label_9:
    bool flag3 = num1 != 0;
    int num2 = readOnlyCollection3.Count + readOnlyCollection2.Count;
    int num3 = readOnlyCollection1.Count + num2;
    if (num3 <= 0)
      return;
    if (command == CollectionCommands.Rename && num3 == 1)
    {
      EBrowserCollectionType ebrowserCollectionType = flag1 ? (EBrowserCollectionType) 0 : (EBrowserCollectionType) 1;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.ContentBrowserCtrl.MySourcesPanel.ShowPromptToRenameCollection((EBrowserCollectionType) ^(int&) ref ebrowserCollectionType);
    }
    if ((command == CollectionCommands.CreateSharedCopy || command == CollectionCommands.CreatePrivateCopy) && num3 == 1)
    {
      EBrowserCollectionType ebrowserCollectionType1 = (EBrowserCollectionType) 0;
      EBrowserCollectionType ebrowserCollectionType2 = !flag3 ? (flag2 ? (EBrowserCollectionType) 2 : (EBrowserCollectionType) (int) ebrowserCollectionType1) : (EBrowserCollectionType) 1;
      EBrowserCollectionType ebrowserCollectionType3 = command == CollectionCommands.CreateSharedCopy ? (EBrowserCollectionType) 0 : (EBrowserCollectionType) 1;
      // ISSUE: cast to a reference type
      // ISSUE: explicit reference operation
      this.ContentBrowserCtrl.MySourcesPanel.ShowPromptToCopyCollection(ebrowserCollectionType2, (EBrowserCollectionType) ^(int&) ref ebrowserCollectionType3);
    }
    if (command != CollectionCommands.Destroy)
      return;
    if (!flag3 && !flag2)
      this.ContentBrowserCtrl.MySourcesPanel.ShowPromptToDestroySelectedSharedCollections();
    else
      this.ContentBrowserCtrl.MySourcesPanel.ShowPromptToDestroySelectedPrivateCollections();
  }

  public virtual unsafe void CanExecuteMenuCommand(object Sender, CanExecuteRoutedEventArgs EvtArgs)
  {
    EvtArgs.Handled = true;
    if (this.bIsExecutingMenuCommand)
      EvtArgs.CanExecute = false;
    else if (!((UIElement) this.ContentBrowserCtrl).IsEnabled)
    {
      EvtArgs.CanExecute = false;
    }
    else
    {
      RoutedCommand command = (RoutedCommand) EvtArgs.Command;
      if (command == PackageCommands.OpenExplorer)
        EvtArgs.CanExecute = this.ContentBrowserCtrl.MySourcesPanel.AnyNodesSelected();
      else if (command == PackageCommands.FullyLoadPackage)
      {
        TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
        // ISSUE: fault handler
        try
        {
          TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
          // ISSUE: fault handler
          try
          {
            this.GetSelectedRootPackages(&fdefaultAllocator1, &fdefaultAllocator2, 0U);
            this.OnCanExecutePackageCommand(Sender, EvtArgs, &fdefaultAllocator1, &fdefaultAllocator2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
          }
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
      }
      else if (!(command.OwnerType == typeof (PackageCommands)) && command != ApplicationCommands.Save && command != PackageCommands.SaveAsset)
      {
        if (command.OwnerType == typeof (SourceControlCommands))
        {
          TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
          // ISSUE: fault handler
          try
          {
            TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
            // ISSUE: fault handler
            try
            {
              this.GetSelectedRootPackages(&fdefaultAllocator1, &fdefaultAllocator2, 1U);
              this.OnCanExecuteSCCCommand(Sender, EvtArgs, &fdefaultAllocator1, &fdefaultAllocator2);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
            }
            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
          }
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
        }
        else if (command.OwnerType == typeof (ObjectFactoryCommands))
        {
          this.CanExecuteNewObjectCommand(Sender, EvtArgs);
        }
        else
        {
          if (!(command.OwnerType == typeof (CollectionCommands)))
            return;
          this.CanExecuteCollectionCommand(Sender, EvtArgs);
        }
      }
      else
      {
        TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
        // ISSUE: fault handler
        try
        {
          TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
          // ISSUE: fault handler
          try
          {
            this.GetSelectedRootPackages(&fdefaultAllocator1, &fdefaultAllocator2, 1U);
            this.OnCanExecutePackageCommand(Sender, EvtArgs, &fdefaultAllocator1, &fdefaultAllocator2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
          }
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
      }
    }
  }

  public virtual unsafe void ExecuteMenuCommand(object Sender, ExecutedRoutedEventArgs EvtArgs)
  {
    EvtArgs.Handled = true;
    if (this.bIsExecutingMenuCommand)
      return;
    this.bIsExecutingMenuCommand = true;
    RoutedCommand command = (RoutedCommand) EvtArgs.Command;
    if (command == PackageCommands.OpenExplorer)
    {
      if (this.ContentBrowserCtrl.MySourcesPanel.AnyNodesSelected())
      {
        ReadOnlyCollection<SourceTreeNode> readOnlyCollection = this.ContentBrowserCtrl.MySourcesPanel.MakeSelectedNodeList();
        int index = 0;
        if (0 < readOnlyCollection.Count)
        {
          SourceTreeNode outermostPackage;
          do
          {
            outermostPackage = readOnlyCollection[index];
            if (outermostPackage == null)
              ++index;
            else
              goto label_7;
          }
          while (index < readOnlyCollection.Count);
          goto label_38;
label_7:
          FString fstring1;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, \u003CModule\u003E.appBaseDir());
          StringBuilder stringBuilder;
          // ISSUE: fault handler
          try
          {
            stringBuilder = new StringBuilder(new string(\u003CModule\u003E.FString\u002E\u002A(&fstring1), 0, \u003CModule\u003E.FString\u002ELen(&fstring1)));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          stringBuilder.Append("..\\..");
          if (((object) outermostPackage).GetType() == typeof (GroupPackage))
            outermostPackage = (SourceTreeNode) ((ObjectContainerNode) outermostPackage).OutermostPackage;
          stringBuilder.Append(outermostPackage.FullTreeviewPath.Replace((char) SourceTreeNode.TreeViewNodeSeparator, Path.DirectorySeparatorChar));
          FString fstring2;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, stringBuilder.ToString());
          // ISSUE: fault handler
          try
          {
            if (((object) outermostPackage).GetType() != typeof (Folder))
            {
              // ISSUE: cast to a function pointer type
              // ISSUE: function pointer call
              int num = (int) __calli((__FnPtr<uint (IntPtr, char*, FGuid*, FString*, char*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 16L))((char*) \u003CModule\u003E.GPackageFileCache, (FString*) \u003CModule\u003E.FString\u002E\u002A(&fstring2), (FGuid*) 0L, (char*) &fstring2, IntPtr.Zero);
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "explorer.exe";
            string str = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
            startInfo.Arguments = "/select," + str;
            EvtArgs.Handled = true;
            Process.Start(startInfo);
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
    }
    else if (!(command.OwnerType == typeof (PackageCommands)) && command != ApplicationCommands.Save && command != PackageCommands.SaveAsset)
    {
      if (command.OwnerType == typeof (SourceControlCommands))
      {
        TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
        // ISSUE: fault handler
        try
        {
          TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
          // ISSUE: fault handler
          try
          {
            this.GetSelectedRootPackages(&fdefaultAllocator1, &fdefaultAllocator2, 1U);
            this.ExecuteSCCCommand(Sender, EvtArgs, &fdefaultAllocator1, &fdefaultAllocator2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
          }
          \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
      }
      else if (command.OwnerType == typeof (ObjectFactoryCommands))
        this.ExecuteNewObjectCommand(Sender, EvtArgs);
      else if (command.OwnerType == typeof (CollectionCommands))
        this.ExecuteCollectionCommand(Sender, EvtArgs);
    }
    else
    {
      TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
      // ISSUE: fault handler
      try
      {
        TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedRootPackages(&fdefaultAllocator1, &fdefaultAllocator2, 1U);
          this.ExecutePackageCommand(Sender, EvtArgs, &fdefaultAllocator1, &fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
      }
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    }
label_38:
    this.bIsExecutingMenuCommand = false;
  }

  public virtual unsafe void CanExecuteAssetCommand(
    object Sender,
    CanExecuteRoutedEventArgs EvtArgs)
  {
    EvtArgs.Handled = true;
    RoutedCommand command = (RoutedCommand) EvtArgs.Command;
    if (!((UIElement) this.ContentBrowserCtrl).IsEnabled)
      EvtArgs.CanExecute = false;
    else if (command == PackageCommands.ImportAsset)
      EvtArgs.CanExecute = false;
    else if (command == PackageCommands.OpenPackage)
      EvtArgs.CanExecute = false;
    else if (command == PackageCommands.OpenExplorer)
    {
      byte num = (byte) (((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems.Count > 0);
      EvtArgs.CanExecute = (bool) num;
    }
    else if (!(command.OwnerType == typeof (PackageCommands)) && command != ApplicationCommands.Save && command != PackageCommands.SaveAsset)
    {
      if (!(command.OwnerType == typeof (SourceControlCommands)))
        return;
      TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
      // ISSUE: fault handler
      try
      {
        TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          this.GetPackagesForSelectedAssetItems(&fdefaultAllocator1, &fdefaultAllocator2);
          this.OnCanExecuteSCCCommand(Sender, EvtArgs, &fdefaultAllocator1, &fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
      }
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    }
    else
    {
      TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
      // ISSUE: fault handler
      try
      {
        TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          this.GetPackagesForSelectedAssetItems(&fdefaultAllocator1, &fdefaultAllocator2);
          this.OnCanExecutePackageCommand(Sender, EvtArgs, &fdefaultAllocator1, &fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
      }
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    }
  }

  public virtual unsafe void ExecuteAssetCommand(object Sender, ExecutedRoutedEventArgs EvtArgs)
  {
    EvtArgs.Handled = true;
    RoutedCommand command = (RoutedCommand) EvtArgs.Command;
    if (command == PackageCommands.OpenExplorer)
    {
      EvtArgs.Handled = true;
      List<string> stringList = new List<string>();
      foreach (AssetItem selectedItem in (IEnumerable) ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems)
      {
        if (!stringList.Contains(selectedItem.PackageName))
          stringList.Add(selectedItem.PackageName);
      }
      List<string>.Enumerator enumerator = stringList.GetEnumerator();
      if (!enumerator.MoveNext())
        return;
      ObjectContainerNode package;
      do
      {
        package = ((SourceTreeNode) this.ContentBrowserCtrl.MySources.RootFolder).FindPackage(enumerator.Current);
        if (package != null)
          goto label_12;
      }
      while (enumerator.MoveNext());
      return;
label_12:
      FString fstring;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, \u003CModule\u003E.appBaseDir());
      StringBuilder stringBuilder;
      // ISSUE: fault handler
      try
      {
        stringBuilder = new StringBuilder(new string(\u003CModule\u003E.FString\u002E\u002A(&fstring), 0, \u003CModule\u003E.FString\u002ELen(&fstring)));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      stringBuilder.Append("..\\..");
      stringBuilder.Append(((SourceTreeNode) package).FullTreeviewPath.Replace((char) SourceTreeNode.TreeViewNodeSeparator, Path.DirectorySeparatorChar));
      stringBuilder.Append(".upk");
      ProcessStartInfo startInfo = new ProcessStartInfo();
      startInfo.FileName = "explorer.exe";
      startInfo.Arguments = "/select," + stringBuilder.ToString();
      EvtArgs.Handled = true;
      Process.Start(startInfo);
    }
    else if (command != PackageCommands.ImportAsset && (command.OwnerType == typeof (PackageCommands) || command == ApplicationCommands.Save || command == PackageCommands.SaveAsset))
    {
      TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
      // ISSUE: fault handler
      try
      {
        TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          this.GetPackagesForSelectedAssetItems(&fdefaultAllocator1, &fdefaultAllocator2);
          this.ExecutePackageCommand(Sender, EvtArgs, &fdefaultAllocator1, &fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
      }
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    }
    else
    {
      if (!(command.OwnerType == typeof (SourceControlCommands)))
        return;
      TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
      // ISSUE: fault handler
      try
      {
        TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          this.GetPackagesForSelectedAssetItems(&fdefaultAllocator1, &fdefaultAllocator2);
          this.ExecuteSCCCommand(Sender, EvtArgs, &fdefaultAllocator1, &fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
      }
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    }
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual bool ShouldShowConfirmationPrompt(ConfirmationPromptType InType) => MContentBrowserControl.ShowConfirmationPrompt[InType];

  public virtual void DisableConfirmationPrompt(ConfirmationPromptType InType) => MContentBrowserControl.ShowConfirmationPrompt[InType] = false;

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool SyncToObjects(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InObjects)
  {
    List<string> OutTags = (List<string>) null;
    bool flag = false;
    if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InObjects) > 0)
    {
      if (!this.DoObjectsPassObjectTypeTest(InObjects))
        this.ContentBrowserCtrl.FilterPanel.ClearFilterForBrowserSync();
      else
        this.ContentBrowserCtrl.FilterPanel.ClearFilterExceptObjectType();
      TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
      // ISSUE: fault handler
      try
      {
        this.GeneratePackageList(InObjects, &fdefaultAllocator);
        if (\u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator) > 0)
        {
          List<ObjectContainerNode> objectContainerNodeList = new List<ObjectContainerNode>();
          int num1 = 0;
          if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator))
          {
            do
            {
              ObjectContainerNode package = this.UPackageToPackage((UPackage*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num1));
              if (package != null)
                objectContainerNodeList.Add(package);
              ++num1;
            }
            while (num1 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator));
          }
          flag = this.ContentBrowserCtrl.MySourcesPanel.SetSelectedPackages(objectContainerNodeList);
          uint num2 = this.ContentBrowserCtrl.IsInQuarantineMode() || (IntPtr) \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA == IntPtr.Zero ? 0U : 1U;
          uint num3 = 0;
          string str1;
          if (num2 != 0U)
          {
            string str2 = "";
            str1 = '['.ToString() + GADDefs.SystemTagTypeNames[10] + (object) ']' + str2;
          }
          else
            str1 = string.Empty;
          List<string> stringList = new List<string>();
          int num4 = 0;
          if (0 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InObjects))
          {
            do
            {
              UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InObjects, num4);
              if ((IntPtr) uobjectPtr != IntPtr.Zero)
              {
                FString fstring;
                FString* fullName = \u003CModule\u003E.UObject\u002EGetFullName(uobjectPtr, &fstring, (UObject*) 0L);
                string InAssetFullName;
                // ISSUE: fault handler
                try
                {
                  InAssetFullName = new string(\u003CModule\u003E.FString\u002E\u002A(fullName), 0, \u003CModule\u003E.FString\u002ELen(fullName));
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
                if (num2 != 0U)
                {
                  \u003CModule\u003E.FGameAssetDatabase\u002EQueryTagsForAsset(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, InAssetFullName, (ETagQueryOptions.Type) 1, out OutTags);
                  if (OutTags.Contains(str1))
                  {
                    num3 = 1U;
                    goto label_22;
                  }
                }
                stringList.Add(InAssetFullName);
              }
label_22:
              ++num4;
            }
            while (num4 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InObjects));
            if (num3 != 0U)
              this.ContentBrowserCtrl.PlayWarning(Utils.Localize("ContentBrowser_Warning_FailedSyncToQuarantinedAssets"));
          }
          this.ContentBrowserCtrl.AssetView.StartDeferredAssetSelection(stringList);
        }
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
      }
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    }
    else
      this.ContentBrowserCtrl.AssetView.SetSelection((AssetItem) null);
    return flag;
  }

  public unsafe void SyncToPackages(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* InPackages)
  {
    List<ObjectContainerNode> objectContainerNodeList = new List<ObjectContainerNode>();
    int num = 0;
    if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InPackages))
    {
      do
      {
        ObjectContainerNode package = this.UPackageToPackage((UPackage*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InPackages, num));
        if (package != null)
          objectContainerNodeList.Add(package);
        ++num;
      }
      while (num < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InPackages));
    }
    this.ContentBrowserCtrl.MySourcesPanel.SetSelectedPackages(objectContainerNodeList);
  }

  public unsafe void GoToSearch()
  {
    WxContentBrowserHost* parentBrowserWindow = this.ParentBrowserWindow;
    if ((IntPtr) parentBrowserWindow != IntPtr.Zero)
      \u003CModule\u003E.UBrowserManager\u002EShowWindow(\u003CModule\u003E.UUnrealEdEngine\u002EGetBrowserManager(\u003CModule\u003E.GUnrealEd), \u003CModule\u003E.WxBrowser\u002EGetDockID((WxBrowser*) parentBrowserWindow), 1U);
    this.ContentBrowserCtrl.FilterPanel.GoToSearchBox();
  }

  public unsafe void Resize(HWND__* hWndParent, int x, int y, int Width, int Height) => \u003CModule\u003E.SetWindowPos((HWND__*) this.InteropWindow.Handle.ToPointer(), (HWND__*) 0L, 0, 0, Width, Height, 6U);

  public unsafe void QuerySerializableObjects(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* OutObjects)
  {
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EReset(OutObjects, 0);
    MScopedNativePointer\u003CTMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E browsableObjectTypeMap = this.ClassToBrowsableObjectTypeMap;
    if (browsableObjectTypeMap.IsValid())
    {
      TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr = browsableObjectTypeMap.Get();
      TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TIterator titerator;
      \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bctor\u007D(&titerator, (TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) fdefaultSetAllocatorPtr, 0U, 0);
      // ISSUE: fault handler
      try
      {
        if (\u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002E_N((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator))
        {
          do
          {
            UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002EKey((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator);
            \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(OutObjects, &uobjectPtr);
            \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002B\u002B((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator);
          }
          while (\u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002E_N((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator));
        }
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bdtor\u007D), (void*) &titerator);
      }
      \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bdtor\u007D(&titerator);
    }
    MScopedNativePointer\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E browsableObjectTypeList = this.BrowsableObjectTypeList;
    if (browsableObjectTypeList.IsValid())
    {
      int num = 0;
      if (0 < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(browsableObjectTypeList.op_MemberSelection()))
      {
        do
        {
          UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(this.BrowsableObjectTypeList.Get(), num);
          \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(OutObjects, &uobjectPtr);
          ++num;
        }
        while (num < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.BrowsableObjectTypeList.op_MemberSelection()));
      }
    }
    MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E referencedObjects = this.ReferencedObjects;
    if (referencedObjects.IsValid())
    {
      TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = referencedObjects.Get();
      int num = 0;
      if (0 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr))
      {
        do
        {
          \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(OutObjects, \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, num));
          ++num;
        }
        while (num < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr));
      }
    }
    MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E callbackEventObjects = this.CallbackEventObjects;
    if (callbackEventObjects.op_Implicit())
    {
      TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = callbackEventObjects.Get();
      int num = 0;
      if (0 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr))
      {
        do
        {
          \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(OutObjects, \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, num));
          ++num;
        }
        while (num < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr));
      }
    }
    MScopedNativePointer\u003CTArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E callbackEventPackages = this.CallbackEventPackages;
    if (callbackEventPackages.op_Implicit())
    {
      TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = callbackEventPackages.Get();
      int num = 0;
      if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr))
      {
        do
        {
          UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, num);
          \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(OutObjects, &uobjectPtr);
          ++num;
        }
        while (num < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr));
      }
    }
    MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E eventSyncObjects = this.CallbackEventSyncObjects;
    if (!eventSyncObjects.op_Implicit())
      return;
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = eventSyncObjects.Get();
    int num1 = 0;
    if (0 >= \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr1))
      return;
    do
    {
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(OutObjects, \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr1, num1));
      ++num1;
    }
    while (num1 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr1));
  }

  public unsafe void Tick()
  {
    if (\u003CModule\u003E.GIsPlayInEditorWorld != 0U)
      return;
    this.bPackageFilterUpdateRequested = this.bPackageFilterUpdateRequested || this.bPackageListUpdateRequested || (this.bPackageListUpdateUIRequested || this.bIsSCCStateDirty);
    this.ConditionalUpdateCollections();
    this.ConditionalUpdatePackages();
    this.ConditionalUpdateSCC((TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L);
    if (this.bPackageFilterUpdateRequested)
    {
      this.ContentBrowserCtrl.MySourcesPanel.RefreshPackageFilter();
      this.bPackageFilterUpdateRequested = false;
    }
    this.ConditionalUpdateAssetView();
    this.UpdateAssetQuery();
    this.ContentBrowserCtrl.AssetView.FilterRefreshTick(this.QueryEngineState != EContentBrowserQueryState.Idle);
    this.ContentBrowserCtrl.AssetView.AssetCanvas.UpdateAssetCanvas();
    if (this.bAssetViewUpdateRequested || this.QueryEngineState != EContentBrowserQueryState.Idle)
      return;
    this.ContentBrowserCtrl.AssetView.SelectDeferredAssetsIfNeeded();
  }

  public unsafe void OnPendingGarbageCollection()
  {
    MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E referencedObjects = this.ReferencedObjects;
    if (referencedObjects.IsValid())
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(referencedObjects.Get(), 0);
    MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E callbackEventObjects = this.CallbackEventObjects;
    if (callbackEventObjects.op_Implicit())
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(callbackEventObjects.Get(), 0);
    MScopedNativePointer\u003CTArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E callbackEventPackages = this.CallbackEventPackages;
    if (callbackEventPackages.op_Implicit())
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(callbackEventPackages.Get(), 0);
    MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E eventSyncObjects = this.CallbackEventSyncObjects;
    if (eventSyncObjects.op_Implicit())
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(eventSyncObjects.Get(), 0);
    if (this.QueryEngineState == EContentBrowserQueryState.Idle)
      return;
    this.AssetQuery_RestartQuery();
  }

  public unsafe void OnObjectModification(
    UObject* InObject,
    uint bForceUpdate,
    AssetStatusUpdateFlags UpdateFlags)
  {
    if (((IntPtr) \u003CModule\u003E.UObject\u002EGetOuter(InObject) == IntPtr.Zero || \u003CModule\u003E.UObject\u002EGetClass(\u003CModule\u003E.UObject\u002EGetOuter(InObject)) != \u003CModule\u003E.UPackage\u002EStaticClass()) && bForceUpdate == 0U)
      return;
    FObjectThumbnail* thumbnailForObject = \u003CModule\u003E.ThumbnailTools\u002EGetThumbnailForObject(InObject);
    if ((IntPtr) thumbnailForObject != IntPtr.Zero)
      \u003CModule\u003E.FObjectThumbnail\u002EMarkAsDirty(thumbnailForObject);
    FString fstring;
    FString* fullName = \u003CModule\u003E.UObject\u002EGetFullName(InObject, &fstring, (UObject*) 0L);
    string str;
    // ISSUE: fault handler
    try
    {
      str = new string(\u003CModule\u003E.FString\u002E\u002A(fullName), 0, \u003CModule\u003E.FString\u002ELen(fullName));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
    AssetItem assetItem = this.ContentBrowserCtrl.AssetView.FindAssetItem(str);
    if (assetItem == null)
      return;
    AssetVisual visual = (AssetVisual) assetItem.Visual;
    if (visual != null)
      visual.ShouldRefreshThumbnail = (__Null) 3;
    this.UpdateAssetStatus(assetItem, UpdateFlags);
    assetItem.MarkCustomLabelsAsDirty();
    assetItem.MarkCustomDataColumnsAsDirty();
    assetItem.MarkMemoryUsageAsDirty();
    assetItem.UpdateCustomLabelsIfNeeded();
    assetItem.UpdateCustomDataColumnsIfNeeded();
    assetItem.UpdateMemoryUsageIfNeeded();
  }

  public unsafe void OnObjectModification(UObject* InObject, uint bForceUpdate) => this.OnObjectModification(InObject, bForceUpdate, (AssetStatusUpdateFlags) 1);

  public void RequestSCCStateUpdate() => this.bIsSCCStateDirty = true;

  public void ClearFilter() => this.ContentBrowserCtrl.FilterPanel.ClearFilter();

  public unsafe void RemoveFromPackageList(UPackage* PackageToRemove) => this.ContentBrowserCtrl.MySources.RemovePackage(this.UPackageToPackage(PackageToRemove));

  public unsafe void RequestPackageListUpdate([MarshalAs(UnmanagedType.U1)] bool bUpdateUIOnly, UObject* SourceObject)
  {
    this.bPackageListUpdateUIRequested = true;
    if (bUpdateUIOnly && !this.bPackageListUpdateRequested)
    {
      UPackage* upackagePtr = \u003CModule\u003E.Cast\u003Cclass\u0020UPackage\u003E(SourceObject);
      if ((IntPtr) upackagePtr != IntPtr.Zero && !this.bPackageListUpdateRequested)
      {
        if (!this.CallbackEventPackages.op_Implicit())
        {
          TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = (TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
          TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* InNativePointer;
          // ISSUE: fault handler
          try
          {
            InNativePointer = (IntPtr) fdefaultAllocatorPtr == IntPtr.Zero ? (TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr);
          }
          __fault
          {
            \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr);
          }
          this.CallbackEventPackages.Reset(InNativePointer);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(this.CallbackEventPackages.op_MemberSelection(), &upackagePtr);
      }
      this.bAssetViewUpdateUIRequested = true;
    }
    else
      this.bPackageListUpdateRequested = true;
  }

  public void RequestCollectionListUpdate([MarshalAs(UnmanagedType.U1)] bool bUpdateUIOnly)
  {
    this.bCollectionListUpdateUIRequested = true;
    if (bUpdateUIOnly)
      return;
    this.bCollectionListUpdateRequested = true;
  }

  public unsafe void RequestAssetListUpdate(
    AssetListRefreshMode RefreshMode,
    UObject* SourceObject,
    uint AssetUpdateFlagMask)
  {
    switch (RefreshMode)
    {
      case AssetListRefreshMode.UIOnly:
        this.bAssetViewUpdateUIRequested = true;
        if ((IntPtr) SourceObject != IntPtr.Zero)
        {
          if (!this.CallbackEventObjects.op_Implicit())
          {
            TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
            TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InNativePointer;
            // ISSUE: fault handler
            try
            {
              InNativePointer = (IntPtr) fdefaultAllocatorPtr == IntPtr.Zero ? (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr);
            }
            __fault
            {
              \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr);
            }
            this.CallbackEventObjects.Reset(InNativePointer);
          }
          \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(this.CallbackEventObjects.op_MemberSelection(), &SourceObject);
          break;
        }
        break;
      case AssetListRefreshMode.Repopulate:
        this.bAssetViewUpdateRequested = true;
        this.bDoFullAssetViewUpdate = true;
        break;
      default:
        if (!this.bAssetViewUpdateRequested)
        {
          this.bAssetViewUpdateRequested = true;
          this.bDoFullAssetViewUpdate = this.bDoFullAssetViewUpdate || !this.IsCapableOfQuickUpdate();
          break;
        }
        break;
    }
    this.AssetUpdateFlags |= AssetUpdateFlagMask;
  }

  public unsafe void RequestSyncAssetView(UObject* SourceObject)
  {
    if ((IntPtr) SourceObject == IntPtr.Zero)
      return;
    this.bAssetViewSyncRequested = true;
    if (!this.CallbackEventSyncObjects.op_Implicit())
    {
      TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
      TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InNativePointer;
      // ISSUE: fault handler
      try
      {
        InNativePointer = (IntPtr) fdefaultAllocatorPtr == IntPtr.Zero ? (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr);
      }
      __fault
      {
        \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr);
      }
      this.CallbackEventSyncObjects.Reset(InNativePointer);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(this.CallbackEventSyncObjects.op_MemberSelection(), &SourceObject);
  }

  public void StartAssetQuery()
  {
    this.AssetQuery_ClearQuery();
    this.QueryEngineState = EContentBrowserQueryState.StartNewQuery;
    if (this.CachedQueryData.get() == null)
      this.CachedQueryData.reset(new MContentBrowserControl.CachedQueryDataType());
    this.CachedQueryData.op_MemberSelection().SelectedSharedCollectionNames = this.ContentBrowserCtrl.MySourcesPanel.GetSelectedCollectionNames((EBrowserCollectionType) 0).AsReadOnly();
    this.CachedQueryData.op_MemberSelection().SelectedPrivateCollectionNames = this.ContentBrowserCtrl.MySourcesPanel.GetSelectedCollectionNames((EBrowserCollectionType) 1).AsReadOnly();
    this.CachedQueryData.op_MemberSelection().SelectedLocalCollectionNames = this.ContentBrowserCtrl.MySourcesPanel.GetSelectedCollectionNames((EBrowserCollectionType) 2).AsReadOnly();
    auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E cachedQueryData = this.CachedQueryData;
    this.ContentBrowserCtrl.MySourcesPanel.MakeSelectedPathNameAndOutermostFullNameList(ref cachedQueryData.op_MemberSelection().SelectedPathNames, ref cachedQueryData.op_MemberSelection().SelectedOutermostPackageNames, ref cachedQueryData.op_MemberSelection().ExplicitlySelectedOutermostPackageNames);
  }

  public unsafe void UpdateAssetQuery()
  {
    double InUpdateStartTime = \u003CModule\u003E.appSeconds();
    QueryUpdateMode UpdateModeFlags = this.bDoFullAssetViewUpdate ? QueryUpdateMode.Amortizing : QueryUpdateMode.QuickUpdate | QueryUpdateMode.Amortizing;
    switch (this.QueryEngineState)
    {
      case EContentBrowserQueryState.Idle:
        return;
      case EContentBrowserQueryState.StartNewQuery:
        this.QueryEngineState = EContentBrowserQueryState.GatherObjects;
        this.ContentBrowserCtrl.OnAssetPopulationStarted((UpdateModeFlags & QueryUpdateMode.QuickUpdate) == QueryUpdateMode.QuickUpdate);
        break;
    }
    if (this.QueryEngineState == EContentBrowserQueryState.GatherObjects && this.AssetQuery_GatherPackagesAndObjects())
    {
      this.QueryEngineState = EContentBrowserQueryState.AddLoadedAssets;
      this.CachedQueryIteratorIndex = 0;
      if ((UpdateModeFlags & QueryUpdateMode.QuickUpdate) == QueryUpdateMode.None)
        ((Collection<AssetItem>) this.ContentBrowserCtrl.MyAssets).Clear();
      else
        this.AssetQuery_RemoveMissingAssets(QueryUpdateMode.QuickUpdate);
    }
    int num = \u003CModule\u003E.TMapBase\u003CFName\u002Cint\u002C1\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003CFName\u002Cint\u002C1\u002CFDefaultSetAllocator\u003E*) this.CachedQueryAssetFullNameFNamesFromGAD.op_MemberSelection()) + \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.CachedQueryObjects.op_MemberSelection());
    if (this.QueryEngineState == EContentBrowserQueryState.AddLoadedAssets)
    {
      if (this.AssetQuery_AddLoadedAssets(InUpdateStartTime, UpdateModeFlags))
      {
        this.QueryEngineState = EContentBrowserQueryState.AddNonLoadedAssets;
        this.CachedQueryIteratorIndex = 0;
      }
      else
        this.ContentBrowserCtrl.SetAssetUpdateProgress((double) this.CachedQueryIteratorIndex * 100.0 / (double) num);
    }
    if (this.QueryEngineState == EContentBrowserQueryState.AddNonLoadedAssets)
    {
      if (this.AssetQuery_AddNonLoadedAssets(InUpdateStartTime, UpdateModeFlags))
      {
        this.AssetQuery_ClearQuery();
        this.bDoFullAssetViewUpdate = false;
        this.ContentBrowserCtrl.RequestFilterRefresh((RefreshFlags) 0);
        this.ContentBrowserCtrl.OnAssetPopulationComplete((UpdateModeFlags & QueryUpdateMode.QuickUpdate) == QueryUpdateMode.QuickUpdate);
      }
      else
        this.ContentBrowserCtrl.SetAssetUpdateProgress((double) (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.CachedQueryObjects.op_MemberSelection()) + this.CachedQueryIteratorIndex) * 100.0 / (double) num);
    }
    this.ContentBrowserCtrl.UpdateAssetCount();
  }

  public unsafe void AssetQuery_ClearQuery()
  {
    this.CachedQueryData.reset((MContentBrowserControl.CachedQueryDataType) null);
    if (!this.LastQueryAssetFullNameFNamesFromGAD.IsValid())
    {
      TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr = (TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E*) \u003CModule\u003E.@new(88UL);
      TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E* InNativePointer;
      // ISSUE: fault handler
      try
      {
        InNativePointer = (IntPtr) fdefaultSetAllocatorPtr == IntPtr.Zero ? (TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E*) 0L : \u003CModule\u003E.TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(fdefaultSetAllocatorPtr);
      }
      __fault
      {
        \u003CModule\u003E.delete((void*) fdefaultSetAllocatorPtr);
      }
      this.LastQueryAssetFullNameFNamesFromGAD.Reset(InNativePointer);
    }
    this.CachedQueryObjects.Reset((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L);
    if (!this.LastQueryLoadedAssetFullNames.IsValid())
    {
      TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr = (TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) \u003CModule\u003E.@new(72UL);
      TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* InNativePointer;
      // ISSUE: fault handler
      try
      {
        InNativePointer = (IntPtr) fdefaultSetAllocatorPtr == IntPtr.Zero ? (TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) 0L : \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(fdefaultSetAllocatorPtr);
      }
      __fault
      {
        \u003CModule\u003E.delete((void*) fdefaultSetAllocatorPtr);
      }
      this.LastQueryLoadedAssetFullNames.Reset(InNativePointer);
    }
    MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E callbackEventObjects = this.CallbackEventObjects;
    if (callbackEventObjects.op_Implicit())
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(callbackEventObjects.op_MemberSelection(), 0);
    this.CachedQueryIteratorIndex = 0;
    this.QueryEngineState = EContentBrowserQueryState.Idle;
  }

  public void AssetQuery_RestartQuery()
  {
    if (this.QueryEngineState == EContentBrowserQueryState.Idle)
      return;
    auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E cachedQueryDataType1 = new auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E(this.CachedQueryData);
    auto_handle\u003CMContentBrowserControl\u003A\u003ACachedQueryDataType\u003E cachedQueryDataType2;
    // ISSUE: fault handler
    try
    {
      cachedQueryDataType2 = cachedQueryDataType1;
      this.AssetQuery_ClearQuery();
      this.CachedQueryData.reset(cachedQueryDataType2.release());
      this.QueryEngineState = EContentBrowserQueryState.StartNewQuery;
      this.StartAssetQuery();
    }
    __fault
    {
      cachedQueryDataType2.Dispose();
    }
    cachedQueryDataType2.Dispose();
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool AssetQuery_GatherPackagesAndObjects()
  {
    List<string> OutAssetFullNames = (List<string>) null;
    TSet\u003CUPackage\u0020const\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020const\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
    \u003CModule\u003E.TSet\u003CUPackage\u0020const\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020const\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
    // ISSUE: fault handler
    try
    {
      TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.PackageTools\u002EGetFilteredPackageList((TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E*) 0L, &fdefaultSetAllocator, (TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) 0L, &fdefaultAllocator1);
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InNativePointer1;
        // ISSUE: fault handler
        try
        {
          InNativePointer1 = (IntPtr) fdefaultAllocatorPtr1 == IntPtr.Zero ? (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr1);
        }
        __fault
        {
          \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr1);
        }
        this.CachedQueryObjects.Reset(InNativePointer1);
        if (((Dictionary<string, int>) this.CachedQueryData.op_MemberSelection().SelectedOutermostPackageNames).Count > 0)
        {
          TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator2;
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
          // ISSUE: fault handler
          try
          {
            int num = 0;
            if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1))
            {
              do
              {
                FString fstring;
                FString* pathName = \u003CModule\u003E.UObject\u002EGetPathName((UObject*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, num), &fstring, (UObject*) 0L);
                string str;
                // ISSUE: fault handler
                try
                {
                  str = \u003CModule\u003E.CLRTools\u002EToString(pathName);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
                if (this.CachedQueryData.op_MemberSelection().SelectedOutermostPackageNames.Contains(str))
                  \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator2, \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, num));
                ++num;
              }
              while (num < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1));
            }
            \u003CModule\u003E.PackageTools\u002EGetObjectsInPackages(&fdefaultAllocator2, this.ClassToBrowsableObjectTypeMap.Get(), this.CachedQueryObjects.Get());
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
          }
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
        }
        else
          \u003CModule\u003E.PackageTools\u002EGetObjectsInPackages((TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L, this.ClassToBrowsableObjectTypeMap.Get(), this.CachedQueryObjects.Get());
        this.LastQueryLoadedAssetFullNames.Reset(this.CachedQueryLoadedAssetFullNames.Release());
        TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr = (TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) \u003CModule\u003E.@new(72UL);
        TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E* InNativePointer2;
        // ISSUE: fault handler
        try
        {
          InNativePointer2 = (IntPtr) fdefaultSetAllocatorPtr == IntPtr.Zero ? (TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) 0L : \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(fdefaultSetAllocatorPtr);
        }
        __fault
        {
          \u003CModule\u003E.delete((void*) fdefaultSetAllocatorPtr);
        }
        this.CachedQueryLoadedAssetFullNames.Reset(InNativePointer2);
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = this.CachedQueryObjects.Get();
        int num1 = 0;
        if (0 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr2))
        {
          do
          {
            FString fstring;
            FString* fullName = \u003CModule\u003E.UObject\u002EGetFullName((UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr2, num1), &fstring, (UObject*) 0L);
            // ISSUE: fault handler
            try
            {
              FSetElementId fsetElementId;
              FName fname;
              \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EAdd(this.CachedQueryLoadedAssetFullNames.op_MemberSelection(), &fsetElementId, *\u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, \u003CModule\u003E.FString\u002E\u002A(fullName), (EFindName) 1, 1U), (uint*) 0L);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
            ++num1;
          }
          while (num1 < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr2));
        }
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
      }
      \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TSet\u003CUPackage\u0020const\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020const\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
    }
    \u003CModule\u003E.TSet\u003CUPackage\u0020const\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020const\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator);
    List<string> stringList = new List<string>();
    foreach (string sharedCollectionName in this.CachedQueryData.op_MemberSelection().SelectedSharedCollectionNames)
      stringList.Add(\u003CModule\u003E.FGameAssetDatabase\u002EMakeSystemTag(ESystemTagType.SharedCollection, sharedCollectionName));
    foreach (string privateCollectionName in this.CachedQueryData.op_MemberSelection().SelectedPrivateCollectionNames)
      stringList.Add(\u003CModule\u003E.FGameAssetDatabase\u002EMakeSystemTag(ESystemTagType.PrivateCollection, privateCollectionName));
    foreach (string localCollectionName in this.CachedQueryData.op_MemberSelection().SelectedLocalCollectionNames)
      stringList.Add(\u003CModule\u003E.FGameAssetDatabase\u002EMakeSystemTag(ESystemTagType.LocalCollection, localCollectionName));
    foreach (string outermostPackageName in this.CachedQueryData.op_MemberSelection().SelectedOutermostPackageNames)
      stringList.Add(\u003CModule\u003E.FGameAssetDatabase\u002EMakeSystemTag(ESystemTagType.OutermostPackage, outermostPackageName));
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    TArray\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      try
      {
        if (stringList.Count > 0)
        {
          TArray\u003CFString\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = (TArray\u003CFString\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
          TArray\u003CFString\u002CFDefaultAllocator\u003E* OutFStrings;
          // ISSUE: fault handler
          try
          {
            OutFStrings = (IntPtr) fdefaultAllocatorPtr1 == IntPtr.Zero ? (TArray\u003CFString\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr1);
          }
          __fault
          {
            \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr1);
          }
          TArray\u003CFString\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = OutFStrings;
          \u003CModule\u003E.CLRTools\u002EToFStringArray((ICollection<string>) stringList, OutFStrings);
          \u003CModule\u003E.TArray\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, &fdefaultAllocatorPtr2);
        }
        this.LastQueryAssetFullNameFNamesFromGAD.Reset(this.CachedQueryAssetFullNameFNamesFromGAD.Release());
        TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr = (TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E*) \u003CModule\u003E.@new(88UL);
        TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E* InNativePointer;
        // ISSUE: fault handler
        try
        {
          InNativePointer = (IntPtr) fdefaultSetAllocatorPtr == IntPtr.Zero ? (TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E*) 0L : \u003CModule\u003E.TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(fdefaultSetAllocatorPtr);
        }
        __fault
        {
          \u003CModule\u003E.delete((void*) fdefaultSetAllocatorPtr);
        }
        this.CachedQueryAssetFullNameFNamesFromGAD.Reset(InNativePointer);
        \u003CModule\u003E.FGameAssetDatabase\u002EQueryAssetsWithTagInAllSets(database0PeaV1Ea, &fdefaultAllocator, this.CachedQueryAssetFullNameFNamesFromGAD.Get());
        \u003CModule\u003E.FGameAssetDatabase\u002EQueryAssetsWithTag(database0PeaV1Ea, \u003CModule\u003E.FGameAssetDatabase\u002EMakeSystemTag(ESystemTagType.Quarantined, ""), out OutAssetFullNames);
        this.CachedQueryQuarantinedAssets = new NameSet((ICollection<string>) OutAssetFullNames);
      }
      finally
      {
        int num = 0;
        if (0 < \u003CModule\u003E.TArray\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator))
        {
          do
          {
            TArray\u003CFString\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = (TArray\u003CFString\u002CFDefaultAllocator\u003E*) *(long*) \u003CModule\u003E.TArray\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num);
            if ((IntPtr) fdefaultAllocatorPtr != IntPtr.Zero)
              \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E__delDtor(fdefaultAllocatorPtr, 1U);
            ++num;
          }
          while (num < \u003CModule\u003E.TArray\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator));
        }
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    return true;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool AssetQuery_AddLoadedAssets(
    double InUpdateStartTime,
    QueryUpdateMode UpdateModeFlags)
  {
    bool flag1 = (UpdateModeFlags & QueryUpdateMode.Amortizing) == QueryUpdateMode.Amortizing;
    bool flag2 = (UpdateModeFlags & QueryUpdateMode.QuickUpdate) == QueryUpdateMode.QuickUpdate;
    bool flag3 = this.ContentBrowserCtrl.IsInQuarantineMode();
    AssetViewModel myAssets = this.ContentBrowserCtrl.MyAssets;
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = this.CachedQueryObjects.Get();
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    bool flag4;
    // ISSUE: fault handler
    try
    {
      if (this.CachedQueryIteratorIndex < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr))
      {
        do
        {
          UObject* uobjectPtr1 = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, this.CachedQueryIteratorIndex);
          FString fstring1;
          FString* fullName = \u003CModule\u003E.UObject\u002EGetFullName(uobjectPtr1, &fstring1, (UObject*) 0L);
          FName fname;
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, \u003CModule\u003E.FString\u002E\u002A(fullName), (EFindName) 1, 1U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          string str1 = \u003CModule\u003E.CLRTools\u002EFNameToString(&fname);
          FString fstring2;
          FString* pathName = \u003CModule\u003E.UObject\u002EGetPathName(uobjectPtr1, &fstring2, (UObject*) 0L);
          string str2;
          // ISSUE: fault handler
          try
          {
            str2 = new string(\u003CModule\u003E.FString\u002E\u002A(pathName), 0, \u003CModule\u003E.FString\u002ELen(pathName));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
          int length = str2.LastIndexOf('.');
          string str3 = str2.Substring(0, length);
          string str4 = str2.Substring(length + 1);
          bool flag5 = false;
          bool flag6 = false;
          if (flag2)
          {
            flag6 = \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EContains(this.LastQueryLoadedAssetFullNames.op_MemberSelection(), fname) == 0U && \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EContains(this.CachedQueryLoadedAssetFullNames.op_MemberSelection(), fname) != 0U;
            flag5 = flag6 && \u003CModule\u003E.TMapBase\u003CFName\u002Cint\u002C1\u002CFDefaultSetAllocator\u003E\u002EHasKey((TMapBase\u003CFName\u002Cint\u002C1\u002CFDefaultSetAllocator\u003E*) this.LastQueryAssetFullNameFNamesFromGAD.op_MemberSelection(), fname) == 0U;
          }
          bool flag7 = this.CachedQueryQuarantinedAssets.Contains(str1);
          uint num1 = ((Dictionary<string, int>) this.CachedQueryData.op_MemberSelection().SelectedPathNames).Count != 0 || this.CachedQueryData.op_MemberSelection().SelectedSharedCollectionNames.Count != 0 || (this.CachedQueryData.op_MemberSelection().SelectedPrivateCollectionNames.Count != 0 || this.CachedQueryData.op_MemberSelection().SelectedLocalCollectionNames.Count != 0) ? 0U : 1U;
          uint num2 = (uint) this.CachedQueryData.op_MemberSelection().SelectedPathNames.Contains(str3);
          uint num3 = num1 != 0U || this.CachedQueryData.op_MemberSelection().SelectedSharedCollectionNames.Count <= 0 && this.CachedQueryData.op_MemberSelection().SelectedPrivateCollectionNames.Count <= 0 && this.CachedQueryData.op_MemberSelection().SelectedLocalCollectionNames.Count <= 0 || (IntPtr) \u003CModule\u003E.TMapBase\u003CFName\u002Cint\u002C1\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003CFName\u002Cint\u002C1\u002CFDefaultSetAllocator\u003E*) this.CachedQueryAssetFullNameFNamesFromGAD.op_MemberSelection(), fname) == IntPtr.Zero ? 0U : 1U;
          uint num4 = !flag3 && flag7 || num1 == 0U && num2 == 0U && num3 == 0U || !flag6 && !flag5 && flag2 ? 0U : 1U;
          uint num5 = !flag2 || !flag6 || flag5 ? 0U : 1U;
          if (num4 != 0U)
          {
            AssetItem assetItem = new AssetItem(this.ContentBrowserCtrl, str4, str3);
            assetItem.IsQuarantined = flag7;
            FString fstring3;
            FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) \u003CModule\u003E.UObject\u002EGetClass(uobjectPtr1), &fstring3);
            string str5;
            // ISSUE: fault handler
            try
            {
              str5 = \u003CModule\u003E.CLRTools\u002EToString(name);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
            assetItem.AssetType = str5;
            byte num6;
            if (\u003CModule\u003E.UObject\u002EHasAllFlags(uobjectPtr1, 1024UL) != 0U)
            {
              UObject* uobjectPtr2 = uobjectPtr1;
              // ISSUE: cast to a function pointer type
              // ISSUE: function pointer call
              if (__calli((__FnPtr<uint (IntPtr, UObject**)>) *(long*) (*(long*) uobjectPtr1 + 376L))((UObject**) uobjectPtr2, IntPtr.Zero) == 0U)
              {
                num6 = (byte) 1;
                goto label_18;
              }
            }
            num6 = (byte) 0;
label_18:
            assetItem.IsArchetype = (bool) num6;
            ETagQueryOptions.Type type = CBDefs.ShowSystemTags ? (ETagQueryOptions.Type) 4 : (ETagQueryOptions.Type) 2;
            \u003CModule\u003E.FGameAssetDatabase\u002EQueryTagsForAsset(database0PeaV1Ea, fname, type, &fdefaultAllocator);
            List<string> stringArray = \u003CModule\u003E.CLRTools\u002EToStringArray(&fdefaultAllocator);
            stringArray.Sort();
            assetItem.Tags = stringArray;
            assetItem.LoadedStatus = \u003CModule\u003E.UPackage\u002EIsDirty(\u003CModule\u003E.UObject\u002EGetOutermost(uobjectPtr1)) == 0U ? (AssetItem.LoadedStatusType) 1 : (AssetItem.LoadedStatusType) 2;
            assetItem.IsVerified = true;
            if (num5 != 0U)
            {
              int assetIndex = this.ContentBrowserCtrl.AssetView.FindAssetIndex(assetItem.FullName);
              if (0 <= assetIndex)
              {
                ((Collection<AssetItem>) this.ContentBrowserCtrl.MyAssets)[assetIndex] = assetItem;
                goto label_22;
              }
            }
            ((Collection<AssetItem>) myAssets).Add(assetItem);
          }
label_22:
          if (!flag1 || this.CachedQueryIteratorIndex % CBDefs.AssetQueryItemsPerTimerCheck != 0 || \u003CModule\u003E.appSeconds() - InUpdateStartTime <= CBDefs.MaxAssetQuerySecondsPerTick)
            ++this.CachedQueryIteratorIndex;
          else
            goto label_24;
        }
        while (this.CachedQueryIteratorIndex < \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr));
        goto label_25;
label_24:
        ++this.CachedQueryIteratorIndex;
      }
label_25:
      flag4 = this.CachedQueryIteratorIndex >= \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    return flag4;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool AssetQuery_AddNonLoadedAssets(
    double InUpdateStartTime,
    QueryUpdateMode UpdateModeFlags)
  {
    if ((UpdateModeFlags & QueryUpdateMode.QuickUpdate) == QueryUpdateMode.QuickUpdate)
      return true;
    bool flag1 = (UpdateModeFlags & QueryUpdateMode.Amortizing) == QueryUpdateMode.Amortizing;
    FGameAssetDatabase* database0PeaV1Ea = \u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA;
    AssetViewModel myAssets = this.ContentBrowserCtrl.MyAssets;
    TArray\u003CFName\u002CFDefaultAllocator\u003E* uniqueElements = \u003CModule\u003E.TLookupMap\u003CFName\u002CFDefaultSetAllocator\u003E\u002EGetUniqueElements(this.CachedQueryAssetFullNameFNamesFromGAD.op_MemberSelection());
    int num1 = \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002ENum(uniqueElements);
    bool flag2 = this.ContentBrowserCtrl.IsInQuarantineMode();
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    bool flag3;
    // ISSUE: fault handler
    try
    {
      if (this.CachedQueryIteratorIndex < num1)
      {
        do
        {
          FName* InFName = \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(uniqueElements, this.CachedQueryIteratorIndex);
          if (\u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EContains(this.CachedQueryLoadedAssetFullNames.op_MemberSelection(), *InFName) == 0U)
          {
            string str1 = \u003CModule\u003E.CLRTools\u002EFNameToString(InFName);
            int length1 = str1.IndexOf(' ');
            string str2 = str1.Substring(0, length1);
            string str3 = str1.Substring(length1 + 1);
            int length2 = str3.LastIndexOf('.');
            int length3 = str3.IndexOf('.');
            string str4 = str3.Substring(0, length2);
            string str5 = str3.Substring(length2 + 1);
            str3.Substring(0, length3);
            bool flag4 = this.CachedQueryQuarantinedAssets.Contains(str1);
            if ((((Dictionary<string, int>) this.CachedQueryData.op_MemberSelection().SelectedPathNames).Count <= 0 || this.CachedQueryData.op_MemberSelection().SelectedPathNames.Contains(str4)) && (flag2 || !flag4))
            {
              \u003CModule\u003E.FGameAssetDatabase\u002EQueryTagsForAsset(database0PeaV1Ea, *InFName, (ETagQueryOptions.Type) 4, &fdefaultAllocator);
              List<string> stringArray = \u003CModule\u003E.CLRTools\u002EToStringArray(&fdefaultAllocator);
              bool flag5 = false;
              bool flag6 = false;
              bool flag7 = false;
              bool flag8 = false;
              bool flag9 = false;
              int index1 = 0;
              if (0 < stringArray.Count)
              {
                do
                {
                  switch (\u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagType(stringArray[index1]))
                  {
                    case ESystemTagType.Invalid:
                      ++index1;
                      continue;
                    case ESystemTagType.ObjectType:
                      flag8 = true;
                      goto default;
                    case ESystemTagType.OutermostPackage:
                      flag7 = true;
                      goto default;
                    case ESystemTagType.Unverified:
                      flag6 = true;
                      goto default;
                    case ESystemTagType.Ghost:
                      flag5 = true;
                      goto default;
                    case ESystemTagType.Archetype:
                      flag9 = true;
                      goto default;
                    default:
                      if (!CBDefs.ShowSystemTags)
                      {
                        int index2 = index1;
                        index1 += -1;
                        stringArray.RemoveAt(index2);
                        goto case ESystemTagType.Invalid;
                      }
                      else
                        goto case ESystemTagType.Invalid;
                  }
                }
                while (index1 < stringArray.Count);
                if (flag8 && flag7 && (!flag5 || CBDefs.ShowSystemTags))
                {
                  AssetItem assetItem = new AssetItem(this.ContentBrowserCtrl, str5, str4);
                  assetItem.IsQuarantined = flag4;
                  assetItem.AssetType = str2;
                  assetItem.IsArchetype = flag9;
                  stringArray.Sort();
                  assetItem.Tags = stringArray;
                  assetItem.LoadedStatus = (AssetItem.LoadedStatusType) 0;
                  byte num2 = (byte) !flag6;
                  assetItem.IsVerified = (bool) num2;
                  ((Collection<AssetItem>) myAssets).Add(assetItem);
                }
              }
            }
          }
          if (!flag1 || this.CachedQueryIteratorIndex % CBDefs.AssetQueryItemsPerTimerCheck != 0 || \u003CModule\u003E.appSeconds() - InUpdateStartTime <= CBDefs.MaxAssetQuerySecondsPerTick)
            ++this.CachedQueryIteratorIndex;
          else
            goto label_20;
        }
        while (this.CachedQueryIteratorIndex < num1);
        goto label_21;
label_20:
        ++this.CachedQueryIteratorIndex;
      }
label_21:
      flag3 = this.CachedQueryIteratorIndex >= num1;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    return flag3;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public unsafe bool AssetQuery_RemoveMissingAssets(QueryUpdateMode UpdateModeFlags)
  {
    AssetViewModel myAssets = this.ContentBrowserCtrl.MyAssets;
    int index = 0;
    if (0 < ((Collection<AssetItem>) myAssets).Count)
    {
      do
      {
        // ISSUE: cast to a reference type
        // ISSUE: variable of a reference type
        byte* local = (byte*) ((Collection<AssetItem>) myAssets)[index].FullName;
        if (local != null)
          local = (long) (uint) RuntimeHelpers.OffsetToStringData + local;
        // ISSUE: explicit reference operation
        fixed (byte* numPtr = &^local)
        {
          FName fname;
          \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (char*) numPtr, (EFindName) 1, 1U);
          if (\u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EContains(this.CachedQueryLoadedAssetFullNames.op_MemberSelection(), fname) == 0U && \u003CModule\u003E.TMapBase\u003CFName\u002Cint\u002C1\u002CFDefaultSetAllocator\u003E\u002EHasKey((TMapBase\u003CFName\u002Cint\u002C1\u002CFDefaultSetAllocator\u003E*) this.CachedQueryAssetFullNameFNamesFromGAD.op_MemberSelection(), fname) == 0U)
            ((Collection<AssetItem>) myAssets).RemoveAt(index);
          else
            ++index;
        }
      }
      while (index < ((Collection<AssetItem>) myAssets).Count);
    }
    return true;
  }

  public unsafe void SetSourceControlState(
    Package pkg,
    TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E* InResultsMap)
  {
    ESourceControlState state = \u003CModule\u003E.FSourceControl\u002ETranslateResultsToState(InResultsMap);
    this.SetSourceControlState(pkg, state);
  }

  public unsafe void SetSourceControlState(Package pkg, ESourceControlState InNewState)
  {
    this.UpdatePackageSCCState((ObjectContainerNode) pkg, InNewState);
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, pkg.Name);
    // ISSUE: fault handler
    try
    {
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      int num = (int) __calli((__FnPtr<uint (IntPtr, char*, int)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 24L))((int) \u003CModule\u003E.GPackageFileCache, \u003CModule\u003E.FString\u002E\u002A(fstring2), (IntPtr) InNewState);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
  }

  public virtual unsafe void SourceControlResultsProcess(FSourceControlCommand* InCommand)
  {
    this.bPackageFilterUpdateRequested = true;
    List<Package> packageList = new List<Package>();
    this.ContentBrowserCtrl.MySources.GetChildNodes<Package>((List<M0>) packageList);
    if (*(int*) ((IntPtr) InCommand + 16L) != 0)
    {
      TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
      \u003CModule\u003E.TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
      // ISSUE: fault handler
      try
      {
        int num1 = 0;
        FSourceControlCommand* fsourceControlCommandPtr1 = (FSourceControlCommand*) ((IntPtr) InCommand + 60L);
        if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr1))
        {
          do
          {
            FFilename ffilename;
            \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr1, num1));
            // ISSUE: fault handler
            try
            {
              FString fstring;
              FString* baseFilename = \u003CModule\u003E.FFilename\u002EGetBaseFilename(&ffilename, &fstring, 1U);
              // ISSUE: fault handler
              try
              {
                FSetElementId fsetElementId;
                uint num2;
                \u003CModule\u003E.TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EAdd(&fdefaultSetAllocator, &fsetElementId, baseFilename, &num2);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename);
            }
            \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename);
            ++num1;
          }
          while (num1 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr1));
        }
        List<Package>.Enumerator enumerator = packageList.GetEnumerator();
        if (enumerator.MoveNext())
        {
          FSourceControlCommand* fsourceControlCommandPtr2 = (FSourceControlCommand*) ((IntPtr) InCommand + 92L);
          do
          {
            Package current = enumerator.Current;
            FString fstring1;
            \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, current.Name);
            // ISSUE: fault handler
            try
            {
              TMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr = \u003CModule\u003E.TMapBase\u003CFString\u002CTMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003CFString\u002CTMap\u003CFString\u002CFString\u002CFDefaultSetAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) fsourceControlCommandPtr2, &fstring1);
              if ((IntPtr) fdefaultSetAllocatorPtr != IntPtr.Zero)
              {
                ESourceControlState state = \u003CModule\u003E.FSourceControl\u002ETranslateResultsToState(fdefaultSetAllocatorPtr);
                this.UpdatePackageSCCState((ObjectContainerNode) current, state);
                FString fstring2;
                FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, current.Name);
                // ISSUE: fault handler
                try
                {
                  // ISSUE: cast to a function pointer type
                  // ISSUE: function pointer call
                  int num2 = (int) __calli((__FnPtr<uint (IntPtr, char*, int)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 24L))((int) \u003CModule\u003E.GPackageFileCache, \u003CModule\u003E.FString\u002E\u002A(fstring3), (IntPtr) state);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
              }
              else if (\u003CModule\u003E.TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EContains(&fdefaultSetAllocator, &fstring1) != 0U)
              {
                if (current != null)
                  ((ObjectContainerNode) current).NodeIcon = (ObjectContainerNode.TreeNodeIconType) 4;
                FString fstring2;
                FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, current.Name);
                // ISSUE: fault handler
                try
                {
                  // ISSUE: cast to a function pointer type
                  // ISSUE: function pointer call
                  int num2 = (int) __calli((__FnPtr<uint (IntPtr, char*, int)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 24L))((int) \u003CModule\u003E.GPackageFileCache, \u003CModule\u003E.FString\u002E\u002A(fstring3), new IntPtr(4));
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
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
      }
      \u003CModule\u003E.TSet\u003CFString\u002CDefaultKeyFuncs\u003CFString\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator);
    }
    else
    {
      int num1 = 0;
      FSourceControlCommand* fsourceControlCommandPtr = (FSourceControlCommand*) ((IntPtr) InCommand + 60L);
      if (0 >= \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr))
        return;
      do
      {
        FFilename ffilename;
        \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr, num1));
        // ISSUE: fault handler
        try
        {
          FString fstring1;
          FString* baseFilename = \u003CModule\u003E.FFilename\u002EGetBaseFilename(&ffilename, &fstring1, 1U);
          string str;
          // ISSUE: fault handler
          try
          {
            str = new string(\u003CModule\u003E.FString\u002E\u002A(baseFilename), 0, \u003CModule\u003E.FString\u002ELen(baseFilename));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          List<Package>.Enumerator enumerator = packageList.GetEnumerator();
          if (enumerator.MoveNext())
          {
            do
            {
              Package current = enumerator.Current;
              if (current.Name == str)
              {
                if (current != null)
                  ((ObjectContainerNode) current).NodeIcon = (ObjectContainerNode.TreeNodeIconType) 4;
                FString fstring2;
                FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, current.Name);
                // ISSUE: fault handler
                try
                {
                  // ISSUE: cast to a function pointer type
                  // ISSUE: function pointer call
                  int num2 = (int) __calli((__FnPtr<uint (IntPtr, char*, int)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 24L))((int) \u003CModule\u003E.GPackageFileCache, \u003CModule\u003E.FString\u002E\u002A(fstring3), new IntPtr(4));
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
            while (enumerator.MoveNext());
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename);
        }
        \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename);
        ++num1;
      }
      while (num1 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFString\u002CFDefaultAllocator\u003E*) fsourceControlCommandPtr));
    }
  }

  protected unsafe void ConditionalUpdateSCC(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* PackageList)
  {
    if (!this.bIsSCCStateDirty)
      return;
    this.bIsSCCStateDirty = false;
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      if ((IntPtr) PackageList == IntPtr.Zero)
      {
        List<Package> packageList = new List<Package>();
        this.ContentBrowserCtrl.MySources.GetChildNodes<Package>((List<M0>) packageList);
        List<Package>.Enumerator enumerator = packageList.GetEnumerator();
        if (enumerator.MoveNext())
        {
          do
          {
            Package current = enumerator.Current;
            FString fstring1;
            FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, current.Name);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, fstring2);
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
      }
      else
      {
        int num = 0;
        if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(PackageList))
        {
          do
          {
            FString fstring;
            FString* pathName = \u003CModule\u003E.UObject\u002EGetPathName((UObject*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(PackageList, num), &fstring, (UObject*) 0L);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, pathName);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
            ++num;
          }
          while (num < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(PackageList));
        }
      }
      \u003CModule\u003E.FSourceControl\u002EConvertPackageNamesToSourceControlPaths(&fdefaultAllocator);
      FContentBrowser* nativeBrowserPtr = this.NativeBrowserPtr;
      \u003CModule\u003E.FSourceControl\u002EIssueUpdateState((IntPtr) nativeBrowserPtr == IntPtr.Zero ? (FSourceControlEventListener*) (ValueType) 0L : (FSourceControlEventListener*) (ValueType) ((IntPtr) nativeBrowserPtr + 24L), &fdefaultAllocator);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  protected unsafe void ConditionalUpdatePackages()
  {
    if (this.bPackageListUpdateRequested)
    {
      this.bPackageListUpdateRequested = false;
      MScopedNativePointer\u003CTArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E callbackEventPackages = this.CallbackEventPackages;
      if (callbackEventPackages.op_Implicit() && \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(callbackEventPackages.op_MemberSelection()) > 0)
      {
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(this.CallbackEventPackages.op_MemberSelection(), 0);
        this.bPackageListUpdateUIRequested = true;
      }
      MContentBrowserControl mcontentBrowserControl = this;
      mcontentBrowserControl.UpdatePackagesTree(mcontentBrowserControl.ContentBrowserCtrl.MySourcesPanel.UsingFlatList);
    }
    if (this.bPackageListUpdateUIRequested)
    {
      this.bPackageListUpdateUIRequested = false;
      MScopedNativePointer\u003CTArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E callbackEventPackages = this.CallbackEventPackages;
      if (callbackEventPackages.op_Implicit() && \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(callbackEventPackages.op_MemberSelection()) > 0)
      {
        TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = this.CallbackEventPackages.Get();
        int num = 0;
        if (0 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr))
        {
          do
          {
            UPackage* upackagePtr = (UPackage*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, num);
            MContentBrowserControl mcontentBrowserControl = this;
            mcontentBrowserControl.UpdatePackagesTreeUI(mcontentBrowserControl.UPackageToPackage(upackagePtr), upackagePtr);
            ++num;
          }
          while (num < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr));
        }
      }
      else
        this.UpdatePackagesTreeUI();
    }
    MScopedNativePointer\u003CTArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E callbackEventPackages1 = this.CallbackEventPackages;
    if (!callbackEventPackages1.op_Implicit() || \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(callbackEventPackages1.op_MemberSelection()) <= 0)
      return;
    \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(this.CallbackEventPackages.op_MemberSelection(), 0);
  }

  protected void ConditionalUpdateCollections()
  {
    if (this.bCollectionListUpdateRequested)
    {
      this.bCollectionListUpdateRequested = false;
      this.UpdateCollectionsList();
      this.bCollectionListUpdateUIRequested = true;
    }
    if (this.bCollectionListUpdateUIRequested)
      this.bCollectionListUpdateUIRequested = false;
    if (!this.bCollectionSyncRequested)
      return;
    this.bCollectionSyncRequested = false;
    List<MContentBrowserControl.CollectionSelectRequest> collectionSelectRequests = this.CollectionSelectRequests;
    if (collectionSelectRequests == null)
      return;
    List<MContentBrowserControl.CollectionSelectRequest>.Enumerator enumerator = collectionSelectRequests.GetEnumerator();
    if (enumerator.MoveNext())
    {
      do
      {
        MContentBrowserControl.CollectionSelectRequest current = enumerator.Current;
        this.ContentBrowserCtrl.MySourcesPanel.SelectCollection(current.CollectionName, current.CollectionType);
      }
      while (enumerator.MoveNext());
    }
    this.CollectionSelectRequests.Clear();
  }

  protected unsafe void ConditionalUpdateAssetView()
  {
    if (this.bAssetViewSyncRequested)
    {
      this.bAssetViewSyncRequested = false;
      this.bAssetViewUpdateRequested = true;
      this.bAssetViewUpdateUIRequested = false;
      MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E eventSyncObjects = this.CallbackEventSyncObjects;
      if (!eventSyncObjects.op_Implicit() || \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(eventSyncObjects.op_MemberSelection()) <= 0)
        return;
      MContentBrowserControl mcontentBrowserControl = this;
      bool objects = mcontentBrowserControl.SyncToObjects(mcontentBrowserControl.CallbackEventSyncObjects.Get());
      this.bDoFullAssetViewUpdate = this.bDoFullAssetViewUpdate || objects;
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(this.CallbackEventSyncObjects.op_MemberSelection(), 0);
    }
    else if (this.bAssetViewUpdateRequested)
    {
      this.bAssetViewUpdateRequested = false;
      this.bAssetViewUpdateUIRequested = false;
      this.StartAssetQuery();
    }
    else
    {
      if (!this.bAssetViewUpdateUIRequested)
        return;
      this.bAssetViewUpdateUIRequested = false;
      MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E callbackEventObjects = this.CallbackEventObjects;
      if (callbackEventObjects.op_Implicit())
      {
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = callbackEventObjects.Get();
        if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr) > 0)
        {
          do
          {
            UObject* InObject = \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EPop(fdefaultAllocatorPtr);
            if ((IntPtr) InObject != IntPtr.Zero)
              this.OnObjectModification(InObject, 0U, (AssetStatusUpdateFlags) (int) this.AssetUpdateFlags);
            else
              break;
          }
          while (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr) > 0);
        }
      }
      this.AssetUpdateFlags = 0U;
    }
  }

  protected void ConditionalUpdatePackageFilter()
  {
    if (!this.bPackageFilterUpdateRequested)
      return;
    this.ContentBrowserCtrl.MySourcesPanel.RefreshPackageFilter();
    this.bPackageFilterUpdateRequested = false;
  }

  protected unsafe void GetFilteredPackageList(
    TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* ObjectTypes,
    TSet\u003CUPackage\u0020const\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020const\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E* OutFilteredPackageMap,
    TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E* OutGroupPackages,
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* OutPackageList)
  {
    \u003CModule\u003E.PackageTools\u002EGetFilteredPackageList(ObjectTypes, OutFilteredPackageMap, OutGroupPackages, OutPackageList);
  }

  protected unsafe void PurgeInvalidNodesFromTree(
    TArray\u003CFString\u002CFDefaultAllocator\u003E* PackageNamesOnDisk,
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* LoadedPackages,
    TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E* LoadedGroups)
  {
    SourcesPanelModel mySources = this.ContentBrowserCtrl.MySources;
    int num1 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNamesOnDisk))
    {
      do
      {
        FFilename ffilename;
        \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(PackageNamesOnDisk, num1));
        // ISSUE: fault handler
        try
        {
          FString fstring;
          FString* baseFilename = \u003CModule\u003E.FFilename\u002EGetBaseFilename(&ffilename, &fstring, 0U);
          string str1;
          // ISSUE: fault handler
          try
          {
            string str2 = new string(\u003CModule\u003E.FString\u002E\u002A(baseFilename), 0, \u003CModule\u003E.FString\u002ELen(baseFilename));
            str1 = mySources.NormalizePackageFilePathName(str2);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
          if (!Utils.IsPackageValidForTree(str1))
          {
            SourceTreeNode descendantNode = mySources.FindDescendantNode(str1);
            if (descendantNode != null)
            {
              if (!(((object) descendantNode).GetType() == typeof (Package)))
              {
                if (!(((object) descendantNode).GetType() == typeof (GroupPackage)))
                  goto label_13;
              }
              mySources.RemovePackage((ObjectContainerNode) descendantNode);
            }
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename);
        }
label_13:
        \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename);
        ++num1;
      }
      while (num1 < \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(PackageNamesOnDisk));
    }
    TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TConstIterator tconstIterator;
    \u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETConstIterator\u002E\u007Bctor\u007D(&tconstIterator, LoadedGroups, 0);
    if (\u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator))
    {
      do
      {
        UPackage* outermost = \u003CModule\u003E.UObject\u002EGetOutermost((UObject*) *(long*) \u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002A((TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator));
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(LoadedPackages, &outermost);
        \u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002B\u002B((TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator);
      }
      while (\u003CModule\u003E.TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TSet\u003CUPackage\u0020\u002A\u002CDefaultKeyFuncs\u003CUPackage\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator));
    }
    int num2 = 0;
    if (0 >= \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(LoadedPackages))
      return;
    do
    {
      UPackage* Pkg = (UPackage*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(LoadedPackages, num2);
      if (\u003CModule\u003E.CLRTools\u002EIsPackageValidForTree(Pkg) == 0U)
      {
        ObjectContainerNode package = this.UPackageToPackage(Pkg);
        if (package != null)
          mySources.RemovePackage(package);
      }
      ++num2;
    }
    while (num2 < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(LoadedPackages));
  }

  protected unsafe void UpdatePackagesTreeUI(
    ObjectContainerNode PackageItem,
    UPackage* UnrealPackage)
  {
    this.bPackageFilterUpdateRequested = true;
    if (PackageItem == null)
      return;
    if ((IntPtr) UnrealPackage != IntPtr.Zero)
    {
      PackageItem.Status = \u003CModule\u003E.UPackage\u002EIsFullyLoaded(\u003CModule\u003E.UObject\u002EGetOutermost((UObject*) UnrealPackage)) == 0U ? (ObjectContainerNode.PackageStatus) 1 : (ObjectContainerNode.PackageStatus) 2;
      if (((object) PackageItem).GetType() == typeof (Package))
        ((Package) PackageItem).IsModified = (IntPtr) \u003CModule\u003E.UObject\u002EGetOuter((UObject*) UnrealPackage) == IntPtr.Zero && \u003CModule\u003E.UPackage\u002EIsDirty(UnrealPackage) != 0U;
      MScopedNativePointer\u003CTArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E callbackEventPackages = this.CallbackEventPackages;
      if (callbackEventPackages.op_Implicit())
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ERemoveItem(callbackEventPackages.op_MemberSelection(), &UnrealPackage);
      if ((IntPtr) \u003CModule\u003E.UObject\u002EGetOuter((UObject*) UnrealPackage) != IntPtr.Zero)
        return;
      this.UpdatePackageSCCState(PackageItem, UnrealPackage);
    }
    else
    {
      FString fstring1;
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, ((SourceTreeNode) PackageItem).Name);
        uint num;
        // ISSUE: fault handler
        try
        {
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          num = __calli((__FnPtr<uint (IntPtr, char*, FGuid*, FString*, char*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 16L))((char*) \u003CModule\u003E.GPackageFileCache, (FString*) \u003CModule\u003E.FString\u002E\u002A(fstring3), (FGuid*) 0L, (char*) &fstring1, IntPtr.Zero);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
        if (num != 0U)
        {
          PackageItem.Status = (ObjectContainerNode.PackageStatus) 0;
          if (((object) PackageItem).GetType() == typeof (Package))
            ((Package) PackageItem).IsModified = false;
        }
        else if (!(PackageItem is GroupPackage))
          this.ContentBrowserCtrl.MySources.RemovePackage(PackageItem);
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

  protected unsafe void UpdatePackagesTreeUI(UPackage* UnrealPackage)
  {
    MContentBrowserControl mcontentBrowserControl = this;
    mcontentBrowserControl.UpdatePackagesTreeUI(mcontentBrowserControl.UPackageToPackage(UnrealPackage), UnrealPackage);
  }

  public virtual unsafe void UpdatePackagesTreeUI(ObjectContainerNode Pkg)
  {
    UPackage* UnrealPackage = (UPackage*) 0L;
    if (Pkg != null)
    {
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, Pkg.ObjectPathName);
      // ISSUE: fault handler
      try
      {
        UnrealPackage = \u003CModule\u003E.FindObject\u003Cclass\u0020UPackage\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    }
    this.UpdatePackagesTreeUI(Pkg, UnrealPackage);
  }

  public virtual void UpdatePackagesTreeUI()
  {
    List<ObjectContainerNode> objectContainerNodeList = new List<ObjectContainerNode>();
    this.ContentBrowserCtrl.MySources.GetChildNodes<ObjectContainerNode>((List<M0>) objectContainerNodeList);
    List<ObjectContainerNode>.Enumerator enumerator = objectContainerNodeList.GetEnumerator();
    if (!enumerator.MoveNext())
      return;
    do
    {
      this.UpdatePackagesTreeUI(enumerator.Current);
    }
    while (enumerator.MoveNext());
  }

  public void OnBecameSelectionAuthority()
  {
    this.SyncSelectedObjectsWithGlobalSelectionSet();
    this.ContentBrowserCtrl.AssetView.AssetCanvas.SetSelectionAppearsAuthoritative(true);
  }

  public void OnYieldSelectionAuthority() => this.ContentBrowserCtrl.AssetView.AssetCanvas.SetSelectionAppearsAuthoritative(false);

  [return: MarshalAs(UnmanagedType.U1)]
  protected bool IsCapableOfQuickUpdate() => this.CachedQueryAssetFullNameFNamesFromGAD.IsValid() && this.LastQueryAssetFullNameFNamesFromGAD.IsValid();

  protected void UpdatePackageSCCState(
    ObjectContainerNode PackageItem,
    ESourceControlState PackageSCCState)
  {
    if (PackageItem == null)
      return;
    switch (PackageSCCState)
    {
      case (ESourceControlState) 0:
        PackageItem.NodeIcon = (ObjectContainerNode.TreeNodeIconType) 0;
        break;
      case (ESourceControlState) 1:
        PackageItem.NodeIcon = (ObjectContainerNode.TreeNodeIconType) 1;
        break;
      case (ESourceControlState) 2:
        PackageItem.NodeIcon = (ObjectContainerNode.TreeNodeIconType) 2;
        break;
      case (ESourceControlState) 3:
        PackageItem.NodeIcon = (ObjectContainerNode.TreeNodeIconType) 3;
        break;
      case (ESourceControlState) 4:
        PackageItem.NodeIcon = (ObjectContainerNode.TreeNodeIconType) 4;
        break;
      case (ESourceControlState) 5:
        PackageItem.NodeIcon = (ObjectContainerNode.TreeNodeIconType) 5;
        break;
      default:
        PackageItem.NodeIcon = (ObjectContainerNode.TreeNodeIconType) 7;
        break;
    }
  }

  protected unsafe void UpdatePackageSCCState(
    ObjectContainerNode PackageItem,
    UPackage* UnrealPackage)
  {
    if (PackageItem == null)
      return;
    FString fstring1;
    FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, ((SourceTreeNode) PackageItem).Name);
    ESourceControlState PackageSCCState;
    // ISSUE: fault handler
    try
    {
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      PackageSCCState = (ESourceControlState) __calli((__FnPtr<int (IntPtr, char*)>) *(long*) (*(long*) \u003CModule\u003E.GPackageFileCache + 32L))((char*) \u003CModule\u003E.GPackageFileCache, (IntPtr) \u003CModule\u003E.FString\u002E\u002A(fstring2));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    this.UpdatePackageSCCState(PackageItem, PackageSCCState);
  }

  protected unsafe void UpdatePackageSCCState(
    TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E* UnrealPackages)
  {
    int num = 0;
    if (0 >= \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(UnrealPackages))
      return;
    do
    {
      UPackage* upackagePtr = (UPackage*) *(long*) \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(UnrealPackages, num);
      MContentBrowserControl mcontentBrowserControl = this;
      mcontentBrowserControl.UpdatePackageSCCState(mcontentBrowserControl.UPackageToPackage(upackagePtr), upackagePtr);
      ++num;
    }
    while (num < \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(UnrealPackages));
  }

  protected unsafe void UpdateCollectionsList()
  {
    List<string> OutTags = (List<string>) null;
    SourcesPanelModel mySources = this.ContentBrowserCtrl.MySources;
    \u003CModule\u003E.FGameAssetDatabase\u002EQueryAllTags(\u003CModule\u003E.\u003FGameAssetDatabaseSingleton\u0040FGameAssetDatabase\u0040\u00400PEAV1\u0040EA, out OutTags, (ETagQueryOptions.Type) 3);
    List<string> stringList1 = new List<string>();
    List<string> stringList2 = new List<string>();
    List<string> stringList3 = new List<string>();
    List<string>.Enumerator enumerator = OutTags.GetEnumerator();
    if (enumerator.MoveNext())
    {
      do
      {
        string current = enumerator.Current;
        if ((current.Length <= 0 || current[0] != '[' || \u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagType(current) != ESystemTagType.SharedCollection ? 0 : 1) != 0)
          stringList1.Add(\u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagValue(current));
        else if ((current.Length <= 0 || current[0] != '[' || \u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagType(current) != ESystemTagType.PrivateCollection ? 0 : 1) != 0)
        {
          if (\u003CModule\u003E.FGameAssetDatabase\u002EIsMyPrivateCollection(current))
            stringList2.Add(\u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagValue(current));
        }
        else if ((current.Length <= 0 || current[0] != '[' || \u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagType(current) != ESystemTagType.LocalCollection ? 0 : 1) != 0)
        {
          string systemTagValue = \u003CModule\u003E.FGameAssetDatabase\u002EGetSystemTagValue(current);
          stringList3.Add(systemTagValue);
          stringList2.Add(systemTagValue);
        }
      }
      while (enumerator.MoveNext());
    }
    mySources.SetCollectionNames((ICollection<string>) stringList1, (ICollection<string>) stringList2, (ICollection<string>) stringList3);
  }

  protected void UpdateCollectionsListUI()
  {
  }

  protected IntPtr MessageHookFunction(
    IntPtr HWnd,
    int Msg,
    IntPtr WParam,
    IntPtr LParam,
    ref bool OutHandled)
  {
    IntPtr num = (IntPtr) 0;
    OutHandled = false;
    switch (Msg)
    {
      case 61:
        OutHandled = true;
        num = (IntPtr) 0;
        break;
      case 135:
        OutHandled = true;
        num = new IntPtr(4);
        break;
    }
    return num;
  }

  protected unsafe void InitBrowsableObjectTypeList()
  {
    TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = (TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
    TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E* InNativePointer1;
    // ISSUE: fault handler
    try
    {
      InNativePointer1 = (IntPtr) fdefaultAllocatorPtr1 == IntPtr.Zero ? (TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr1);
    }
    __fault
    {
      \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr1);
    }
    this.BrowsableObjectTypeList.Reset(InNativePointer1);
    TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = (TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
    TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E* InNativePointer2;
    // ISSUE: fault handler
    try
    {
      InNativePointer2 = (IntPtr) fdefaultAllocatorPtr2 == IntPtr.Zero ? (TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr2);
    }
    __fault
    {
      \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr2);
    }
    this.SharedThumbnailClasses.Reset(InNativePointer2);
    TMap\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr1 = (TMap\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E*) \u003CModule\u003E.@new(72UL);
    TMap\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* InNativePointer3;
    // ISSUE: fault handler
    try
    {
      InNativePointer3 = (IntPtr) fdefaultSetAllocatorPtr1 == IntPtr.Zero ? (TMap\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E*) 0L : \u003CModule\u003E.TMap\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(fdefaultSetAllocatorPtr1);
    }
    __fault
    {
      \u003CModule\u003E.delete((void*) fdefaultSetAllocatorPtr1);
    }
    this.BrowsableObjectTypeToClassMap.Reset(InNativePointer3);
    TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr2 = (TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E*) \u003CModule\u003E.@new(72UL);
    TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* InNativePointer4;
    // ISSUE: fault handler
    try
    {
      InNativePointer4 = (IntPtr) fdefaultSetAllocatorPtr2 == IntPtr.Zero ? (TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E*) 0L : \u003CModule\u003E.TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(fdefaultSetAllocatorPtr2);
    }
    __fault
    {
      \u003CModule\u003E.delete((void*) fdefaultSetAllocatorPtr2);
    }
    this.ClassToBrowsableObjectTypeMap.Reset(InNativePointer4);
    \u003CModule\u003E.ObjectTools\u002ECreateBrowsableObjectTypeMaps(this.BrowsableObjectTypeList.Get(), this.BrowsableObjectTypeToClassMap.Get(), this.ClassToBrowsableObjectTypeMap.Get());
    UThumbnailManager* thumbnailManager = \u003CModule\u003E.UUnrealEdEngine\u002EGetThumbnailManager(\u003CModule\u003E.GUnrealEd);
    this.AssetTypeNames = new NameSet();
    TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TConstIterator tconstIterator1;
    \u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETConstIterator\u002E\u007Bctor\u007D(&tconstIterator1, (TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) this.BrowsableObjectTypeToClassMap.Get(), 0);
    if (\u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator1))
    {
      do
      {
        long num = *(long*) \u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002EKey((TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator1);
        TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr3 = \u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002EValue((TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator1);
        bool flag = (IntPtr) \u003CModule\u003E.ConstCast\u003Cclass\u0020UGenericBrowserType_Archetype\u003E((UObject*) num) != 0L;
        TIndexedContainerConstIterator\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
        \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, fdefaultAllocatorPtr3);
        if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
        {
          do
          {
            UClass* uclassPtr = (UClass*) *(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
            if (!flag)
            {
              FThumbnailRenderingInfo* renderingInfo = \u003CModule\u003E.UThumbnailManager\u002EGetRenderingInfo(thumbnailManager, \u003CModule\u003E.UClass\u002EGetDefaultObject(uclassPtr, 0U));
              if ((*(int*) ((IntPtr) uclassPtr + 292L) & 1) == 0 && ((IntPtr) renderingInfo == IntPtr.Zero || \u003CModule\u003E.UObject\u002EGetClass((UObject*) *(long*) ((IntPtr) renderingInfo + 40L)) == \u003CModule\u003E.UIconThumbnailRenderer\u002EStaticClass()))
                \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(this.SharedThumbnailClasses.op_MemberSelection(), &uclassPtr);
              FString fstring;
              FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) uclassPtr, &fstring);
              // ISSUE: fault handler
              try
              {
                this.AssetTypeNames.Add(new string(\u003CModule\u003E.FString\u002E\u002A(name), 0, \u003CModule\u003E.FString\u002ELen(name)));
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
            }
            \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
          }
          while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
        }
        \u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002B\u002B((TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator1);
      }
      while (\u003CModule\u003E.TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TMapBase\u003CUGenericBrowserType\u0020\u002A\u002CTArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator1));
    }
    this.ClassNameToBrowsableTypeNameMap = new Dictionary<string, List<string>>();
    this.ClassNameToBorderColorMap = new Dictionary<string, Color>();
    TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TConstIterator tconstIterator2;
    \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETConstIterator\u002E\u007Bctor\u007D(&tconstIterator2, (TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) this.ClassToBrowsableObjectTypeMap.Get(), 0);
    if (!\u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator2))
      return;
    do
    {
      long num = *(long*) \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002EKey((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator2);
      TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr3 = \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002EValue((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator2);
      FString fstring1;
      ref FString local = ref fstring1;
      FString* name = \u003CModule\u003E.UObject\u002EGetName((UObject*) num, (FString*) ref local);
      string str1;
      // ISSUE: fault handler
      try
      {
        str1 = new string(\u003CModule\u003E.FString\u002E\u002A(name), 0, \u003CModule\u003E.FString\u002ELen(name));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      List<string> stringList = new List<string>(\u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr3));
      TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, fdefaultAllocatorPtr3);
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          if ((IntPtr) \u003CModule\u003E.Cast\u003Cclass\u0020UGenericBrowserType_Archetype\u003E((UObject*) *(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt)) == IntPtr.Zero)
          {
            FString* browserTypeDescription = \u003CModule\u003E.UGenericBrowserType\u002EGetBrowserTypeDescription((UGenericBrowserType*) *(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt));
            string str2 = new string(\u003CModule\u003E.FString\u002E\u002A(browserTypeDescription), 0, \u003CModule\u003E.FString\u002ELen(browserTypeDescription));
            stringList.Add(str2);
          }
          if (!this.ClassNameToBorderColorMap.ContainsKey(str1))
          {
            UGenericBrowserType** ugenericBrowserTypePtr = \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
            FColor fcolor;
            // ISSUE: cpblk instruction
            __memcpy(ref fcolor, (IntPtr) \u003CModule\u003E.TArray\u003CFGenericBrowserTypeInfo\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFGenericBrowserTypeInfo\u002CFDefaultAllocator\u003E*) (*(long*) ugenericBrowserTypePtr + 112L), 0) + 8L, 4);
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            Color color = Color.FromArgb((byte) 200, (byte) (((uint) ^(byte&) ((IntPtr) &fcolor + 2) >> 1) + (uint) sbyte.MaxValue), (byte) (((uint) ^(byte&) ((IntPtr) &fcolor + 1) >> 1) + (uint) sbyte.MaxValue), (byte) (((uint) ^(byte&) ref fcolor >> 1) + (uint) sbyte.MaxValue));
            this.ClassNameToBorderColorMap.Add(str1, color);
          }
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
      }
      if (this.ClassNameToBrowsableTypeNameMap.ContainsKey(str1))
      {
        FString fstring2;
        FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, str1);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.FOutputDevice\u002ELogf\u003Cwchar_t\u0020const\u0020\u002A\u003E((FOutputDevice*) \u003CModule\u003E.GLog, (EName) 767, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D39, \u003CModule\u003E.FString\u002E\u002A(fstring3));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
      }
      else
        this.ClassNameToBrowsableTypeNameMap.Add(str1, stringList);
      \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002B\u002B((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator2);
    }
    while (\u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator2));
  }

  protected unsafe void InitFactoryClassList()
  {
    TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = (TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
    TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E* InNativePointer;
    // ISSUE: fault handler
    try
    {
      InNativePointer = (IntPtr) fdefaultAllocatorPtr1 == IntPtr.Zero ? (TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr1);
    }
    __fault
    {
      \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr1);
    }
    this.ObjectFactoryClasses.Reset(InNativePointer);
    TObjectIterator\u003CUClass\u003E tobjectIteratorUclass;
    \u003CModule\u003E.TObjectIterator\u003CUClass\u003E\u002E\u007Bctor\u007D(&tobjectIteratorUclass, 0U);
    if (\u003CModule\u003E.FObjectIterator\u002E\u002E_N((FObjectIterator*) &tobjectIteratorUclass))
    {
      do
      {
        UClass* uclassPtr = \u003CModule\u003E.TObjectIterator\u003CUClass\u003E\u002E\u002A(&tobjectIteratorUclass);
        if (\u003CModule\u003E.UStruct\u002EIsChildOf((UStruct*) uclassPtr, (UStruct*) \u003CModule\u003E.UFactory\u002EStaticClass()) != 0U && \u003CModule\u003E.UClass\u002EHasAnyClassFlags(uclassPtr, 1U) == 0U)
        {
          UFactory* ufactoryPtr = \u003CModule\u003E.Cast\u003Cclass\u0020UFactory\u003E(\u003CModule\u003E.UClass\u002EGetDefaultObject(uclassPtr, 0U));
          if ((*(int*) ((IntPtr) ufactoryPtr + 144L) & 1) != 0 && \u003CModule\u003E.UFactory\u002EValidForCurrentGame(ufactoryPtr) != 0U)
            \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(this.ObjectFactoryClasses.op_MemberSelection(), &uclassPtr);
        }
        \u003CModule\u003E.FObjectIterator\u002E\u002B\u002B((FObjectIterator*) &tobjectIteratorUclass);
      }
      while (\u003CModule\u003E.FObjectIterator\u002E\u002E_N((FObjectIterator*) &tobjectIteratorUclass));
    }
    TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = this.ObjectFactoryClasses.Get();
    \u003CModule\u003E.Sort\u003Cclass\u0020UClass\u0020\u002A\u002Cclass\u0020CompareContentBrowserCLRUClassPointer\u003E(\u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr2, 0), \u003CModule\u003E.TArray\u003CUClass\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr2));
  }

  protected unsafe void InitRecentObjectsList()
  {
    if (MContentBrowserControl.RecentItemsInitialized)
      return;
    this.ContentBrowserCtrl.InitRecentItems(30);
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FConfigCacheIni\u002EGetSingleLineArray(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D41, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D40, &fdefaultAllocator, (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
      TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, &fdefaultAllocator);
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          FString* fstringPtr = \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
          this.ContentBrowserCtrl.AddRecentItem(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr)));
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
      }
      MContentBrowserControl.RecentItemsInitialized = true;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  protected unsafe void OpenObjectEditorForSelectedObjects()
  {
    IEnumerator enumerator = ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems.GetEnumerator();
label_1:
    try
    {
      while (enumerator.MoveNext())
      {
        AssetItem current = (AssetItem) enumerator.Current;
        UObject* uobjectPtr1 = (UObject*) 0L;
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, current.AssetType);
        UClass* objectClassUclass;
        // ISSUE: fault handler
        try
        {
          objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
        if ((IntPtr) objectClassUclass != IntPtr.Zero)
        {
          FString fstring3;
          FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, current.FullyQualifiedPath);
          // ISSUE: fault handler
          try
          {
            uobjectPtr1 = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
          if ((IntPtr) uobjectPtr1 != IntPtr.Zero)
          {
            TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) this.ClassToBrowsableObjectTypeMap.op_MemberSelection(), \u003CModule\u003E.UObject\u002EGetClass(uobjectPtr1));
            if ((IntPtr) fdefaultAllocatorPtr != IntPtr.Zero)
            {
              int num = 0;
              while (true)
              {
                if (num < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr))
                {
                  UGenericBrowserType* ugenericBrowserTypePtr1 = (UGenericBrowserType*) *(long*) \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr, num);
                  if (\u003CModule\u003E.UGenericBrowserType\u002ESupports(ugenericBrowserTypePtr1, uobjectPtr1) != 0U)
                  {
                    UGenericBrowserType* ugenericBrowserTypePtr2 = ugenericBrowserTypePtr1;
                    UObject* uobjectPtr2 = uobjectPtr1;
                    // ISSUE: cast to a function pointer type
                    // ISSUE: function pointer call
                    if (__calli((__FnPtr<uint (IntPtr, UObject*)>) *(long*) (*(long*) ugenericBrowserTypePtr1 + 640L))((UObject*) ugenericBrowserTypePtr2, (IntPtr) uobjectPtr2) != 0U)
                      goto label_1;
                  }
                  ++num;
                }
                else
                  goto label_1;
              }
            }
          }
        }
      }
    }
    finally
    {
      if (enumerator is IDisposable disposable2)
        disposable2.Dispose();
    }
  }

  protected unsafe void OpenPropertiesForSelectedObjects()
  {
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      this.GetSelectedObjects(&fdefaultAllocator);
      if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator) > 0)
      {
        WxPropertyWindowFrame* propertyWindowFramePtr1 = (WxPropertyWindowFrame*) \u003CModule\u003E.@new(728UL);
        WxPropertyWindowFrame* propertyWindowFramePtr2;
        // ISSUE: fault handler
        try
        {
          propertyWindowFramePtr2 = (IntPtr) propertyWindowFramePtr1 == IntPtr.Zero ? (WxPropertyWindowFrame*) 0L : \u003CModule\u003E.WxPropertyWindowFrame\u002E\u007Bctor\u007D(propertyWindowFramePtr1);
        }
        __fault
        {
          \u003CModule\u003E.delete((void*) propertyWindowFramePtr1);
        }
        UUnrealEdEngine* uunrealEdEnginePtr1 = (IntPtr) \u003CModule\u003E.GUnrealEd == IntPtr.Zero ? (UUnrealEdEngine*) 0L : (UUnrealEdEngine*) ((IntPtr) \u003CModule\u003E.GUnrealEd + 3128L);
        WxPropertyWindowFrame* propertyWindowFramePtr3 = propertyWindowFramePtr2;
        long num1 = *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L);
        UUnrealEdEngine* uunrealEdEnginePtr2 = uunrealEdEnginePtr1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, wxWindow*, int, FNotifyHook*)>) *(long*) (*(long*) propertyWindowFramePtr2 + 1712L))((FNotifyHook*) propertyWindowFramePtr3, (int) num1, (wxWindow*) -1, (IntPtr) uunrealEdEnginePtr2);
        \u003CModule\u003E.WxPropertyWindowFrame\u002EAllowClose(propertyWindowFramePtr2);
        \u003CModule\u003E.WxPropertyWindowFrame\u002ESetObjectArray\u003Cclass\u0020UObject\u003E(propertyWindowFramePtr2, &fdefaultAllocator, 9U);
        WxPropertyWindowFrame* propertyWindowFramePtr4 = propertyWindowFramePtr2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        int num2 = (int) __calli((__FnPtr<byte (IntPtr, byte)>) *(long*) (*(long*) propertyWindowFramePtr2 + 304L))((byte) propertyWindowFramePtr4, new IntPtr(1));
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  protected unsafe void GetSelectedObjects(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* OutObjects)
  {
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EReset(OutObjects, 0);
    foreach (AssetItem selectedItem in (IEnumerable) ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems)
    {
      UObject* uobjectPtr = (UObject*) 0L;
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, selectedItem.AssetType);
      UClass* objectClassUclass;
      // ISSUE: fault handler
      try
      {
        objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      if ((IntPtr) objectClassUclass != IntPtr.Zero)
      {
        FString fstring3;
        FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, selectedItem.FullyQualifiedPath);
        // ISSUE: fault handler
        try
        {
          uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      }
      if ((IntPtr) uobjectPtr != IntPtr.Zero)
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(OutObjects, &uobjectPtr);
    }
  }

  protected unsafe int DetermineDefaultCommand(
    int InProposedDefaultCommand,
    TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E* SupportedCommands)
  {
    int num1 = InProposedDefaultCommand;
    if (InProposedDefaultCommand == -1)
    {
      int num2 = 0;
      while (num2 < \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002ENum(SupportedCommands))
      {
        num1 = *(int*) \u003CModule\u003E.TArray\u003CFObjectSupportedCommandType\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(SupportedCommands, num2) == 21708 ? 21708 : num1;
        ++num2;
        if (num1 != -1)
          goto label_5;
      }
      num1 = num1 == -1 ? 11274 : num1;
    }
label_5:
    return num1;
  }

  protected void OnCustomObjectCommand(object Sender, ExecutedRoutedEventArgs EventArgs)
  {
    EventArgs.Handled = true;
    this.ExecuteCustomObjectCommand((int) EventArgs.Parameter);
  }

  protected unsafe void ExecuteCustomObjectCommand(int InCommandId)
  {
    string str = (string) null;
    uint num1 = 0;
    this.LoadSelectedObjectsIfNeeded();
    switch (InCommandId)
    {
      case 11273:
        this.ContentBrowserCtrl.AssetView.CopySelectedAssets();
        break;
      case 11274:
        this.OpenPropertiesForSelectedObjects();
        break;
      case 11277:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator1);
          \u003CModule\u003E.UPropertyWindowManager\u002EClearAllThatContainObjects(\u003CModule\u003E.GPropertyWindowManager, &fdefaultAllocator1);
          \u003CModule\u003E.ObjectTools\u002EDeleteObjects(&fdefaultAllocator1, this.BrowsableObjectTypeList.Get());
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
        break;
      case 11278:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator2;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator2);
          \u003CModule\u003E.ObjectTools\u002EShowReferencers(&fdefaultAllocator2);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
        break;
      case 11279:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator3;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator3);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator3);
          if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator3) != 0)
          {
            UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator3, 0);
            \u003CModule\u003E.USelection\u002EDeselect(\u003CModule\u003E.UEditorEngine\u002EGetSelectedObjects(\u003CModule\u003E.GEditor), uobjectPtr);
            \u003CModule\u003E.ObjectTools\u002EShowReferenceGraph(uobjectPtr, this.ClassToBrowsableObjectTypeMap.Get());
            \u003CModule\u003E.USelection\u002ESelect(\u003CModule\u003E.UEditorEngine\u002EGetSelectedObjects(\u003CModule\u003E.GEditor), uobjectPtr);
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
        break;
      case 11280:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator4;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator4);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator4);
          FString fstring;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring, this.LastExportPath);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.ObjectTools\u002EExportObjects(&fdefaultAllocator4, 1U, &fstring, 0U);
            this.LastExportPath = \u003CModule\u003E.CLRTools\u002EToString(&fstring);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator4);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator4);
        break;
      case 11281:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator5;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator5);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator5);
          FString fstring;
          \u003CModule\u003E.CLRTools\u002EToFString(&fstring, this.LastExportPath);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.ObjectTools\u002EExportObjects(&fdefaultAllocator5, 0U, &fstring, 0U);
            this.LastExportPath = \u003CModule\u003E.CLRTools\u002EToString(&fstring);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator5);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator5);
        break;
      case 11285:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator6;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator6);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator6);
          \u003CModule\u003E.ObjectTools\u002EDuplicateWithRefs(&fdefaultAllocator6, this.ClassToBrowsableObjectTypeMap.Get(), (TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator6);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator6);
        break;
      case 11286:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator7;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator7);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator7);
          int num2 = (int) \u003CModule\u003E.ObjectTools\u002ERenameObjectsWithRefs(&fdefaultAllocator7, 0U, this.ClassToBrowsableObjectTypeMap.Get());
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator7);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator7);
        break;
      case 11287:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator8;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator8);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator8);
          int num2 = (int) \u003CModule\u003E.ObjectTools\u002ERenameObjectsWithRefs(&fdefaultAllocator8, 1U, this.ClassToBrowsableObjectTypeMap.Get());
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator8);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator8);
        break;
      case 11288:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator9;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator9);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator9);
          \u003CModule\u003E.ObjectTools\u002EForceDeleteObjects(&fdefaultAllocator9, this.BrowsableObjectTypeList.Get());
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator9);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator9);
        break;
      case 11289:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator10;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator10);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator10);
          \u003CModule\u003E.FConsolidateWindow\u002EAddConsolidationObjects(&fdefaultAllocator10, this.BrowsableObjectTypeList.Get());
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator10);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator10);
        break;
      case 11290:
      case 11291:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator11;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator11);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator11);
          if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator11) == 1)
          {
            uint num2 = (uint) (InCommandId == 11291);
            \u003CModule\u003E.ObjectTools\u002EShowReferencedObjs((UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator11, 0), num2);
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator11);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator11);
        break;
      case 11292:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator12;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator12);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator12);
          if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator12) == 1)
            \u003CModule\u003E.ObjectTools\u002ESelectObjectAndExternalReferencersInLevel((UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator12, 0));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator12);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator12);
        break;
      case 11293:
        FViewport* InViewport = (FViewport*) *(long*) ((IntPtr) \u003CModule\u003E.GCurrentLevelEditingViewportClient + 32L);
        FEditorLevelViewportClient* editingViewportClient = \u003CModule\u003E.GCurrentLevelEditingViewportClient;
        \u003CModule\u003E.GCurrentLevelEditingViewportClient = (FEditorLevelViewportClient*) 0L;
        \u003CModule\u003E.FViewport\u002EDraw(InViewport, 1U);
        List<AssetItem> InAssetsToAssign = this.ContentBrowserCtrl.AssetView.AssetListView.CloneSelection();
        this.CaptureThumbnailFromViewport(InViewport, InAssetsToAssign);
        \u003CModule\u003E.GCurrentLevelEditingViewportClient = editingViewportClient;
        \u003CModule\u003E.FViewport\u002EDraw(InViewport, 1U);
        break;
      case 11294:
        long num3 = *(long*) ((IntPtr) \u003CModule\u003E.GEditor + 1732L);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        this.CaptureThumbnailFromViewport(__calli((__FnPtr<FViewport* (IntPtr)>) *(long*) (*(long*) num3 + 672L))((IntPtr) num3), this.ContentBrowserCtrl.AssetView.AssetListView.CloneSelection());
        break;
      case 11295:
        this.ClearCustomThumbnails(this.ContentBrowserCtrl.AssetView.AssetListView.CloneSelection());
        break;
      case 11296:
        this.FilterSelectedObjectTypes(this.ContentBrowserCtrl.AssetView.AssetListView.CloneSelection());
        break;
      case 11297:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator13;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator13);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator13);
          if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator13) == 1)
          {
            UObject* uobjectPtr1 = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator13, 0);
            if ((IntPtr) uobjectPtr1 != IntPtr.Zero)
            {
              UClass* uclassPtr = \u003CModule\u003E.UObject\u002EGetClass(uobjectPtr1);
              if ((IntPtr) uclassPtr != IntPtr.Zero)
              {
                uint num2 = (uint) *(int*) ((IntPtr) uclassPtr + 292L);
                if (((int) num2 & 33554432) == 0)
                {
                  if (((int) num2 & 1) == 0)
                  {
                    if (\u003CModule\u003E.UStruct\u002EIsChildOf((UStruct*) uclassPtr, (UStruct*) \u003CModule\u003E.UUIRoot\u002EStaticClass()) == 0U)
                    {
                      FString fstring1;
                      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
                      // ISSUE: fault handler
                      try
                      {
                        FString fstring2;
                        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2);
                        // ISSUE: fault handler
                        try
                        {
                          FString fstring3;
                          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3);
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.USelection\u002EDeselect(\u003CModule\u003E.UEditorEngine\u002EGetSelectedObjects(\u003CModule\u003E.GEditor), uobjectPtr1);
                            if (\u003CModule\u003E.UStruct\u002EIsChildOf((UStruct*) uclassPtr, (UStruct*) \u003CModule\u003E.AActor\u002EStaticClass()) != 0U)
                            {
                              AActor* aactorPtr1 = \u003CModule\u003E.UObject\u002EHasAnyFlags(uobjectPtr1, 1024UL) == 0U ? (AActor*) 0L : \u003CModule\u003E.CastChecked\u003Cclass\u0020AActor\u002Cclass\u0020UObject\u003E(uobjectPtr1);
                              FName fname;
                              FVector fvector;
                              FRotator frotator;
                              AActor* aactorPtr2 = \u003CModule\u003E.UWorld\u002ESpawnActor(\u003CModule\u003E.GWorld, uclassPtr, *\u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (EName) 0), \u003CModule\u003E.FVector\u002E\u007Bctor\u007D(&fvector, 0.0f, 0.0f, 0.0f), \u003CModule\u003E.FRotator\u002E\u007Bctor\u007D(&frotator, 0, 0, 0), aactorPtr1, 1U, 0U, (AActor*) 0L, (APawn*) 0L, 0U, (ULevel*) 0L);
                              if ((IntPtr) aactorPtr2 != IntPtr.Zero)
                              {
                                UPackage* outermost = \u003CModule\u003E.UObject\u002EGetOutermost(uobjectPtr1);
                                FString fstring4;
                                FString* fstringPtr1;
                                FString fstring5;
                                if ((IntPtr) outermost != IntPtr.Zero)
                                {
                                  fstringPtr1 = \u003CModule\u003E.UObject\u002EGetName((UObject*) outermost, &fstring4);
                                  // ISSUE: fault handler
                                  try
                                  {
                                    num1 = 1U;
                                  }
                                  __fault
                                  {
                                    if (((int) num1 & 1) != 0)
                                    {
                                      num1 &= 4294967294U;
                                      // ISSUE: method pointer
                                      // ISSUE: cast to a function pointer type
                                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                                    }
                                  }
                                }
                                else
                                {
                                  fstringPtr1 = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring5, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
                                  // ISSUE: fault handler
                                  try
                                  {
                                    // ISSUE: fault handler
                                    try
                                    {
                                      num1 = 2U;
                                    }
                                    __fault
                                    {
                                      if (((int) num1 & 2) != 0)
                                      {
                                        num1 &= 4294967293U;
                                        // ISSUE: method pointer
                                        // ISSUE: cast to a function pointer type
                                        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
                                      }
                                    }
                                  }
                                  __fault
                                  {
                                    if (((int) num1 & 1) != 0)
                                    {
                                      num1 &= 4294967294U;
                                      // ISSUE: method pointer
                                      // ISSUE: cast to a function pointer type
                                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                                    }
                                  }
                                }
                                // ISSUE: fault handler
                                try
                                {
                                  // ISSUE: fault handler
                                  try
                                  {
                                    \u003CModule\u003E.FString\u002E\u003D(&fstring2, fstringPtr1);
                                  }
                                  __fault
                                  {
                                    if (((int) num1 & 2) != 0)
                                    {
                                      num1 &= 4294967293U;
                                      // ISSUE: method pointer
                                      // ISSUE: cast to a function pointer type
                                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
                                    }
                                  }
                                  if (((int) num1 & 2) != 0)
                                  {
                                    num1 &= 4294967293U;
                                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
                                  }
                                }
                                __fault
                                {
                                  if (((int) num1 & 1) != 0)
                                  {
                                    num1 &= 4294967294U;
                                    // ISSUE: method pointer
                                    // ISSUE: cast to a function pointer type
                                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                                  }
                                }
                                if (((int) num1 & 1) != 0)
                                {
                                  num1 &= 4294967294U;
                                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
                                }
                                UPackage* upackagePtr = \u003CModule\u003E.Cast\u003Cclass\u0020UPackage\u003E(\u003CModule\u003E.UObject\u002EGetOuter(uobjectPtr1));
                                FString fstring6;
                                FString* fstringPtr2;
                                FString fstring7;
                                if ((IntPtr) upackagePtr != IntPtr.Zero)
                                {
                                  fstringPtr2 = \u003CModule\u003E.UObject\u002EGetFullGroupName((UObject*) upackagePtr, &fstring6, 0U);
                                  // ISSUE: fault handler
                                  try
                                  {
                                    num1 |= 4U;
                                  }
                                  __fault
                                  {
                                    if (((int) num1 & 4) != 0)
                                    {
                                      num1 &= 4294967291U;
                                      // ISSUE: method pointer
                                      // ISSUE: cast to a function pointer type
                                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
                                    }
                                  }
                                }
                                else
                                {
                                  fstringPtr2 = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring7, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
                                  // ISSUE: fault handler
                                  try
                                  {
                                    // ISSUE: fault handler
                                    try
                                    {
                                      num1 |= 8U;
                                    }
                                    __fault
                                    {
                                      if (((int) num1 & 8) != 0)
                                      {
                                        num1 &= 4294967287U;
                                        // ISSUE: method pointer
                                        // ISSUE: cast to a function pointer type
                                        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring7);
                                      }
                                    }
                                  }
                                  __fault
                                  {
                                    if (((int) num1 & 4) != 0)
                                    {
                                      num1 &= 4294967291U;
                                      // ISSUE: method pointer
                                      // ISSUE: cast to a function pointer type
                                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
                                    }
                                  }
                                }
                                // ISSUE: fault handler
                                try
                                {
                                  // ISSUE: fault handler
                                  try
                                  {
                                    \u003CModule\u003E.FString\u002E\u003D(&fstring3, fstringPtr2);
                                  }
                                  __fault
                                  {
                                    if (((int) num1 & 8) != 0)
                                    {
                                      num1 &= 4294967287U;
                                      // ISSUE: method pointer
                                      // ISSUE: cast to a function pointer type
                                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring7);
                                    }
                                  }
                                  if (((int) num1 & 8) != 0)
                                  {
                                    num1 &= 4294967287U;
                                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring7);
                                  }
                                }
                                __fault
                                {
                                  if (((int) num1 & 4) != 0)
                                  {
                                    num1 &= 4294967291U;
                                    // ISSUE: method pointer
                                    // ISSUE: cast to a function pointer type
                                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
                                  }
                                }
                                if (((int) num1 & 4) != 0)
                                {
                                  uint num4 = num1 & 4294967291U;
                                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
                                }
                                UUnrealEdEngine* gunrealEd = \u003CModule\u003E.GUnrealEd;
                                AActor* aactorPtr3 = aactorPtr2;
                                ref FString local1 = ref fstring1;
                                ref FString local2 = ref fstring2;
                                ref FString local3 = ref fstring3;
                                // ISSUE: cast to a function pointer type
                                // ISSUE: function pointer call
                                UObject* uobjectPtr2 = __calli((__FnPtr<UObject* (IntPtr, UObject*, FString*, FString*, FString*)>) *(long*) (*(long*) \u003CModule\u003E.GUnrealEd + 1856L))((FString*) gunrealEd, (FString*) aactorPtr3, (FString*) ref local1, (UObject*) ref local2, (IntPtr) ref local3);
                                int num5 = (int) \u003CModule\u003E.UWorld\u002EEditorDestroyActor(\u003CModule\u003E.GWorld, aactorPtr2, 0U);
                              }
                            }
                            else
                            {
                              UObject* uobjectPtr2 = \u003CModule\u003E.UObject\u002EHasAnyFlags(uobjectPtr1, 1024UL) != 0U ? (UObject*) (ValueType) (IntPtr) uobjectPtr1 : (UObject*) (ValueType) 0L;
                              FName fname;
                              UObject* uobjectPtr3 = \u003CModule\u003E.UObject\u002EStaticConstructObject(uclassPtr, (UObject*) \u003CModule\u003E.UObject\u002EGetTransientPackage(), *\u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (EName) 0), 0UL, uobjectPtr2, (FOutputDevice*) \u003CModule\u003E.GError, (UObject*) 0L, (FObjectInstancingGraph*) 0L);
                              UUnrealEdEngine* gunrealEd = \u003CModule\u003E.GUnrealEd;
                              UObject* uobjectPtr4 = uobjectPtr3;
                              ref FString local1 = ref fstring1;
                              ref FString local2 = ref fstring2;
                              ref FString local3 = ref fstring3;
                              // ISSUE: cast to a function pointer type
                              // ISSUE: function pointer call
                              UObject* uobjectPtr5 = __calli((__FnPtr<UObject* (IntPtr, UObject*, FString*, FString*, FString*)>) *(long*) (*(long*) \u003CModule\u003E.GUnrealEd + 1856L))((FString*) gunrealEd, (FString*) uobjectPtr4, (FString*) ref local1, (UObject*) ref local2, (IntPtr) ref local3);
                            }
                            \u003CModule\u003E.USelection\u002ESelect(\u003CModule\u003E.UEditorEngine\u002EGetSelectedObjects(\u003CModule\u003E.GEditor), uobjectPtr1);
                            \u003CModule\u003E.UObject\u002ECollectGarbage(\u003CModule\u003E.GIsEditor != 0U ? 290482175965396992UL : 288230376151711744UL, 1U);
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
                  }
                }
              }
            }
          }
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator13);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator13);
        break;
      case 21708:
        this.OpenObjectEditorForSelectedObjects();
        break;
      case 23110:
        TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator14;
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator14);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedPackages(&fdefaultAllocator14, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) 0L, 1U);
          \u003CModule\u003E.WxSoundCueEditor\u002EBatchProcessClusterSounds(&fdefaultAllocator14, 0U);
          FCallbackEventParameters fcallbackEventParameters;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) \u003CModule\u003E.GCallbackEvent, (IntPtr) \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters, (FCallbackEventDevice*) 0L, (ECallbackEventType) 23, 145U));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator14);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator14);
        break;
      case 23111:
        TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator15;
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator15);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedPackages(&fdefaultAllocator15, (TArray\u003CFString\u002CFDefaultAllocator\u003E*) 0L, 1U);
          \u003CModule\u003E.WxSoundCueEditor\u002EBatchProcessClusterSounds(&fdefaultAllocator15, 1U);
          FCallbackEventParameters fcallbackEventParameters;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) \u003CModule\u003E.GCallbackEvent, (IntPtr) \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters, (FCallbackEventDevice*) 0L, (ECallbackEventType) 23, 145U));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator15);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator15);
        break;
      case 23112:
        TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator16;
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator16);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedPackages(&fdefaultAllocator16);
          \u003CModule\u003E.WxSoundCueEditor\u002EBatchProcessInsertRadioChirp(&fdefaultAllocator16);
          FCallbackEventParameters fcallbackEventParameters;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) \u003CModule\u003E.GCallbackEvent, (IntPtr) \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters, (FCallbackEventDevice*) 0L, (ECallbackEventType) 23, 68U));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator16);
        }
        \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator16);
        break;
      case 23113:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator17;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator17);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator17);
          \u003CModule\u003E.WxSoundCueEditor\u002EBatchProcessInsertRadioChirp(&fdefaultAllocator17);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator17);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator17);
        break;
      case 23114:
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator18;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator18);
        // ISSUE: fault handler
        try
        {
          this.GetSelectedObjects(&fdefaultAllocator18);
          \u003CModule\u003E.WxSoundCueEditor\u002EBatchProcessInsertMatureNode(&fdefaultAllocator18);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator18);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator18);
        break;
      default:
        if ((uint) (InCommandId - 21751) <= 998U && !this.ContentBrowserCtrl.AssetView.IsContextMenuOpen)
        {
          TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator19;
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator19);
          // ISSUE: fault handler
          try
          {
            this.GetSelectedPackages(&fdefaultAllocator19);
            \u003CModule\u003E.WxSoundCueEditor\u002EBatchProcessSoundClass(&fdefaultAllocator19, InCommandId);
            FCallbackEventParameters fcallbackEventParameters;
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) \u003CModule\u003E.GCallbackEvent, (IntPtr) \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters, (FCallbackEventDevice*) 0L, (ECallbackEventType) 23, 68U));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator19);
          }
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator19);
          break;
        }
        List<AssetItem> assetItemList = this.ContentBrowserCtrl.AssetView.AssetListView.CloneSelection();
        AssetItem.SortByAssetType(assetItemList);
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator20;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator20);
        // ISSUE: fault handler
        try
        {
          List<AssetItem>.Enumerator enumerator = assetItemList.GetEnumerator();
          if (enumerator.MoveNext())
          {
            do
            {
              AssetItem current = enumerator.Current;
              if (str != current.AssetType)
              {
                TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator19;
                TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = &fdefaultAllocator19;
                TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* SelectedObjectsWithSameType = \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator19, &fdefaultAllocator20);
                this.InvokeCustomCommandOnArray(InCommandId, SelectedObjectsWithSameType);
                \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(&fdefaultAllocator20, 0);
              }
              str = current.AssetType;
              UObject* uobjectPtr = (UObject*) 0L;
              FString fstring1;
              FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, current.AssetType);
              UClass* objectClassUclass;
              // ISSUE: fault handler
              try
              {
                objectClassUclass = \u003CModule\u003E.FindObject\u003Cclass\u0020UClass\u003E((UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring2), 0U);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
              if ((IntPtr) objectClassUclass != IntPtr.Zero)
              {
                FString fstring3;
                FString* fstring4 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring3, current.FullyQualifiedPath);
                // ISSUE: fault handler
                try
                {
                  uobjectPtr = \u003CModule\u003E.UObject\u002EStaticFindObject(objectClassUclass, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A(fstring4), 0U);
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
              }
              \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator20, &uobjectPtr);
            }
            while (enumerator.MoveNext());
          }
          TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator21;
          TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = &fdefaultAllocator21;
          TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* SelectedObjectsWithSameType1 = \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator21, &fdefaultAllocator20);
          this.InvokeCustomCommandOnArray(InCommandId, SelectedObjectsWithSameType1);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator20);
        }
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator20);
        break;
    }
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator22;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator22);
    // ISSUE: fault handler
    try
    {
      this.GetSelectedObjects(&fdefaultAllocator22);
      TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, &fdefaultAllocator22);
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
          FString fstring1;
          \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
          // ISSUE: fault handler
          try
          {
            FString fstring2;
            FString* pathName = \u003CModule\u003E.UObject\u002EGetPathName(uobjectPtr, &fstring2, (UObject*) 0L);
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.FString\u002E\u003D(&fstring1, pathName);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
            this.ContentBrowserCtrl.AddRecentItem(new string(\u003CModule\u003E.FString\u002E\u002A(&fstring1), 0, \u003CModule\u003E.FString\u002ELen(&fstring1)));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
      }
      this.WriteRecentObjectsToConfig();
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator22);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator22);
  }

  protected unsafe void InvokeCustomCommandOnArray(
    int CommandID,
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* SelectedObjectsWithSameType)
  {
    // ISSUE: fault handler
    try
    {
      if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(SelectedObjectsWithSameType) != 0)
      {
        UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(SelectedObjectsWithSameType, 0);
        TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) this.ClassToBrowsableObjectTypeMap.op_MemberSelection(), \u003CModule\u003E.UObject\u002EGetClass(uobjectPtr));
        if ((IntPtr) fdefaultAllocatorPtr1 != IntPtr.Zero)
        {
          int num1 = 0;
          if (0 < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr1))
          {
            do
            {
              UGenericBrowserType* ugenericBrowserTypePtr1 = (UGenericBrowserType*) *(long*) \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr1, num1);
              if (\u003CModule\u003E.UGenericBrowserType\u002ESupports(ugenericBrowserTypePtr1, uobjectPtr) != 0U)
              {
                UGenericBrowserType* ugenericBrowserTypePtr2 = ugenericBrowserTypePtr1;
                int num2 = CommandID;
                TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = SelectedObjectsWithSameType;
                // ISSUE: cast to a function pointer type
                // ISSUE: function pointer call
                __calli((__FnPtr<void (IntPtr, int, TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*)>) *(long*) (*(long*) ugenericBrowserTypePtr1 + 680L))((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ugenericBrowserTypePtr2, num2, (IntPtr) fdefaultAllocatorPtr2);
              }
              ++num1;
            }
            while (num1 < \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr1));
          }
        }
      }
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) SelectedObjectsWithSameType);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(SelectedObjectsWithSameType);
  }

  protected void CanExecuteCustomObjectCommand(object Sender, CanExecuteRoutedEventArgs EventArgs)
  {
    EventArgs.Handled = true;
    int parameter = (int) EventArgs.Parameter;
    EventArgs.CanExecute = false;
    if (!((UIElement) this.ContentBrowserCtrl).IsEnabled)
      return;
    if ((parameter < 21750 || parameter >= 22750) && (parameter != 23110 && parameter != 23111) && (parameter != 23112 && parameter != 22904))
    {
      IEnumerator enumerator = ((ListBox) this.ContentBrowserCtrl.AssetView.AssetListView).SelectedItems.GetEnumerator();
      try
      {
        if (!enumerator.MoveNext())
          return;
        AssetItem current = (AssetItem) enumerator.Current;
        EventArgs.CanExecute = true;
      }
      finally
      {
        if (enumerator is IDisposable disposable4)
          disposable4.Dispose();
      }
    }
    else
      EventArgs.CanExecute = true;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual unsafe bool IsMapPackageAsset(string AssetPathName)
  {
    FString fstring;
    FString* fstringPtr = &fstring;
    return \u003CModule\u003E.CLRTools\u002EIsMapPackageAsset(\u003CModule\u003E.CLRTools\u002EToFString(&fstring, AssetPathName));
  }

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual bool IsAssetValidForLoading(string AssetPathName) => \u003CModule\u003E.CLRTools\u002EIsAssetValidForLoading(AssetPathName);

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual bool IsAssetValidForPlacing(string AssetPathName) => \u003CModule\u003E.CLRTools\u002EIsAssetValidForPlacing(AssetPathName);

  [return: MarshalAs(UnmanagedType.U1)]
  public virtual bool IsAssetValidForTagging(string AssetFullName) => AssetFullName != (string) null && AssetFullName.Length > 0;

  public unsafe void WriteRecentObjectsToConfig()
  {
    FString fstring1;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D42);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FConfigCacheIni\u002EEmptySection(\u003CModule\u003E.GConfig, \u003CModule\u003E.FString\u002E\u002A(&fstring1), (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
      int count = MainControl.RecentAssets.Count;
      TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddZeroed(&fdefaultAllocator, count);
        int num = count <= MainControl.MaxNumberRecentItems ? count - 1 : MainControl.MaxNumberRecentItems;
        int index = num;
        if (num >= 0)
        {
          do
          {
            string recentAsset = MainControl.RecentAssets[index];
            FString fstring2;
            FString* fstring3 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, recentAsset);
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
            index += -1;
          }
          while (index >= 0);
        }
        \u003CModule\u003E.FConfigCacheIni\u002ESetSingleLineArray(\u003CModule\u003E.GConfig, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D44, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D43, &fdefaultAllocator, (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
        \u003CModule\u003E.FConfigCacheIni\u002EFlush(\u003CModule\u003E.GConfig, 0U, (char*) &\u003CModule\u003E.GEditorUserSettingsIni);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
      }
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
  }

  [HandleProcessCorruptedStateExceptions]
  protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      try
      {
        this.\u007EMContentBrowserControl();
      }
      finally
      {
        try
        {
          this.CallbackEventSyncObjects.Dispose();
        }
        finally
        {
          try
          {
            this.CallbackEventPackages.Dispose();
          }
          finally
          {
            try
            {
              this.CallbackEventObjects.Dispose();
            }
            finally
            {
              try
              {
                this.LastQueryLoadedAssetFullNames.Dispose();
              }
              finally
              {
                try
                {
                  this.CachedQueryLoadedAssetFullNames.Dispose();
                }
                finally
                {
                  try
                  {
                    this.CachedQueryObjects.Dispose();
                  }
                  finally
                  {
                    try
                    {
                      this.LastQueryAssetFullNameFNamesFromGAD.Dispose();
                    }
                    finally
                    {
                      try
                      {
                        this.CachedQueryAssetFullNameFNamesFromGAD.Dispose();
                      }
                      finally
                      {
                        try
                        {
                          this.CachedQueryData.Dispose();
                        }
                        finally
                        {
                          try
                          {
                            this.ReferencedObjects.Dispose();
                          }
                          finally
                          {
                            try
                            {
                              this.ClassToBrowsableObjectTypeMap.Dispose();
                            }
                            finally
                            {
                              try
                              {
                                this.BrowsableObjectTypeToClassMap.Dispose();
                              }
                              finally
                              {
                                try
                                {
                                  this.ObjectFactoryClasses.Dispose();
                                }
                                finally
                                {
                                  try
                                  {
                                    this.SharedThumbnailClasses.Dispose();
                                  }
                                  finally
                                  {
                                    try
                                    {
                                      this.BrowsableObjectTypeList.Dispose();
                                    }
                                    finally
                                    {
                                    }
                                  }
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
    else
    {
      try
      {
      }
      finally
      {
        // ISSUE: explicit finalizer call
        base.Finalize();
      }
    }
  }

  public virtual void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  ~MContentBrowserControl() => this.Dispose(false);

  protected class CachedQueryDataType
  {
    public ReadOnlyCollection<string> SelectedSharedCollectionNames;
    public ReadOnlyCollection<string> SelectedPrivateCollectionNames;
    public ReadOnlyCollection<string> SelectedLocalCollectionNames;
    public NameSet SelectedPathNames;
    public NameSet SelectedOutermostPackageNames;
    public NameSet ExplicitlySelectedOutermostPackageNames;
  }

  protected class CollectionSelectRequest
  {
    public EBrowserCollectionType CollectionType;
    public string CollectionName;
  }
}
