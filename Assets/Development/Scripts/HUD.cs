using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Bomber
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private Button _freeze;
        [SerializeField] private EnemySpawner _enemySpawner;

        private float _timeRestartButton = 15f;

        private void OnEnable()
        {
            _freeze.onClick.AddListener(FreezeEnemySpawn);
        }

        private void OnDisable()
        {
            _freeze.onClick.RemoveListener(FreezeEnemySpawn);
        }

        private void FreezeEnemySpawn()
        {
            _enemySpawner.Freeze();
            StartCoroutine(RestartButton(_freeze, _timeRestartButton));
        }

        private IEnumerator RestartButton(Button button, float time)
        {
            button.interactable = false;
            yield return new WaitForSeconds(time);
            button.interactable = true;
        }
    }
}
