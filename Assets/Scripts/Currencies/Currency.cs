using System;

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
        
        public bool IsEnough(int _amountNeeded)
        {
            return _amountNeeded <= Total;
        }
    }
}