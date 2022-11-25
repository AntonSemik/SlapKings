using UnityEngine;

public class QteDefence : MonoBehaviour
{
    [SerializeField] private GameObject shieldButtonPrefab;
    private int _shieldsCollected;
    private Vector2[] _buttonsMask = new Vector2[28];

    private void Start()
    {
        int arrayIndex = 0;
        for (int i = 240; i >= -300; i -= 90)
        {
            for (int j = -150; j <= 150; j += 100)
            {
                _buttonsMask[arrayIndex] = new Vector2(j, i);
                Vector3 position = new Vector3(_buttonsMask[arrayIndex].x, _buttonsMask[arrayIndex].y, 0);
                Instantiate(shieldButtonPrefab,position,Quaternion.identity,gameObject.transform); //Посмотрим позже, возможно будет лучше сделать пул кнопок
                
                Debug.Log(_buttonsMask[arrayIndex].x);
                Debug.Log(_buttonsMask[arrayIndex].y);
                arrayIndex++;
            }
        }
    }
}