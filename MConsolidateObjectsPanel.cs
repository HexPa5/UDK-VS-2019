// Decompiled with JetBrains decompiler
// Type: MConsolidateObjectsPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using \u003CCppImplementationDetails\u003E;
using ObjectTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

internal class MConsolidateObjectsPanel : MWPFPanel, IDisposable
{
  private uint bAlreadyWarnedAboutTypes;
  private ListBox ConsolidationObjectsListBox;
  private Panel ErrorPanel;
  private TextBlock ErrorMessageTextBlock;
  private Button DismissErrorPanelButton;
  private CheckBox SaveCheckBox;
  private Button ConsolidateButton;
  private Button CancelButton;
  private List<string> ConsolidationObjectNames;
  private readonly MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E ConsolidationObjects;
  private readonly MScopedNativePointer\u003CTSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E ConsolidationResourceTypes;
  private readonly MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E DroppedAssets;

  public unsafe MConsolidateObjectsPanel(string InXamlName)
  {
    MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator1 = new MScopedNativePointer\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u0020\u003E();
    // ISSUE: fault handler
    try
    {
      this.ConsolidationObjects = fdefaultAllocator1;
      MScopedNativePointer\u003CTSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E fdefaultSetAllocator = new MScopedNativePointer\u003CTSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u0020\u003E();
      // ISSUE: fault handler
      try
      {
        this.ConsolidationResourceTypes = fdefaultSetAllocator;
        MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator2 = new MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E();
        // ISSUE: fault handler
        try
        {
          this.DroppedAssets = fdefaultAllocator2;
          // ISSUE: explicit constructor call
          base.\u002Ector(InXamlName);
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
          this.ConsolidationObjects.Reset(InNativePointer1);
          TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E* fdefaultSetAllocatorPtr = (TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) \u003CModule\u003E.@new(72UL);
          TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E* InNativePointer2;
          // ISSUE: fault handler
          try
          {
            InNativePointer2 = (IntPtr) fdefaultSetAllocatorPtr == IntPtr.Zero ? (TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E*) 0L : \u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(fdefaultSetAllocatorPtr);
          }
          __fault
          {
            \u003CModule\u003E.delete((void*) fdefaultSetAllocatorPtr);
          }
          this.ConsolidationResourceTypes.Reset(InNativePointer2);
          TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = (TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
          TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E* InNativePointer3;
          // ISSUE: fault handler
          try
          {
            InNativePointer3 = (IntPtr) fdefaultAllocatorPtr2 == IntPtr.Zero ? (TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr2);
          }
          __fault
          {
            \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr2);
          }
          this.DroppedAssets.Reset(InNativePointer3);
          this.ConsolidationObjectNames = new List<string>();
          ListBox logicalNode = (ListBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "ConsolidateObjectsListBox");
          this.ConsolidationObjectsListBox = logicalNode;
          logicalNode.ItemsSource = (IEnumerable) this.ConsolidationObjectNames;
          this.ConsolidationObjectsListBox.SelectionChanged += new SelectionChangedEventHandler(this.OnListBoxSelectionChanged);
          MConsolidateObjectsPanel mconsolidateObjectsPanel1 = this;
          mconsolidateObjectsPanel1.ErrorPanel = (Panel) LogicalTreeHelper.FindLogicalNode((DependencyObject) mconsolidateObjectsPanel1, nameof (ErrorPanel));
          MConsolidateObjectsPanel mconsolidateObjectsPanel2 = this;
          mconsolidateObjectsPanel2.ErrorMessageTextBlock = (TextBlock) LogicalTreeHelper.FindLogicalNode((DependencyObject) mconsolidateObjectsPanel2, nameof (ErrorMessageTextBlock));
          MConsolidateObjectsPanel mconsolidateObjectsPanel3 = this;
          mconsolidateObjectsPanel3.DismissErrorPanelButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mconsolidateObjectsPanel3, nameof (DismissErrorPanelButton));
          this.DismissErrorPanelButton.Click += new RoutedEventHandler(this.OnDismissErrorPanelButtonClicked);
          MConsolidateObjectsPanel mconsolidateObjectsPanel4 = this;
          mconsolidateObjectsPanel4.SaveCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) mconsolidateObjectsPanel4, nameof (SaveCheckBox));
          MConsolidateObjectsPanel mconsolidateObjectsPanel5 = this;
          mconsolidateObjectsPanel5.ConsolidateButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mconsolidateObjectsPanel5, "OKButton");
          this.ConsolidateButton.Click += new RoutedEventHandler(this.OnConsolidateButtonClicked);
          MConsolidateObjectsPanel mconsolidateObjectsPanel6 = this;
          mconsolidateObjectsPanel6.CancelButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) mconsolidateObjectsPanel6, nameof (CancelButton));
          this.CancelButton.Click += new RoutedEventHandler(this.OnCancelButtonClicked);
          this.ErrorPanel.Visibility = Visibility.Collapsed;
          this.AllowDrop = true;
          MConsolidateObjectsPanel mconsolidateObjectsPanel7 = this;
          mconsolidateObjectsPanel7.DragEnter += new DragEventHandler(mconsolidateObjectsPanel7.OnDragEnter);
          MConsolidateObjectsPanel mconsolidateObjectsPanel8 = this;
          mconsolidateObjectsPanel8.DragLeave += new DragEventHandler(mconsolidateObjectsPanel8.OnDragLeave);
          MConsolidateObjectsPanel mconsolidateObjectsPanel9 = this;
          mconsolidateObjectsPanel9.Drop += new DragEventHandler(mconsolidateObjectsPanel9.OnDrop);
          MConsolidateObjectsPanel mconsolidateObjectsPanel10 = this;
          mconsolidateObjectsPanel10.DragOver += new DragEventHandler(mconsolidateObjectsPanel10.OnDragOver);
          MConsolidateObjectsPanel mconsolidateObjectsPanel11 = this;
          mconsolidateObjectsPanel11.KeyUp += new KeyEventHandler(mconsolidateObjectsPanel11.OnKeyUp);
          MConsolidateObjectsPanel mconsolidateObjectsPanel12 = this;
          mconsolidateObjectsPanel12.MouseDown += new MouseButtonEventHandler(mconsolidateObjectsPanel12.OnMouseDown);
        }
        __fault
        {
          this.DroppedAssets.Dispose();
        }
      }
      __fault
      {
        this.ConsolidationResourceTypes.Dispose();
      }
    }
    __fault
    {
      this.ConsolidationObjects.Dispose();
    }
  }

  public unsafe int AddConsolidationObjects(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InObjects,
    TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E* InResourceTypes)
  {
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    int num;
    // ISSUE: fault handler
    try
    {
      int assetCompatibility = (int) this.DetermineAssetCompatibility(InObjects, &fdefaultAllocator);
      TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt1;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt1, &fdefaultAllocator);
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt1))
      {
        do
        {
          UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1);
          if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EContainsItem(this.ConsolidationObjects.op_MemberSelection(), &uobjectPtr) == 0U)
          {
            FString fstring;
            FString* fullName = \u003CModule\u003E.UObject\u002EGetFullName(uobjectPtr, &fstring, (UObject*) 0L);
            // ISSUE: fault handler
            try
            {
              this.ConsolidationObjectNames.Add(new string(\u003CModule\u003E.FString\u002E\u002A(fullName), 0, \u003CModule\u003E.FString\u002ELen(fullName)));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
            \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(this.ConsolidationObjects.op_MemberSelection(), &uobjectPtr);
          }
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt1);
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt1));
      }
      this.ConsolidationObjectsListBox.Items.Refresh();
      TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt2;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt2, InResourceTypes);
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt2))
      {
        do
        {
          UGenericBrowserType** ugenericBrowserTypePtr = \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt2);
          FSetElementId fsetElementId;
          \u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EAdd(this.ConsolidationResourceTypes.op_MemberSelection(), &fsetElementId, (UGenericBrowserType*) *(long*) ugenericBrowserTypePtr, (uint*) 0L);
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt2);
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt2));
      }
      if (this.AreObjClassesHomogeneous() == 0U && this.bAlreadyWarnedAboutTypes == 0U)
      {
        FString fstring;
        FString* ErrorMessage = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D313, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D312, (char*) 0L);
        // ISSUE: fault handler
        try
        {
          this.DisplayMessage(0U, ErrorMessage);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
        this.bAlreadyWarnedAboutTypes = 1U;
      }
      this.UpdateButtons();
      num = \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    return num;
  }

  public unsafe void QuerySerializableObjects(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* OutSerializableObjects)
  {
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(OutSerializableObjects, \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.ConsolidationObjects.op_MemberSelection()));
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAppend(OutSerializableObjects, this.ConsolidationObjects.Get());
    TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TConstIterator tconstIterator;
    \u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETConstIterator\u002E\u007Bctor\u007D(&tconstIterator, this.ConsolidationResourceTypes.Get(), 0);
    if (\u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator))
    {
      do
      {
        UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002A((TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator);
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(OutSerializableObjects, &uobjectPtr);
        \u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002B\u002B((TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator);
      }
      while (\u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator));
    }
    TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
    \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, this.DroppedAssets.Get());
    if (!\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      return;
    do
    {
      FSelectedAssetInfo* fselectedAssetInfoPtr = \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(OutSerializableObjects, (UObject**) ((IntPtr) fselectedAssetInfoPtr + 24L));
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
    }
    while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
  }

  public unsafe uint DetermineAssetCompatibility(
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* InProposedObjects,
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E* OutCompatibleObjects)
  {
    uint num = 1;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(OutCompatibleObjects, 0);
    if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(InProposedObjects) > 0)
    {
      UClass* uclassPtr = \u003CModule\u003E.UObject\u002EGetClass(\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.ConsolidationObjects.op_MemberSelection()) <= 0 ? (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(InProposedObjects, 0) : (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(this.ConsolidationObjects.Get(), 0));
      TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, InProposedObjects);
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
          if (\u003CModule\u003E.UObject\u002EGetClass(uobjectPtr) != uclassPtr)
          {
            UClass* nearestCommonBaseClass = \u003CModule\u003E.UObject\u002EFindNearestCommonBaseClass(uobjectPtr, uclassPtr);
            if (\u003CModule\u003E.UStruct\u002EIsChildOf((UStruct*) nearestCommonBaseClass, (UStruct*) \u003CModule\u003E.UTexture\u002EStaticClass()) == 0U && \u003CModule\u003E.UStruct\u002EIsChildOf((UStruct*) nearestCommonBaseClass, (UStruct*) \u003CModule\u003E.UMaterialInterface\u002EStaticClass()) == 0U)
            {
              num = 0U;
              goto label_8;
            }
          }
          if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EContainsItem(this.ConsolidationObjects.op_MemberSelection(), &uobjectPtr) != 0U)
            num = 0U;
          else
            \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(OutCompatibleObjects, &uobjectPtr);
