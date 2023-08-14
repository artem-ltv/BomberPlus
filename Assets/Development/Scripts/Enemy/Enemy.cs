using UnityEngine;
using UnityEngine.Events;

namespace Bomber
{
    public class Enemy : MonoBehaviour
    {
        public UnityAction<Enemy> Dying;

        public int Damage => _damage;

        [SerializeField ] private int _damage;

        public void Die()
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
