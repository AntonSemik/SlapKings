using Shop;

namespace Currencies
{
    public class Skins : Currency
    {
        public Skins(CurrencyData settings)
        {
            Init(settings);
            // TODO: Get from Inventory
            // Total = Singletons._singletons.SaveGameState.Skins;
        }

        public override void ChangeValue(int value)
        {
            base.ChangeValue(value);
            // TODO: Add to Inventory
        }
        
    }
}