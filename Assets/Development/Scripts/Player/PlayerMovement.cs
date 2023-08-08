using UnityEngine;

namespace Bomber
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool CanMove { get; private set; } = true;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        public void Move(Vector3 direction)
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(direction, 1) * _moveSpeed;
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
