using System;
using System.Collections;
using System.Collections.Generic;
using Shop;
using UnityEngine;

public class MegaSlapObject : MonoBehaviour, IGoods
{
    [SerializeField] private bool isUnlockedByDefault;

    public string Name { get; private set; }

    [SerializeField] private float damageFactor;
    [SerializeField] private float megaslapDuration;
    public float DamageFactor => damageFactor;
    public float MegaslapDuration => megaslapDuration;

    [HideInInspector] public bool isUnlocked { get; private set; }
    [HideInInspector] public bool isVisible => VisibleModelOrigin.activeSelf;

    [SerializeField] private ParticleSystem[] OnChargeVFX;
    [SerializeField] private ParticleSystem OnHitVFX;
    [SerializeField] private GameObject VisibleModelOrigin;
    
    // for shop
    [SerializeField] private CurrencyData _settingsForShop;
    public CurrencyData GetSettingsForShop() => _settingsForShop;
    public bool IsUnlockedByDefault() => isUnlockedByDefault;

    public void Buyed(string value)
    {
        Debug.Log("Buyed " + value);
        OnUnlock();
    }
    //

    private void Awake()
    {
        Name = _settingsForShop.title;
    }

    private void Start()
    {
        if (isUnlockedByDefault) OnUnlock();

        isUnlocked = Singletons._singletons.SaveGameState.LoadBool(Name);
    }

    public void ToggleVisibility(bool isVisible)
    {
        VisibleModelOrigin.SetActive(isVisible);
    }

    public void OnUnlock()
    {
        isUnlocked = true;
        Singletons._singletons.SaveGameState.SaveBool(Name, isUnlocked);
    }

    public void OnChargeTrigger(int chargeLevel)
    {
        if (chargeLevel >= OnChargeVFX.Length) return;
        OnChargeVFX[chargeLevel]?.Play();
    }

    public void OnMegaHit()
    {
        OnHitVFX.Play();
    }
}
