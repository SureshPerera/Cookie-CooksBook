valueList valu = new valueList();
WriteFile writeFile = new WriteFile();
ReadFile readFile = new ReadFile();

string path = "C:\\Users\\Max\\Downloads\\abc.txt";
int x = 0;
string name;
Console.WriteLine("Exsisting File\n");
readFile.fileRead(path);
Console.WriteLine("\n");
while (x < 3)
{

    Console.WriteLine("Enter name :");
    name = Console.ReadLine();

    writeFile.add(name);
    x++;
}

Console.WriteLine("\n\n\nAll Details");

valu.ShowAllListDate();

writeFile.fileWrite(path);

Console.WriteLine("save sussusfully");

Console.ReadLine();

public class valueList()
{


    public List<string> Details = new List<string>();
    
    public void ShowAllListDate()
    {
        foreach (string item in Details)
        {
           
            Console.WriteLine(item);
        }
    }
  
}

public class WriteFile : valueList
{ 
    public void add(string add) => Details.Add(add);
    valueList valueList = new valueList();
    public void fileWrite(string path)
    {
        File.WriteAllText(path, string.Join(Environment.NewLine, Details));
    }
}

public class ReadFile : valueList
{
    public void fileRead(string path)
    {
        var Content = File.ReadAllText(path);
        var nameFromFile = Content.Split(Environment.NewLine);
        foreach (var name in nameFromFile)
        {
            Console.WriteLine(name);
        }
    }
}