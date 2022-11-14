using System;
using UnityEngine;
using UnityEngine.UI;

public class Input : MonoBehaviour, IInput
{
    [SerializeField] private Button _slap;
    [SerializeField] private Button _megaSlap;
    [SerializeField] private Button _armor;

    public event Action SlapClicked;
    public event Action MegaSlapClicked;
    public event Action ArmorClicked;

    private void Start()
    {
        _slap.onClick.AddListener(() => SlapClicked?.Invoke());
        _megaSlap.onClick.AddListener(() => MegaSlapClicked?.Invoke());
        _armor.onClick.AddListener(() => ArmorClicked?.Invoke());
    }
}