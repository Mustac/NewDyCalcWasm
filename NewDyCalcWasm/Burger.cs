namespace NewDyCalcWasm
{
    public static class Burger
    {
        public static event Action<bool> OnBurgerChange;
        

        public static void TriggerBurgerHide(bool burgerClick)
        {
            OnBurgerChange?.Invoke(burgerClick);
        }
    }
}
