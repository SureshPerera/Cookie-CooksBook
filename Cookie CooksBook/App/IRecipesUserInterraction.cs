
using Cookie_CooksBook.Recipes.Ingredients;

namespace Cookie_CooksBook.App
{
    public interface IRecipesUserInterraction
    {
        void ShowMessage(string message);
        void Exit();
        void PrintExcistingRecipes(IEnumerable<Recipes> allRecipes);
        void PromptToCreateRecipes();
        IEnumerable<Ingredient> ReadIngredientFromUser();
    }
}
