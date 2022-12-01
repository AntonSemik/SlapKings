namespace Currencies
{
    public class Skins : Currency
    {

        // public int Price { get; private set; } = 1000;
        // public int QuantityPerPrice { get; } = 1;

        public Skins()
        {
            CurrencyType = CurrencyType.Skins;
            BuyingPerCurrencyType = CurrencyType.Marshmallows;
            Price = 2;
            Total = Singletons._singletons.SaveGameState.Skins;
        }

        public override void ChangeValue(int value)
        {
            base.ChangeValue(value);
            Singletons._singletons.SaveGameState.Marshmallows = Total;
        }
        
        public override bool TryChangeValue(int value)
        {
            bool result = base.TryChangeValue(value);
            Singletons._singletons.SaveGameState.Marshmallows = Total;
            return result;
        }
    }
}