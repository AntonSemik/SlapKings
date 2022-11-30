using System;
using UnityEngine;

namespace Currencies
{
    
    public enum CurrencyType { Coins, Marshmallows }
    
    public class Currency
    {
        public int Total { get; protected set; }
        public CurrencyType CurrencyType { get; protected set; }
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