using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public class DefensiveArea : MonoBehaviour
    {
        [SerializeField] private string CoinTag;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == CoinTag)
            {
                Debug.Log("Coin is detected");
                other.gameObject.SetActive(false);
                UIController.Instance.UpdatePlayerHealth(10, true);
                UIController.Instance.UpdateCoinCollection(10);
            }
        }
    }
}
