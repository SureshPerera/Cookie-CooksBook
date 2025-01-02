using Cookie_CooksBook.Recipes;
using Cookie_CooksBook.Recipes.Ingredients;
using System.IO;
//using static DisplayIngredient;



var cookiesRecepiesApp = new CookiesRecepiesApp(
    new RecipesRepository(), 
    new RecipesConsoleUserInterraction());

cookiesRecepiesApp.Run("recipes.txt");


public class CookiesRecepiesApp
{
    private readonly IRecipesRepository _recipesRepository ;
    private readonly IRecipesUserInterraction _recipesUserInterraction = 
        new RecipesConsoleUserInterraction();

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
    public readonly IngredientRegister _ingredientRegister = new ();

 
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

public class IngredientRegister
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
            if(ingredient.Id == id)
            {
                return ingredient;
            }
           
        }
        return null;
    }
}

public class RecipesRepository : IRecipesRepository
{
    public List<Recipes> Read(string filePath)
    {
        return new List<Recipes>
        {
            new Recipes(new List<Ingredient>
            {
                new WheatFlour(),
                new Butter()
            }),
            new Recipes(new List<Ingredient>
            {
                new Butter(),
                new WheatFlour(),
            }),
        };
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

