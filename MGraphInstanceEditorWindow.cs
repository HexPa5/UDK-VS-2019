// Decompiled with JetBrains decompiler
// Type: MGraphInstanceEditorWindow
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using \u003CCppImplementationDetails\u003E;
using CustomControls;
using std.tr1;
using SubstanceAir;
using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

internal class MGraphInstanceEditorWindow : MWPFPanel, IDisposable
{
  private Visual RootVisual;
  private static unsafe FGraphInstance* ParentInstance;
  private unsafe FPickColorStruct* PickColorStruct;
  private unsafe FLinearColor* PickColorData;
  private PickColorDataContext CurrentColorEdited;
  protected readonly MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E DroppedAssets;

  public unsafe MGraphInstanceEditorWindow(
    MWPFFrame InFrame,
    FGraphInstance* Instance,
    FPickColorStruct* inPickColorStruct,
    FLinearColor* inPickColorData)
  {
    this.PickColorStruct = inPickColorStruct;
    this.PickColorData = inPickColorData;
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator = new MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E();
    // ISSUE: fault handler
    try
    {
      this.DroppedAssets = fdefaultAllocator;
      // ISSUE: explicit constructor call
      base.\u002Ector("SubstanceAirGraphInstanceEditorWindow.xaml");
      MGraphInstanceEditorWindow.ParentInstance = Instance;
      MGraphInstanceEditorWindow instanceEditorWindow;
      instanceEditorWindow.RootVisual = (Visual) (instanceEditorWindow = this);
      FrameworkElement frameworkElement = (FrameworkElement) this;
      frameworkElement.DataContext = (object) this;
      this.CurrentColorEdited = (PickColorDataContext) null;
      \u003CModule\u003E.CloseColorPickers();
      this.BuildGraphDesc();
      this.BuildOutputList();
      this.BuildImageInputList();
      this.BuildInputList();
      this.BuildDefaultActions();
      ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) InFrame.GetRootVisual(), "TitleBarCloseButton")).Click += new RoutedEventHandler(this.OnClose);
      frameworkElement.PreviewKeyDown += new KeyEventHandler(this.PreviewKeyDownHandler);
    }
    __fault
    {
      this.DroppedAssets.Dispose();
    }
  }

  public unsafe void OnClose(object Sender, RoutedEventArgs Args)
  {
    \u003CModule\u003E.CloseColorPickers();
    MGraphInstanceEditorWindow.ParentInstance = (FGraphInstance*) 0L;
    \u003CModule\u003E.\u003FGraphInstance\u0040FGraphInstanceEditorWindow\u0040\u00402PEAUFGraphInstance\u0040SubstanceAir\u0040\u0040EA = (FGraphInstance*) 0L;
  }

  private void \u007EMGraphInstanceEditorWindow()
  {
  }

  public unsafe void BuildOutputList()
  {
    Grid logicalNode = (Grid) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.RootVisual, "Outputs");
    logicalNode.Children.Clear();
    TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt1;
    \u003CModule\u003E.SubstanceAir\u002EList\u003CSubstanceAir\u003A\u003AFOutputInstance\u003E\u002Eitfront((List\u003CSubstanceAir\u003A\u003AFOutputInstance\u003E*) MGraphInstanceEditorWindow.ParentInstance, &fdefaultAllocatorInt1);
    ulong num = 0;
    if (!\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt1))
      return;
    do
    {
      ulong OutputIndex = num;
      ++num;
      TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt2;
      this.BuildOutputControl(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt2, &fdefaultAllocatorInt1), logicalNode, OutputIndex);
      \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt1);
    }
    while (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt1));
  }

  public unsafe void BuildInputList()
  {
    StackPanel logicalNode1 = (StackPanel) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.RootVisual, "Inputs");
    logicalNode1.Children.Clear();
    List\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u0020\u003E* airFinputDescBasePtr = (List\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u0020\u003E*) (*(long*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 64L) + 64L);
    List\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u0020\u003E airFinputDescBase;
    \u003CModule\u003E.TArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D((TArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E*) &airFinputDescBase, (TArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E*) airFinputDescBasePtr);
    // ISSUE: fault handler
    try
    {
      List\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u0020\u003E* finputInstanceBasePtr = (List\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u0020\u003E*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 16L);
      List\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u0020\u003E finputInstanceBase;
      \u003CModule\u003E.TArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D((TArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E*) &finputInstanceBase, (TArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E*) finputInstanceBasePtr);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.Sort\u003Cclass\u0020std\u003A\u003Atr1\u003A\u003Ashared_ptr\u003Cstruct\u0020SubstanceAir\u003A\u003AFInputDescBase\u003E\u002Cclass\u0020CompareSubstanceAirEdGraphInstanceEditorinput_desc_ptrConstRef\u003E(\u003CModule\u003E.SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u0020\u003E\u002E\u0028\u0029(&airFinputDescBase, 0U), \u003CModule\u003E.SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u0020\u003E\u002ENum(&airFinputDescBase));
        \u003CModule\u003E.Sort\u003Cclass\u0020std\u003A\u003Atr1\u003A\u003Ashared_ptr\u003Cstruct\u0020SubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002Cclass\u0020CompareSubstanceAirEdGraphInstanceEditorinput_inst_t_ptrConstRef\u003E(\u003CModule\u003E.SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u0020\u003E\u002E\u0028\u0029(&finputInstanceBase, 0U), \u003CModule\u003E.SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u0020\u003E\u002ENum(&finputInstanceBase));
        TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt1;
        \u003CModule\u003E.SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u0020\u003E\u002Eitfront(&airFinputDescBase, &fdefaultAllocatorInt1);
        TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt2;
        \u003CModule\u003E.SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u0020\u003E\u002Eitfront(&finputInstanceBase, &fdefaultAllocatorInt2);
        TArray\u003Cunsigned\u0020long\u002CFDefaultAllocator\u003E fdefaultAllocator;
        \u003CModule\u003E.TArray\u003Cunsigned\u0020long\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
        // ISSUE: fault handler
        try
        {
          TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt3;
          \u003CModule\u003E.SubstanceAir\u002EList\u003CSubstanceAir\u003A\u003AFOutputInstance\u003E\u002Eitfront((List\u003CSubstanceAir\u003A\u003AFOutputInstance\u003E*) MGraphInstanceEditorWindow.ParentInstance, &fdefaultAllocatorInt3);
          if (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt3))
          {
            do
            {
              \u003CModule\u003E.TArray\u003Cunsigned\u0020long\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, (uint*) \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt3));
              \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt3);
            }
            while (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt3));
          }
          TMap\u003CFString\u002Cint\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
          \u003CModule\u003E.TMap\u003CFString\u002Cint\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
          // ISSUE: fault handler
          try
          {
            bool flag = false;
            bool DarkBackgroud = false;
            if (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt1))
            {
              while (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt2))
              {
                if (\u003CModule\u003E.FString\u002E\u003D\u003D((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1)) + 8L), (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BG\u0040KOCKIEFP\u0040\u003F\u0024AA\u0024\u003F\u0024AAp\u003F\u0024AAi\u003F\u0024AAx\u003F\u0024AAe\u003F\u0024AAl\u003F\u0024AAs\u003F\u0024AAi\u003F\u0024AAz\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040) == 0U && \u003CModule\u003E.FString\u002E\u003D\u003D((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1)) + 8L), (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1M\u0040BHIJFMNA\u0040\u003F\u0024AA\u0024\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAm\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040) == 0U && (\u003CModule\u003E.FString\u002E\u003D\u003D((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1)) + 8L), (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040CPKHCPMN\u0040\u003F\u0024AA\u0024\u003F\u0024AAn\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAf\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAt\u003F\u0024AA\u003F\u0024AA\u0040) == 0U && *(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1)) + 68L) != 5))
                {
                  flag = true;
                  if (0 == \u003CModule\u003E.FString\u002ELen((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1)) + 40L)))
                  {
                    logicalNode1.Children.Add((UIElement) this.BuildInputControl(&fdefaultAllocatorInt1, &fdefaultAllocatorInt2, DarkBackgroud, false));
                    DarkBackgroud = !DarkBackgroud;
                  }
                  else
                  {
                    if (0U == \u003CModule\u003E.TMapBase\u003CFString\u002Cint\u002C0\u002CFDefaultSetAllocator\u003E\u002EHasKey((TMapBase\u003CFString\u002Cint\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, (FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1)) + 40L)))
                    {
                      Expander expander = new Expander();
                      expander.Header = (object) \u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1)) + 40L));
                      expander.Foreground = (Brush) Application.Current.Resources[(object) "Slate_Control_Foreground"];
                      expander.Content = (object) new StackPanel();
                      expander.DataContext = (object) false;
                      Thickness thickness = new Thickness(5.0, 0.0, -1.0, 0.0);
                      expander.Margin = thickness;
                      logicalNode1.Children.Add((UIElement) expander);
                      \u003CModule\u003E.TMapBase\u003CFString\u002Cint\u002C0\u002CFDefaultSetAllocator\u003E\u002ESet((TMapBase\u003CFString\u002Cint\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, (FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1)) + 40L), logicalNode1.Children.IndexOf((UIElement) expander));
                    }
                    int* numPtr = \u003CModule\u003E.TMapBase\u003CFString\u002Cint\u002C0\u002CFDefaultSetAllocator\u003E\u002EFind((TMapBase\u003CFString\u002Cint\u002C0\u002CFDefaultSetAllocator\u003E*) &fdefaultSetAllocator, (FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1)) + 40L));
                    Expander child = (Expander) logicalNode1.Children[*numPtr];
                    ((Panel) child.Content).Children.Add((UIElement) this.BuildInputControl(&fdefaultAllocatorInt1, &fdefaultAllocatorInt2, (bool) child.DataContext, true));
                    int num = !(bool) child.DataContext ? 1 : 0;
                    child.DataContext = (object) (bool) num;
                  }
                }
                \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt1);
                \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt2);
                if (!\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt1))
                  break;
              }
              if (flag)
                goto label_18;
            }
            Expander logicalNode2 = (Expander) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.RootVisual, "InputsExpander");
            logicalNode2.Visibility = Visibility.Collapsed;
            logicalNode2.Height = 0.0;
            ((UIElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.RootVisual, "InputsSep")).Visibility = Visibility.Collapsed;
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TMap\u003CFString\u002Cint\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
          }
