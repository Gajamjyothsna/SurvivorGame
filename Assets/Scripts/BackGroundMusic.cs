using SurvivorGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public class BackGroundMusic : MonoBehaviour
    {
        private AudioSource audioSource;
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            if (SurvivorGameManager.Instance.CurrentGameState == SurvivorGameDataModel.GameState.GameOver) audioSource.Stop();
            PlayBackgroundMusic();
        }

        public void PlayBackgroundMusic()
        {
            // Assuming SoundManager has a method called PlayClip which takes an AudioSource and a clip name
            SoundManager.Instance.PlayBackgroundMusic(audioSource, SurvivorGameDataModel.SoundType.BackGroundMusic);
        }
    }
}
