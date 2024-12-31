valueList valu = new valueList();
WriteFile writeFile = new WriteFile();
ReadFile readFile = new ReadFile();
DisplayIngredient displayIngredient = new DisplayIngredient();

string path = "C:\\Users\\Max\\Downloads\\abc.txt";
int x = 0;
int name;
Console.WriteLine("Exsisting File\n");
readFile.fileRead(path);
Console.WriteLine("\n");

displayIngredient.ShowIngredient();




while (x < 3)
{

    Console.WriteLine("Add Ingredient by it's Id or type 0' to if finished :");
    name = int.Parse(Console.ReadLine());

    writeFile.add(name);
    x++;
}

Console.WriteLine("\n\n\nAll Details");

displayIngredient.abc(valu.Details);

writeFile.fileWrite(path);

Console.WriteLine("save sussusfully");

Console.ReadLine();


public class DisplayIngredient
{
    public int EnumSelectedValue { get; set; }
    public void ShowIngredient()
    {
        Console.WriteLine("Create a new cookies recipe! Available ingredients are :");
        string IngredientList = @"1.WheatFlour
2.CoconatFlour";
        Console.WriteLine(IngredientList);
    }

    public void abc(List<int> select)
    {
           var enumValue = IngredientList.GetValues(typeof(IngredientList)).Cast<IngredientList>;
        foreach (var Enumvalues in enumValue)
        {
         Console.WriteLine(Enumvalues);
        }
    }
    public enum IngredientList
    {
        WheatFlour = 1,
        CoconatFlour
    }
}


public class valueList()
{


    public List<int> Details = new List<int>();
    
    public void ShowAllListDate()
    {
        foreach (int item in Details)
        {
           
            Console.WriteLine(item);
        }
    }
  
}

public class WriteFile : valueList
{ 
    public void add(int add) => Details.Add(add);
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