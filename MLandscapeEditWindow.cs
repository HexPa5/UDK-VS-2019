// Decompiled with JetBrains decompiler
// Type: MLandscapeEditWindow
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using \u003CCppImplementationDetails\u003E;
using CustomControls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UnrealEd;
using WPF_Landscape;

internal class MLandscapeEditWindow : MWPFWindowWrapper, INotifyPropertyChanged
{
  private Button ImportButton;
  private Button GizmoLayerRemoveButton;
  private Button GizmoImportButton;
  private Button ChangeComponentSizeButton;
  private Button UpdateLODBiasButton;
  private CheckBox MaskEnableCheckBox;
  private CheckBox InvertMaskCheckBox;
  private MEnumerableTArrayWrapper\u003CMLandscapeListWrapper\u002CFLandscapeListInfo\u003E LandscapeListsValue;
  private ComboBox LandscapeComboBox;
  private Label LandscapeCompNum;
  private Label CollisionCompNum;
  private Label CompQuadNum;
  private Label QuadPerSection;
  private Label SubsectionNum;
  private TextBlock CurrentWidth;
  private TextBlock CurrentHeight;
  private int CurrentLandscapeIndexValue;
  private string HeightmapFileNameStringValue;
  private int WidthValue;
  private int HeightValue;
  private int SectionSizeValue;
  private int NumSectionsValue;
  private int TotalComponentsValue;
  public LandscapeImportLayers LandscapeImportLayersValue;
  private int ConvertWidthValue;
  private int ConvertHeightValue;
  private int ConvertSectionSizeValue;
  private int ConvertNumSectionsValue;
  private int ConvertTotalComponentsValue;
  private int ConvertCompQuadNumValue;
  private string GizmoHeightmapFileNameStringValue;
  private int GizmoImportWidthValue;
  private int GizmoImportHeightValue;
  public MEnumerableTArrayWrapper\u003CMGizmoImportLayerWrapper\u002CFGizmoImportLayer\u003E GizmoImportLayersValue;
  public uint bExportLayers;
  public MEnumerableTArrayWrapper\u003CMLandscapeTargetListWrapper\u002CFLandscapeTargetListInfo\u003E LandscapeTargetsValue;
  public ListBox TargetListBox;
  public ListBox GizmoListBox;
  public MEnumerableTArrayWrapper\u003CMGizmoHistoryWrapper\u002CFGizmoHistory\u003E GizmoHistoriesValue;
  private int CurrentGizmoIndexValue;
  public ListBox GizmoDataListBox;
  public MEnumerableTArrayWrapper\u003CMGizmoDataWrapper\u002CFGizmoData\u003E GizmoDataValue;
  private int CurrentGizmoDataIndexValue;
  public uint bNoBlending;
  private string AddLayerNameStringValue;
  private float HardnessValue;
  public DragSlider BrushRadiusSlider;
  public DragSlider BrushSizeSlider;
  public Button AlphaTextureUseRButton;
  public Button AlphaTextureUseGButton;
  public Button AlphaTextureUseBButton;
  public Button AlphaTextureUseAButton;
  private BitmapSource AlphaTextureValue;
  public DragSlider LODBiasThresholdSlider;
  public int HeightmapFileSize;
  public int GizmoFileSize;
  public string LastImportPath;
  protected readonly MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E DroppedAssets;
  protected unsafe FEdModeLandscape* LandscapeEditSystem;

  public int CurrentLandscapeIndex
  {
    get => this.CurrentLandscapeIndexValue;
    set
    {
      if (this.CurrentLandscapeIndexValue == value)
        return;
      this.CurrentLandscapeIndexValue = value;
      this.OnPropertyChanged(nameof (CurrentLandscapeIndex));
    }
  }

  public MEnumerableTArrayWrapper\u003CMLandscapeListWrapper\u002CFLandscapeListInfo\u003E LandscapeListsProperty
  {
    get => this.LandscapeListsValue;
    set
    {
      if (value == this.LandscapeListsValue)
        return;
      this.LandscapeListsValue = value;
      this.OnPropertyChanged(nameof (LandscapeListsProperty));
    }
  }

  public string HeightmapFileNameString
  {
    get => this.HeightmapFileNameStringValue;
    set
    {
      if (!(this.HeightmapFileNameStringValue != value))
        return;
      this.HeightmapFileNameStringValue = value;
      this.OnPropertyChanged(nameof (HeightmapFileNameString));
    }
  }

  public int Width
  {
    get => this.WidthValue;
    set
    {
      if (this.WidthValue == value)
        return;
      this.WidthValue = value;
      this.OnPropertyChanged(nameof (Width));
    }
  }

  public int Height
  {
    get => this.HeightValue;
    set
    {
      if (this.HeightValue == value)
        return;
      this.HeightValue = value;
      this.OnPropertyChanged(nameof (Height));
    }
  }

  public int SectionSize
  {
    get => this.SectionSizeValue;
    set
    {
      if (this.SectionSizeValue == value)
        return;
      this.SectionSizeValue = value;
      this.OnPropertyChanged(nameof (SectionSize));
    }
  }

  public int NumSections
  {
    get => this.NumSectionsValue;
    set
    {
      if (this.NumSectionsValue == value)
        return;
      this.NumSectionsValue = value;
      this.OnPropertyChanged(nameof (NumSections));
    }
  }

  public int TotalComponents
  {
    get => this.TotalComponentsValue;
    set
    {
      if (this.TotalComponentsValue == value)
        return;
      this.TotalComponentsValue = value;
      this.OnPropertyChanged(nameof (TotalComponents));
    }
  }

  public LandscapeImportLayers LandscapeImportLayersProperty
  {
    get => this.LandscapeImportLayersValue;
    set
    {
      if (value == this.LandscapeImportLayersValue)
        return;
      this.LandscapeImportLayersValue = value;
      this.OnPropertyChanged(nameof (LandscapeImportLayersProperty));
    }
  }

  public int ConvertWidth
  {
    get => this.ConvertWidthValue;
    set
    {
      if (this.ConvertWidthValue == value)
        return;
      this.ConvertWidthValue = value;
      this.OnPropertyChanged(nameof (ConvertWidth));
    }
  }

  public int ConvertHeight
  {
    get => this.ConvertHeightValue;
    set
    {
      if (this.ConvertHeightValue == value)
        return;
      this.ConvertHeightValue = value;
      this.OnPropertyChanged(nameof (ConvertHeight));
    }
  }

  public int ConvertSectionSize
  {
    get => this.ConvertSectionSizeValue;
    set
    {
      if (this.ConvertSectionSizeValue == value)
        return;
      this.ConvertSectionSizeValue = value;
      this.OnPropertyChanged(nameof (ConvertSectionSize));
    }
  }

  public int ConvertNumSections
  {
    get => this.ConvertNumSectionsValue;
    set
    {
      if (this.ConvertNumSectionsValue == value)
        return;
      this.ConvertNumSectionsValue = value;
      this.OnPropertyChanged(nameof (ConvertNumSections));
    }
  }

  public int ConvertTotalComponents
  {
    get => this.ConvertTotalComponentsValue;
    set
    {
      if (this.ConvertTotalComponentsValue == value)
        return;
      this.ConvertTotalComponentsValue = value;
      this.OnPropertyChanged(nameof (ConvertTotalComponents));
    }
  }

  public int ConvertCompQuadNum
  {
    get => this.ConvertCompQuadNumValue;
    set
    {
      if (this.ConvertCompQuadNumValue == value)
        return;
      this.ConvertCompQuadNumValue = value;
      this.OnPropertyChanged(nameof (ConvertCompQuadNum));
    }
  }

  public string GizmoHeightmapFileNameString
  {
    get => this.GizmoHeightmapFileNameStringValue;
    set
    {
      if (!(this.GizmoHeightmapFileNameStringValue != value))
        return;
      this.GizmoHeightmapFileNameStringValue = value;
      this.OnPropertyChanged(nameof (GizmoHeightmapFileNameString));
    }
  }

  public int GizmoImportWidth
  {
    get => this.GizmoImportWidthValue;
    set
    {
      if (this.GizmoImportWidthValue == value)
        return;
      this.GizmoImportWidthValue = value;
      this.OnPropertyChanged(nameof (GizmoImportWidth));
    }
  }

  public int GizmoImportHeight
  {
    get => this.GizmoImportHeightValue;
    set
    {
      if (this.GizmoImportHeightValue == value)
        return;
      this.GizmoImportHeightValue = value;
      this.OnPropertyChanged(nameof (GizmoImportHeight));
    }
  }

  public MEnumerableTArrayWrapper\u003CMGizmoImportLayerWrapper\u002CFGizmoImportLayer\u003E GizmoImportLayersProperty
  {
    get => this.GizmoImportLayersValue;
    set
    {
      if (value == this.GizmoImportLayersValue)
        return;
      this.GizmoImportLayersValue = value;
      this.OnPropertyChanged(nameof (GizmoImportLayersProperty));
    }
  }

