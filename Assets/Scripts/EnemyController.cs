using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private Animator _enemyAnimatorController;
    #endregion

    #region Private Methods
    private void Start()
    {
        _enemyAnimatorController.SetFloat("enemyAction", 0f);
    }
    #endregion
}
