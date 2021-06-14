// Decompiled with JetBrains decompiler
// Type: UDKSurveyPostProcessor.Hardware
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System.Xml.Serialization;

namespace UDKSurveyPostProcessor
{
  public class Hardware
  {
    [XmlAttribute]
    public ulong TotalPhysicalMemory;
    [XmlAttribute]
    public ulong TotalHardDriveSize;
    [XmlAttribute]
    public ulong TotalHardDriveFreeSpace;
    [XmlElement("Processors")]
    public Processors ProcessorInfo;
    public VideoCard PrimaryVideoCard;
    public Monitor PrimaryMonitor;
    [XmlAttribute]
    public uint TotalMonitors;
    [XmlAttribute]
    public uint TotalVideoCards;
    [XmlAttribute]
    public sbyte AppCompatLevelCPU;
    [XmlAttribute]
    public sbyte AppCompatLevelGPU;
    [XmlAttribute]
    public sbyte AppCompatLevelComposite;

    public Hardware()
    {
      this.ProcessorInfo = new Processors();
      this.PrimaryVideoCard = new VideoCard();
      this.PrimaryMonitor = new Monitor();
      this.AppCompatLevelCPU = (sbyte) -1;
      this.AppCompatLevelGPU = (sbyte) -1;
      this.AppCompatLevelComposite = (sbyte) -1;
    }
  }
}
