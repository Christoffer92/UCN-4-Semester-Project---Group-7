using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            JpegInfoCollecter jInfoCollecter = new JpegInfoCollecter();
            jInfoCollecter.CollectInformation();

            Console.ReadLine();
        }
    }
}
