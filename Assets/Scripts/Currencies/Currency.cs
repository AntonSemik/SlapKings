using System;
using Shop;
using UnityEngine;

namespace Currencies
{
    
    public enum CurrencyType { Coins, Marshmallows, Skins, Boosters }
    
    public class Currency
    {
        public int Total { get; protected set; }
        public CurrencyType CurrencyType { get; private set; }
        public CurrencyType BuyingPerCurrency { get; private set; }
        public int Price { get; private set; } = 1;
        public int QuantityPerPrice { get; private set; } = 1;
        public CurrencyData Settings { get; private set; }
        
        public event Action<int> OnChanged;

        public void Init(CurrencyData settings)
        {
            Settings = settings;
            CurrencyType = Settings.currencyType;
            BuyingPerCurrency = Settings.buyingPerCurrency;
            Price = Settings.price;
            QuantityPerPrice = Settings.quantityPerPrice;
        }
        
        public virtual void ChangeValue(int value)
        {
            Total += value;
            OnChanged?.Invoke(Total);
        }
        
        public bool TryChangeValue(int value)
        {
            if (IsEnough(value))
            {
                ChangeValue(value);
                return true;
            }
            return false;
        }
        
        public bool IsEnough(int value)
        {
            return Math.Abs(value) <= Total;
        }
    }
}