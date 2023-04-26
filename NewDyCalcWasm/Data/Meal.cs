using System.ComponentModel.DataAnnotations;

namespace NewDyCalcWasm.Data
{
    public class Meal
    {

        public int Id { get; private set; }
        public string NameBox { get; set; }
        public string NameHotMeal { get; set; }
        public string ColorClass { get; private set; }

        public Meal(int id, string nameBox, string nameHotMeal, int HotMealCartonBox = 24, int MealBoxCartonBox = 12, string colorClass = "")
        {
            Id = id;
            NameBox = nameBox;
            NameHotMeal = nameHotMeal;
            this.HotMealInCartonBox = HotMealCartonBox;
            this.MealBoxInCartonBox = MealBoxCartonBox;
            ColorClass = colorClass;
        }

        public Meal()
        {
        }


        public int? FirstDayMeals { get; set; }
        public int? SecondDayMeals { get; set; }
        public int SumOfMeals { get; set; }


        // How many items in one box
        private int HotMealInCartonBox = 24;
        private int MealBoxInCartonBox = 12;

        // How many items in one plastic box
        // private int HotMealPlasticBox = 48;
        // private int MealBoxPlasticBox = 18;

        public int CartonHotMeal { get; set; } 
        public int LeftoverHotMeal { get; set; }
        public int CartonMealBox { get; set; }
        public int LeftoverMealBox { get; set; }


        public void Calculate()
        {

            int firstMeals = FirstDayMeals == null ? 0 : FirstDayMeals.Value;
            int secondMeals = SecondDayMeals == null ? 0 : SecondDayMeals.Value;

            SumOfMeals = firstMeals + secondMeals;

            //if(SumOfMeals == 0)
            // {
            //     CartonHotMeal = 0;
            //     CartonMealBox = 0;
            //    // PlasticHotMeal = "0";
            //    // PlasticMealBox = "0";
            //     return;
            // }

            CartonHotMeal = SumOfMeals / HotMealInCartonBox;
            CartonMealBox = SumOfMeals / MealBoxInCartonBox;

            LeftoverHotMeal = SumOfMeals % HotMealInCartonBox;
            LeftoverMealBox = SumOfMeals % MealBoxInCartonBox;


            //.ToString("0.##")
        }


    }

}
