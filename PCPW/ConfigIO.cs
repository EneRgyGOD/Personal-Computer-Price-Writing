using Newtonsoft.Json;
using System.IO;

namespace PCPW
{
    class ConfigIO
    {
        public Data Read(Data data)
        {
            data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(data.CfgPath));
            return data;
        }
        public void Write(Data data)
        {
            data.Name.Clear();
            data.Price.Clear();
            if (File.Exists(data.CfgPath)) File.WriteAllText(data.CfgPath, "");
            File.WriteAllText(data.CfgPath, JsonConvert.SerializeObject(data));
        }
    }
}
