using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class PanelWinLose : MonoBehaviour
    {
        [SerializeField] private bool _isWinPanel;
        
        private LoadLevelState _loadLevelState;
        
        private void Awake()
        {
            _loadLevelState = Singletons._singletons.GameStateMachine.GetComponent<LoadLevelState>();
        }

        private void OnEnable()
        {
            _loadLevelState.SetActiveScreenUI(false);
        }

        private void OnDisable()
        {
            _loadLevelState.SetActiveScreenUI(true);
            if (_isWinPanel)
                Singletons._singletons.GameStateMachine.IncreaseLevel();
            else
                Singletons._singletons.GameStateMachine.ResetLevel();
        }
    }
}