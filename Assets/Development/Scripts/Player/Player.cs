using UnityEngine;
using UnityEngine.Events;

namespace Bomber
{
    public class Player : MonoBehaviour
    {
        public UnityAction Dying;

        [SerializeField] private int _health;
        [SerializeField] private HUD _hud;

        public void AddDamage(int damage)
        {
            if(damage > 0)
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
    }
}
