using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Bomber
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _start;

        private void OnEnable()
        {
            _start.onClick.AddListener(StartGame);
        }

        private void OnDisable()
        {
            _start.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
