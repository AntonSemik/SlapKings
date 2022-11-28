using UnityEngine;

public class QtePanel : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttonPrefabs;
    private int _shieldsCollected = 0;
    private int _coinsCollected = 0;
    private Vector3[] _buttonsGrid = new Vector3[28];

    private void OnEnable()
    {
        InitializeButtonsGrid();
    }

    private void InitializeButtonsGrid()
    {
        int arrayIndex = 0;
        for (int yRange = 240; yRange >= -300; yRange -= 90)
        {
            for (int xRange = -150; xRange <= 150; xRange += 100)
            {
                _buttonsGrid[arrayIndex] = gameObject.transform.TransformPoint(xRange, yRange, 0f);

                Instantiate(_buttonPrefabs[Random.Range(0, _buttonPrefabs.Length)], _buttonsGrid[arrayIndex],
                    Quaternion.identity, gameObject.transform);
                arrayIndex++;
            }
        }
    }
}