using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Bomber
{
    public class BombExplosion : MonoBehaviour
    {
        [SerializeField] private GameObject _explosionObject;
        [SerializeField] private float _explosionLength;
        [SerializeField] private float _lifetimeExplosion;
        [SerializeField] private LayerMask _layerMaskWall;

        private List<Vector3> CellsForExplodeForward;
        private List<Vector3> CellsForExplodeBackward;
        private List<Vector3> CellsForExplodeRight;
        private List<Vector3> CellsForExplodeLeft;

        private Bomb _bomb;
        private float _explosionLengthUnit;

        int _cellWidth = 4;
        int _halfCellWidth;

        private void Start()
        {
            _explosionLengthUnit = _explosionLength * _cellWidth;
            _halfCellWidth = _cellWidth / 2;
        }

        public void Launch(Bomb bomb)
        {
            _bomb = bomb;

            Calculate(CellsForExplodeForward, _bomb.transform.forward);
            Calculate(CellsForExplodeBackward, _bomb.transform.forward * -1);
            Calculate(CellsForExplodeRight, _bomb.transform.right);
            Calculate(CellsForExplodeLeft, _bomb.transform.right * -1);
        }

        private void Calculate(List<Vector3> lineExplosion, Vector3 direction)
        {
            lineExplosion = new List<Vector3>();

            for (int i = _halfCellWidth; i <= _explosionLengthUnit + _halfCellWidth; i += _cellWidth)
            {
                RaycastHit hit;
                Ray ray = new Ray(_bomb.transform.position, direction);

                if (Physics.Raycast(ray, out hit, (float)i, _layerMaskWall))
                    break;

                else
                {
                    Playback(lineExplosion, direction, i);
                }
            }
        }

        private void Playback(List<Vector3> lineExplosion, Vector3 direction, int step)
        {
            if (direction == _bomb.transform.forward)
                AddExplosionPoint(lineExplosion, 0, (step - _halfCellWidth));

            if (direction == _bomb.transform.forward * -1)
                AddExplosionPoint(lineExplosion, 0, -(step - _halfCellWidth));

            if (direction == _bomb.transform.right)
                AddExplosionPoint(lineExplosion, (step - _halfCellWidth), 0);

            if (direction == _bomb.transform.right * -1)
                AddExplosionPoint(lineExplosion, -(step - _halfCellWidth), 0);

            foreach (var item in lineExplosion)
            {
                GameObject objectExplosion = Instantiate(_explosionObject, item, Quaternion.identity);
                StartCoroutine(Delete(objectExplosion, _lifetimeExplosion));
            }
        }

        private void AddExplosionPoint(List<Vector3> lineExplosion, float stepX, float stepZ)
        {
            lineExplosion.Add(new Vector3(_bomb.transform.position.x + stepX, _bomb.transform.position.y, _bomb.transform.position.z + stepZ));
        }

        private IEnumerator Delete(GameObject objectExplode, float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(objectExplode);
        }
    }
}
