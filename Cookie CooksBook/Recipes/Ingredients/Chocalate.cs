namespace Cookie_CooksBook.Recipes.Ingredients
{
    public class Chocalate : Ingredient
    {
        public override int Id => 4;
        public override string Name => "Chocalate";

        public override string PreparationInstruction =>
            $"Melt in water bath. {base.PreparationInstruction}";
    }
}
