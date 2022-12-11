using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkinOnPlayer : MonoBehaviour
{
    [SerializeField] private PlayerContainer _playerContainer;
    [SerializeField] private Transform _modelsContainer;
    [SerializeField] private Transform _avatarContainer;
    [SerializeField] private Image _avatarPrefab;
    private List<Player> _skins = new List<Player>();
    private int _currentSkinId = 0;

    public event Action<int> OnChangeSkin;
    // public event Action<string> OnChangeSkin;

    private void Awake()
    {
        int layer = LayerMask.NameToLayer("UI");

        int index = 0;
        foreach (var item in _playerContainer.Players)
        {
            Player skin = Instantiate(item, _modelsContainer);
            skin.transform.SetLayer(layer);
            if (_currentSkinId != index) 
                skin.gameObject.SetActive(false);
            _skins.Add(skin);
            
            var avatar = Instantiate(_avatarPrefab, _avatarContainer);
            avatar.sprite = item.GetAvatar();
            
            Button button = avatar.GetComponent<Button>();
            int indexSkin = index;
            button.onClick.AddListener(() => ChangeSkin(indexSkin));
            
            index++;
        }
    }

    private void ChangeSkin(int skinId = 0)
    {
        _currentSkinId = skinId;
        string title = _skins[_currentSkinId].GetSettingsForShop().title;
        OnChangeSkin?.Invoke(_currentSkinId);
        // OnChangeSkin?.Invoke(title);
        SwitchSkins();
    }

    private void SwitchSkins()
    {
        int index = 0;
        foreach (var item in _skins)
        {
            item.gameObject.SetActive(_currentSkinId == index);
            index++;
        }
    }
}

public static class TransformExtensions
{
    public static void SetLayer(this Transform transform, int layer) 
    {
        transform.gameObject.layer = layer;
        foreach(Transform child in transform)
            child.SetLayer( layer);
    }
}
