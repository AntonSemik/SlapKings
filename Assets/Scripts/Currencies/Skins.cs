using Shop;
using System;

namespace Currencies
{
    public class Skins : Currency
    {
        public event Action<string> OnBuyed;

        public Skins(CurrencyData settings)
        {
            Init(settings);
            // TODO: Get from Inventory
            // Total = Singletons._singletons.SaveGameState.Skins;
        }

        public override void ChangeValue(int value)
        {
            base.ChangeValue(value);
            OnBuyed?.Invoke(Settings.title);
        }
    }
}