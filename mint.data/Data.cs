using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace mint.data
{
  using models;

  public class Data : IData
  {
    private const string mongoUri = "mongodb://api:api@ds059125.mongolab.com:59125/mint";

    private readonly IMongoClient _client;
    private readonly IMongoDatabase _db;

    public Data(): this(mongoUri)
    {}

    public Data(string uri)
    {
      var url = new MongoUrl(uri);
      _client = new MongoClient(url);
      _db = _client.GetDatabase(url.DatabaseName);
    }

    public void DeleteAll()
    {
      var col = _db.GetCollection<Node>("node");
      col.DeleteMany<Node>(n => true);
    }

    public void DeleteNode(string id)
    {
      var col = _db.GetCollection<Node>("node");
      col.DeleteOne<Node>(n => n.Id == id);
    }

    public IEnumerable<Node> GetAllNodes()
    {
      return _db.GetCollection<Node>("node").AsQueryable()
                .ToEnumerable();
    }

    public void SaveNode(Node node)
    {
      var col = _db.GetCollection<Node>("node");
      col.InsertOne(node);
    }
  }
}
