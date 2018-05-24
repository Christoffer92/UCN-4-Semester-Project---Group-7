using ModelLayer;
using StageDatabase;
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

            //etlCtr.BigReset();

            //etlCtr.InsertDataIntoSourceDB();

            etlCtr.ProcessBatchFromSourceDBToResultDB(20);

            Console.ReadLine();
        }
    }
}
