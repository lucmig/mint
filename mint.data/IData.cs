using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mint.data
{
  using models;

  public interface IData
  {
    void SaveDoc(string collection, string doc);

    string GetDoc(string collection, string id);

    IEnumerable<Node> GetAllNodes();

    void DeleteNode(string id);

    void DeleteAll();
  }
}
