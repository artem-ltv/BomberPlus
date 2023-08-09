using UnityEngine;

namespace Bomber
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void ActivateMoving(float speed)
        {
            _animator.SetFloat("Move", speed);
        }
    }
}