  public bool ExportLayers
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.bExportLayers != 0U;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == (int) this.bExportLayers)
        return;
      this.bExportLayers = (uint) value;
      this.OnPropertyChanged(nameof (ExportLayers));
    }
  }

  public MEnumerableTArrayWrapper\u003CMLandscapeTargetListWrapper\u002CFLandscapeTargetListInfo\u003E LandscapeTargetsProperty
  {
    get => this.LandscapeTargetsValue;
    set
    {
      if (value == this.LandscapeTargetsValue)
        return;
      this.LandscapeTargetsValue = value;
      this.OnPropertyChanged(nameof (LandscapeTargetsProperty));
    }
  }

  public MEnumerableTArrayWrapper\u003CMGizmoHistoryWrapper\u002CFGizmoHistory\u003E GizmoHistoriesProperty
  {
    get => this.GizmoHistoriesValue;
    set
    {
      if (value == this.GizmoHistoriesValue)
        return;
      this.GizmoHistoriesValue = value;
      this.OnPropertyChanged(nameof (GizmoHistoriesProperty));
    }
  }

  public int CurrentGizmoIndex
  {
    get => this.CurrentGizmoIndexValue;
    set
    {
      if (this.CurrentGizmoIndexValue == value)
        return;
      this.CurrentGizmoIndexValue = value;
      this.OnPropertyChanged(nameof (CurrentGizmoIndex));
    }
  }

  public MEnumerableTArrayWrapper\u003CMGizmoDataWrapper\u002CFGizmoData\u003E GizmoDataProperty
  {
    get => this.GizmoDataValue;
    set
    {
      if (value == this.GizmoDataValue)
        return;
      this.GizmoDataValue = value;
      this.OnPropertyChanged(nameof (GizmoDataProperty));
    }
  }

  public int CurrentGizmoDataIndex
  {
    get => this.CurrentGizmoDataIndexValue;
    set
    {
      if (this.CurrentGizmoDataIndexValue == value)
        return;
      this.CurrentGizmoDataIndexValue = value;
      this.OnPropertyChanged(nameof (CurrentGizmoDataIndex));
    }
  }

  public string AddLayerNameString
  {
    get => this.AddLayerNameStringValue;
    set
    {
      if (!(this.AddLayerNameStringValue != value))
        return;
      this.AddLayerNameStringValue = value;
      this.OnPropertyChanged(nameof (AddLayerNameString));
    }
  }

  public float Hardness
  {
    get => this.HardnessValue;
    set
    {
      if ((double) this.HardnessValue == (double) value)
        return;
      this.HardnessValue = value;
      this.OnPropertyChanged(nameof (Hardness));
    }
  }

  public bool NoBlending
  {
    [return: MarshalAs(UnmanagedType.U1)] get => this.bNoBlending != 0U;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      if ((value ? 1 : 0) == (int) this.bNoBlending)
        return;
      this.bNoBlending = (uint) value;
      this.OnPropertyChanged(nameof (NoBlending));
    }
  }

  public unsafe float ToolStrength
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetToolStrength((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetToolStrength((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetToolStrength((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe float WeightTargetValue
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetWeightTargetValue((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetWeightTargetValue((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetWeightTargetValue((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe uint bUseWeightTargetValue
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbUseWeightTargetValue((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbUseWeightTargetValue((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (int) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbUseWeightTargetValue((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe float BrushRadius
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetBrushRadius((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetBrushRadius((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetBrushRadius((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe float BrushComponentSize
  {
    get => (float) \u003CModule\u003E.FLandscapeUISettings\u002EGetBrushComponentSize((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetBrushComponentSize((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetBrushComponentSize((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (int) value);
    }
  }

  public unsafe float BrushFalloff
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetBrushFalloff((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetBrushFalloff((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetBrushFalloff((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe uint bUseClayBrush
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbUseClayBrush((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbUseClayBrush((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (int) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbUseClayBrush((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe float AlphaBrushScale
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaBrushScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaBrushScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetAlphaBrushScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe float AlphaBrushRotation
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaBrushRotation((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaBrushRotation((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetAlphaBrushRotation((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe float AlphaBrushPanU
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaBrushPanU((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaBrushPanU((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetAlphaBrushPanU((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe float AlphaBrushPanV
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaBrushPanV((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaBrushPanV((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetAlphaBrushPanV((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public BitmapSource AlphaTexture
  {
    get => this.AlphaTextureValue;
    set
    {
      if (this.AlphaTextureValue == value)
        return;
      this.AlphaTextureValue = value;
      this.OnPropertyChanged(nameof (AlphaTexture));
    }
  }

  public unsafe float bSmoothGizmoBrush
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbSmoothGizmoBrush((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetbSmoothGizmoBrush((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbSmoothGizmoBrush((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe bool IsFlattenModeBoth
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetFlattenMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetFlattenMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 0;
      if (value == flag)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetFlattenMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeToolNoiseMode.Type) num);
    }
  }

  public unsafe bool IsFlattenModeAdd
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetFlattenMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetFlattenMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 1;
      if (value == flag)
        return;
      int num = 1;
      if (!value)
        num = -num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetFlattenMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeToolNoiseMode.Type) num);
    }
  }

  public unsafe bool IsFlattenModeSub
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetFlattenMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 2;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetFlattenMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 2;
      if (value == flag)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetFlattenMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value ? (ELandscapeToolNoiseMode.Type) 2 : (ELandscapeToolNoiseMode.Type) -1);
    }
  }

  public unsafe uint bUseSlopeFlatten
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbUseSlopeFlatten((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbUseSlopeFlatten((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (int) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbUseSlopeFlatten((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe uint bPickValuePerApply
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbPickValuePerApply((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbPickValuePerApply((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (int) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbPickValuePerApply((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe int ErodeThresh
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetErodeThresh((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if (\u003CModule\u003E.FLandscapeUISettings\u002EGetErodeThresh((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetErodeThresh((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (float) value);
    }
  }

  public unsafe int ErodeIterationNum
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetErodeIterationNum((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if (\u003CModule\u003E.FLandscapeUISettings\u002EGetErodeIterationNum((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetErodeIterationNum((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (float) value);
    }
  }

  public unsafe int ErodeSurfaceThickness
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetErodeSurfaceThickness((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if (\u003CModule\u003E.FLandscapeUISettings\u002EGetErodeSurfaceThickness((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetErodeSurfaceThickness((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (float) value);
    }
  }

  public unsafe bool IsErosionNoiseModeBoth
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetErosionNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetErosionNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 0;
      if (value == flag)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetErosionNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeToolNoiseMode.Type) num);
    }
  }

  public unsafe bool IsErosionNoiseModeAdd
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetErosionNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetErosionNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 1;
      if (value == flag)
        return;
      int num = 1;
      if (!value)
        num = -num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetErosionNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeToolNoiseMode.Type) num);
    }
  }

  public unsafe bool IsErosionNoiseModeSub
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetErosionNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 2;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetErosionNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 2;
      if (value == flag)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetErosionNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value ? (ELandscapeToolNoiseMode.Type) 2 : (ELandscapeToolNoiseMode.Type) -1);
    }
  }

  public unsafe float ErosionNoiseScale
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetErosionNoiseScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetErosionNoiseScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetErosionNoiseScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe int RainAmount
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetRainAmount((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if (\u003CModule\u003E.FLandscapeUISettings\u002EGetRainAmount((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetRainAmount((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe float SedimentCapacity
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetSedimentCapacity((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetSedimentCapacity((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetSedimentCapacity((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe int HErodeIterationNum
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetHErodeIterationNum((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if (\u003CModule\u003E.FLandscapeUISettings\u002EGetHErodeIterationNum((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetHErodeIterationNum((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (float) value);
    }
  }

  public unsafe bool IsRainDistModeBoth
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetRainDistMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetRainDistMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 0;
      if (value == flag)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetRainDistMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeToolNoiseMode.Type) num);
    }
  }

  public unsafe bool IsRainDistModeAdd
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetRainDistMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetRainDistMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 1;
      if (value == flag)
        return;
      int num = 1;
      if (!value)
        num = -num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetRainDistMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeToolNoiseMode.Type) num);
    }
  }

  public unsafe float RainDistScale
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetRainDistScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetRainDistScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetRainDistScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe uint bHErosionDetailSmooth
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbHErosionDetailSmooth((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbHErosionDetailSmooth((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (int) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbHErosionDetailSmooth((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (float) value);
    }
  }

  public unsafe float HErosionDetailScale
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetHErosionDetailScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetHErosionDetailScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetHErosionDetailScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe bool IsNoiseModeBoth
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 0;
      if (value == flag)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeToolNoiseMode.Type) num);
    }
  }

  public unsafe bool IsNoiseModeAdd
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 1;
      if (value == flag)
        return;
      int num = 1;
      if (!value)
        num = -num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeToolNoiseMode.Type) num);
    }
  }

  public unsafe bool IsNoiseModeSub
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 2;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 2;
      if (value == flag)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetNoiseMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value ? (ELandscapeToolNoiseMode.Type) 2 : (ELandscapeToolNoiseMode.Type) -1);
    }
  }

  public unsafe float NoiseScale
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetNoiseScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetNoiseScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetNoiseScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe uint bDetailSmooth
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbDetailSmooth((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbDetailSmooth((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (int) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbDetailSmooth((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (float) value);
    }
  }

  public unsafe float DetailScale
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetDetailScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetDetailScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetDetailScale((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe bool IsPasteModeBoth
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetPasteMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetPasteMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 0;
      if (value == flag)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetPasteMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeToolNoiseMode.Type) num);
    }
  }

  public unsafe bool IsPasteModeAdd
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetPasteMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetPasteMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 1;
      if (value == flag)
        return;
      int num = 1;
      if (!value)
        num = -num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetPasteMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeToolNoiseMode.Type) num);
    }
  }

  public unsafe bool IsPasteModeSub
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetPasteMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 2;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetPasteMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeToolNoiseMode.Type) 2;
      if (value == flag)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetPasteMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value ? (ELandscapeToolNoiseMode.Type) 2 : (ELandscapeToolNoiseMode.Type) -1);
    }
  }

  public unsafe uint bUseSelectedRegion
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbUseSelectedRegion((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbUseSelectedRegion((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (int) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbUseSelectedRegion((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe uint bUseNegativeMask
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbUseNegativeMask((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbUseNegativeMask((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (int) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbUseNegativeMask((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe uint bMaskEnabled
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbMaskEnabled((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbMaskEnabled((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (int) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbMaskEnabled((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe uint bApplyToAllTargets
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetbApplyToAllTargets((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbApplyToAllTargets((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (int) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbApplyToAllTargets((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (float) value);
    }
  }

  public bool IsViewModeNormal
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.GLandscapeViewMode == (ELandscapeViewMode.Type) 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.GLandscapeViewMode == (ELandscapeViewMode.Type) 0;
      if (value == flag)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      \u003CModule\u003E.GLandscapeViewMode = (ELandscapeViewMode.Type) num;
      this.OnPropertyChanged(nameof (IsViewModeNormal));
    }
  }

  public bool IsViewModeEditLayer
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.GLandscapeViewMode == (ELandscapeViewMode.Type) 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.GLandscapeViewMode == (ELandscapeViewMode.Type) 1;
      if (value == flag)
        return;
      int num = 1;
      if (!value)
        num = -num;
      \u003CModule\u003E.GLandscapeViewMode = (ELandscapeViewMode.Type) num;
      this.OnPropertyChanged(nameof (IsViewModeEditLayer));
    }
  }

  public bool IsViewModeDebugLayer
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.GLandscapeViewMode == (ELandscapeViewMode.Type) 2;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.GLandscapeViewMode == (ELandscapeViewMode.Type) 2;
      if (value == flag)
        return;
      \u003CModule\u003E.GLandscapeViewMode = value ? (ELandscapeViewMode.Type) 2 : (ELandscapeViewMode.Type) -1;
      this.OnPropertyChanged(nameof (IsViewModeDebugLayer));
    }
  }

  public bool IsViewModeLayerDensity
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.GLandscapeViewMode == (ELandscapeViewMode.Type) 3;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.GLandscapeViewMode == (ELandscapeViewMode.Type) 3;
      if (value == flag)
        return;
      \u003CModule\u003E.GLandscapeViewMode = value ? (ELandscapeViewMode.Type) 3 : (ELandscapeViewMode.Type) -1;
      this.OnPropertyChanged(nameof (IsViewModeLayerDensity));
    }
  }

  public bool IsViewModeLOD
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.GLandscapeViewMode == (ELandscapeViewMode.Type) 4;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.GLandscapeViewMode == (ELandscapeViewMode.Type) 4;
      if (value == flag)
        return;
      \u003CModule\u003E.GLandscapeViewMode = value ? (ELandscapeViewMode.Type) 4 : (ELandscapeViewMode.Type) -1;
      this.OnPropertyChanged(nameof (IsViewModeLOD));
    }
  }

  public unsafe bool IsConvertModeExpand
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetConvertMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeConvertMode.Type) 0;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetConvertMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeConvertMode.Type) 0;
      if (value == flag)
        return;
      int num = 0;
      if (!value)
        num = ~num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetConvertMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeConvertMode.Type) num);
      this.OnPropertyChanged("ConvertMode");
    }
  }

  public unsafe bool IsConvertModeClip
  {
    [return: MarshalAs(UnmanagedType.U1)] get => \u003CModule\u003E.FLandscapeUISettings\u002EGetConvertMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeConvertMode.Type) 1;
    [param: MarshalAs(UnmanagedType.U1)] set
    {
      bool flag = \u003CModule\u003E.FLandscapeUISettings\u002EGetConvertMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (ELandscapeConvertMode.Type) 1;
      if (value == flag)
        return;
      int num = 1;
      if (!value)
        num = -num;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetConvertMode((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), (ELandscapeConvertMode.Type) num);
      this.OnPropertyChanged("ConvertMode");
    }
  }

  public unsafe float LODBiasThreshold
  {
    get => \u003CModule\u003E.FLandscapeUISettings\u002EGetLODBiasThreshold((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    set
    {
      if ((double) \u003CModule\u003E.FLandscapeUISettings\u002EGetLODBiasThreshold((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) == (double) value)
        return;
      \u003CModule\u003E.FLandscapeUISettings\u002ESetLODBiasThreshold((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), value);
    }
  }

  public unsafe MLandscapeEditWindow(FEdModeLandscape* InLandscapeEditSystem)
  {
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E fdefaultAllocator = new MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E();
    // ISSUE: fault handler
    try
    {
      this.DroppedAssets = fdefaultAllocator;
      this.LandscapeEditSystem = InLandscapeEditSystem;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      // ISSUE: fault handler
      try
      {
        if ((double) this.HardnessValue == 0.5)
          return;
        this.HardnessValue = 0.5f;
        this.OnPropertyChanged(nameof (Hardness));
      }
      __fault
      {
        base.Dispose(true);
      }
    }
    __fault
    {
      this.DroppedAssets.Dispose();
    }
  }

  public unsafe uint InitLandscapeEditWindow(HWND__* InParentWindowHandle)
  {
    string InWindowTitle = \u003CModule\u003E.CLRTools\u002ELocalizeString("LandscapeEditWindow_WindowTitle", (string) null, (string) null, (string) null);
    string InWPFXamlFileName = "LandscapeEditWindow.xaml";
    this.HeightmapFileSize = -1;
    this.GizmoFileSize = -1;
    this.LastImportPath = \u003CModule\u003E.CLRTools\u002EToString((FString*) ((IntPtr) \u003CModule\u003E.GApp + 260L));
    int InPositionX;
    int InPositionY;
    int InWidth;
    int InHeight;
    \u003CModule\u003E.FLandscapeUISettings\u002EGetWindowSizePos((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), &InPositionX, &InPositionY, &InWidth, &InHeight);
    bool bCenterWindow = InPositionX == -1 || InPositionY == -1;
    if (this.InitWindow(InParentWindowHandle, InWindowTitle, InWPFXamlFileName, InPositionX, InPositionY, InWidth, InHeight, bCenterWindow, 28, 0) == 0U)
      return 0;
    *(long*) ((IntPtr) this.LandscapeEditSystem + 392L) = 0L;
    MLandscapeEditWindow mlandscapeEditWindow1 = this;
    mlandscapeEditWindow1.PropertyChanged += new PropertyChangedEventHandler(mlandscapeEditWindow1.OnLandscapeEditPropertyChanged);
    Visual rootVisual = this.InteropWindow.op_MemberSelection().RootVisual;
    FrameworkElement frameworkElement = (FrameworkElement) rootVisual;
    frameworkElement.DataContext = (object) this;
    Button logicalNode1 = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "TitleBarCloseButton");
    logicalNode1.Click += new RoutedEventHandler(this.OnClose);
    this.FakeTitleBarButtonWidth = (int) (logicalNode1.ActualWidth + (double) this.FakeTitleBarButtonWidth);
    this.ImportButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ImportButton");
    this.GizmoImportButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "GizmoImportButton");
    this.ChangeComponentSizeButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ChangeComponentSizeButton");
    this.UpdateLODBiasButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "UpdateLODBiasButton");
    this.LandscapeComboBox = (ComboBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "LandscapeCombo");
    this.LandscapeComboBox.SelectionChanged += new SelectionChangedEventHandler(this.OnLandscapeListSelectionChanged);
    MLandscapeEditWindow mlandscapeEditWindow2 = this;
    mlandscapeEditWindow2.LandscapeListsValue = new MEnumerableTArrayWrapper\u003CMLandscapeListWrapper\u002CFLandscapeListInfo\u003E(\u003CModule\u003E.FEdModeLandscape\u002EGetLandscapeList(mlandscapeEditWindow2.LandscapeEditSystem));
    this.LandscapeCompNum = (Label) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "LandscapeCompNum");
    this.CollisionCompNum = (Label) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "CollisionCompNum");
    this.CompQuadNum = (Label) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "CompQuadNum");
    this.QuadPerSection = (Label) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "QuadPerSection");
    this.SubsectionNum = (Label) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "SubsectionNum");
    Utils.CreateBinding((FrameworkElement) this.LandscapeComboBox, ItemsControl.ItemsSourceProperty, (object) this, "LandscapeListsProperty");
    int num1 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L)))
    {
      do
      {
        FLandscapeToolSet* flandscapeToolSetPtr = (FLandscapeToolSet*) *(long*) \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L), num1);
        ImageRadioButton logicalNode2 = (ImageRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, new string(\u003CModule\u003E.FLandscapeToolSet\u002EGetToolSetName(flandscapeToolSetPtr)));
        ((ButtonBase) logicalNode2).Click += new RoutedEventHandler(this.ToolButton_Click);
        long num2 = *(long*) \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L), num1);
        FString fstring1;
        FString* editorResourcesDir1 = \u003CModule\u003E.GetEditorResourcesDir(&fstring1);
        BitmapImage bitmapImage1;
        // ISSUE: fault handler
        try
        {
          FString fstring2;
          ref FString local1 = ref fstring2;
          ref \u0024ArrayType\u0024\u0024\u0024BY0CF\u0040\u0024\u0024CB_W local2 = ref \u003CModule\u003E.\u003F\u003F_C\u0040_1EK\u0040EGBMNDOL\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA_\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAv\u003F\u0024AAe\u0040;
          char* chPtr1 = \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir1);
          long num3 = num2;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          char* chPtr2 = __calli((__FnPtr<char* (IntPtr)>) *(long*) (*(long*) num3 + 8L))((IntPtr) num3);
          FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FString*) ref local1, (char*) ref local2, chPtr1, chPtr2);
          // ISSUE: fault handler
          try
          {
            bitmapImage1 = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
        long num4 = *(long*) \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L), num1);
        FString fstring3;
        FString* editorResourcesDir2 = \u003CModule\u003E.GetEditorResourcesDir(&fstring3);
        BitmapImage bitmapImage2;
        // ISSUE: fault handler
        try
        {
          FString fstring2;
          ref FString local1 = ref fstring2;
          ref \u0024ArrayType\u0024\u0024\u0024BY0CH\u0040\u0024\u0024CB_W local2 = ref \u003CModule\u003E.\u003F\u003F_C\u0040_1EO\u0040HDMBGKGD\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA_\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAt\u003F\u0024AAi\u0040;
          char* chPtr1 = \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir2);
          long num3 = num4;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          char* chPtr2 = __calli((__FnPtr<char* (IntPtr)>) *(long*) (*(long*) num3 + 8L))((IntPtr) num3);
          FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FString*) ref local1, (char*) ref local2, chPtr1, chPtr2);
          // ISSUE: fault handler
          try
          {
            bitmapImage2 = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
        long num5 = *(long*) \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L), num1);
        long num6 = num5;
        FString fstring4;
        ref FString local3 = ref fstring4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        long num7 = (long) __calli((__FnPtr<FString* (IntPtr, FString*)>) *(long*) (*(long*) num5 + 16L))((FString*) num6, (IntPtr) ref local3);
        // ISSUE: fault handler
        try
        {
          ((FrameworkElement) logicalNode2).ToolTip = (object) new string(\u003CModule\u003E.FString\u002E\u002A((FString*) num7));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
        logicalNode2.CheckedImage = bitmapImage1;
        logicalNode2.UncheckedImage = bitmapImage2;
        FEdModeLandscape* landscapeEditSystem = this.LandscapeEditSystem;
        if (*(int*) ((IntPtr) landscapeEditSystem + 432L) == num1)
        {
          long num3 = *(long*) \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) landscapeEditSystem + 452L), num1);
          FString fstring2;
          FString* editorResourcesDir3 = \u003CModule\u003E.GetEditorResourcesDir(&fstring2);
          BitmapImage bitmapImage3;
          // ISSUE: fault handler
          try
          {
            FString fstring5;
            ref FString local1 = ref fstring5;
            ref \u0024ArrayType\u0024\u0024\u0024BY0CH\u0040\u0024\u0024CB_W local2 = ref \u003CModule\u003E.\u003F\u003F_C\u0040_1EO\u0040EMOANNPP\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAT\u003F\u0024AAo\u003F\u0024AAo\u003F\u0024AAl\u003F\u0024AA_\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA_\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAs\u003F\u0024AAa\u003F\u0024AAb\u003F\u0024AAl\u0040;
            char* chPtr1 = \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir3);
            long num8 = num3;
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            char* chPtr2 = __calli((__FnPtr<char* (IntPtr)>) *(long*) (*(long*) num8 + 8L))((IntPtr) num8);
            FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FString*) ref local1, (char*) ref local2, chPtr1, chPtr2);
            // ISSUE: fault handler
            try
            {
              bitmapImage3 = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
          logicalNode2.DisabledImage = bitmapImage3;
        }
        if ((IntPtr) flandscapeToolSetPtr == *(long*) ((IntPtr) this.LandscapeEditSystem + 376L))
        {
          bool? nullable = (bool?) true;
          ((ToggleButton) logicalNode2).IsChecked = nullable;
          *(int*) ((IntPtr) this.LandscapeEditSystem + 420L) = num1;
        }
        ++num1;
      }
      while (num1 < \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L)));
    }
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ToolStrengthSlider"), RangeBase.ValueProperty, (object) this, "ToolStrength");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ToolWeightTargetValueSlider"), RangeBase.ValueProperty, (object) this, "WeightTargetValue");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "UseWeightTargetValueCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "bUseWeightTargetValue");
    StackPanel logicalNode3 = (StackPanel) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FlattenPanel");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FlattenModeBoth"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsFlattenModeBoth");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FlattenModeAdd"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsFlattenModeAdd");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FlattenModeSub"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsFlattenModeSub");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "UseSlopeCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "bUseSlopeFlatten");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "PickValuePerApplyCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "bPickValuePerApply");
    StackPanel logicalNode4 = (StackPanel) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ErosionPanel");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ErodeThreshSlider"), RangeBase.ValueProperty, (object) this, "ErodeThresh");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ErodeIterationNumSlider"), RangeBase.ValueProperty, (object) this, "ErodeIterationNum");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ErodeSurfaceThicknessSlider"), RangeBase.ValueProperty, (object) this, "ErodeSurfaceThickness");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ErosionNoiseModeBoth"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsErosionNoiseModeBoth");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ErosionNoiseModeAdd"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsErosionNoiseModeAdd");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ErosionNoiseModeSub"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsErosionNoiseModeSub");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ErosionNoiseScaleSlider"), RangeBase.ValueProperty, (object) this, "ErosionNoiseScale");
    StackPanel logicalNode5 = (StackPanel) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "HydraulicErosionPanel");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "RainAmountSlider"), RangeBase.ValueProperty, (object) this, "RainAmount");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "SedimentCapacitySlider"), RangeBase.ValueProperty, (object) this, "SedimentCapacity");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "HErodeIterationNumSlider"), RangeBase.ValueProperty, (object) this, "HErodeIterationNum");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "RainDistModeBoth"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsRainDistModeBoth");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "RainDistModeAdd"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsRainDistModeAdd");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "RainDistScaleSlider"), RangeBase.ValueProperty, (object) this, "RainDistScale");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "HErosoinDetailSmoothCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "bHErosionDetailSmooth");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "HErosionDetailScaleSlider"), RangeBase.ValueProperty, (object) this, "HErosionDetailScale");
    StackPanel logicalNode6 = (StackPanel) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "NoisePanel");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "NoiseModeBoth"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsNoiseModeBoth");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "NoiseModeAdd"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsNoiseModeAdd");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "NoiseModeSub"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsNoiseModeSub");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "NoiseScaleSlider"), RangeBase.ValueProperty, (object) this, "NoiseScale");
    StackPanel logicalNode7 = (StackPanel) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "SmoothOptionPanel");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "DetailSmoothCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "bDetailSmooth");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "DetailScaleSlider"), RangeBase.ValueProperty, (object) this, "DetailScale");
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ClearSelectionButton")).Click += new RoutedEventHandler(this.ClearSelectionButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ClearMaskButton")).Click += new RoutedEventHandler(this.ClearMaskButton_Click);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "PasteModeBoth"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsPasteModeBoth");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "PasteModeAdd"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsPasteModeAdd");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "PasteModeSub"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsPasteModeSub");
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ClearGizmoDataButton")).Click += new RoutedEventHandler(this.ClearGizmoDataButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FitToSelectionButton")).Click += new RoutedEventHandler(this.FitToSelectionButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "FitToGizmoButton")).Click += new RoutedEventHandler(this.FitToGizmoButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "CopyToGizmoButton")).Click += new RoutedEventHandler(this.CopyToGizmoButton_Click);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "EditmodeNone"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsViewModeNormal");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "EditmodeEdit"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsViewModeEditLayer");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "EditmodeDebugView"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsViewModeDebugLayer");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "EditmodeLayerDensity"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsViewModeLayerDensity");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "EditmodeLOD"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsViewModeLOD");
    UniformGrid logicalNode8 = (UniformGrid) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "BrushGrid");
    int num9 = 0;
    if (0 < \u003CModule\u003E.TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 468L)))
    {
      do
      {
        FLandscapeBrushSet* flandscapeBrushSetPtr = \u003CModule\u003E.TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 468L), num9);
        ToolDropdownRadioButton logicalNode2 = (ToolDropdownRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, new string(\u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) flandscapeBrushSetPtr + 16L))));
        ((FrameworkElement) logicalNode2).ToolTip = (object) new string(\u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) flandscapeBrushSetPtr + 32L)));
        int num2 = 0;
        if (0 < \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr))
        {
          do
          {
            long num3 = *(long*) \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr, num2);
            FString fstring1;
            FString* editorResourcesDir1 = \u003CModule\u003E.GetEditorResourcesDir(&fstring1);
            BitmapImage bitmapImage1;
            // ISSUE: fault handler
            try
            {
              FString fstring2;
              ref FString local1 = ref fstring2;
              ref \u0024ArrayType\u0024\u0024\u0024BY0CI\u0040\u0024\u0024CB_W local2 = ref \u003CModule\u003E.\u003F\u003F_C\u0040_1FA\u0040ODMFIDBP\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAB\u003F\u0024AAr\u003F\u0024AAu\u003F\u0024AAs\u003F\u0024AAh\u003F\u0024AA_\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA_\u003F\u0024AAi\u003F\u0024AAn\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAt\u0040;
              char* chPtr1 = \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir1);
              long num4 = num3;
              // ISSUE: cast to a function pointer type
              // ISSUE: function pointer call
              char* chPtr2 = __calli((__FnPtr<char* (IntPtr)>) *(long*) (*(long*) num4 + 88L))((IntPtr) num4);
              FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FString*) ref local1, (char*) ref local2, chPtr1, chPtr2);
              // ISSUE: fault handler
              try
              {
                bitmapImage1 = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
            long num5 = *(long*) \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr, num2);
            FString fstring3;
            FString* editorResourcesDir2 = \u003CModule\u003E.GetEditorResourcesDir(&fstring3);
            BitmapImage bitmapImage2;
            // ISSUE: fault handler
            try
            {
              FString fstring2;
              ref FString local1 = ref fstring2;
              ref \u0024ArrayType\u0024\u0024\u0024BY0CG\u0040\u0024\u0024CB_W local2 = ref \u003CModule\u003E.\u003F\u003F_C\u0040_1EM\u0040CKGMGBMM\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAB\u003F\u0024AAr\u003F\u0024AAu\u003F\u0024AAs\u003F\u0024AAh\u003F\u0024AA_\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA_\u003F\u0024AAa\u003F\u0024AAc\u003F\u0024AAt\u003F\u0024AAi\u003F\u0024AAv\u0040;
              char* chPtr1 = \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir2);
              long num4 = num5;
              // ISSUE: cast to a function pointer type
              // ISSUE: function pointer call
              char* chPtr2 = __calli((__FnPtr<char* (IntPtr)>) *(long*) (*(long*) num4 + 88L))((IntPtr) num4);
              FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FString*) ref local1, (char*) ref local2, chPtr1, chPtr2);
              // ISSUE: fault handler
              try
              {
                bitmapImage2 = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
            long num6 = *(long*) \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr, num2);
            FString fstring4;
            FString* editorResourcesDir3 = \u003CModule\u003E.GetEditorResourcesDir(&fstring4);
            BitmapImage bitmapImage3;
            // ISSUE: fault handler
            try
            {
              FString fstring2;
              ref FString local1 = ref fstring2;
              ref \u0024ArrayType\u0024\u0024\u0024BY0CI\u0040\u0024\u0024CB_W local2 = ref \u003CModule\u003E.\u003F\u003F_C\u0040_1FA\u0040NMOEDEID\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AAw\u003F\u0024AAx\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F2\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AA_\u003F\u0024AAB\u003F\u0024AAr\u003F\u0024AAu\u003F\u0024AAs\u003F\u0024AAh\u003F\u0024AA_\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA_\u003F\u0024AAd\u003F\u0024AAi\u003F\u0024AAs\u003F\u0024AAa\u003F\u0024AAb\u0040;
              char* chPtr1 = \u003CModule\u003E.FString\u002E\u002A(editorResourcesDir3);
              long num4 = num6;
              // ISSUE: cast to a function pointer type
              // ISSUE: function pointer call
              char* chPtr2 = __calli((__FnPtr<char* (IntPtr)>) *(long*) (*(long*) num4 + 88L))((IntPtr) num4);
              FString* fstringPtr = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u002Cwchar_t\u0020const\u0020\u002A\u003E((FString*) ref local1, (char*) ref local2, chPtr1, chPtr2);
              // ISSUE: fault handler
              try
              {
                bitmapImage3 = new BitmapImage(new Uri(new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr)), UriKind.Absolute));
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
            long num7 = *(long*) \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr, num2);
            long num8 = num7;
            FString fstring5;
            ref FString local = ref fstring5;
            // ISSUE: cast to a function pointer type
            // ISSUE: function pointer call
            long num10 = (long) __calli((__FnPtr<FString* (IntPtr, FString*)>) *(long*) (*(long*) num7 + 96L))((FString*) num8, (IntPtr) ref local);
            // ISSUE: fault handler
            try
            {
              ((Collection<ToolDropdownItem>) logicalNode2.ListItems).Add(new ToolDropdownItem(bitmapImage1, bitmapImage2, bitmapImage3, new string(\u003CModule\u003E.FString\u002E\u002A((FString*) num10))));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
            logicalNode2.ToolSelectionChanged += new RoutedEventHandler(this.BrushButton_SelectionChanged);
            if (num2 == 0)
            {
              logicalNode2.CheckedImage = bitmapImage2;
              logicalNode2.UncheckedImage = bitmapImage1;
              logicalNode2.DisabledImage = bitmapImage3;
              logicalNode2.SelectedIndex = 0;
            }
            if (*(long*) \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr, num2) == *(long*) ((IntPtr) this.LandscapeEditSystem + 384L))
            {
              bool? nullable = (bool?) true;
              ((ToggleButton) logicalNode2).IsChecked = nullable;
              logicalNode2.CheckedImage = bitmapImage2;
              logicalNode2.UncheckedImage = bitmapImage1;
              logicalNode2.DisabledImage = bitmapImage3;
              logicalNode2.SelectedIndex = num2;
              *(int*) ((IntPtr) this.LandscapeEditSystem + 424L) = num9;
            }
            ++num2;
          }
          while (num2 < \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr));
        }
        ++num9;
      }
      while (num9 < \u003CModule\u003E.TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 468L)));
    }
    this.BrushRadiusSlider = (DragSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "BrushRadiusSlider");
    Utils.CreateBinding((FrameworkElement) this.BrushRadiusSlider, RangeBase.ValueProperty, (object) this, "BrushRadius");
    this.BrushSizeSlider = (DragSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "BrushSizeSlider");
    Utils.CreateBinding((FrameworkElement) this.BrushSizeSlider, RangeBase.ValueProperty, (object) this, "BrushComponentSize");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "BrushFalloffSlider"), RangeBase.ValueProperty, (object) this, "BrushFalloff");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "UseClayBrushCheckbox"), ToggleButton.IsCheckedProperty, (object) this, "bUseClayBrush");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AlphaBrushScaleSlider"), RangeBase.ValueProperty, (object) this, "AlphaBrushScale");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AlphaBrushRotationSlider"), RangeBase.ValueProperty, (object) this, "AlphaBrushRotation");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AlphaBrushPanUSlider"), RangeBase.ValueProperty, (object) this, "AlphaBrushPanU");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AlphaBrushPanVSlider"), RangeBase.ValueProperty, (object) this, "AlphaBrushPanV");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "SmoothGizmoBrushCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "bSmoothGizmoBrush");
    this.AlphaTextureUseRButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AlphaTextureUseRButton");
    this.AlphaTextureUseRButton.Click += new RoutedEventHandler(this.AlphaTextureUseButton_Click);
    this.AlphaTextureUseGButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AlphaTextureUseGButton");
    this.AlphaTextureUseGButton.Click += new RoutedEventHandler(this.AlphaTextureUseButton_Click);
    this.AlphaTextureUseBButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AlphaTextureUseBButton");
    this.AlphaTextureUseBButton.Click += new RoutedEventHandler(this.AlphaTextureUseButton_Click);
    this.AlphaTextureUseAButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AlphaTextureUseAButton");
    this.AlphaTextureUseAButton.Click += new RoutedEventHandler(this.AlphaTextureUseButton_Click);
    MLandscapeEditWindow mlandscapeEditWindow3 = this;
    mlandscapeEditWindow3.AlphaTexture = mlandscapeEditWindow3.MakeAlphaTextureBitmap();
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "SyncContentBrowserButton")).Click += new RoutedEventHandler(this.SyncContentBrowserButton_Click);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ApplyAllCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "bApplyToAllTargets");
    MLandscapeEditWindow mlandscapeEditWindow4 = this;
    mlandscapeEditWindow4.LandscapeTargetsValue = new MEnumerableTArrayWrapper\u003CMLandscapeTargetListWrapper\u002CFLandscapeTargetListInfo\u003E(\u003CModule\u003E.FEdModeLandscape\u002EGetTargetList(mlandscapeEditWindow4.LandscapeEditSystem));
    this.LandscapeTargetsValue.PropertyChanged += new PropertyChangedEventHandler(this.OnLandscapeTargetLayerPropertyChanged);
    this.TargetListBox = (ListBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "TargetListBox");
    Utils.CreateBinding((FrameworkElement) this.TargetListBox, ItemsControl.ItemsSourceProperty, (object) this, "LandscapeTargetsProperty");
    this.TargetListBox.AllowDrop = true;
    this.TargetListBox.DragOver += new DragEventHandler(this.OnDragOver);
    this.TargetListBox.Drop += new DragEventHandler(this.OnDrop);
    this.TargetListBox.DragEnter += new DragEventHandler(this.OnDragEnter);
    this.TargetListBox.DragLeave += new DragEventHandler(this.OnDragLeave);
    RoutedCommand resource1 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeEditTargetLayerCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource1, new ExecutedRoutedEventHandler(this.OnLandscapeTargetLayerChanged)));
    RoutedCommand resource2 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeTargetLayerRemoveCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource2, new ExecutedRoutedEventHandler(this.TargetLayerRemoveButton_Click)));
    RoutedCommand resource3 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeTargetLayerSyncCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource3, new ExecutedRoutedEventHandler(this.TargetLayerSyncButton_Click)));
    RoutedCommand resource4 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeTargetReimportCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource4, new ExecutedRoutedEventHandler(this.TargetReimportButton_Click)));
    RoutedCommand resource5 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeTargetSetPhysMaterialCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource5, new ExecutedRoutedEventHandler(this.TargetLayerSetPhysMaterialButton_Click)));
    RoutedCommand resource6 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeTargetSetFilePathCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource6, new ExecutedRoutedEventHandler(this.TargetSetFilePathButton_Click)));
    MLandscapeEditWindow mlandscapeEditWindow5 = this;
    mlandscapeEditWindow5.GizmoHistoriesValue = new MEnumerableTArrayWrapper\u003CMGizmoHistoryWrapper\u002CFGizmoHistory\u003E(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoHistories((FLandscapeUISettings*) ((IntPtr) mlandscapeEditWindow5.LandscapeEditSystem + 104L)));
    this.GizmoListBox = (ListBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "GizmoListBox");
    Utils.CreateBinding((FrameworkElement) this.GizmoListBox, ItemsControl.ItemsSourceProperty, (object) this, "GizmoHistoriesProperty");
    Utils.CreateBinding((FrameworkElement) this.GizmoListBox, Selector.SelectedIndexProperty, (object) this, "CurrentGizmoIndex", (IValueConverter) new IntToIntOffsetConverter(0));
    RoutedCommand resource7 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeEditGizmoCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource7, new ExecutedRoutedEventHandler(this.OnLandscapeGizmoChanged)));
    MLandscapeEditWindow mlandscapeEditWindow6 = this;
    mlandscapeEditWindow6.GizmoDataValue = new MEnumerableTArrayWrapper\u003CMGizmoDataWrapper\u002CFGizmoData\u003E(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoData((FLandscapeUISettings*) ((IntPtr) mlandscapeEditWindow6.LandscapeEditSystem + 104L)));
    this.GizmoDataListBox = (ListBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "GizmoDataListBox");
    Utils.CreateBinding((FrameworkElement) this.GizmoDataListBox, ItemsControl.ItemsSourceProperty, (object) this, "GizmoDataProperty");
    Utils.CreateBinding((FrameworkElement) this.GizmoDataListBox, Selector.SelectedIndexProperty, (object) this, "CurrentGizmoDataIndex", (IValueConverter) new IntToIntOffsetConverter(0));
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AddLayerButton")).Click += new RoutedEventHandler(this.AddLayerButton_Click);
    TextBox logicalNode9 = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AddLayerNameTextBox");
    TextBox logicalNode10 = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AddHardnessTextBox");
    DependencyProperty textProperty1 = TextBox.TextProperty;
    Utils.CreateBinding((FrameworkElement) logicalNode9, textProperty1, (object) this, "AddLayerNameString");
    this.AddLayerNameString = "";
    Utils.CreateBinding((FrameworkElement) logicalNode10, TextBox.TextProperty, (object) this, "Hardness");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "AddNoBlendingCheckBox"), ToggleButton.IsCheckedProperty, (object) this, "NoBlending");
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "HeightmapFileButton")).Click += new RoutedEventHandler(this.HeightmapFileButton_Click);
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "HeightmapFileNameTextBox"), TextBox.TextProperty, (object) this, "HeightmapFileNameString");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "WidthTextBox"), TextBox.TextProperty, (object) this, "Width");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "HeightTextBox"), TextBox.TextProperty, (object) this, "Height");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "SectionSizeCombo"), Selector.SelectedIndexProperty, (object) this, "SectionSize", (IValueConverter) new IntToIntOffsetConverter(0));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "NumSectionsCombo"), Selector.SelectedIndexProperty, (object) this, "NumSections", (IValueConverter) new IntToIntOffsetConverter(0));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "TotalComponentsLabel"), TextBlock.TextProperty, (object) this, "TotalComponents");
    this.LandscapeImportLayersValue = new LandscapeImportLayers();
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ImportLayersItemsControl"), ItemsControl.ItemsSourceProperty, (object) this, "LandscapeImportLayersProperty");
    RoutedCommand resource8 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeImportLayersFilenameCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource8, new ExecutedRoutedEventHandler(this.LayerFileButton_Click)));
    RoutedCommand resource9 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeImportLayersRemoveCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource9, new ExecutedRoutedEventHandler(this.LayerRemoveButton_Click)));
    this.ImportButton.Click += new RoutedEventHandler(this.ImportButton_Click);
    this.ImportButton.IsEnabled = false;
    this.CurrentWidth = (TextBlock) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "WidthTextBlock");
    this.CurrentHeight = (TextBlock) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "HeightTextBlock");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ConvertWidthTextBlock"), TextBlock.TextProperty, (object) this, "ConvertWidth");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ConvertHeightTextBlock"), TextBlock.TextProperty, (object) this, "ConvertHeight");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ConvertSectionSizeCombo"), Selector.SelectedIndexProperty, (object) this, "ConvertSectionSize", (IValueConverter) new IntToIntOffsetConverter(0));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ConvertNumSectionsCombo"), Selector.SelectedIndexProperty, (object) this, "ConvertNumSections", (IValueConverter) new IntToIntOffsetConverter(0));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ConvertTotalComponentsLabel"), ContentControl.ContentProperty, (object) this, "ConvertTotalComponents");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ConvertCompQuadNumLabel"), ContentControl.ContentProperty, (object) this, "ConvertCompQuadNum");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ConvertModeExpand"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsConvertModeExpand");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ConvertModeClip"), (DependencyProperty) BindableRadioButton.IsActuallyCheckedProperty, (object) this, "IsConvertModeClip");
    this.ChangeComponentSizeButton.Click += new RoutedEventHandler(this.ChangeComponentSizeButton_Click);
    this.ChangeComponentSizeButton.IsEnabled = false;
    RoutedCommand resource10 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeGizmoPinCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource10, new ExecutedRoutedEventHandler(this.LandscapeGizmoPin_Click)));
    RoutedCommand resource11 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeGizmoDeleteCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource11, new ExecutedRoutedEventHandler(this.LandscapeGizmoDelete_Click)));
    RoutedCommand resource12 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeGizmoMoveToCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource12, new ExecutedRoutedEventHandler(this.LandscapeGizmoMoveTo_Click)));
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "GizmoHeightmapFileButton")).Click += new RoutedEventHandler(this.GizmoHeightmapFileButton_Click);
    TextBox logicalNode11 = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "GizmoHeightmapFileNameTextBox");
    TextBox logicalNode12 = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "GizmoWidthTextBox");
    TextBox logicalNode13 = (TextBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "GizmoHeightTextBox");
    DependencyProperty textProperty2 = TextBox.TextProperty;
    Utils.CreateBinding((FrameworkElement) logicalNode11, textProperty2, (object) this, "GizmoHeightmapFileNameString");
    Utils.CreateBinding((FrameworkElement) logicalNode12, TextBox.TextProperty, (object) this, "GizmoImportWidth");
    Utils.CreateBinding((FrameworkElement) logicalNode13, TextBox.TextProperty, (object) this, "GizmoImportHeight");
    MLandscapeEditWindow mlandscapeEditWindow7 = this;
    mlandscapeEditWindow7.GizmoImportLayersValue = new MEnumerableTArrayWrapper\u003CMGizmoImportLayerWrapper\u002CFGizmoImportLayer\u003E(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) mlandscapeEditWindow7.LandscapeEditSystem + 104L)));
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "GizmoImportLayersItemsControl"), ItemsControl.ItemsSourceProperty, (object) this, "GizmoImportLayersProperty");
    RoutedCommand resource13 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeGizmoImportLayersFilenameCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource13, new ExecutedRoutedEventHandler(this.GizmoLayerFileButton_Click)));
    RoutedCommand resource14 = (RoutedCommand) frameworkElement.FindResource((object) "LandscapeGizmoImportLayersRemoveCommand");
    frameworkElement.CommandBindings.Add(new CommandBinding((ICommand) resource14, new ExecutedRoutedEventHandler(this.GizmoLayerRemoveButton_Click)));
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "GizmoLayerAddButton")).Click += new RoutedEventHandler(this.GizmoLayerAddButton_Click);
    this.GizmoLayerRemoveButton = (Button) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "GizmoLayerRemoveButton");
    this.GizmoLayerRemoveButton.Click += new RoutedEventHandler(this.GizmoLastLayerRemoveButton_Click);
    this.GizmoLayerRemoveButton.IsEnabled = false;
    this.GizmoImportButton.Click += new RoutedEventHandler(this.GizmoImportButton_Click);
    this.GizmoImportButton.IsEnabled = false;
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "UseMaskCheckbox"), ToggleButton.IsCheckedProperty, (object) this, "bUseSelectedRegion");
    this.InvertMaskCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "UseInvertMaskCheckbox");
    Utils.CreateBinding((FrameworkElement) this.InvertMaskCheckBox, ToggleButton.IsCheckedProperty, (object) this, "bUseNegativeMask");
    this.MaskEnableCheckBox = (CheckBox) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "MaskEnabled");
    Utils.CreateBinding((FrameworkElement) this.MaskEnableCheckBox, ToggleButton.IsCheckedProperty, (object) this, "bMaskEnabled");
    Utils.CreateBinding((FrameworkElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ExportLayersCheckbox"), ToggleButton.IsCheckedProperty, (object) this, "ExportLayers");
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ExportButton")).Click += new RoutedEventHandler(this.ExportButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ExportGizmoButton")).Click += new RoutedEventHandler(this.ExportGizmoButton_Click);
    ((ButtonBase) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "ConvertTerrainButton")).Click += new RoutedEventHandler(this.ConvertTerrainButton_Click);
    this.LODBiasThresholdSlider = (DragSlider) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "LODBiasThresholdSlider");
    Utils.CreateBinding((FrameworkElement) this.LODBiasThresholdSlider, RangeBase.ValueProperty, (object) this, "LODBiasThreshold");
    this.UpdateLODBiasButton.Click += new RoutedEventHandler(this.UpdateLODBiasButton_Click);
    this.UpdateLODBiasButton.IsEnabled = true;
    this.UpdateLandscapeList();
    this.ShowWindow(true);
    return 1;
  }

  protected unsafe void OnClose(object Owner, RoutedEventArgs Args) => \u003CModule\u003E.FEditorModeTools\u002EDeactivateMode(\u003CModule\u003E.GEditorModeTools(), (EEditorMode) 10);

  protected unsafe void OnDragEnter(object Sender, DragEventArgs Args)
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
    Args.Effects = DragDropEffects.Copy;
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E droppedAssets = this.DroppedAssets;
    if ((IntPtr) droppedAssets.Get() != IntPtr.Zero)
    {
      TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, droppedAssets.Get());
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        while (*(long*) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt) == (IntPtr) \u003CModule\u003E.ULandscapeLayerInfoObject\u002EStaticClass())
        {
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
          if (!\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
            goto label_5;
        }
        Args.Effects = DragDropEffects.None;
      }
    }
