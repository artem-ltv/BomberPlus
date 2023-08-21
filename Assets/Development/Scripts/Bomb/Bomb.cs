using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace Bomber
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _explodeDelay;
        
        private Audio _audioSystem;

        private BombExplosion _explosion;
        private float _timeForMovePosition = 0.5f;

        private void Start()
        {
            _audioSystem.PlayWickSound();
        }

        public void Init(BombExplosion explosion, Audio audio)
        {
            _explosion = explosion;
            _audioSystem = audio;
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
            _audioSystem.StopWickSound();
            _explosion.Launch(this);
            gameObject.SetActive(false);
        }
    }
}
