namespace Currencies
{
    public class Marshmallows : Currency
    {

        public int Price { get; private set; } = 500;
        public int QuantityPerPrice { get; } = 1;

        public Marshmallows()
        {
            CurrencyType = CurrencyType.Marshmallows;
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