using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveArea : MonoBehaviour
{
    [SerializeField] private string EnemyTag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == EnemyTag)
        {
            Debug.Log("Enemy is detected");
        }
    }
}
