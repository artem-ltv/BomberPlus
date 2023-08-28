using UnityEngine;
using UnityEngine.UI;

namespace Bomber
{
    public class StartPanel : MonoBehaviour
    {
        [SerializeField] private Hint _hint;
        [SerializeField] private Timer _timer;
        [SerializeField] private Button _start;
        [SerializeField] private Audio _audioSystem;
        [SerializeField] private Game _game;


        private void OnEnable()
        {
            _start.onClick.AddListener(OnStartButtonClick);
        }

        private void OnDisable()
        {
            _start.onClick.RemoveListener(OnStartButtonClick);
        }
        private void Start()
        {
            SetActiveComponents(false);
            _game.Stop();
        }

        private void OnStartButtonClick()
        {
            _audioSystem.PlayButtonSound();
            SetActiveComponents(true);
            gameObject.SetActive(false);

            _game.Continue();
        }

        private void SetActiveComponents(bool isActive)
        {
            _hint.enabled = isActive;
            _timer.enabled = isActive;
        }
    }
}
