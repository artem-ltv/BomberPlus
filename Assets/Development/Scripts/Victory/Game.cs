using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bomber
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private VictoryRoom _victoryRoom;
        [SerializeField] private Player _player;
        [SerializeField] private HUD _hud;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemiesCollection _enemiesCollection;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Timer _timer;


        private void OnEnable()
        {
            _victoryRoom.Entering += Win;
            _player.Dying += Lose;
        }

        private void OnDisable()
        {
            _victoryRoom.Entering -= Win;
            _player.Dying -= Lose;
        }

        private void Win()
        {
            Stop();
            _hud.ShowWinPanel();
        }

        private void Lose()
        {
            Stop();
            _hud.ShowLosePanel();
        }

        public void Restart()
        {
            SceneManager.LoadScene(1);
        }

        public void Stop()
        {
            _enemySpawner.Stop();
            _enemiesCollection.TryStopMove();
            _playerMovement.Stop();
            _timer.Stop();
        }

        public void Continue()
        {
            _enemySpawner.Start();
            _enemiesCollection.TryResumeMove();
            _playerMovement.Resume();
            _timer.Resume();
        }
    }
}
