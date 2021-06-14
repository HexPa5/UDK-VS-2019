// Decompiled with JetBrains decompiler
// Type: UDKSurveyPostProcessor.VideoCard
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Xml.Serialization;

namespace UDKSurveyPostProcessor
{
  public class VideoCard
  {
    [XmlAttribute]
    public string Driver;
    [XmlAttribute]
    public string Description;
    [XmlAttribute]
    public ulong DriverVersion;
    [XmlAttribute]
    public uint VendorID;
    [XmlAttribute]
    public uint DeviceID;
    [XmlAttribute]
    public uint SubSysID;
    [XmlAttribute]
    public uint Revision;
    [XmlAttribute]
    public Guid DeviceIdentifier;
    [XmlAttribute]
    public ushort PixelShaderVersionDX9;
    [XmlAttribute]
    public ushort VertexShaderVersionDX9;
    [XmlAttribute]
    public uint TotalVRAM;
  }
}
