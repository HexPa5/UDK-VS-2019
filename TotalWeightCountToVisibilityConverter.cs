// Decompiled with JetBrains decompiler
// Type: TotalWeightCountToVisibilityConverter
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

[ValueConversion(typeof (int), typeof (Visibility))]
internal class TotalWeightCountToVisibilityConverter : IValueConverter
{
  public virtual object Convert(
    object value,
    Type targetType,
    object parameter,
    CultureInfo culture)
  {
    int num = (int) value;
    return (int) parameter < num ? (object) Visibility.Visible : (object) Visibility.Collapsed;
  }

  public virtual object ConvertBack(
    object value,
    Type targetType,
    object parameter,
    CultureInfo culture)
  {
    return (object) null;
  }
}
