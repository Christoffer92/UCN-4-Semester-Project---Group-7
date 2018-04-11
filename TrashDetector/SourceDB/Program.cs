using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            SourceDB sourceDB = new SourceDB();
            sourceDB.DatabaseExists();

            sourceDB.InsertSingleImageFile(@"C:\Users\Chris\OneDrive\Skrivebord\SimpelExample.jpg");
            sourceDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\SourceDBData");

            Console.ReadLine();

        }
    }
}
