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


            stageDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\StageDBData\cigarettes");
            stageDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\StageDBData\non_cigarettes");
            //stageDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\StageDBData\augmented_data\cigarettes");
            //stageDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\StageDBData\augmented_data\non_cigarettes");


            Console.ReadLine();



        }
    }
}
