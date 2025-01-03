namespace Cookie_CooksBook.Recipes.Ingredients
{
    public abstract class mon : Ingredient
    {
        public override string PreparationInstruction =>
            $"Take half a teaspon. {base.PreparationInstruction}";
    }
}
