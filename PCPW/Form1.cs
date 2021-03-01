using Microsoft.Win32;
using System;
using System.Diagnostics;
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
        bool bootState, silent;
        const string configPath = @"C:\Users\Public\Documents\config.json";
        string[] arguments = Environment.GetCommandLineArgs();

        public Form1()
        {
            InitializeComponent();
            dataIn.CfgPath = configPath;
            if (arguments.Length > 1 && arguments[1] == "--silent") silent = true;
            if (silent) _Hide();
        }

        async private void Pull()
        {
            status.Text = "loading page";

            Parser Parser = new Parser();
            dataIn = await Parser.ParserAsync(dataIn);

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
            if (silent) this.Close();
        }

        public void btnPull_Click(object sender, EventArgs e)
        {
            if (cfgCheck()) Pull();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                dataIn.Path = folderBrowserDialog1.SelectedPath + "\\PriceData.csv";
            }
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            if (File.Exists(dataIn.Path)) System.Diagnostics.Process.Start("notepad.exe", dataIn.Path);
            else status.Text = "csv missing";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (cfgCheck()) Pull();
            if (reg.GetValue("PCPW") != null)
            {
                checkBoxBoot.Checked = true;
                bootState = true;
            }
            else bootState = false;
        }

        private bool cfgCheck()
        {
            if (dataIn.Url != TxtBoxUrl.Text && TxtBoxUrl.Text != "") config.Write(dataIn);
            if (File.Exists(dataIn.CfgPath))
            {
                dataIn = config.Read(dataIn);
                status.Text = "Loading cfg";
                TxtBoxUrl.Text = dataIn.Url;
                status.Text = "cfg loaded";
                return true;
            }
            else if (dataIn.Url == "")
            {
                status.Text = "Enter Url";
                return false;
            }
            else if (dataIn.Path == null)
            {
                status.Text = "Choose folder for csv file";
                return false;
            }
            else
            {
                config.Write(dataIn);
                status.Text = "cfg saved";
                return true;
            }
        }

        private void BootOnStartup()
        {
            if (bootState)
            {
                reg.DeleteValue("PCPW");
                checkBoxBoot.Checked = false;
                bootState = false;
            }
            else
            {
                reg.SetValue("PCPW", Application.ExecutablePath + " --silent");
                checkBoxBoot.Checked = true;
                bootState = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            BootOnStartup();
        }

        private void _Hide() 
        {
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }
    }
}