label_18:
          \u003CModule\u003E.TMap\u003CFString\u002Cint\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020long\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
        }
        \u003CModule\u003E.TArray\u003Cunsigned\u0020long\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u0020\u003E\u002E\u007Bdtor\u007D), (void*) &finputInstanceBase);
      }
      \u003CModule\u003E.SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u0020\u003E\u002E\u007Bdtor\u007D(&finputInstanceBase);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u0020\u003E\u002E\u007Bdtor\u007D), (void*) &airFinputDescBase);
    }
    \u003CModule\u003E.SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u0020\u003E\u002E\u007Bdtor\u007D(&airFinputDescBase);
  }

  public unsafe void BuildImageInputList()
  {
    StackPanel logicalNode1 = (StackPanel) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.RootVisual, "ImageInputs");
    logicalNode1.Children.Clear();
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt1;
    \u003CModule\u003E.SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u0020\u003E\u002Eitfront((List\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u0020\u003E*) (*(long*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 64L) + 64L), &fdefaultAllocatorInt1);
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt2;
    \u003CModule\u003E.SubstanceAir\u002EList\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u0020\u003E\u002Eitfront((List\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u0020\u003E*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 16L), &fdefaultAllocatorInt2);
    bool flag = false;
    DockPanel dockPanel = (DockPanel) null;
    if (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt1))
    {
      while (\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt2))
      {
        if (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt1)) + 68L) == 5)
        {
          if (dockPanel != null)
          {
            dockPanel.Children.Add(this.BuildImageInputControl(&fdefaultAllocatorInt1, &fdefaultAllocatorInt2));
            logicalNode1.Children.Add((UIElement) dockPanel);
            dockPanel = (DockPanel) null;
          }
          else
          {
            dockPanel = new DockPanel();
            Thickness thickness = new Thickness(10.0, 5.0, 0.0, 5.0);
            dockPanel.Margin = thickness;
            dockPanel.Children.Add(this.BuildImageInputControl(&fdefaultAllocatorInt1, &fdefaultAllocatorInt2));
          }
          flag = true;
        }
        \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt1);
        \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt2);
        if (!\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt1))
          break;
      }
    }
    if (dockPanel != null)
      logicalNode1.Children.Add((UIElement) dockPanel);
    if (flag)
      return;
    Expander logicalNode2 = (Expander) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.RootVisual, "ImageInputsExpander");
    logicalNode2.Visibility = Visibility.Collapsed;
    logicalNode2.Height = 0.0;
    ((UIElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.RootVisual, "ImageInputsSep")).Visibility = Visibility.Collapsed;
  }

  public unsafe void SynchColorPicker()
  {
    PickColorDataContext currentColorEdited = this.CurrentColorEdited;
    if (currentColorEdited == null)
      return;
    FNumericalInputInstanceBase* inputInstanceBasePtr = (FNumericalInputInstanceBase*) currentColorEdited.mInputPtr.Get();
    switch (*(int*) (*(long*) ((IntPtr) inputInstanceBasePtr + 20L) + 68L))
    {
      case 0:
      case 1:
      case 2:
      case 3:
        TArray\u003Cfloat\u002CFDefaultAllocator\u003E fdefaultAllocator1;
        \u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.SubstanceAir\u002EFNumericalInputInstanceBase\u002EGetValue\u003Cfloat\u003E(inputInstanceBasePtr, &fdefaultAllocator1);
          *(float*) this.PickColorData = *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, 0);
          *(float*) ((IntPtr) this.PickColorData + 4L) = *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, 1);
          *(float*) ((IntPtr) this.PickColorData + 8L) = *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, 2);
          if (\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator1) == 4)
            *(float*) ((IntPtr) this.PickColorData + 12L) = *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, 3);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
        }
        \u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
        break;
      default:
        TArray\u003Cint\u002CFDefaultAllocator\u003E fdefaultAllocator2;
        \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.SubstanceAir\u002EFNumericalInputInstanceBase\u002EGetValue\u003Cint\u003E(inputInstanceBasePtr, &fdefaultAllocator2);
          *(float*) this.PickColorData = (float) *\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator2, 0);
          *(float*) ((IntPtr) this.PickColorData + 4L) = (float) *\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator2, 1);
          *(float*) ((IntPtr) this.PickColorData + 8L) = (float) *\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator2, 2);
          if (\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator2) == 4)
            *(float*) ((IntPtr) this.PickColorData + 12L) = (float) *\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator2, 3);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
        break;
    }
    MColorPickerPanel.GetStaticColorPicker(this.CurrentColorEdited.ColorPickerIndex).BindData();
  }

  protected unsafe void PreviewKeyDownHandler(object sender, KeyEventArgs e)
  {
    if (e.KeyboardDevice.Modifiers != ModifierKeys.Control || !e.KeyboardDevice.IsKeyDown(Key.Z))
      return;
    UUnrealEdEngine* uunrealEdEnginePtr1 = (UUnrealEdEngine*) ((IntPtr) \u003CModule\u003E.GUnrealEd + 96L);
    UUnrealEdEngine* uunrealEdEnginePtr2 = uunrealEdEnginePtr1;
    ref \u0024ArrayType\u0024\u0024\u0024BY0BB\u0040\u0024\u0024CB_W local = ref \u003CModule\u003E.\u003F\u003F_C\u0040_1CC\u0040JJIDPJAH\u0040\u003F\u0024AAT\u003F\u0024AAR\u003F\u0024AAA\u003F\u0024AAN\u003F\u0024AAS\u003F\u0024AAA\u003F\u0024AAC\u003F\u0024AAT\u003F\u0024AAI\u003F\u0024AAO\u003F\u0024AAN\u003F\u0024AA\u003F5\u003F\u0024AAU\u003F\u0024AAN\u003F\u0024AAD\u003F\u0024AAO\u003F\u0024AA\u003F\u0024AA\u0040;
    FOutputDeviceRedirectorBase* glog = \u003CModule\u003E.GLog;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    int num = (int) __calli((__FnPtr<uint (IntPtr, char*, FOutputDevice*)>) *(long*) *(long*) uunrealEdEnginePtr1)((FOutputDevice*) uunrealEdEnginePtr2, (char*) ref local, (IntPtr) glog);
    e.Handled = true;
  }

  [return: MarshalAs(UnmanagedType.U1)]
  protected unsafe bool CanEdit() => \u003CModule\u003E.UObject\u002EHasAnyFlags((UObject*) *(long*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 72L), 32768UL) == 0U && 0U != \u003CModule\u003E.UObject\u002EHasAnyFlags((UObject*) *(long*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 72L), 2251799813685248UL);

  protected unsafe void BuildGraphDesc()
  {
    Grid logicalNode = (Grid) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.RootVisual, "GraphDetails");
    logicalNode.RowDefinitions.Add(new RowDefinition());
    Label label1 = new Label();
    label1.Content = (object) "Name";
    logicalNode.Children.Add((UIElement) label1);
    Grid.SetColumn((UIElement) label1, 0);
    Label label2 = new Label();
    label2.HorizontalAlignment = HorizontalAlignment.Left;
    string str = \u003CModule\u003E.CLRTools\u002EToString((FString*) (*(long*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 64L) + 16L)).Replace("_", " ").Trim();
    label2.Content = (object) str;
    logicalNode.Children.Add((UIElement) label2);
    Grid.SetColumn((UIElement) label2, 1);
    ((HeaderedContentControl) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.RootVisual, "GraphDetailsExp")).Header = (object) ("Graph Details (" + label2.Content + ")");
    if (\u003CModule\u003E.FString\u002ELen((FString*) (*(long*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 64L) + 32L)) == 0)
      return;
    logicalNode.RowDefinitions.Add(new RowDefinition());
    Label label3 = new Label();
    label3.Content = (object) "Description";
    TextBlock textBlock = new TextBlock();
    textBlock.Text = \u003CModule\u003E.CLRTools\u002EToString((FString*) (*(long*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 64L) + 32L));
    textBlock.Foreground = (Brush) Application.Current.Resources[(object) "Slate_Control_Foreground"];
    textBlock.TextWrapping = TextWrapping.Wrap;
    logicalNode.Children.Add((UIElement) label3);
    Grid.SetColumn((UIElement) label3, 0);
    Grid.SetRow((UIElement) label3, 1);
    logicalNode.Children.Add((UIElement) textBlock);
    Grid.SetColumn((UIElement) textBlock, 1);
    Grid.SetRow((UIElement) textBlock, 1);
  }

  protected unsafe void BuildOutputControl(
    TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItOut,
    Grid Container,
    ulong OutputIndex)
  {
    FOutputDesc* outputDesc = \u003CModule\u003E.SubstanceAir\u002EFOutputInstance\u002EGetOutputDesc(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItOut));
    if ((IntPtr) outputDesc == IntPtr.Zero)
      return;
    Label label = new Label();
    FOutputDesc* foutputDescPtr = (FOutputDesc*) ((IntPtr) outputDesc + 16L);
    label.Content = (object) \u003CModule\u003E.CLRTools\u002EToString((FString*) foutputDescPtr);
    CheckBox checkBox1 = new CheckBox();
    checkBox1.Foreground = (Brush) Application.Current.Resources[(object) "Slate_Control_Foreground"];
    bool? nullable = (bool?) (((int) (byte) *(int*) ((IntPtr) \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItOut) + 24L) & 1) != 0);
    checkBox1.IsChecked = nullable;
    CheckBox checkBox2 = checkBox1;
    checkBox2.Style = (Style) checkBox2.TryFindResource((object) "OnOffCheckbox");
    if (*(long*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CUSubstanceAirTexture2D\u0020\u002A\u003E\u002E\u002A((shared_ptr\u003CUSubstanceAirTexture2D\u0020\u002A\u003E*) ((IntPtr) \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002D\u003E(ItOut) + 32L)) != 0L)
    {
      if (\u003CModule\u003E.UObject\u002EIsReferenced(&(UObject*) *(long*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CUSubstanceAirTexture2D\u0020\u002A\u003E\u002E\u002A((shared_ptr\u003CUSubstanceAirTexture2D\u0020\u002A\u003E*) ((IntPtr) \u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002D\u003E(ItOut) + 32L)), \u003CModule\u003E.GIsEditor != 0U ? 290482175965396992UL : 288230376151711744UL) != 0U)
      {
        FString fstring;
        \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1GE\u0040HIIPMDKD\u0040\u003F\u0024AAT\u003F\u0024AAh\u003F\u0024AAi\u003F\u0024AAs\u003F\u0024AA\u003F5\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAx\u003F\u0024AAt\u003F\u0024AAu\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AA\u003F5\u003F\u0024AAi\u003F\u0024AAs\u003F\u0024AA\u003F5\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAf\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAd\u003F\u0024AA\u003F5\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AA\u003F5\u003F\u0024AAc\u0040);
        // ISSUE: fault handler
        try
        {
          label.ToolTip = (object) \u003CModule\u003E.CLRTools\u002EToString(&fstring);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
        checkBox1.IsEnabled = false;
      }
      else
        checkBox1.IsEnabled = true;
    }
    else
      checkBox1.IsEnabled = true;
    MOutputDataContext moutputDataContext = new MOutputDataContext();
    moutputDataContext.mOutputPtr.Reset(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItOut));
    moutputDataContext.mGraphPtr.Reset(\u003CModule\u003E.SubstanceAir\u002EFOutputInstance\u002EGetParentGraphInstance(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003CSubstanceAir\u003A\u003AFOutputInstance\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItOut)));
    moutputDataContext.mOutputName = \u003CModule\u003E.CLRTools\u002EToString((FString*) foutputDescPtr);
    checkBox1.DataContext = (object) moutputDataContext;
    checkBox1.Checked += new RoutedEventHandler(this.CheckedOutput);
    checkBox1.Unchecked += new RoutedEventHandler(this.UncheckedOutput);
    Container.RowDefinitions.Add(new RowDefinition());
    Container.Children.Add((UIElement) label);
    Grid.SetColumn((UIElement) label, 0);
    int num = (int) OutputIndex;
    Grid.SetRow((UIElement) label, num);
    Container.Children.Add((UIElement) checkBox1);
    Grid.SetColumn((UIElement) checkBox1, 1);
    Grid.SetRow((UIElement) checkBox1, num);
  }

  protected unsafe void BuildDefaultActions()
  {
    Grid logicalNode = (Grid) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.RootVisual, "Options");
    logicalNode.RowDefinitions.Add(new RowDefinition());
    Label label = new Label();
    label.Content = (object) "Bake outputs";
    CheckBox checkBox1 = new CheckBox();
    bool? nullable = (bool?) (bool) ((uint) *(int*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 80L) >> 1 & 1U);
    checkBox1.IsChecked = nullable;
    CheckBox checkBox2 = checkBox1;
    checkBox2.Style = (Style) checkBox2.TryFindResource((object) "OnOffCheckbox");
    checkBox1.Checked += new RoutedEventHandler(this.CheckedBake);
    checkBox1.Unchecked += new RoutedEventHandler(this.UncheckedBake);
    logicalNode.Children.Add((UIElement) label);
    Grid.SetColumn((UIElement) label, 0);
    logicalNode.Children.Add((UIElement) checkBox1);
    Grid.SetColumn((UIElement) checkBox1, 1);
    logicalNode.RowDefinitions.Add(new RowDefinition());
    Button button = new Button();
    button.Content = (object) "Reset to default Values";
    button.Height = 18.0;
    button.HorizontalAlignment = HorizontalAlignment.Stretch;
    Thickness thickness = new Thickness(0.0, 0.0, 5.0, 0.0);
    button.Margin = thickness;
    button.Click += new RoutedEventHandler(this.ResetToDefaultPressed);
    logicalNode.Children.Add((UIElement) button);
    Grid.SetColumn((UIElement) button, 1);
    Grid.SetRow((UIElement) button, 2);
  }

  protected unsafe void CheckedBake(object sender, RoutedEventArgs e)
  {
    uint num = (uint) (*(int*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 80L) | 2);
    *(int*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 80L) = (int) num;
  }

  protected unsafe void UncheckedBake(object sender, RoutedEventArgs e)
  {
    uint num = (uint) (*(int*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 80L) & -3);
    *(int*) ((IntPtr) MGraphInstanceEditorWindow.ParentInstance + 80L) = (int) num;
  }

  protected Grid BuildGrid(ulong ColCount)
  {
    Grid grid = new Grid();
    if (0UL < ColCount)
    {
      ulong num = ColCount;
      do
      {
        grid.ColumnDefinitions.Add(new ColumnDefinition()
        {
          Width = new GridLength(1.0, GridUnitType.Star)
        });
        --num;
      }
      while (num > 0UL);
    }
    return grid;
  }

  protected unsafe Grid BuildInputControl(
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputDesc,
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputInst,
    [MarshalAs(UnmanagedType.U1)] bool DarkBackgroud,
    [MarshalAs(UnmanagedType.U1)] bool IsInGroup)
  {
    Grid Container = new Grid();
    Container.ColumnDefinitions.Add(new ColumnDefinition()
    {
      Width = new GridLength(IsInGroup ? 109.0 : 120.0)
    });
    Container.ColumnDefinitions.Add(new ColumnDefinition()
    {
      Width = new GridLength(1.0, GridUnitType.Star)
    });
    if (IsInGroup)
    {
      Thickness thickness = new Thickness(5.0, 0.0, 0.0, 0.0);
      Container.Margin = thickness;
    }
    if (DarkBackgroud)
    {
      Color color = Color.FromArgb(byte.MaxValue, (byte) 80, (byte) 80, (byte) 80);
      Container.Background = (Brush) new SolidColorBrush(color);
    }
    if (\u003CModule\u003E.FString\u002E\u003D\u003D((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 8L), (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BI\u0040FCNBIPHN\u0040\u003F\u0024AA\u0024\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAo\u003F\u0024AAm\u003F\u0024AAs\u003F\u0024AAe\u003F\u0024AAe\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040) != 0U)
    {
      this.BuildRandomSeedControl(ItInputDesc, ItInputInst, Container);
      Grid.SetColumn(Container.Children[1], 1);
      return Container;
    }
    if (\u003CModule\u003E.FString\u002E\u003D\u003D((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 8L), (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BI\u0040JBFAEMPA\u0040\u003F\u0024AA\u0024\u003F\u0024AAo\u003F\u0024AAu\u003F\u0024AAt\u003F\u0024AAp\u003F\u0024AAu\u003F\u0024AAt\u003F\u0024AAs\u003F\u0024AAi\u003F\u0024AAz\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040) != 0U)
    {
      this.BuildSizePow2Control(ItInputDesc, ItInputInst, Container);
      Grid.SetColumn(Container.Children[1], 1);
      return Container;
    }
    switch (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 56L))
    {
      case 2:
        this.BuildAngleControl(ItInputDesc, ItInputInst, Container);
        break;
      case 3:
        if (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L) == 0)
        {
          this.BuildSliderControl(ItInputDesc, ItInputInst, Container, (Button) null, false);
          break;
        }
        this.BuildColorControl(ItInputDesc, ItInputInst, Container);
        break;
      case 4:
        this.BuildToggleButtonControl(ItInputDesc, ItInputInst, Container);
        break;
      case 5:
        this.BuildComboBoxControl(ItInputDesc, ItInputInst, Container);
        break;
      case 6:
        this.BuildSizePow2Control(ItInputDesc, ItInputInst, Container);
        break;
      default:
        this.BuildSliderControl(ItInputDesc, ItInputInst, Container, (Button) null, false);
        break;
    }
    Grid.SetColumn(Container.Children[1], 1);
    return Container;
  }

  protected unsafe int GetMinComponent\u003CFIntVector2\u002Cint\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FIntVector2\u002E\u005B\u005D((FIntVector2*) ((IntPtr) Desc + 104L), Idx);
  }

  protected unsafe float GetMinComponent\u003CFVector2D\u002Cfloat\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FVector2D\u002E\u005B\u005D((FVector2D*) ((IntPtr) Desc + 104L), Idx);
  }

  protected unsafe int GetMinComponent\u003CFIntVector3\u002Cint\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FIntVector3\u002E\u005B\u005D((FIntVector3*) ((IntPtr) Desc + 108L), Idx);
  }

  protected unsafe float GetMinComponent\u003CFVector\u002Cfloat\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FVector\u002E\u005B\u005D((FVector*) ((IntPtr) Desc + 108L), Idx);
  }

  protected unsafe int GetMinComponent\u003CFIntVector4\u002Cint\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FIntVector4\u002E\u005B\u005D((FIntVector4*) ((IntPtr) Desc + 112L), Idx);
  }

  protected unsafe float GetMinComponent\u003CFVector4\u002Cfloat\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FVector4\u002E\u005B\u005D((FVector4*) ((IntPtr) Desc + 112L), Idx);
  }

  protected unsafe int GetMaxComponent\u003CFIntVector2\u002Cint\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FIntVector2\u002E\u005B\u005D((FIntVector2*) ((IntPtr) Desc + 112L), Idx);
  }

  protected unsafe float GetMaxComponent\u003CFVector2D\u002Cfloat\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FVector2D\u002E\u005B\u005D((FVector2D*) ((IntPtr) Desc + 112L), Idx);
  }

  protected unsafe int GetMaxComponent\u003CFIntVector3\u002Cint\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FIntVector3\u002E\u005B\u005D((FIntVector3*) ((IntPtr) Desc + 120L), Idx);
  }

  protected unsafe float GetMaxComponent\u003CFVector\u002Cfloat\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FVector\u002E\u005B\u005D((FVector*) ((IntPtr) Desc + 120L), Idx);
  }

  protected unsafe int GetMaxComponent\u003CFIntVector4\u002Cint\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FIntVector4\u002E\u005B\u005D((FIntVector4*) ((IntPtr) Desc + 128L), Idx);
  }

  protected unsafe float GetMaxComponent\u003CFVector4\u002Cfloat\u003E(
    FInputDescBase* Desc,
    int Idx)
  {
    return *\u003CModule\u003E.FVector4\u002E\u005B\u005D((FVector4*) ((IntPtr) Desc + 128L), Idx);
  }

  protected unsafe void BuildSliderControl(
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputDesc,
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputInst,
    Grid Container,
    Button ColorPicker,
    [MarshalAs(UnmanagedType.U1)] bool PlusOne)
  {
    FNumericalInputDesc\u003Cint\u003E* fnumericalInputDescIntPtr1 = (FNumericalInputDesc\u003Cint\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002Eget(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc));
    int length = 1;
    switch (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L))
    {
      case 1:
      case 8:
        length = 2;
        break;
      case 2:
      case 9:
        length = 3;
        break;
      case 3:
      case 10:
        length = 4;
        break;
    }
    Label label = new Label();
    label.Content = (object) \u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 24L)).Replace("_", " ");
    label.ToolTip = (object) \u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 8L));
    Container.Children.Add((UIElement) label);
    UniformGrid uniformGrid = new UniformGrid();
    uniformGrid.Columns = !PlusOne ? length : length + 1;
    uniformGrid.Rows = 1;
    uniformGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
    int Idx = 0;
    if (0 < length)
    {
      int num1 = length - 1;
      FNumericalInputDesc\u003Cint\u003E* fnumericalInputDescIntPtr2 = (FNumericalInputDesc\u003Cint\u003E*) ((IntPtr) fnumericalInputDescIntPtr1 + 92L);
      do
      {
        DragSlider dragSlider1 = new DragSlider();
        ((FrameworkElement) dragSlider1).HorizontalAlignment = HorizontalAlignment.Stretch;
        ((FrameworkElement) dragSlider1).Height = 18.0;
        if (Idx != num1)
        {
          Thickness thickness = new Thickness(0.0, 0.0, 5.0, 0.0);
          ((FrameworkElement) dragSlider1).Margin = thickness;
        }
        dragSlider1.AllowInlineEdit = (__Null) 1;
        MInputDataContext\u003Cfloat\u003E dataContextFloat = new MInputDataContext\u003Cfloat\u003E();
        dataContextFloat.mInputPtr.Reset(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst)));
        dataContextFloat.mGraphPtr.Reset(MGraphInstanceEditorWindow.ParentInstance);
        dataContextFloat.mIndex = Idx;
        dataContextFloat.mValue = new float[length];
        dataContextFloat.mPickButton = ColorPicker;
        int num2 = *(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L);
        if (num2 >= 0)
        {
          if (num2 > 3)
          {
            switch (num2)
            {
              case 4:
              case 8:
              case 9:
              case 10:
                ((RangeBase) dragSlider1).Minimum = 0.0;
                ((RangeBase) dragSlider1).Maximum = (double) uint.MaxValue;
                break;
            }
          }
          else
          {
            ((RangeBase) dragSlider1).Minimum = double.MinValue;
            ((RangeBase) dragSlider1).Maximum = double.MaxValue;
          }
        }
        switch (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L))
        {
          case 0:
            FNumericalInputInstance\u003Cfloat\u003E* inputInstanceFloatPtr = (FNumericalInputInstance\u003Cfloat\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
            ((RangeBase) dragSlider1).Value = (double) *(float*) ((IntPtr) inputInstanceFloatPtr + 36L);
            dataContextFloat.mValue[0] = *(float*) ((IntPtr) inputInstanceFloatPtr + 36L);
            break;
          case 1:
            FNumericalInputInstance\u003CFVector2D\u003E* instanceFvector2DPtr = (FNumericalInputInstance\u003CFVector2D\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
            float num3 = Idx != 0 ? *(float*) ((IntPtr) instanceFvector2DPtr + 40L) : *(float*) ((IntPtr) instanceFvector2DPtr + 36L);
            ((RangeBase) dragSlider1).Value = (double) num3;
            float[] mValue1 = dataContextFloat.mValue;
            mValue1[0] = *(float*) ((IntPtr) instanceFvector2DPtr + 36L);
            mValue1[1] = *(float*) ((IntPtr) instanceFvector2DPtr + 40L);
            break;
          case 2:
            FNumericalInputInstance\u003CFVector\u003E* inputInstanceFvectorPtr = (FNumericalInputInstance\u003CFVector\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
            float num4;
            float num5;
            switch (Idx)
            {
              case 0:
                num4 = *(float*) ((IntPtr) inputInstanceFvectorPtr + 36L);
                goto label_29;
              case 1:
                num5 = *(float*) ((IntPtr) inputInstanceFvectorPtr + 40L);
                break;
              default:
                num5 = *(float*) ((IntPtr) inputInstanceFvectorPtr + 44L);
                break;
            }
            num4 = num5;
label_29:
            ((RangeBase) dragSlider1).Value = (double) num4;
            float[] mValue2 = dataContextFloat.mValue;
            mValue2[0] = *(float*) ((IntPtr) inputInstanceFvectorPtr + 36L);
            mValue2[1] = *(float*) ((IntPtr) inputInstanceFvectorPtr + 40L);
            mValue2[2] = *(float*) ((IntPtr) inputInstanceFvectorPtr + 44L);
            break;
          case 3:
            FNumericalInputInstance\u003CFVector4\u003E* instanceFvector4Ptr = (FNumericalInputInstance\u003CFVector4\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
            float num6;
            float num7;
            float num8;
            switch (Idx)
            {
              case 0:
                num6 = *(float*) ((IntPtr) instanceFvector4Ptr + 48L);
                goto label_45;
              case 1:
                num7 = *(float*) ((IntPtr) instanceFvector4Ptr + 52L);
                goto label_44;
              case 2:
                num8 = *(float*) ((IntPtr) instanceFvector4Ptr + 56L);
                break;
              default:
                num8 = *(float*) ((IntPtr) instanceFvector4Ptr + 60L);
                break;
            }
            num7 = num8;
label_44:
            num6 = num7;
label_45:
            ((RangeBase) dragSlider1).Value = (double) num6;
            float[] mValue3 = dataContextFloat.mValue;
            mValue3[0] = *(float*) ((IntPtr) instanceFvector4Ptr + 48L);
            mValue3[1] = *(float*) ((IntPtr) instanceFvector4Ptr + 52L);
            mValue3[2] = *(float*) ((IntPtr) instanceFvector4Ptr + 56L);
            mValue3[3] = *(float*) ((IntPtr) instanceFvector4Ptr + 60L);
            break;
          case 4:
            FNumericalInputInstance\u003Cint\u003E* inputInstanceIntPtr = (FNumericalInputInstance\u003Cint\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
            ((RangeBase) dragSlider1).Value = (double) *(int*) ((IntPtr) inputInstanceIntPtr + 36L);
            dataContextFloat.mValue[0] = (float) *(int*) ((IntPtr) inputInstanceIntPtr + 36L);
            break;
          case 8:
            FNumericalInputInstance\u003CFIntVector2\u003E* instanceFintVector2Ptr = (FNumericalInputInstance\u003CFIntVector2\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
            int num9 = Idx != 0 ? *(int*) ((IntPtr) instanceFintVector2Ptr + 40L) : *(int*) ((IntPtr) instanceFintVector2Ptr + 36L);
            ((RangeBase) dragSlider1).Value = (double) num9;
            float[] mValue4 = dataContextFloat.mValue;
            mValue4[0] = (float) *(int*) ((IntPtr) instanceFintVector2Ptr + 36L);
            mValue4[1] = (float) *(int*) ((IntPtr) instanceFintVector2Ptr + 40L);
            break;
          case 9:
            FNumericalInputInstance\u003CFIntVector3\u003E* instanceFintVector3Ptr = (FNumericalInputInstance\u003CFIntVector3\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
            int num10;
            int num11;
            switch (Idx)
            {
              case 0:
                num10 = *(int*) ((IntPtr) instanceFintVector3Ptr + 36L);
                goto label_23;
              case 1:
                num11 = *(int*) ((IntPtr) instanceFintVector3Ptr + 40L);
                break;
              default:
                num11 = *(int*) ((IntPtr) instanceFintVector3Ptr + 44L);
                break;
            }
            num10 = num11;
label_23:
            ((RangeBase) dragSlider1).Value = (double) num10;
            float[] mValue5 = dataContextFloat.mValue;
            mValue5[0] = (float) *(int*) ((IntPtr) instanceFintVector3Ptr + 36L);
            mValue5[1] = (float) *(int*) ((IntPtr) instanceFintVector3Ptr + 40L);
            mValue5[2] = (float) *(int*) ((IntPtr) instanceFintVector3Ptr + 44L);
            break;
          case 10:
            FNumericalInputInstance\u003CFIntVector4\u003E* instanceFintVector4Ptr = (FNumericalInputInstance\u003CFIntVector4\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
            int num12;
            int num13;
            int num14;
            switch (Idx)
            {
              case 0:
                num12 = *(int*) ((IntPtr) instanceFintVector4Ptr + 36L);
                goto label_37;
              case 1:
                num13 = *(int*) ((IntPtr) instanceFintVector4Ptr + 40L);
                goto label_36;
              case 2:
                num14 = *(int*) ((IntPtr) instanceFintVector4Ptr + 44L);
                break;
              default:
                num14 = *(int*) ((IntPtr) instanceFintVector4Ptr + 48L);
                break;
            }
            num13 = num14;
label_36:
            num12 = num13;
label_37:
            ((RangeBase) dragSlider1).Value = (double) num12;
            float[] mValue6 = dataContextFloat.mValue;
            mValue6[0] = (float) *(int*) ((IntPtr) instanceFintVector4Ptr + 36L);
            mValue6[1] = (float) *(int*) ((IntPtr) instanceFintVector4Ptr + 40L);
            mValue6[2] = (float) *(int*) ((IntPtr) instanceFintVector4Ptr + 44L);
            mValue6[3] = (float) *(int*) ((IntPtr) instanceFintVector4Ptr + 48L);
            break;
        }
        switch (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L))
        {
          case 0:
            FNumericalInputDesc\u003Cfloat\u003E* fnumericalInputDescFloatPtr = (FNumericalInputDesc\u003Cfloat\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc));
            dragSlider1.SliderMin = (double) *(float*) ((IntPtr) fnumericalInputDescFloatPtr + 100L);
            dragSlider1.SliderMax = (double) *(float*) ((IntPtr) fnumericalInputDescFloatPtr + 104L);
            break;
          case 1:
            dragSlider1.SliderMin = (double) this.GetMinComponent\u003CFVector2D\u002Cfloat\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            dragSlider1.SliderMax = (double) this.GetMaxComponent\u003CFVector2D\u002Cfloat\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            break;
          case 2:
            dragSlider1.SliderMin = (double) this.GetMinComponent\u003CFVector\u002Cfloat\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            dragSlider1.SliderMax = (double) this.GetMaxComponent\u003CFVector\u002Cfloat\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            break;
          case 3:
            dragSlider1.SliderMin = (double) this.GetMinComponent\u003CFVector4\u002Cfloat\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            dragSlider1.SliderMax = (double) this.GetMaxComponent\u003CFVector4\u002Cfloat\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            break;
          case 4:
            FNumericalInputDesc\u003Cint\u003E* fnumericalInputDescIntPtr3 = (FNumericalInputDesc\u003Cint\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc));
            dragSlider1.SliderMin = (double) *(int*) ((IntPtr) fnumericalInputDescIntPtr3 + 100L);
            dragSlider1.SliderMax = (double) *(int*) ((IntPtr) fnumericalInputDescIntPtr3 + 104L);
            break;
          case 8:
            dragSlider1.SliderMin = (double) this.GetMinComponent\u003CFIntVector2\u002Cint\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            dragSlider1.SliderMax = (double) this.GetMaxComponent\u003CFIntVector2\u002Cint\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            break;
          case 9:
            dragSlider1.SliderMin = (double) this.GetMinComponent\u003CFIntVector3\u002Cint\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            dragSlider1.SliderMax = (double) this.GetMaxComponent\u003CFIntVector3\u002Cint\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            break;
          case 10:
            dragSlider1.SliderMin = (double) this.GetMinComponent\u003CFIntVector4\u002Cint\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            dragSlider1.SliderMax = (double) this.GetMaxComponent\u003CFIntVector4\u002Cint\u003E(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)), Idx);
            break;
        }
        if (dragSlider1.SliderMin == 0.0 && dragSlider1.SliderMax == 0.0)
        {
          if (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L) != 4 && *(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L) != 8 && (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L) != 9 && *(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L) != 10))
          {
            dragSlider1.SliderMin = 0.0;
            dragSlider1.SliderMax = 1.0;
          }
          else
          {
            dragSlider1.SliderMin = 0.0;
            float num15 = dataContextFloat.mValue[0];
            float num16 = (double) num15 <= 0.0 ? 10f : num15 * 2f;
            dragSlider1.SliderMax = (double) num16;
          }
        }
        if (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L) != 4 && *(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L) != 8 && (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L) != 9 && *(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L) != 10))
        {
          DragSlider dragSlider2 = dragSlider1;
          dragSlider2.ValuesPerDragPixel = (dragSlider2.SliderMax - dragSlider1.SliderMin) * 0.001;
          DragSlider dragSlider3 = dragSlider1;
          dragSlider3.ValuesPerMouseWheelScroll = dragSlider3.ValuesPerDragPixel * 10.0;
        }
        else
        {
          dragSlider1.ValuesPerDragPixel = 0.100000001490116;
          dragSlider1.DrawAsInteger = true;
        }
        if (*(int*) fnumericalInputDescIntPtr2 != 0)
        {
          DragSlider dragSlider2 = dragSlider1;
          ((RangeBase) dragSlider2).Minimum = dragSlider2.SliderMin;
          DragSlider dragSlider3 = dragSlider1;
          ((RangeBase) dragSlider3).Maximum = dragSlider3.SliderMax;
        }
        ((RangeBase) dragSlider1).ValueChanged += new RoutedPropertyChangedEventHandler<double>(this.SliderValueChanged\u003Cfloat\u003E);
        ((UIElement) dragSlider1).PreviewMouseDown += new MouseButtonEventHandler(this.SliderMouseDown);
        dragSlider1.AbsoluteDrag = true;
        ((FrameworkElement) dragSlider1).DataContext = (object) dataContextFloat;
        dragSlider1.DrawAsPercentage = false;
        uniformGrid.Children.Add((UIElement) dragSlider1);
        ++Idx;
      }
      while (Idx < length);
    }
    Container.Children.Add((UIElement) uniformGrid);
  }

  protected unsafe void BuildRandomSeedControl(
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputDesc,
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputInst,
    Grid Container)
  {
    FNumericalInputInstance\u003Cint\u003E* inputInstanceIntPtr = (FNumericalInputInstance\u003Cint\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
    Label label = new Label();
    label.Content = (object) "Random Seed";
    Grid grid = this.BuildGrid(2UL);
    GridLength gridLength1 = new GridLength(90.0);
    grid.ColumnDefinitions[0].Width = gridLength1;
    GridLength gridLength2 = new GridLength(1.0, GridUnitType.Star);
    grid.ColumnDefinitions[1].Width = gridLength2;
    MInputDataContext\u003Cint\u003E minputDataContextInt = new MInputDataContext\u003Cint\u003E();
    minputDataContextInt.mInputPtr.Reset(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst)));
    minputDataContextInt.mGraphPtr.Reset(MGraphInstanceEditorWindow.ParentInstance);
    int[] numArray = new int[1];
    minputDataContextInt.mValue = numArray;
    numArray[0] = *(int*) ((IntPtr) inputInstanceIntPtr + 36L);
    DragSlider dragSlider = new DragSlider();
    ((FrameworkElement) dragSlider).HorizontalAlignment = HorizontalAlignment.Stretch;
    ((RangeBase) dragSlider).Minimum = 0.0;
    ((RangeBase) dragSlider).Maximum = (double) uint.MaxValue;
    dragSlider.ValuesPerDragPixel = 1.0;
    dragSlider.AllowInlineEdit = (__Null) 1;
    dragSlider.DrawAsInteger = true;
    ((FrameworkElement) dragSlider).DataContext = (object) minputDataContextInt;
    ((RangeBase) dragSlider).Value = (double) minputDataContextInt.mValue[0];
    ((FrameworkElement) dragSlider).Height = 18.0;
    ((RangeBase) dragSlider).ValueChanged += new RoutedPropertyChangedEventHandler<double>(this.SliderValueChanged\u003Cint\u003E);
    Button button = new Button();
    button.Content = (object) "Randomize";
    button.Height = 18.0;
    button.HorizontalAlignment = HorizontalAlignment.Stretch;
    Thickness thickness = new Thickness(0.0, 0.0, 5.0, 0.0);
    button.Margin = thickness;
    MRandomizeDataContext mrandomizeDataContext = new MRandomizeDataContext();
    mrandomizeDataContext.mRandomSlider = dragSlider;
    mrandomizeDataContext.mGraphPtr.Reset(MGraphInstanceEditorWindow.ParentInstance);
    button.DataContext = (object) mrandomizeDataContext;
    button.Click += new RoutedEventHandler(this.RandomizeButtonPressed);
    grid.Children.Add((UIElement) button);
    Grid.SetColumn((UIElement) button, 0);
    grid.Children.Add((UIElement) dragSlider);
    Grid.SetColumn((UIElement) dragSlider, 1);
    Container.Children.Add((UIElement) label);
    Container.Children.Add((UIElement) grid);
  }

  protected unsafe ComboBox BuildResolutionComboBox(
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputDesc,
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputInst,
    int SizeValue,
    ComboBox ResolutionComboBox,
    ComboBox OtherResolutionComboBox,
    CheckBox RatioLock,
    uint IsWidth)
  {
    ResolutionComboBox.Width = 60.0;
    ResolutionComboBox.Height = 18.0;
    int num1 = 5;
    do
    {
      int num2 = (int) \u003CModule\u003E.appPow(2f, (float) num1);
      FString fstring;
      FString* InFString = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_15KNBIKKIN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, num2);
      // ISSUE: fault handler
      try
      {
        ResolutionComboBox.Items.Add((object) \u003CModule\u003E.CLRTools\u002EToString(InFString));
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
    while (num1 <= 11);
    int num3 = \u003CModule\u003E.Clamp\u003Cint\u003E(5, SizeValue, 11) - 5;
    ResolutionComboBox.SelectedIndex = num3;
    ResolutionComboBox.SelectionChanged += new SelectionChangedEventHandler(this.Pow2Changed);
    MSizePow2Context msizePow2Context = new MSizePow2Context();
    msizePow2Context.mInputPtr.Reset(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst)));
    msizePow2Context.mGraphPtr.Reset(MGraphInstanceEditorWindow.ParentInstance);
    int num4 = IsWidth != 0U ? 0 : 1;
    msizePow2Context.mIndex = num4;
    msizePow2Context.mRatioLock = RatioLock;
    msizePow2Context.mOtherSize = OtherResolutionComboBox;
    msizePow2Context.mSkipUpdate = false;
    ResolutionComboBox.DataContext = (object) msizePow2Context;
    return ResolutionComboBox;
  }

  protected unsafe void BuildSizePow2Control(
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputDesc,
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputInst,
    Grid Container)
  {
    Label label = new Label();
    label.Content = (object) "Output size";
    label.ToolTip = (object) "$outputsize";
    StackPanel stackPanel = new StackPanel();
    stackPanel.Orientation = Orientation.Horizontal;
    FNumericalInputInstance\u003CFIntVector2\u003E* instanceFintVector2Ptr = (FNumericalInputInstance\u003CFIntVector2\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
    int SizeValue1 = *(int*) ((IntPtr) instanceFintVector2Ptr + 36L);
    int SizeValue2 = *(int*) ((IntPtr) instanceFintVector2Ptr + 40L);
    CheckBox RatioLock = new CheckBox();
    RatioLock.Content = (object) "Lock ratio";
    RatioLock.VerticalAlignment = VerticalAlignment.Center;
    bool? nullable = (bool?) (((int) (byte) *(int*) ((IntPtr) instanceFintVector2Ptr + 44L) & 1) != 0);
    RatioLock.IsChecked = nullable;
    RatioLock.Checked += new RoutedEventHandler(this.CheckedLockRatio);
    RatioLock.Unchecked += new RoutedEventHandler(this.CheckedLockRatio);
    ComboBox comboBox1 = new ComboBox();
    ComboBox comboBox2 = new ComboBox();
    this.BuildResolutionComboBox(ItInputDesc, ItInputInst, SizeValue1, comboBox1, comboBox2, RatioLock, 1U);
    this.BuildResolutionComboBox(ItInputDesc, ItInputInst, SizeValue2, comboBox2, comboBox1, RatioLock, 0U);
    RatioLock.DataContext = comboBox1.DataContext;
    Thickness thickness1 = new Thickness(0.0, 0.0, 5.0, 0.0);
    comboBox1.Margin = thickness1;
    Thickness thickness2 = new Thickness(0.0, 0.0, 5.0, 0.0);
    comboBox2.Margin = thickness2;
    stackPanel.Children.Add((UIElement) comboBox1);
    stackPanel.Children.Add((UIElement) comboBox2);
    stackPanel.Children.Add((UIElement) RatioLock);
    Container.Children.Add((UIElement) label);
    Container.Children.Add((UIElement) stackPanel);
  }

  protected unsafe void CheckedLockRatio(object sender, RoutedEventArgs e)
  {
    if (!this.CanEdit())
      return;
    CheckBox checkBox = (CheckBox) sender;
    MSizePow2Context dataContext = (MSizePow2Context) checkBox.DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E finputInstanceBase = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(dataContext.mInputPtr.Get());
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
    if (!finputInstanceBase.IsValid() || !airFgraphInstance.IsValid())
      return;
    FNumericalInputInstance\u003CFIntVector2\u003E* instanceFintVector2Ptr = (FNumericalInputInstance\u003CFIntVector2\u003E*) finputInstanceBase.Get();
    int num = checkBox.IsChecked.Value ? 1 : 0;
    *(int*) ((IntPtr) instanceFintVector2Ptr + 44L) = *(int*) ((IntPtr) instanceFintVector2Ptr + 44L) & -2;
    *(int*) ((IntPtr) instanceFintVector2Ptr + 44L) = *(int*) ((IntPtr) instanceFintVector2Ptr + 44L) | num & 1;
  }

  protected unsafe void BuildColorControl(
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputDesc,
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputInst,
    Grid Container)
  {
    Button ColorPicker = new Button();
    this.BuildSliderControl(ItInputDesc, ItInputInst, Container, ColorPicker, true);
    UniformGrid child = (UniformGrid) Container.Children[1];
    Image image = new Image();
    FString fstring1;
    FString* editorResourcesDir = \u003CModule\u003E.GetEditorResourcesDir(&fstring1);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1DG\u0040PFIDJNII\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAE\u003F\u0024AAy\u003F\u0024AAe\u003F\u0024AAD\u003F\u0024AAr\u003F\u0024AAo\u003F\u0024AAp\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AAI\u003F\u0024AAc\u003F\u0024AAo\u003F\u0024AAn\u003F\u0024AA\u003F4\u003F\u0024AAp\u003F\u0024AAn\u003F\u0024AAg\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir));
      // ISSUE: fault handler
      try
      {
        image.Source = (ImageSource) new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
    ColorPicker.Content = (object) image;
    ColorPicker.Height = 18.0;
    ColorPicker.HorizontalAlignment = HorizontalAlignment.Stretch;
    Thickness thickness = new Thickness(5.0, 0.0, 0.0, 0.0);
    ColorPicker.Margin = thickness;
    PickColorDataContext colorDataContext = new PickColorDataContext();
    colorDataContext.bSyncEnabled = true;
    colorDataContext.mInputPtr.Reset(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst)));
    colorDataContext.mGraphPtr.Reset(MGraphInstanceEditorWindow.ParentInstance);
    colorDataContext.mSliderRed = (DragSlider) child.Children[0];
    colorDataContext.mSliderGreen = (DragSlider) child.Children[1];
    colorDataContext.mSliderBlue = (DragSlider) child.Children[2];
    if (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 68L) == 3)
      colorDataContext.mSliderAlpha = (DragSlider) child.Children[3];
    Color color = Color.FromArgb(byte.MaxValue, (byte) ((int) (uint) (((RangeBase) colorDataContext.mSliderRed).Value * (double) byte.MaxValue) & (int) byte.MaxValue), (byte) ((int) (uint) (((RangeBase) colorDataContext.mSliderGreen).Value * (double) byte.MaxValue) & (int) byte.MaxValue), (byte) ((int) (uint) (((RangeBase) colorDataContext.mSliderBlue).Value * (double) byte.MaxValue) & (int) byte.MaxValue));
    ColorPicker.Background = (Brush) new SolidColorBrush(color);
    ColorPicker.DataContext = (object) colorDataContext;
    ColorPicker.Click += new RoutedEventHandler(this.PickColorPressed);
    child.Children.Add((UIElement) ColorPicker);
    PickColorDataContext currentColorEdited1 = this.CurrentColorEdited;
    if (currentColorEdited1 == null || currentColorEdited1.mInputPtr.Get() != \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002Eget(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst)))
      return;
    PickColorDataContext currentColorEdited2 = this.CurrentColorEdited;
    float startR = (float) currentColorEdited2.StartR;
    float startG = (float) currentColorEdited2.StartG;
    float startB = (float) currentColorEdited2.StartB;
    float startA = (float) currentColorEdited2.StartA;
    this.CurrentColorEdited = colorDataContext;
    colorDataContext.StartR = (double) startR;
    this.CurrentColorEdited.StartG = (double) startG;
    this.CurrentColorEdited.StartB = (double) startB;
    this.CurrentColorEdited.StartA = (double) startA;
  }

  protected unsafe void BuildAngleControl(
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputDesc,
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputInst,
    Grid Container)
  {
    this.BuildSliderControl(ItInputDesc, ItInputInst, Container, (Button) null, false);
  }

  protected unsafe void BuildComboBoxControl(
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputDesc,
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputInst,
    Grid Container)
  {
    Label label = new Label();
    label.Content = (object) \u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 24L));
    label.ToolTip = (object) \u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 8L));
    label.VerticalAlignment = VerticalAlignment.Center;
    MInputDataContext\u003Cint\u003E minputDataContextInt = new MInputDataContext\u003Cint\u003E();
    minputDataContextInt.mInputPtr.Reset(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst)));
    minputDataContextInt.mGraphPtr.Reset(MGraphInstanceEditorWindow.ParentInstance);
    ComboBox comboBox = new ComboBox();
    FInputDescBase* finputDescBasePtr = \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc));
    FNumericalInputInstance\u003Cint\u003E* inputInstanceIntPtr1 = (FNumericalInputInstance\u003Cint\u003E*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst));
    int num = 0;
    FNumericalInputDescComboBox* inputDescComboBoxPtr = (FNumericalInputDescComboBox*) ((IntPtr) finputDescBasePtr + 108L);
    minputDataContextInt.mValue = new int[\u003CModule\u003E.TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) inputDescComboBoxPtr)];
    TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E.TIterator titerator;
    \u003CModule\u003E.TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bctor\u007D(&titerator, (TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E*) inputDescComboBoxPtr, 0U, 0);
    // ISSUE: fault handler
    try
    {
      int index = 0;
      if (\u003CModule\u003E.TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002E_N((TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator))
      {
        FNumericalInputInstance\u003Cint\u003E* inputInstanceIntPtr2 = (FNumericalInputInstance\u003Cint\u003E*) ((IntPtr) inputInstanceIntPtr1 + 36L);
        do
        {
          int* numPtr1 = \u003CModule\u003E.TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002EKey((TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator);
          num = *(int*) inputInstanceIntPtr2 == *numPtr1 ? index : num;
          comboBox.Items.Add((object) \u003CModule\u003E.CLRTools\u002EToString(\u003CModule\u003E.TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002EValue((TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator)));
          int* numPtr2 = \u003CModule\u003E.TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002EKey((TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator);
          minputDataContextInt.mValue[index] = *numPtr2;
          \u003CModule\u003E.TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002B\u002B((TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator);
          ++index;
        }
        while (\u003CModule\u003E.TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002E_N((TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator));
      }
      comboBox.DataContext = (object) minputDataContextInt;
      comboBox.SelectedIndex = num;
      comboBox.Height = 18.0;
      comboBox.SelectionChanged += new SelectionChangedEventHandler(this.ComboBoxChoiceChanged);
      Container.Children.Add((UIElement) label);
      Container.Children.Add((UIElement) comboBox);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bdtor\u007D), (void*) &titerator);
    }
    \u003CModule\u003E.TMapBase\u003Cint\u002CFString\u002C0\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bdtor\u007D(&titerator);
  }

  protected unsafe void BuildToggleButtonControl(
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputDesc,
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputInst,
    Grid Container)
  {
    Label label = new Label();
    label.Content = (object) \u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 24L));
    label.ToolTip = (object) \u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002E\u002D\u003E(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 8L));
    label.VerticalAlignment = VerticalAlignment.Center;
    CheckBox checkBox1 = new CheckBox();
    checkBox1.HorizontalAlignment = HorizontalAlignment.Right;
    CheckBox checkBox2 = checkBox1;
    checkBox2.Style = (Style) checkBox2.TryFindResource((object) "OnOffCheckbox");
    checkBox1.HorizontalAlignment = HorizontalAlignment.Left;
    bool? nullable = (bool?) (*(int*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst)) + 36L) == 1);
    checkBox1.IsChecked = nullable;
    checkBox1.Checked += new RoutedEventHandler(this.ToggleButtonChecked);
    checkBox1.Unchecked += new RoutedEventHandler(this.ToggleButtonUnchecked);
    MInputDataContext\u003Cfloat\u003E dataContextFloat = new MInputDataContext\u003Cfloat\u003E();
    dataContextFloat.mInputPtr.Reset(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst)));
    dataContextFloat.mGraphPtr.Reset(MGraphInstanceEditorWindow.ParentInstance);
    checkBox1.DataContext = (object) dataContextFloat;
    Container.Children.Add((UIElement) label);
    Container.Children.Add((UIElement) checkBox1);
  }

  protected Button ImageInputButtonFactory(string IconUrl)
  {
    Button button = new Button();
    button.Width = 18.0;
    button.Height = 18.0;
    button.HorizontalAlignment = HorizontalAlignment.Center;
    button.Background = (Brush) new ImageBrush((ImageSource) new BitmapImage(new Uri(IconUrl, UriKind.Absolute)));
    return button;
  }

  protected unsafe UIElement BuildImageInputControl(
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputDesc,
    TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E* ItInputInst)
  {
    StackPanel stackPanel1 = new StackPanel();
    Thickness thickness1 = new Thickness(0.0, 5.0, 0.0, 0.0);
    stackPanel1.Margin = thickness1;
    stackPanel1.Width = 195.0;
    stackPanel1.HorizontalAlignment = HorizontalAlignment.Left;
    MImageInputDataContext inputDataContext = new MImageInputDataContext();
    inputDataContext.mInputPtr.Reset(\u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst)));
    inputDataContext.mGraphPtr.Reset(MGraphInstanceEditorWindow.ParentInstance);
    Rectangle rectangle = new Rectangle();
    rectangle.RadiusX = 15.0;
    rectangle.RadiusY = 15.0;
    rectangle.Width = 64.0;
    rectangle.Height = 64.0;
    inputDataContext.mThumbnailRect = rectangle;
    ulong num = (ulong) *(long*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002E\u002A(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputInst)) + 56L);
    if (num != 0UL)
    {
      rectangle.Fill = (Brush) new ImageBrush((ImageSource) \u003CModule\u003E.ThumbnailToolsCLR\u002EGetBitmapSourceForObject((UObject*) num));
    }
    else
    {
      FString fstring1;
      FString* editorResourcesDir = \u003CModule\u003E.GetEditorResourcesDir(&fstring1);
      // ISSUE: fault handler
      try
      {
        FString fstring2;
        FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1EM\u0040MODEKJJE\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA_\u003F\u0024AAN\u003F\u0024AAo\u003F\u0024AAI\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAg\u003F\u0024AAe\u003F\u0024AAI\u003F\u0024AAn\u003F\u0024AAp\u003F\u0024AAu\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir));
        // ISSUE: fault handler
        try
        {
          rectangle.Fill = (Brush) new ImageBrush((ImageSource) new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute)));
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
    rectangle.DataContext = (object) inputDataContext;
    rectangle.AllowDrop = true;
    rectangle.DragOver += new DragEventHandler(this.OnDragOver);
    rectangle.Drop += new DragEventHandler(this.OnDrop);
    rectangle.DragEnter += new DragEventHandler(this.OnDragEnter);
    rectangle.DragLeave += new DragEventHandler(this.OnDragLeave);
    Label label = new Label();
    label.Content = (object) \u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002Eget(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 96L));
    label.ToolTip = (object) \u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002Eget(\u003CModule\u003E.TIndexedContainerIterator\u003CTArray\u003Cstd\u003A\u003Atr1\u003A\u003Ashared_ptr\u003CSubstanceAir\u003A\u003AFInputDescBase\u003E\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(ItInputDesc)) + 8L));
    label.VerticalAlignment = VerticalAlignment.Center;
    label.Margin.Bottom = 0.0;
    label.Margin.Left = 0.0;
    label.Margin.Top = 0.0;
    label.Margin.Right = 0.0;
    DockPanel dockPanel = new DockPanel();
    dockPanel.Children.Add((UIElement) rectangle);
    dockPanel.Children.Add((UIElement) label);
    stackPanel1.Children.Add((UIElement) dockPanel);
    StackPanel stackPanel2 = new StackPanel();
    stackPanel2.Orientation = Orientation.Horizontal;
    Thickness thickness2 = new Thickness(0.0, 2.0, 0.0, 0.0);
    stackPanel2.Margin = thickness2;
    stackPanel2.HorizontalAlignment = HorizontalAlignment.Left;
    FString fstring3;
    FString* editorResourcesDir1 = \u003CModule\u003E.GetEditorResourcesDir(&fstring3);
    Button button1;
    // ISSUE: fault handler
    try
    {
      FString fstring1;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FG\u0040MNDLGINM\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA_\u003F\u0024AAR\u003F\u0024AAe\u003F\u0024AAp\u003F\u0024AAl\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAI\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAg\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir1));
      // ISSUE: fault handler
      try
      {
        button1 = this.ImageInputButtonFactory(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
    button1.DataContext = (object) inputDataContext;
    button1.Click += new RoutedEventHandler(this.ImageInputReplaceButton_Click);
    Thickness thickness3 = new Thickness(3.0, 0.0, 0.0, 0.0);
    button1.Margin = thickness3;
    stackPanel2.Children.Add((UIElement) button1);
    FString fstring4;
    FString* editorResourcesDir2 = \u003CModule\u003E.GetEditorResourcesDir(&fstring4);
    Button button2;
    // ISSUE: fault handler
    try
    {
      FString fstring1;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1FE\u0040NNFLKIIE\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA_\u003F\u0024AAD\u003F\u0024AAe\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAt\u003F\u0024AAe\u003F\u0024AAI\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAg\u003F\u0024AAe\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir2));
      // ISSUE: fault handler
      try
      {
        button2 = this.ImageInputButtonFactory(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
    button2.DataContext = (object) inputDataContext;
    button2.Click += new RoutedEventHandler(this.ImageInputRemoveButton_Click);
    Thickness thickness4 = new Thickness(2.0, 0.0, 0.0, 0.0);
    button2.Margin = thickness4;
    stackPanel2.Children.Add((UIElement) button2);
    FString fstring5;
    FString* editorResourcesDir3 = \u003CModule\u003E.GetEditorResourcesDir(&fstring5);
    Button button3;
    // ISSUE: fault handler
    try
    {
      FString fstring1;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1EA\u0040GFNBHGBO\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA_\u003F\u0024AAS\u003F\u0024AAy\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAC\u003F\u0024AAB\u003F\u0024AA\u003F4\u003F\u0024AAp\u003F\u0024AAn\u003F\u0024AAg\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir3));
      // ISSUE: fault handler
      try
      {
        button3 = this.ImageInputButtonFactory(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)));
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
    button3.DataContext = (object) inputDataContext;
    button3.Click += new RoutedEventHandler(this.ImageInputSyncButton_Click);
    Thickness thickness5 = new Thickness(2.0, 0.0, 0.0, 0.0);
    button3.Margin = thickness5;
    stackPanel2.Children.Add((UIElement) button3);
    stackPanel1.Children.Add((UIElement) stackPanel2);
    return (UIElement) stackPanel1;
  }

  protected unsafe void OnDragEnter(object Sender, DragEventArgs Args)
  {
    if (!this.CanEdit() || !Args.Data.GetDataPresent(DataFormats.StringFormat))
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
        TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr = (TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.@new(16UL);
        TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E* InNativePointer;
        // ISSUE: fault handler
        try
        {
          InNativePointer = (IntPtr) fdefaultAllocatorPtr == IntPtr.Zero ? (TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr);
        }
        __fault
        {
          \u003CModule\u003E.delete((void*) fdefaultAllocatorPtr);
        }
        this.DroppedAssets.Reset(InNativePointer);
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

  protected unsafe void OnDragLeave(object Sender, DragEventArgs Args)
  {
    if (!this.CanEdit())
      return;
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E droppedAssets = this.DroppedAssets;
    if ((IntPtr) droppedAssets.Get() != IntPtr.Zero)
    {
      \u003CModule\u003E.TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002EEmpty(droppedAssets.op_MemberSelection(), 0);
      this.DroppedAssets.Reset((TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) 0L);
    }
    Args.Handled = true;
  }

  protected unsafe void OnDragOver(object Owner, DragEventArgs Args)
  {
    if (!this.CanEdit())
      return;
    Args.Effects = DragDropEffects.Copy;
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E droppedAssets = this.DroppedAssets;
    if ((IntPtr) droppedAssets.Get() != IntPtr.Zero)
    {
      TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, droppedAssets.Get());
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          FSelectedAssetInfo* fselectedAssetInfoPtr = \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt);
          if ((IntPtr) \u003CModule\u003E.Cast\u003Cclass\u0020USubstanceAirImageInput\u003E((UObject*) *(long*) ((IntPtr) fselectedAssetInfoPtr + 24L)) != IntPtr.Zero || (IntPtr) \u003CModule\u003E.Cast\u003Cclass\u0020USubstanceAirTexture2D\u003E((UObject*) *(long*) ((IntPtr) fselectedAssetInfoPtr + 24L)) != IntPtr.Zero)
            \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
          else
            goto label_6;
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
        goto label_7;
label_6:
        Args.Effects = DragDropEffects.None;
      }
    }
