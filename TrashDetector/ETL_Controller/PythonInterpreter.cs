using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            Console.WriteLine("Starting Python Code.");
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.Dispose();
            //p.WaitForExit();
            //Console.WriteLine(p.ExitTime);
            
            //p.Close();

            Console.WriteLine(output);
            Console.WriteLine("Finished Python Code");
        }
    }
}
