using UnityEngine;

//Пример запуска боевки
//Даниил, предупреди когда будешь убирать этот скрипт, от него зависит перезапуск боя
public class PlaceHolderFightStarter : MonoBehaviour
{    
    [SerializeField] private Fight _fight;
    [SerializeField] private Slaper _player;
    [SerializeField] private Slaper _enemy;

    private void Start() => StartFight();

    public void StartFight()
    {
        _fight.SetupSlappers(_player, _enemy);
    }
}


