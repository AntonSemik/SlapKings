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
        _image.sprite = _imageArray[Random.Range(0,_imageArray.Length)];
    }
}