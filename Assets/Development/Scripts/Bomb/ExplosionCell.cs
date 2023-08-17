using UnityEngine;
using System.Collections;

namespace Bomber
{
    [RequireComponent(typeof(Collider))]
    public class ExplosionCell : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosionEffect;
        [SerializeField] private float _delayForRemoveCollider;

        private Collider _collider;
        private int _damage = 100;

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _explosionEffect.Play();
            StartCoroutine(DisableCollider(_delayForRemoveCollider));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.Die();
            }

            if (other.gameObject.TryGetComponent(out Player player))
            {
                player.AddDamage(_damage);
            }
        }

        private IEnumerator DisableCollider(float delay)
        {
            yield return new WaitForSeconds(delay);
            _collider.enabled = false;
        }
    }
}
