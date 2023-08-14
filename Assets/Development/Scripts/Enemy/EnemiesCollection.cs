using System.Collections.Generic;
using UnityEngine;

namespace Bomber
{
    public class EnemiesCollection : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemies;

        public void Add(Enemy enemy)
        {
            enemy.Dying += Remove;
            _enemies.Add(enemy);
        }

        private void Remove(Enemy enemy)
        {
            enemy.Dying -= Remove;
            _enemies.Remove(enemy);
        }

        public void TryStopMove()
        {
            foreach(var enemy in _enemies)
            {
                if(enemy != null)
                {
                    if(enemy.TryGetComponent(out EnemyMovement enemyMovement))
                    {
                        enemyMovement.Stop();
                    }
                    else
                    {
                        Debug.LogError("The 'EnemyMovement' component was not found");
                    }
                }
            }
        }

        public void TryResumeMove()
        {
            foreach (var enemy in _enemies)
            {
                if (enemy != null)
                {
                    if (enemy.TryGetComponent(out EnemyMovement enemyMovement))
                    {
                        enemyMovement.Resume();
                    }
                    else
                    {
                        Debug.LogError("The 'EnemyMovement' component was not found");
                    }
                }
            }
        }
    }
}
