using UnityEngine;
using UnityEngine.Events;

namespace Bomber
{
    public class Enemy : MonoBehaviour
    {
        public UnityAction Dying;

        public void Die()
        {
            Dying?.Invoke();
            Destroy(gameObject);
        }
    }
}
