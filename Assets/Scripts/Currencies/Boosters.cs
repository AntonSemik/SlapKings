using Shop;

namespace Currencies
{
    public class Boosters : Currency
    {
        public Boosters(CurrencyData settings)
        {
            Init(settings);

            // Total = Singletons._singletons.SaveGameState.Boosters // Amounts saved, default to 0; Anton
        }

        public override void ChangeValue(int value)
        {
            base.ChangeValue(value);

            //Call from shop to add, call from usage to subtract
        }
        
    }
}