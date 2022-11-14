using UI;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    [SerializeField] private HealthPanelAnimator _playerHP;
    [SerializeField] private HealthPanelAnimator _enemyHP;

    private Slaper _player;
    private Slaper _enemy;

    public void SetSlapers(Slaper player, Slaper enemy)
    {
        UnsubscribeFromSlapers();
        _player = player;
        _enemy = enemy;
        ResetHealthPanels();
        SubscribeToSlapers();
    }

    private void SubscribeToSlapers()
    {
        _player.DamageReceived += OnPlayerReceivedDamage;
        _enemy.DamageReceived += OnEnemyReceivedDamage;
    }
    private void UnsubscribeFromSlapers()
    {
        if (_player != null)
            _player.DamageReceived -= OnPlayerReceivedDamage;

        if (_enemy != null)
            _enemy.DamageReceived -= OnEnemyReceivedDamage;
    }

    private void ResetHealthPanels()
    {        
        Debug.Log($"_player.MaxHealth{_player.MaxHealth}||| _enemy.MaxHealth{_enemy.MaxHealth}");
        _playerHP.SetDefaultValues(_player.MaxHealth);
        _enemyHP.SetDefaultValues(_enemy.MaxHealth);
    }

    private void OnPlayerReceivedDamage(int damage) =>
        _playerHP.SetHealth(_player.CurrentHealth);
    private void OnEnemyReceivedDamage(int damage) =>
        _enemyHP.SetHealth(_enemy.CurrentHealth);
}

