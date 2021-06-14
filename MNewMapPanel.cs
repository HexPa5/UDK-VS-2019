// Decompiled with JetBrains decompiler
// Type: MNewMapPanel
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using UnrealEd;

internal class MNewMapPanel : MWPFPanel
{
  private unsafe TArray\u003CUTemplateMapMetadata\u0020\u002A\u002CFDefaultAllocator\u003E* \u003Cbacking_store\u003ETemplates;
  private string \u003Cbacking_store\u003ESelectedTemplate;

  public MNewMapPanel(string InXaml)
    : base(InXaml)
  {
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "CloseWindowButton")).Click += new RoutedEventHandler(this.OnCloseClicked);
    ((Selector) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "TemplatesStackPanelCol0")).SelectionChanged += new SelectionChangedEventHandler(this.OnSelect);
    ((Selector) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "TemplatesStackPanelCol1")).SelectionChanged += new SelectionChangedEventHandler(this.OnSelect);
  }

  public override void SetParentFrame(MWPFFrame InParentFrame)
  {
    ((Selector) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "TemplatesStackPanelCol0")).SelectedItem = (object) null;
    ((Selector) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "TemplatesStackPanelCol1")).SelectedItem = (object) null;
    this.SelectedTemplate = (string) null;
    if (this.GetParentFrame() == InParentFrame)
      return;
    base.SetParentFrame(InParentFrame);
    this.PopulateTemplateList();
  }

  public unsafe TArray\u003CUTemplateMapMetadata\u0020\u002A\u002CFDefaultAllocator\u003E* Templates
  {
    get => this.\u003Cbacking_store\u003ETemplates;
    set => this.\u003Cbacking_store\u003ETemplates = value;
  }

  public string SelectedTemplate
  {
    get => this.\u003Cbacking_store\u003ESelectedTemplate;
    set => this.\u003Cbacking_store\u003ESelectedTemplate = value;
  }

  private void OnCloseClicked(object Owner, RoutedEventArgs Args)
  {
    this.SelectedTemplate = (string) null;
    this.ParentFrame.Close(0);
  }

  private void OnSelect(object Owner, SelectionChangedEventArgs Args)
  {
    ListBox listBox = (ListBox) Owner;
    if (null == listBox.SelectedItem)
      return;
    TemplateMapMetadata selectedItem = (TemplateMapMetadata) listBox.SelectedItem;
    if (null == selectedItem)
      return;
    this.SelectedTemplate = selectedItem.PackageName;
    this.ParentFrame.Close(1);
  }

  private unsafe void PopulateTemplateList()
  {
    ItemsControl logicalNode1 = (ItemsControl) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "TemplatesStackPanelCol0");
    ItemsControl logicalNode2 = (ItemsControl) LogicalTreeHelper.FindLogicalNode((DependencyObject) this, "TemplatesStackPanelCol1");
    TemplateMapMetadata templateMapMetadata1 = new TemplateMapMetadata();
    templateMapMetadata1.PackageName = (string) null;
    FString fstring1;
    \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BE\u0040CINDKFIE\u0040\u003F\u0024AAB\u003F\u0024AAl\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAk\u003F\u0024AA\u003F5\u003F\u0024AAM\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AA\u003F\u0024AA\u0040);
    // ISSUE: fault handler
    try
    {
      templateMapMetadata1.DisplayName = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring1), 0, \u003CModule\u003E.FString\u002ELen(&fstring1));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
    FString fstring2;
    FString* editorResourcesDir1 = \u003CModule\u003E.GetEditorResourcesDir(&fstring2);
    // ISSUE: fault handler
    try
    {
      FString fstring3;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1DI\u0040OKEPKFLI\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAN\u003F\u0024AAe\u003F\u0024AAw\u003F\u0024AAM\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AA_\u003F\u0024AAB\u003F\u0024AAl\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAk\u003F\u0024AAM\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AA\u003F4\u003F\u0024AAp\u003F\u0024AAn\u003F\u0024AAg\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir1));
      // ISSUE: fault handler
      try
      {
        FString fstring4;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring4, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
        // ISSUE: fault handler
        try
        {
          string uriString = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring4), 0, \u003CModule\u003E.FString\u002ELen(&fstring4));
          templateMapMetadata1.Thumbnail = (BitmapSource) new BitmapImage(new Uri(uriString, UriKind.Absolute));
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
    FString fstring5;
    FString* editorResourcesDir2 = \u003CModule\u003E.GetEditorResourcesDir(&fstring5);
    BitmapImage bitmapImage;
    // ISSUE: fault handler
    try
    {
      FString fstring3;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1DG\u0040NPDDGNJD\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAN\u003F\u0024AAe\u003F\u0024AAw\u003F\u0024AAM\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AA_\u003F\u0024AAD\u003F\u0024AAe\u003F\u0024AAf\u003F\u0024AAa\u003F\u0024AAu\u003F\u0024AAl\u003F\u0024AAt\u003F\u0024AA\u003F4\u003F\u0024AAp\u003F\u0024AAn\u003F\u0024AAg\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir2));
      // ISSUE: fault handler
      try
      {
        FString fstring4;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring4, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
        // ISSUE: fault handler
        try
        {
          bitmapImage = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(&fstring4), 0, \u003CModule\u003E.FString\u002ELen(&fstring4)), UriKind.Absolute));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
    int num1 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CUTemplateMapMetadata\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.Templates))
    {
      do
      {
        UTemplateMapMetadata* utemplateMapMetadataPtr = (UTemplateMapMetadata*) *(long*) \u003CModule\u003E.TArray\u003CUTemplateMapMetadata\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(this.Templates, num1);
        TemplateMapMetadata templateMapMetadata2 = new TemplateMapMetadata();
        FString fstring3;
        FString* name1 = \u003CModule\u003E.UObject\u002EGetName((UObject*) utemplateMapMetadataPtr, &fstring3);
        // ISSUE: fault handler
        try
        {
          templateMapMetadata2.PackageName = new string(\u003CModule\u003E.FString\u002E\u002A(name1), 0, \u003CModule\u003E.FString\u002ELen(name1));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
        templateMapMetadata2.Thumbnail = (BitmapSource) bitmapImage;
        ulong num2 = (ulong) *(long*) ((IntPtr) utemplateMapMetadataPtr + 96L);
        if (0UL != num2)
        {
          FObjectThumbnail* thumbnailForObject = \u003CModule\u003E.ThumbnailTools\u002EGenerateThumbnailForObject((UObject*) num2);
          if (0L != (IntPtr) thumbnailForObject)
            templateMapMetadata2.Thumbnail = \u003CModule\u003E.ThumbnailToolsCLR\u002ECreateBitmapSourceForThumbnail(thumbnailForObject);
        }
        FString fstring4;
        FString* name2 = \u003CModule\u003E.UObject\u002EGetName((UObject*) utemplateMapMetadataPtr, &fstring4);
        // ISSUE: fault handler
        try
        {
          FString fstring6;
          FString* fstringPtr = \u003CModule\u003E.Localize(&fstring6, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1EC\u0040DCDEBCLI\u0040\u003F\u0024AAT\u003F\u0024AAe\u003F\u0024AAm\u003F\u0024AAp\u003F\u0024AAl\u003F\u0024AAa\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAM\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAM\u003F\u0024AAe\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAd\u003F\u0024AAa\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AA\u003F4\u003F\u0024AAD\u003F\u0024AAi\u003F\u0024AAs\u003F\u0024AAp\u003F\u0024AAl\u003F\u0024AAa\u003F\u0024AAy\u003F\u0024AAN\u003F\u0024AAa\u003F\u0024AAm\u003F\u0024AAe\u003F\u0024AAs\u0040, \u003CModule\u003E.FString\u002E\u002A(name2), (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1CG\u0040LMOLEGMD\u0040\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAM\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAT\u003F\u0024AAe\u003F\u0024AAm\u003F\u0024AAp\u003F\u0024AAl\u003F\u0024AAa\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.UObject\u002EGetLanguage(), 0U);
          // ISSUE: fault handler
          try
          {
            templateMapMetadata2.DisplayName = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr));
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
        if (0 == num1 % 2)
          logicalNode1.Items.Add((object) templateMapMetadata2);
        else
          logicalNode2.Items.Add((object) templateMapMetadata2);
        ++num1;
      }
      while (num1 < \u003CModule\u003E.TArray\u003CUTemplateMapMetadata\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(this.Templates));
    }
    if (0 == logicalNode1.Items.Count % 2)
      logicalNode1.Items.Add((object) templateMapMetadata1);
    else
      logicalNode2.Items.Add((object) templateMapMetadata1);
  }
}
