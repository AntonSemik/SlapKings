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
        public Boosters _whatsBuy;

        protected override void GetWhatsBuy()
        {
            _whatsBuy = new Boosters(_whatsBuySettings);
        }
        
        protected override void Buy()
        {
            Singletons._singletons.Shop.Buy(_whatsBuy);
        }
        
    }
}