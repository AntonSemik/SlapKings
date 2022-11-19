using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressLevel : MonoBehaviour
    {
        [SerializeField] private LevelPoint[] _progress;
        [SerializeField] private Sprite[] _progressSprites;
        
        private Color _colorDefault = Color.white;
        private Color _colorFineshed = new Color32(0,116,6, 255);
        private Image _currentProgressBackground;
        private int _levelNumber = 1;
        private int _levelIndex;
        private int _bonusLevelNumber = 4;
        private int _bonusLevelIndex = 0;

        private void Awake()
        {
            _currentProgressBackground = GetComponent<Image>();
            _bonusLevelNumber = Singletons._singletons.LevelParameters.bonusLevelNumber;
        }

        private void OnEnable()
        {
            _levelNumber = Singletons._singletons.LevelParameters._level;
            _levelIndex = GetLevelIndex();
            _currentProgressBackground.sprite = _progressSprites[_levelIndex];
            
            SetCurrentLevelPoint();
            SetLeftLevelPoints();
            SetRightLevelPoints();
        }

        private void OnDisable()
        {
            SetLevelPointValue(_bonusLevelIndex, 0, _colorDefault);
        }
        
        private int GetLevelIndex() => _levelNumber % _bonusLevelNumber;

        private void SetCurrentLevelPoint()
        {
            _progress[_levelIndex].levelNumber.gameObject.SetActive(false);
            _progress[_levelIndex].levelFinished.gameObject.SetActive(true);
            if (IsBonusLevel())
                _levelIndex = _progress.Length;
        }
        
        private void SetRightLevelPoints()
        {
            int level = _levelNumber;
            for (int pointIndex = _levelIndex + 1; pointIndex < _progress.Length; pointIndex++)
            {
                level++;
                SetLevelPointValue(pointIndex, level, _colorDefault);
            }
        }
        
        private void SetLeftLevelPoints()
        {
            int level = _levelNumber;
            for (int pointIndex = _levelIndex - 1; pointIndex > 0; pointIndex--)
            {
                level--;
                SetLevelPointValue(pointIndex, level, _colorFineshed);
            }
        }

        private void SetLevelPointValue(int pointIndex, int level, Color color)
        {
            _progress[pointIndex].levelNumber.color = color;
            _progress[pointIndex].levelNumber.text = level == 0 ? "" : level.ToString();
            _progress[pointIndex].levelNumber.gameObject.SetActive(true);
            _progress[pointIndex].levelFinished.gameObject.SetActive(false);
        }

        private bool IsBonusLevel() => _levelNumber % _bonusLevelNumber == 0;
    }
}