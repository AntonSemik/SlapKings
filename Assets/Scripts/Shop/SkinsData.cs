using Currencies;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "Skin Data", fileName = "BaseSkinData")]
    public class SkinsData : ScriptableObject
    {
        public string title;
        public Sprite icon;
        public int price;
        public CurrencyType buyingPerCurrency;
    }
}