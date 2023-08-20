using UnityEngine;
using UnityEngine.UI;

namespace Bomber
{
    public abstract class Panel : MonoBehaviour
    {
        [SerializeField] protected Button Restart;
        [SerializeField] protected Game Game;

        private void OnClickRestartGame()
        {
            Game.Restart();
        }

        protected virtual void AddButtonsEvents()
        {
            Restart.onClick.AddListener(OnClickRestartGame);
        }

        protected virtual void RemoveButtonsEvents()
        {
            Restart.onClick.RemoveListener(OnClickRestartGame);
        }
    }
}
