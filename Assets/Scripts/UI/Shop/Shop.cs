using System;
using Currencies;
using TMPro;
using UnityEngine;

namespace UI.Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private TMP_Text _marshmallowsText;
        [SerializeField] private GameObject _newFeatures;
        [SerializeField] private GameObject _oldFeatures;
        public void BuyMarshmallows()
        {
            if (Singletons._singletons.Coins.TryChangeValue(-Singletons._singletons.Marshmallows.CostPerCoins))
            {
                Singletons._singletons.Marshmallows.ChangeValue(1);
            }
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
                _marshmallowsText.text = Singletons._singletons.Marshmallows.CostPerCoins.ToString();
            }
            
        }
    }
}