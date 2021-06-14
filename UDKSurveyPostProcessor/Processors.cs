// Decompiled with JetBrains decompiler
// Type: UDKSurveyPostProcessor.Processors
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Xml.Serialization;

namespace UDKSurveyPostProcessor
{
  public class Processors
  {
    [XmlAttribute]
    public string Description;
    [XmlAttribute]
    public ushort Family;
    [XmlAttribute]
    public string Manufacturer;
    [XmlAttribute]
    public uint MaxClockSpeed;
    [XmlAttribute]
    public ushort DataWidth;
    [XmlAttribute]
    public string Name;
    [XmlAttribute]
    public uint NumberOfPhysicalProcessors;
    [XmlAttribute]
    public uint NumberOfCores;
    [XmlAttribute]
    public uint NumberOfLogicalProcessors;
    [XmlAttribute]
    public string Features;
  }
}
