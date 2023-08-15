using UnityEngine;
using UnityEngine.UI;

namespace Bomber
{
    public abstract class Panel : MonoBehaviour
    {
        [SerializeField] protected Button Restart;
        [SerializeField] protected Button MainMenu;
        [SerializeField] protected Game Game;

        private void Start()
        {
            Restart.onClick.AddListener(OnClickRestartGame);
            //MainMenu.onClick.AddListener(OnClickMainMenu);
        }

        private void OnDisable()
        {
            Restart.onClick.RemoveListener(OnClickRestartGame);
            //MainMenu.onClick.RemoveListener(OnClickMainMenu);
        }

        private void OnClickMainMenu()
        {
            Game.GoToMainMenu();
        }

        private void OnClickRestartGame()
        {
            Game.Restart();
        }
    }
}
