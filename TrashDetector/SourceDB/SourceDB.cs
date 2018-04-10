using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;


namespace SourceDB
{
    public class SourceDB
    {
        /*
         *         public Comment InsertComment(Comment comment)
        {
            using (var db = new SolvrContext())
            {
               db.Comments.InsertOnSubmit(comment);
               db.SubmitChanges();
            }
            return comment;
        }

         * 
         * */
        public ImageFile InsertImageFile(ImageFile imageFile)
        {
            using (var db = new SourceDBContext())
            {
                db.imageFiles.InsertOnSubmit(imageFile);
                db.SubmitChanges();
            }
            return imageFile;
        }

        public void InsertImageInfo(ImageInfo imageInfo)
        {

        }



        public int InsertSingleImageFile(string filePath)
        {
            int startIndexOfFilename = filePath.LastIndexOf('\\') + 1;
            string fileName = filePath.Substring(startIndexOfFilename);


            try
            {
                using (var db = new SourceDBContext())
                {

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


    }
}
