using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace mint.services.calc
{
  using models;
  using data;

  public class CalcService : ICalcService
  {
    private readonly CompositionContainer _container;
    private readonly IData _data;

    public CalcService()
    {
      var catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(IData).Assembly));
      _container = new CompositionContainer(catalog);
      _container.SatisfyImportsOnce(this);
      _data = Data;
    }

    public CalcService(IData data)
    {
      _data = data;
    }

    [Import]
    private IData Data { get; set; }

    public IEnumerable<IEnumerable<string>> GetShortestPath(string from, string to)
    {
      var nodes = _data.GetAllNodes().ToList();
      var paths = new List<List<string>>();
      var currentPath = new List<string>();
      currentPath.Add(from);
      GetPathsRec(from, to, from, nodes, currentPath, paths);
      var shortestPathLength = paths.Select(p => p.Count).Min();
      var shortestPaths = paths.Where(p => p.Count == shortestPathLength);
      return shortestPaths;
    }

    private void GetPathsRec(string from, string to, string origin, List<Node> nodes, List<string> currentPath, List<List<string>> paths)
    {
      var currentNode = nodes.Single(n => n.id == from);
      var unvisitedNodes = currentNode.adjacentNodes.Except(currentPath.ToList()).Where(n => n != from).Select(n => n);
      foreach (var next in unvisitedNodes)
      {
        currentPath.Add(next);
        if (next == to)
        {
          var path = new List<string>();
          currentPath.ForEach(p => path.Add(p));
          paths.Add(path);
        }
        else
        {
          GetPathsRec(next, to, origin, nodes, currentPath, paths);
        }
        currentPath.Remove(next);
      }
    }
  }
}
