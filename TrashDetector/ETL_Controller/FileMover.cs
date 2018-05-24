using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ModelLayer;
using StageDatabase;
using System.Threading;

namespace ETL_Controller
{
    public class FileMover
    {
        public FileMover() {
        }

        public void CopyJpgFiles(string sourceFilePath, string destFilePath, int amount)
        {
            foreach (string file in Directory.EnumerateFiles(sourceFilePath, "*.jpg"))
            {
                if (amount <= 0)
                    break;

                string fileName = file.Split('\\').Last();

                Console.WriteLine(destFilePath + fileName);
                File.Copy(file, destFilePath + fileName);
                amount--;
            }
        }

        internal void ResetStageDBLogFile()
        {
            throw new NotImplementedException();
        }

        public void DeleteEveryJpgFileInFolder(string folderPath)
        {
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.jpg"))
            {
                File.Delete(file);
            }
        }

        public void DeleteEveryJpgFileInFolderAndSubFolders(string folderPath)
        {
            foreach (string folder in Directory.EnumerateDirectories(folderPath)) {
                DeleteEveryJpgFileInFolder(folder);
                Console.WriteLine("Deleted all jpg files in: " + folder);
            }
        }

        public void MoveJpgFiles(string sourceFilePath, string destFilePath, int amount)
        {
            foreach (string file in Directory.EnumerateFiles(sourceFilePath, "*.jpg"))
            {
                if (amount <= 0)
                    break;

                string fileName = file.Split('\\').Last();

                Console.WriteLine(destFilePath + fileName);
                File.Move(file, destFilePath + fileName);
                amount--;
            }
        }

        public void MoveImageFilesFromFolderToFolder(string sourceFolder, string distFolder)
        {
            foreach (string file in Directory.EnumerateFiles(sourceFolder, "*.jpg"))
            {
                string fileName = file.Split('\\').Last();
                File.Move(file, distFolder + fileName);
            }
        }

        public void MoveImageFile(ImageFile imageFile, string destFilePath)
        {
            int NumberOfRetries = 8;
            int DelayOnRetry = 3000;

            for (int i=1; i <= NumberOfRetries; ++i) {
                try {
                    File.Move(imageFile.FilePath, destFilePath + imageFile.FileName);
                    break;
                }
                catch (IOException e) when (i <= NumberOfRetries) {
                    // You may check error code to filter some exceptions, not every error
                    // can be recovered.
                    Console.WriteLine(e);
                    Thread.Sleep(DelayOnRetry);
                    //throw (e);
                 }
            }
        }
    








    public void CopyImageFile(ImageFile imageFile, string destFilePath)
        {
            File.Copy(imageFile.FilePath, destFilePath + imageFile.FileName);
        }

        public void UpdateTxtFile(string txt, string logFile)
        {
            StreamWriter sw = new System.IO.StreamWriter(StageDB.stageDBDataLog);
            sw.Write(txt, 1);
            sw.Close();
            if (txt.Equals(""))
                Console.WriteLine("Reseted: " + logFile);
        }
    }
}
