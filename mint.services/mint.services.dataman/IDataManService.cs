using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace mint.services.dataman
{
  using models;
  using data;

  [ServiceContract]
  public interface IDataManService
  {
    [OperationContract]
    void SaveNode(Node node);

    [OperationContract]
    Node GetNodeById(string id);

    [OperationContract]
    IEnumerable<Node> GetAllNodes();

    [OperationContract]
    void DeleteNode(string id);

    [OperationContract]
    void DeleteAll();
  }
}
