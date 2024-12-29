// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;
var DisplyIngredient = new DisplyIngredientsList();

DisplyIngredient.displayHeader();
//Console.WriteLine(DisplyIngredient.ingredientsList());


    //DisplyIngredient.displayInputMassage();
IngredientsList ingredientsList = new IngredientsList();


Console.WriteLine();




Console.WriteLine();

Console.ReadLine();

public enum IngredientsList
{

    WheatFlour = 1,
    CoconetFlour,
}
class DisplyIngredientsList
{
    public string ids;
    public int Id { get; set; }

    public void displayHeader() => Console.WriteLine("Create a new cookies recipe! Available ingredients are :");

    public string ingredientsList() => @"1. Wheat Flour
2. Coconet Flour
3. ";

    public void displayInputMassage()
    {
    }
}
