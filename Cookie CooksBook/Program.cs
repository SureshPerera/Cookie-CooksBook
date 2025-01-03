using Cookie_CooksBook.App;
using Cookie_CooksBook.Data_Access;
using Cookie_CooksBook.Recipes;
using Cookie_CooksBook.Recipes.Ingredients;
using System.IO;
using System.Text.Json;
using static Cookie_CooksBook.Recipes.Recipes;
//using static DisplayIngredient;


var ingredientRegister = new IngredientRegister(); 
var cookiesRecepiesApp = new CookiesRecepiesApp(
    new RecipesRepository(
        new StringJsonRepository(),
        //new StringTextualRepository(),
        ingredientRegister), 
    new RecipesConsoleUserInterraction(
        ingredientRegister));

cookiesRecepiesApp.Run("recipes.json");











