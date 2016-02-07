using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace mint.services.calc.tests
{
  using models;
  using data;

  [TestClass()]
  public class CalcServiceTests
  {
    private Mock<IData> _mockData;
    private CalcService _calc;

    [TestInitialize]
    public void init()
    {
      _mockData = new Mock<IData>();
      _mockData.Setup(d => d.GetAllNodes()).Returns(TestData());
      _calc = new CalcService(_mockData.Object);
    }

    [TestMethod()]
    public void GetShortestPathTest_5_6()
    {
      var paths = _calc.GetShortestPath("5", "6");
      Assert.AreEqual(1, paths.Count());
      Assert.AreEqual(3, paths.ToArray()[0].Count());
      Assert.AreEqual("5", paths.ToArray()[0].ToArray()[0]);
      Assert.AreEqual("7", paths.ToArray()[0].ToArray()[1]);
      Assert.AreEqual("6", paths.ToArray()[0].ToArray()[2]);
    }

    [TestMethod()]
    public void GetShortestPathTest_2_9()
    {
      var paths = _calc.GetShortestPath("2", "9");
      Assert.AreEqual(1, paths.Count());
      Assert.AreEqual(2, paths.ToArray()[0].Count());
      Assert.AreEqual("2", paths.ToArray()[0].ToArray()[0]);
      Assert.AreEqual("9", paths.ToArray()[0].ToArray()[1]);
    }

    [TestMethod()]
    public void GetShortestPathTest_3_9()
    {
      var paths = _calc.GetShortestPath("3", "9");
      Assert.AreEqual(2, paths.Count());
      Assert.AreEqual(4, paths.ToArray()[0].Count());
    }

    private IEnumerable<Node> TestData()
    {
      var nodes = new List<Node>();
      nodes.Add(new Node() { id = "9", label = "Amazon", adjacentNodes = new List<string>() { "10" } });
      nodes.Add(new Node() { id = "1", label = "Apple", adjacentNodes = new List<string>() { "2","3" } });
      nodes.Add(new Node() { id = "6", label = "eBay", adjacentNodes = new List<string>() { "10", "7" } });
      nodes.Add(new Node() { id = "10", label = "Facebook", adjacentNodes = new List<string>() { "9" } });
      nodes.Add(new Node() { id = "3", label = "Google", adjacentNodes = new List<string>() { "5" } });
      nodes.Add(new Node() { id = "4", label = "IBM", adjacentNodes = new List<string>() });
      nodes.Add(new Node() { id = "2", label = "Intel", adjacentNodes = new List<string>() { "1", "10", "5", "9", "7" } });
      nodes.Add(new Node() { id = "7", label = "Microsoft", adjacentNodes = new List<string>() { "6" } });
      nodes.Add(new Node() { id = "5", label = "Paypal", adjacentNodes = new List<string>() { "2", "8", "5", "7" } });
      nodes.Add(new Node() { id = "8", label = "Yahoo", adjacentNodes = new List<string>() { "9" } });
      return nodes;
    }
  }
}