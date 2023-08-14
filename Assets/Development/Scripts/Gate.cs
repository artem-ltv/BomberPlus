using UnityEngine;
using DG.Tweening;

namespace Bomber
{
    public class Gate : MonoBehaviour
    {
        public Color Color => _color;
        public string Name => _name;

        [SerializeField] private Color _color;
        [SerializeField] private string _name;
        [SerializeField] private KeySpawner _keySpawner;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private float _timeForOpen;
        [SerializeField] private Transform _leftGate;
        [SerializeField] private Transform _rightGate;
        [SerializeField] private Hint _hint;

        private float _rightGateTargetX = -6f;
        private float _leftGateTargetX = 6f;

        public void TryOpen()
        {
            if (_inventory.KeysCount == _keySpawner.MaxKeys)
            {
                Move();
                _hint.GetHintToGate();
            }
        }

        private void Move()
        {
            _leftGate.DOLocalMoveX(_leftGateTargetX, _timeForOpen).SetEase(Ease.Linear);
            _rightGate.DOLocalMoveX(_rightGateTargetX, _timeForOpen).SetEase(Ease.Linear);
        }
    }
}
