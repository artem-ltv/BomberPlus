using System.Collections;
using UnityEngine;

namespace Bomber
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Player _player;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _delayBeforeSpawn;
        [SerializeField] private float _timeFreezeSpawn;
        [SerializeField] private EnemiesCollection _collection;

        private Coroutine _spawnCoroutine;

        public void Start()
        {
            _spawnCoroutine = StartCoroutine(Spawn(_delayBeforeSpawn));
        }

        private IEnumerator Spawn(float delay)
        {
            WaitForSeconds waitForSecond = new WaitForSeconds(delay);

            while (true)
            {
                yield return waitForSecond;

                int randomIndex = Random.Range(0, _spawnPoints.Length);
                Enemy newEnemy = Instantiate(_enemy, _spawnPoints[randomIndex].position, transform.rotation);
                _collection.Add(newEnemy);

                if (newEnemy.TryGetComponent(out EnemyMovement enemyMovement))
                {
                    enemyMovement.Init(_player);
                }
                else
                {
                    Debug.LogError("The 'EnemyMovement' component was not found");
                }
            }
        }

        public void Stop()
        {
            StopCoroutine(_spawnCoroutine);
        }

        public void Freeze()
        {
            StartCoroutine(FreezeForTime(_timeFreezeSpawn));
        }

        private IEnumerator FreezeForTime(float timeFreeze)
        {
            Stop();
            yield return new WaitForSeconds(_timeFreezeSpawn);
            _spawnCoroutine = StartCoroutine(Spawn(_delayBeforeSpawn));
        }
    }
}
