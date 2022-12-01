using System;
using Currencies;
using TMPro;
using UnityEngine;

namespace UI.Shop
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _marshmallowsText;
        [SerializeField] private GameObject _newFeatures;
        [SerializeField] private GameObject _oldFeatures;
        
        public void BuyMarshmallows()
        {
            Singletons._singletons.Shop.Buy(Singletons._singletons.Marshmallows, Singletons._singletons.Coins);
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