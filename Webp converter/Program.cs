using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webp_converter
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            //if(args.Length == 0){
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            //} else {
            //    bool checkingDirs = false;
            //    bool checkingFiles = false;
            //    bool removeConvertedFiles = false;

            //    for(int i = 0; i < args.Length; i++) {
            //        if(args[i] == "-d") {
            //            checkingDirs = true;
            //            checkingFiles = false;
            //        }else if(args[i] == "-f") {
            //            checkingFiles = true;
            //            checkingDirs = false;
            //        }else if(args[i] == "-rm") {
            //            removeConvertedFiles = true;
            //        }

            //        if(checkingDirs) {
            //            List<string> inputArray = new List<string>();
            //            List<string> outputArray = new List<string>();
                        
            //            var dir = args[i];
            //            int count = 0;
            //            foreach(var file in Directory.GetFiles(dir, "*", SearchOption.AllDirectories)) {
            //                inputArray.Add(file);
            //                count++;
            //            }
            //            Console.WriteLine($"Checking directory {dir}, found {count} files.");

            //            for(int n = 0; n < inputArray.Count; n++) {
            //                FileInfo fileInf = new FileInfo(inputArray[n]);
            //                string dirPath = fileInf.Directory.FullName;
            //                string fileName = Path.GetFileNameWithoutExtension(inputArray[n]);

            //                Console.WriteLine($"Converting {fileInf.FullName}.");
            //                string outPath = Path.Combine(dirPath, fileName + ".png");
            //                outputArray.Add(outPath);

            //                if(removeConvertedFiles) {
            //                    Console.WriteLine($"Deleting.");
            //                    fileInf.Delete();
            //                }
            //            }

            //            (new Form1()).Convert(inputArray.ToArray(), outputArray.ToArray());
            //        }
            //    }
            //}
        }
    }
}
