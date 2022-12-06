using Shop;

namespace Currencies
{
    public class Marshmallows : Currency
    {
        public Marshmallows(CurrencyData settings)
        {
            Init(settings);
            Total = Singletons.Instance.SaveGameState.Marshmallows;
        }

        public override void ChangeValue(int value)
        {
            base.ChangeValue(value);
            Singletons.Instance.SaveGameState.Marshmallows = Total;
        }
        
    }
}