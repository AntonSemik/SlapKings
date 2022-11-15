using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _speed = 0.5f;
    private float _time = 0.5f;
    private float _angle;
    private bool _move;
   
    private void Update()
    {   
        if(!_move)
            return;
        _time += Time.deltaTime * _speed;

        _angle = _curve.Evaluate(_time);

        transform.rotation = Quaternion.Euler(_angle, 0, 0);
    }

    public void StartMoving()
    {
        _move = true;   
    }

    public void Reset()
    {
        _time = 0.5f;       
        _move = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
