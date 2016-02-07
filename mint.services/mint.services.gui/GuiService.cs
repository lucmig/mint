using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace mint.services.gui
{
  using models;
  using data;

  public class GuiService : IGuiService
  {
    private readonly CompositionContainer _container;
    private readonly IData _data;

    public GuiService()
    {
      var catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(IData).Assembly));
      _container = new CompositionContainer(catalog);
      _container.SatisfyImportsOnce(this);
      _data = Data;
    }

    public GuiService(IData data)
    {
      _data = data;
    }

    [Import]
    private IData Data { get; set; }

    public IEnumerable<Node> GetAllNodes()
    {
      return _data.GetAllNodes();
    }
  }
}
