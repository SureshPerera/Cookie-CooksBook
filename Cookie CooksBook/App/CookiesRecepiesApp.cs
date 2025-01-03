using static Cookie_CooksBook.Recipes.Recipes;

namespace Cookie_CooksBook.App
{
    public class CookiesRecepiesApp
    {
        private readonly IRecipesRepository _recipesRepository;
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
}
