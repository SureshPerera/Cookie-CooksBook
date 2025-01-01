
namespace Cookie_CooksBook.Recipes;

public abstract class Flour : Ingredient
{
    public override string PreparationInstruction => $"Sieve.{base.PreparationInstruction} ";
}
