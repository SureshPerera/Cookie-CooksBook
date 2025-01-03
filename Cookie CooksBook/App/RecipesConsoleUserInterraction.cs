
using Cookie_CooksBook.Recipes.Ingredients;

namespace Cookie_CooksBook.App
{
    public class RecipesConsoleUserInterraction : IRecipesUserInterraction
    {
        public readonly IIngredientRegister _ingredientRegister;

        public RecipesConsoleUserInterraction(IIngredientRegister ingredientRegister)
        {
            _ingredientRegister = ingredientRegister;
        }

        public void Exit()
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
            if (allRecipes.Count() > 0)
            {
                Console.WriteLine("Existing recipes are : " + Environment.NewLine);

                int number = 1;
                foreach (var recipt in allRecipes)
                {
                    Console.WriteLine($"****{number}****");
                    Console.WriteLine(recipt);
                    Console.WriteLine();
                    ++number;
                }
            }
        }


        public void ShowMessage(string message)
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
                if (int.TryParse(usrInput, out int id))
                {
                    var selectedIngredient = _ingredientRegister.GetById(id);
                    if (selectedIngredient is not null)
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
}
