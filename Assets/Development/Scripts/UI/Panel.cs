using UnityEngine;
using UnityEngine.UI;

namespace Bomber
{
    public abstract class Panel : MonoBehaviour
    {
        [SerializeField] protected Button Restart;
        [SerializeField] protected Button MainMenu;
        [SerializeField] protected Game Game;

        private void OnClickMainMenu()
        {
            Game.GoToMainMenu();
        }

        private void OnClickRestartGame()
        {
            Game.Restart();
        }

        protected virtual void AddButtonsEvents()
        {
            Restart.onClick.AddListener(OnClickRestartGame);
            MainMenu.onClick.AddListener(OnClickMainMenu);
        }

        protected virtual void RemoveButtonsEvents()
        {
            Restart.onClick.RemoveListener(OnClickRestartGame);
            MainMenu.onClick.RemoveListener(OnClickMainMenu);
        }
    }
}
