using Shop;

namespace Currencies
{
    public class Skins : Currency
    {

        // public int Price { get; private set; } = 1000;
        // public int QuantityPerPrice { get; } = 1;

        public Skins(SkinsData settings)
        {
            CurrencyType = settings.currencyType;
            BuyingPerCurrency = settings.buyingPerCurrency;
            Price = settings.price;
            Total = Singletons._singletons.SaveGameState.Skins;
        }

        public override void ChangeValue(int value)
        {
            base.ChangeValue(value);
            // Singletons._singletons.SaveGameState.Marshmallows = Total;
        }
        
        public override bool TryChangeValue(int value)
        {
            bool result = base.TryChangeValue(value);
            // Singletons._singletons.SaveGameState.Skins = Total;
            return result;
        }
    }
}