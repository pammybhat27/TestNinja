using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking {
  public  class FileReader {

      public string Read(string path)
      {
          return File.ReadAllText("video.txt");
      }

  }
}
