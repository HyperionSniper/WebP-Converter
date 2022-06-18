using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AnyAscii;
using Ookii.Dialogs.Wpf;

namespace Webp_converter
{
    public partial class Form1 : Form
    {
        //TODO: USE MULTITHREAD "-mt" TAG!
        string binToolsVersion = "https://storage.googleapis.com/downloads.webmproject.org/releases/webp/libwebp-0.4.1-rc1-windows-x64-no-wic.zip";
        int maxProcesses = 10; //Max parallel processes when converting.

        public Form1()
        {
            InitializeComponent();
            string[] types = { "png", "bmp", "tiff", "pam", "ppm", "pgm", "yuv" };
            outputType.Items.AddRange(types);
            outputType.SelectedIndex = 0; //Make sure to select the first item instead of "BLANK".
        }

        private void FilesInputButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            inputFileDialog.Filter = "Image files (*.webp)|*.webp|All files (*.*)|*.*";
            inputFileDialog.Multiselect = true;
            inputFileDialog.Title = "Select file(s)";

            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilesInputTextbox.Clear(); //Clear previous selection / files
                convertTextbox.Clear(); //Clear previous selection / files.
                foreach (string filePath in inputFileDialog.FileNames)
                {
                    FilesInputTextbox.Text += filePath + ";";
                    convertTextbox.Text += filePath.Replace(".webp", $".{outputType.SelectedItem.ToString()};");
                    //MessageBox.Show(filePath);
                }
            }
        }

        private void DirsInputButton_Click(object sender, EventArgs e) {
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            dialog.Multiselect = true; ;
            dialog.UseDescriptionForTitle = true;
            dialog.Description = "Select folder(s)";

            if (dialog.ShowDialog() == true) {
                DirsInputTextbox.Clear(); //Clear previous selection / files
                convertTextbox.Clear(); //Clear previous selection / files.

                foreach (string dirPath in dialog.SelectedPaths) {
                    DirsInputTextbox.Text += dirPath + ";";
                    foreach (var filePath in Directory.GetFiles(dirPath, "*", SearchOption.TopDirectoryOnly)) {
                        convertTextbox.Text += filePath.Replace(".webp", $".{outputType.SelectedItem.ToString()};");
                    }
                }
            }
        }

        private void InputTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void convertTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {

            if(CheckTools()){
                List<string> inputArray = new List<string>(FilesInputTextbox.Text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)); //Remove empty entries using filter.
                List<string> outputArray = new List<string>();

                string[] inputDirsArray = DirsInputTextbox.Text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries); //Remove empty entries using filter.

                Status("Checking dirs");
                for (int i = 0; i < inputDirsArray.Length; i++) {
                    var dir = inputDirsArray[i];
                    int count = 0;
                    foreach (var file in Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly)) {
                        inputArray.Add(file);
                        count++;
                    }
                    Console.WriteLine($"Checking directory {dir}, found {count} files.");
                }

                List<string> newInputArray = new List<string>();
                List<string> newOutputArray = new List<string>();

                Status($"Getting converted file paths{(DeleteConverted.Checked ? " and deleting converted files" : "")}.");
                for (int n = 0; n < inputArray.Count; n++) {
                    var inPath = inputArray[n];

                    // if unicode name
                    if (Encoding.UTF8.GetByteCount(inPath) != inPath.Length) {
                        newInputArray.Add(Path.GetTempFileName());
                        newOutputArray.Add(Path.GetTempFileName());
                    }
                    else {
                        newInputArray.Add(null);
                        newOutputArray.Add(null);
                    }

                    // get original output path
                    outputArray.Add(inputArray[n].Replace(".webp", $".{outputType.SelectedItem.ToString()}"));
                }

                Convert(inputArray.ToArray(), outputArray.ToArray(), newInputArray.ToArray(), newOutputArray.ToArray());
            }
        }

        public void Convert(string[] originalInputArray, string[] originalOutputArray, string[] inputArray, string[] outputArray)
        {
            int currentProcessCount = 0;

            convertTextbox.Clear();

            List<Process> processes = new List<Process>();

            bool elevated = false; 

            bool deleteConverted = DeleteConverted.Checked;
            int successes = 0;
            int failsToInvalidInput = 0;
            int failsToMismatch = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (originalInputArray.Length == originalOutputArray.Length) //if arrays arren't the same size something went wrong. (Need output path & name)
                {
                    string input = originalInputArray[i];
                    string output = originalOutputArray[i];

                    if (input.Length > 0 && output.Length > 0) //Array can't be null or empty.
                    {
                        bool copyTempFile = inputArray[i] != null;

                        if (copyTempFile) {
                            input = inputArray[i];
                            output = outputArray[i];

                            if (elevated || !File.Exists(inputArray[i])) {
                                File.Copy(originalInputArray[i], inputArray[i], true);
                            }
                        }

                        convertTextbox.Text += input + "=>" + output + "\n";

                        string extraParameter = "";

                        if (outputType.SelectedItem.ToString() != "png") //png is default so no parameters needed. if changed, add parameters.
                        {
                            extraParameter = $"-{outputType.SelectedItem.ToString()}";
                        }
                        Process dwebp = new Process();
                        dwebp.StartInfo.FileName = $"{Environment.CurrentDirectory}/bin/bin/dwebp.exe";
                        dwebp.StartInfo.Arguments = $"\"{input}\" {extraParameter} -o \"{output}\"";
                        dwebp.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //Hide windows so you dont get console windows spam when converting 100+ files.
                        dwebp.EnableRaisingEvents = true; //To enable .Exited call.

                        dwebp.Exited += (s, e) => //Count when process is done and decrease process count.
                        {
                            currentProcessCount--;

                            bool isTemp = copyTempFile;
                            if (isTemp) {
                                int index = i;

                                if (elevated || !File.Exists(originalOutputArray[index])) {
                                    File.Copy(outputArray[index], originalOutputArray[index], elevated);
                                }

                                if (elevated) {
                                    File.Delete(inputArray[index]);
                                    File.Delete(outputArray[index]);
                                }
                            }

                            if (deleteConverted) {
                                //File.Delete(originalInputArray[i]);
                            }

                            successes++;
                        };

                        processes.Add(dwebp);
                        dwebp.Start();
                        currentProcessCount++; //Add process because it just started another one.

                        if (currentProcessCount >= maxProcesses) //When max processes reached. wait for processes to finish before starting more.
                            dwebp.WaitForExit(); //Wait for process to finish before continueing.

                        //Maybe add "Max Process count" so you can run 10 instances at the same time?
                        float procDone = (float)(100 / (float)inputArray.Length) * (float)(i + 1); //Thats a lot of floats!.... yep.. the calculations doesn't work if its not float. the 100 / lenght returns 0 because it thinks its a INT...
                        Status($"Converting {i + 1}/{inputArray.Length} {(int)procDone}%"); // i + 1 because arrays start at 0... Also converting the float to int for readability.
                    }
                    else failsToInvalidInput++;
                }
                else failsToMismatch ++;
            }

            Status($"Done converting: {(successes == inputArray.Length && successes != 0 ? "SUCCESS" : "FAIL")}; {successes}/{inputArray.Length} successes; Mismatched: {failsToMismatch}; Invalid: {failsToInvalidInput}");
        }

        private void outputType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool CheckTools()
        {
            if (!Directory.Exists("bin"))
            {
                StatusStripLabel.Text = "Tools missing.";
                DialogResult downloadTools = MessageBox.Show("webp tools from Google not found. Download?", "Tools not found", MessageBoxButtons.YesNo);

                if(downloadTools == DialogResult.Yes)
                {
                    //Directory.CreateDirectory("bin");
                    StatusStripLabel.Text = "Downloading tools...";
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadProgressChanged += (s, e) => 
                        {
                            StatusStripLabel.Text = $"Downloading tools {e.ProgressPercentage}% {e.BytesReceived}/{e.TotalBytesToReceive} bytes received.";
                        };

                        client.DownloadFileCompleted += (s, e) =>
                        {
                            StatusStripLabel.Text = "Download complete.";
                            /*
                             * This is stupid.
                             * No program should have to do this.
                             * I hope im just a terrible programmer and there is a way around this stupid mess.
                             * This is utterly terrible code.
                             * You have been warned.
                             * I shouldn't be allowed to program.
                             */

                            var readAchrive = ZipFile.OpenRead("tools.zip"); //Zip to var because it doesn't fk close it on its own ffs.
                            string oldFolderName = readAchrive.Entries.First().ToString(); //Get foldername. could all be one line BUT NOOOOO it doesnt fkn auto close
                            readAchrive.Dispose(); //Have to dispose of this shit because IT DOESN'T FKN AUTO CLOSE! File.Delete can't delete because "File in use..." RIP one-liner ;(

                            Status("Extracting zip...");
                            ZipFile.ExtractToDirectory("tools.zip", "./");
                            
                            Status("Done extracting. Renaming folder and deleting download file.");
                            Directory.Move(oldFolderName, "bin");

                            File.Delete("tools.zip");
                            Status("Done.");

                            //string[] inputArray = FilesInputTextbox.Text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries); //Remove empty entries using filter.
                            //string[] outputArray = convertTextbox.Text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            //Convert(inputArray, outputArray);
                        };


                        client.DownloadFileTaskAsync(binToolsVersion, "tools.zip"); //Changed to async to show progress bar

                        /*string oldFolderName = ZipFile.OpenRead("tools.zip").Entries.First().ToString();
                        StatusStripLabel.Text = "Extracting zip...";
                        ZipFile.ExtractToDirectory("tools.zip", "./");
                        StatusStripLabel.Text = "Done extracting. Renaming folder and deleting download file.";
                        Directory.Move(oldFolderName, "bin");
                        File.Delete("tools.zip");
                        StatusStripLabel.Text = "Done.";*/
                    }
                    return false;
                }
                else
                {
                    Status("Can't convert without tools.");
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private void Status(string status) {
            if(StatusStripLabel != null)
                StatusStripLabel.Text = status;
        }

        private void StatusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void StatusStripLabel_Click(object sender, EventArgs e)
        {

        }

        private void DirsInputTextbox_TextChanged(object sender, EventArgs e) {

        }

        private void TrueOutputTextbox_TextChanged(object sender, EventArgs e) {

        }
    }
}
