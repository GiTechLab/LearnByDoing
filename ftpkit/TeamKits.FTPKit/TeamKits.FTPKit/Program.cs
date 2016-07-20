using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamKits.FTPKit
{
    struct FTPUploadInfo
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            if (args.Length <= 0)
            {
                args = new List<string>() { @"C:\echotext.txt" }.ToArray();
            }
#endif

            if (args.Length > 0)
            {
                var fileToUpload = args[0];
                if (!File.Exists(fileToUpload))
                {
                    Console.WriteLine("Nothing to upload.");
                }
                else
                {
                    var ftpServer = ConfigurationManager.AppSettings["FTPServer"];
                    var ftpDestinationFolder = ConfigurationManager.AppSettings["FTPDestinationFolder"];
                    var ftpLogin = ConfigurationManager.AppSettings["FTPLogin"]; 
                    var ftpPassword = ConfigurationManager.AppSettings["FTPPassword"];
                    Console.WriteLine("It is uploading file " + fileToUpload + " to FTP://" + ftpServer + ftpDestinationFolder);

                    //Async Job
                    UploadTaskAsync();

                    Console.WriteLine("The File is Uploading");
                }
            }
            else
            {
                Console.WriteLine("Invalid Upload Parameter. Nothing to upload.");
            }


            
#if DEBUG
            Console.ReadKey();
#endif
        }

        static async void UploadTaskAsync()
        {
            await Task.Factory.StartNew(() => {
                //System.Threading.Thread.Sleep(5000);

                Console.WriteLine("The File has been uploaded.");
            });
        }
    }
}
