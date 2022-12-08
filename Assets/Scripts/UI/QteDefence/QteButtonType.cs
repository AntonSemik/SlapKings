using System;
using UnityEngine;

public enum ButtonType {Empty, Coin, Shield}

public class QteButtonType : MonoBehaviour
{
    public ButtonType buttonType;

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}