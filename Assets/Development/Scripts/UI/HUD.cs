using System.Collections;
using TMPro;
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
        [SerializeField] private TMP_Text _timerDisplay;
        [SerializeField] private TMP_Text _hintTaskDisplay;
        [SerializeField] private TMP_Text _hintItemDisplay;

        private float _timeRestartButton = 120f;

        private void OnEnable()
        {
            _freeze.onClick.AddListener(FreezeEnemySpawn);
        }

        private void OnDisable()
        {
            _freeze.onClick.RemoveListener(FreezeEnemySpawn);
        }

        public void UpdateTimerValue(float value)
        {
            _timerDisplay.text = value.ToString("F2");
        }

        public void UpdateHint(string task, string item, Color color)
        {
            _hintTaskDisplay.text = task;
            _hintItemDisplay.text = item;
            _hintItemDisplay.color = color;
        }

        public void ShowLosePanel()
        {
            _losePanel.SetActive(true);
        }

        public void ShowWinPanel()
        {
            _winPanel.SetActive(true);
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
