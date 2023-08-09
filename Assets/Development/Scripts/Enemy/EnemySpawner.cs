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

        private Coroutine _spawnCoroutine;

        private void Start()
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

                if(newEnemy.TryGetComponent(out EnemyMovement enemyMovement))
                {
                    enemyMovement.Init(_player);
                }
                else
                {
                    Debug.LogError("The 'EnemyMovement' component was not found");
                }
            }
        }

        private void Stop()
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
}
