using UnityEngine;
using UnityEngine.Events;

namespace Bomber
{
    public class Player : MonoBehaviour
    {
        public UnityAction Dying;

        [SerializeField] private int _health;

        public void AddDamage(int damage)
        {
            if(damage > 0)
            {
                _health -= damage;

                if (_health <= 0)
                {
                    Die();
                }
            }
        }

        private void Die()
        {
            Dying?.Invoke();
        }

        private void AddHealth(int health)
        {
            _health = health;
        }
    }
}