label_7:
    Args.Handled = true;
  }

  protected unsafe void OnDrop(object Owner, DragEventArgs Args)
  {
    if (!this.CanEdit())
      return;
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E droppedAssets = this.DroppedAssets;
    if ((IntPtr) droppedAssets.Get() != IntPtr.Zero)
    {
      TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, droppedAssets.Get());
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          UObject* uobjectPtr = \u003CModule\u003E.LoadObject\u003Cclass\u0020UObject\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt) + 8L)), (char*) 0L, 0U, (UPackageMap*) 0L);
          if ((IntPtr) \u003CModule\u003E.Cast\u003Cclass\u0020USubstanceAirImageInput\u003E(uobjectPtr) != IntPtr.Zero || (IntPtr) \u003CModule\u003E.Cast\u003Cclass\u0020USubstanceAirTexture2D\u003E(uobjectPtr) != IntPtr.Zero)
          {
            MImageInputDataContext dataContext = (MImageInputDataContext) ((FrameworkElement) Owner).DataContext;
            MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E finputInstanceBase = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(dataContext.mInputPtr.Get());
            MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
            if (\u003CModule\u003E.SubstanceAir\u002EFGraphInstance\u002EUpdateInput(airFgraphInstance.op_MemberSelection(), (uint*) ((IntPtr) finputInstanceBase.op_MemberSelection() + 8L), uobjectPtr) != 0)
            {
              UObject* InObject = (UObject*) *(long*) ((IntPtr) finputInstanceBase.Get() + 56L);
              if ((IntPtr) uobjectPtr != IntPtr.Zero && uobjectPtr == InObject)
                dataContext.mThumbnailRect.Fill = (Brush) new ImageBrush((ImageSource) \u003CModule\u003E.ThumbnailToolsCLR\u002EGetBitmapSourceForObject(InObject));
            }
            \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERenderAsync(airFgraphInstance.Get());
          }
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
      }
    }
    Args.Handled = true;
  }

  protected unsafe void ImageInputReplaceButton_Click(object Owner, RoutedEventArgs Args)
  {
    if (!this.CanEdit())
      return;
    FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr, ECallbackEventType)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 72L))((ECallbackEventType) gcallbackEvent, new IntPtr(24));
    UObject* top = \u003CModule\u003E.USelection\u002EGetTop(\u003CModule\u003E.UEditorEngine\u002EGetSelectedSet(\u003CModule\u003E.GEditor, \u003CModule\u003E.UObject\u002EStaticClass()), \u003CModule\u003E.UObject\u002EStaticClass());
    if ((IntPtr) \u003CModule\u003E.Cast\u003Cclass\u0020USubstanceAirImageInput\u003E(top) == IntPtr.Zero && (IntPtr) \u003CModule\u003E.Cast\u003Cclass\u0020USubstanceAirTexture2D\u003E(top) == IntPtr.Zero)
      return;
    MImageInputDataContext dataContext = (MImageInputDataContext) ((FrameworkElement) Owner).DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E finputInstanceBase = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(dataContext.mInputPtr.Get());
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
    if (\u003CModule\u003E.SubstanceAir\u002EFGraphInstance\u002EUpdateInput(airFgraphInstance.op_MemberSelection(), (uint*) ((IntPtr) finputInstanceBase.op_MemberSelection() + 8L), top) != 0)
    {
      UObject* InObject = (UObject*) *(long*) ((IntPtr) finputInstanceBase.Get() + 56L);
      if ((IntPtr) top != IntPtr.Zero && top == InObject)
        dataContext.mThumbnailRect.Fill = (Brush) new ImageBrush((ImageSource) \u003CModule\u003E.ThumbnailToolsCLR\u002EGetBitmapSourceForObject(InObject));
    }
    \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERenderAsync(airFgraphInstance.Get());
  }

  protected unsafe void ImageInputSyncButton_Click(object Owner, RoutedEventArgs Args)
  {
    if (!this.CanEdit())
      return;
    UObject* uobjectPtr = (UObject*) *(long*) ((IntPtr) ((MImageInputDataContext) ((FrameworkElement) Owner).DataContext).mInputPtr.Get() + 56L);
    if ((IntPtr) uobjectPtr == IntPtr.Zero)
      return;
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, &uobjectPtr);
      \u003CModule\u003E.WxEditorFrame\u002ESyncBrowserToObjects((WxEditorFrame*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &fdefaultAllocator);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  protected unsafe void ImageInputRemoveButton_Click(object Owner, RoutedEventArgs Args)
  {
    if (!this.CanEdit())
      return;
    MImageInputDataContext dataContext = (MImageInputDataContext) ((FrameworkElement) Owner).DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E finputInstanceBase = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(dataContext.mInputPtr.Get());
    \u003CModule\u003E.SubstanceAir\u002EFGraphInstance\u002EUpdateInput(new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get()).op_MemberSelection(), (uint*) ((IntPtr) finputInstanceBase.op_MemberSelection() + 8L), (UObject*) 0L);
    FString fstring1;
    FString* editorResourcesDir = \u003CModule\u003E.GetEditorResourcesDir(&fstring1);
    // ISSUE: fault handler
    try
    {
      FString fstring2;
      FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1EM\u0040MODEKJJE\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA_\u003F\u0024AAN\u003F\u0024AAo\u003F\u0024AAI\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAg\u003F\u0024AAe\u003F\u0024AAI\u003F\u0024AAn\u003F\u0024AAp\u003F\u0024AAu\u0040, \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir));
      // ISSUE: fault handler
      try
      {
        dataContext.mThumbnailRect.Fill = (Brush) new ImageBrush((ImageSource) new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute)));
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
    \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERenderAsync(dataContext.mGraphPtr.Get());
  }

  protected unsafe void CheckedOutput(object sender, RoutedEventArgs e)
  {
    if (!this.CanEdit())
      return;
    MOutputDataContext dataContext = (MOutputDataContext) ((FrameworkElement) sender).DataContext;
    if (0 == (*(int*) ((IntPtr) dataContext.mOutputPtr.op_MemberSelection() + 24L) & 1))
    {
      FString fstring;
      FString* fstringPtr1 = &fstring;
      FString* fstringPtr2 = \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring);
      FOutputInstance* foutputInstancePtr;
      // ISSUE: fault handler
      try
      {
        foutputInstancePtr = dataContext.mOutputPtr.Get();
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) fstringPtr1);
      }
      \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ECreateTexture2D(foutputInstancePtr, fstringPtr2);
      List\u003CSubstanceAir\u003A\u003AFGraphInstance\u0020\u002A\u003E airFgraphInstance;
      \u003CModule\u003E.SubstanceAir\u002EList\u003CSubstanceAir\u003A\u003AFGraphInstance\u0020\u002A\u003E\u002E\u007Bctor\u007D(&airFgraphInstance);
      // ISSUE: fault handler
      try
      {
        FGraphInstance* fgraphInstancePtr = dataContext.mGraphPtr.Get();
        \u003CModule\u003E.SubstanceAir\u002EList\u003CSubstanceAir\u003A\u003AFGraphInstance\u0020\u002A\u003E\u002Epush(&airFgraphInstance, &fgraphInstancePtr);
        \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERenderAsync(&airFgraphInstance);
        \u003CModule\u003E.SubstanceAir\u002EHelpers\u002EFlagRefreshContentBrowser(1);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(SubstanceAir\u002EList\u003CSubstanceAir\u003A\u003AFGraphInstance\u0020\u002A\u003E\u002E\u007Bdtor\u007D), (void*) &airFgraphInstance);
      }
      \u003CModule\u003E.SubstanceAir\u002EList\u003CSubstanceAir\u003A\u003AFGraphInstance\u0020\u002A\u003E\u002E\u007Bdtor\u007D(&airFgraphInstance);
    }
    e.Handled = true;
  }

  protected unsafe void UncheckedOutput(object sender, RoutedEventArgs e)
  {
    if (!this.CanEdit())
      return;
    MOutputDataContext dataContext = (MOutputDataContext) ((FrameworkElement) sender).DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFOutputInstance\u003E mOutputPtr = dataContext.mOutputPtr;
    if ((*(int*) ((IntPtr) mOutputPtr.op_MemberSelection() + 24L) & 1) != 0 && *(long*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CUSubstanceAirTexture2D\u0020\u002A\u003E\u002E\u002A((shared_ptr\u003CUSubstanceAirTexture2D\u0020\u002A\u003E*) ((IntPtr) mOutputPtr.op_MemberSelection() + 32L)) != 0L)
    {
      \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERegisterForDeletion((USubstanceAirTexture2D*) *(long*) \u003CModule\u003E.std\u002Etr1\u002Eshared_ptr\u003CUSubstanceAirTexture2D\u0020\u002A\u003E\u002E\u002A((shared_ptr\u003CUSubstanceAirTexture2D\u0020\u002A\u003E*) ((IntPtr) dataContext.mOutputPtr.op_MemberSelection() + 32L)));
      \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ETick();
    }
    e.Handled = true;
  }

  protected unsafe void ToggleButtonSetValue(
    MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E InputPtr,
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E InstancePtr,
    [MarshalAs(UnmanagedType.U1)] bool isChecked)
  {
    if (!this.CanEdit() || !InputPtr.IsValid() || !InstancePtr.IsValid())
      return;
    TArray\u003Cint\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      int num = isChecked ? 1 : 0;
      \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, &num);
      \u003CModule\u003E.SubstanceAir\u002EFGraphInstance\u002EUpdateInput\u003Cint\u003E(InstancePtr.op_MemberSelection(), (uint*) ((IntPtr) InputPtr.op_MemberSelection() + 8L), &fdefaultAllocator);
      \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERenderAsync(InstancePtr.Get());
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  protected unsafe void ToggleButtonChecked(object sender, RoutedEventArgs e)
  {
    if (!this.CanEdit())
      return;
    MInputDataContext\u003Cfloat\u003E dataContext = (MInputDataContext\u003Cfloat\u003E) ((FrameworkElement) sender).DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
    if (!airFgraphInstance.IsValid())
      return;
    FString fstring;
    FString* fstringPtr = \u003CModule\u003E.Localize(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1O\u0040PNHGCNJL\u0040\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040JAOOKING\u0040\u003F\u0024AAM\u003F\u0024AAo\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAe\u003F\u0024AAd\u003F\u0024AAI\u003F\u0024AAn\u003F\u0024AAp\u003F\u0024AAu\u003F\u0024AAt\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BK\u0040PODDHOFJ\u0040\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L, 0U);
    FScopedTransaction fscopedTransaction;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FScopedTransaction\u002E\u007Bctor\u007D(&fscopedTransaction, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E InstancePtr = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
      this.ToggleButtonSetValue(new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(dataContext.mInputPtr.Get()), InstancePtr, true);
      long num1 = *(long*) ((IntPtr) airFgraphInstance.op_MemberSelection() + 72L);
      long num2 = num1;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, uint)>) *(long*) (*(long*) num1 + 48L))((uint) num2, new IntPtr(1));
      e.Handled = true;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FScopedTransaction\u002E\u007Bdtor\u007D), (void*) &fscopedTransaction);
    }
    \u003CModule\u003E.FScopedTransaction\u002E\u007Bdtor\u007D(&fscopedTransaction);
  }

  protected unsafe void ToggleButtonUnchecked(object sender, RoutedEventArgs e)
  {
    if (!this.CanEdit())
      return;
    MInputDataContext\u003Cfloat\u003E dataContext = (MInputDataContext\u003Cfloat\u003E) ((FrameworkElement) sender).DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
    if (!airFgraphInstance.IsValid())
      return;
    FString fstring;
    FString* fstringPtr = \u003CModule\u003E.Localize(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1O\u0040PNHGCNJL\u0040\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040JAOOKING\u0040\u003F\u0024AAM\u003F\u0024AAo\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAe\u003F\u0024AAd\u003F\u0024AAI\u003F\u0024AAn\u003F\u0024AAp\u003F\u0024AAu\u003F\u0024AAt\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BK\u0040PODDHOFJ\u0040\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L, 0U);
    FScopedTransaction fscopedTransaction;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FScopedTransaction\u002E\u007Bctor\u007D(&fscopedTransaction, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E InstancePtr = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
      this.ToggleButtonSetValue(new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(dataContext.mInputPtr.Get()), InstancePtr, false);
      long num1 = *(long*) ((IntPtr) airFgraphInstance.op_MemberSelection() + 72L);
      long num2 = num1;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, uint)>) *(long*) (*(long*) num1 + 48L))((uint) num2, new IntPtr(1));
      e.Handled = true;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FScopedTransaction\u002E\u007Bdtor\u007D), (void*) &fscopedTransaction);
    }
    \u003CModule\u003E.FScopedTransaction\u002E\u007Bdtor\u007D(&fscopedTransaction);
  }

  protected unsafe void RandomizeButtonPressed(object Sender, RoutedEventArgs e)
  {
    if (!this.CanEdit())
      return;
    MRandomizeDataContext dataContext = (MRandomizeDataContext) ((FrameworkElement) Sender).DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
    if (!airFgraphInstance.IsValid())
      return;
    FString fstring;
    FString* fstringPtr = \u003CModule\u003E.Localize(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1O\u0040PNHGCNJL\u0040\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040JAOOKING\u0040\u003F\u0024AAM\u003F\u0024AAo\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAe\u003F\u0024AAd\u003F\u0024AAI\u003F\u0024AAn\u003F\u0024AAp\u003F\u0024AAu\u003F\u0024AAt\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BK\u0040PODDHOFJ\u0040\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L, 0U);
    FScopedTransaction fscopedTransaction;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FScopedTransaction\u002E\u007Bctor\u007D(&fscopedTransaction, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      long num1 = *(long*) ((IntPtr) airFgraphInstance.op_MemberSelection() + 72L);
      long num2 = num1;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, uint)>) *(long*) (*(long*) num1 + 48L))((uint) num2, new IntPtr(1));
      ((RangeBase) dataContext.mRandomSlider).Value = (double) \u003CModule\u003E.appRand();
      e.Handled = true;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FScopedTransaction\u002E\u007Bdtor\u007D), (void*) &fscopedTransaction);
    }
    \u003CModule\u003E.FScopedTransaction\u002E\u007Bdtor\u007D(&fscopedTransaction);
  }

  protected unsafe void ResetToDefaultPressed(object Sender, RoutedEventArgs e)
  {
    if (!this.CanEdit())
      return;
    \u003CModule\u003E.SubstanceAir\u002EHelpers\u002EResetToDefault(MGraphInstanceEditorWindow.ParentInstance);
    this.BuildInputList();
    this.BuildImageInputList();
    \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERenderAsync(MGraphInstanceEditorWindow.ParentInstance);
  }

  protected unsafe void PickColorPressed(object Sender, RoutedEventArgs e)
  {
    if (!this.CanEdit())
      return;
    PickColorDataContext dataContext = (PickColorDataContext) ((FrameworkElement) Sender).DataContext;
    this.CurrentColorEdited = dataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
    if (!airFgraphInstance.IsValid())
      return;
    FString fstring;
    FString* fstringPtr = \u003CModule\u003E.Localize(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1O\u0040PNHGCNJL\u0040\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040JAOOKING\u0040\u003F\u0024AAM\u003F\u0024AAo\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAe\u003F\u0024AAd\u003F\u0024AAI\u003F\u0024AAn\u003F\u0024AAp\u003F\u0024AAu\u003F\u0024AAt\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BK\u0040PODDHOFJ\u0040\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L, 0U);
    FScopedTransaction fscopedTransaction;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FScopedTransaction\u002E\u007Bctor\u007D(&fscopedTransaction, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      long num1 = *(long*) ((IntPtr) airFgraphInstance.op_MemberSelection() + 72L);
      long num2 = num1;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, uint)>) *(long*) (*(long*) num1 + 48L))((uint) num2, new IntPtr(1));
      \u003CModule\u003E.CloseColorPickers();
      float num3 = (float) ((RangeBase) this.CurrentColorEdited.mSliderRed).Value;
      *(float*) this.PickColorData = num3;
      PickColorDataContext currentColorEdited1 = this.CurrentColorEdited;
      currentColorEdited1.StartR = (double) num3;
      float num4 = (float) ((RangeBase) currentColorEdited1.mSliderGreen).Value;
      *(float*) ((IntPtr) this.PickColorData + 4L) = num4;
      PickColorDataContext currentColorEdited2 = this.CurrentColorEdited;
      currentColorEdited2.StartG = (double) num4;
      float num5 = (float) ((RangeBase) currentColorEdited2.mSliderBlue).Value;
      *(float*) ((IntPtr) this.PickColorData + 8L) = num5;
      PickColorDataContext currentColorEdited3 = this.CurrentColorEdited;
      currentColorEdited3.StartB = (double) num5;
      if (currentColorEdited3.mSliderAlpha != null)
      {
        float num6 = (float) ((RangeBase) currentColorEdited3.mSliderAlpha).Value;
        *(float*) ((IntPtr) this.PickColorData + 12L) = num6;
        this.CurrentColorEdited.StartA = (double) num6;
      }
      int num7 = (int) \u003CModule\u003E.PickColorWPF(this.PickColorStruct);
      this.CurrentColorEdited.ColorPickerIndex = MColorPickerPanel.GetNumColorPickerPanels() - 1U;
      MColorPickerPanel staticColorPicker = MColorPickerPanel.GetStaticColorPicker(this.CurrentColorEdited.ColorPickerIndex);
      staticColorPicker.AddCallbackDelegate(new ColorPickerPropertyChangeFunction(this.UpdatePreviewColors));
      Button logicalNode = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) staticColorPicker, "CancelButton");
      logicalNode.Click += new RoutedEventHandler(this.CancelColorClicked);
      logicalNode.Click += new RoutedEventHandler(this.OkColorClicked);
      e.Handled = true;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FScopedTransaction\u002E\u007Bdtor\u007D), (void*) &fscopedTransaction);
    }
    \u003CModule\u003E.FScopedTransaction\u002E\u007Bdtor\u007D(&fscopedTransaction);
  }

  protected void OkColorClicked(object Owner, RoutedEventArgs Args) => this.CurrentColorEdited = (PickColorDataContext) null;

  protected void CancelColorClicked(object Owner, RoutedEventArgs Args)
  {
    PickColorDataContext currentColorEdited = this.CurrentColorEdited;
    this.CurrentColorEdited = (PickColorDataContext) null;
    ((RangeBase) currentColorEdited.mSliderRed).Value = currentColorEdited.StartR;
    ((RangeBase) currentColorEdited.mSliderGreen).Value = currentColorEdited.StartG;
    ((RangeBase) currentColorEdited.mSliderBlue).Value = currentColorEdited.StartB;
    DragSlider mSliderAlpha = currentColorEdited.mSliderAlpha;
    if (mSliderAlpha == null)
      return;
    ((RangeBase) mSliderAlpha).Value = currentColorEdited.StartA;
  }

  protected unsafe void UpdatePreviewColors()
  {
    MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E finputInstanceBase = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(this.CurrentColorEdited.mInputPtr.Get());
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(this.CurrentColorEdited.mGraphPtr.Get());
    if (!finputInstanceBase.IsValid() || !airFgraphInstance.IsValid())
      return;
    TArray\u003Cfloat\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator, 4);
    // ISSUE: fault handler
    try
    {
      FLinearColor* pickColorData = this.PickColorData;
      *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, 0) = *(float*) pickColorData;
      FLinearColor* flinearColorPtr1 = (FLinearColor*) ((IntPtr) this.PickColorData + 4L);
      *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, 1) = *(float*) flinearColorPtr1;
      FLinearColor* flinearColorPtr2 = (FLinearColor*) ((IntPtr) this.PickColorData + 8L);
      *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, 2) = *(float*) flinearColorPtr2;
      FLinearColor* flinearColorPtr3 = (FLinearColor*) ((IntPtr) this.PickColorData + 12L);
      *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, 3) = *(float*) flinearColorPtr3;
      this.CurrentColorEdited.bSyncEnabled = false;
      ((RangeBase) this.CurrentColorEdited.mSliderRed).Value = (double) *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, 0);
      ((RangeBase) this.CurrentColorEdited.mSliderGreen).Value = (double) *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, 1);
      ((RangeBase) this.CurrentColorEdited.mSliderBlue).Value = (double) *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, 2);
      if (this.CurrentColorEdited.mSliderAlpha != null)
        ((RangeBase) this.CurrentColorEdited.mSliderAlpha).Value = (double) *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, 3);
      this.CurrentColorEdited.bSyncEnabled = true;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  protected unsafe void ComboBoxChoiceChanged(object sender, SelectionChangedEventArgs e)
  {
    if (!this.CanEdit())
      return;
    ComboBox comboBox = (ComboBox) sender;
    MInputDataContext\u003Cint\u003E dataContext = (MInputDataContext\u003Cint\u003E) comboBox.DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E finputInstanceBase = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(dataContext.mInputPtr.Get());
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
    if (finputInstanceBase.IsValid() && airFgraphInstance.IsValid())
    {
      FString fstring;
      FString* fstringPtr = \u003CModule\u003E.Localize(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1O\u0040PNHGCNJL\u0040\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040JAOOKING\u0040\u003F\u0024AAM\u003F\u0024AAo\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAe\u003F\u0024AAd\u003F\u0024AAI\u003F\u0024AAn\u003F\u0024AAp\u003F\u0024AAu\u003F\u0024AAt\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BK\u0040PODDHOFJ\u0040\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L, 0U);
      FScopedTransaction fscopedTransaction;
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FScopedTransaction\u002E\u007Bctor\u007D(&fscopedTransaction, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
        long num1 = *(long*) ((IntPtr) airFgraphInstance.op_MemberSelection() + 72L);
        long num2 = num1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, uint)>) *(long*) (*(long*) num1 + 48L))((uint) num2, new IntPtr(1));
        TArray\u003Cint\u002CFDefaultAllocator\u003E fdefaultAllocator;
        \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
        // ISSUE: fault handler
        try
        {
          int num3 = dataContext.mValue[comboBox.SelectedIndex];
          \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, &num3);
          \u003CModule\u003E.SubstanceAir\u002EFGraphInstance\u002EUpdateInput\u003Cint\u003E(airFgraphInstance.op_MemberSelection(), (uint*) ((IntPtr) finputInstanceBase.op_MemberSelection() + 8L), &fdefaultAllocator);
          \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERenderAsync(airFgraphInstance.Get());
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
        }
        \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FScopedTransaction\u002E\u007Bdtor\u007D), (void*) &fscopedTransaction);
      }
      \u003CModule\u003E.FScopedTransaction\u002E\u007Bdtor\u007D(&fscopedTransaction);
    }
    e.Handled = true;
  }

  protected unsafe void Pow2Changed(object sender, SelectionChangedEventArgs e)
  {
    if (!this.CanEdit())
      return;
    ComboBox comboBox = (ComboBox) sender;
    MSizePow2Context dataContext1 = (MSizePow2Context) comboBox.DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E finputInstanceBase = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(dataContext1.mInputPtr.Get());
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext1.mGraphPtr.Get());
    if (finputInstanceBase.IsValid() && airFgraphInstance.IsValid() && !dataContext1.mSkipUpdate)
    {
      FNumericalInputInstanceBase* inputInstanceBasePtr = (FNumericalInputInstanceBase*) finputInstanceBase.Get();
      TArray\u003Cint\u002CFDefaultAllocator\u003E fdefaultAllocator;
      \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.SubstanceAir\u002EFNumericalInputInstanceBase\u002EGetValue\u003Cint\u003E(inputInstanceBasePtr, &fdefaultAllocator);
        int mIndex = dataContext1.mIndex;
        int num1 = mIndex != 0 ? 0 : 1;
        int num2 = *\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, mIndex);
        int num3 = \u003CModule\u003E.Clamp\u003Cint\u003E(comboBox.SelectedIndex + 5, 5, 11);
        *\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, mIndex) = num3;
        if (dataContext1.mRatioLock.IsChecked.Equals((object) true))
        {
          int num4 = num3 - num2;
          int num5 = \u003CModule\u003E.Clamp\u003Cint\u003E(*\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num1) + num4, 5, 11);
          *\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, num1) = num5;
          MSizePow2Context dataContext2 = (MSizePow2Context) dataContext1.mOtherSize.DataContext;
          dataContext2.mSkipUpdate = true;
          dataContext1.mOtherSize.SelectedIndex = num5 - 5;
          dataContext2.mSkipUpdate = false;
        }
        int num6 = \u003CModule\u003E.SubstanceAir\u002EFGraphInstance\u002EUpdateInput\u003Cint\u003E(airFgraphInstance.op_MemberSelection(), (uint*) ((IntPtr) finputInstanceBase.op_MemberSelection() + 8L), &fdefaultAllocator);
        \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERenderAsync(airFgraphInstance.Get());
        \u003CModule\u003E.SubstanceAir\u002EHelpers\u002EFlagRefreshContentBrowser(num6);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
      }
      \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    }
    e.Handled = true;
  }

  protected unsafe void SliderMouseDown(object Sender, MouseButtonEventArgs e)
  {
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(((MInputDataContext\u003Cfloat\u003E) ((FrameworkElement) Sender).DataContext).mGraphPtr.Get());
    if (!airFgraphInstance.IsValid())
      return;
    FString fstring;
    FString* fstringPtr = \u003CModule\u003E.Localize(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1O\u0040PNHGCNJL\u0040\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAt\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040JAOOKING\u0040\u003F\u0024AAM\u003F\u0024AAo\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAe\u003F\u0024AAd\u003F\u0024AAI\u003F\u0024AAn\u003F\u0024AAp\u003F\u0024AAu\u003F\u0024AAt\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BK\u0040PODDHOFJ\u0040\u003F\u0024AAS\u003F\u0024AAu\u003F\u0024AAb\u003F\u0024AAs\u003F\u0024AAt\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAc\u003F\u0024AAe\u003F\u0024AAA\u003F\u0024AAi\u003F\u0024AAr\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L, 0U);
    FScopedTransaction fscopedTransaction;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FScopedTransaction\u002E\u007Bctor\u007D(&fscopedTransaction, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      long num1 = *(long*) ((IntPtr) airFgraphInstance.op_MemberSelection() + 72L);
      long num2 = num1;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr, uint)>) *(long*) (*(long*) num1 + 48L))((uint) num2, new IntPtr(1));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FScopedTransaction\u002E\u007Bdtor\u007D), (void*) &fscopedTransaction);
    }
    \u003CModule\u003E.FScopedTransaction\u002E\u007Bdtor\u007D(&fscopedTransaction);
  }

  protected unsafe void SliderValueChanged\u003Cfloat\u003E(
    object sender,
    RoutedPropertyChangedEventArgs<double> e)
  {
    if (!this.CanEdit())
      return;
    MInputDataContext\u003Cfloat\u003E dataContext = (MInputDataContext\u003Cfloat\u003E) ((FrameworkElement) sender).DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E finputInstanceBase = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(dataContext.mInputPtr.Get());
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
    if (finputInstanceBase.IsValid() && airFgraphInstance.IsValid())
    {
      FNumericalInputInstanceBase* inputInstanceBasePtr = (FNumericalInputInstanceBase*) finputInstanceBase.Get();
      TArray\u003Cfloat\u002CFDefaultAllocator\u003E fdefaultAllocator;
      \u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.SubstanceAir\u002EFNumericalInputInstanceBase\u002EGetValue\u003Cfloat\u003E(inputInstanceBasePtr, &fdefaultAllocator);
        if (\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator) != 0)
          goto label_6;
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
      }
      \u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
      return;
