using Currencies;
using UnityEngine;

namespace Shop
{
    public class GameShop
    {
        public GameShop()
        {
    
        }

        public void Buy2(CurrencyType whatsBuyingType)
        {
            Debug.Log("Buy2 " + whatsBuyingType);
            
            var whatsBuying = Singletons._singletons.CurrencyManager[whatsBuyingType];
            var currencyForPay = Singletons._singletons.CurrencyManager[whatsBuying.BuyingPerCurrency];
            
            Debug.Log(whatsBuying);
            Debug.Log(currencyForPay);
            
            if (currencyForPay.TryChangeValue(-whatsBuying.Price))
                whatsBuying.ChangeValue(whatsBuying.QuantityPerPrice);
            
            // if (currency.TryChangeValue(-product.Price))
            //     product.ChangeValue(product.QuantityPerPrice);
        }
        
        // public void Buy(Marshmallows product, Currency currency)
        // {
        //     if (currency.TryChangeValue(-product.Price))
        //         product.ChangeValue(product.QuantityPerPrice);
        // }
        
        // public void Buy(Skins product, Currency currency)
        // {
        //     if (currency.TryChangeValue(-product.Price))
        //         product.ChangeValue(product.QuantityPerPrice);
        // }
    }
}

