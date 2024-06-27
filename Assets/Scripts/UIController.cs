using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public class UIController : MonoBehaviour
    {
        #region Creating Instance
        public static UIController Instance { get; private set; }
        #endregion

        #region Private Variables
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        #endregion
    }

}