label_6:
      // ISSUE: fault handler
      try
      {
        float newValue1 = (float) e.NewValue;
        *\u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, dataContext.mIndex) = newValue1;
        if (*(int*) (*(long*) ((IntPtr) inputInstanceBasePtr + 20L) + 56L) == 3 && \u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator) >= 3)
        {
          float newValue2 = (float) e.NewValue;
          *\u003CModule\u003E.FLinearColor\u002EComponent(this.PickColorData, dataContext.mIndex) = newValue2;
          float* numPtr1 = \u003CModule\u003E.FLinearColor\u002EComponent(this.PickColorData, 2);
          float* numPtr2 = \u003CModule\u003E.FLinearColor\u002EComponent(this.PickColorData, 1);
          Color color = Color.FromArgb(byte.MaxValue, (byte) ((int) (uint) ((double) *\u003CModule\u003E.FLinearColor\u002EComponent(this.PickColorData, 0) * (double) byte.MaxValue) & (int) byte.MaxValue), (byte) ((int) (uint) ((double) *numPtr2 * (double) byte.MaxValue) & (int) byte.MaxValue), (byte) ((int) (uint) ((double) *numPtr1 * (double) byte.MaxValue) & (int) byte.MaxValue));
          dataContext.mPickButton.Background = (Brush) new SolidColorBrush(color);
        }
        \u003CModule\u003E.SubstanceAir\u002EFGraphInstance\u002EUpdateInput\u003Cfloat\u003E(airFgraphInstance.op_MemberSelection(), (uint*) ((IntPtr) finputInstanceBase.op_MemberSelection() + 8L), &fdefaultAllocator);
        \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERenderAsync(airFgraphInstance.Get());
        PickColorDataContext currentColorEdited = this.CurrentColorEdited;
        if (currentColorEdited != null)
        {
          if (currentColorEdited.bSyncEnabled)
            MColorPickerPanel.GetStaticColorPicker(currentColorEdited.ColorPickerIndex).BindData();
        }
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
      }
      \u003CModule\u003E.TArray\u003Cfloat\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    }
    e.Handled = true;
  }

  protected unsafe void SliderValueChanged\u003Cint\u003E(
    object sender,
    RoutedPropertyChangedEventArgs<double> e)
  {
    if (!this.CanEdit())
      return;
    MInputDataContext\u003Cint\u003E dataContext = (MInputDataContext\u003Cint\u003E) ((FrameworkElement) sender).DataContext;
    MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E finputInstanceBase = new MNativePointer\u003CSubstanceAir\u003A\u003AFInputInstanceBase\u003E(dataContext.mInputPtr.Get());
    MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E airFgraphInstance = new MNativePointer\u003CSubstanceAir\u003A\u003AFGraphInstance\u003E(dataContext.mGraphPtr.Get());
    if (finputInstanceBase.IsValid() && airFgraphInstance.IsValid())
    {
      FNumericalInputInstanceBase* inputInstanceBasePtr = (FNumericalInputInstanceBase*) finputInstanceBase.Get();
      TArray\u003Cint\u002CFDefaultAllocator\u003E fdefaultAllocator;
      \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.SubstanceAir\u002EFNumericalInputInstanceBase\u002EGetValue\u003Cint\u003E(inputInstanceBasePtr, &fdefaultAllocator);
        if (\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator) != 0)
          goto label_6;
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
      }
      \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
      return;
