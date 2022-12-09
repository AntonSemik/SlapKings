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
        }

        public override void ChangeValue(int value)
        {
            base.ChangeValue(value);
            OnBuyed?.Invoke(Settings.title);
        }
    }
}