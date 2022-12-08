using System;
using Shop;
using UnityEngine;

namespace Currencies
{
    public class Boosters : Currency
    {
        public event Action<string> OnBuyed;
        
        public Boosters(CurrencyData settings)
        {
            Init(settings);
            // TODO: Get from Inventory
            // Total = Singletons._singletons.SaveGameState.Boosters;
        }

        public override void ChangeValue(int value)
        {
            base.ChangeValue(value);
            OnBuyed?.Invoke(Settings.title);
        }
    }
}