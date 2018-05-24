using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileTransfer
{
    public class FileMover
    {
        public FileMover(){
        }

        public void MoveJpgFiles(string sourceFilePath, string destFilePath, int amount)
        {
            sourceFilePath = @"C:\TrashDetector\Data\SourceDBData";
            destFilePath = @"C:\TrashDetector\Data\StageDBData\unprocessed";

            foreach (string file in Directory.EnumerateFiles(sourceFilePath, "*.jpg"))
            {
                if (amount <= 0)
                    break;

                File.Move(file, destFilePath);
                amount--;
            }
        }
    }
}
