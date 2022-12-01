using System;
using UnityEngine;

namespace Currencies
{
    
    public enum CurrencyType { Coins, Marshmallows, Skins, Boosters }
    
    public class Currency
    {
        public int Total { get; protected set; }
        public CurrencyType CurrencyType { get; protected set; }
        public CurrencyType BuyingPerCurrencyType { get; protected set; }
        public int Price { get; protected set; } = 1;
        public int QuantityPerPrice { get; protected set; } = 1;
        public event Action<int> OnChanged;
        
        public virtual void ChangeValue(int value)
        {
            Total += value;
            OnChanged?.Invoke(Total);
        }
        
        public virtual bool TryChangeValue(int value)
        {
            if (IsEnough(value))
            {
                ChangeValue(value);
                return true;
            }
            return false;
        }
        
        public bool IsEnough(int _amountNeeded)
        {
            return Math.Abs(_amountNeeded) <= Total;
        }
    }
}