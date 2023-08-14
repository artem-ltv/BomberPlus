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
            Debug.Log("Win game");
        }

        private void Lose()
        {
            Debug.Log("Lose game");
        }
    }
}
