using UnityEngine;

namespace Bomber
{
    public class KeyboardInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private BombThrowing _bombThrowing;

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            TryMovePlayer(horizontal, vertical);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TryBombThrow();
            }
        }

        private void TryMovePlayer(float horizontal, float vertical)
        {
            if (_playerMovement.CanMove)
            {
                Vector3 direction = new Vector3(horizontal, 0f, vertical);
                float speed = Mathf.Abs(horizontal + vertical);

                _playerMovement.Move(direction, speed);

                if (direction != Vector3.zero)
                {
                    _playerMovement.Rotation(direction);
                }
            }
        }

        private void TryBombThrow()
        {
            if (_bombThrowing.CanThrow)
            {
                _bombThrowing.Throw();
            }
        }
    }
}
