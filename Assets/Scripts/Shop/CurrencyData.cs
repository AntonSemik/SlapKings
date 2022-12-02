using Currencies;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "Currency Data", fileName = "BaseCurrencyData")]
    public class CurrencyData : ScriptableObject
    {
        public string title;
        public Sprite icon;
        public int price;
        public CurrencyType currencyType;
        public CurrencyType buyingPerCurrency;
    }
}