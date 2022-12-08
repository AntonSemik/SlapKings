using System;
using Currencies;
using UnityEngine;

namespace Shop
{
    public class ButtonLoader : MonoBehaviour
    {
        [SerializeField] private CurrencyType _currencyType;
        
        private void Awake()
        {
            if (!Singletons._singletons.Shop.GoodsButtons.ContainsKey(_currencyType)) return;
            foreach (var button in Singletons._singletons.Shop.GoodsButtons[_currencyType])
            {
                button.transform.SetParent(transform);
                button.transform.localScale = Vector3.one;
            }
        }
    }
}