using Blazored.LocalStorage;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NewDyCalcWasm.Service
{
    public class StorageService
    {
        private readonly ILocalStorageService _localStorageService;

        public StorageService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task SaveItem(MealInfo meal)
        {
            try
            {
                List<MealInfo> tempMeal = await _localStorageService.GetItemAsync<List<MealInfo>>($"Meals");

                if(tempMeal is null) 
                {
                    tempMeal = new List<MealInfo> { meal };
                } 
                else if(tempMeal.Count > 0)
                {
                    meal.Position = tempMeal.LastOrDefault().Position + 1;
                    tempMeal.Add(meal);
                }

                await _localStorageService.SetItemAsync($"Meals", tempMeal);

            }
            catch
            {
                await _localStorageService.SetItemAsStringAsync("LogReadMealInfo", "Could not load Meals from the key Meals");
            }
        }
    }
}
