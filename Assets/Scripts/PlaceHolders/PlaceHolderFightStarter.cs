using UnityEngine;

//Пример запуска боевки
public class PlaceHolderFightStarter : MonoBehaviour
{    
    [SerializeField] private Fight _fight;
    [SerializeField] private Slaper _player;
    [SerializeField] private Slaper _enemy;

    private void Start() =>
        _fight.SetupSlappers(_player, _enemy);
}


