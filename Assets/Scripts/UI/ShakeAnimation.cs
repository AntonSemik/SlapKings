using System;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace UI
{
    public class ShakeAnimation : MonoBehaviour
    {
        [Header("Values for shake set between 0f to 0.2f")]
        [SerializeField][Min(0)] private float _xRange;
        [SerializeField][Min(0)] private float _yRange;
        [SerializeField][Min(0)] private float _rotationRange;
        [SerializeField][Min(0)] private float _scaleRange;
        [SerializeField][Min(0)] private float _speed = 0.2f;

        private float _time;
        private float _offsetX;
        private float _offsetY;
        private float _offsetAngle;
        private float _offsetScale;
  
        private void Update()
        {
            _time += Time.deltaTime * _speed;

            _offsetX = GetShakeOffset(_xRange);
            _offsetY = GetShakeOffset(_yRange);
            _offsetAngle = GetShakeOffset(_rotationRange);
            _offsetScale = GetShakeOffset(_scaleRange);
            
            transform.position = new Vector3(transform.position.x + _offsetX, transform.position.y + _offsetY, transform.position.z);
            transform.localScale += new Vector3(_offsetScale, _offsetScale, 0);
            transform.Rotate(transform.rotation.x, transform.rotation.y, _offsetAngle);
            
        }

        private float GetShakeOffset(float range)
        {
            return (range == 0) ? 0 : (Mathf.PingPong(_time, range * 2) - range);
        }
        
    }
}