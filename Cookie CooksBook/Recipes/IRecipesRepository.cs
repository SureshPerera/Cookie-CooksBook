namespace Cookie_CooksBook.Recipes
{
    public partial class Recipes
    {
        public interface IRecipesRepository
        {
            List<Recipes> Read(string filePath);
            void Write(string filePath, List<Recipes> allRecipes);
        }
    }
}
