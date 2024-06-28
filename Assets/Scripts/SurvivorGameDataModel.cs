using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public static class SurvivorGameDataModel
    {
        #region PoolClass
        [System.Serializable]
        public enum PoolObjectType
        {
            FireBall,
            Enemy,
            Bullet,
            Coin
        }

        [System.Serializable]
        public class Pool
        {
            public int capacity;
            public GameObject poolGameObject;
            public PoolObjectType PoolObjectType;
        }
        #endregion

        #region Game States
        [System.Serializable]
        public enum  GameState
        {
            Playing,
            GameOver
        }
        #endregion

        #region SoundClass
        [System.Serializable]
        public class SoundClip
        {
            public SoundType soundType;
            public AudioClip audioClip;
        }

        [System.Serializable]
        public enum SoundType
        {
            PlayerWalk,
            PlayerHurt,
            PlayerDie,
            EnemyDie,
            EnemyHit,
            BackGroundMusic,
            CoinCollect,
            PlayerHit
        }
        #endregion
    }
}
