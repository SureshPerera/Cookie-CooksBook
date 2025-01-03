namespace Cookie_CooksBook.Data_Access
{
    public class StringTextualRepository : IStringRepository
    {
        private static readonly string Seperator = Environment.NewLine;

        public List<string> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContent = File.ReadAllText(filePath);
                return fileContent.Split(Seperator).ToList();

            }
            return new List<string>();
        }
        public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, string.Join(Seperator, strings));
        }
    }

}
