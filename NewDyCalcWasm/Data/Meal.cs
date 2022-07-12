using System.ComponentModel.DataAnnotations;

namespace NewDyCalcWasm.Data
{
    public class Meal
    {

        public int Id { get; private set; }
        public string NameBox { get; set; }
        public string NameHotMeal { get; set; }

        public Meal(int id, string nameBox, string nameHotMeal)
        {
            Id = id;
            NameBox = nameBox;
            NameHotMeal = nameHotMeal;
        }

        public Meal()
        {
        }


        public int? FirstDayMeals { get; set; }
        public int? SecondDayMeals { get; set; }


        // How many items in one box
        private int HotMealCartonBox = 24;
        private int MealBoxCartonBox = 12;

        // How many items in one plastic box
        private int HotMealPlasticBox = 48;
        private int MealBoxPlasticBox = 18;

        public string CartonHotMeal { get; set; } = string.Empty;
        public string CartonMealBox { get; set; } = string.Empty;
        public string PlasticHotMeal { get; set; } = string.Empty;
        public string PlasticMealBox { get; set; } = string.Empty;

        public void Calculate()
        {

            int firstMeals = FirstDayMeals == null ? 0 : FirstDayMeals.Value;
            int secondMeals = SecondDayMeals == null ? 0 : SecondDayMeals.Value;

            int summedBoxes = firstMeals + secondMeals;
           if(summedBoxes == 0)
            {
                CartonHotMeal = "0";
                CartonMealBox = "0";
                PlasticHotMeal = "0";
                PlasticMealBox = "0";
                return;
            }
            var tempCartonHotMealsCeil = Math.Ceiling(((float)summedBoxes / HotMealCartonBox));
            var tempCartonMealsBoxCeil = Math.Ceiling(((float)summedBoxes / MealBoxCartonBox));

            CartonHotMeal = tempCartonHotMealsCeil.ToString("0.##");

            CartonMealBox = tempCartonMealsBoxCeil.ToString("0.##");

                PlasticHotMeal = ((float)tempCartonHotMealsCeil * 24 / HotMealPlasticBox).ToString("0.##");

                PlasticMealBox = ((float)tempCartonMealsBoxCeil * 12 / MealBoxPlasticBox).ToString("0.##");
        }


    }

}
