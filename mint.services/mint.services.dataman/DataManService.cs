using System.Xml.Serialization;
using System.IO;
using System.ComponentModel.Composition;

namespace mint.services.dataman
{
  using models;
  using data;

  public class DataManService : IDataManService
  {
    private readonly IData _data;

    [ImportingConstructor]
    public DataManService(IData data)
    {
      _data = data;
    }

    public void SaveNode(string nodeXml)
    {
      var ser = new XmlSerializer(typeof(Node));
      using (var reader = new StringReader(nodeXml))
      {
        var node = (Node)ser.Deserialize(reader);
        _data.SaveNode(node);
      }
    }
  }
}
