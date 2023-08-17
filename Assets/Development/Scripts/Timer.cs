using UnityEngine;

namespace Bomber
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private HUD _hud;

        private float _startTime = 0f;
        private bool _isTimerOn = true;

        private void Start()
        {
            _hud.UpdateTimer(_startTime);
        }

        private void Update()
        {
            if (_isTimerOn)
            {
                _startTime += Time.deltaTime;
                _hud.UpdateTimer(_startTime);
            }
        }

        public void Stop()
        {
            _isTimerOn = false;
        }

        public void Resume()
        {
            _isTimerOn = true;
        }

        public float GetTime() 
        {
            return _startTime;
        }
    }
}
