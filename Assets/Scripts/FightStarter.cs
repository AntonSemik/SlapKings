using UnityEngine;

public class FightStarter : MonoBehaviour
{
    //Плейс холдер скрипт для запуска боевки
    [SerializeField] private Fight _fight;
    [SerializeField] private Slaper _player;
    [SerializeField] private Slaper _enemy;

    private void Start() =>
        _fight.SetupSlappers(_player, _enemy);
}
