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
        public Skins whatsBuy;
        
        protected override void GetWhatsBuy()
        {
            whatsBuy = new Skins(whatsBuySettings);
        }
        
        protected override void Buy()
        {
            Singletons.Instance.Shop.Buy(whatsBuy);
        }
        
    }
}