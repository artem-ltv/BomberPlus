using TMPro;
using UnityEngine;

namespace Bomber
{
    public class WinPanel : Panel
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private TMP_Text _bestTimeDisplay;

        private string _bestTime = "Время прохождения:";

        private void Start()
        {
            _bestTimeDisplay.text = $"{_bestTime} {_timer.GetTime():F2}";
        }
    }
}
