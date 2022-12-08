using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLocation : MonoBehaviour
{
    [SerializeField] private string[] LocationNames;
    [SerializeField] private SaveGameState SaveGameState;

    private void Start()
    {
        StartCoroutine(LoadLocationAsync());
    }

    IEnumerator LoadLocationAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Location_"+LocationNames[SaveGameState._locationID]);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
