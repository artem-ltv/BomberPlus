using UnityEngine;
using UnityEngine.Events;

namespace Bomber
{
    public class Key : MonoBehaviour
    {
        public UnityAction<Key> Taking;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Player player))
            {
                Taking?.Invoke(this);
                gameObject.SetActive(false);
            }
        }
    }
}
