// Decompiled with JetBrains decompiler
// Type: UDKSurveyPostProcessor.UDKSurvey
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Xml.Serialization;

namespace UDKSurveyPostProcessor
{
  [XmlRoot("Survey")]
  public class UDKSurvey
  {
    public UDKHeader UDKHeader;
    public Locale Locale;
    public OperatingSystem OperatingSystem;
    public Hardware Hardware;
    public string DataCollectionErrorString;

    public UDKSurvey()
    {
      this.UDKHeader = new UDKHeader();
      this.OperatingSystem = new OperatingSystem();
      this.Locale = new Locale();
      this.Hardware = new Hardware();
      this.DataCollectionErrorString = string.Empty;
    }
  }
}
