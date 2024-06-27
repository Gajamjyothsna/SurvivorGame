using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public class Coin : MonoBehaviour
    {
        #region Private Methods
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
                //Increase the Player Health;
            }
        }
        #endregion
    }
}
