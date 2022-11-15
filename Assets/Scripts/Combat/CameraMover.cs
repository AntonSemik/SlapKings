using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _playerAngle;
    [SerializeField] private Vector3 _enemyAngle;

    public static CameraMover Instance;
    private Vector3 _targetAngle;

    private void Awake() =>
        Instance = this;

    private void Update() =>
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_targetAngle), _speed * Time.deltaTime);

    public void LookAtPlayer() =>
        _targetAngle = _playerAngle;

    public void LookAtEnemy() =>
        _targetAngle = _enemyAngle;

    public void InstantLookAtEnemy()
    {
        _targetAngle = _enemyAngle;
        transform.rotation = Quaternion.Euler(_targetAngle);
    }
}