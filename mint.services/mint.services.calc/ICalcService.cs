using System.Collections.Generic;
using System.ServiceModel;

namespace mint.services.calc
{
  using models;

  [ServiceContract]
  public interface ICalcService
  {
    [OperationContract]
    IEnumerable<IEnumerable<string>> GetShortestPath(string from, string to);
  }
}
