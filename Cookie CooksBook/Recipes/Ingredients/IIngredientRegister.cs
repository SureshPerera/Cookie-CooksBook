namespace Cookie_CooksBook.Recipes.Ingredients
{
    public interface IIngredientRegister
    {
        IEnumerable<Ingredient> All { get; }

        Ingredient GetById(int id);
    }
}
