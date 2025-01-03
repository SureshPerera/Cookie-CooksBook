using Cookie_CooksBook.Recipes;
using Cookie_CooksBook.Recipes.Ingredients;
using System.IO;
//using static DisplayIngredient;


var ingredientRegister = new IngredientRegister(); 
var cookiesRecepiesApp = new CookiesRecepiesApp(
    new RecipesRepository(
        new StringTextualRepository(),
        ingredientRegister), 
    new RecipesConsoleUserInterraction(
        ingredientRegister));

cookiesRecepiesApp.Run("recipes.txt");


public class CookiesRecepiesApp
{
    private readonly IRecipesRepository _recipesRepository ;
    private readonly IRecipesUserInterraction _recipesUserInterraction;
       

    public CookiesRecepiesApp(IRecipesRepository recipesRepository,
        IRecipesUserInterraction recipesConsoleUserInterraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInterraction = recipesConsoleUserInterraction;
    }
    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInterraction.PrintExcistingRecipes(allRecipes);

        _recipesUserInterraction.PromptToCreateRecipes();

        var ingredients = _recipesUserInterraction.ReadIngredientFromUser();

        if (ingredients.Count() > 0)
        {
            var recipes = new Recipes(ingredients);
            allRecipes.Add(recipes);
            _recipesRepository.Write(filePath, allRecipes);

            _recipesUserInterraction.ShowMessage(
                "Recipes Added :");
            _recipesUserInterraction.ShowMessage(recipes.ToString());
        }
        else
        {
            _recipesUserInterraction.ShowMessage(
                "No Ingredient have been selected" +
                "Recipe will not be saved");
        }

        _recipesUserInterraction.Exit();
    }
}

public interface IRecipesRepository
{
    List<Recipes> Read(string filePath);
    void Write(string filePath, List<Recipes> allRecipes);
}
public interface IRecipesUserInterraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExcistingRecipes(IEnumerable<Recipes> allRecipes);
    void PromptToCreateRecipes();
    IEnumerable<Ingredient> ReadIngredientFromUser();
}
public class RecipesConsoleUserInterraction : IRecipesUserInterraction
{
    public readonly IIngredientRegister _ingredientRegister ;

    public RecipesConsoleUserInterraction(IIngredientRegister ingredientRegister)
    {
        _ingredientRegister = ingredientRegister;
    }

    public  void Exit()
    {
        Console.WriteLine("Press Any Key To Exit.");
        Console.ReadKey();
    }

    public void PromptToCreateRecipes()
    {
        Console.WriteLine("Create a new cookies recipes!" +
            "Available ingredients are :");
        foreach (var ingredient in _ingredientRegister.All)
        {
            Console.WriteLine($"{ingredient.Id}.{ingredient.Name}");
        }
    }
    public void PrintExcistingRecipes(IEnumerable<Recipes> allRecipes)
    {
        if(allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are : " + Environment.NewLine);

            int number = 1;
            foreach(var recipt in allRecipes)
            {
                Console.WriteLine($"****{number}****");
                Console.WriteLine(recipt);
                Console.WriteLine();
                ++number;
            }
        }
    }


    public  void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public IEnumerable<Ingredient> ReadIngredientFromUser()
    {
        bool shallStop = false;
        var ingredient = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine("Add an ingredient by Id," +
                "or type anything else if finished");
            var usrInput = Console.ReadLine();
            if(int.TryParse(usrInput,out int id))
            {
                var selectedIngredient = _ingredientRegister.GetById(id);
                if(selectedIngredient is not null)
                {
                    ingredient.Add(selectedIngredient);

                }
            }
            else
            {
                shallStop = true;
            }
        }

        return ingredient;
    
    }
}

public interface IIngredientRegister
{
    IEnumerable<Ingredient> All { get; }

    Ingredient GetById(int id);
}

public class IngredientRegister : IIngredientRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocalate(),
        new Suger(),
        new Cardamon(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id)
            {
                return ingredient;
            }

        }
        return null;
    }
}

public class RecipesRepository : IRecipesRepository
{
    private readonly IIngredientRegister _ingredientRegister;
    private readonly IStringRepository _stringRepository;
    public RecipesRepository(IStringRepository stringRepository,
        IIngredientRegister ingredientRegister)
    {
        _stringRepository = stringRepository;
        _ingredientRegister = ingredientRegister;
    }
    public List<Recipes> Read(string filePath)
    {
        List<string> recipesFromFile = _stringRepository.Read(filePath);
        var recipes = new List<Recipes>();

        foreach(var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipesFromString(recipeFromFile);
            recipes.Add(recipe);
        }
        return recipes;
    }

    private Recipes RecipesFromString(string recipeFromFile)
    {
        var textualId = recipeFromFile.Split(",");
        var ingredient = new List<Ingredient>();
        foreach(var textualIds in textualId)
        {
            var id = int.Parse(textualIds);
            var ingredients = _ingredientRegister.GetById(id);
            ingredient.Add(ingredients);
        }
        return new Recipes(ingredient);
    }

    public void Write(string filePath, List<Recipes> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach(var recipes in allRecipes)
        {
            var allIds = new List<int>();
            foreach(var ingredient in recipes.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsStrings.Add(string.Join(",", allIds));
        }
        _stringRepository.Write(filePath, recipesAsStrings);
    }
}

public interface IStringRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}

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
        
    }
}

