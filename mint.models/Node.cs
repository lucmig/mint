using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mint.models
{
  public class Node
  {
    public string Id { get; set; }
    public string Label { get; set; }
    public IEnumerable<string> AdjacentNodes { get; set; }
  }
}
