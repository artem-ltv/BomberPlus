using UnityEngine;

namespace Bomber
{
    public class BombThrowing : MonoBehaviour
    {
        public bool CanThrow => _canThrow;

        [SerializeField] private Transform _throwPoint;
        [SerializeField] private Bomb _bomb;
        [SerializeField] private BombExplosion _bombExplosion;

        private bool _canThrow = true;

        public void Throw()
        {
            Bomb newBomb = Instantiate(_bomb, _throwPoint.position, Quaternion.identity);
            newBomb.Init(_bombExplosion);
        }

        public void SetPossible(bool isPossible)
        {
            _canThrow = isPossible;
        }
    }
}
