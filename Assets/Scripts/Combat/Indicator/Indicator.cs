using UnityEngine;

public class Indicator : MonoBehaviour
{
    ///<summary>
    ///<para>Value between -1 and 1</para>   
    ///</summary>
    public float PointerPosition => _pointerPosition;
    public float PowerPercent => _powerPercent;

    [SerializeField] private float _speed = 1;
    private float _time;
    private float _pointerPosition;
    private float _powerPercent;
    [SerializeField] private bool _updatePointerPosition;

    private void OnEnable() => 
        StartPointerMovement();
    private void Update()
    {
        if (_updatePointerPosition)            
            MovePointer();
    }

    
    public void StartPointerMovement() =>
        _updatePointerPosition = true;
    
    public void Stop() =>
        _updatePointerPosition = false;
        
    private void MovePointer()
    {
        _time += Time.deltaTime * _speed;
        _pointerPosition = Mathf.PingPong(_time, 2) - 1;
        _powerPercent = 1 - Mathf.Abs(_pointerPosition);
    }
}
