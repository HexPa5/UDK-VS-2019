// Decompiled with JetBrains decompiler
// Type: MGameAssetJournalEntry
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Text;

internal class MGameAssetJournalEntry
{
  public int DatabaseIndex;
  public bool IsValidEntry;
  public bool IsOfflineEntry;
  public ValueType TimeStamp;
  public EJournalEntryType Type;
  public string Tag;
  public string AssetFullName;
  public string UserName;
  public string BranchName;
  public string GameName;

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(this.DatabaseIndex);
    stringBuilder.Append("\t");
    stringBuilder.Append(((DateTime) this.TimeStamp).ToString());
    stringBuilder.Append("\t");
    stringBuilder.Append(this.UserName);
    stringBuilder.Append("\t");
    stringBuilder.Append((object) this.Type);
    stringBuilder.Append("\t");
    stringBuilder.Append(this.Tag);
    stringBuilder.Append("\t");
    stringBuilder.Append(this.AssetFullName);
    return stringBuilder.ToString();
  }

  public static MGameAssetJournalEntry MakeAddTagToAssetEntry(
    string InAssetFullName,
    string InTag)
  {
    return new MGameAssetJournalEntry()
    {
      Type = EJournalEntryType.AddTag,
      AssetFullName = InAssetFullName,
      Tag = InTag
    };
  }

  public static MGameAssetJournalEntry MakeRemoveTagFromAssetEntry(
    string InAssetFullName,
    string InTag)
  {
    return new MGameAssetJournalEntry()
    {
      Type = EJournalEntryType.RemoveTag,
      AssetFullName = InAssetFullName,
      Tag = InTag
    };
  }

  public static MGameAssetJournalEntry MakeCreateTagEntry(string InTagName) => new MGameAssetJournalEntry()
  {
    Type = EJournalEntryType.CreateTag,
    Tag = InTagName
  };

  public static MGameAssetJournalEntry MakeDestroyTagEntry(string InTagName) => new MGameAssetJournalEntry()
  {
    Type = EJournalEntryType.DestroyTag,
    Tag = InTagName
  };

  public static int JournalEntrySortDelegate(MGameAssetJournalEntry X, MGameAssetJournalEntry Y)
  {
    long num = ((DateTime) X.TimeStamp).Ticks - ((DateTime) Y.TimeStamp).Ticks;
    if (num == 0L)
      num = (long) (X.DatabaseIndex - Y.DatabaseIndex);
    return num < 0L ? -1 : (num > 0L ? 1 : 0);
  }
}
