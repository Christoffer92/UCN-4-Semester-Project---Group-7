﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;


namespace SourceDatabase
{
    public class SourceDB
    {
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

        public int GetImageFilesCount()
        {
            using (var db = new SourceDBContext())
            {
                return (from imageFile in db.imageFiles select imageFile).Count();
            }
        }

        #region Insert Methods 

        public ImageFile InsertImageFile(ImageFile imageFile)
        {
            using (var db = new SourceDBContext())
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
                using (var db = new SourceDBContext())
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

        #region Get Methods

        public ImageFile GetImageFile(int id)
        {
            using (var db = new SourceDBContext())
            {
                return (from imageFile in db.imageFiles where imageFile.ID == id select imageFile).First();
            }
        }

        public List<ImageFile> GetAllImageFiles()
        {
            List<ImageFile> imageFiles = new List<ImageFile>();

            using (var db = new SourceDBContext())
            {
                var Query = from imageFile in db.imageFiles select imageFile;
                foreach (ImageFile item in Query)
                {
                    imageFiles.Add(item);
                }
            }

            return imageFiles;

        }

        #endregion

        public int RunSQLScript(string SQLScriptName)
        {
            string sqlScript = null;
            int ress = 0;

            if (SQLScriptName.ToLower().Equals("reset"))
            {
                //To Do: This scripts need to be relative, but for now its local..
                sqlScript = File.ReadAllText(@"C:\Users\Chris\Source\Repos\UCN-4-Semester-Project---Group-7\TrashDetector\SourceDB\Scripts\Reset.sql");
            }

            if (sqlScript != null)
            {
                using (var db = new SourceDBContext())
                {
                    ress = db.ExecuteCommand(sqlScript);
                }
            }

            return ress;
                
        }
    }
}