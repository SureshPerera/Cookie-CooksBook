﻿
namespace Cookie_CooksBook.Recipes;

public abstract class Ingredient
{
    public abstract int Id { get; }
    public abstract string Name { get; }
    public virtual string PreparationInstruction => 
        "Add to other ingredient";
}
