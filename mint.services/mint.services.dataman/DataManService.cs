using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace mint.services.dataman
{
  using models;
  using data;

  public class DataManService : IDataManService
  {
    private readonly CompositionContainer _container;
    private readonly IData _data;

    public DataManService()
    {
      var catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(IData).Assembly));
      _container = new CompositionContainer(catalog);
      _container.SatisfyImportsOnce(this);
      _data = Data;
    }

    public DataManService(IData data)
    {
      _data = data;
    }

    [Import]
    private IData Data { get; set; }

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
