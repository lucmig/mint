using mint.services.dataman;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace mint.services.dataman.tests
{
  using models;
  using data;

  [TestClass]
  public class DataManServiceTest
  {
    [TestMethod()]
    public void SaveNodeTest()
    {
      var nodeXml = "<node><id>9</id><label>Amazon</label><adjacentNodes><id>10</id></adjacentNodes></node>";
      //var nd = new Node()
      //{
      //  Id = "9",
      //  Label = "Amazon",
      //  AdjacentNodes = new string[] { "10" }
      //};
      var mockData = new Mock<IData>();
      mockData.Setup(d => d.SaveNode(It.IsAny<Node>()))
              .Callback((Node node) =>
              {
                Assert.AreEqual("9", node.id);
                Assert.AreEqual("Amazon", node.label);
                Assert.AreEqual(1, node.adjacentNodes.Count());
                Assert.AreEqual("10", node.adjacentNodes.ToArray()[0]);
              }).Verifiable();
      var dataMan = new DataManService(mockData.Object);
      dataMan.SaveNode(nodeXml);
      mockData.Verify(d => d.SaveNode(It.IsAny<Node>()), Times.Once);
    }
  }
}
