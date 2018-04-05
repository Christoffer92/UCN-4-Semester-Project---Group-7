using System;
using ModelLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace DatabaseManage
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
            int startIndexOfFilename = filePath.LastIndexOf('\\')+1;
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

        public ImageFile GetImageFileStream(string name) {

                using (var db = new SourceDBContext())
                {
                    return (from imageFile in db.ImagesTable where imageFile.name.Equals(name) select imageFile).First();
                }
        }

        public string GetImageFileStreamTest(string name)
        {

            using (var db = new SourceDBContext())
            {
                return (from imageFile in db.ImagesTable where imageFile.name.Equals(name) select imageFile).First().name;
            }
        }
    }
}


/*
 * System.IO.FileNotFoundException
  HResult=0x80070002
  Message=Could not load file or assembly 'Microsoft.SqlServer.Types, Version=10.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91' or one of its dependencies. The system cannot find the file specified.
  Source=System.Data.Linq
  StackTrace:
   at System.Data.Linq.SqlClient.SqlProvider.Execute(Expression query, QueryInfo queryInfo, IObjectReaderFactory factory, Object[] parentArgs, Object[] userArgs, ICompiledSubQuery[] subQueries, Object lastResult)
   at System.Data.Linq.SqlClient.SqlProvider.ExecuteAll(Expression query, QueryInfo[] queryInfos, IObjectReaderFactory factory, Object[] userArguments, ICompiledSubQuery[] subQueries)
   at System.Data.Linq.SqlClient.SqlProvider.System.Data.Linq.Provider.IProvider.Execute(Expression query)
   at System.Data.Linq.DataQuery`1.System.Linq.IQueryProvider.Execute[S](Expression expression)
   at System.Linq.Queryable.First[TSource](IQueryable`1 source)
   at DatabaseManage.SourceDB.GetImageFileStream(String name) in C:\Users\Chris\Source\Repos\UCN-4-Semester-Project---Group-7\TrashDetector\DatabaseManage\SourceDB.cs:line 81
   at DatabaseManage.Program.Main(String[] args) in C:\Users\Chris\Source\Repos\UCN-4-Semester-Project---Group-7\TrashDetector\DatabaseManage\Program.cs:line 27
*/