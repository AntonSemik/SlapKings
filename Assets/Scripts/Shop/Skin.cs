using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class Skin : MonoBehaviour
    {
        [SerializeField] private SkinsData _skinData;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _coin;
        [SerializeField] private TMP_Text _price;
        
        private void OnEnable()
        {
            Debug.Log(_skinData.title);
            _title.text = "Skin: " + _skinData.title;
            _price.text = _skinData.price.ToString();
            _icon.sprite = _skinData.icon;
        }
        
        public void BuySkins()
        {
            // Singletons._singletons.Shop.Buy(Singletons._singletons.Marshmallows, Singletons._singletons.Coins);
            // Singletons._singletons.Shop.Buy2(CurrencyType.Skins);
        }
        
    }
}