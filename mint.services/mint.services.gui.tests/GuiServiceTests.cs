using Microsoft.VisualStudio.TestTools.UnitTesting;
using mint.services.gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace mint.services.gui.tests
{
  using models;
  using data;

  [TestClass()]
  public class GuiServiceTests
  {
    [TestMethod()]
    public void GetAllNodesTest()
    {
      var mockData = new Mock<IData>();
      mockData.Setup(d => d.GetAllNodes()).Returns(new Node[]
      {
        new Node() {id = "1", label = "test 1" },
        new Node() {id = "2", label = "test 2", adjacentNodes = new List<string>() { "1", "3" } },
        new Node() {id = "3", label = "test 3" }
        });
      var dataMan = new GuiService(mockData.Object);
      var nodes = dataMan.GetAllNodes();
      Assert.AreEqual(3, nodes.Count());
      var node2 = nodes.Single(n => n.id == "2");
      Assert.AreEqual("test 2", node2.label);
      Assert.AreEqual(2, node2.adjacentNodes.Count);
    }
  }
}