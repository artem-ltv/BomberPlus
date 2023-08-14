using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bomber
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _mainMenu;
        [SerializeField] private Game _game;
        [SerializeField] private Timer _timer;
        [SerializeField] private TMP_Text _bestTimeDisplay;


        private void OnEnable()
        {
            _restart.onClick.AddListener(OnClickRestartGame);
        }

        private void OnDisable()
        {
            _restart.onClick.RemoveListener(OnClickRestartGame);
        }

        private void OnClickRestartGame()
        {
            _game.Restart();
        }
    }
}
