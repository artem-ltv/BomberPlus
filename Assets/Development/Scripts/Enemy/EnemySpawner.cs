using System.Collections;
using UnityEngine;

namespace Bomber
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Player _player;
        [SerializeField] private Transform[] _mainSpawnPoints;
        [SerializeField] private Transform[] _secondarySpawnPoints;
        [SerializeField] private EnemiesCollection _collection;

        private int _maxEnemies = 23;
        private Coroutine _spawnCoroutine;
        private float _minTimeFreezeSpawn = 1f;
        private float _maxTimeFreezeSpawn = 2f;
        private float _delayBeforeSpawn = 3f;

        private int _countEnemiesAdded = 2;
        private float _countSecondsTaken = 0.2f;

        public void Start()
        {
            _spawnCoroutine = StartCoroutine(Spawn(_delayBeforeSpawn));
        }

        public void Init(Key key)
        {
            key.Taking += OnTakingKey;
        }

        private void OnTakingKey(Key key)
        {
            key.Taking -= OnTakingKey;
            _maxEnemies += _countEnemiesAdded;
            _delayBeforeSpawn -= _countSecondsTaken;
            CheckEnemiesCount();
        }

        public void CheckEnemiesCount()
        {
            if (_collection.EnemiesCount >= _maxEnemies)
            {
                if (_spawnCoroutine != null)
                {
                    StopCoroutine();
                }
            }
            else
            {
                if(_spawnCoroutine == null)
                {
                    _spawnCoroutine = StartCoroutine(Spawn(_delayBeforeSpawn));
                }
            }
        }

        private IEnumerator Spawn(float delay)
        {
            WaitForSeconds waitForSecond = new WaitForSeconds(delay);
            bool isMainPoints = true;

            while (true)
            {      
                yield return waitForSecond;

                if (isMainPoints)
                {
                    CreateEnemy(_mainSpawnPoints);
                    isMainPoints = !isMainPoints;
                }
                else
                {
                    CreateEnemy(_secondarySpawnPoints);
                    isMainPoints = !isMainPoints;
                }

                CheckEnemiesCount();
            }
        }

        private void CreateEnemy(Transform[] spawnPoints)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Enemy newEnemy = Instantiate(_enemy, spawnPoints[randomIndex].position, transform.rotation);

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

        public void Stop()
        {
            if(_spawnCoroutine != null)
            {
                StopCoroutine();
            }
        }

        private void StopCoroutine()
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        public void Freeze()
        {
            float time = Random.Range(_minTimeFreezeSpawn, _maxTimeFreezeSpawn);
            StartCoroutine(FreezeForTime(time));
        }

        private IEnumerator FreezeForTime(float timeFreeze)
        {
            Stop();
            yield return new WaitForSeconds(timeFreeze);
            _spawnCoroutine = StartCoroutine(Spawn(_delayBeforeSpawn));
        }
    }
}
