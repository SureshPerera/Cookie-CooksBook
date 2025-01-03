

using System.Text.Json;

namespace Cookie_CooksBook.Data_Access
{
    public class StringJsonRepository : IStringRepository
    {


        public List<string> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContent = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<string>>(fileContent);

            }
            return new List<string>();
        }
        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(strings));
        }
    }

}
