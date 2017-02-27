using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CA_1
{
    class FileHandler
    {
        public String[] ReadLinesFromFile(String fileName, String dir)
        {
            String filePath = String.Format("{0}{1}", dir, fileName);
            String[] lines = File.ReadAllLines(filePath);
            return lines;
        }

        public void WriteDataToFile(String fileName, String dir, String[] lines)
        {
            String filePath = String.Format("{0}{1}", dir, fileName);
            File.WriteAllLines(filePath, lines);
        }
    }
}
