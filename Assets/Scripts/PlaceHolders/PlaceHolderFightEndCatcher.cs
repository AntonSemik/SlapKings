using UnityEngine;

//Пример окончание боя
public class PlaceHolderFightEndCatcher : MonoBehaviour
{
    //Плейс холдер скрипт      
    [SerializeField] private Fight _fight;
    private void Start() => 
        _fight.PlayerWin += win => Debug.Log($"Player wins: {win}");
}


