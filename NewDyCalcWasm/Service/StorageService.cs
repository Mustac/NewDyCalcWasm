using Blazored.LocalStorage;
using NewDyCalcWasm.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDyCalcWasm.Service
{
    public class StorageService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly MealService _mealService;

        public event Func<Task> OnMealChange;

        public StorageService(ILocalStorageService localStorageService, MealService mealService)
        {
            _localStorageService = localStorageService;
            _mealService = mealService;
        }

        public async Task SaveItem(MealInfo meal)
        {
            try
            {
                var tempMeal = await _localStorageService.GetItemAsync<List<MealInfo>>("Meals") ?? new List<MealInfo>();

                tempMeal.Add(meal);

                await _localStorageService.SetItemAsync("Meals", tempMeal);

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
                var tempMeals = await _localStorageService.GetItemAsync<List<MealInfo>>("Meals");

                if (tempMeals != null)
                {
                    var tempMeal = tempMeals.FirstOrDefault(x => x.BoxId == boxId);
                    if (tempMeal != null)
                    {
                        tempMeals.Remove(tempMeal);
                        await _localStorageService.SetItemAsync("Meals", tempMeals);
                    }

                    await _mealService.TriggerMealAction(ActionTaken.Delete);
                }
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
                return meals ?? new List<MealInfo>();
            }
            catch
            {
                return new List<MealInfo>();
            }
        }

        public async Task<MealInfo> LoadItem(string id)
        {
            try
            {
                var meals = await _localStorageService.GetItemAsync<List<MealInfo>>("Meals");
                return meals?.FirstOrDefault(x => x.BoxId == id) ?? new MealInfo();
            }
            catch
            {
                return new MealInfo();
            }
        }

        public async Task UpdateItem(string oldId, MealInfo mealUpdateInfo)
        {
            try
            {
                List<MealInfo> meals = await LoadItems();

                var meal = meals.FirstOrDefault(x => x.BoxId == oldId);

                if(meal is null)
                    throw new Exception("Meal not found");

                if (meal != null)
                {
                    meal.BoxId = mealUpdateInfo.BoxId;
                    meal.BoxPosition = mealUpdateInfo.BoxPosition;
                    meal.BoxName = mealUpdateInfo.BoxName;
                    meal.BoxPiecesPerCartonBox = mealUpdateInfo.BoxPiecesPerCartonBox;
                    meal.BoxPiecesPerPlasticCase = mealUpdateInfo.BoxPiecesPerPlasticCase;
                    meal.BoxColor = mealUpdateInfo.BoxColor;
                    meal.HotMealId = mealUpdateInfo.HotMealId;
                    meal.HotMealPosition = mealUpdateInfo.HotMealPosition;
                    meal.HotMealName = mealUpdateInfo.HotMealName;
                    meal.HotMealPiecesPerCartonBox = mealUpdateInfo.HotMealPiecesPerCartonBox;
                    meal.HotMealPiecesPerPlasticCase = mealUpdateInfo.HotMealPiecesPerPlasticCase;
                    meal.PercentageAddExtra = mealUpdateInfo.PercentageAddExtra;

                    await _localStorageService.SetItemAsync("Meals", meals);
                    await _mealService.TriggerMealAction(ActionTaken.Update);
                }
            }
            catch
            {
                await _localStorageService.SetItemAsStringAsync("LogUpdateInfo", $"Update error at {DateTime.Now}");
            }
        }

        public async Task SwapIds(int indexDragged, int indexDropped)
        {
            try
            {
                var meals = await LoadItems();

                if (meals != null && indexDragged < meals.Count && indexDropped < meals.Count)
                {
                    var meal = meals[indexDragged];
                    meals.RemoveAt(indexDragged);
                    meals.Insert(indexDropped, meal);

                    await _localStorageService.SetItemAsync("Meals", meals);
                }
            }
            catch
            {
                await _localStorageService.SetItemAsStringAsync("LogUpdateInfo", $"Update error at {DateTime.Now}");
            }
        }
    }
}
