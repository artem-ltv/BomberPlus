using System.Collections.Generic;
using UnityEngine;

namespace Bomber
{
    public class KeyGeneration : MonoBehaviour
    {
        [SerializeField] private Key _key;
        [SerializeField] private List<Transform> _spawnPoints;

        private List<Key> _keys = new List<Key>();

        private void Spawn()
        {
            int randomIndex = Random.Range(0, _spawnPoints.Count);
            Key newKey = Instantiate(_key, _spawnPoints[randomIndex].position, Quaternion.identity);
            _keys.Add(newKey);
            _spawnPoints.RemoveAt(randomIndex);
        }
    }
}
