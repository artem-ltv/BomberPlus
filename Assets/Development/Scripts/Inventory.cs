using System.Collections.Generic;
using UnityEngine;

namespace Bomber
{
    public class Inventory : MonoBehaviour
    {
        public int KeysCount => _keys.Count;

        private List<Key> _keys = new List<Key>();

        public void AddKey(Key key)
        {
            _keys.Add(key);
        }
    }
}
