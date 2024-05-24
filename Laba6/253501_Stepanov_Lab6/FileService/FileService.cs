using _253501_Stepanov_Lab6;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace FileService
{
    public class FileService<T>: IFileService<T>//<Computer>
    {
        public IEnumerable<Computer> ReadFile(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                var computers = JsonConvert.DeserializeObject<List<Computer>>(json);
                return computers;
            }
        }
        public void SaveData(IEnumerable<Computer> data, string fileName)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }
}
