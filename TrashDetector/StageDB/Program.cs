using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            StageDB stageDB = new StageDB();
            stageDB.DatabaseExists();

           // stageDB.InsertSingleImageFile(@"C:\Users\Chris\OneDrive\Skrivebord\SimpelExample.jpg");
           // stageDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\StageDBData");


            Console.ReadLine();



        }
    }
}
