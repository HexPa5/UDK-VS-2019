// Decompiled with JetBrains decompiler
// Type: RoundedIntToDoubleConverter
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Globalization;
using System.Windows.Data;

[ValueConversion(typeof (int), typeof (double))]
internal class RoundedIntToDoubleConverter : IValueConverter
{
  public virtual object Convert(
    object value,
    Type targetType,
    object parameter,
    CultureInfo culture)
  {
    return (object) (double) (int) value;
  }

  public virtual object ConvertBack(
    object value,
    Type targetType,
    object parameter,
    CultureInfo culture)
  {
    return (object) (int) Math.Round((double) value);
  }
}
