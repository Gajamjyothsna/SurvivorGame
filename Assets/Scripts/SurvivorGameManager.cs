using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SurvivorGame.SurvivorGameDataModel;

namespace SurvivorGame
{
    public class SurvivorGameManager : MonoBehaviour
    {
        #region Singleton
        private static SurvivorGameManager _instance;

        public static SurvivorGameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SurvivorGameManager>();
                }
                return _instance;
            }
        }
        #endregion

        public GameState CurrentGameState { get; private set; } = GameState.Playing;
        public Action<GameState> OnGameStateChanged;

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
        }

        public void SetGameOver()
        {
            CurrentGameState = GameState.GameOver;
            OnGameStateChanged?.Invoke(GameState.GameOver);
        }

        public void SetPlayAgain()
        {
            CurrentGameState = GameState.Playing;
        }

    }
}
