using System;
using ModelLibrary;

namespace DatabaseManage
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("gsadgasg");

            SourceDB sourceDB = new SourceDB();

            if (sourceDB.DatabaseExists())
                Console.WriteLine("true");
            else
                Console.WriteLine("false");

            Console.ReadLine();

            Image image = new Image
            {
                Longtitude = "32"
            };
            sourceDB.InsertImage(image);
        }
    }
}
