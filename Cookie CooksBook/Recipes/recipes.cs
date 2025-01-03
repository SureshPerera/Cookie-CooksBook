using Cookie_CooksBook.Recipes.Ingredients;

namespace Cookie_CooksBook.Recipes
{
    public partial class Recipes
    {
        public IEnumerable<Ingredient> Ingredients { get; }

        public Recipes(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }
        public override string ToString()
        {
            var steps = new List<string>();
            foreach (var ingredient in Ingredients)
            {
                steps.Add($"{ingredient.Name}.{ingredient.PreparationInstruction}");
            }
            return string.Join(Environment.NewLine, steps);
        }
    }
}
