using System;
using System.IO;

namespace mint.utilities.dataloader
{
  class Program
  {
    static void Main(string[] args)
    {
      var path = Directory.GetCurrentDirectory();
      if (args.Length > 0)
        if (Directory.Exists(args[0]))
          path = args[0];
      var files = Directory.GetFiles(path, "*.xml");
      var client = new DataManServiceClient();
      foreach (var file in files)
        try
        {
          var xmlString = System.IO.File.ReadAllText(file);
          client.SaveNode(xmlString);
        }
        catch (Exception ex)
        {
          Console.WriteLine(string.Format("File {0} load failed, with error: {1}.", file, ex.Message));
        }
    }
  }
}
