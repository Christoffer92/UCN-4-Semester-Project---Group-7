using ModelLayer;
using ResultDatabase;
using SourceDatabase;
using StageDatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransformData;

namespace ETL_Controller
{
    public class ETLcontroller
    {

        public static string sourceDBDataFolder = @"C:\TrashDetector\Data\SourceDBData";



        public void ProcessBatchFromSourceDBToResultDB(int amount)
        {
            int leftToDo = amount;
            int batch = 50;

            SourceDB sourceDB = new SourceDB();
            int imageFilesInSourceDB = sourceDB.GetImageFilesCount();

            ResultDB resultDB = new ResultDB();
            int imageFilesInResultDB = resultDB.GetImageFilesCount();

            int diffResultDBandSourceDB = imageFilesInSourceDB - imageFilesInResultDB;

            if (diffResultDBandSourceDB == 0)
            {
                Console.WriteLine("No new images in sourceDB to process");
                return;
            }

            while (leftToDo > 0){

                if (leftToDo <= batch)
                {
                    batch = leftToDo;
                }
                if (leftToDo > diffResultDBandSourceDB)
                {
                    batch = diffResultDBandSourceDB;
                }
                if (batch == 0)
                {
                    break;
                }

                CopyJpgFiles(ETLcontroller.sourceDBDataFolder, ETLcontroller.stageDBDataUnporssedFolder, batch);
                InsertDataIntoStageDBFromUnprocessed();
                ExtractMetadataIntoStageDB();
                ImageRegonitionPrediction();
                SortFilesInStageDBData();
                MoveFilesFromStageDBDataToResultDBData();

                LoadDataFromStageDBtoResultDB();
                ResetStageDB();

                leftToDo -= 50;
            }
        }

