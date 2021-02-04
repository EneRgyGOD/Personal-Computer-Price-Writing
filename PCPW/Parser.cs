using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Text;
using System.Threading.Tasks;

namespace PCPW
{
    class Parser
    {
        public async Task<Data> ParserAsync()
        {
            Data data = new Data();

            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://ek.ua/ul_/fswtud0jhz1/zakladki/";
            var document = await BrowsingContext.New(config).OpenAsync(address);
            var contentPrice = document.QuerySelectorAll("td.model-hot-prices-td [id^=price], [class$=ib] span:first-child");
            var contentName = document.QuerySelectorAll("td.model-short-info table span.u");

            for (int i = 0; i < contentName.Length && i < contentPrice.Length; i++)
            {
                string check = contentPrice[i].Text();
                string result = null;

                for (int z = 0; !check[1].IsDigit() && z < check.Length; z++)
                {
                    if (z != 1)
                    {
                        result += check[z];
                    }
                }
                if (check[1].IsDigit())
                {
                    result = check;
                }

                data.Price.Add(int.Parse(result));
                data.Name.Add(contentName[i].Text());

            }
            return data;
        }
    }
}
