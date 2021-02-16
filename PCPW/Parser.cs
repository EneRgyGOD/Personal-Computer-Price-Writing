using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Text;
using System;
using System.Threading.Tasks;

namespace PCPW
{
    class Parser
    {
        public async Task<Data> ParserAsync(string address, string Path)
        {
            Data data = new Data();

            var config = Configuration.Default.WithDefaultLoader();

            var document = await BrowsingContext.New(config).OpenAsync(address);
            var contentPrice = document.QuerySelectorAll("td.model-hot-prices-td [id^=price], [class$=ib] span:first-child");
            var contentName = document.QuerySelectorAll("td.model-short-info table span.u");

            for (int i = 0; i < contentName.Length && i < contentPrice.Length; i++)
            {
                string check = contentPrice[i].Text();
                string result = null;

                for (int z = 0; z < check.Length; z++)
                {
                    if (check[z].IsDigit())
                    {
                        result += check[z];
                    }
                }
                Console.WriteLine($"Added: {contentName[i].Text()}  {result}");

                data.Price.Add(int.Parse(result));
                data.Name.Add(Convert.ToString(contentName[i].Text()));
                

            }
            data.Path = Path;
            data.Url = address;
            return data;
        }
    }
}
