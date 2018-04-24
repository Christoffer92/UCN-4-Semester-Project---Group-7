using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace ResultDatabase
{
    public class ResultDB
    {
        public bool DatabaseExists()
        {
            try
            {
                using (var db = new ResultDBContext())
                {
                    return db.DatabaseExists();
                }
            }
            catch (Exception)
            {
                throw new Exception("No Connection to the Source Database.");
            }
        }

        public void RunSQLScript(string SQLScriptName)
        {
            string sqlScript = null;

            if (SQLScriptName.ToLower().Equals("reset"))
            {
                //To Do: This scripts need to be relative, but for now its local..
                sqlScript = File.ReadAllText(@"C:\Users\Chris\Source\Repos\UCN-4-Semester-Project---Group-7\TrashDetector\ResultDatabase\Scripts\Reset.sql");
            }

            if (sqlScript != null)
            {
                using (var db = new ResultDBContext())
                {
                    db.ExecuteCommand(sqlScript);
                }
            }

        }

        #region Insert Methods
        public ImageInfo InsertImageInfo(ImageInfo imageInfo)
        {
            using (var db = new ResultDBContext())
            {
                db.imageInfos.InsertOnSubmit(imageInfo);
                db.SubmitChanges();
            }
            return imageInfo;
        }

        public ImageFile InsertImageFile(ImageFile imageFile)
        {
            using (var db = new ResultDBContext())
            {
                db.imageFiles.InsertOnSubmit(imageFile);
                db.SubmitChanges();
            }
            return imageFile;
        }
        #endregion
    }
}
