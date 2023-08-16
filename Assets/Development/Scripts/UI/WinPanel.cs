using TMPro;
using UnityEngine;

namespace Bomber
{
    public class WinPanel : Panel
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private TMP_Text _bestTimeDisplay;

        private void OnEnable()
        {
            base.AddButtonsEvents();
        }

        private void OnDisable()
        {
            base.RemoveButtonsEvents();
        }

        private void Start()
        {
            _bestTimeDisplay.text = $": {_timer.GetTime():F2}";
        }
    }
}
