using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace Bomber
{
    public class RedButton : MonoBehaviour
    {
        public UnityAction KeyGenerating; 

        [SerializeField] private float _timeMove;

        private float _targetZ = 6.3f;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Player player))
            {
                transform.DOMoveZ(_targetZ, _timeMove);
                KeyGenerating?.Invoke();
            }
        }

        private void Generate()
        {

        }
    }
}
