using Currencies;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "Currency|Skins|Boosters Data", fileName = "New Data")]
    public class CurrencyData : ScriptableObject
    {
        public string title;
        public Sprite icon;
        public int price;
        public CurrencyType currencyType;
        public CurrencyType buyingPerCurrency;
        public int quantityPerPrice = 1;
        public GameObject prefab;
    }
}