label_5:
    Args.Handled = true;
  }

  protected unsafe void OnDrop(object Owner, DragEventArgs Args)
  {
    MScopedNativePointer\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u0020\u003E droppedAssets = this.DroppedAssets;
    if ((IntPtr) droppedAssets.Get() != IntPtr.Zero)
    {
      TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E fdefaultAllocatorInt;
      \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u007Bctor\u007D(&fdefaultAllocatorInt, droppedAssets.Get());
      if (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt))
      {
        do
        {
          ULandscapeLayerInfoObject* ulandscapeLayerInfoObjectPtr = \u003CModule\u003E.LoadObject\u003Cclass\u0020ULandscapeLayerInfoObject\u003E((UObject*) 0L, \u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002A(&fdefaultAllocatorInt) + 8L)), (char*) 0L, 0U, (UPackageMap*) 0L);
          if ((IntPtr) ulandscapeLayerInfoObjectPtr != IntPtr.Zero)
          {
            \u003CModule\u003E.FEdModeLandscape\u002EAddLayerInfo(this.LandscapeEditSystem, ulandscapeLayerInfoObjectPtr);
            this.LandscapeTargetsValue.NotifyChanged();
          }
          \u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002B\u002B(&fdefaultAllocatorInt);
        }
        while (\u003CModule\u003E.TIndexedContainerConstIterator\u003CTArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002Cint\u003E\u002E\u002E_N(&fdefaultAllocatorInt));
      }
      \u003CModule\u003E.TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E\u002EEmpty(this.DroppedAssets.op_MemberSelection(), 0);
      this.DroppedAssets.Reset((TArray\u003CFSelectedAssetInfo\u002CFDefaultAllocator\u003E*) 0L);
    }
    Args.Handled = true;
  }

  protected unsafe void UpdateToolButtons()
  {
    if (*(long*) ((IntPtr) this.LandscapeEditSystem + 392L) == 0L)
      return;
    Visual rootVisual = this.InteropWindow.op_MemberSelection().RootVisual;
    if ((IntPtr) \u003CModule\u003E.Cast\u003Cclass\u0020ALandscape\u003E((UObject*) *(long*) (*(long*) ((IntPtr) this.LandscapeEditSystem + 392L) + 336L)) == IntPtr.Zero)
    {
      FEdModeLandscape* landscapeEditSystem1 = this.LandscapeEditSystem;
      if (*(int*) ((IntPtr) landscapeEditSystem1 + 420L) == *(int*) ((IntPtr) landscapeEditSystem1 + 432L))
        \u003CModule\u003E.FEdModeLandscape\u002ESetCurrentTool(landscapeEditSystem1, 0);
      FEdModeLandscape* landscapeEditSystem2 = this.LandscapeEditSystem;
      int num = *(int*) ((IntPtr) landscapeEditSystem2 + 432L);
      if (num >= \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L)))
        return;
      FLandscapeToolSet* flandscapeToolSetPtr = (FLandscapeToolSet*) *(long*) \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) landscapeEditSystem2 + 452L), num);
      ((UIElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, new string(\u003CModule\u003E.FLandscapeToolSet\u002EGetToolSetName(flandscapeToolSetPtr)))).IsEnabled = false;
    }
    else
    {
      FEdModeLandscape* landscapeEditSystem = this.LandscapeEditSystem;
      int num = *(int*) ((IntPtr) landscapeEditSystem + 432L);
      if (num >= \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L)))
        return;
      FLandscapeToolSet* flandscapeToolSetPtr = (FLandscapeToolSet*) *(long*) \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) landscapeEditSystem + 452L), num);
      ((UIElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, new string(\u003CModule\u003E.FLandscapeToolSet\u002EGetToolSetName(flandscapeToolSetPtr)))).IsEnabled = true;
    }
  }

  protected unsafe void OnLandscapeEditPropertyChanged(object Owner, PropertyChangedEventArgs Args)
  {
    uint num1 = 0;
    if (string.Compare(Args.PropertyName, "HeightmapFileNameString") == 0)
    {
      string fileNameStringValue = this.HeightmapFileNameStringValue;
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, fileNameStringValue);
      // ISSUE: fault handler
      try
      {
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        this.HeightmapFileSize = __calli((__FnPtr<int (IntPtr, char*)>) *(long*) (*(long*) \u003CModule\u003E.GFileManager + 192L))((char*) \u003CModule\u003E.GFileManager, (IntPtr) \u003CModule\u003E.FString\u002E\u002A(fstring2));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      int heightmapFileSize1 = this.HeightmapFileSize;
      if (heightmapFileSize1 == -1)
      {
        if (this.WidthValue != 0)
        {
          this.WidthValue = 0;
          this.OnPropertyChanged("Width");
        }
        if (this.HeightValue != 0)
        {
          this.HeightValue = 0;
          this.OnPropertyChanged("Height");
        }
        if (this.SectionSizeValue != 0)
        {
          this.SectionSizeValue = 0;
          this.OnPropertyChanged("SectionSize");
        }
        if (this.NumSectionsValue != 0)
        {
          this.NumSectionsValue = 0;
          this.OnPropertyChanged("NumSections");
        }
        if (this.TotalComponentsValue != 0)
        {
          this.TotalComponentsValue = 0;
          this.OnPropertyChanged("TotalComponents");
        }
      }
      else
      {
        int num2 = \u003CModule\u003E.appTrunc(\u003CModule\u003E.appSqrt((float) (heightmapFileSize1 >> 1)));
        int heightmapFileSize2 = this.HeightmapFileSize;
        int num3 = heightmapFileSize2 >> 1;
        int num4 = num3 / num2;
        if (num4 * num2 * 2 != heightmapFileSize2)
        {
          do
          {
            num2 += -1;
            if (num2 > 0)
              num4 = num3 / num2;
            else
              goto label_18;
          }
          while (num4 * num2 * 2 != this.HeightmapFileSize);
          goto label_19;
label_18:
          num2 = 0;
          num4 = 0;
          this.SectionSize = 0;
          this.NumSections = 0;
          this.TotalComponents = 0;
        }
label_19:
        this.Width = num2;
        this.Height = num4;
      }
      num1 = 1U;
    }
    if (string.Compare(Args.PropertyName, "Width") == 0)
    {
      int widthValue = this.WidthValue;
      if (widthValue > 0)
      {
        int heightmapFileSize = this.HeightmapFileSize;
        if (heightmapFileSize > 0)
        {
          int num2 = widthValue;
          int num3 = (heightmapFileSize >> 1) / num2;
          if (widthValue * num3 * 2 == heightmapFileSize)
            this.Height = num3;
        }
      }
      num1 = 1U;
    }
    if (string.Compare(Args.PropertyName, "Height") == 0)
    {
      int heightValue = this.HeightValue;
      if (heightValue > 0)
      {
        int heightmapFileSize = this.HeightmapFileSize;
        if (heightmapFileSize > 0)
        {
          int num2 = heightValue;
          int num3 = (heightmapFileSize >> 1) / num2;
          if (heightValue * num3 * 2 == heightmapFileSize)
            this.Width = num3;
        }
      }
      num1 = 1U;
    }
    if (string.Compare(Args.PropertyName, "GizmoHeightmapFileNameString") == 0)
    {
      string fileNameStringValue = this.GizmoHeightmapFileNameStringValue;
      FString fstring1;
      FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, fileNameStringValue);
      // ISSUE: fault handler
      try
      {
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        this.GizmoFileSize = __calli((__FnPtr<int (IntPtr, char*)>) *(long*) (*(long*) \u003CModule\u003E.GFileManager + 192L))((char*) \u003CModule\u003E.GFileManager, (IntPtr) \u003CModule\u003E.FString\u002E\u002A(fstring2));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      int gizmoFileSize1 = this.GizmoFileSize;
      if (gizmoFileSize1 == -1)
      {
        this.GizmoImportWidth = 0;
        this.GizmoImportHeight = 0;
        this.GizmoImportButton.IsEnabled = false;
      }
      else
      {
        int num2 = \u003CModule\u003E.appTrunc(\u003CModule\u003E.appSqrt((float) (gizmoFileSize1 >> 1)));
        int gizmoFileSize2 = this.GizmoFileSize;
        int num3 = gizmoFileSize2 >> 1;
        int num4 = num3 / num2;
        if (num4 * num2 * 2 != gizmoFileSize2)
        {
          do
          {
            num2 += -1;
            if (num2 > 0)
              num4 = num3 / num2;
            else
              goto label_42;
          }
          while (num4 * num2 * 2 != this.GizmoFileSize);
          goto label_43;
label_42:
          num2 = 0;
          num4 = 0;
        }
label_43:
        this.GizmoImportWidth = num2;
        this.GizmoImportHeight = num4;
        this.GizmoImportButton.IsEnabled = true;
      }
    }
    if (string.Compare(Args.PropertyName, "GizmoImportWidth") == 0 && this.GizmoImportWidthValue > 0)
    {
      int gizmoFileSize = this.GizmoFileSize;
      if (gizmoFileSize > 0)
      {
        int num2 = (gizmoFileSize >> 1) / this.GizmoImportWidth;
        if (this.GizmoImportWidth * num2 * 2 == gizmoFileSize)
          this.GizmoImportHeight = num2;
      }
    }
    if (string.Compare(Args.PropertyName, "GizmoImportHeight") == 0 && this.GizmoImportHeightValue > 0)
    {
      int gizmoFileSize = this.GizmoFileSize;
      if (gizmoFileSize > 0)
      {
        int num2 = (gizmoFileSize >> 1) / this.GizmoImportHeight;
        if (this.GizmoImportHeight * num2 * 2 == gizmoFileSize)
          this.GizmoImportWidth = num2;
      }
    }
    if (num1 != 0U)
    {
      this.TotalComponents = 0;
      if (this.Width > 0 && this.Height > 0)
      {
        int num2 = 1;
        int num3;
        int num4;
        do
        {
          num3 = 2;
          num4 = (256 >> num2 - 1) - 1;
          do
          {
            int num5 = num4 * num3;
            if ((this.Width - 1) % num5 != 0 || (this.Height - 1) % num5 != 0)
              num3 += -1;
            else
              goto label_60;
          }
          while (num3 >= 1);
          ++num2;
        }
        while (num2 < 7);
        goto label_61;
label_60:
        this.SectionSize = num2;
        this.NumSections = num3;
        this.TotalComponents = (this.Width - 1) * (this.Height - 1) / \u003CModule\u003E.Square\u003Cint\u003E(num4 * num3);
        goto label_62;
label_61:
        this.SectionSize = 0;
        this.NumSections = 0;
        this.TotalComponents = 0;
      }
    }
label_62:
    if (string.Compare(Args.PropertyName, "SectionSize") == 0)
    {
      if (this.SectionSize > 0)
      {
        int num2 = 2;
        int num3;
        do
        {
          num3 = (256 >> this.SectionSize - 1) - 1;
          int num4 = num3 * num2;
          if ((this.Width - 1) % num4 != 0 || (this.Height - 1) % num4 != 0)
            num2 += -1;
          else
            goto label_67;
        }
        while (num2 >= 1);
        goto label_68;
label_67:
        this.TotalComponents = (this.Width - 1) * (this.Height - 1) / \u003CModule\u003E.Square\u003Cint\u003E(num3 * num2);
        this.NumSections = num2;
        goto label_72;
      }
label_68:
      if (this.TotalComponentsValue != 0)
      {
        this.TotalComponentsValue = 0;
        this.OnPropertyChanged("TotalComponents");
      }
      if (this.NumSectionsValue != 0)
      {
        this.NumSectionsValue = 0;
        this.OnPropertyChanged("NumSections");
      }
    }
label_72:
    if (string.Compare(Args.PropertyName, "NumSections") == 0)
    {
      int numSectionsValue = this.NumSectionsValue;
      if (numSectionsValue > 0)
      {
        int num2 = 1;
        int num3 = numSectionsValue;
        int widthValue = this.WidthValue;
        int num4 = widthValue - 1;
        int num5;
        do
        {
          num5 = (256 >> num2 - 1) - 1;
          int num6 = num3 * num5;
          if (num4 % num6 != 0 || (this.HeightValue - 1) % num6 != 0)
            ++num2;
          else
            goto label_78;
        }
        while (num2 < 7);
        goto label_79;
label_78:
        this.TotalComponents = (this.HeightValue - 1) * (widthValue - 1) / \u003CModule\u003E.Square\u003Cint\u003E(num3 * num5);
        this.SectionSize = num2;
        goto label_83;
      }
label_79:
      if (this.SectionSizeValue != 0)
      {
        this.SectionSizeValue = 0;
        this.OnPropertyChanged("SectionSize");
      }
      if (this.TotalComponentsValue != 0)
      {
        this.TotalComponentsValue = 0;
        this.OnPropertyChanged("TotalComponents");
      }
    }
label_83:
    int sectionSizeValue = this.SectionSizeValue;
    int num7 = (256 >> sectionSizeValue - 1) - 1;
    int heightmapFileSize3 = this.HeightmapFileSize;
    if (heightmapFileSize3 > 0 && this.HeightValue * this.WidthValue * 2 == heightmapFileSize3 || heightmapFileSize3 == -1)
    {
      int widthValue = this.WidthValue;
      if (widthValue > 0)
      {
        int heightValue = this.HeightValue;
        if (heightValue > 0 && sectionSizeValue > 0)
        {
          int numSectionsValue = this.NumSectionsValue;
          if (numSectionsValue > 0)
          {
            int num2 = numSectionsValue * num7;
            if ((widthValue - 1) % num2 == 0 && (heightValue - 1) % num2 == 0)
            {
              this.ImportButton.IsEnabled = true;
              goto label_90;
            }
          }
        }
      }
    }
    this.ImportButton.IsEnabled = false;
label_90:
    this.ChangeComponentSizeButton.IsEnabled = false;
    if (string.Compare(Args.PropertyName, "ConvertNumSections") == 0 || string.Compare(Args.PropertyName, "ConvertSectionSize") == 0 || string.Compare(Args.PropertyName, "ConvertMode") == 0)
    {
      ULandscapeInfo* ulandscapeInfoPtr = (ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
      int num2;
      int num3;
      int num4;
      int num5;
      if ((IntPtr) ulandscapeInfoPtr != IntPtr.Zero && this.ConvertSectionSizeValue > 0 && (this.ConvertNumSectionsValue > 0 && \u003CModule\u003E.ULandscapeInfo\u002EGetLandscapeExtent(ulandscapeInfoPtr, &num2, &num3, &num4, &num5) != 0U))
      {
        int num6 = ((256 >> this.ConvertSectionSizeValue - 1) - 1) * this.ConvertNumSectionsValue;
        if (this.IsConvertModeExpand)
        {
          float num8 = (float) num6;
          this.ConvertWidth = \u003CModule\u003E.appCeil((float) (num4 - num2) / num8) * num6 + 1;
          this.ConvertHeight = \u003CModule\u003E.appCeil((float) (num5 - num3) / num8) * num6 + 1;
        }
        else
        {
          float num8 = (float) num6;
          this.ConvertWidth = \u003CModule\u003E.Max\u003Cint\u003E(1, \u003CModule\u003E.appFloor((float) (num4 - num2) / num8)) * num6 + 1;
          this.ConvertHeight = \u003CModule\u003E.Max\u003Cint\u003E(1, \u003CModule\u003E.appFloor((float) (num5 - num3) / num8)) * num6 + 1;
        }
        this.ConvertTotalComponents = (this.ConvertHeightValue - 1) * (this.ConvertWidthValue - 1) / \u003CModule\u003E.Square\u003Cint\u003E(num6);
        this.ConvertCompQuadNum = num6;
        this.ChangeComponentSizeButton.IsEnabled = true;
      }
    }
    if (string.Compare(Args.PropertyName, "IsViewModeDebugLayer") != 0 || \u003CModule\u003E.GLandscapeViewMode != (ELandscapeViewMode.Type) 2)
      return;
    long num9 = *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if (num9 == 0L)
      return;
    \u003CModule\u003E.ULandscapeInfo\u002EUpdateDebugColorMaterial((ULandscapeInfo*) num9);
  }

  protected void OnLandscapeGizmoPropertyChanged(object Owner, PropertyChangedEventArgs Args) => string.Compare(Args.PropertyName, "GizmoName");

  protected unsafe void OnLandscapeListSelectionChanged(
    object Owner,
    SelectionChangedEventArgs Args)
  {
    FEdModeLandscape* fedModeLandscapePtr = (FEdModeLandscape*) ((IntPtr) this.LandscapeEditSystem + 392L);
    ULandscapeInfo* ulandscapeInfoPtr = (ULandscapeInfo*) *(long*) fedModeLandscapePtr;
    *(long*) fedModeLandscapePtr = 0L;
    TArray\u003CFLandscapeListInfo\u002CFDefaultAllocator\u003E* landscapeList = \u003CModule\u003E.FEdModeLandscape\u002EGetLandscapeList(this.LandscapeEditSystem);
    if (this.LandscapeComboBox.SelectedIndex >= 0 && (IntPtr) landscapeList != IntPtr.Zero && this.LandscapeComboBox.SelectedIndex < \u003CModule\u003E.TArray\u003CFLandscapeListInfo\u002CFDefaultAllocator\u003E\u002ENum(landscapeList))
    {
      FLandscapeListInfo* flandscapeListInfoPtr = \u003CModule\u003E.TArray\u003CFLandscapeListInfo\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(landscapeList, this.LandscapeComboBox.SelectedIndex);
      *(long*) ((IntPtr) this.LandscapeEditSystem + 392L) = *(long*) ((IntPtr) flandscapeListInfoPtr + 32L);
      this.UpdateToolButtons();
      long num1 = *(long*) ((IntPtr) flandscapeListInfoPtr + 32L);
      int num2 = num1 == 0L ? 0 : \u003CModule\u003E.TMapBase\u003Cunsigned\u0020__int64\u002CULandscapeComponent\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003Cunsigned\u0020__int64\u002CULandscapeComponent\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E*) (num1 + 192L));
      FString fstring1;
      FString* fstringPtr1 = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_15KNBIKKIN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, num2);
      // ISSUE: fault handler
      try
      {
        this.LandscapeCompNum.Content = (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr1), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr1));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      long num3 = *(long*) ((IntPtr) flandscapeListInfoPtr + 32L);
      int num4 = num3 == 0L ? 0 : \u003CModule\u003E.TMapBase\u003Cunsigned\u0020__int64\u002CULandscapeHeightfieldCollisionComponent\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003Cunsigned\u0020__int64\u002CULandscapeHeightfieldCollisionComponent\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E*) (num3 + 264L));
      FString fstring2;
      FString* fstringPtr2 = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_15KNBIKKIN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, num4);
      // ISSUE: fault handler
      try
      {
        this.CollisionCompNum.Content = (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr2), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr2));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
      FString fstring3;
      FString* fstringPtr3 = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_15KNBIKKIN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, *(int*) ((IntPtr) flandscapeListInfoPtr + 40L));
      // ISSUE: fault handler
      try
      {
        this.CompQuadNum.Content = (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr3), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr3));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
      FString fstring4;
      FString* fstringPtr4 = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring4, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_15KNBIKKIN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, *(int*) ((IntPtr) flandscapeListInfoPtr + 40L) / *(int*) ((IntPtr) flandscapeListInfoPtr + 44L));
      // ISSUE: fault handler
      try
      {
        this.QuadPerSection.Content = (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr4), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr4));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
      FString fstring5;
      FString* fstringPtr5 = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring5, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_15KNBIKKIN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.Square\u003Cint\u003E(*(int*) ((IntPtr) flandscapeListInfoPtr + 44L)));
      // ISSUE: fault handler
      try
      {
        this.SubsectionNum.Content = (object) new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr5), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr5));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring5);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring5);
      FString fstring6;
      FString* fstringPtr6 = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring6, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_15KNBIKKIN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, *(int*) ((IntPtr) flandscapeListInfoPtr + 48L));
      // ISSUE: fault handler
      try
      {
        this.CurrentWidth.Text = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr6), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr6));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring6);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring6);
      FString fstring7;
      FString* fstringPtr7 = \u003CModule\u003E.FString\u002EPrintf\u003Cint\u003E(&fstring7, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_15KNBIKKIN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, *(int*) ((IntPtr) flandscapeListInfoPtr + 52L));
      // ISSUE: fault handler
      try
      {
        this.CurrentHeight.Text = new string(\u003CModule\u003E.FString\u002E\u002A(fstringPtr7), 0, \u003CModule\u003E.FString\u002ELen(fstringPtr7));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring7);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring7);
    }
    long num5 = *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if (num5 != 0L && num5 != (IntPtr) ulandscapeInfoPtr)
      this.UpdateTargets();
    FEdModeLandscape* landscapeEditSystem = this.LandscapeEditSystem;
    ulong num6 = (ulong) *(long*) ((IntPtr) landscapeEditSystem + 436L);
    if (num6 == 0UL)
      return;
    \u003CModule\u003E.ALandscapeGizmoActiveActor\u002ESetTargetLandscape((ALandscapeGizmoActiveActor*) num6, (ULandscapeInfo*) *(long*) ((IntPtr) landscapeEditSystem + 392L));
  }

  protected unsafe void OnLandscapeTargetLayerPropertyChanged(
    object Owner,
    PropertyChangedEventArgs Args)
  {
    MLandscapeTargetListWrapper targetListWrapper = (MLandscapeTargetListWrapper) Owner;
    if (string.Compare(Args.PropertyName, "Viewmode") == 0)
    {
      int debugColor = targetListWrapper.DebugColor;
      uint num1 = 0;
      TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E* targetList = \u003CModule\u003E.FEdModeLandscape\u002EGetTargetList(this.LandscapeEditSystem);
      if ((IntPtr) targetList != IntPtr.Zero)
      {
        int num2 = 0;
        if (0 < \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002ENum(targetList))
        {
          do
          {
            if (num2 != targetListWrapper.Index)
            {
              FLandscapeLayerStruct* flandscapeLayerStructPtr = (FLandscapeLayerStruct*) *(long*) ((IntPtr) \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(targetList, num2) + 20L);
              if ((IntPtr) flandscapeLayerStructPtr != IntPtr.Zero)
              {
                int num3 = *(int*) ((IntPtr) flandscapeLayerStructPtr + 24L);
                int num4 = num3 & debugColor;
                if (num4 != 0)
                {
                  *(int*) ((IntPtr) flandscapeLayerStructPtr + 24L) = num3 - num4;
                  num1 = 1U;
                }
              }
            }
            ++num2;
          }
          while (num2 < \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002ENum(targetList));
          if (num1 != 0U)
            this.LandscapeTargetsValue.NotifyChanged();
        }
      }
      \u003CModule\u003E.ULandscapeInfo\u002EUpdateDebugColorMaterial((ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L));
    }
    else if (string.Compare(Args.PropertyName, "IsSelected") == 0)
    {
      if (!targetListWrapper.IsSelected)
        return;
      *(int*) ((IntPtr) this.LandscapeEditSystem + 400L) = (int) targetListWrapper.GetTargetType();
      FName fname;
      // ISSUE: cpblk instruction
      __memcpy((IntPtr) this.LandscapeEditSystem + 404L, (IntPtr) targetListWrapper.GetLayerName(&fname), 8);
    }
    else
    {
      if (string.Compare(Args.PropertyName, "PhysMaterial") != 0)
        return;
      long num1 = *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
      if (num1 == 0L)
        return;
      ulong num2 = (ulong) *(long*) (num1 + 336L);
      if (num2 == 0UL)
        return;
      \u003CModule\u003E.ALandscapeProxy\u002EChangedPhysMaterial((ALandscapeProxy*) num2);
    }
  }

  protected unsafe void AlphaTextureUseButton_Click(object Owner, RoutedEventArgs Args)
  {
    uint num1 = 0;
    int num2 = Owner != this.AlphaTextureUseGButton ? (Owner != this.AlphaTextureUseBButton ? (Owner == this.AlphaTextureUseAButton ? 3 : 0) : 2) : 1;
    FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr, ECallbackEventType)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 72L))((ECallbackEventType) gcallbackEvent, new IntPtr(24));
    UTexture2D* utexture2DPtr = \u003CModule\u003E.Cast\u003Cclass\u0020UTexture2D\u003E(\u003CModule\u003E.USelection\u002EGetTop(\u003CModule\u003E.UEditorEngine\u002EGetSelectedSet(\u003CModule\u003E.GEditor, \u003CModule\u003E.UTexture2D\u002EStaticClass()), \u003CModule\u003E.UTexture2D\u002EStaticClass()));
    FString fstring;
    char* chPtr;
    if ((IntPtr) utexture2DPtr != IntPtr.Zero)
    {
      FString* pathName = \u003CModule\u003E.UObject\u002EGetPathName((UObject*) utexture2DPtr, &fstring, (UObject*) 0L);
      // ISSUE: fault handler
      try
      {
        num1 = 1U;
        chPtr = \u003CModule\u003E.FString\u002E\u002A(pathName);
      }
      __fault
      {
        if (((int) num1 & 1) != 0)
        {
          num1 &= 4294967294U;
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
        }
      }
    }
    else
      chPtr = (char*) 0L;
    // ISSUE: fault handler
    try
    {
      int num3 = (int) \u003CModule\u003E.FLandscapeUISettings\u002ESetAlphaTexture((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), chPtr, num2);
    }
    __fault
    {
      if (((int) num1 & 1) != 0)
      {
        num1 &= 4294967294U;
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
      }
    }
    if (((int) num1 & 1) != 0)
    {
      uint num3 = num1 & 4294967294U;
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
    }
    BitmapSource bitmapSource = this.MakeAlphaTextureBitmap();
    if (this.AlphaTextureValue == bitmapSource)
      return;
    this.AlphaTextureValue = bitmapSource;
    this.OnPropertyChanged("AlphaTexture");
  }

  protected unsafe void SyncContentBrowserButton_Click(object Owner, RoutedEventArgs Args)
  {
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      UObject* alphaTexture = (UObject*) \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaTexture((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
      \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, &alphaTexture);
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

  protected unsafe BitmapSource MakeAlphaTextureBitmap()
  {
    int alphaTextureSizeX = \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaTextureSizeX((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    int alphaTextureSizeY = \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaTextureSizeY((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    IntPtr buffer = new IntPtr((long) \u003CModule\u003E.FLandscapeUISettings\u002EGetAlphaTextureData((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)));
    PixelFormat gray8 = PixelFormats.Gray8;
    return BitmapSource.Create(alphaTextureSizeX, alphaTextureSizeY, 96.0, 96.0, gray8, (BitmapPalette) null, buffer, alphaTextureSizeY * alphaTextureSizeX, alphaTextureSizeX);
  }

  protected void OnLandscapeTargetLayerChanged(object Owner, ExecutedRoutedEventArgs Args) => this.TargetListBox.Focus();

  protected void OnLandscapeGizmoChanged(object Owner, ExecutedRoutedEventArgs Args) => this.GizmoListBox.Focus();

  protected unsafe void LandscapeGizmoPin_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    FEdModeLandscape* landscapeEditSystem = this.LandscapeEditSystem;
    if (*(long*) ((IntPtr) landscapeEditSystem + 436L) == 0L)
      return;
    FGizmoHistory* fgizmoHistoryPtr = (FGizmoHistory*) \u003CModule\u003E.operator\u0020new\u003Cstruct\u0020FGizmoHistory\u002Cclass\u0020FDefaultAllocator\u003E(24UL, \u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoHistories((FLandscapeUISettings*) ((IntPtr) landscapeEditSystem + 104L)));
    if ((IntPtr) fgizmoHistoryPtr != IntPtr.Zero)
      \u003CModule\u003E.FGizmoHistory\u002E\u007Bctor\u007D(fgizmoHistoryPtr, \u003CModule\u003E.ALandscapeGizmoActiveActor\u002ESpawnGizmoActor((ALandscapeGizmoActiveActor*) *(long*) ((IntPtr) this.LandscapeEditSystem + 436L)));
    this.GizmoHistoriesValue.NotifyChanged();
  }

  protected unsafe void LandscapeGizmoDelete_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    TArray\u003CFGizmoHistory\u002CFDefaultAllocator\u003E* gizmoHistories = \u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoHistories((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L));
    int currentGizmoIndexValue1 = this.CurrentGizmoIndexValue;
    if (currentGizmoIndexValue1 < 0 || currentGizmoIndexValue1 >= \u003CModule\u003E.TArray\u003CFGizmoHistory\u002CFDefaultAllocator\u003E\u002ENum(gizmoHistories))
      return;
    int currentGizmoIndexValue2 = this.CurrentGizmoIndexValue;
    ALandscapeGizmoActor* alandscapeGizmoActorPtr = (ALandscapeGizmoActor*) *(long*) \u003CModule\u003E.TArray\u003CFGizmoHistory\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(gizmoHistories, currentGizmoIndexValue2);
    int num = (int) \u003CModule\u003E.UWorld\u002EDestroyActor(\u003CModule\u003E.GWorld, (AActor*) alandscapeGizmoActorPtr, 0U, 1U);
    \u003CModule\u003E.TArray\u003CFGizmoHistory\u002CFDefaultAllocator\u003E\u002ERemove(gizmoHistories, this.CurrentGizmoIndexValue, 1);
    this.GizmoHistoriesValue.NotifyChanged();
  }

  protected unsafe void LandscapeGizmoMoveTo_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    FEdModeLandscape* landscapeEditSystem = this.LandscapeEditSystem;
    if (*(long*) ((IntPtr) landscapeEditSystem + 436L) == 0L)
      return;
    TArray\u003CFGizmoHistory\u002CFDefaultAllocator\u003E* gizmoHistories = \u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoHistories((FLandscapeUISettings*) ((IntPtr) landscapeEditSystem + 104L));
    int currentGizmoIndexValue1 = this.CurrentGizmoIndexValue;
    if (currentGizmoIndexValue1 < 0 || currentGizmoIndexValue1 >= \u003CModule\u003E.TArray\u003CFGizmoHistory\u002CFDefaultAllocator\u003E\u002ENum(gizmoHistories))
      return;
    int currentGizmoIndexValue2 = this.CurrentGizmoIndexValue;
    long num1 = *(long*) \u003CModule\u003E.TArray\u003CFGizmoHistory\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(gizmoHistories, currentGizmoIndexValue2);
    long num2 = num1;
    long num3 = *(long*) ((IntPtr) this.LandscapeEditSystem + 436L);
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr, ALandscapeGizmoActor*)>) *(long*) (*(long*) num1 + 1944L))((ALandscapeGizmoActor*) num2, (IntPtr) num3);
  }

  protected unsafe void HeightmapFileButton_Click(object Owner, RoutedEventArgs Args)
  {
    wxString wxString1;
    \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1HM\u0040JNPOJEGC\u0040\u003F\u0024AAH\u003F\u0024AAe\u003F\u0024AAi\u003F\u0024AAg\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AA\u003F5\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CI\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F0\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AA1\u003F\u0024AA6\u003F\u0024AA\u003F\u0024CJ\u003F\u0024AA\u003F\u0024HM\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u0040);
    WxFileDialog wxFileDialog;
    // ISSUE: fault handler
    try
    {
      wxString wxString2;
      \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
      // ISSUE: fault handler
      try
      {
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.LastImportPath);
        // ISSUE: fault handler
        try
        {
          wxString wxString3;
          \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString3, \u003CModule\u003E.FString\u002E\u002A(fstring2));
          // ISSUE: fault handler
          try
          {
            FString fstring3;
            FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_06IBNLALPJ\u0040Import\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
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
                \u003CModule\u003E.WxFileDialog\u002E\u007Bctor\u007D(&wxFileDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString4, &wxString3, &wxString2, &wxString1, 17, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition);
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
          FFilename ffilename;
          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.wxString\u002E\u002EPEB_W(\u003CModule\u003E.wxArrayString\u002E\u005B\u005D(&wxArrayString, 0UL)));
          // ISSUE: fault handler
          try
          {
            string str = new string(\u003CModule\u003E.FString\u002E\u002A((FString*) &ffilename), 0, \u003CModule\u003E.FString\u002ELen((FString*) &ffilename));
            if (this.HeightmapFileNameStringValue != str)
            {
              this.HeightmapFileNameStringValue = str;
              this.OnPropertyChanged("HeightmapFileNameString");
            }
            FString fstring1;
            FString* path = \u003CModule\u003E.FFilename\u002EGetPath(&ffilename, &fstring1);
            // ISSUE: fault handler
            try
            {
              FString fstring2;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(path));
              // ISSUE: fault handler
              try
              {
                this.LastImportPath = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
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
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename);
          }
          \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename);
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
    \u003CModule\u003E.wxFileDialog\u002E\u007Bdtor\u007D((wxFileDialog*) &wxFileDialog);
  }

  protected unsafe void LayerFileButton_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    LandscapeImportLayer parameter = (LandscapeImportLayer) Args.Parameter;
    wxString wxString1;
    \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1HA\u0040IALJPGIP\u0040\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAy\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F5\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CI\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F0\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AA8\u003F\u0024AA\u003F\u0024CJ\u003F\u0024AA\u003F\u0024HM\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024DL\u003F\u0024AA\u003F\u0024CK\u0040);
    WxFileDialog wxFileDialog;
    // ISSUE: fault handler
    try
    {
      wxString wxString2;
      \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
      // ISSUE: fault handler
      try
      {
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.LastImportPath);
        // ISSUE: fault handler
        try
        {
          wxString wxString3;
          \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString3, \u003CModule\u003E.FString\u002E\u002A(fstring2));
          // ISSUE: fault handler
          try
          {
            FString fstring3;
            FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_06IBNLALPJ\u0040Import\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
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
                \u003CModule\u003E.WxFileDialog\u002E\u007Bctor\u007D(&wxFileDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString4, &wxString3, &wxString2, &wxString1, 17, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition);
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
          FFilename ffilename;
          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.wxString\u002E\u002EPEB_W(\u003CModule\u003E.wxArrayString\u002E\u005B\u005D(&wxArrayString, 0UL)));
          // ISSUE: fault handler
          try
          {
            parameter.LayerFilename = new string(\u003CModule\u003E.FString\u002E\u002A((FString*) &ffilename), 0, \u003CModule\u003E.FString\u002ELen((FString*) &ffilename));
            FString fstring1;
            FString* baseFilename = \u003CModule\u003E.FFilename\u002EGetBaseFilename(&ffilename, &fstring1, 1U);
            // ISSUE: fault handler
            try
            {
              FString fstring2;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(baseFilename));
              // ISSUE: fault handler
              try
              {
                parameter.LayerName = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
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
            FString fstring3;
            FString* path = \u003CModule\u003E.FFilename\u002EGetPath(&ffilename, &fstring3);
            // ISSUE: fault handler
            try
            {
              FString fstring2;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(path));
              // ISSUE: fault handler
              try
              {
                this.LastImportPath = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
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
            this.LandscapeImportLayersValue.CheckNeedNewEntry();
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
    \u003CModule\u003E.wxFileDialog\u002E\u007Bdtor\u007D((wxFileDialog*) &wxFileDialog);
  }

  protected unsafe void GizmoHeightmapFileButton_Click(object Owner, RoutedEventArgs Args)
  {
    wxString wxString1;
    \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1HM\u0040JNPOJEGC\u0040\u003F\u0024AAH\u003F\u0024AAe\u003F\u0024AAi\u003F\u0024AAg\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AA\u003F5\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CI\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F0\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AA1\u003F\u0024AA6\u003F\u0024AA\u003F\u0024CJ\u003F\u0024AA\u003F\u0024HM\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u0040);
    WxFileDialog wxFileDialog;
    // ISSUE: fault handler
    try
    {
      wxString wxString2;
      \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
      // ISSUE: fault handler
      try
      {
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.LastImportPath);
        // ISSUE: fault handler
        try
        {
          wxString wxString3;
          \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString3, \u003CModule\u003E.FString\u002E\u002A(fstring2));
          // ISSUE: fault handler
          try
          {
            FString fstring3;
            FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_06IBNLALPJ\u0040Import\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
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
                \u003CModule\u003E.WxFileDialog\u002E\u007Bctor\u007D(&wxFileDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString4, &wxString3, &wxString2, &wxString1, 17, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition);
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
          FFilename ffilename;
          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.wxString\u002E\u002EPEB_W(\u003CModule\u003E.wxArrayString\u002E\u005B\u005D(&wxArrayString, 0UL)));
          // ISSUE: fault handler
          try
          {
            string str = new string(\u003CModule\u003E.FString\u002E\u002A((FString*) &ffilename), 0, \u003CModule\u003E.FString\u002ELen((FString*) &ffilename));
            if (this.GizmoHeightmapFileNameStringValue != str)
            {
              this.GizmoHeightmapFileNameStringValue = str;
              this.OnPropertyChanged("GizmoHeightmapFileNameString");
            }
            FString fstring1;
            FString* path = \u003CModule\u003E.FFilename\u002EGetPath(&ffilename, &fstring1);
            // ISSUE: fault handler
            try
            {
              FString fstring2;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(path));
              // ISSUE: fault handler
              try
              {
                this.LastImportPath = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
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
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename);
          }
          \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename);
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
    \u003CModule\u003E.wxFileDialog\u002E\u007Bdtor\u007D((wxFileDialog*) &wxFileDialog);
  }

  protected unsafe void GizmoLayerFileButton_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    MGizmoImportLayerWrapper parameter = (MGizmoImportLayerWrapper) Args.Parameter;
    wxString wxString1;
    \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1HA\u0040IALJPGIP\u0040\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAy\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F5\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CI\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F0\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AA8\u003F\u0024AA\u003F\u0024CJ\u003F\u0024AA\u003F\u0024HM\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024DL\u003F\u0024AA\u003F\u0024CK\u0040);
    WxFileDialog wxFileDialog;
    // ISSUE: fault handler
    try
    {
      wxString wxString2;
      \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
      // ISSUE: fault handler
      try
      {
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.LastImportPath);
        // ISSUE: fault handler
        try
        {
          wxString wxString3;
          \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString3, \u003CModule\u003E.FString\u002E\u002A(fstring2));
          // ISSUE: fault handler
          try
          {
            FString fstring3;
            FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_06IBNLALPJ\u0040Import\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
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
                \u003CModule\u003E.WxFileDialog\u002E\u007Bctor\u007D(&wxFileDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString4, &wxString3, &wxString2, &wxString1, 17, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition);
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
          FFilename ffilename;
          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.wxString\u002E\u002EPEB_W(\u003CModule\u003E.wxArrayString\u002E\u005B\u005D(&wxArrayString, 0UL)));
          // ISSUE: fault handler
          try
          {
            parameter.LayerFilename = new string(\u003CModule\u003E.FString\u002E\u002A((FString*) &ffilename), 0, \u003CModule\u003E.FString\u002ELen((FString*) &ffilename));
            FString fstring1;
            FString* baseFilename = \u003CModule\u003E.FFilename\u002EGetBaseFilename(&ffilename, &fstring1, 1U);
            // ISSUE: fault handler
            try
            {
              FString fstring2;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(baseFilename));
              // ISSUE: fault handler
              try
              {
                parameter.LayerName = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
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
            FString fstring3;
            FString* path = \u003CModule\u003E.FFilename\u002EGetPath(&ffilename, &fstring3);
            // ISSUE: fault handler
            try
            {
              FString fstring2;
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(path));
              // ISSUE: fault handler
              try
              {
                this.LastImportPath = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring2), 0, \u003CModule\u003E.FString\u002ELen(&fstring2));
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
            this.GizmoImportLayersValue.NotifyChanged();
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
    \u003CModule\u003E.wxFileDialog\u002E\u007Bdtor\u007D((wxFileDialog*) &wxFileDialog);
  }

  protected unsafe void GizmoLayerRemoveButton_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    MGizmoImportLayerWrapper parameter = (MGizmoImportLayerWrapper) Args.Parameter;
    \u003CModule\u003E.TArray\u003CFGizmoImportLayer\u002CFDefaultAllocator\u003E\u002ERemove(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)), parameter.Index, 1);
    this.GizmoImportLayersValue.NotifyChanged();
    if (\u003CModule\u003E.TArray\u003CFGizmoImportLayer\u002CFDefaultAllocator\u003E\u002ENum(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L))) != 0)
      return;
    this.GizmoLayerRemoveButton.IsEnabled = false;
  }

  protected void LayerRemoveButton_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    ((Collection<LandscapeImportLayer>) this.LandscapeImportLayersValue).Remove((LandscapeImportLayer) Args.Parameter);
    this.LandscapeImportLayersValue.CheckNeedNewEntry();
  }

  protected unsafe void TargetLayerRemoveButton_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    MLandscapeTargetListWrapper parameter = (MLandscapeTargetListWrapper) Args.Parameter;
    ULandscapeInfo* ulandscapeInfoPtr = (ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if ((IntPtr) ulandscapeInfoPtr != IntPtr.Zero)
    {
      FName fname1;
      FString fstring1;
      FString* fstringPtr1 = \u003CModule\u003E.FName\u002EToString(parameter.GetLayerName(&fname1), &fstring1);
      uint num;
      // ISSUE: fault handler
      try
      {
        FName fname2;
        FString fstring2;
        FString* fstringPtr2 = \u003CModule\u003E.FName\u002EToString(parameter.GetLayerName(&fname2), &fstring2);
        // ISSUE: fault handler
        try
        {
          FString fstring3;
          FString* fstringPtr3 = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BK\u0040GJIONLDJ\u0040LandscapeMode_RemoveLayer\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
          // ISSUE: fault handler
          try
          {
            num = \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 1, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr3)), \u003CModule\u003E.FString\u002E\u002A(fstringPtr2)), \u003CModule\u003E.FString\u002E\u002A(fstringPtr1));
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
      if (num != 0U)
      {
        FName fname2;
        \u003CModule\u003E.ULandscapeInfo\u002EDeleteLayer(ulandscapeInfoPtr, *parameter.GetLayerName(&fname2));
      }
    }
    this.UpdateTargets();
  }

  protected unsafe void TargetLayerSyncButton_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    MLandscapeTargetListWrapper parameter = (MLandscapeTargetListWrapper) Args.Parameter;
    ULandscapeInfo* ulandscapeInfoPtr = (ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if ((IntPtr) ulandscapeInfoPtr == IntPtr.Zero)
      return;
    FName fname;
    FLandscapeLayerStruct* flandscapeLayerStructPtr = \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002EFindRef((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E*) ((IntPtr) ulandscapeInfoPtr + 112L), *parameter.GetLayerName(&fname));
    if ((IntPtr) flandscapeLayerStructPtr == IntPtr.Zero || *(long*) flandscapeLayerStructPtr == 0L)
      return;
    TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CUObject\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    // ISSUE: fault handler
    try
    {
      UObject* uobjectPtr = (UObject*) *(long*) flandscapeLayerStructPtr;
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

  protected unsafe void TargetReimportButton_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    MLandscapeTargetListWrapper parameter = (MLandscapeTargetListWrapper) Args.Parameter;
    ULandscapeInfo* ulandscapeInfoPtr1 = (ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if ((IntPtr) ulandscapeInfoPtr1 == IntPtr.Zero)
      return;
    if (parameter.GetTargetType() == (ELandscapeToolTargetType) 0)
    {
      ULandscapeInfo* ulandscapeInfoPtr2 = (ULandscapeInfo*) ((IntPtr) ulandscapeInfoPtr1 + 776L);
      if (\u003CModule\u003E.FString\u002ELen((FString*) ulandscapeInfoPtr2) != 0)
      {
        TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E fdefaultAllocator;
        \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
        // ISSUE: fault handler
        try
        {
          int array = (int) \u003CModule\u003E.appLoadFileToArray(&fdefaultAllocator, \u003CModule\u003E.FString\u002E\u002A((FString*) ulandscapeInfoPtr2), \u003CModule\u003E.GFileManager, 0U);
          if (\u003CModule\u003E.ULandscapeInfo\u002EReimportHeightmap(ulandscapeInfoPtr1, \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator), (ushort*) \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator, 0)) == 0U)
          {
            FString fstring;
            FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BO\u0040FJGLCHEB\u0040LandscapeReImport_BadFileSize\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
            // ISSUE: fault handler
            try
            {
              int num = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 0, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr)), \u003CModule\u003E.FString\u002E\u002A((FString*) ulandscapeInfoPtr2)), \u003CModule\u003E.FString\u002E\u002A((FString*) ulandscapeInfoPtr2));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
          }
          else
            goto label_11;
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
        }
        \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
        return;
