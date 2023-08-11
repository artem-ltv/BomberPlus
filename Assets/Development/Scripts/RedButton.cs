using UnityEngine;
using DG.Tweening;

namespace Bomber
{
    [RequireComponent(typeof(Collider))]
    public class RedButton : MonoBehaviour
    {
        [SerializeField] private KeySpawner _keySpawner;
        [SerializeField] private float _timeMove;

        private float _targetZ = -1.7f;
        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Player player))
            {
                transform.DOLocalMoveZ(_targetZ, _timeMove);
                _keySpawner.TrySpawn();
                _collider.enabled = false;
            }
        }
    }
}
