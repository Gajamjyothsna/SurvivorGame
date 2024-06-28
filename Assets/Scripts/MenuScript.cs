using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SurvivorGame
{
    public class MenuScript : MonoBehaviour
    {
        public void PlayeButtonClick()
        {
            SceneManager.LoadScene("SurvivorGame");
        }
    }
}
