using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    [SerializeField] private GameObject _UIpanel;

    public void ToggleElement()
    {
        _UIpanel.SetActive(!_UIpanel.activeSelf);
    }
}
