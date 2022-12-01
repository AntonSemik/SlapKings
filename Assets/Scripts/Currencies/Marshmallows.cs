namespace Currencies
{
    public class Marshmallows : Currency
    {

        // public int Price { get; } = 500;
        // public int QuantityPerPrice { get; } = 1;
        // public Currency buyingCurrency = new Coins();

        public Marshmallows()
        {
            CurrencyType = CurrencyType.Marshmallows;
            BuyingPerCurrencyType = CurrencyType.Coins;
            Price = 110;
            Total = Singletons._singletons.SaveGameState.Marshmallows;
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