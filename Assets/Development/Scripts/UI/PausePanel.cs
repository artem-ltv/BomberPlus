using UnityEngine;
using UnityEngine.UI;

namespace Bomber
{
    public class PausePanel : Panel
    {
        [SerializeField] private Button _continue;

        private void OnEnable()
        {
            base.AddButtonsEvents();
            _continue.onClick.AddListener(OnClickContinueGame);
        }

        private void OnDisable()
        {
            base.RemoveButtonsEvents();
            _continue.onClick.RemoveListener(OnClickContinueGame);
        }

        private void OnClickContinueGame()
        {
            Game.Continue();
        }
    }
}
