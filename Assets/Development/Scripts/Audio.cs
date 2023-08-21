using UnityEngine;

namespace Bomber
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private AudioSource _button;
        [SerializeField] private AudioSource _background;
        [SerializeField] private AudioSource _winGame;
        [SerializeField] private AudioSource _loseGame;
        [SerializeField] private AudioSource _wick;
        [SerializeField] private AudioSource _explosion;

        [SerializeField] private AudioClip _buttonSound;
        [SerializeField] private AudioClip _wickSound;
        [SerializeField] private AudioClip _explosionSound;

        private void Start()
        {
            PlayBackgroundSound();
        }

        private void PlayBackgroundSound()
        {
            _background.Play();
        }

        public void PlayButtonSound()
        {
            _button.PlayOneShot(_buttonSound);
        }

        public void PlayWinGameSound()
        {
            _winGame.Play();
        }

        public void PlayLoseGameSound()
        {
            _loseGame.Play();
        }

        public void PlayWickSound()
        {
            _wick.Play();
        }

        public void PlayExplosiobSound()
        {
            _explosion.PlayOneShot(_explosionSound);
        }

        public void StopWickSound()
        {
            _wick.Stop();
        }
    }
}
