// Decompiled with JetBrains decompiler
// Type: UDKSurveyPostProcessor.UDKHeader
// Assembly: UDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03787CDB-4638-4E03-874B-43F342731149
// Assembly location: C:\UDK\BatmanMods\Binaries\Win64\UDK.exe

using System;
using System.Xml.Serialization;

namespace UDKSurveyPostProcessor
{
  public class UDKHeader
  {
    [XmlAttribute]
    public int Version;
    [XmlAttribute]
    public string ModName;
    [XmlAttribute]
    public Guid ModGuid;
    [XmlAttribute]
    public Guid ModAuthorID;
    [XmlAttribute]
    public Guid ID;
    [XmlAttribute]
    public int SurveyTimeMS;
    [XmlAttribute]
    public int SurveysAttempted;
    [XmlAttribute]
    public int SurveysFailed;
  }
}
