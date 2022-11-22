using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class PanelWinLose : MonoBehaviour
    {
        [SerializeField] private GameObject _slapButton; // TODO: костыль, пока не пофиксим загрузку уровня после закрытия экранов Win/Lose
        
        private LoadLevelState _loadLevelState;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);
        
        private void Awake()
        {
            _loadLevelState = Singletons._singletons.GameStateMachine.GetComponent<LoadLevelState>();
        }

        private void OnEnable()
        {
            _loadLevelState.SetActiveScreenUI(false);
            StartCoroutine(HideIdleUI()); // TODO: костыль, пока не пофиксим загрузку уровня после закрытия экранов Win/Lose
        }

        private void OnDisable()
        {
            _loadLevelState.SetActiveScreenUI(true);
        }

        
        private IEnumerator HideIdleUI()
        {
            yield return _waitForSeconds;
            _loadLevelState.HideIdleUI();
            _slapButton.SetActive(false);
        }
    }
}