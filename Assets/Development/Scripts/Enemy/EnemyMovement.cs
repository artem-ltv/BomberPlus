using UnityEngine;
using UnityEngine.AI;

namespace Bomber
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(_player != null)
            {
                _navMeshAgent.SetDestination(_player.transform.position);
            }
        }

        public void Init(Player player)
        {
            _player = player;
        }
    }
}
