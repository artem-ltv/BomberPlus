using UnityEngine;

namespace Bomber
{
    public class Key : MonoBehaviour
    {
        private Inventory _inventory;
        private KeySpawner _keySpawner;
        private Gate _gate;

        public void Init(KeySpawner keySpawner, Inventory inventory, Gate gate)
        {
            _keySpawner = keySpawner;
            _inventory = inventory;
            _gate = gate;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Player player))
            {
                _inventory.AddKey(this);
                _gate.TryOpen();
                _keySpawner.TrySpawn();
                gameObject.SetActive(false);
            }
        }
    }
}
