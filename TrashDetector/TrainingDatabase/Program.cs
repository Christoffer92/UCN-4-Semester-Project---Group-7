using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {

            TrainingDB trainingDB = new TrainingDB();
            trainingDB.DatabaseExists();

            trainingDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\TrainingDBData\cigarettes");
            trainingDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\TrainingDBData\non_cigarettes");
            trainingDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\TrainingDBData\augmented_data\non_cigarettes");
            trainingDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\TrainingDBData\augmented_data\cigarettes");
        }
    }
}
