using TMPro;
using UnityEngine;

public class PlaceHolderHPUI : MonoBehaviour
{
    [SerializeField] private Slaper _player;
    [SerializeField] private Slaper _enemy;
    [SerializeField] private TextMeshProUGUI _playerHP;
    [SerializeField] private TextMeshProUGUI _enemyHP;

    private void Start()
    {   
        _playerHP.text = _player.CurrentHealth.ToString();
        _enemyHP.text = _enemy.CurrentHealth.ToString();

        _player.DamageReceived += damage => {_playerHP.text = _player.CurrentHealth.ToString(); Debug.Log($"Enemy dealed {damage} damage points");};
        _enemy.DamageReceived += damage => {_enemyHP.text = _enemy.CurrentHealth.ToString(); Debug.Log($"Player dealed {damage} damage points");};
    }

}