label_11:
        \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
      }
      else
      {
        FString fstring;
        FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1DM\u0040GOADLMLL\u0040\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AAR\u003F\u0024AAe\u003F\u0024AAI\u003F\u0024AAm\u003F\u0024AAp\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAt\u003F\u0024AA_\u003F\u0024AAB\u003F\u0024AAa\u003F\u0024AAd\u003F\u0024AAF\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAN\u003F\u0024AAa\u003F\u0024AAm\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
        // ISSUE: fault handler
        try
        {
          int num = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf((EAppMsgType) 0, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
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
    else
    {
      FName fname;
      FLandscapeLayerStruct* flandscapeLayerStructPtr1 = \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002EFindRef((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E*) ((IntPtr) ulandscapeInfoPtr1 + 112L), *parameter.GetLayerName(&fname));
      if ((IntPtr) flandscapeLayerStructPtr1 != IntPtr.Zero && *(long*) flandscapeLayerStructPtr1 != 0L)
      {
        FLandscapeLayerStruct* flandscapeLayerStructPtr2 = (FLandscapeLayerStruct*) ((IntPtr) flandscapeLayerStructPtr1 + 32L);
        if (\u003CModule\u003E.FString\u002ELen((FString*) flandscapeLayerStructPtr2) != 0)
        {
          TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E fdefaultAllocator;
          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
          // ISSUE: fault handler
          try
          {
            int array = (int) \u003CModule\u003E.appLoadFileToArray(&fdefaultAllocator, \u003CModule\u003E.FString\u002E\u002A((FString*) flandscapeLayerStructPtr2), \u003CModule\u003E.GFileManager, 0U);
            if (\u003CModule\u003E.ULandscapeInfo\u002EReimportLayermap(ulandscapeInfoPtr1, *(FName*) (*(long*) flandscapeLayerStructPtr1 + 96L), &fdefaultAllocator) == 0U)
            {
              FString fstring;
              FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BO\u0040FJGLCHEB\u0040LandscapeReImport_BadFileSize\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
              // ISSUE: fault handler
              try
              {
                int num = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 0, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr)), \u003CModule\u003E.FString\u002E\u002A((FString*) flandscapeLayerStructPtr2)), \u003CModule\u003E.FString\u002E\u002A((FString*) flandscapeLayerStructPtr2));
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
            }
            else
              goto label_27;
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
          }
          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
          return;
label_27:
          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
          return;
        }
      }
      FString fstring1;
      FString* fstringPtr1 = \u003CModule\u003E.LocalizeUnrealEd(&fstring1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1DM\u0040GOADLMLL\u0040\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAn\u003F\u0024AAd\u003F\u0024AAs\u003F\u0024AAc\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AAe\u003F\u0024AAR\u003F\u0024AAe\u003F\u0024AAI\u003F\u0024AAm\u003F\u0024AAp\u003F\u0024AAo\u003F\u0024AAr\u003F\u0024AAt\u003F\u0024AA_\u003F\u0024AAB\u003F\u0024AAa\u003F\u0024AAd\u003F\u0024AAF\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAN\u003F\u0024AAa\u003F\u0024AAm\u003F\u0024AAe\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
      // ISSUE: fault handler
      try
      {
        int num = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf((EAppMsgType) 0, \u003CModule\u003E.FString\u002E\u002A(fstringPtr1));
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

  protected unsafe void TargetLayerSetPhysMaterialButton_Click(
    object Owner,
    ExecutedRoutedEventArgs Args)
  {
    FCallbackEventObserver* gcallbackEvent = \u003CModule\u003E.GCallbackEvent;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr, ECallbackEventType)>) *(long*) (*(long*) \u003CModule\u003E.GCallbackEvent + 72L))((ECallbackEventType) gcallbackEvent, new IntPtr(24));
    UPhysicalMaterial* uphysicalMaterialPtr = \u003CModule\u003E.Cast\u003Cclass\u0020UPhysicalMaterial\u003E(\u003CModule\u003E.USelection\u002EGetTop(\u003CModule\u003E.UEditorEngine\u002EGetSelectedSet(\u003CModule\u003E.GEditor, \u003CModule\u003E.UPhysicalMaterial\u002EStaticClass()), \u003CModule\u003E.UPhysicalMaterial\u002EStaticClass()));
    if ((IntPtr) uphysicalMaterialPtr == IntPtr.Zero)
      return;
    MLandscapeTargetListWrapper parameter = (MLandscapeTargetListWrapper) Args.Parameter;
    FString fstring;
    FString* pathName = \u003CModule\u003E.UObject\u002EGetPathName((UObject*) uphysicalMaterialPtr, &fstring, (UObject*) 0L);
    // ISSUE: fault handler
    try
    {
      parameter.PhysMaterial = new string(\u003CModule\u003E.FString\u002E\u002A(pathName), 0, \u003CModule\u003E.FString\u002ELen(pathName));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
  }

  protected unsafe void TargetSetFilePathButton_Click(object Owner, ExecutedRoutedEventArgs Args)
  {
    wxString wxString1;
    \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1HA\u0040IALJPGIP\u0040\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAy\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F5\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024CI\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F0\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AA8\u003F\u0024AA\u003F\u0024CJ\u003F\u0024AA\u003F\u0024HM\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024DL\u003F\u0024AA\u003F\u0024CK\u0040);
    WxFileDialog wxFileDialog;
    // ISSUE: fault handler
    try
    {
      wxString wxString2;
      \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040);
      // ISSUE: fault handler
      try
      {
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, this.LastImportPath);
        // ISSUE: fault handler
        try
        {
          wxString wxString3;
          \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString3, \u003CModule\u003E.FString\u002E\u002A(fstring2));
          // ISSUE: fault handler
          try
          {
            FString fstring3;
            FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_06IBNLALPJ\u0040Import\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
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
                \u003CModule\u003E.WxFileDialog\u002E\u007Bctor\u007D(&wxFileDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString4, &wxString3, &wxString2, &wxString1, 17, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition);
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
          FFilename ffilename;
          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.wxString\u002E\u002EPEB_W(\u003CModule\u003E.wxArrayString\u002E\u005B\u005D(&wxArrayString, 0UL)));
          // ISSUE: fault handler
          try
          {
            ((MLandscapeTargetListWrapper) Args.Parameter).SourceFilePath = new string(\u003CModule\u003E.FString\u002E\u002A((FString*) &ffilename), 0, \u003CModule\u003E.FString\u002ELen((FString*) &ffilename));
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
    \u003CModule\u003E.wxFileDialog\u002E\u007Bdtor\u007D((wxFileDialog*) &wxFileDialog);
  }

  protected unsafe void AddLayerButton_Click(object Owner, RoutedEventArgs Args)
  {
    float num1 = \u003CModule\u003E.Clamp\u003Cfloat\u003E(this.HardnessValue, 0.0f, 1f);
    if ((double) this.HardnessValue != (double) num1)
    {
      this.HardnessValue = num1;
      this.OnPropertyChanged("Hardness");
    }
    ULandscapeInfo* ulandscapeInfoPtr = (ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if ((IntPtr) ulandscapeInfoPtr != IntPtr.Zero)
    {
      // ISSUE: cast to a reference type
      // ISSUE: variable of a reference type
      byte* local = (byte*) this.AddLayerNameStringValue;
      if (local != null)
        local = (long) (uint) RuntimeHelpers.OffsetToStringData + local;
      // ISSUE: explicit reference operation
      fixed (byte* numPtr = &^local)
      {
        FName fname1;
        \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname1, (char*) numPtr, (EFindName) 1, 1U);
        FName fname2;
        \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname2, (EName) 0);
        if (\u003CModule\u003E.FName\u002E\u003D\u003D(&fname1, &fname2) != 0U)
        {
          FString fstring;
          FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0CA\u0040JKJDHIBP\u0040LandscapeMode_AddLayerEnterName\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
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
          return;
        }
        if ((IntPtr) \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002EFindRef((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E*) ((IntPtr) ulandscapeInfoPtr + 112L), fname1) == IntPtr.Zero && \u003CModule\u003E.FName\u002E\u003D\u003D(&fname1, &\u003CModule\u003E.\u003FDataWeightmapName\u0040ALandscape\u0040\u00402VFName\u0040\u0040A) == 0U)
        {
          if (*(long*) ((IntPtr) ulandscapeInfoPtr + 336L) != 0L)
          {
            FString fstring;
            FString* fstringPtr = \u003CModule\u003E.FName\u002EToString(&fname1, &fstring);
            ULandscapeLayerInfoObject* layerInfo;
            // ISSUE: fault handler
            try
            {
              layerInfo = \u003CModule\u003E.ALandscapeProxy\u002EGetLayerInfo((ALandscapeProxy*) *(long*) ((IntPtr) ulandscapeInfoPtr + 336L), \u003CModule\u003E.FString\u002E\u002A(fstringPtr), (UPackage*) 0L, (char*) 0L);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
            if ((IntPtr) layerInfo != IntPtr.Zero)
            {
              // ISSUE: cpblk instruction
              __memcpy((IntPtr) layerInfo + 96L, ref fname1, 8);
              float hardnessValue = this.HardnessValue;
              *(float*) ((IntPtr) layerInfo + 112L) = hardnessValue;
              *(int*) ((IntPtr) layerInfo + 116L) = *(int*) ((IntPtr) layerInfo + 116L) ^ ((int) this.bNoBlending ^ *(int*) ((IntPtr) layerInfo + 116L)) & 1;
            }
          }
        }
        else
        {
          FString fstring1;
          FString* fstringPtr1 = \u003CModule\u003E.FName\u002EToString(&fname1, &fstring1);
          // ISSUE: fault handler
          try
          {
            FString fstring2;
            FString* fstringPtr2 = \u003CModule\u003E.FName\u002EToString(&fname1, &fstring2);
            // ISSUE: fault handler
            try
            {
              FString fstring3;
              FString* fstringPtr3 = \u003CModule\u003E.LocalizeUnrealEd(&fstring3, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0CA\u0040JKBAFLG\u0040LandscapeMode_AddLayerDuplicate\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
              // ISSUE: fault handler
              try
              {
                int num2 = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 0, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr3)), \u003CModule\u003E.FString\u002E\u002A(fstringPtr2)), \u003CModule\u003E.FString\u002E\u002A(fstringPtr1));
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
          return;
        }
      }
    }
    string str = "";
    if (this.AddLayerNameStringValue != str)
    {
      this.AddLayerNameStringValue = str;
      this.OnPropertyChanged("AddLayerNameString");
    }
    this.UpdateTargets();
  }

  protected unsafe void GizmoLayerAddButton_Click(object Owner, RoutedEventArgs Args)
  {
    FGizmoImportLayer* fgizmoImportLayerPtr = (FGizmoImportLayer*) \u003CModule\u003E.operator\u0020new\u003Cstruct\u0020FGizmoImportLayer\u002Cclass\u0020FDefaultAllocator\u003E(36UL, \u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)));
    if ((IntPtr) fgizmoImportLayerPtr != IntPtr.Zero)
      \u003CModule\u003E.FGizmoImportLayer\u002E\u007Bctor\u007D(fgizmoImportLayerPtr);
    this.GizmoImportLayersValue.NotifyChanged();
    this.GizmoLayerRemoveButton.IsEnabled = true;
  }

  protected unsafe void GizmoLastLayerRemoveButton_Click(object Owner, RoutedEventArgs Args)
  {
    if (\u003CModule\u003E.TArray\u003CFGizmoImportLayer\u002CFDefaultAllocator\u003E\u002ENum(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L))) - 1 >= 0)
    {
      \u003CModule\u003E.TArray\u003CFGizmoImportLayer\u002CFDefaultAllocator\u003E\u002ERemove(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)), \u003CModule\u003E.TArray\u003CFGizmoImportLayer\u002CFDefaultAllocator\u003E\u002ENum(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L))) - 1, 1);
      this.GizmoImportLayersValue.NotifyChanged();
    }
    if (\u003CModule\u003E.TArray\u003CFGizmoImportLayer\u002CFDefaultAllocator\u003E\u002ENum(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L))) != 0)
      return;
    this.GizmoLayerRemoveButton.IsEnabled = false;
  }

  protected unsafe void GizmoImportButton_Click(object Owner, RoutedEventArgs Args)
  {
    if (*(long*) ((IntPtr) this.LandscapeEditSystem + 436L) == 0L)
      return;
    TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E fdefaultAllocator1;
    \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
    // ISSUE: fault handler
    try
    {
      if (this.GizmoFileSize > 0)
      {
        string fileNameStringValue = this.GizmoHeightmapFileNameStringValue;
        FString fstring1;
        FString* fstring2 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring1, fileNameStringValue);
        // ISSUE: fault handler
        try
        {
          int array = (int) \u003CModule\u003E.appLoadFileToArray(&fdefaultAllocator1, \u003CModule\u003E.FString\u002E\u002A(fstring2), \u003CModule\u003E.GFileManager, 0U);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      }
      if (this.GizmoFileSize <= 0)
      {
        FString fstring;
        FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0CB\u0040MILJFHCM\u0040LandscapeImport_BadHeightmapSize\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
        // ISSUE: fault handler
        try
        {
          int num = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf((EAppMsgType) 0, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
        }
        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
      }
      else
        goto label_14;
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    return;
label_14:
    TArray\u003CFName\u002CFDefaultAllocator\u003E fdefaultAllocator2;
    TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E fdefaultAllocator3;
    TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator4;
    FGizmoImportLayer fgizmoImportLayer;
    FString fstring3;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator3);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator4);
          // ISSUE: fault handler
          try
          {
            int num1 = 0;
            if (0 < \u003CModule\u003E.TArray\u003CFGizmoImportLayer\u002CFDefaultAllocator\u003E\u002ENum(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L))))
            {
              do
              {
                FGizmoImportLayer* fgizmoImportLayerPtr = \u003CModule\u003E.TArray\u003CFGizmoImportLayer\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)), num1);
                \u003CModule\u003E.FString\u002E\u007Bctor\u007D((FString*) &fgizmoImportLayer, (FString*) fgizmoImportLayerPtr);
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.FString\u002E\u007Bctor\u007D((FString*) ((IntPtr) &fgizmoImportLayer + 16), (FString*) ((IntPtr) fgizmoImportLayerPtr + 16L));
                  // ISSUE: fault handler
                  try
                  {
                    // ISSUE: cast to a reference type
                    // ISSUE: explicit reference operation
                    ^(int&) ((IntPtr) &fgizmoImportLayer + 32) = *(int*) ((IntPtr) fgizmoImportLayerPtr + 32L);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) (ref fgizmoImportLayer + 16L));
                  }
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fgizmoImportLayer);
                }
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.FString\u002EReplace((FString*) ((IntPtr) &fgizmoImportLayer + 16), &fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_13HOIJIPNN\u0040\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040, 0U);
                  // ISSUE: fault handler
                  try
                  {
                    // ISSUE: cast to a reference type
                    // ISSUE: explicit reference operation
                    if (\u003CModule\u003E.FString\u002E\u0021\u003D((FString*) &fgizmoImportLayer, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040) != 0U && ^(int&) ((IntPtr) &fgizmoImportLayer + 32) == 0)
                    {
                      TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = (TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.operator\u0020new\u003Cclass\u0020TArray\u003Cunsigned\u0020char\u002Cclass\u0020FDefaultAllocator\u003E\u002Cclass\u0020FDefaultAllocator\u003E(16UL, &fdefaultAllocator3);
                      TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = (IntPtr) fdefaultAllocatorPtr1 == IntPtr.Zero ? (TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr1);
                      int array = (int) \u003CModule\u003E.appLoadFileToArray(fdefaultAllocatorPtr2, \u003CModule\u003E.FString\u002E\u002A((FString*) &fgizmoImportLayer), \u003CModule\u003E.GFileManager, 0U);
                      int importWidthValue = this.GizmoImportWidthValue;
                      int importHeightValue = this.GizmoImportHeightValue;
                      if (\u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr2) == importHeightValue * importWidthValue)
                      {
                        if (\u003CModule\u003E.FString\u002E\u003D\u003D(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040) == 0U)
                        {
                          FName* fnamePtr = (FName*) \u003CModule\u003E.operator\u0020new\u003Cclass\u0020FName\u002Cclass\u0020FDefaultAllocator\u003E(8UL, &fdefaultAllocator2);
                          if ((IntPtr) fnamePtr != IntPtr.Zero)
                            \u003CModule\u003E.FName\u002E\u007Bctor\u007D(fnamePtr, \u003CModule\u003E.FString\u002E\u002A(&fstring3), (EFindName) 1, 1U);
                          byte* numPtr = \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr2, 0);
                          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator4, &numPtr);
                        }
                        else
                          goto label_56;
                      }
                      else
                        goto label_38;
                    }
                    else if (\u003CModule\u003E.FString\u002E\u0021\u003D(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040) != 0U)
                      goto label_74;
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
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FGizmoImportLayer\u002E\u007Bdtor\u007D), (void*) &fgizmoImportLayer);
                }
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &fgizmoImportLayer + 16));
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fgizmoImportLayer);
                }
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) &fgizmoImportLayer);
                ++num1;
              }
              while (num1 < \u003CModule\u003E.TArray\u003CFGizmoImportLayer\u002CFDefaultAllocator\u003E\u002ENum(\u003CModule\u003E.FLandscapeUISettings\u002EGetGizmoImportLayers((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L))));
              goto label_87;
