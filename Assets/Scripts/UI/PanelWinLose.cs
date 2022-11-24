using UnityEngine;

namespace UI
{
    public class PanelWinLose : MonoBehaviour
    {
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
        }
    }
}