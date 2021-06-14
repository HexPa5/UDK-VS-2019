// Decompiled with JetBrains decompiler
// Type: IntToIntOffsetConverter
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Globalization;
using System.Windows.Data;

[ValueConversion(typeof (int), typeof (int))]
internal class IntToIntOffsetConverter : IValueConverter
{
  private int Offset;

  public IntToIntOffsetConverter(int InOffset)
  {
    this.Offset = InOffset;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public virtual object Convert(
    object value,
    Type targetType,
    object parameter,
    CultureInfo culture)
  {
    return (object) (this.Offset + (int) value);
  }

  public virtual object ConvertBack(
    object value,
    Type targetType,
    object parameter,
    CultureInfo culture)
  {
    return (object) ((int) value - this.Offset);
  }
}
