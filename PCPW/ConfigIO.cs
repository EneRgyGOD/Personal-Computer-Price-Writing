using System.IO;

namespace PCPW
{
    class ConfigIO
    {
        Data data = new Data();
        public Data Read(string cfgPath)
        {
            string[] input;
            input = File.ReadAllLines(cfgPath);

            data.Url = input[0];
            data.Path = input[1];

            return data;
        }
        public void Write(string cfgPath, string Url, string path)
        {
            if (File.Exists(cfgPath)) File.Delete(cfgPath);
            File.WriteAllText(cfgPath, Url + "\n" + path);
        }
    }
}
