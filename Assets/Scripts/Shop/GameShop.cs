using System;
using System.Collections.Generic;
using Currencies;
using UnityEngine;

namespace Shop
{
    public class GameShop
    {
        public Dictionary<CurrencyType, List<CurrencyData>> Goods { get; private set; } = new Dictionary<CurrencyType, List<CurrencyData>>();
        
        public void Buy(Currency whatsBuying)
        {
            var currencyForPay = Singletons._singletons.CurrencyManager[whatsBuying.BuyingPerCurrency];
            
            if (currencyForPay.TryChangeValue(-whatsBuying.Price))
                whatsBuying.ChangeValue(whatsBuying.QuantityPerPrice);
        }

        public void InitBoosters(MegaSlapObject[] megaSlaps)
        {
            foreach (var item in megaSlaps)
            {
                if (item.IsUnlockedByDefault) continue;
                if (!Goods.ContainsKey(item.settingsForShop.currencyType))
                    Goods.Add(item.settingsForShop.currencyType, new List<CurrencyData>());
                Goods[item.settingsForShop.currencyType].Add(item.settingsForShop);
            }
        }

        public void InitSkins(Player[] skins)
        {
            foreach (var item in skins)
            {
                if (item.IsUnlockedByDefault) continue;
                if (!Goods.ContainsKey(item.settingsForShop.currencyType))
                    Goods.Add(item.settingsForShop.currencyType, new List<CurrencyData>());
                Goods[item.settingsForShop.currencyType].Add(item.settingsForShop);
            }
        }
    }
}

