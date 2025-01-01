
namespace Cookie_CooksBook.Recipes;

public class recipes
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public recipes(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }
}
