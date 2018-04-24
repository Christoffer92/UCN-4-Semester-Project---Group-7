using ModelLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDatabase
{
    public class TrainingDB
    {
        public bool DatabaseExists()
        {
            try
            {
                using (var db = new TrainingDBContext())
                {
                    return db.DatabaseExists();
                }
            }
            catch (Exception)
            {
                throw new Exception("No Connection to the Stage Database.");
            }
        }

        #region GetMethods


        #endregion

        #region InsertMethods

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

        public void RunSQLScript(string SQLScriptName)
        {
            string sqlScript = null;

            if (SQLScriptName.ToLower().Equals("reset"))
            {
                //To Do: This scripts need to be relative, but for now its local..
                sqlScript = File.ReadAllText(@"C:\Users\Chris\Source\Repos\UCN-4-Semester-Project---Group-7\TrashDetector\TrainingDatabase\Scripts\Reset.sql");
            }

            if (sqlScript != null)
            {
                using (var db = new TrainingDBContext())
                {
                    db.ExecuteCommand(sqlScript);
                }
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
                using (var db = new TrainingDBContext())
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

            if (filePath.Contains("non_cigarettes")) { 
                using (var db = new TrainingDBContext())
                {
                    db.ExecuteCommand("UPDATE ImageFiles SET IsCig = 0 WHERE ID = " + imageFile.ID);
                }
            }
            else{
                using (var db = new TrainingDBContext())
                {
                    db.ExecuteCommand("UPDATE ImageFiles SET IsCig = 1 WHERE ID = " + imageFile.ID);
                }
            }

            return 0;
        }

        #endregion
    }
}
