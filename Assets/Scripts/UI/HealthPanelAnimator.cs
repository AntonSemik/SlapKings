using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthPanelAnimator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _damageText;
        [SerializeField] private float _damageTextOffsetY = 20f;
        [SerializeField] private Slider _damageSlider;
        [SerializeField] private float _damageBarSpeed = 2f;
        [SerializeField] private float _damageBarTimeAnimation = 1f;
        
        private Slider _healthSlider;
        
        private void Awake()
        {
            _healthSlider = GetComponent<Slider>();
        }

        public void SetDefaultValues(int hp)
        {   
            _healthSlider.minValue = 0;
            _healthSlider.maxValue = hp;
            _healthSlider.value = _healthSlider.maxValue;            
            
            _damageSlider.minValue = _healthSlider.minValue;
            _damageSlider.maxValue = _healthSlider.maxValue;
            _damageSlider.value = _healthSlider.value;

            _healthText.SetText(hp.ToString());
            _damageText.enabled = false;
        }

        private int GetHealth()
        {
             return Convert.ToInt32(_healthText.text);
        }

        public void SetHealth(int hp)
        {    
            hp = Mathf.Clamp(hp, 0, (int)_healthSlider.maxValue);
            _healthSlider.value = hp;
            StartCoroutine(DamageBarAnimation(_damageBarTimeAnimation));
        }

        private IEnumerator DamageBarAnimation(float seconds)
        {
            float time = 0f;
            float startValue = _damageSlider.value;
            int damageValue = (int)(startValue - _healthSlider.value);
            
            _damageText.SetText("-" + damageValue.ToString());
            _damageText.enabled = true;
            
            Vector2 startPositionDamageText = _damageText.transform.position;
            Vector2 endPositionDamageText = new Vector2(startPositionDamageText.x, startPositionDamageText.y + _damageTextOffsetY);
            
            while (time <= seconds)
            {
                _damageSlider.value = Mathf.Lerp(startValue, _healthSlider.value, time * _damageBarSpeed);
                _healthText.SetText(_damageSlider.value.ToString());
                _damageText.transform.position = Vector2.Lerp(startPositionDamageText, endPositionDamageText, time * _damageBarSpeed);
                time += Time.deltaTime;
                yield return null;
            }
            
            _damageText.enabled = false;
            _damageText.transform.position = startPositionDamageText;
        }
    }
}