label_38:
              // ISSUE: fault handler
              try
              {
                // ISSUE: fault handler
                try
                {
                  FString fstring1;
                  FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring1, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BN\u0040CGAMHGJ\u0040LandscapeImport_BadLayerSize\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
                  // ISSUE: fault handler
                  try
                  {
                    int num2 = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 0, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr)), \u003CModule\u003E.FString\u002E\u002A((FString*) &fgizmoImportLayer)), \u003CModule\u003E.FString\u002E\u002A((FString*) &fgizmoImportLayer));
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
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FGizmoImportLayer\u002E\u007Bdtor\u007D), (void*) &fgizmoImportLayer);
              }
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &fgizmoImportLayer + 16));
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fgizmoImportLayer);
              }
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) &fgizmoImportLayer);
            }
            else
              goto label_87;
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator4);
          }
          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator4);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
        }
        \u003CModule\u003E.TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
      }
      \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    return;
label_56:
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        // ISSUE: fault handler
        try
        {
          // ISSUE: fault handler
          try
          {
            // ISSUE: fault handler
            try
            {
              // ISSUE: fault handler
              try
              {
                FString fstring1;
                FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring1, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BN\u0040EGMNAJEA\u0040LandscapeImport_BadLayerName\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
                // ISSUE: fault handler
                try
                {
                  int num = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 0, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr)), \u003CModule\u003E.FString\u002E\u002A((FString*) &fgizmoImportLayer)), \u003CModule\u003E.FString\u002E\u002A((FString*) &fgizmoImportLayer));
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
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FGizmoImportLayer\u002E\u007Bdtor\u007D), (void*) &fgizmoImportLayer);
            }
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &fgizmoImportLayer + 16));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fgizmoImportLayer);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) &fgizmoImportLayer);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator4);
          }
          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator4);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
        }
        \u003CModule\u003E.TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
      }
      \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    return;
