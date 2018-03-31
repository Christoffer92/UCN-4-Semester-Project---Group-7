using System;
using ModelLibrary;

namespace DatabaseManage
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stating console aplication");

            SourceDB sourceDB = new SourceDB();

            if (sourceDB.DatabaseExists())
                Console.WriteLine("Connection: true");
            else
                Console.WriteLine("Connection: false");


            sourceDB.InsertSingleImageFile(@"C:\Users\Chris\OneDrive\Skrivebord\SimpelExample.jpg");
            sourceDB.InsertAllImageFilesFromFolder(@"C:\Users\Chris\OneDrive\Skrivebord\Pictures");

            //DataCollector dataCollector = new DataCollector();
            //dataCollector.DownloadImageFolderFromUrl("https://video-downloads.googleusercontent.com/ACG88tPx1tHipfXbxK7_UFjrdOb562PTCN2rbUjxJPDlTQr7QM956b1M1HcMgDIwwpVTSCRDgT117FhM-KyNF6JLXF4d2w9SkdQA8k1Qr0fDk2_PCfOotX0z4E6akg3Q7sDF9sZeWIPXj6D9uRC5Z0SdLe1rSZtRya2rfvMdac7Pzm1wnuxLhXOLCAwNRDRwIFBAZX2Ued8Xvs4tS235a7qnoT2QndjLwkfzm3sZo3WcTDFTrzbu12dUiutdy9tVPgmaeImu4Xpprq1eDVVTyFQG1KXIbTQCPlLMnlboOADvZQ6baxe92xDujVpUTrkYd5-7TOm3gKhm2uzRMRRIM3u4QehgN6PsF2YhBbIOXN5DQdZVfxJXYgG5xuPfQd1Xt2lwHeK4cceJNyz1rFAciRroIuy_NRPSk23HsPaTCcXFCz4KB1x8edA4TDM8U1XpHO6JILEAT1Cv_km3Qbk1PYtXxi5GrGtdqPQOpQcPiBlQi1FaLE1MVAXeYxGxhFdIexIJRghIfkAkmF7vQV_utjX9PqJhncprPXdaIvuCKHskUuEfHNz5UVsMxWq-vPRoZ8L0IusWpLbc0QmPJRj2EIKD5wWvLVLVRc4djGNEtod1pJ-_9qxiuxVDLfg22CMf7y6oZ_S6e4f1r_iVGLFtASdMdQo8Xb3HAW4pPdbDAYF0pJ79oTq9gdzuELe5N8Whhu6fsa3HFAVYLUGMuoISZEYFGwtYOrjfnmLyUJgCG9WgZlZ9bGi-MCZdrKTBzyOTE9B0oydh75vfKBBTWR1qutn6GbpXoDFuRw");

            Console.ReadLine();
        }
    }
}
