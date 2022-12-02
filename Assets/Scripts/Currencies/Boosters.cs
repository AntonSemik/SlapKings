using Shop;

namespace Currencies
{
    public class Boosters : Currency
    {
        public Boosters(CurrencyData settings)
        {
            Init(settings);
            // TODO: Get from Inventory
            // Total = Singletons._singletons.SaveGameState.Boosters;
        }

        public override void ChangeValue(int value)
        {
            base.ChangeValue(value);
            // TODO: Add to Inventory
        }
        
    }
}