label_74:
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        // ISSUE: fault handler
        try
        {
          // ISSUE: fault handler
          try
          {
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring3);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FGizmoImportLayer\u002E\u007Bdtor\u007D), (void*) &fgizmoImportLayer);
            }
            // ISSUE: fault handler
            try
            {
              \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) ((IntPtr) &fgizmoImportLayer + 16));
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fgizmoImportLayer);
            }
            \u003CModule\u003E.FString\u002E\u007Bdtor\u007D((FString*) &fgizmoImportLayer);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator4);
          }
          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator4);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
        }
        \u003CModule\u003E.TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
      }
      \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    return;
label_87:
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        // ISSUE: fault handler
        try
        {
          // ISSUE: fault handler
          try
          {
            byte** numPtr1 = \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator4) == 0 ? (byte**) 0L : \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator4, 0);
            TArray\u003CFName\u002CFDefaultAllocator\u003E fdefaultAllocator5;
            TArray\u003CFName\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = &fdefaultAllocator5;
            TArray\u003CFName\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator5, &fdefaultAllocator2);
            int importHeightValue;
            int importWidthValue;
            long num;
            byte* numPtr2;
            // ISSUE: fault handler
            try
            {
              importHeightValue = this.GizmoImportHeightValue;
              importWidthValue = this.GizmoImportWidthValue;
              num = *(long*) ((IntPtr) this.LandscapeEditSystem + 436L);
              numPtr2 = \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, 0);
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) fdefaultAllocatorPtr1);
            }
            \u003CModule\u003E.ALandscapeGizmoActiveActor\u002EImport((ALandscapeGizmoActiveActor*) num, importWidthValue, importHeightValue, (ushort*) numPtr2, fdefaultAllocatorPtr2, numPtr1);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator4);
          }
          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator4);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
        }
        \u003CModule\u003E.TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
      }
      \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
  }

  protected unsafe void ImportButton_Click(object Owner, RoutedEventArgs Args)
  {
    int num1 = (256 >> this.SectionSizeValue - 1) - 1;
    TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E fdefaultAllocator1;
    \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
    FString fstring1;
    TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E fdefaultAllocator2;
    TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E fdefaultAllocator3;
    TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E fdefaultAllocator4;
    FString fstring2;
    FString fstring3;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
      // ISSUE: fault handler
      try
      {
        if (this.HeightmapFileSize > 0)
        {
          string fileNameStringValue = this.HeightmapFileNameStringValue;
          FString fstring4;
          FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, fileNameStringValue);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.FString\u002E\u003D(&fstring1, fstring5);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
          int array = (int) \u003CModule\u003E.appLoadFileToArray(&fdefaultAllocator1, \u003CModule\u003E.FString\u002E\u002A(&fstring1), \u003CModule\u003E.GFileManager, 0U);
        }
        else
        {
          int widthValue1 = this.WidthValue;
          int heightValue1 = this.HeightValue;
          \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002EAdd(&fdefaultAllocator1, heightValue1 * widthValue1 * 2);
          ushort* numPtr1 = (ushort*) \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, 0);
          int num2 = 0;
          if (0 < this.HeightValue * this.WidthValue)
          {
            ushort* numPtr2 = numPtr1;
            int widthValue2;
            int heightValue2;
            do
            {
              *numPtr2 = (ushort) 32768;
              ++num2;
              numPtr2 += 2L;
              widthValue2 = this.WidthValue;
              heightValue2 = this.HeightValue;
            }
            while (num2 < heightValue2 * widthValue2);
          }
        }
        \u003CModule\u003E.TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
        // ISSUE: fault handler
        try
        {
          \u003CModule\u003E.TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator3);
          // ISSUE: fault handler
          try
          {
            \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator4);
            // ISSUE: fault handler
            try
            {
              int index = 0;
              if (0 < ((Collection<LandscapeImportLayer>) this.LandscapeImportLayersValue).Count)
              {
                LandscapeImportLayers importLayersValue;
                do
                {
                  LandscapeImportLayer landscapeImportLayer = ((Collection<LandscapeImportLayer>) this.LandscapeImportLayersValue)[index];
                  \u003CModule\u003E.CLRTools\u002EToFString(&fstring2, landscapeImportLayer.LayerFilename);
                  // ISSUE: fault handler
                  try
                  {
                    FString fstring4;
                    FString* fstring5 = \u003CModule\u003E.CLRTools\u002EToFString(&fstring4, landscapeImportLayer.LayerName);
                    // ISSUE: fault handler
                    try
                    {
                      \u003CModule\u003E.FString\u002EReplace(fstring5, &fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_13HOIJIPNN\u0040\u003F\u0024AA\u003F5\u003F\u0024AA\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040, 0U);
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
                      float num2 = \u003CModule\u003E.Clamp\u003Cfloat\u003E(landscapeImportLayer.Hardness, 0.0f, 1f);
                      int num3 = landscapeImportLayer.NoBlending ? 1 : 0;
                      if (\u003CModule\u003E.FString\u002E\u0021\u003D(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040) != 0U)
                      {
                        TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = (TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.operator\u0020new\u003Cclass\u0020TArray\u003Cunsigned\u0020char\u002Cclass\u0020FDefaultAllocator\u003E\u002Cclass\u0020FDefaultAllocator\u003E(16UL, &fdefaultAllocator3);
                        TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = (IntPtr) fdefaultAllocatorPtr1 == IntPtr.Zero ? (TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr1);
                        int array = (int) \u003CModule\u003E.appLoadFileToArray(fdefaultAllocatorPtr2, \u003CModule\u003E.FString\u002E\u002A(&fstring2), \u003CModule\u003E.GFileManager, 0U);
                        int widthValue = this.WidthValue;
                        int heightValue = this.HeightValue;
                        if (\u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002ENum(fdefaultAllocatorPtr2) == heightValue * widthValue)
                        {
                          if (\u003CModule\u003E.FString\u002E\u003D\u003D(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040) == 0U)
                          {
                            FLandscapeLayerInfo* flandscapeLayerInfoPtr = (FLandscapeLayerInfo*) \u003CModule\u003E.operator\u0020new\u003Cstruct\u0020FLandscapeLayerInfo\u002Cclass\u0020FDefaultAllocator\u003E(56UL, &fdefaultAllocator2);
                            if ((IntPtr) flandscapeLayerInfoPtr != IntPtr.Zero)
                            {
                              FName fname;
                              \u003CModule\u003E.FLandscapeLayerInfo\u002E\u007Bctor\u007D(flandscapeLayerInfoPtr, *\u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, \u003CModule\u003E.FString\u002E\u002A(&fstring3), (EFindName) 1, 1U), num2, (uint) num3, \u003CModule\u003E.FString\u002E\u002A(&fstring2));
                            }
                            byte* numPtr = \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr2, 0);
                            \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator4, &numPtr);
                          }
                          else
                            goto label_50;
                        }
                        else
                          goto label_32;
                      }
                      else if (\u003CModule\u003E.FString\u002E\u0021\u003D(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_11LOCGONAA\u0040\u003F\u0024AA\u003F\u0024AA\u0040) != 0U)
                      {
                        TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = (TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E*) \u003CModule\u003E.operator\u0020new\u003Cclass\u0020TArray\u003Cunsigned\u0020char\u002Cclass\u0020FDefaultAllocator\u003E\u002Cclass\u0020FDefaultAllocator\u003E(16UL, &fdefaultAllocator3);
                        TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = (IntPtr) fdefaultAllocatorPtr1 == IntPtr.Zero ? (TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E*) 0L : \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(fdefaultAllocatorPtr1);
                        int widthValue = this.WidthValue;
                        int heightValue = this.HeightValue;
                        \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002EAddZeroed(fdefaultAllocatorPtr2, heightValue * widthValue);
                        FLandscapeLayerInfo* flandscapeLayerInfoPtr = (FLandscapeLayerInfo*) \u003CModule\u003E.operator\u0020new\u003Cstruct\u0020FLandscapeLayerInfo\u002Cclass\u0020FDefaultAllocator\u003E(56UL, &fdefaultAllocator2);
                        if ((IntPtr) flandscapeLayerInfoPtr != IntPtr.Zero)
                        {
                          FName fname;
                          \u003CModule\u003E.FLandscapeLayerInfo\u002E\u007Bctor\u007D(flandscapeLayerInfoPtr, *\u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, \u003CModule\u003E.FString\u002E\u002A(&fstring3), (EFindName) 1, 1U), num2, (uint) num3, (char*) 0L);
                        }
                        byte* numPtr = \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(fdefaultAllocatorPtr2, 0);
                        \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator4, &numPtr);
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
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
                  }
                  \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring2);
                  ++index;
                  importLayersValue = this.LandscapeImportLayersValue;
                }
                while (index < ((Collection<LandscapeImportLayer>) importLayersValue).Count);
                goto label_68;
label_32:
                // ISSUE: fault handler
                try
                {
                  // ISSUE: fault handler
                  try
                  {
                    FString fstring4;
                    FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring4, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BN\u0040CGAMHGJ\u0040LandscapeImport_BadLayerSize\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
                    // ISSUE: fault handler
                    try
                    {
                      int num2 = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 0, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr)), \u003CModule\u003E.FString\u002E\u002A(&fstring2)), \u003CModule\u003E.FString\u002E\u002A(&fstring2));
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
              else
                goto label_68;
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator4);
            }
            \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator4);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
          }
          \u003CModule\u003E.TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    return;
label_50:
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        // ISSUE: fault handler
        try
        {
          // ISSUE: fault handler
          try
          {
            // ISSUE: fault handler
            try
            {
              // ISSUE: fault handler
              try
              {
                // ISSUE: fault handler
                try
                {
                  FString fstring4;
                  FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring4, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BN\u0040EGMNAJEA\u0040LandscapeImport_BadLayerName\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
                  // ISSUE: fault handler
                  try
                  {
                    int num2 = (int) \u003CModule\u003E.\u003FA0x3a4a4fc4\u002EappMsgf\u003Cwchar_t\u0020const\u0020\u002A\u003E((EAppMsgType) 0, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr)), \u003CModule\u003E.FString\u002E\u002A(&fstring2)), \u003CModule\u003E.FString\u002E\u002A(&fstring2));
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
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator4);
            }
            \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator4);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
          }
          \u003CModule\u003E.TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    return;
