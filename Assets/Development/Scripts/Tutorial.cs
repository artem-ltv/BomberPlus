using UnityEngine;
using UnityEngine.UI;

namespace Bomber
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField] private GameObject[] _slides;
        [SerializeField] private Button _further;
        [SerializeField] private Audio _audioSystem;
        [SerializeField] private StartPanel _startPanel;

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
            gameObject.SetActive(false);

            _startPanel.gameObject.SetActive(true);

            Time.timeScale = 1f;
        }
    }
}
