using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public class Coin : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private int increasePlayerHealth = 10;
        #endregion
        #region Private Methods
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                if (collision.gameObject.tag == "Player")
                {
                    // Handle collision with the player or other default layer objects
                    Debug.Log("Bullet hit: " + collision.gameObject.name);
                    // Apply damage or other effects here
                    UIController.Instance.UpdatePlayerHealth(10, true);
                    // Disable or destroy the bullet
                    gameObject.SetActive(false);
                }
            }
        }
        #endregion
    }
}
