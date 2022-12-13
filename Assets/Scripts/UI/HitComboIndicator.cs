using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitComboIndicator : MonoBehaviour
{
    [SerializeField] GameObject _hitCounterOrigin;
    [SerializeField] TMP_Text _hitCounter;
    [SerializeField] string _hitCounterPreText;

    private void Start()
    {
        SetCounter(0);
    }

    private void OnEnable()
    {
        SetCounter(0);
    }

    public void ToggleCounter(bool isActive)
    {
        _hitCounterOrigin.SetActive(isActive);
    }

    public void SetCounter(int count)
    {
        _hitCounter.text = _hitCounterPreText + count.ToString();
    }
}
