using Currencies;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Shop
{
    [RequireComponent(typeof(Button))]
    public class BuyBoosterButton : BuyButton
    {
        public Boosters whatsBuy;

        protected override void GetWhatsBuy()
        {
            whatsBuy = new Boosters(whatsBuySettings);
        }
        
        protected override void Buy()
        {
            Singletons.Instance.Shop.Buy(whatsBuy);
        }
        
    }
}