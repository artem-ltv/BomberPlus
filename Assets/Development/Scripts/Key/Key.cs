using UnityEngine;
using UnityEngine.Events;

namespace Bomber
{
    public class Key : MonoBehaviour
    {
        public UnityAction<Key> Taking;
        public Color Color => _color;
        public string Name => _name;

        [SerializeField] private Color _color;
        [SerializeField] private string _name;

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
