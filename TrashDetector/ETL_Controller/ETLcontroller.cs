using SourceDatabase;
using System;
using System.Collections.Generic;
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
