using UnityEngine;

namespace Bomber
{
    public class KeyboardInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement; 

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (_playerMovement.CanMove)
            {
                Vector3 direction = new Vector3(horizontal, 0f, vertical);
                _playerMovement.Move(direction);

                if(direction != Vector3.zero)
                {
                    _playerMovement.Rotation(direction);
                }
            }
        }
    }
}
