using Blazored.LocalStorage;
using NewDyCalcWasm.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NewDyCalcWasm.Service
{
    public class StorageService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly MealService _mealService;

        
 


        public StorageService(ILocalStorageService localStorageService, MealService mealService)
        {
            _localStorageService = localStorageService;
            _mealService = mealService;
        }

        public async Task SaveItem(MealInfo meal)
        {
            try
            {
                List<MealInfo> tempMeal = await _localStorageService.GetItemAsync<List<MealInfo>>("Meals");

                if(tempMeal is null) 
                {
                    tempMeal = new List<MealInfo> { meal };
                } 
                else if(tempMeal.Count > 0)
                {
                    tempMeal.Add(meal);
                }

                await _localStorageService.SetItemAsync($"Meals", tempMeal);

                await _mealService.TriggerMealAction(ActionTaken.Create);

            }
            catch
            {
                await _localStorageService.SetItemAsStringAsync("LogReadMealInfo", $"Could not load Meals from the key Meals at {DateTime.Now}");
            }
        }

        public async Task DeleteItem(string boxId)
        {
            try
            {
                List<MealInfo> tempMeals = await _localStorageService.GetItemAsync<List<MealInfo>>("Meals");

                MealInfo tempMeal = tempMeals.FirstOrDefault(x => x.BoxId == boxId);

                await _localStorageService.RemoveItemAsync("Meals");

                tempMeals.Remove(tempMeal);

                if(tempMeals.Count != 0 )
                {
                    await _localStorageService.SetItemAsync($"Meals", tempMeals);
                }

                await _mealService.TriggerMealAction(ActionTaken.Delete);


            }
            catch 
            {
                await _localStorageService.SetItemAsStringAsync("LogDeleteMealInfo", $"Deletion error at {DateTime.Now}");
            }
        }

        public async Task<List<MealInfo>> LoadItems()
        {
            try
            {
                var meals = await _localStorageService.GetItemAsync<List<MealInfo>>("Meals");

                return meals;
            }
            catch
            {
                return new List<MealInfo>();
            }
        }

        public async Task SwapIds(int indexDragged, int indexDropped)
        {
            try
            {
                var meals = await LoadItems();
                
                if (meals is null)
                    return;

                var meal = meals[indexDragged];

                meals.Remove(meal);

                meals.Insert(indexDropped, meal);


                await _localStorageService.RemoveItemAsync("Meals");
                await _localStorageService.SetItemAsync("Meals", meals);



            }
            catch
            {
                await _localStorageService.SetItemAsStringAsync("LogUpdateInfo", $"Update error at {DateTime.Now}");
            }

        }

    }
}
