using NewDyCalcWasm.Helpers;
using NewDyCalcWasm.Shared;

namespace NewDyCalcWasm.Service
{
    public class MealService
    {
        public PopupAddItem? PopupAddItem { get; set; }

        public event Func<ActionTaken, Task>? OnActionTaken;
        public event Func<Task>? OnAnyActionTaken;


        public void Show() => PopupAddItem.ShowPopup();
        public void Hide() => PopupAddItem.HidePopup();

       public async Task TriggerMealAction(ActionTaken actionTaken = ActionTaken.Any)
        {
            if (OnActionTaken is not null) await OnActionTaken.Invoke(actionTaken);
            if (OnAnyActionTaken is not null) await OnAnyActionTaken.Invoke();
        }

    }
}
