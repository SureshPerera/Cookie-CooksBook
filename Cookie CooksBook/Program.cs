using static DisplayIngredient;

valueList valu = new valueList();
WriteFile writeFile = new WriteFile();
ReadFile readFile = new ReadFile();
DisplayIngredient displayIngredient = new DisplayIngredient();
DocumentReader documentReader = new DocumentReader();

string path = "C:\\Users\\Max\\Downloads\\abc.txt";
int x ;
bool y = true;
string name;
var Contents = File.ReadAllText(path);
Console.WriteLine("Exsisting File\n");
readFile.fileRead(path);



Console.WriteLine("\n");

displayIngredient.ShowIngredient();




while (y)
{

    Console.WriteLine("Add Ingredient by it's Id or type 0' to if finished :");
    name = Console.ReadLine();
    if(int.TryParse(name, out int index))
    {
        if (index < 0)
        {
            Console.WriteLine("Try again..");
            break;
        }
        else if (index > 8)
        {
            
            Console.WriteLine("try again");
            break;
        }
        else if (index == 0)
        {
            y = false;
            Console.WriteLine("\n\n\nAll Details");

           
            break;
            

        }
        else
        {
            writeFile.add(index);
            x = index;
        }
    }
}


writeFile.fileWrite(path);

valu.ShowAllListDate();

Console.ReadLine();


public class DisplayIngredient
{
    public int EnumSelectedValue { get; set; }
    public void ShowIngredient()
    {
        Console.WriteLine("Create a new cookies recipe! Available ingredients are :");
        string IngredientList = @"1.WheatFlour
2.CoconatFlour
3.Butter
4.Chocolate
5.Sugar
6.Cardamom
7.Cinnamon
8.Cocoa powder";
        Console.WriteLine("\n"+ IngredientList+ "\n");
    }

    public enum IngredientList
    {
        WheatFlour = 1,
        CoconatFlour,
        Butter,
        Chocolate,
        Sugar,
        Cardamom,
        Cinnamon,
        Cocoapowder
    }
}


public class valueList()
{


    public List<int> Details = new List<int>();
    
    public void ShowAllListDate()
    {
        Console.WriteLine();
        Console.WriteLine("Recipe added:");
        foreach (var item in Details)
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
        if(Details.Count == 0)
        {
            Console.WriteLine("Details is null..");

        }
        else
        {
           
            File.WriteAllText(path, string.Join(Environment.NewLine, Details));
            Console.WriteLine("save sussusfully");
        }
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

public class DocumentReader
{
    ReadFile readFile = new ReadFile();
    public void showFileReader(string path)
    {
       
       
    }
}