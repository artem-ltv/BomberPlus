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
        [SerializeField] private RedButton _redButton;
        [SerializeField] private Hint _hint;

        private int _keyNumber = 0;

        private void OnEnable()
        {
            _redButton.Pressing += TrySpawn;
        }

        private void OnDisable()
        {
            _redButton.Pressing -= TrySpawn;
        }

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
                _keyNumber++;

                _inventory.InitKey(newKey);
                _hint.GetHintToKey(newKey);
                _spawnPoints.RemoveAt(randomIndex);
            }
        }

        private void OnTakingKey(Key key) 
        {
            key.Taking -= OnTakingKey;
            TrySpawn();
        }
    }
}
