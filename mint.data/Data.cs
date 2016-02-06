using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace mint.data
{
  public class Data
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
  }
}
