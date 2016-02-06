using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace mint.data
{
  using models;

  public class Data : IData
  {
    private const string mongoUri = "mongodb://api:api@ds059125.mongolab.com:59125/mint";

    private readonly IMongoClient _client;
    private readonly IMongoDatabase _db;

    public Data()
    {
      var url = new MongoUrl(mongoUri);
      _client = new MongoClient(url);
      _db = _client.GetDatabase(url.DatabaseName);
    }

    public void DeleteAll()
    {
      throw new NotImplementedException();
    }

    public void DeleteNode(string id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Node> GetAllNodes()
    {
      throw new NotImplementedException();
    }

    public void SaveNode(Node node)
    {
      throw new NotImplementedException();
    }
  }
}
