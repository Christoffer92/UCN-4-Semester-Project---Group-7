﻿using ModelLayer;
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
        private static string stageDBDataPathUnprocessed = @"C:\TrashDetector\Data\StageDBData\unprocessed\";
        public static string stageDBDataLog = @"C:\TrashDetector\Data\StageDBData\log.txt";

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

        public void RunSQLScript(string SQLScriptName)
        {
            string sqlScript = null;

            if (SQLScriptName.ToLower().Equals("reset"))
            {
                //To Do: This scripts need to be relative, but for now its local..
                sqlScript = File.ReadAllText(@"C:\Users\Chris\Source\Repos\UCN-4-Semester-Project---Group-7\TrashDetector\StageDB\Scripts\Reset.sql");
            }

            if (sqlScript != null)
            {
                using (var db = new StageDBContext())
                {
                    db.ExecuteCommand(sqlScript);
                }
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

        public void UpdateImageFilePath(ImageFile newImageFile)
        {
            using (var db = new StageDBContext())
            {
                var Query = (from imageFile in db.imageFiles where imageFile.ID == newImageFile.ID select imageFile).First();
                Query.FilePath = newImageFile.FilePath;
                db.SubmitChanges();
            }
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

        public void InsertBatchImageFilesFromSourceDB(int amount, string folderPath)
        {
            int i = 0;
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.jpg"))
            {
                if (amount <= 0)
                    break;

                i++;
                InsertSingleImageFile(file);
                Console.WriteLine("Inserted: " + i + " / " + amount);

                amount--;
            }
        }
        #endregion

        #region Get Methods
        public ImageFile GetImageFile(int id)
        {
            using (var db = new StageDBContext())
            {
                return (from imageFile in db.imageFiles where imageFile.ID == id select imageFile).First();
            }
        }

        public List<ImageFile> GetAllImageFiles()
        {
            List<ImageFile> imageFiles = new List<ImageFile>();

            using (var db = new StageDBContext())
            {
                var Query = from imageFile in db.imageFiles select imageFile;
                foreach (ImageFile item in Query)
                {
                    imageFiles.Add(item);
                }
            }

            return imageFiles;
        }

        public List<ImageInfo> GetAllImageInfos()
        {
            List<ImageInfo> imageInfos = new List<ImageInfo>();

            using (var db = new StageDBContext())
            {
                var Query = from imageInfo in db.imageInfos select imageInfo;
                //foreach (ImageInfo item in Query)
                //{
                //    Console.WriteLine(item.IsCig);
                //}
                foreach (ImageInfo item in Query)
                {
                    imageInfos.Add(item);
                }
            }

            return imageInfos;
        }

        //public List<ImageFile> GetAllImageFilesWithCig(bool isCig)
        //{
        //    List<ImageFile> imageFiles = new List<ImageFile>();

        //    using (var db = new StageDBContext())
        //    {
        //        var Query = from imageFile in db.imageFiles where imageFile.IsCig == "1" select imageFile;
        //        foreach (ImageFile item in Query)
        //        {
        //            imageFiles.Add(item);
        //        }
        //    }

        //    return imageFiles;
        //}
        #endregion
    }
}