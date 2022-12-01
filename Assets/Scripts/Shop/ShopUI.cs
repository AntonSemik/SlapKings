using Currencies;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _marshmallowsText;
        [SerializeField] private GameObject _newFeatures;
        [SerializeField] private GameObject _oldFeatures;
    
        public void BuyMarshmallows()
        {
            // Singletons._singletons.Shop.Buy(Singletons._singletons.Marshmallows, Singletons._singletons.Coins);
            Singletons._singletons.Shop.Buy2(CurrencyType.Marshmallows);
        }
        
        public void BuySkins()
        {
            // Singletons._singletons.Shop.Buy(Singletons._singletons.Marshmallows, Singletons._singletons.Coins);
            // Singletons._singletons.Shop.Buy2(CurrencyType.Skins);
        }

        private void OnEnable()
        {
            if (Singletons._singletons.ThemeManager.IsDefault)
            {
                _newFeatures.SetActive(false);
                _oldFeatures.SetActive(true);
            }
            else
            {
                _newFeatures.SetActive(true);
                _oldFeatures.SetActive(false);
                _marshmallowsText.text = Singletons._singletons.Marshmallows.Price.ToString();
            }
        
        }
    }
}