using UnityEngine;

namespace Bomber
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool CanMove { get; private set; } = true;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private PlayerAnimatorController _animatorController;

        public void Move(Vector3 direction, float speed)
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(direction, 1) * _moveSpeed;
            _animatorController.ActivateMoving(speed);
        }

        public void Rotation(Vector3 direction)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _rotationSpeed);
        }

        private void Lock()
        {
            CanMove = false;
        }
    }
}
