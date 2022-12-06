using Currencies;
using UnityEngine;

namespace Shop
{
    public class GameShop
    {
        public void Buy(Currency whatsBuying)
        {
            var currencyForPay = Singletons.Instance.CurrencyManager[whatsBuying.BuyingPerCurrency];
            
            if (currencyForPay.TryChangeValue(-whatsBuying.Price))
                whatsBuying.ChangeValue(whatsBuying.QuantityPerPrice);
        }

    }
}

