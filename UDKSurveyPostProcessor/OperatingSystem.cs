// Decompiled with JetBrains decompiler
// Type: UDKSurveyPostProcessor.OperatingSystem
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Xml.Serialization;

namespace UDKSurveyPostProcessor
{
  public class OperatingSystem
  {
    [XmlAttribute]
    public string Platform;
    [XmlAttribute]
    public string Version;
    [XmlAttribute]
    public string ServicePack;
    [XmlAttribute]
    public ushort ServicePackMajor;
    [XmlAttribute]
    public ushort ServicePackMinor;
    [XmlAttribute]
    public ushort SuiteMask;
    [XmlAttribute]
    public byte ProductType;
    [XmlAttribute]
    public string Caption;
    [XmlAttribute]
    public bool Is64Bit;
    [XmlAttribute]
    public string IsUACEnabled;
    [XmlAttribute]
    public bool IsAdmin;
  }
}
