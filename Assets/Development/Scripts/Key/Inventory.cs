using System.Collections.Generic;
using UnityEngine;

namespace Bomber
{
    public class Inventory : MonoBehaviour
    {
        public int KeysCount => _keys.Count;

        [SerializeField] private Gate _gate;

        private List<Key> _keys = new List<Key>();

        public void InitKey(Key key)
        {
            key.Taking += AddKey;
        }

        private void AddKey(Key key)
        {
            key.Taking -= AddKey;
            _keys.Add(key);
            _gate.TryOpen();
        }
    }
}
