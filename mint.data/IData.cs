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
    void SaveNode(Node node);

    IEnumerable<Node> GetAllNodes();

    void DeleteNode(string id);

    void DeleteAll();
  }
}
