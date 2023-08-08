using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace Bomber
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _explodeDelay;
        
        private BombExplosion _explosion;
        private float _timeForMovePosition = 0.5f;


        public void Init(BombExplosion explosion)
        {
            _explosion = explosion;
        }

        public void SetPosition(Vector3 position)
        {
            transform.DOMove(position, _timeForMovePosition);
        }

        public void StartExplode()
        {
            StartCoroutine(Explode(_explodeDelay));
        }

        private IEnumerator Explode(float delay)
        {
            yield return new WaitForSeconds(delay);
            _explosion.Launch(this);
            gameObject.SetActive(false);
        }
    }
}
