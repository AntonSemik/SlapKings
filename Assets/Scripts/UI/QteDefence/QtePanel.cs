using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QtePanel : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttonPrefabs;
    public  int _shieldsCollected { get; private set; }
    public  int _coinsCollected { get; private set; }

    private Vector3[] _buttonsGrid = new Vector3[28];

    private void OnEnable()
    {
        InitializeButtonsGrid();
        CreateButtons(_buttonsGrid);
        ResetRewards();
    }

    private void InitializeButtonsGrid()
    {
        int arrayIndex = 0;
        for (int yRange = 240; yRange >= -300; yRange -= 90)
        {
            for (int xRange = -150; xRange <= 150; xRange += 100)
            {
                _buttonsGrid[arrayIndex] = gameObject.transform.TransformPoint(xRange, yRange, 0f);
                arrayIndex++;
            }
        }
    }

    private void CreateButtons(Vector3[] grid)
    {
        foreach (var position in grid)
        {
            GameObject currentButton = Instantiate(_buttonPrefabs[Random.Range(0, _buttonPrefabs.Length)], position,
                Quaternion.identity, gameObject.transform);

            ButtonType buttonType = currentButton.gameObject.GetComponent<QteButtonType>().buttonType;

            if (buttonType == ButtonType.Coin)
                currentButton.GetComponent<Button>().onClick.AddListener(() => CoinButtonClick(currentButton));
            else if (buttonType == ButtonType.Shield)
                currentButton.GetComponent<Button>().onClick.AddListener(() => ShieldButtonClick(currentButton));
        }
    }

    private void ResetRewards()
    {
        _shieldsCollected = 0;
        _coinsCollected = 0;
    }

    private void CoinButtonClick(GameObject button)
    {
        _coinsCollected += 1;
        Destroy(button);
    }

    private void ShieldButtonClick(GameObject button)
    {
        _shieldsCollected += 1;
        Destroy(button);
    }
}