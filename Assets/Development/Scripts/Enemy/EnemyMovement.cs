using UnityEngine;
using UnityEngine.AI;

namespace Bomber
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        private Player _player;
        private NavMeshAgent _navMeshAgent;
        private bool _canMove = true;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (_canMove)
            {
                if(_player != null)
                {
                    _navMeshAgent.SetDestination(_player.transform.position);
                }
            }
        }

        public void Init(Player player)
        {
            _player = player;
        }

        public void Stop()
        {
            _canMove = false;
            _navMeshAgent.enabled = false;
        }

        public void Resume()
        {
            _canMove = true;
            _navMeshAgent.enabled = true;
        }
    }
}
