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
        private float _effectPostionY = 2f;

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _explosionEffect.Play();
            //Instantiate(_explosionEffect, new Vector3(gameObject.transform.position.x, _effectPostionY, gameObject.transform.position.z), Quaternion.identity);
            StartCoroutine(DisableCollider(_delayForRemoveCollider));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.Die();
            }

            //if (other.gameObject.TryGetComponent(out Player player))
            //    player.Die();
        }

        private IEnumerator DisableCollider(float delay)
        {
            yield return new WaitForSeconds(delay);
            _collider.enabled = false;
        }
    }
}
