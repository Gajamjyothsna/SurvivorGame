using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SurvivorGame.SurvivorGameDataModel;

namespace SurvivorGame
{
    public class SoundManager : MonoBehaviour
    {
        #region Singleton
        private static SoundManager _instance;

        public static SoundManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SoundManager>();
                }
                return _instance;
            }
        }
        #endregion

        [Header("Sound Clips")]
        [SerializeField] private List<SoundClip> soundClips;

        private Dictionary<SoundType, AudioClip> _soundDict;
        private AudioSource _audioSource;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }

            _audioSource = GetComponent<AudioSource>();

            _soundDict = new Dictionary<SoundType, AudioClip>();
            foreach (var soundClip in soundClips)
            {
                _soundDict[soundClip.soundType] = soundClip.audioClip;
            }
        }

        public void PlaySound(SoundType soundType)
        {
            Debug.Log("Soundtype :" + soundType);
            if (_soundDict.ContainsKey(soundType))
            {
                _audioSource.PlayOneShot(_soundDict[soundType]);
            }
            else
            {
                Debug.LogWarning("Sound type not found: " + soundType);
            }
        }

        public void PlayBackgroundMusic(AudioSource audioSource, SoundType soundType)
        {
            if (_soundDict.ContainsKey(soundType))
            {
                audioSource.clip = _soundDict[soundType];
                audioSource.loop = true;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Background music type not found: " + soundType);
            }
        }

        public void StopBackgroundMusic()
        {
            _audioSource.Stop();
        }
    }
}
