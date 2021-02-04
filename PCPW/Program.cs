using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PCPW
{
    class Program
    {
        static void Main()
        {
          MainProcess().GetAwaiter().GetResult();
        }
        static async Task MainProcess()
        {
            Data dataOut = new Data();
            Parser Parser = new Parser();
           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PROGRAM PCPW HAS BEEN STARTED");
            Console.ResetColor();

            string path = @"D:\MeMo\doc\PriceData.csv";
            var csv = new StringBuilder();

            DateTime date = new DateTime();
            date = DateTime.Now;

            string input = File.ReadAllText(path);

            if (!input.Contains(date.Day + "." + date.Month + "." + date.Year + ";"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n!!!pls wait few seconds!!!");
                Console.ResetColor();
                dataOut = await Parser.ParserAsync();
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

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSUCCESS");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nYou already did it today...");
            }
            Console.WriteLine("\nPress any button to exit");
            Console.ReadKey();

            return;
        }
    }
}
