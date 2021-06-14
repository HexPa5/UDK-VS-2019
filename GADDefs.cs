// Decompiled with JetBrains decompiler
// Type: GADDefs
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

internal class GADDefs
{
  public static readonly int JournalEntryVersionNumber_AssetFullNames = 2;
  public static readonly int JournalEntryVersionNumber = GADDefs.JournalEntryVersionNumber_AssetFullNames;
  public static readonly int CheckpointFileVersionNumber_PersistentCollections = 2;
  public static readonly int CheckpointFileVersionNumber_AssetFullNames = 3;
  public static readonly int CheckpointFileVersionNumber = GADDefs.CheckpointFileVersionNumber_AssetFullNames;
  public static readonly int JournalFileVersionNumber = 1;
  public static readonly string[] SystemTagTypeNames = new string[11];
  public static readonly char PrivateCollectionUserDelimiter;
  public static readonly string[] JournalEntryTypeNames;
  public static readonly char JournalEntryFieldDelimiter;
  public static readonly byte[] CheckpointFileHeaderChars;
  public static readonly int DeleteJournalEntriesOlderThanDays;
  public static readonly int DeleteGhostAssetsOlderThanDays;
  public static readonly int PurgeJournalEntriesOlderThanDays;
  public static readonly int MaxTagLength;

  static GADDefs()
  {
    string str1 = "<Invalid>";
    GADDefs.SystemTagTypeNames[0] = str1;
    string str2 = "ObjectType";
    GADDefs.SystemTagTypeNames[1] = str2;
    string str3 = "Package";
    GADDefs.SystemTagTypeNames[2] = str3;
    string str4 = "Collection";
    GADDefs.SystemTagTypeNames[3] = str4;
    string str5 = "PrivateCollection";
    GADDefs.SystemTagTypeNames[4] = str5;
    string str6 = "LocalCollection";
    GADDefs.SystemTagTypeNames[5] = str6;
    string str7 = "Unverified";
    GADDefs.SystemTagTypeNames[6] = str7;
    string str8 = "Ghost";
    GADDefs.SystemTagTypeNames[7] = str8;
    string str9 = "Archetype";
    GADDefs.SystemTagTypeNames[8] = str9;
    string str10 = "DateAdded";
    GADDefs.SystemTagTypeNames[9] = str10;
    string str11 = "Quarantined";
    GADDefs.SystemTagTypeNames[10] = str11;
    GADDefs.PrivateCollectionUserDelimiter = '@';
    GADDefs.JournalEntryTypeNames = new string[5];
    string str12 = "Invalid";
    GADDefs.JournalEntryTypeNames[0] = str12;
    string str13 = "Add";
    GADDefs.JournalEntryTypeNames[1] = str13;
    string str14 = "Remove";
    GADDefs.JournalEntryTypeNames[2] = str14;
    string str15 = "CreateTag";
    GADDefs.JournalEntryTypeNames[3] = str15;
    string str16 = "DestroyTag";
    GADDefs.JournalEntryTypeNames[4] = str16;
    GADDefs.JournalEntryFieldDelimiter = '|';
    GADDefs.CheckpointFileHeaderChars = new byte[4];
    GADDefs.CheckpointFileHeaderChars[0] = (byte) 71;
    GADDefs.CheckpointFileHeaderChars[1] = (byte) 65;
    GADDefs.CheckpointFileHeaderChars[2] = (byte) 68;
    GADDefs.CheckpointFileHeaderChars[3] = (byte) 67;
    GADDefs.DeleteJournalEntriesOlderThanDays = 3;
    GADDefs.DeleteGhostAssetsOlderThanDays = 7;
    GADDefs.PurgeJournalEntriesOlderThanDays = 14;
    GADDefs.MaxTagLength = 1024;
  }
}
