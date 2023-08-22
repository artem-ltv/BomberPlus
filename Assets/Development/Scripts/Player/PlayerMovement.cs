using UnityEngine;

namespace Bomber
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool CanMove => _canMove;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private PlayerAnimatorController _animatorController;
        
        private bool _canMove = true;

        public void Move(Vector3 direction, float speed)
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(direction, 1) * _moveSpeed;
            _animatorController.ActivateMoving(speed);
        }

        public void Rotation(Vector3 direction)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _rotationSpeed);
        }

        public void Stop()
        {
            _canMove = false;
            _rigidbody.velocity = Vector3.zero;
        }

        public void Resume()
        {
            _canMove = true;
        }
    }
}
