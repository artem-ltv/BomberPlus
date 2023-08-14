using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace Bomber
{
    [RequireComponent(typeof(Collider))]
    public class RedButton : MonoBehaviour
    {
        public UnityAction Pressing;

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
                Pressing?.Invoke();
                transform.DOLocalMoveZ(_targetZ, _timeMove);
                _collider.enabled = false;
            }
        }
    }
}
