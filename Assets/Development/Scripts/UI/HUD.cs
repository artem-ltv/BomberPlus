using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Bomber
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private Button _freeze;
        [SerializeField] private Button _throwBomb;
        [SerializeField] private Button _muteSound;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private TMP_Text _timerDisplay;
        [SerializeField] private TMP_Text _hintTaskDisplay;
        [SerializeField] private TMP_Text _hintItemDisplay;
        [SerializeField] private TMP_Text _healthDisplay;
        [SerializeField] private Image _damage;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Audio _audioSystem;
        [SerializeField] private Sprite[] _muteSoundSprites;

        private Image _muteSoundImage;
        private float _timeRestartButton = 120f;
        private float _targetAlpha = 0.7f;
        private float _timeAnimation = 0.25f;


        private void OnEnable()
        {
            _freeze.onClick.AddListener(FreezeEnemySpawn);
            _throwBomb.onClick.AddListener(OnClickThrowBomb);
            _muteSound.onClick.AddListener(OnClickMuteSound);
        }

        private void OnDisable()
        {
            _freeze.onClick.RemoveListener(FreezeEnemySpawn);
            _throwBomb.onClick.RemoveListener(OnClickThrowBomb);
            _muteSound.onClick.RemoveListener(OnClickMuteSound);
        }

        public void UpdateTimer(float time)
        {
            _timerDisplay.text = time.ToString("F2");
        }

        public void UpdateHint(string task, string item, Color color)
        {
            _hintTaskDisplay.text = task;
            _hintItemDisplay.text = item;
            _hintItemDisplay.color = color;
        }

        public void UpdateHealth(int health)
        {
            _healthDisplay.text = health.ToString();
        }

        public void ShowLosePanel(bool isShow)
        {
            _losePanel.SetActive(isShow);
        }

        public void ShowWinPanel(bool isShow)
        {
            _winPanel.SetActive(isShow);
        }

        public void ShowPausePanel(bool isShow)
        {
            _pausePanel.SetActive(isShow);
        }

        public void ShowDamageFrame()
        {
            _damage.DOFade(_targetAlpha, _timeAnimation).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
        }

        public void HideAllPanels()
        {
            ShowLosePanel(false);
            ShowWinPanel(false);
            ShowPausePanel(false);
        }

        private void FreezeEnemySpawn()
        {
            _enemySpawner.Freeze();
            _audioSystem.PlayFreezeSound();
            StartCoroutine(RestartButton(_freeze, _timeRestartButton));
        }

        private void OnClickMuteSound()
        {
            _audioSystem.PlayButtonSound();
            _audioSystem.MuteAll(!_audioSystem.IsMute);

            UpdateSpriteMuteSound();
        }

        public void UpdateSpriteMuteSound()
        {
            if(_muteSound.TryGetComponent(out _muteSoundImage))
            {
                if (_audioSystem.IsMute)
                {
                    _muteSoundImage.sprite = _muteSoundSprites[0];
                }
                else
                {
                    _muteSoundImage.sprite = _muteSoundSprites[1];
                }
            }
        }

        private void OnClickThrowBomb()
        {
            _audioSystem.PlayButtonSound();
            _input.TryBombThrow();
        }

        private IEnumerator RestartButton(Button button, float time)
        {
            button.interactable = false;
            yield return new WaitForSeconds(time);
            button.interactable = true;
        }
    }
}
