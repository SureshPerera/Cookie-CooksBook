namespace Cookie_CooksBook.Data_Access
{
    public interface IStringRepository
    {
        List<string> Read(string filePath);
        void Write(string filePath, List<string> strings);
    }

}
