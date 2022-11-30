using System;

namespace Currencies
{
    public class Currency
    {
        protected int _total;
        public event Action OnChanged;
        
        protected virtual void ChangeValue(int value)
        {
            _total += value;
            OnChanged?.Invoke();
        }
        
        public bool IsEnough(int _amountNeeded)
        {
            return _amountNeeded <= _total;
        }
        
        protected void Save(string key)
        {
            Singletons._singletons.SaveGameState.SaveInt(key, _total);
        }
    }
}