using UnityEngine;

namespace Bomber
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private VictoryRoom _victoryRoom;

        private void OnEnable()
        {
            _victoryRoom.Entering += Win;
        }

        private void Onisable()
        {
            _victoryRoom.Entering -= Win;
        }

        private void Win()
        {

        }

        private void Lose()
        {

        }
    }
}
