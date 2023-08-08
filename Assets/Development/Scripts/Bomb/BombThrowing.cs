using UnityEngine;

namespace Bomber
{
    public class BombThrowing : MonoBehaviour
    {
        [SerializeField] private Transform _throwPoint;
        [SerializeField] private Bomb _bomb;
        [SerializeField] private BombExplosion _bombExplosion;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Bomb newBomb = Instantiate(_bomb, _throwPoint.position, Quaternion.identity);
                newBomb.Init(_bombExplosion);
            }
        }
    }
}
