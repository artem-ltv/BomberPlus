using System.Collections.Generic;
using UnityEngine;

namespace Bomber
{
    public class Inventory : MonoBehaviour
    {
        public int KeysCount => _keys.Count;

        [SerializeField] private Gate _gate;
        [SerializeField] private Audio _audioSystem;

        private List<Key> _keys = new List<Key>();

        public void InitKey(Key key)
        {
            key.Taking += OnTakingKey;
        }

        private void OnTakingKey(Key key)
        {
            key.Taking -= OnTakingKey;

            _audioSystem.PlayTakingSound();
            _keys.Add(key);
            _gate.TryOpen();
        }
    }
}
