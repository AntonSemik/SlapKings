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
            }
        
        }
    }
}