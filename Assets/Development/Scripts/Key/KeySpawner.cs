using System.Collections.Generic;
using UnityEngine;

namespace Bomber
{
    public class KeySpawner : MonoBehaviour
    {
        public int MaxKeys { get; private set; }

        [SerializeField] private Inventory _inventory;
        [SerializeField] private List<Key> _keys;
        [SerializeField] private List<Transform> _spawnPoints;

        private int _keyNumber = 0;

        private void Start()
        {
            MaxKeys = _keys.Count;
        }

        public void TrySpawn()
        {
            int remainingKeysCount = _keys.Count - _keyNumber;

            if ((_keyNumber < MaxKeys) && (_spawnPoints.Count >= remainingKeysCount))
            {
                int randomIndex = Random.Range(0, _spawnPoints.Count);

                Key newKey = Instantiate(_keys[_keyNumber], _spawnPoints[randomIndex].position, Quaternion.identity);
                newKey.Taking += OnTakingKey;

                _inventory.InitKey(newKey);
                _spawnPoints.RemoveAt(randomIndex);
                _keyNumber++;
            }
        }
        
        private void OnTakingKey(Key key) 
        {
            key.Taking -= OnTakingKey;
            TrySpawn();
        }
    }
}
