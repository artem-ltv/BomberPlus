using UnityEngine;

namespace Bomber
{
    public class Hint : MonoBehaviour
    {
        [SerializeField] private HUD _hud;
        [SerializeField] private RedButton _redButton;
        [SerializeField] private Gate _gate;

        private string _taskFind = "Найти";
        private string _taskExit = "Выйти в";

        private void Start()
        {
            _hud.UpdateHint(_taskFind, _redButton.Name, _redButton.Color);
        }
            
        public void GetHintToKey(Key key)
        {
            _hud.UpdateHint(_taskFind, key.Name, key.Color);
        }

        public void GetHintToGate()
        {
            _hud.UpdateHint(_taskExit, _gate.Name, _gate.Color);
        }
    }
}
