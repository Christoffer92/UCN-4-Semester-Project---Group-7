using ModelLayer;
using ResultDatabase;
using SourceDatabase;
using StageDatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransformData;

namespace ETL_Controller
{
    public class ETLcontroller
    {

        public ETLcontroller(){
        }

        public void InsertDataIntoSourceDB()
        {
            SourceDB sourceDB = new SourceDB();
            sourceDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\SourceDBData");
        }

        internal void LoadDataFromSourceDBtoStageDB()
        {
            StageDB stageDB = new StageDB();
            stageDB.InsertAllImageFilesFromFolder(@"C:\TrashDetector\Data\SourceDBData");
        }

        #region ResetDB Methods
        public void ResetStageDB()
        {
            StageDB stageDB = new StageDB();
            stageDB.RunSQLScript("reset");
        }

        public void ResetResultDB()
        {
            ResultDB resultDB = new ResultDB();
            resultDB.RunSQLScript("reset");
        }

        public void ResetSourceDB()
        {
            SourceDB sourceDB = new SourceDB();
            sourceDB.RunSQLScript("Reset");
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
            pythonInterpreter.RunCmd(@"C:\Users\Chris\Source\Repos\UCN-4-Semester-Project---Group-7\TrashDetector\ImageRegonition\predictBatchFromStageDB.py");
        }


        public void ExtractMetadataIntoStageDB()
        {
            JpegInfoCollecter jpegInfoCollecter = new JpegInfoCollecter();
            jpegInfoCollecter.CollectInformation();
        }

    }
}
