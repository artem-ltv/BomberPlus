using UnityEngine;
using UnityEngine.Events;

namespace Bomber
{
    public class VictoryRoom : MonoBehaviour
    {
        public UnityAction Entering;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {
                Entering?.Invoke();
            }
        }
    }
}