label_8:
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
      }
    }
    return num;
  }

  public unsafe void ClearConsolidationObjects()
  {
    this.ConsolidationObjectNames.Clear();
    this.ConsolidationObjectsListBox.Items.Refresh();
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EEmpty(this.ConsolidationObjects.op_MemberSelection(), 0);
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    base.SetParentFrame(InParentFrame);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InParentFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.OnCancelButtonClicked);
  }

  private unsafe uint AreObjClassesHomogeneous()
  {
    uint num = 1;
    if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.ConsolidationObjects.op_MemberSelection()) > 1)
    {
      TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, this.ConsolidationObjects.Get());
      UClass* uclassPtr = \u003CModule\u003E.UObject\u002EGetClass((UObject*) *(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt));
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        while (\u003CModule\u003E.UObject\u002EGetClass((UObject*) *(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt)) == uclassPtr)
        {
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
          if (!\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
            goto label_5;
        }
        num = 0U;
      }
    }
label_5:
    return num;
  }

  private unsafe void ClearDroppedAssets() => \u003CModule\u003E.TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002EEmpty(this.DroppedAssets.op_MemberSelection(), 0);

  private void ResetErrorPanel()
  {
    this.bAlreadyWarnedAboutTypes = 0U;
    this.ErrorPanel.Visibility = Visibility.Collapsed;
    this.ErrorMessageTextBlock.Text = "";
  }

  private unsafe void UpdateButtons() => this.ConsolidateButton.IsEnabled = \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.ConsolidationObjects.op_MemberSelection()) > 1 && this.ConsolidationObjectsListBox.SelectedIndex >= 0;

  private unsafe void RemoveSelectedObject()
  {
    int selectedIndex = this.ConsolidationObjectsListBox.SelectedIndex;
    if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EIsValidIndex(this.ConsolidationObjects.op_MemberSelection(), selectedIndex) == 0U)
      return;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ERemove(this.ConsolidationObjects.op_MemberSelection(), selectedIndex, 1);
    this.ConsolidationObjectNames.RemoveAt(selectedIndex);
    this.ConsolidationObjectsListBox.Items.Refresh();
    if (this.bAlreadyWarnedAboutTypes != 0U && this.AreObjClassesHomogeneous() != 0U)
      this.ResetErrorPanel();
    this.UpdateButtons();
  }

  private unsafe void DisplayMessage(uint bError, FString* ErrorMessage)
  {
    if (bError != 0U)
    {
      this.ErrorPanel.Background = (Brush) Application.Current.Resources[(object) "Slate_Error_Background"];
      this.ErrorMessageTextBlock.Foreground = (Brush) Application.Current.Resources[(object) "Slate_Error_Foreground"];
    }
    else
    {
      this.ErrorPanel.Background = (Brush) Application.Current.Resources[(object) "Slate_Warning_Background"];
      this.ErrorMessageTextBlock.Foreground = (Brush) Application.Current.Resources[(object) "Slate_Warning_Foreground"];
    }
    this.ErrorMessageTextBlock.Text = new string(\u003CModule\u003E.FString\u002E\u002A(ErrorMessage), 0, \u003CModule\u003E.FString\u002ELen(ErrorMessage));
    this.ErrorPanel.Visibility = Visibility.Visible;
  }

  private void OnDismissErrorPanelButtonClicked(object Sender, RoutedEventArgs Args) => this.ErrorPanel.Visibility = Visibility.Collapsed;

  private unsafe void OnConsolidateButtonClicked(object Sender, RoutedEventArgs Args)
  {
    int selectedIndex = this.ConsolidationObjectsListBox.SelectedIndex;
    UObject* uobjectPtr = (UObject*) *(long*) \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(this.ConsolidationObjects.Get(), selectedIndex);
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1, this.ConsolidationObjects.Get());
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ERemoveSingleItem(&fdefaultAllocator1, &uobjectPtr);
      TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator2;
      \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
      // ISSUE: fault handler
      try
      {
        TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TConstIterator tconstIterator;
        \u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETConstIterator\u002E\u007Bctor\u007D(&tconstIterator, this.ConsolidationResourceTypes.Get(), 0);
        if (\u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator))
        {
          do
          {
            \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator2, \u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002A((TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator));
            \u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002B\u002B((TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator);
          }
          while (\u003CModule\u003E.TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C1\u003E\u002E\u002E_N((TSet\u003CUGenericBrowserType\u0020\u002A\u002CDefaultKeyFuncs\u003CUGenericBrowserType\u0020\u002A\u002C0\u003E\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C1\u003E*) &tconstIterator));
        }
        this.ParentFrame.Close(0);
        this.ResetErrorPanel();
        this.ClearConsolidationObjects();
        FConsolidationResults fconsolidationResults;
        \u003CModule\u003E.ObjectTools\u002EConsolidateObjects(&fconsolidationResults, uobjectPtr, &fdefaultAllocator1, &fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          if (this.SaveCheckBox.IsChecked.HasValue)
          {
            if (\u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) &fconsolidationResults + 8)) > 0 && \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) &fconsolidationResults + 40)) == 0 && this.SaveCheckBox.IsChecked.Value)
            {
              int num = (int) \u003CModule\u003E.FEditorFileUtils\u002EPromptForCheckoutAndSave((TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) &fconsolidationResults + 8), 0U, 1U, (TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E*) 0L);
            }
            else if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) &fconsolidationResults + 40)) > 0 && this.SaveCheckBox.IsChecked.Value)
            {
              FString fstring;
              FString* ErrorMessage = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (sbyte*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D315, (char*) &\u003CModule\u003E.\u003FA0x3a4a4fc4\u002Eunnamed\u002Dglobal\u002D314, (char*) 0L);
              // ISSUE: fault handler
              try
              {
                this.DisplayMessage(1U, ErrorMessage);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
            }
          }
          this.ParentFrame.SetContentAndShow((MWPFPanel) this);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(ObjectTools\u002EFConsolidationResults\u002E\u007Bdtor\u007D), (void*) &fconsolidationResults);
        }
        // ISSUE: fault handler
        try
        {
          // ISSUE: fault handler
          try
          {
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) &fconsolidationResults + 40));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) (ref fconsolidationResults + 24L));
            }
            \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D((TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) &fconsolidationResults + 24));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) (ref fconsolidationResults + 8L));
          }
          \u003CModule\u003E.TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D((TArray\u003CUPackage\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) &fconsolidationResults + 8));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FSerializableObject\u002E\u007Bdtor\u007D), (void*) &fconsolidationResults);
        }
        \u003CModule\u003E.FSerializableObject\u002E\u007Bdtor\u007D((FSerializableObject*) &fconsolidationResults);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
      }
      \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
  }

  private void OnCancelButtonClicked(object Sender, RoutedEventArgs Args)
  {
    this.ParentFrame.Close(1);
    this.ClearConsolidationObjects();
    this.ClearDroppedAssets();
    this.ResetErrorPanel();
  }

  private unsafe void OnDragEnter(object Sender, DragEventArgs Args)
  {
    if (!Args.Data.GetDataPresent(DataFormats.StringFormat))
      return;
    \u0024ArrayType\u0024\u0024\u0024BY01\u0024\u0024CB_W arrayTypeBy01CbW;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ^(short&) ref arrayTypeBy01CbW = (short) 124;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    ^(short&) ((IntPtr) &arrayTypeBy01CbW + 2) = (short) 0;
    string data = (string) Args.Data.GetData(DataFormats.StringFormat);
    FString fstring;
    \u003CModule\u003E.CLRTools\u002EToFString(&fstring, data);
    // ISSUE: fault handler
    try
    {
      TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002EParseIntoArray(&fstring, &fdefaultAllocator, (char*) &arrayTypeBy01CbW, 1U);
        \u003CModule\u003E.TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002EEmpty(this.DroppedAssets.op_MemberSelection(), \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator));
        TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
        \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, &fdefaultAllocator);
        if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
        {
          do
          {
            FSelectedAssetInfo* fselectedAssetInfoPtr = (FSelectedAssetInfo*) \u003CModule\u003E.operator\u0020new\u003Cstruct\u0020FSelectedAssetInfo\u002Cclass\u0020FDefaultAllocator\u003E(32UL, this.DroppedAssets.Get());
            if ((IntPtr) fselectedAssetInfoPtr != IntPtr.Zero)
              \u003CModule\u003E.FSelectedAssetInfo\u002E\u007Bctor\u007D(fselectedAssetInfoPtr, \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt));
            \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
          }
          while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFString\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
        }
        Args.Handled = true;
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  private void OnDragLeave(object Sender, DragEventArgs Args)
  {
    this.ClearDroppedAssets();
    Args.Handled = true;
  }

  private unsafe void OnDrop(object Sender, DragEventArgs Args)
  {
    if (\u003CModule\u003E.FContentBrowser\u002EIsInitialized(0) != 0U)
    {
      TMap\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002CFDefaultSetAllocator\u003E* browsableObjectTypeMap = \u003CModule\u003E.gcroot\u003CMContentBrowserControl\u0020\u005E\u003E\u002E\u002EPE\u0024AAVMContentBrowserControl\u0040\u0040((gcroot\u003CMContentBrowserControl\u0020\u005E\u003E*) ((IntPtr) \u003CModule\u003E.FContentBrowser\u002EGetActiveInstance() + 32L)).GetBrowsableObjectTypeMap();
      TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
      \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
      // ISSUE: fault handler
      try
      {
        TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator2;
        \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt1;
          \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt1, this.DroppedAssets.Get());
          if (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt1))
          {
            do
            {
              FSelectedAssetInfo* fselectedAssetInfoPtr1 = \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1);
              FSelectedAssetInfo* fselectedAssetInfoPtr2 = (FSelectedAssetInfo*) ((IntPtr) fselectedAssetInfoPtr1 + 24L);
              if (*(long*) fselectedAssetInfoPtr2 == 0L)
              {
                FSelectedAssetInfo* fselectedAssetInfoPtr3 = (FSelectedAssetInfo*) ((IntPtr) fselectedAssetInfoPtr1 + 8L);
                UObject* uobjectPtr1 = \u003CModule\u003E.UObject\u002EStaticFindObject((UClass*) *(long*) fselectedAssetInfoPtr1, (UObject*) -1L, \u003CModule\u003E.FString\u002E\u002A((FString*) fselectedAssetInfoPtr3), 0U);
                *(long*) fselectedAssetInfoPtr2 = (long) uobjectPtr1;
                if ((IntPtr) uobjectPtr1 == IntPtr.Zero && \u003CModule\u003E.FContentBrowser\u002EIsInitialized(0) != 0U && \u003CModule\u003E.CLRTools\u002EIsAssetValidForLoading(new string(\u003CModule\u003E.FString\u002E\u002A((FString*) fselectedAssetInfoPtr3), 0, \u003CModule\u003E.FString\u002ELen((FString*) fselectedAssetInfoPtr3))))
                {
                  UObject* uobjectPtr2 = \u003CModule\u003E.UObject\u002EStaticLoadObject((UClass*) *(long*) fselectedAssetInfoPtr1, (UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A((FString*) fselectedAssetInfoPtr3), (char*) 0L, 8194U, (UPackageMap*) 0L, 0U);
                  *(long*) fselectedAssetInfoPtr2 = (long) uobjectPtr2;
                  if ((IntPtr) uobjectPtr2 != IntPtr.Zero)
                  {
                    FCallbackEventParameters fcallbackEventParameters;
                    \u003CModule\u003E.FCallbackEventParameters\u002E\u007Bctor\u007D(&fcallbackEventParameters, (FCallbackEventDevice*) 0L, (ECallbackEventType) 23, 149U, uobjectPtr2);
                    FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
                    ref FCallbackEventParameters local = ref fcallbackEventParameters;
                    // ISSUE: cast to a function pointer type
                    // ISSUE: function pointer call
                    __calli((__FnPtr<void (IntPtr, FCallbackEventParameters*)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 8L))((FCallbackEventParameters*) gcallbackEvent, (IntPtr) ref local);
                  }
                }
              }
              if (*(long*) fselectedAssetInfoPtr2 != 0L)
              {
                \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator2, (UObject**) fselectedAssetInfoPtr2);
                TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = \u003CModule\u003E.TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003CUClass\u0020\u002A\u002CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002C0\u002CFDefaultSetAllocator\u003E*) browsableObjectTypeMap, \u003CModule\u003E.UObject\u002EGetClass((UObject*) *(long*) fselectedAssetInfoPtr2));
                if ((IntPtr) fdefaultAllocatorPtr != IntPtr.Zero)
                {
                  TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt2;
                  \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt2, fdefaultAllocatorPtr);
                  if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt2))
                  {
                    do
                    {
                      \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(&fdefaultAllocator1, \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt2));
                      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt2);
                    }
                    while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt2));
                  }
                }
              }
              \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt1);
            }
            while (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt1));
          }
          this.AddConsolidationObjects(&fdefaultAllocator2, &fdefaultAllocator1);
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
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
      }
      \u003CModule\u003E.TArray\u003CUGenericBrowserType\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    }
    this.ClearDroppedAssets();
    Keyboard.Focus((IInputElement) this);
    Args.Handled = true;
  }

  private unsafe void OnDragOver(object Sender, DragEventArgs Args)
  {
    Args.Effects = DragDropEffects.None;
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator1;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
    // ISSUE: fault handler
    try
    {
      TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, this.DroppedAssets.Get());
      if (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          FSelectedAssetInfo* fselectedAssetInfoPtr = \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
          ulong num = (ulong) *(long*) ((IntPtr) fselectedAssetInfoPtr + 24L);
          UObject* uobjectPtr = num == 0UL ? (UObject*) (ValueType) (IntPtr) \u003CModule\u003E.UClass\u002EGetDefaultObject((UClass*) *(long*) fselectedAssetInfoPtr, 0U) : (UObject*) (ValueType) (long) num;
          \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddUniqueItem(&fdefaultAllocator1, &uobjectPtr);
          \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
        }
        while (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
      }
      TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator2;
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
      // ISSUE: fault handler
      try
      {
        if (\u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1) > 0 && this.DetermineAssetCompatibility(&fdefaultAllocator1, &fdefaultAllocator2) != 0U)
          Args.Effects = DragDropEffects.Copy;
        Args.Handled = true;
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

  private void OnKeyUp(object Sender, KeyEventArgs Args)
  {
    if (Args.Key != Key.Delete)
      return;
    this.RemoveSelectedObject();
    Args.Handled = true;
  }

  private void OnMouseDown(object Sender, MouseButtonEventArgs Args) => Keyboard.Focus((IInputElement) this);

  private void OnListBoxSelectionChanged(object Sender, SelectionChangedEventArgs Args)
  {
    this.UpdateButtons();
    Keyboard.Focus((IInputElement) this);
  }

  public void \u007EMConsolidateObjectsPanel()
  {
  }

  [HandleProcessCorruptedStateExceptions]
  protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
  {
    if (_param1)
    {
      try
      {
      }
      finally
      {
        try
        {
          this.DroppedAssets.Dispose();
        }
        finally
        {
          try
          {
            this.ConsolidationResourceTypes.Dispose();
          }
          finally
          {
            try
            {
              this.ConsolidationObjects.Dispose();
            }
            finally
            {
            }
          }
        }
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
