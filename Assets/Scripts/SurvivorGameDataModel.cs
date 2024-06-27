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

    }
}
