using System;
using UnityEngine;

namespace Shop
{
    public class CurrencyLoader : MonoBehaviour
    {
        [SerializeField] private CurrencyData[] _data;
        [SerializeField] private BuyButton _buttonPrefab;
        
        private void Awake()
        {
            foreach (var settings in _data)
            {
                _buttonPrefab._whatsBuySettings = settings;
                Instantiate(_buttonPrefab, transform);
            }
        }
    }
}