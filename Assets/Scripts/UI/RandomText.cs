using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomText : MonoBehaviour
{
    [SerializeField] private string[] TextSamples;
    [SerializeField] private TMP_Text TextComponent;

    private void Start()
    {
        SetRandomTextFromSamples();
    }

    public void SetRandomTextFromSamples()
    {
        TextComponent.text = TextSamples[Random.Range(0, TextSamples.Length)];
    }
}
