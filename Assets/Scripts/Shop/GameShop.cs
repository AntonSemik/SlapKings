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

                switch (settings.currencyType)
                {
                    case CurrencyType.Boosters:
                        InstantiateBoosterButton(item, settings);
                        break;
                    case CurrencyType.Skins:
                        InstantiateSkinButton(item, settings);
                        break;
                }
            }
        }

        private void InstantiateBoosterButton(IGoods item, CurrencyData settings)
        {
            var prefab = _buttonBoostersPrefab; 
            _buttonBoostersPrefab.whatsBuySettings = settings;
                    
            var button = Instantiate(prefab, _buttonBoostersContainer);
            button.whatsBuy.OnBuyed += item.Buyed;

            GoodsButtons[settings.currencyType].Add(button);
        }
        
        private void InstantiateSkinButton(IGoods item, CurrencyData settings)
        {
            var prefab = _buttonSkinsPrefab; 
            _buttonSkinsPrefab.whatsBuySettings = settings;
                    
            var button = Instantiate(prefab, _buttonSkinsContainer);
            button.whatsBuy.OnBuyed += item.Buyed;
            
            GoodsButtons[settings.currencyType].Add(button);
        }

        public void Buy(Currency whatsBuying)
        {
            var currencyForPay = Singletons.Instance.CurrencyManager[whatsBuying.BuyingPerCurrency];
            
            if (currencyForPay.TryChangeValue(-whatsBuying.Price))
                whatsBuying.ChangeValue(whatsBuying.QuantityPerPrice);
        }
        
    }
}

