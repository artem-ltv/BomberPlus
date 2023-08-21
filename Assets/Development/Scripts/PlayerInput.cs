using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

namespace Bomber
{
    public enum DeviceTypeWebGL
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

        [SerializeField] private DeviceTypeWebGL CurrentDeviceType;

        [DllImport("__Internal")]
        private static extern void GetTypePlatformDevice();

        private string _mobileType = "mobile";
        private string _desktopType = "desktop";
        private string _tabletType = "tablet";

        private bool _isDesktop = false;

        private void Start()
        {
            //GetTypePlatformDevice();

            if(CurrentDeviceType == DeviceTypeWebGL.Desktop)
            {
                IdentifyDeviceType(_desktopType);
            }
            else
            {
                IdentifyDeviceType(_mobileType);
            }
        }

        private void FixedUpdate()
        {  
            if(_isDesktop)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");

                TryMovePlayer(horizontal, vertical);
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

        public void IdentifyDeviceType(string typeDevice)
        {
            if (typeDevice == _desktopType)
            {
                SetControllerForDevice(DeviceTypeWebGL.Desktop, true, false);
                _text.text = typeDevice;
            }

            if (typeDevice == _mobileType || typeDevice == _tabletType)
            {
                SetControllerForDevice(DeviceTypeWebGL.Mobile, false, true);
                _text.text = typeDevice;
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
            if (_isDesktop == false)
            {
                _joystick.gameObject.SetActive(isActive);
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

        private void SetControllerForDevice(DeviceTypeWebGL deviceType, bool isDesktop, bool isJoystickActive)
        {
            CurrentDeviceType = deviceType;
            _joystick.gameObject.SetActive(isJoystickActive);
            _isDesktop = isDesktop;
        }
    }
}
