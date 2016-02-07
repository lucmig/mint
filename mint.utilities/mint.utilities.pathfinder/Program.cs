using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mint.utilities.pathfinder
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length != 2)
        Console.WriteLine("Please provice two node ids; start and end points.");
      try
      {
        var client = new CalcServiceClient();
        var paths = client.GetShortestPath(args[0], args[1]);
        if (paths.Length > 0)
        {
          Console.WriteLine("Paths:");
          foreach (var path in paths)
          {
            for (var i = 0; i < path.Length; i++)
              if (i == 0)
                Console.Write(string.Format("\t{0}", path[i]));
              else
                Console.Write(string.Format("=>{0}", path[i]));
            Console.WriteLine();
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Path could not be calculated.");
      }
    }
  }
} 
