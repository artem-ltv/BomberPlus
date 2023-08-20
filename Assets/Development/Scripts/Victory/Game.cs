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
        [SerializeField] private BombThrowing _bombThrowing;
        [SerializeField] private PlayerInput _input;

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

        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        public void Stop()
        {
            _enemySpawner.Stop();
            _enemiesCollection.TryStopMove();
            _playerMovement.Stop();
            _timer.Stop();
            _bombThrowing.SetPossible(false);
            _input.SetAciveJoystick(false);
        }

        public void Continue()
        {
            Time.timeScale = 1f;
            _hud.HideAllPanels();
            _enemySpawner.Start();
            _enemiesCollection.TryResumeMove();
            _playerMovement.Resume();
            _timer.Resume();
            _bombThrowing.SetPossible(true);
            _input.SetAciveJoystick(true);
        }

        public void Pause()
        {
            Stop();
            Time.timeScale = 0f;
            _hud.ShowPausePanel(true);
        }

        private void Win()
        {
            Stop();
            _hud.ShowWinPanel(true);
        }

        private void Lose()
        {
            Stop();
            _hud.ShowLosePanel(true);
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
