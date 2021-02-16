using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCPW
{
    public partial class Form1 : Form
    {
        Data dataOut = new Data();
        public Form1()
        {
            InitializeComponent();
            MainProcess().GetAwaiter().GetResult();
        }
        async Task MainProcess()
        {
            status.Text = "loading page";
            Parser Parser = new Parser();
            dataOut = await Parser.ParserAsync(TxtBoxUrl.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = @"D:\MeMo\doc\PriceData.csv";
            string input = File.ReadAllText(path);
            DateTime date = new DateTime();
            date = DateTime.Now;
            var csv = new StringBuilder();

            if (!input.Contains(date.Day + "." + date.Month + "." + date.Year + ";"))
            {
                double x = 0;
                string bigstring = "";
                for (int i = 0; i < dataOut.Price.Count; i++)
                {
                    bigstring += $"{dataOut.Price[i]};";
                    x += dataOut.Price[i];
                }
                bigstring += $"{x};";
                var newLine = string.Format(date.Day + "." + date.Month + "." + date.Year + ";" + bigstring);
                csv.Append(newLine);

                csv.AppendLine();
                File.AppendAllText(path, csv.ToString());

                status.Text = "SUCCESS";
            }
            else
            {
                status.Text = "ALREDY DONE!";
            }
        }
    }
}
