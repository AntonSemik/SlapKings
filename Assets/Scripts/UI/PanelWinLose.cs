using UnityEngine;

namespace UI
{
    public class PanelWinLose : MonoBehaviour
    {
        private LoadLevelState _loadLevelState;
        
        private void Awake()
        {
            _loadLevelState = Singletons.Instance.GameStateMachine.GetComponent<LoadLevelState>();
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