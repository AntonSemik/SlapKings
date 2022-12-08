using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLocation : MonoBehaviour
{
    public void LoadLoadingScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
