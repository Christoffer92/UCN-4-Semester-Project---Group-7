using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceDatabase
{
    public class SourceDB
    {

        private string insertFileSqlString = @"INSERT INTO [dbo].[ImagesTable]
                                                ([name],[file_stream])
                                             SELECT
                                                'file_name',
                                                * FROM OPENROWSET(BULK N'file_path',
                                                SINGLE_BLOB) AS FileData";


        public bool DatabaseExists()
        {
            try
            {
                using (var db = new SourceDBContext())
                {
                    return db.DatabaseExists();
                }
            }
            catch (Exception)
            {
                throw new Exception("No Connection to the Source Database.");
            }
        }

        public int InsertSingleImageFile(string filePath)
        {
            int startIndexOfFilename = filePath.LastIndexOf('\\') + 1;
            string fileName = filePath.Substring(startIndexOfFilename);
            string sqlString = insertFileSqlString.Replace("file_name", fileName).Replace("file_path", filePath);

            try
            {
                using (var db = new SourceDBContext())
                {
                    db.ExecuteCommand(sqlString);
                    db.SubmitChanges();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Console.WriteLine("Cannot Insert " + fileName + " Into database. " +
                                  "Most likely is a violation of unique key constraint " +
                                  "because the file allready exisits in the database");
            }

            return 0;
        }

        public int InsertAllImageFilesFromFolder(string folderPath)
        {
            int noOfFiles = Directory.EnumerateFiles(folderPath, "*.jpg").Count();
            int i = 1;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.jpg"))
            {
                InsertSingleImageFile(file);
                Console.WriteLine("Inserted: " + i + " / " + noOfFiles);
                i++;
            }
            return 0;
        }


        /*
        public ImageFile GetImageFileStream(string name)
        {
            using (var db = new SourceDBContext())
            {
                return (from imageFile in db.ImagesTable where imageFile.name.Equals(name) select imageFile).First();
            }
        }
        */
    }
}

