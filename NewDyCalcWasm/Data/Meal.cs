using System.ComponentModel.DataAnnotations;

namespace NewDyCalcWasm.Data;

public class Meal : MealInfo
{

    public float? FirstDayMealQuantity { get; set; }
    public float? SecondDayMealQuantity { get; set; }
    public float MealsPick { get; set; }

    // Shows how manny mealbox needs to be picked
    public float BoxMealsCartonBoxPick { get; set; }
    public float BoxMealsPlasticBoxPick { get; set; }

    // Shows how manny hotmeals needs to be picked
    public float HotMealsCartonBoxPick { get; set; }
    public float HotMealsPlasticBoxPick { get; set; }
    public bool PercentAdded { get; set; } = false;

    public void Calculate()
    {
        // calculation of the amount of plastic cases and carton boxes

        MealsPick = (FirstDayMealQuantity.HasValue ? FirstDayMealQuantity.Value : 0) +
                                    (SecondDayMealQuantity.HasValue ? SecondDayMealQuantity.Value : 0);

        BoxMealsCartonBoxPick = (float)MealsPick / (BoxPiecesPerCartonBox.HasValue ? BoxPiecesPerCartonBox.Value : 0);
        BoxMealsPlasticBoxPick = (float)MealsPick / (BoxPiecesPerPlasticCase.HasValue ? BoxPiecesPerPlasticCase.Value : 0);

        HotMealsCartonBoxPick = (float)MealsPick / (HotMealPiecesPerCartonBox.HasValue ? HotMealPiecesPerCartonBox.Value : 0);
        HotMealsPlasticBoxPick = (float)MealsPick / (HotMealPiecesPerPlasticCase.HasValue ? HotMealPiecesPerPlasticCase.Value : 0);
    }

}





