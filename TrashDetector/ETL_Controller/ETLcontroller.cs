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

        internal void ResetStageDB()
        {
            StageDB stageDB = new StageDB();
            stageDB.RunSQLScript("Reset");
        }

        internal void LoadDataFromStageDBtoResultDB()
        {
            throw new NotImplementedException();
        }

        public void ImageRegonitionPrediction()
        {
            PythonInterpreter pythonInterpreter = new PythonInterpreter();
            //TODO needs to be a relative path.
            pythonInterpreter.RunCmd(@"C:\Users\Chris\Source\Repos\UCN-4-Semester-Project---Group-7\TrashDetector\ImageRegonition\predictBatchFromStageDB.py");
        }

        public void ResetSourceDB()
        {
            SourceDB sourceDB = new SourceDB();
            sourceDB.RunSQLScript("Reset");
        }

        public void ExtractMetadataIntoStageDB()
        {
            JpegInfoCollecter jpegInfoCollecter = new JpegInfoCollecter();
            jpegInfoCollecter.CollectInformation();
        }

    }
}
