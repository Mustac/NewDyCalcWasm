using System.ComponentModel.DataAnnotations;

namespace NewDyCalcWasm.Data
{
    public class Meal
    {

        public int Id { get; private set; }

        public Meal(int id)
        {
            Id = id;
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
                return;
            }
               // PlasticHotMeal = ((float)summedBoxes / HotMealPlasticBox).ToString("#.##");

              //  PlasticMealBox = ((float)summedBoxes / MealBoxPlasticBox).ToString("#.##");

                CartonHotMeal = ((float)summedBoxes / HotMealCartonBox).ToString("#.##");

                CartonMealBox = ((float)summedBoxes / MealBoxCartonBox).ToString("#.##");
            
        }


    }

}
