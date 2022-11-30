namespace Currencies
{
    public class Marshmallows : Currency
    {
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
    }
}