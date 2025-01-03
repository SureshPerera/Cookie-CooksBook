using Cookie_CooksBook.Data_Access;
using Cookie_CooksBook.Recipes.Ingredients;

namespace Cookie_CooksBook.Recipes
{
    public partial class Recipes
    {
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

                foreach (var recipeFromFile in recipesFromFile)
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
                foreach (var textualIds in textualId)
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
                foreach (var recipes in allRecipes)
                {
                    var allIds = new List<int>();
                    foreach (var ingredient in recipes.Ingredients)
                    {
                        allIds.Add(ingredient.Id);
                    }
                    recipesAsStrings.Add(string.Join(",", allIds));
                }
                _stringRepository.Write(filePath, recipesAsStrings);
            }
        }
    }
}
