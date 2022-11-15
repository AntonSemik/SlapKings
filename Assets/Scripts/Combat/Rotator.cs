using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _leftMaxAngle = -15;
    [SerializeField] private float _rightMaxAngle = 15;
    private float _time = 0.5f;
    private float _angle;
    private bool _move;
   
    private void Update()
    {   
        if(!_move)
            return;
        _time += Time.deltaTime * _speed;
        _angle = Mathf.Lerp(_rightMaxAngle, _leftMaxAngle, Mathf.PingPong(_time, 1));
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
