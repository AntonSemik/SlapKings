using Currencies;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Shop
{
    [RequireComponent(typeof(Button))]
    public class BuySkinButton : BuyButton
    {
        private Skins _whatsBuy;
        
        protected override void GetWhatsBuy()
        {
            _whatsBuy = new Skins(_whatsBuySettings);
        }
        
        protected override void Buy()
        {
            Singletons.Instance.Shop.Buy(_whatsBuy);
        }
        
    }
}