using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Controller
{
    public class Program
    {
        static void Main(string[] args)
        {
            ETLcontroller etlCtr = new ETLcontroller();
            etlCtr.ResetSourceDB();
            etlCtr.ResetStageDB();

            etlCtr.InsertDataIntoSourceDB();
            etlCtr.LoadDataFromSourceDBtoStageDB();
            etlCtr.ExtractMetadataIntoStageDB();

            //blur_blur_IMG_20180423_122036
            //Method not done
            etlCtr.ImageRegonitionPrediction();

            //Method not done
            //etlCtr.LoadDataFromStageDBtoResultDB();


            



            Console.ReadLine();
        }
    }
}