label_68:
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        // ISSUE: fault handler
        try
        {
          // ISSUE: fault handler
          try
          {
            // ISSUE: fault handler
            try
            {
              int heightValue1 = this.HeightValue;
              int widthValue1 = this.WidthValue;
              FName fname;
              FVector fvector;
              FRotator frotator;
              ALandscape* alandscapePtr = \u003CModule\u003E.Cast\u003Cclass\u0020ALandscape\u003E((UObject*) \u003CModule\u003E.UWorld\u002ESpawnActor(\u003CModule\u003E.GWorld, \u003CModule\u003E.ALandscape\u002EStaticClass(), *\u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (EName) 0), \u003CModule\u003E.FVector\u002E\u007Bctor\u007D(&fvector, (float) (widthValue1 * -64), (float) (heightValue1 * -64), 0.0f), \u003CModule\u003E.FRotator\u002E\u007Bctor\u007D(&frotator, 0, 0, 0), (AActor*) 0L, 0U, 0U, (AActor*) 0L, (APawn*) 0L, 0U, (ULevel*) 0L));
              byte** numPtr1 = \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum(&fdefaultAllocator4) == 0 ? (byte**) 0L : \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator4, 0);
              TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E fdefaultAllocator5;
              TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr1 = &fdefaultAllocator5;
              TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E* fdefaultAllocatorPtr2 = \u003CModule\u003E.TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator5, &fdefaultAllocator2);
              int num2;
              int heightValue2;
              int widthValue2;
              int num3;
              byte* numPtr2;
              char* chPtr;
              // ISSUE: fault handler
              try
              {
                int numSectionsValue = this.NumSectionsValue;
                num2 = numSectionsValue;
                int num4 = numSectionsValue;
                heightValue2 = this.HeightValue;
                widthValue2 = this.WidthValue;
                int num5 = num1;
                num3 = num4 * num5;
                numPtr2 = \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(&fdefaultAllocator1, 0);
                chPtr = \u003CModule\u003E.FString\u002E\u002A(&fstring1);
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) fdefaultAllocatorPtr1);
              }
              \u003CModule\u003E.ALandscape\u002EImport(alandscapePtr, widthValue2, heightValue2, num3, num2, num1, (ushort*) numPtr2, chPtr, fdefaultAllocatorPtr2, numPtr1);
              this.HeightmapFileNameString = "";
              this.Width = 0;
              this.Height = 0;
              this.SectionSize = 0;
              this.NumSections = 0;
              this.TotalComponents = 0;
              ((Collection<LandscapeImportLayer>) this.LandscapeImportLayersValue).Clear();
              this.LandscapeImportLayersValue.CheckNeedNewEntry();
              this.UpdateLandscapeList();
            }
            __fault
            {
              // ISSUE: method pointer
              // ISSUE: cast to a function pointer type
              \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator4);
            }
            \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator4);
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator3);
          }
          \u003CModule\u003E.TArray\u003CTArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator3);
        }
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator2);
        }
        \u003CModule\u003E.TArray\u003CFLandscapeLayerInfo\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator2);
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003Cunsigned\u0020char\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
  }

  protected unsafe void ChangeComponentSizeButton_Click(object Owner, RoutedEventArgs Args)
  {
    ULandscapeInfo* ulandscapeInfoPtr = (ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if ((IntPtr) ulandscapeInfoPtr == IntPtr.Zero)
      return;
    \u003CModule\u003E.ULandscapeInfo\u002EChangeComponentSetting(ulandscapeInfoPtr, this.ConvertWidthValue, this.ConvertHeightValue, this.ConvertNumSectionsValue, (256 >> this.ConvertSectionSizeValue - 1) - 1);
    if (this.ConvertWidthValue != 0)
    {
      this.ConvertWidthValue = 0;
      this.OnPropertyChanged("ConvertWidth");
    }
    if (this.ConvertHeightValue != 0)
    {
      this.ConvertHeightValue = 0;
      this.OnPropertyChanged("ConvertHeight");
    }
    if (this.ConvertSectionSizeValue != 0)
    {
      this.ConvertSectionSizeValue = 0;
      this.OnPropertyChanged("ConvertSectionSize");
    }
    if (this.ConvertNumSectionsValue != 0)
    {
      this.ConvertNumSectionsValue = 0;
      this.OnPropertyChanged("ConvertNumSections");
    }
    if (this.ConvertTotalComponentsValue != 0)
    {
      this.ConvertTotalComponentsValue = 0;
      this.OnPropertyChanged("ConvertTotalComponents");
    }
    if (this.ConvertCompQuadNumValue != 0)
    {
      this.ConvertCompQuadNumValue = 0;
      this.OnPropertyChanged("ConvertCompQuadNum");
    }
    int num = \u003CModule\u003E.FEdModeLandscape\u002EUpdateLandscapeList(this.LandscapeEditSystem);
    this.LandscapeListsValue.NotifyChanged();
    this.LandscapeComboBox.SelectedIndex = num;
    this.UpdateTargets();
  }

  protected unsafe void UpdateLODBiasButton_Click(object Owner, RoutedEventArgs Args)
  {
    ULandscapeInfo* ulandscapeInfoPtr = (ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if ((IntPtr) ulandscapeInfoPtr == IntPtr.Zero)
      return;
    \u003CModule\u003E.ULandscapeInfo\u002EUpdateLODBias(ulandscapeInfoPtr, (float) ((RangeBase) this.LODBiasThresholdSlider).Value);
  }

  protected unsafe void ExportButton_Click(object Owner, RoutedEventArgs Args)
  {
    ULandscapeInfo* ulandscapeInfoPtr1 = (ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if ((IntPtr) ulandscapeInfoPtr1 == IntPtr.Zero)
      return;
    TArray\u003CFName\u002CFDefaultAllocator\u003E fdefaultAllocator1;
    \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator1);
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator2;
    TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E.TIterator titerator;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator2);
      // ISSUE: fault handler
      try
      {
        ULandscapeInfo* ulandscapeInfoPtr2 = (ULandscapeInfo*) ((IntPtr) ulandscapeInfoPtr1 + 112L);
        \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bctor\u007D(&titerator, (TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E*) ulandscapeInfoPtr2, 0U, 0);
        // ISSUE: fault handler
        try
        {
          int num1 = -1;
          FString fstring1;
          FString fstring2;
          FString fstring3;
          WxFileDialog wxFileDialog;
          while (true)
          {
            int num2 = this.bExportLayers == 0U ? 0 : \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E*) ulandscapeInfoPtr2);
            if (num1 < num2)
            {
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2);
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3);
                  // ISSUE: fault handler
                  try
                  {
                    if (num1 < 0)
                    {
                      FString fstring4;
                      FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring4, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0CC\u0040JIJJMCND\u0040LandscapeExport_HeightmapFilenam\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
                      // ISSUE: fault handler
                      try
                      {
                        \u003CModule\u003E.FString\u002E\u003D(&fstring1, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
                      }
                      __fault
                      {
                        // ISSUE: method pointer
                        // ISSUE: cast to a function pointer type
                        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                      }
                      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
                      \u003CModule\u003E.FString\u002E\u003D(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040MKNOLGLH\u0040\u003F\u0024AAH\u003F\u0024AAe\u003F\u0024AAi\u003F\u0024AAg\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024AA\u0040);
                      \u003CModule\u003E.FString\u002E\u003D(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1II\u0040MKALCGKI\u0040\u003F\u0024AAH\u003F\u0024AAe\u003F\u0024AAi\u003F\u0024AAg\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AA\u003F5\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F5\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F\u0024HM\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024HM\u003F\u0024AAH\u003F\u0024AAe\u003F\u0024AAi\u003F\u0024AAg\u003F\u0024AAh\u0040);
                    }
                    else
                    {
                      if (*(long*) \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002EValue((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator) != 0L && *(long*) *(long*) \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002EValue((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator) != 0L)
                      {
                        ULandscapeLayerInfoObject* ulandscapeLayerInfoObjectPtr = (ULandscapeLayerInfoObject*) (*(long*) *(long*) \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002EValue((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator) + 96L);
                        FString fstring4;
                        FString* fstringPtr1 = \u003CModule\u003E.FName\u002EToString((FName*) ulandscapeLayerInfoObjectPtr, &fstring4);
                        // ISSUE: fault handler
                        try
                        {
                          FString fstring5;
                          FString* fstringPtr2 = \u003CModule\u003E.FName\u002EToString((FName*) ulandscapeLayerInfoObjectPtr, &fstring5);
                          // ISSUE: fault handler
                          try
                          {
                            FString fstring6;
                            FString* fstringPtr3 = \u003CModule\u003E.LocalizeUnrealEd(&fstring6, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BO\u0040MAALCGFM\u0040LandscapeExport_LayerFilename\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring7;
                              FString* fstringPtr4 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring7, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr3)), \u003CModule\u003E.FString\u002E\u002A(fstringPtr2)), \u003CModule\u003E.FString\u002E\u002A(fstringPtr1));
                              // ISSUE: fault handler
                              try
                              {
                                \u003CModule\u003E.FString\u002E\u003D(&fstring1, \u003CModule\u003E.FString\u002E\u002A(fstringPtr4));
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
                        FString fstring8;
                        FString* fstringPtr5 = \u003CModule\u003E.FName\u002EToString((FName*) ulandscapeLayerInfoObjectPtr, &fstring8);
                        // ISSUE: fault handler
                        try
                        {
                          FString fstring5;
                          FString* fstringPtr2 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring5, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1O\u0040LOPGCCNN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.FString\u002E\u002A(fstringPtr5));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.FString\u002E\u003D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(fstringPtr2));
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
                          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring8);
                        }
                        \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring8);
                      }
                      \u003CModule\u003E.FString\u002E\u003D(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1HE\u0040GIFLOPIK\u0040\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAy\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F5\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F5\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F\u0024HM\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024HM\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAy\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F5\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AA8\u0040);
                    }
                    wxString wxString1;
                    \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, \u003CModule\u003E.FString\u002E\u002A(&fstring3));
                    // ISSUE: fault handler
                    try
                    {
                      wxString wxString2;
                      \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, \u003CModule\u003E.FString\u002E\u002A(&fstring2));
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
                            wxString wxString4;
                            \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString4, \u003CModule\u003E.FString\u002E\u002A(&fstring1));
                            // ISSUE: fault handler
                            try
                            {
                              // ISSUE: cast to a reference type
                              // ISSUE: explicit reference operation
                              \u003CModule\u003E.WxFileDialog\u002E\u007Bctor\u007D(&wxFileDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString4, &wxString3, &wxString2, &wxString1, 6, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition);
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
                      // ISSUE: cast to a reference type
                      // ISSUE: explicit reference operation
                      // ISSUE: cast to a function pointer type
                      // ISSUE: function pointer call
                      if (__calli((__FnPtr<int (IntPtr)>) *(long*) (^(long&) ref wxFileDialog + 1528L))((IntPtr) ref local1) == 5100)
                      {
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
                          FFilename ffilename;
                          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.wxString\u002E\u002EPEB_W(\u003CModule\u003E.wxArrayString\u002E\u005B\u005D(&wxArrayString, 0UL)));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator2, (FString*) &ffilename);
                            FString fstring4;
                            FString* path = \u003CModule\u003E.FFilename\u002EGetPath(&ffilename, &fstring4);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring5;
                              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring5, \u003CModule\u003E.FString\u002E\u002A(path));
                              // ISSUE: fault handler
                              try
                              {
                                this.LastImportPath = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring5), 0, \u003CModule\u003E.FString\u002ELen(&fstring5));
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
                            if (num1 >= 0)
                            {
                              if (*(long*) \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002EValue((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator) != 0L)
                              {
                                if (*(long*) *(long*) \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002EValue((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator) != 0L)
                                {
                                  \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator1, \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002EKey((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator));
                                  \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETBaseIterator\u003C0\u003E\u002E\u002B\u002B((TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E.TBaseIterator\u003C0\u003E*) &titerator);
                                }
                              }
                            }
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
                          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxArrayString\u002E\u007Bdtor\u007D), (void*) &wxArrayString);
                        }
                        \u003CModule\u003E.wxArrayString\u002E\u007Bdtor\u007D(&wxArrayString);
                      }
                      else
                        break;
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
                    }
                    \u003CModule\u003E.wxFileDialog\u002E\u007Bdtor\u007D((wxFileDialog*) &wxFileDialog);
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
              ++num1;
            }
            else
              goto label_93;
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
                \u003CModule\u003E.wxFileDialog\u002E\u007Bdtor\u007D((wxFileDialog*) &wxFileDialog);
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
        __fault
        {
          // ISSUE: method pointer
          // ISSUE: cast to a function pointer type
          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bdtor\u007D), (void*) &titerator);
        }
        \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bdtor\u007D(&titerator);
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
    return;
label_93:
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.TMapBase\u003CFName\u002CFLandscapeLayerStruct\u0020\u002A\u002C0\u002CFDefaultSetAllocator\u003E\u002ETIterator\u002E\u007Bdtor\u007D(&titerator);
        \u003CModule\u003E.ULandscapeInfo\u002EExport(ulandscapeInfoPtr1, &fdefaultAllocator1, &fdefaultAllocator2);
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
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator1);
    }
    \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator1);
  }

  protected unsafe void ExportGizmoButton_Click(object Owner, RoutedEventArgs Args)
  {
    ALandscapeGizmoActiveActor* gizmoActiveActorPtr1 = (ALandscapeGizmoActiveActor*) *(long*) ((IntPtr) this.LandscapeEditSystem + 436L);
    if ((IntPtr) gizmoActiveActorPtr1 == IntPtr.Zero || *(long*) ((IntPtr) gizmoActiveActorPtr1 + 596L) == 0L || \u003CModule\u003E.TMapBase\u003Cunsigned\u0020__int64\u002CFGizmoSelectData\u002C0\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003Cunsigned\u0020__int64\u002CFGizmoSelectData\u002C0\u002CFDefaultSetAllocator\u003E*) ((IntPtr) gizmoActiveActorPtr1 + 608L)) == 0)
      return;
    int num1 = -1;
    TArray\u003CFString\u002CFDefaultAllocator\u003E fdefaultAllocator;
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultAllocator);
    TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E fdefaultSetAllocator;
    // ISSUE: fault handler
    try
    {
      \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bctor\u007D(&fdefaultSetAllocator);
      // ISSUE: fault handler
      try
      {
        int num2 = 0;
        ALandscapeGizmoActiveActor* gizmoActiveActorPtr2 = (ALandscapeGizmoActiveActor*) ((IntPtr) gizmoActiveActorPtr1 + 876L);
        if (0 < \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFName\u002CFDefaultAllocator\u003E*) gizmoActiveActorPtr2))
        {
          do
          {
            if (*(int*) ((IntPtr) this.LandscapeEditSystem + 400L) == 1)
              num1 = \u003CModule\u003E.FName\u002E\u003D\u003D((FName*) ((IntPtr) this.LandscapeEditSystem + 404L), \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFName\u002CFDefaultAllocator\u003E*) gizmoActiveActorPtr2, num2)) != 0U ? num2 : num1;
            FSetElementId fsetElementId;
            \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002EAdd(&fdefaultSetAllocator, &fsetElementId, *\u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFName\u002CFDefaultAllocator\u003E*) gizmoActiveActorPtr2, num2), (uint*) 0L);
            ++num2;
          }
          while (num2 < \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFName\u002CFDefaultAllocator\u003E*) gizmoActiveActorPtr2));
        }
        int num3 = -1;
        if (-1 < \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFName\u002CFDefaultAllocator\u003E*) gizmoActiveActorPtr2))
        {
          FString fstring1;
          FString fstring2;
          FString fstring3;
          WxFileDialog wxFileDialog;
          do
          {
            if (\u003CModule\u003E.FLandscapeUISettings\u002EGetbApplyToAllTargets((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) != 0U || num3 == num1)
            {
              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring1);
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring2);
                // ISSUE: fault handler
                try
                {
                  \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring3);
                  // ISSUE: fault handler
                  try
                  {
                    if (num3 < 0)
                    {
                      if ((byte) ((uint) *(byte*) ((IntPtr) gizmoActiveActorPtr1 + 604L) & 1U) != (byte) 0)
                        goto label_20;
                    }
                    else
                      goto label_27;
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
              goto label_98;
label_20:
              // ISSUE: fault handler
              try
              {
                // ISSUE: fault handler
                try
                {
                  // ISSUE: fault handler
                  try
                  {
                    FString fstring4;
                    FString* fstringPtr = \u003CModule\u003E.LocalizeUnrealEd(&fstring4, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0CC\u0040JIJJMCND\u0040LandscapeExport_HeightmapFilenam\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
                    // ISSUE: fault handler
                    try
                    {
                      \u003CModule\u003E.FString\u002E\u003D(&fstring1, \u003CModule\u003E.FString\u002E\u002A(fstringPtr));
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring4);
                    }
                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring4);
                    \u003CModule\u003E.FString\u002E\u003D(&fstring2, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BM\u0040MKNOLGLH\u0040\u003F\u0024AAH\u003F\u0024AAe\u003F\u0024AAi\u003F\u0024AAg\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024AA\u0040);
                    \u003CModule\u003E.FString\u002E\u003D(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1II\u0040MKALCGKI\u0040\u003F\u0024AAH\u003F\u0024AAe\u003F\u0024AAi\u003F\u0024AAg\u003F\u0024AAh\u003F\u0024AAt\u003F\u0024AAm\u003F\u0024AAa\u003F\u0024AAp\u003F\u0024AA\u003F5\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F5\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F\u0024HM\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024HM\u003F\u0024AAH\u003F\u0024AAe\u003F\u0024AAi\u003F\u0024AAg\u003F\u0024AAh\u0040);
                    goto label_56;
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
                  }
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
                }
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
              }
label_27:
              // ISSUE: fault handler
              try
              {
                // ISSUE: fault handler
                try
                {
                  // ISSUE: fault handler
                  try
                  {
                    if ((byte) ((uint) *(byte*) ((IntPtr) gizmoActiveActorPtr1 + 604L) & 2U) != (byte) 0)
                      goto label_34;
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
              goto label_98;
label_34:
              // ISSUE: fault handler
              try
              {
                // ISSUE: fault handler
                try
                {
                  // ISSUE: fault handler
                  try
                  {
                    FName* fnamePtr = \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFName\u002CFDefaultAllocator\u003E*) gizmoActiveActorPtr2, num3);
                    FName fname;
                    // ISSUE: cpblk instruction
                    __memcpy(ref fname, (IntPtr) fnamePtr, 8);
                    FString fstring4;
                    FString* fstringPtr1 = \u003CModule\u003E.FName\u002EToString(&fname, &fstring4);
                    // ISSUE: fault handler
                    try
                    {
                      FString fstring5;
                      FString* fstringPtr2 = \u003CModule\u003E.FName\u002EToString(&fname, &fstring5);
                      // ISSUE: fault handler
                      try
                      {
                        FString fstring6;
                        FString* fstringPtr3 = \u003CModule\u003E.LocalizeUnrealEd(&fstring6, (sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_0BO\u0040MAALCGFM\u0040LandscapeExport_LayerFilename\u003F\u0024AA\u0040, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1BC\u0040BILDELMA\u0040\u003F\u0024AAU\u003F\u0024AAn\u003F\u0024AAr\u003F\u0024AAe\u003F\u0024AAa\u003F\u0024AAl\u003F\u0024AAE\u003F\u0024AAd\u003F\u0024AA\u003F\u0024AA\u0040, (char*) 0L);
                        // ISSUE: fault handler
                        try
                        {
                          FString fstring7;
                          FString* fstringPtr4 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring7, \u003CModule\u003E.FormatLocalizedString\u003Cwchar_t\u0020const\u0020\u002A\u003E(\u003CModule\u003E.TArray\u003Cwchar_t\u002CFDefaultAllocator\u003E\u002EGetData(\u003CModule\u003E.FString\u002EGetCharArray(fstringPtr3)), \u003CModule\u003E.FString\u002E\u002A(fstringPtr2)), \u003CModule\u003E.FString\u002E\u002A(fstringPtr1));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.FString\u002E\u003D(&fstring1, \u003CModule\u003E.FString\u002E\u002A(fstringPtr4));
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
                    FString fstring8;
                    FString* fstringPtr5 = \u003CModule\u003E.FName\u002EToString(&fname, &fstring8);
                    // ISSUE: fault handler
                    try
                    {
                      FString fstring5;
                      FString* fstringPtr2 = \u003CModule\u003E.FString\u002EPrintf\u003Cwchar_t\u0020const\u0020\u002A\u003E(&fstring5, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1O\u0040LOPGCCNN\u0040\u003F\u0024AA\u003F\u0024CF\u003F\u0024AAs\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024AA\u0040, \u003CModule\u003E.FString\u002E\u002A(fstringPtr5));
                      // ISSUE: fault handler
                      try
                      {
                        \u003CModule\u003E.FString\u002E\u003D(&fstring2, \u003CModule\u003E.FString\u002E\u002A(fstringPtr2));
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
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring8);
                    }
                    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring8);
                    \u003CModule\u003E.FString\u002E\u003D(&fstring3, (char*) &\u003CModule\u003E.\u003F\u003F_C\u0040_1HE\u0040GIFLOPIK\u0040\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAy\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F5\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F5\u003F\u0024AAf\u003F\u0024AAi\u003F\u0024AAl\u003F\u0024AAe\u003F\u0024AAs\u003F\u0024AA\u003F\u0024HM\u003F\u0024AA\u003F\u0024CK\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AAa\u003F\u0024AAw\u003F\u0024AA\u003F\u0024HM\u003F\u0024AAL\u003F\u0024AAa\u003F\u0024AAy\u003F\u0024AAe\u003F\u0024AAr\u003F\u0024AA\u003F5\u003F\u0024AA\u003F4\u003F\u0024AAr\u003F\u0024AA8\u0040);
                  }
                  __fault
                  {
                    // ISSUE: method pointer
                    // ISSUE: cast to a function pointer type
                    \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring3);
                  }
                }
                __fault
                {
                  // ISSUE: method pointer
                  // ISSUE: cast to a function pointer type
                  \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring2);
                }
              }
              __fault
              {
                // ISSUE: method pointer
                // ISSUE: cast to a function pointer type
                \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
              }
label_56:
              // ISSUE: fault handler
              try
              {
                // ISSUE: fault handler
                try
                {
                  // ISSUE: fault handler
                  try
                  {
                    wxString wxString1;
                    \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString1, \u003CModule\u003E.FString\u002E\u002A(&fstring3));
                    // ISSUE: fault handler
                    try
                    {
                      wxString wxString2;
                      \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString2, \u003CModule\u003E.FString\u002E\u002A(&fstring2));
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
                            wxString wxString4;
                            \u003CModule\u003E.wxString\u002E\u007Bctor\u007D(&wxString4, \u003CModule\u003E.FString\u002E\u002A(&fstring1));
                            // ISSUE: fault handler
                            try
                            {
                              // ISSUE: cast to a reference type
                              // ISSUE: explicit reference operation
                              \u003CModule\u003E.WxFileDialog\u002E\u007Bctor\u007D(&wxFileDialog, (wxWindow*) *(long*) ((IntPtr) \u003CModule\u003E.GApp + 172L), &wxString4, &wxString3, &wxString2, &wxString1, 6, (wxPoint*) ^(long&) ref \u003CModule\u003E.__imp_wxDefaultPosition);
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
                      // ISSUE: cast to a reference type
                      // ISSUE: explicit reference operation
                      // ISSUE: cast to a function pointer type
                      // ISSUE: function pointer call
                      if (__calli((__FnPtr<int (IntPtr)>) *(long*) (^(long&) ref wxFileDialog + 1528L))((IntPtr) ref local1) == 5100)
                      {
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
                          FFilename ffilename;
                          \u003CModule\u003E.FFilename\u002E\u007Bctor\u007D(&ffilename, \u003CModule\u003E.wxString\u002E\u002EPEB_W(\u003CModule\u003E.wxArrayString\u002E\u005B\u005D(&wxArrayString, 0UL)));
                          // ISSUE: fault handler
                          try
                          {
                            \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002EAddItem(&fdefaultAllocator, (FString*) &ffilename);
                            FString fstring4;
                            FString* path = \u003CModule\u003E.FFilename\u002EGetPath(&ffilename, &fstring4);
                            // ISSUE: fault handler
                            try
                            {
                              FString fstring5;
                              \u003CModule\u003E.FString\u002E\u007Bctor\u007D(&fstring5, \u003CModule\u003E.FString\u002E\u002A(path));
                              // ISSUE: fault handler
                              try
                              {
                                this.LastImportPath = new string(\u003CModule\u003E.FString\u002E\u002A(&fstring5), 0, \u003CModule\u003E.FString\u002ELen(&fstring5));
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
                            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FFilename\u002E\u007Bdtor\u007D), (void*) &ffilename);
                          }
                          \u003CModule\u003E.FFilename\u002E\u007Bdtor\u007D(&ffilename);
                        }
                        __fault
                        {
                          // ISSUE: method pointer
                          // ISSUE: cast to a function pointer type
                          \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(wxArrayString\u002E\u007Bdtor\u007D), (void*) &wxArrayString);
                        }
                        \u003CModule\u003E.wxArrayString\u002E\u007Bdtor\u007D(&wxArrayString);
                      }
                      else
                        goto label_100;
                    }
                    __fault
                    {
                      // ISSUE: method pointer
                      // ISSUE: cast to a function pointer type
                      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(WxFileDialog\u002E\u007Bdtor\u007D), (void*) &wxFileDialog);
                    }
                    \u003CModule\u003E.wxFileDialog\u002E\u007Bdtor\u007D((wxFileDialog*) &wxFileDialog);
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
label_98:
            ++num3;
          }
          while (num3 < \u003CModule\u003E.TArray\u003CFName\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFName\u002CFDefaultAllocator\u003E*) gizmoActiveActorPtr2));
          goto label_111;
