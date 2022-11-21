using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomizeImage : MonoBehaviour
{
    [SerializeField] Sprite[] _imageArray;
    [SerializeField] Image _image;

    private void OnEnable()
    {
        Singletons._singletons.GameStateMachine.SetPause(true);
        _image.sprite = _imageArray[Random.Range(0,_imageArray.Length)];
    }

    private void OnDisable()
    {
        Singletons._singletons.GameStateMachine.SetPause(false);
    }
}