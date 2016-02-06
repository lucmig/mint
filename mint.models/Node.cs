using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace mint.models
{
  [Serializable, XmlRoot("node")]
  public class Node
  {
    public string id { get; set; }
    public string label { get; set; }
    [XmlArray]
    [XmlArrayItem("id")]
    public List<string> adjacentNodes { get; set; }
  }
}
