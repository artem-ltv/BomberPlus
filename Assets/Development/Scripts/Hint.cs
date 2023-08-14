using UnityEngine;

namespace Bomber
{
    public class Hint : MonoBehaviour
    {
        [SerializeField] private HUD _hud;
        [SerializeField] private Color[] _colors; 

        private string[] _tasks = { "�����", "�����", "�����", "�����", "�����", "�����", "����� �"};
        private string[] _item = { "������� ������", "����� ����", "������� ����", "���������� ����", "������� ����", "������ ����", "������ ������"};

        private int _numberOfHint = 0;

        private void Start()
        {
            _hud.UpdateHint(_tasks[_numberOfHint], _item[_numberOfHint], _colors[_numberOfHint]);
        }

        [ContextMenu("Next")]
        private void TryNext()
        {
            if((_numberOfHint <= _tasks.Length) && (_tasks.Length == _item.Length) && (_tasks.Length == _colors.Length))
            {
                _numberOfHint++;
                _hud.UpdateHint(_tasks[_numberOfHint], _item[_numberOfHint], _colors[_numberOfHint]);
            }
        }
    }
}