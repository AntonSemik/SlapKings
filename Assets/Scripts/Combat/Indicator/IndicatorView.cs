using UnityEngine;
using PathCreation;
public class IndicatorView : MonoBehaviour
{
    [SerializeField] private Indicator _indicator;
    [SerializeField] private PathCreator _pathCreator;
    private float _time;

    
    private void Update()
    {
        _time = Mathf.InverseLerp(-1, 1, _indicator.PointerPosition);
        transform.position = _pathCreator.path.GetPointAtTime(_time);    
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_pathCreator.path.length * _time);
    }
}