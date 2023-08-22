using UnityEngine;
using UnityEngine.Events;

namespace Bomber
{
    public class Player : MonoBehaviour
    {
        public UnityAction Dying;

        [SerializeField] private int _health;
        [SerializeField] private HUD _hud;
        [SerializeField] private Audio _audioSystem;
        [SerializeField] private CapsuleCollider _collider;
        [SerializeField] private PlayerInput _input;

        private float _colliderRadiusForMobile = 0.28f;
        private float _colliderRadiusForDesktop = 0.35f;

        private void OnEnable()
        {
            _input.IdentifingDeviceType += ChangeColliderRadius;
        }

        private void OnDisable()
        {
            _input.IdentifingDeviceType -= ChangeColliderRadius;
        }

        public void AddDamage(int damage)
        {
            _audioSystem.PlayDamageSound();

            if (damage > 0)
            {
                _health -= damage;

                _hud.ShowDamageFrame();

                if (_health <= 0)
                {
                    _health = 0;
                    Die();
                }

                _hud.UpdateHealth(_health);
            }
        }

        private void Die()
        {
            Dying?.Invoke();
        }

        public void AddHealth(int health)
        {
            if(health > 0)
            {
                _health += health;
                _hud.UpdateHealth(_health);
            }
        }

        private void ChangeColliderRadius(DeviceTypeWebGL deviceTypeWebGL)
        {
            if (deviceTypeWebGL == DeviceTypeWebGL.Desktop)
            {
                _collider.radius = _colliderRadiusForDesktop;
            }
            else
            {
                _collider.radius = _colliderRadiusForMobile;
            }
        }
    }
}