        private void MoveFilesFromStageDBDataToResultDBData()
        {
            FileMover fileMover = new FileMover();
            fileMover.MoveImageFilesFromFolderToFolder(@"C:\TrashDetector\Data\StageDBData\uncertain", @"C:\TrashDetector\Data\ResultDBData\uncertain\");
            fileMover.MoveImageFilesFromFolderToFolder(@"C:\TrashDetector\Data\StageDBData\non_cigarettes", @"C:\TrashDetector\Data\ResultDBData\non_cigarettes\");
            fileMover.MoveImageFilesFromFolderToFolder(@"C:\TrashDetector\Data\StageDBData\cigarettes", @"C:\TrashDetector\Data\ResultDBData\cigarettes\");
        }

        internal void BigReset()
        {
            ResetSourceDB();
            ResetStageDB();
            ResetResultDB();

            FileMover fileMover = new FileMover();

            fileMover.DeleteEveryJpgFileInFolderAndSubFolders(@"C:\TrashDetector\Data\StageDBData");
            fileMover.DeleteEveryJpgFileInFolderAndSubFolders(@"C:\TrashDetector\Data\ResultDBData");
            fileMover.UpdateTxtFile("", StageDB.stageDBDataLog);
        }

        internal void InsertDataIntoStageDBFromUnprocessed()
        {
            StageDB stageDB = new StageDB();
            stageDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\StageDBData\unprocessed\");
        }

        public static string stageDBDataUnporssedFolder = @"C:\TrashDetector\Data\StageDBData\unprocessed\";
        public static string predictBatchFromStageDBPythonPath = @"C:\Users\Chris\Source\Repos\UCN-4-Semester-Project---Group-7\TrashDetector\ImageRegonition\predictBatchFromStageDB.py";

        public ETLcontroller(){
        }

        public void InsertDataIntoSourceDB()
        {
            SourceDB sourceDB = new SourceDB();
            sourceDB.InsertAllImageFilesFromFolder(sourceDBDataFolder);
        }

        public void SortFilesInStageDBData()
        {
            StageDB stageDB = new StageDB();
            List<ImageInfo> imageInfos = new List<ImageInfo>();
            imageInfos = stageDB.GetAllImageInfos();

            FileMover fileMover = new FileMover();

            decimal isCigDecider = new decimal(0.70);
            decimal isNonCigDecider = new decimal(0.70);

            foreach (ImageInfo imageInfo in imageInfos)
            {
                //{ LessThan = -1, Equals = 0, GreaterThan = 1 }

                if (Decimal.Compare(imageInfo.IsCig, isCigDecider) == 1 || Decimal.Compare(imageInfo.IsCig, isCigDecider) == 0)
                {
                    ImageFile imageFile = stageDB.GetImageFile(imageInfo.ImageFileID);
                    fileMover.MoveImageFile(imageFile, @"C:\TrashDetector\Data\StageDBData\cigarettes\");
                    imageFile.FilePath = @"C:\TrashDetector\Data\StageDBData\cigarettes\" + imageFile.FileName;
                    stageDB.UpdateImageFilePath(imageFile);
                }
                else if (Decimal.Compare(imageInfo.IsNotCig, isNonCigDecider) == 1 || Decimal.Compare(imageInfo.IsCig, isNonCigDecider) == 0)
                {
                    ImageFile imageFile = stageDB.GetImageFile(imageInfo.ImageFileID);
                    fileMover.MoveImageFile(imageFile, @"C:\TrashDetector\Data\StageDBData\non_cigarettes\");
                    imageFile.FilePath = @"C:\TrashDetector\Data\StageDBData\non_cigarettes\" + imageFile.FileName;
                    stageDB.UpdateImageFilePath(imageFile);
                }
                else
                {
                    ImageFile imageFile = stageDB.GetImageFile(imageInfo.ImageFileID);
                    fileMover.MoveImageFile(imageFile, @"C:\TrashDetector\Data\StageDBData\uncertain\");
                    imageFile.FilePath = @"C:\TrashDetector\Data\StageDBData\uncertain\" + imageFile.FileName;
                    stageDB.UpdateImageFilePath(imageFile);
                }
            }
        }

        internal void LoadDataFromSourceDBtoStageDB()
        {
            StageDB stageDB = new StageDB();
            stageDB.InsertAllImageFilesFromFolder(sourceDBDataFolder);
        }

        #region ResetDB Methods
        public void ResetStageDB()
        {
            StageDB stageDB = new StageDB();
            stageDB.RunSQLScript("reset");
            Console.WriteLine("Resetted Stage Database");
        }

        public void ResetResultDB()
        {
            ResultDB resultDB = new ResultDB();
            resultDB.RunSQLScript("reset");
            Console.WriteLine("Resetted Result Database");
        }

        public void ResetSourceDB()
        {
            SourceDB sourceDB = new SourceDB();
            sourceDB.RunSQLScript("Reset");
            Console.WriteLine("Resetted SourceDB");
        }
        #endregion

        public void LoadDataFromStageDBtoResultDB()
        {
            List<ImageFile> imageFiles = new List<ImageFile>();
            List<ImageInfo> imageInfos = new List<ImageInfo>();

            StageDB stageDB = new StageDB();
            ResultDB resultDB = new ResultDB();


            imageFiles = stageDB.GetAllImageFiles();
            imageInfos = stageDB.GetAllImageInfos();
          

            foreach (ImageFile imageFile in imageFiles)
            {
                imageFile.FilePath.Replace("StageDBData", "ResultDBData");
                resultDB.InsertImageFile(imageFile);
            }

            foreach(ImageInfo imageInfo in imageInfos)
            {
                resultDB.InsertImageInfo(imageInfo);
            }
        }

        public void ImageRegonitionPrediction()
        {
            PythonInterpreter pythonInterpreter = new PythonInterpreter();
            //TODO needs to be a relative path.
            pythonInterpreter.RunCmd(predictBatchFromStageDBPythonPath);

            //Trying to clear memmory to free up images for I/O
            pythonInterpreter = new PythonInterpreter();
        }


        public void ExtractMetadataIntoStageDB()
        {
            JpegInfoCollecter jpegInfoCollecter = new JpegInfoCollecter();
            jpegInfoCollecter.CollectInformation();
        }



        public void CopyJpgFiles(string sourceFilePath, string destFilePath, int amount)
        {
            FileMover fileMover = new FileMover();

            StreamReader sr = new StreamReader(StageDB.stageDBDataLog);
            string line = sr.ReadLine();
            int lastImageFileIndex = 0;
            if (line != null)
                lastImageFileIndex = Int32.Parse(line);

            sr.Close();


            for (int i = 1; i <= amount; i++)
            {
                SourceDB sourceDB = new SourceDB();
                ImageFile imageFile = sourceDB.GetImageFile(lastImageFileIndex+i);

                fileMover.CopyImageFile(imageFile, stageDBDataUnporssedFolder);
            }
            
                if (lastImageFileIndex == 0)
                    lastImageFileIndex = amount;
                else
                    lastImageFileIndex += amount;


                fileMover.UpdateTxtFile(lastImageFileIndex.ToString(), StageDB.stageDBDataLog);


            //StageDB.stageDBDataLog
            //fileMover.CopyJpgFiles(sourceFilePath, destFilePath, amount);
        }

    }
}
