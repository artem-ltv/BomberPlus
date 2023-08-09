using UnityEngine;

namespace Bomber
{
    [RequireComponent(typeof(Bomb))]
    public class BombCollisionHandler : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        private Bomb _bomb;
        private string _floorLayerName = "Floor";

        private void Start()
        {
            _bomb = GetComponent<Bomb>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer(_floorLayerName))
            {
                var floorRenderer = collision.gameObject.GetComponent<Renderer>();

                Vector3 groundPosition = floorRenderer.bounds.center;
                Vector3 bombNextPosition = new Vector3(groundPosition.x, transform.position.y, groundPosition.z);

                _bomb.SetPosition(bombNextPosition);
                _bomb.StartExplode();
            }
        }
    }
}