label_6:
      // ISSUE: fault handler
      try
      {
        int newValue1 = (int) e.NewValue;
        *\u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, dataContext.mIndex) = newValue1;
        if (*(int*) (*(long*) ((IntPtr) inputInstanceBasePtr + 20L) + 56L) == 3 && \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator) >= 3)
        {
          float newValue2 = (float) e.NewValue;
          *\u003CModule\u003E.FLinearColor\u002EComponent(this.PickColorData, dataContext.mIndex) = newValue2;
          float* numPtr1 = \u003CModule\u003E.FLinearColor\u002EComponent(this.PickColorData, 2);
          float* numPtr2 = \u003CModule\u003E.FLinearColor\u002EComponent(this.PickColorData, 1);
          Color color = Color.FromArgb(byte.MaxValue, (byte) ((int) (uint) ((double) *\u003CModule\u003E.FLinearColor\u002EComponent(this.PickColorData, 0) * (double) byte.MaxValue) & (int) byte.MaxValue), (byte) ((int) (uint) ((double) *numPtr2 * (double) byte.MaxValue) & (int) byte.MaxValue), (byte) ((int) (uint) ((double) *numPtr1 * (double) byte.MaxValue) & (int) byte.MaxValue));
          dataContext.mPickButton.Background = (Brush) new SolidColorBrush(color);
        }
        \u003CModule\u003E.SubstanceAir\u002EFGraphInstance\u002EUpdateInput\u003Cint\u003E(airFgraphInstance.op_MemberSelection(), (uint*) ((IntPtr) finputInstanceBase.op_MemberSelection() + 8L), &fdefaultAllocator);
        \u003CModule\u003E.SubstanceAir\u002EHelpers\u002ERenderAsync(airFgraphInstance.Get());
        PickColorDataContext currentColorEdited = this.CurrentColorEdited;
        if (currentColorEdited != null)
        {
          if (currentColorEdited.bSyncEnabled)
            MColorPickerPanel.GetStaticColorPicker(currentColorEdited.ColorPickerIndex).BindData();
        }
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
      }
      \u003CModule\u003E.TArray\u003Cint\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    }
    e.Handled = true;
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
        this.DroppedAssets.Dispose();
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
