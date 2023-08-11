using UnityEngine;

namespace Bomber
{
    public class VictoryRoom : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Player player))
            {

            }
        }
    }
}
