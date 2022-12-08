using System;
using System.Collections.Generic;
using Currencies;
using UnityEngine;

namespace Shop
{
    public class GameShop : MonoBehaviour
    { 
        [SerializeField] private BuyBoosterButton _buttonBoostersPrefab;
        [SerializeField] private Transform _buttonBoostersContainer;
        [SerializeField] private BuySkinButton _buttonSkinsPrefab;
        [SerializeField] private Transform _buttonSkinsContainer;
        
        public Dictionary<CurrencyType, List<BuyButton>> GoodsButtons { get; private set; } = new Dictionary<CurrencyType, List<BuyButton>>();

        public void InitGoods(IGoods[] goods)
        {
            foreach (var item in goods)
            {
                if (item.IsUnlockedByDefault()) continue;
                var settings = item.GetSettingsForShop();

                if (!GoodsButtons.ContainsKey(settings.currencyType))
                    GoodsButtons.Add(settings.currencyType, new List<BuyButton>());
                
                if (settings.currencyType == CurrencyType.Boosters)
                {
                    var prefab = _buttonBoostersPrefab; 
                    prefab._whatsBuySettings = settings;
                    
                    var button = Instantiate(prefab, _buttonBoostersContainer);
                    button._whatsBuy.OnBuyed += item.Buyed;
                    
                    GoodsButtons[settings.currencyType].Add(button);
                    // Debug.Log(button);
                }
            }
        }

        private void InstantiateButton()
        {
            
        }

        public void Buy(Currency whatsBuying)
        {
            var currencyForPay = Singletons._singletons.CurrencyManager[whatsBuying.BuyingPerCurrency];
            
            if (currencyForPay.TryChangeValue(-whatsBuying.Price))
                whatsBuying.ChangeValue(whatsBuying.QuantityPerPrice);
        }
        
    }
}

