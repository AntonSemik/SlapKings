using UnityEngine;

namespace UI
{
    public class AnimatorSettings : MonoBehaviour
    {
        [SerializeField][Min(1)] private float _speedAnimation = 1f;
        
        private Animator _animator;
        private static readonly int SpeedHash = Animator.StringToHash("Speed");

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.SetFloat(SpeedHash, _speedAnimation);
        }
    }
}