using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class HideObject : MonoBehaviour
    {
        [SerializeField] private float _timeToHide = 2f;

        private void OnEnable()
        {
            StartCoroutine(Hide());
        }

        private IEnumerator Hide()
        {
            yield return new WaitForSeconds(_timeToHide);
            gameObject.SetActive(false);
        }
    }
}