﻿// Decompiled with JetBrains decompiler
// Type: EContentBrowserQueryState
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

internal enum EContentBrowserQueryState
{
  Idle,
  StartNewQuery,
  GatherObjects,
  AddLoadedAssets,
  AddNonLoadedAssets,
  RemoveMissingAssets,
}
