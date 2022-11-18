using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressLevel : MonoBehaviour
    {
        [SerializeField] private LevelPoint[] _progress;
        [SerializeField] private Sprite[] _progressSprites;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _fineshedColor;

        private Image _currentProgressImage;
        
        
        private void Start()
        {
            _currentProgressImage = GetComponent<Image>();
            Invoke("Display", 1f);
        }

        private void Display()
        {
            int level = Singletons._singletons.LevelParameters._level;
            int levelPosition = level % 4;

            _currentProgressImage.sprite = _progressSprites[levelPosition];
            
            Debug.Log(levelPosition);
            
            Debug.Log(_currentProgressImage.sprite);

            for (int point = 0; point < _progress.Length; point++)
            {
                _progress[point]._levelNumber.text = level.ToString();
                // if (point != 0)
                // {
                //     _progress[point]._levelNumber.text = level.ToString();
                // }
                //
                // if (point == levelPosition)
                // {
                //     
                // }
            }

            
            // Debug.Log(Mathf.FloorToInt(level / 4));
        }

    }
}