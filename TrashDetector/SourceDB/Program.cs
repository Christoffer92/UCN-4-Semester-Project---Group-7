using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceDB
{
    public class Program
    {
        static void Main(string[] args)
        {
            SourceDB sourceDB = new SourceDB();
            sourceDB.DatabaseExists();


            //sourceDB.InsertSingleImageFile(@"C:\Users\Chris\OneDrive\Skrivebord\SimpelExample.jpg");
            //sourceDB.InsertAllImageFilesFromFolder(@"C:\Users\Chris\OneDrive\Skrivebord\Pictures");



            ImageFile imageFile = new ImageFile();
            imageFile.filePath = @"C:\Users\Chris\OneDrive\Skrivebord\SimpelExample.jpg";
            imageFile.ID = 2;


            sourceDB.InsertImageFile(imageFile);

            Console.ReadLine();

        }
    }
}
