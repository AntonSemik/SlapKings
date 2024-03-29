using UI;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField] private HealthPanelAnimator _playerHP;
    [SerializeField] private HealthPanelAnimator _enemyHP;
    [SerializeField] private Image _playerImage;
    [SerializeField] private Image _enemyImage;
    
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
        _playerHP.SetDefaultValues(_player.MaxHealth);
        _enemyHP.SetDefaultValues(_enemy.MaxHealth);
        // TODO: временная проверка аватара на null, т.к. иногда после бонусного уровня аватар становится null 
        _playerImage.sprite = _player.GetAvatar() != null ? _player.GetAvatar() : _playerImage.sprite;
        _enemyImage.sprite = _enemy.GetAvatar() != null ? _enemy.GetAvatar() : _enemyImage.sprite;
    }

    private void OnPlayerReceivedDamage(int damage) =>
        _playerHP.SetHealth(_player.CurrentHealth);
    private void OnEnemyReceivedDamage(int damage) =>
        _enemyHP.SetHealth(_enemy.CurrentHealth);
}