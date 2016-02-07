using System.ServiceModel;

namespace mint.services.dataman
{
  [ServiceContract]
  public interface IDataManService
  {
    [OperationContract]
    void SaveNode(string node);
  }
}
