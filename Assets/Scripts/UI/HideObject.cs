using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class HideObject : MonoBehaviour
    {
        [SerializeField] private float _timeToHide = 2f;

        private WaitForSeconds _waitForSeconds;

        private void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_timeToHide);
        }

        private void OnEnable()
        {
            StartCoroutine(Hide());
        }

        private IEnumerator Hide()
        {
            yield return _waitForSeconds;
            gameObject.SetActive(false);
        }
    }
}