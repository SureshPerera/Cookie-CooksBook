namespace Cookie_CooksBook.Recipes.Ingredients
{
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
}
