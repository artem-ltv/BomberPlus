using UnityEngine;

namespace Bomber
{
    public class CameraFollowing : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Vector3 _offset;

        private Vector3 _targetPosition;

        private void Update()
        {
            _targetPosition = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, _player.position.z + _offset.z);
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }
}
