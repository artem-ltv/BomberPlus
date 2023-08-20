using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

namespace Bomber
{
    public enum DeviceTypeWeb
    {
        Desktop,
        Mobile,
        Tablet
    }

    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private BombThrowing _bombThrowing;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private TMP_Text _text;

        [DllImport("__Internal")]
        private static extern void GetTypePlatformDevice();

        public DeviceTypeWeb CurrentDeviceType { get; private set; } = DeviceTypeWeb.Mobile;

        private void Start()
        {
            GetTypePlatformDevice();
        }

        public void IdentifyDeviceType(string typeDevice)
        {
            if(typeDevice == "desktop")
            {
                CurrentDeviceType = DeviceTypeWeb.Desktop;
                _text.text = typeDevice;
            }

            if(typeDevice == "mobile")
            {
                CurrentDeviceType = DeviceTypeWeb.Mobile;
                _text.text = typeDevice;
            }
        }

        private void FixedUpdate()
        {  
            if(CurrentDeviceType == DeviceTypeWeb.Desktop)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");

                TryMovePlayer(horizontal, vertical);

                SetAciveJoystick(false);
            }

            else
            {
                if (_joystick != null)
                {
                    TryMovePlayer(_joystick.Horizontal, _joystick.Vertical);
                }
            }
            
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

        public void TryBombThrow()
        {
            if (_bombThrowing.CanThrow)
            {
                _bombThrowing.Throw();
            }
        }

        public void SetAciveJoystick(bool isActive)
        {
            _joystick.gameObject.SetActive(isActive);
        }
    }
}
