using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Bomber
{
    public class LosePanel : MonoBehaviour
    {
        [SerializeField] private Button _ads;
        [SerializeField] private Button _restart;
        [SerializeField] private Button _continue;
        [SerializeField] private Button _mainMenu;
        [SerializeField] private Image _adsImage;
        [SerializeField] private float _timeForContinue;
        [SerializeField] private Game _game;

        private Coroutine _filling;
        private float _startFillImageValue = 1f;

        private void OnEnable()
        {
            _ads.onClick.AddListener(OnClickAds);
            _continue.onClick.AddListener(OnClickContinueGame);
            _restart.onClick.AddListener(OnClickRestartGame);
        }

        private void OnDisable()
        {
            _ads.onClick.RemoveListener(OnClickAds);
            _continue.onClick.RemoveListener(OnClickContinueGame);
            _restart.onClick.RemoveListener(OnClickRestartGame);
        }

        private void Start()
        {
            SetActiveButtons(false, _restart, _continue);
            _filling = StartCoroutine(ImageFilling(_startFillImageValue, 0f,_timeForContinue, EnableRestart));
        }

        public void OnClickAds()
        {
            StopImageFilling();

            SetActiveButtons(true, _continue);
            SetActiveButtons(false, _ads, _restart);
        }

        private IEnumerator ImageFilling(float startValue, float endValue, float duration, UnityAction action)
        {
            float elapsed = 0;
            float nextValue;

            while(elapsed < duration)
            {
                nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
                _adsImage.fillAmount = nextValue;
                elapsed += Time.deltaTime;
                yield return null;
            }

            SetActiveButtons(false, _ads);
            action?.Invoke();
        }

        private void StopImageFilling()
        {
            StopCoroutine(_filling);
        }

        private void EnableRestart()
        {
            SetActiveButtons(false, _continue);
            SetActiveButtons(true, _restart);
        }

        private void OnClickContinueGame()
        {
            SetActiveButtons(false, _continue, _ads);
            SetActiveButtons(true, _restart);

            _game.Continue();

            gameObject.SetActive(false);
        }

        private void OnClickRestartGame()
        {
            _game.Restart();
        }

        private void SetActiveButtons(bool isActive, params Button[] buttons)
        {
            foreach(var button in buttons)
            {
                button.gameObject.SetActive(isActive);
            }
        }
    }
}
