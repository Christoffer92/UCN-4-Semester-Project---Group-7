using ModelLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageDatabase
{
    public class StageDB
    {
        public bool DatabaseExists()
        {
            try
            {
                using (var db = new StageDBContext())
                {
                    return db.DatabaseExists();
                }
            }
            catch (Exception)
            {
                throw new Exception("No Connection to the Stage Database.");
            }
        }

        #region Insert Methods 

        public ImageInfo InsertImageInfo(ImageInfo imageInfo)
        {
            using (var db = new StageDBContext())
            {
                db.imageInfos.InsertOnSubmit(imageInfo);
                db.SubmitChanges();
            }
            return imageInfo;
        }

        public ImageFile InsertImageFile(ImageFile imageFile)
        {
            using (var db = new StageDBContext())
            {
                db.imageFiles.InsertOnSubmit(imageFile);
                db.SubmitChanges();
            }
            return imageFile;
        }

        public int InsertSingleImageFile(string filePath)
        {
            int startIndexOfFilename = filePath.LastIndexOf('\\') + 1;
            string fileName = filePath.Substring(startIndexOfFilename);
            ImageFile imageFile = new ImageFile();
            imageFile.FilePath = filePath;
            imageFile.FileName = fileName;

            try
            {
                using (var db = new StageDBContext())
                {
                    db.imageFiles.InsertOnSubmit(imageFile);
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

        #endregion

        
    }
}
