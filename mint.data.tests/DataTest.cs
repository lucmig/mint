using mint.data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace mint.data.tests
{
  using models;

  [TestClass]
  public class DataTests
  {
    private const string uri = "mongodb://api:api@ds059215.mongolab.com:59215/mint_autotest";

    private IMongoDatabase _db;

    [TestInitialize]
    public void Init()
    {
      var data = new Data(uri);
      var accessor = new PrivateObject(data);
      _db = (IMongoDatabase)accessor.GetField("_db");
    }

    [TestCleanup]
    public void clean()
    {
      _db.DropCollection("node");
    }

    [TestMethod()]
    public void DataTest()
    {
      Assert.AreEqual("mint_autotest", _db.DatabaseNamespace.DatabaseName);
    }

    [TestMethod()]
    public void DeleteAllTest()
    {
      var nodes = new Node[] { new Node() { Id = "a1", Label = "test 1" }, new Node() { Id = "a2", Label = "test 2" } };
      _db.GetCollection<Node>("node").InsertMany(nodes);
      var dta = new Data(uri);
      dta.DeleteAll();
      var result = _db.GetCollection<Node>("node").AsQueryable<Node>().ToList();
      Assert.AreEqual(0, result.Count);
    }

    [TestMethod()]
    public void DeleteNodeTest()
    {
      var nodes = new Node[] { new Node() { Id = "a1", Label = "test 1" }, new Node() { Id = "a2", Label = "test 2" } };
      _db.GetCollection<Node>("node").InsertMany(nodes);
      var dta = new Data(uri);
      dta.DeleteNode("a1");
      var result = _db.GetCollection<Node>("node").AsQueryable<Node>().ToList();
      Assert.AreEqual(1, result.Count);
    }

    [TestMethod()]
    public void GetAllNodesTest()
    {
      var nodes = new Node[] { new Node() { Id = "a1", Label = "test 1" }, new Node() { Id = "a2", Label = "test 2" } };
      _db.GetCollection<Node>("node").InsertMany(nodes);
      var dta = new Data(uri);
      var result = dta.GetAllNodes();
      Assert.AreEqual(2, result.Count());
    }

    [TestMethod()]
    public void SaveNodeTest()
    {
      var dta = new Data(uri);
      dta.SaveNode(new Node() { Id = "a3", Label = "test 3" });
      var result = _db.GetCollection<Node>("node").AsQueryable<Node>().ToList();
      Assert.AreEqual(1, result.Count);
    }
  }
}
