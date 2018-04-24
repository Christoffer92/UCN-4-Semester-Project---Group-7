using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Controller
{
    public class PythonInterpreter
    {
        public void RunCmd(string pythonFilePath)
        {
            Process p = new Process();
            
            //the path to python.exe should be changed if possible into a relative path.
            p.StartInfo = new ProcessStartInfo(@"C:\Users\Chris\Anaconda3\python.exe", pythonFilePath)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false
            };
            Console.WriteLine("stating");
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);

            Console.WriteLine("finished");

            Console.ReadLine();
        }
    }
}
