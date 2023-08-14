using UnityEngine;

namespace Bomber
{
    [RequireComponent(typeof(Player))]
    public class PlayerCollisionHandler : MonoBehaviour
    {
        private Player _player;

        private void Start()
        {
            _player = GetComponent<Player>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                _player.AddDamage(enemy.Damage);
                enemy.Die();
            }
        }
    }
}
