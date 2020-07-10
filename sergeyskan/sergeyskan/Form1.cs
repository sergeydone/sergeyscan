using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace sergeyskan
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            cancel.Enabled = false;
        }

        List<string> ResultList = new List<string>();
        string temp = "";

        private string[,] LoadCsv(string filename)
        {
            
                // get file text:
                string whole_file = System.IO.File.ReadAllText(filename);

            // split into lines:
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
            StringSplitOptions.RemoveEmptyEntries);

            // calc rows and columns
            int num_rows = lines.Length;
            int num_cols = lines[0].Split(';').Length;

            // Allocate data array
            string[,] values = new string[num_rows, num_cols];

            // load array
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(';');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }
            return values;
        }


        public void tryToScanNow(string adr, Int32 port)
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(adr, port);
                    temp = "" + adr + ";" + port + ";open";
                    ResultList.Add(temp);
                }
                catch(Exception)
                {
                    temp = "" + adr + ";" + port +";closed";
                    ResultList.Add(temp);
                }
            }
        }


        private void saveResults()
        {
            string path = "result.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Test results:");
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (var result in ResultList)
                {
                    sw.WriteLine("" + result);
                }
            }
        
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (!File.Exists("sample.csv"))
            {
                legend.ForeColor = System.Drawing.Color.Red;
                legend.Text = "Sorry. File sample.csv  not found. Execution stopped ";
            }
            else
            {
                legend.ForeColor = System.Drawing.Color.Green;
                legend.Text = "Execution has started";
                if (backgroundWorker1.IsBusy != true)
                {
                    start.Enabled = false;
                    cancel.Enabled = true;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            cancel.Enabled = false;
            legend.ForeColor = System.Drawing.Color.Red;
            legend.Text = "Execution is stopping. Wait a minute";
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string[,] TestArray = LoadCsv("sample.csv");
            for (int j = 0; j < TestArray.GetLength(0); j++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    tryToScanNow(TestArray[j, 0], Convert.ToInt32(TestArray[j, 1]));
                    worker.ReportProgress((j + 1) * 100 / TestArray.GetLength(0));
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            start.Enabled = true;
            cancel.Enabled = false;
            if (e.Cancelled == true)
            {
                legend.ForeColor = System.Drawing.Color.Green;
                legend.Text = "Execution stopped. Result saved in result.txt";
                saveResults();
                status.Value = 0;
            }
            else if (e.Error != null)
            {
                legend.ForeColor = System.Drawing.Color.Red;
                legend.Text = "Error" + e.Error.Message + ". File sample.csv incorrect";
            }
            else
            {
                legend.ForeColor = System.Drawing.Color.Green;
                saveResults();
                legend.Text = "Execution finished. Result in file result.txt";
                status.Value = 0;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            legend.Text = (e.ProgressPercentage.ToString() + "%");
            status.Value = (e.ProgressPercentage);
        }
    }


}
