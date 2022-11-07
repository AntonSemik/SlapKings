using TMPro;
using UI;
using UnityEngine;

public class PlaceHolderHPUI : MonoBehaviour
{
    [SerializeField] private Slaper _player;
    [SerializeField] private Slaper _enemy;
    [SerializeField] private HealthPanelAnimator _playerHP;
    [SerializeField] private HealthPanelAnimator _enemyHP;
    
    private void Start()
    {   
        _playerHP.SetDefaultValues(_player.CurrentHealth);
        _enemyHP.SetDefaultValues(_enemy.CurrentHealth);
        
        _player.DamageReceived += damage => {_playerHP.SetHealth(_player.CurrentHealth); Debug.Log($"Enemy dealed {damage} damage points");};
        _enemy.DamageReceived += damage => {_enemyHP.SetHealth(_enemy.CurrentHealth); Debug.Log($"Player dealed {damage} damage points");};
    }

}

