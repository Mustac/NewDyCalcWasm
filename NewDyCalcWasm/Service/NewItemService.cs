using NewDyCalcWasm.Shared;

namespace NewDyCalcWasm.Service
{
    public class NewItemService
    {
        public PopupAddItem? PopupAddItem { get; set; }

        public void Show() => PopupAddItem.ShowPopup();
        public void Hide() => PopupAddItem.HidePopup();

    }
}
