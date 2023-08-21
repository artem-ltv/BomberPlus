using UnityEngine;
using UnityEngine.UI;

namespace Bomber
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private Hint _hint;
        [SerializeField] private Timer _timer;
        [SerializeField] private GameObject[] _slides;
        [SerializeField] private Button _further;
        [SerializeField] private Audio _audioSystem;

        private int _numberOfSlide = 0;
        private string _tutorial = "Tutorial";

        private void Awake()
        {
            if (!PlayerPrefs.HasKey(_tutorial))
            {
                StartTutorial();
            }
            else
            {
                Close();
            }
        }

        private void OnEnable()
        {
            _further.onClick.AddListener(OnClickButton);
        }

        private void OnDisable()
        {
            _further.onClick.RemoveListener(OnClickButton);
        }

        private void StartTutorial()
        {
            Time.timeScale = 0f;

            SetActiveComponents(false);

            foreach (var slider in _slides)
            {
                slider.SetActive(false);
            }

            _slides[_numberOfSlide].SetActive(true);
        }

        private void OnClickButton()
        {
            _audioSystem.PlayButtonSound();
            if (_numberOfSlide < _slides.Length-1)
            {
                _numberOfSlide++;
                SwitchSlide(_numberOfSlide);
            }
            else
            {
                Close();
            }
        }

        private void SwitchSlide(int nubmerOfSlide)
        {
            _slides[nubmerOfSlide - 1].SetActive(false);
            _slides[nubmerOfSlide].SetActive(true);
        }

        private void Close()
        {
            PlayerPrefs.SetString(_tutorial, "Yes");
            SetActiveComponents(true);
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }

        private void SetActiveComponents(bool isActive)
        {
            _hint.enabled = isActive;
            _timer.enabled = isActive;
        }
    }
}
