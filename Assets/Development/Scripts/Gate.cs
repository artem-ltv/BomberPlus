using UnityEngine;
using DG.Tweening;

namespace Bomber
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private float _timeForOpen;
        [SerializeField] private Transform _leftGate;
        [SerializeField] private Transform _rightGate;

        private float _rightGateTargetX = -6f;
        private float _leftGateTargetX = 6f;

        private void Open()
        {
            _leftGate.DOLocalMoveX(_leftGateTargetX, _timeForOpen).SetEase(Ease.Linear);
            _rightGate.DOLocalMoveX(_rightGateTargetX, _timeForOpen).SetEase(Ease.Linear);
        }
    }
}