label_100:
          // ISSUE: fault handler
          try
          {
            // ISSUE: fault handler
            try
            {
              // ISSUE: fault handler
              try
              {
                \u003CModule\u003E.wxFileDialog\u002E\u007Bdtor\u007D((wxFileDialog*) &wxFileDialog);
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
        else
          goto label_111;
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
      }
      \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
    return;
label_111:
    // ISSUE: fault handler
    try
    {
      // ISSUE: fault handler
      try
      {
        \u003CModule\u003E.ALandscapeGizmoActiveActor\u002EExport(gizmoActiveActorPtr1, num1, &fdefaultAllocator);
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultSetAllocator);
      }
      \u003CModule\u003E.TSet\u003CFName\u002CDefaultKeyFuncs\u003CFName\u002C0\u003E\u002CFDefaultSetAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultSetAllocator);
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D), (void*) &fdefaultAllocator);
    }
    \u003CModule\u003E.TArray\u003CFString\u002CFDefaultAllocator\u003E\u002E\u007Bdtor\u007D(&fdefaultAllocator);
  }

  protected unsafe void ConvertTerrainButton_Click(object Owner, RoutedEventArgs Args)
  {
    FActorIterator factorIterator;
    \u003CModule\u003E.FActorIterator\u002E\u007Bctor\u007D(&factorIterator);
    if (\u003CModule\u003E.FActorIteratorBase\u002E\u002EI((FActorIteratorBase*) &factorIterator) != 0U)
    {
      do
      {
        ATerrain* aterrainPtr = \u003CModule\u003E.Cast\u003Cclass\u0020ATerrain\u003E((UObject*) \u003CModule\u003E.FActorIteratorBase\u002E\u002A((FActorIteratorBase*) &factorIterator));
        if ((IntPtr) aterrainPtr != IntPtr.Zero)
        {
          FName fname;
          FRotator frotator;
          ALandscape* alandscapePtr = \u003CModule\u003E.Cast\u003Cclass\u0020ALandscape\u003E((UObject*) \u003CModule\u003E.UWorld\u002ESpawnActor(\u003CModule\u003E.GWorld, \u003CModule\u003E.ALandscape\u002EStaticClass(), *\u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (EName) 0), (FVector*) ((IntPtr) aterrainPtr + 128L), \u003CModule\u003E.FRotator\u002E\u007Bctor\u007D(&frotator, 0, 0, 0), (AActor*) 0L, 0U, 0U, (AActor*) 0L, (APawn*) 0L, 0U, (ULevel*) 0L));
          if (\u003CModule\u003E.ALandscape\u002EImportFromOldTerrain(alandscapePtr, aterrainPtr) != 0U)
          {
            int num1 = (int) \u003CModule\u003E.UWorld\u002EDestroyActor(\u003CModule\u003E.GWorld, (AActor*) aterrainPtr, 0U, 1U);
          }
          else
          {
            int num2 = (int) \u003CModule\u003E.UWorld\u002EDestroyActor(\u003CModule\u003E.GWorld, (AActor*) alandscapePtr, 0U, 1U);
          }
        }
        \u003CModule\u003E.TActorIteratorBase\u003CFActorFilter\u002CFTickableLevelFilter\u003E\u002E\u002B\u002B((TActorIteratorBase\u003CFActorFilter\u002CFTickableLevelFilter\u003E*) &factorIterator);
      }
      while (\u003CModule\u003E.FActorIteratorBase\u002E\u002EI((FActorIteratorBase*) &factorIterator) != 0U);
    }
    int num = \u003CModule\u003E.FEdModeLandscape\u002EUpdateLandscapeList(this.LandscapeEditSystem);
    this.LandscapeListsValue.NotifyChanged();
    this.LandscapeComboBox.SelectedIndex = num;
    this.UpdateTargets();
  }

  protected unsafe void ClearSelectionButton_Click(object Owner, RoutedEventArgs Args)
  {
    ULandscapeInfo* ulandscapeInfoPtr = (ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if ((IntPtr) ulandscapeInfoPtr == IntPtr.Zero)
      return;
    \u003CModule\u003E.ULandscapeInfo\u002EClearSelectedRegion(ulandscapeInfoPtr, 1U);
    \u003CModule\u003E.FEdModeLandscape\u002ESetMaskEnable(this.LandscapeEditSystem, (uint) \u003CModule\u003E.TMapBase\u003Cunsigned\u0020__int64\u002Cfloat\u002C0\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003Cunsigned\u0020__int64\u002Cfloat\u002C0\u002CFDefaultSetAllocator\u003E*) ((IntPtr) ulandscapeInfoPtr + 704L)));
  }

  protected unsafe void ClearMaskButton_Click(object Owner, RoutedEventArgs Args)
  {
    ULandscapeInfo* ulandscapeInfoPtr = (ULandscapeInfo*) *(long*) ((IntPtr) this.LandscapeEditSystem + 392L);
    if ((IntPtr) ulandscapeInfoPtr == IntPtr.Zero)
      return;
    \u003CModule\u003E.ULandscapeInfo\u002EClearSelectedRegion(ulandscapeInfoPtr, 0U);
    \u003CModule\u003E.FEdModeLandscape\u002ESetMaskEnable(this.LandscapeEditSystem, (uint) \u003CModule\u003E.TMapBase\u003Cunsigned\u0020__int64\u002Cfloat\u002C0\u002CFDefaultSetAllocator\u003E\u002ENum((TMapBase\u003Cunsigned\u0020__int64\u002Cfloat\u002C0\u002CFDefaultSetAllocator\u003E*) ((IntPtr) ulandscapeInfoPtr + 704L)));
  }

  protected unsafe void ClearGizmoDataButton_Click(object Owner, RoutedEventArgs Args)
  {
    ALandscapeGizmoActiveActor* gizmoActiveActorPtr = (ALandscapeGizmoActiveActor*) *(long*) ((IntPtr) this.LandscapeEditSystem + 436L);
    if ((IntPtr) gizmoActiveActorPtr == IntPtr.Zero || *(long*) ((IntPtr) gizmoActiveActorPtr + 596L) == 0L)
      return;
    \u003CModule\u003E.ALandscapeGizmoActiveActor\u002EClearGizmoData(gizmoActiveActorPtr);
  }

  protected unsafe void FitToSelectionButton_Click(object Owner, RoutedEventArgs Args)
  {
    ALandscapeGizmoActiveActor* gizmoActiveActorPtr = (ALandscapeGizmoActiveActor*) *(long*) ((IntPtr) this.LandscapeEditSystem + 436L);
    if ((IntPtr) gizmoActiveActorPtr == IntPtr.Zero || *(long*) ((IntPtr) gizmoActiveActorPtr + 596L) == 0L)
      return;
    \u003CModule\u003E.ALandscapeGizmoActiveActor\u002EFitToSelection(gizmoActiveActorPtr);
  }

  protected unsafe void FitToGizmoButton_Click(object Owner, RoutedEventArgs Args)
  {
    ALandscapeGizmoActiveActor* gizmoActiveActorPtr = (ALandscapeGizmoActiveActor*) *(long*) ((IntPtr) this.LandscapeEditSystem + 436L);
    if ((IntPtr) gizmoActiveActorPtr == IntPtr.Zero || *(long*) ((IntPtr) gizmoActiveActorPtr + 596L) == 0L)
      return;
    \u003CModule\u003E.ALandscapeGizmoActiveActor\u002EFitMinMaxHeight(gizmoActiveActorPtr);
  }

  protected unsafe void CopyToGizmoButton_Click(object Owner, RoutedEventArgs Args)
  {
    FEdModeLandscape* landscapeEditSystem = this.LandscapeEditSystem;
    if ((IntPtr) landscapeEditSystem == IntPtr.Zero)
      return;
    \u003CModule\u003E.FEdModeLandscape\u002ECopyDataToGizmo(landscapeEditSystem);
  }

  protected unsafe void ToolButton_Click(object Owner, RoutedEventArgs Args)
  {
    Visual rootVisual = this.InteropWindow.op_MemberSelection().RootVisual;
    // ISSUE: cast to a reference type
    // ISSUE: variable of a reference type
    byte* local1 = (byte*) ((FrameworkElement) Owner).Name;
    if (local1 != null)
      local1 = (long) (uint) RuntimeHelpers.OffsetToStringData + local1;
    // ISSUE: explicit reference operation
    fixed (byte* numPtr = &^local1)
    {
      FName fname;
      \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, (char*) numPtr, (EFindName) 1, 1U);
      \u003CModule\u003E.FEdModeLandscape\u002ESetCurrentTool(this.LandscapeEditSystem, fname);
      UniformGrid logicalNode1 = (UniformGrid) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "BrushGrid");
      FEdModeLandscape* landscapeEditSystem = this.LandscapeEditSystem;
      int num1 = *(int*) ((IntPtr) landscapeEditSystem + 424L);
      if (num1 >= 0 && num1 < \u003CModule\u003E.TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E*) ((IntPtr) landscapeEditSystem + 468L)))
      {
        FLandscapeBrushSet* flandscapeBrushSetPtr = \u003CModule\u003E.TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 468L), num1);
        ToolDropdownRadioButton logicalNode2 = (ToolDropdownRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, new string(\u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) flandscapeBrushSetPtr + 16L))));
        if (((UIElement) logicalNode2).IsEnabled && \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002EIsValidIndex((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr, logicalNode2.SelectedIndex) != 0U)
        {
          FLandscapeBrush* flandscapeBrushPtr1 = (FLandscapeBrush*) *(long*) \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr, logicalNode2.SelectedIndex);
          ulong num2 = (ulong) *(long*) ((IntPtr) this.LandscapeEditSystem + 384L);
          if ((long) num2 == (IntPtr) flandscapeBrushPtr1)
            return;
          long num3 = (long) num2;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) num3 + 64L))((IntPtr) num3);
          *(long*) ((IntPtr) this.LandscapeEditSystem + 384L) = (long) flandscapeBrushPtr1;
          *(int*) ((IntPtr) this.LandscapeEditSystem + 424L) = num1;
          long num4 = *(long*) ((IntPtr) this.LandscapeEditSystem + 384L);
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) num4 + 56L))((IntPtr) num4);
          FLandscapeBrush* flandscapeBrushPtr2 = flandscapeBrushPtr1;
          FString fstring;
          ref FString local2 = ref fstring;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          long num5 = (long) __calli((__FnPtr<FString* (IntPtr, FString*)>) *(long*) (*(long*) flandscapeBrushPtr1 + 96L))((FString*) flandscapeBrushPtr2, (IntPtr) ref local2);
          // ISSUE: fault handler
          try
          {
            ((FrameworkElement) logicalNode2).ToolTip = (object) new string(\u003CModule\u003E.FString\u002E\u002A((FString*) num5));
          }
          __fault
          {
            // ISSUE: method pointer
            // ISSUE: cast to a function pointer type
            \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
          }
          \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
          bool? nullable = (bool?) true;
          ((ToggleButton) logicalNode2).IsChecked = nullable;
          return;
        }
      }
      int num6 = 0;
      if (0 >= \u003CModule\u003E.TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 468L)))
        return;
      FLandscapeBrushSet* flandscapeBrushSetPtr1;
      ToolDropdownRadioButton logicalNode3;
      do
      {
        flandscapeBrushSetPtr1 = \u003CModule\u003E.TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 468L), num6);
        logicalNode3 = (ToolDropdownRadioButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, new string(\u003CModule\u003E.FString\u002E\u002A((FString*) ((IntPtr) flandscapeBrushSetPtr1 + 16L))));
        if (!((UIElement) logicalNode3).IsEnabled || \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002EIsValidIndex((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr1, logicalNode3.SelectedIndex) == 0U)
          ++num6;
        else
          goto label_13;
      }
      while (num6 < \u003CModule\u003E.TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 468L)));
      return;
label_13:
      *(int*) ((IntPtr) this.LandscapeEditSystem + 424L) = num6;
      FLandscapeBrush* flandscapeBrushPtr3 = (FLandscapeBrush*) *(long*) \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr1, logicalNode3.SelectedIndex);
      ulong num7 = (ulong) *(long*) ((IntPtr) this.LandscapeEditSystem + 384L);
      if ((long) num7 == (IntPtr) flandscapeBrushPtr3)
        return;
      long num8 = (long) num7;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) num8 + 64L))((IntPtr) num8);
      *(long*) ((IntPtr) this.LandscapeEditSystem + 384L) = (long) flandscapeBrushPtr3;
      *(int*) ((IntPtr) this.LandscapeEditSystem + 424L) = num6;
      long num9 = *(long*) ((IntPtr) this.LandscapeEditSystem + 384L);
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) num9 + 56L))((IntPtr) num9);
      FLandscapeBrush* flandscapeBrushPtr4 = flandscapeBrushPtr3;
      FString fstring1;
      ref FString local3 = ref fstring1;
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      long num10 = (long) __calli((__FnPtr<FString* (IntPtr, FString*)>) *(long*) (*(long*) flandscapeBrushPtr3 + 96L))((FString*) flandscapeBrushPtr4, (IntPtr) ref local3);
      // ISSUE: fault handler
      try
      {
        ((FrameworkElement) logicalNode3).ToolTip = (object) new string(\u003CModule\u003E.FString\u002E\u002A((FString*) num10));
      }
      __fault
      {
        // ISSUE: method pointer
        // ISSUE: cast to a function pointer type
        \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring1);
      }
      \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring1);
      bool? nullable1 = (bool?) true;
      ((ToggleButton) logicalNode3).IsChecked = nullable1;
    }
  }

  protected unsafe void BrushButton_SelectionChanged(object Owner, RoutedEventArgs Args)
  {
    Visual rootVisual = this.InteropWindow.op_MemberSelection().RootVisual;
    int num1 = ((Panel) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, "BrushGrid")).Children.IndexOf((UIElement) Owner);
    if (num1 == -1)
      return;
    FLandscapeBrushSet* flandscapeBrushSetPtr = \u003CModule\u003E.TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrushSet\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 468L), num1);
    if (\u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002EIsValidIndex((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr, ((ToolDropdownRadioButton) Owner).SelectedIndex) == 0U)
      return;
    FLandscapeBrush* flandscapeBrushPtr1 = (FLandscapeBrush*) *(long*) \u003CModule\u003E.TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeBrush\u0020\u002A\u002CFDefaultAllocator\u003E*) flandscapeBrushSetPtr, ((ToolDropdownRadioButton) Owner).SelectedIndex);
    ulong num2 = (ulong) *(long*) ((IntPtr) this.LandscapeEditSystem + 384L);
    if ((long) num2 == (IntPtr) flandscapeBrushPtr1)
      return;
    long num3 = (long) num2;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) num3 + 64L))((IntPtr) num3);
    *(long*) ((IntPtr) this.LandscapeEditSystem + 384L) = (long) flandscapeBrushPtr1;
    *(int*) ((IntPtr) this.LandscapeEditSystem + 424L) = num1;
    long num4 = *(long*) ((IntPtr) this.LandscapeEditSystem + 384L);
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    __calli((__FnPtr<void (IntPtr)>) *(long*) (*(long*) num4 + 56L))((IntPtr) num4);
    ulong num5 = (ulong) *(long*) ((IntPtr) this.LandscapeEditSystem + 376L);
    if (num5 != 0UL)
      *(int*) ((long) num5 + 48L) = num1;
    FLandscapeBrush* flandscapeBrushPtr2 = flandscapeBrushPtr1;
    FString fstring;
    ref FString local = ref fstring;
    // ISSUE: cast to a function pointer type
    // ISSUE: function pointer call
    long num6 = (long) __calli((__FnPtr<FString* (IntPtr, FString*)>) *(long*) (*(long*) flandscapeBrushPtr1 + 96L))((FString*) flandscapeBrushPtr2, (IntPtr) ref local);
    // ISSUE: fault handler
    try
    {
      ((FrameworkElement) Owner).ToolTip = (object) new string(\u003CModule\u003E.FString\u002E\u002A((FString*) num6));
    }
    __fault
    {
      // ISSUE: method pointer
      // ISSUE: cast to a function pointer type
      \u003CModule\u003E.___CxxCallUnwindDtor((__FnPtr<void (void*)>) __methodptr(FString\u002E\u007Bdtor\u007D), (void*) &fstring);
    }
    \u003CModule\u003E.FString\u002E\u007Bdtor\u007D(&fstring);
    FEdModeLandscape* landscapeEditSystem = this.LandscapeEditSystem;
    int num7 = *(int*) ((IntPtr) landscapeEditSystem + 420L);
    if (num7 >= 0 && num7 < \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) landscapeEditSystem + 452L)))
    {
      FLandscapeToolSet* flandscapeToolSetPtr = (FLandscapeToolSet*) *(long*) \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L), num7);
      if (((UIElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, new string(\u003CModule\u003E.FLandscapeToolSet\u002EGetToolSetName(flandscapeToolSetPtr)))).Visibility == Visibility.Visible)
        return;
    }
    int num8 = 0;
    if (0 >= \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L)))
      return;
    do
    {
      FLandscapeToolSet* flandscapeToolSetPtr = (FLandscapeToolSet*) *(long*) \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002E\u0028\u0029((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L), num8);
      if (((UIElement) LogicalTreeHelper.FindLogicalNode((DependencyObject) rootVisual, new string(\u003CModule\u003E.FLandscapeToolSet\u002EGetToolSetName(flandscapeToolSetPtr)))).Visibility != Visibility.Visible)
        ++num8;
      else
        goto label_14;
    }
    while (num8 < \u003CModule\u003E.TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E\u002ENum((TArray\u003CFLandscapeToolSet\u0020\u002A\u002CFDefaultAllocator\u003E*) ((IntPtr) this.LandscapeEditSystem + 452L)));
    return;
label_14:
    \u003CModule\u003E.FEdModeLandscape\u002ESetCurrentTool(this.LandscapeEditSystem, num8);
  }

  public virtual event PropertyChangedEventHandler PropertyChanged;

  [SpecialName]
  protected virtual void raise_PropertyChanged(object value0, PropertyChangedEventArgs value1)
  {
    PropertyChangedEventHandler storePropertyChanged = this.\u003Cbacking_store\u003EPropertyChanged;
    if (storePropertyChanged == null)
      return;
    storePropertyChanged(value0, value1);
  }

  public void RefreshAllProperties() => this.UpdateTargets();

  public unsafe void UpdateLandscapeList()
  {
    int num = \u003CModule\u003E.FEdModeLandscape\u002EUpdateLandscapeList(this.LandscapeEditSystem);
    this.LandscapeListsValue.NotifyChanged();
    this.LandscapeComboBox.SelectedIndex = num;
    this.UpdateTargets();
  }

  public unsafe void UpdateTargets()
  {
    \u003CModule\u003E.FEdModeLandscape\u002EUpdateTargetList(this.LandscapeEditSystem);
    int num1 = this.TargetListBox.SelectedIndex;
    TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E* targetList = \u003CModule\u003E.FEdModeLandscape\u002EGetTargetList(this.LandscapeEditSystem);
    if (num1 < 0 && \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002ENum(targetList) > 0)
    {
      num1 = 0;
      int num2 = 1;
      if (1 < \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002ENum(targetList))
      {
        while (*(int*) ((IntPtr) \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(targetList, num2) + 28L) == 0)
        {
          ++num2;
          if (num2 >= \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002ENum(targetList))
            goto label_6;
        }
        num1 = num2;
      }
    }
label_6:
    this.LandscapeTargetsValue.NotifyChanged();
    this.TargetListBox.SelectedIndex = num1;
    int num3 = 0;
    if (0 >= \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002ENum(targetList))
      return;
    do
    {
      uint num2 = (uint) (num3 == num1);
      *(int*) ((IntPtr) \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(targetList, num3) + 28L) = (int) num2;
      if (num3 == num1)
      {
        *(int*) ((IntPtr) this.LandscapeEditSystem + 400L) = num3 > 0 ? 1 : 0;
        FName fname;
        // ISSUE: cpblk instruction
        __memcpy((IntPtr) this.LandscapeEditSystem + 404L, (IntPtr) \u003CModule\u003E.FName\u002E\u007Bctor\u007D(&fname, \u003CModule\u003E.FString\u002E\u002A((FString*) \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002E\u0028\u0029(targetList, num3)), (EFindName) 1, 1U), 8);
      }
      ++num3;
    }
    while (num3 < \u003CModule\u003E.TArray\u003CFLandscapeTargetListInfo\u002CFDefaultAllocator\u003E\u002ENum(targetList));
  }

  public void NotifyCurrentToolChanged(string ToolSetName) => ((ToggleButton) LogicalTreeHelper.FindLogicalNode((DependencyObject) this.InteropWindow.op_MemberSelection().RootVisual, ToolSetName)).IsChecked = (bool?) true;

  public unsafe void NotifyMaskEnableChanged([MarshalAs(UnmanagedType.U1)] bool MaskEnabled)
  {
    uint num = (uint) MaskEnabled;
    if ((int) \u003CModule\u003E.FLandscapeUISettings\u002EGetbMaskEnabled((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) != (int) num)
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbMaskEnabled((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), num);
    this.MaskEnableCheckBox.IsChecked = (bool?) MaskEnabled;
    if (MaskEnabled)
      return;
    if (\u003CModule\u003E.FLandscapeUISettings\u002EGetbUseNegativeMask((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L)) != 1U)
      \u003CModule\u003E.FLandscapeUISettings\u002ESetbUseNegativeMask((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), 1U);
    this.InvertMaskCheckBox.IsChecked = (bool?) true;
  }

  public void NotifyBrushSizeChanged(float Radius) => ((RangeBase) this.BrushRadiusSlider).Value = (double) Radius;

  public void NotifyBrushComponentSizeChanged(int Size) => ((RangeBase) this.BrushSizeSlider).Value = (double) Size;

  public virtual void OnPropertyChanged(string Info)
  {
    MLandscapeEditWindow mlandscapeEditWindow = this;
    mlandscapeEditWindow.raise_PropertyChanged((object) mlandscapeEditWindow, new PropertyChangedEventArgs(Info));
  }

  public unsafe void SaveWindowSettings()
  {
    tagRECT tagRect;
    \u003CModule\u003E.GetWindowRect(this.GetWindowHandle(), &tagRect);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    \u003CModule\u003E.FLandscapeUISettings\u002ESetWindowSizePos((FLandscapeUISettings*) ((IntPtr) this.LandscapeEditSystem + 104L), ^(int&) ref tagRect, ^(int&) ((IntPtr) &tagRect + 4), ^(int&) ((IntPtr) &tagRect + 8) - ^(int&) ref tagRect, ^(int&) ((IntPtr) &tagRect + 12) - ^(int&) ((IntPtr) &tagRect + 4));
  }

  protected override unsafe IntPtr VirtualMessageHookFunction(
    IntPtr HWnd,
    int Msg,
    IntPtr WParam,
    IntPtr LParam,
    ref bool OutHandled)
  {
    OutHandled = false;
    int num1 = 0;
    if (Msg <= 257)
    {
      if (Msg < 256)
      {
        switch (Msg)
        {
          case 33:
            \u003CModule\u003E.BringWindowToTop((HWND__*) (long) HWnd);
            goto label_13;
          case 36:
            long num2 = (long) HWnd;
            long num3 = (long) WParam;
            long num4 = (long) LParam;
            long num5 = num3;
            long num6 = num4;
            num1 = (int) \u003CModule\u003E.DefWindowProcW((HWND__*) num2, 36U, (ulong) num5, num6);
            OutHandled = true;
            *(int*) (num4 + 28L) = 150;
            goto label_13;
          case 132:
            HWND__* hwndPtr = (HWND__*) (long) HWnd;
            long num7 = (long) WParam;
            long num8 = (long) LParam;
            num1 = (int) \u003CModule\u003E.DefWindowProcW(hwndPtr, 132U, (ulong) num7, num8);
            if (num1 == 1)
            {
              tagRECT tagRect;
              \u003CModule\u003E.GetWindowRect(hwndPtr, &tagRect);
              int num9 = (int) (short) (uint) ((ulong) num8 >> 16);
              // ISSUE: cast to a reference type
              // ISSUE: explicit reference operation
              // ISSUE: cast to a reference type
              // ISSUE: explicit reference operation
              if (num9 >= ^(int&) ((IntPtr) &tagRect + 4) && num9 < ^(int&) ((IntPtr) &tagRect + 4) + 5)
              {
                num1 = 12;
                OutHandled = true;
                goto label_14;
              }
              else
              {
                // ISSUE: cast to a reference type
                // ISSUE: explicit reference operation
                // ISSUE: cast to a reference type
                // ISSUE: explicit reference operation
                if (num9 <= ^(int&) ((IntPtr) &tagRect + 12) && num9 > ^(int&) ((IntPtr) &tagRect + 12) - 5)
                {
                  num1 = 15;
                  OutHandled = true;
                  goto label_14;
                }
                else
                  goto label_13;
              }
            }
            else
              goto label_13;
          default:
            goto label_15;
        }
      }
    }
    else if (Msg < 260 || Msg > 261 && Msg != 786)
      goto label_15;
    if (!(FocusManager.GetFocusedElement((DependencyObject) this.InteropWindow.op_MemberSelection().RootVisual) is TextBox))
    {
      long num9 = (long) WParam;
      long num10 = (long) LParam;
      \u003CModule\u003E.FEdModeLandscape\u002EAddWindowMessage(this.LandscapeEditSystem, (uint) Msg, (ulong) num9, num10);
    }
label_13:
    if (!OutHandled)
      goto label_15;
label_14:
    return (IntPtr) num1;
label_15:
    return base.VirtualMessageHookFunction(HWnd, Msg, WParam, LParam, ref OutHandled);
  }

  public void \u007EMLandscapeEditWindow()
  {
  }

  [HandleProcessCorruptedStateExceptions]
  protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool _param1)
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
          base.Dispose(true);
        }
        finally
        {
          this.DroppedAssets.Dispose();
        }
      }
    }
    else
      base.Dispose(false);
  }
}
