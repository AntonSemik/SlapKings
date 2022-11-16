using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    [SerializeField] private string _URL;

    public void Open_URL()
    {
        Application.OpenURL(_URL);
    }
}