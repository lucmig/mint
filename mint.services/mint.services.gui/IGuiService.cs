using System.Collections.Generic;
using System.ServiceModel;

namespace mint.services.gui
{
  using models;

  [ServiceContract]
  public interface IGuiService
  {
    [OperationContract]
    IEnumerable<Node> GetAllNodes();
  }
}
