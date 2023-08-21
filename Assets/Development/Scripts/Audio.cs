using System;
using UnityEngine;

namespace Bomber
{
    public class Audio : MonoBehaviour
    {
        public bool IsMute => _isMute;

        [SerializeField] private AudioSource _button;
        [SerializeField] private AudioSource _freeze;
        [SerializeField] private AudioSource _background;
        [SerializeField] private AudioSource _winGame;
        [SerializeField] private AudioSource _loseGame;
        [SerializeField] private AudioSource _wick;
        [SerializeField] private AudioSource _explosion;
        [SerializeField] private AudioSource _damage;
        [SerializeField] private AudioSource _taking;

        [SerializeField] private AudioClip _buttonSound;
        [SerializeField] private AudioClip _freezeSound;
        [SerializeField] private AudioClip _wickSound;
        [SerializeField] private AudioClip _explosionSound;
        [SerializeField] private AudioClip _damageSound;
        [SerializeField] private AudioClip _takingSound;


        [SerializeField] private HUD _hud; 

        private string _muteSound = "Mute";
        private bool _isMute;

        private void Start()
        {
            if(PlayerPrefs.GetInt(_muteSound) == 1)
            {
                _isMute = true;
            }
            else
            {
                _isMute = false;
            }

            MuteAll(_isMute);
            PlayBackgroundSound();
            _hud.UpdateSpriteMuteSound();
        }

        private void PlayBackgroundSound()
        {
            _background.Play();
        }

        public void PlayButtonSound()
        {
            _button.PlayOneShot(_buttonSound);
        }

        public void PlayFreezeSound()
        {
            _freeze.PlayOneShot(_freezeSound);
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

        public void PlayDamageSound()
        {
            _damage.PlayOneShot(_damageSound);
        }

        public void PlayTakingSound()
        {
            _taking.PlayOneShot(_takingSound);
        }

        public void MuteAll(bool isMute)
        {
            _button.mute = isMute;
            _freeze.mute = isMute;
            _background.mute = isMute;
            _winGame.mute = isMute;
            _loseGame.mute = isMute;
            _wick.mute = isMute;
            _explosion.mute = isMute;
            _damage.mute = isMute;
            _taking.mute = isMute;

            _isMute = isMute;
            int value = Convert.ToInt32(isMute);
            PlayerPrefs.SetInt(_muteSound, value);
        }
    }
}
