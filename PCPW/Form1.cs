using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PCPW
{
    public partial class Form1 : Form
    {
        Data dataIn = new Data();
        ConfigIO config = new ConfigIO();
        RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        DateTime data = DateTime.Now.AddMilliseconds(-Environment.TickCount);
        bool bootState;
        string cfgPath = @"C:\Users\Public\Documents\config.txt";
        public Form1()
        {
            InitializeComponent();
            if (DateTime.Now.Ticks - data.Ticks < 120) this.Hide();

            if (File.Exists(cfgPath))
            {
                dataIn = config.Read(cfgPath);
                status.Text = "Config Loaded!";
            }
        }
        async public void btnPull_Click(object sender, EventArgs e)
        {
            dataIn.Url = TxtBoxUrl.Text;
            if (File.Exists(cfgPath))
            {
                dataIn = config.Read(cfgPath);
                status.Text = "Loading cfg";
                TxtBoxUrl.Text = dataIn.Url;
            }
            else if (dataIn.Url == "")
            {
                status.Text = "Enter Url";
                return;
            }
            else if (dataIn.Path == null)
            {
                status.Text = "Choose folder for csv file";
                return;
            }
            else
            {
                config.Write(cfgPath, dataIn.Url, dataIn.Path);
            }

            status.Text = "loading page";

            Parser Parser = new Parser();
            dataIn = await Parser.ParserAsync(dataIn.Url, dataIn.Path);

            status.Text = "OK";
            status.Text = "Checking File";

            string input = File.ReadAllText(dataIn.Path);
            DateTime date = DateTime.Now;
            var csv = new StringBuilder();

            if (!input.Contains(date.Day + "." + date.Month + "." + date.Year + ";"))
            {
                status.Text = "Writing data";
                double x = 0;
                string bigstring = "";

                for (int i = 0; i < dataIn.Price.Count; i++)
                {
                    bigstring += $"{dataIn.Price[i]};";
                    x += dataIn.Price[i];
                }

                bigstring += $"{x};";
                var newLine = string.Format(date.Day + "." + date.Month + "." + date.Year + ";" + bigstring);
                csv.Append(newLine);

                csv.AppendLine();
                File.AppendAllText(dataIn.Path, csv.ToString());

                status.Text = "SUCCESS";
            }
            else
            {
                status.Text = "ALREDY DONE!";
            }
            if (DateTime.Now.Ticks - data.Ticks < 120) this.Close();

        }
        private void btnPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                dataIn.Path = folderBrowserDialog1.SelectedPath + "\\PriceData.csv";
            }
        }

        private void btnBoot_Click(object sender, EventArgs e)
        {
            if (bootState)
            {
                reg.DeleteValue("PCPW");
                btnBoot.Text = "Boot with Windows";
            }
            else
            {
                reg.SetValue("PCPW", Application.ExecutablePath);
                btnBoot.Text = "Disable Boot";
            }
        }
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            if (File.Exists(dataIn.Path)) System.Diagnostics.Process.Start("notepad.exe", dataIn.Path);
            else status.Text = "csv missing";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnPull.PerformClick();
            if (reg.GetValue("PCPW") != null)
            {
                btnBoot.Text = "Disable Boot";
                bootState = true;
            }
            else bootState = false;
        }
    }
}
