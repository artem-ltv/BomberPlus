using UnityEngine;

namespace Bomber
{
    public class Hint : MonoBehaviour
    {
        [SerializeField] private HUD _hud;
        [SerializeField] private RedButton _redButton;
        [SerializeField] private Color[] _colors; 

        private string[] _tasks = { "Найти", "Найти", "Найти", "Найти", "Найти", "Найти", "Выйти в"};
        private string[] _item = { "красную кнопку", "синий ключ", "зеленый ключ", "фиолетовый ключ", "красный ключ", "желтый ключ", "желтые ворота"};

        private int _numberOfHint = 0;

        private void OnEnable()
        {
            _redButton.Pressing += TryNext;
        }

        private void OnDisable()
        {
            _redButton.Pressing -= TryNext;
        }

        private void Start()
        {
            _hud.UpdateHint(_tasks[_numberOfHint], _item[_numberOfHint], _colors[_numberOfHint]);
        }
            
        public void TryNext()
        {
            if((_numberOfHint <= _tasks.Length) && (_tasks.Length == _item.Length) && (_tasks.Length == _colors.Length))
            {
                _numberOfHint++;
                _hud.UpdateHint(_tasks[_numberOfHint], _item[_numberOfHint], _colors[_numberOfHint]);
            }
        }
    }
}
