using UnityEngine;
using TMPro;

public class UpdateReward : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _X = 1;
    private void OnEnable()
    {
        _text.text = (Singletons.Instance.LevelParameters._baseReward * _X).ToString();
    }
}