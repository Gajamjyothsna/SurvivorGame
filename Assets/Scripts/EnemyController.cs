using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public class EnemyController : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private Animator _enemyAnimatorController;
        [SerializeField] private Transform _fireBallPoint;
        private Transform _target;
        private bool isAttacking = false; // To track if the enemy is currently attacking
        #endregion

        #region Private Methods
        private void Start()
        {
            _target = GameObject.Find("Player").transform;
            _enemyAnimatorController.SetFloat("enemyAction", 0f);
        }

        private void Update()
        {
            MoveTowardsPlayer();
        }

        private void MoveTowardsPlayer()
        {
            Vector3 direction = _target.position - transform.position;
            float distance = direction.magnitude;

            if (distance > 5f)
            {
                _enemyAnimatorController.SetFloat("enemyAction", 0.25f);
                transform.LookAt(_target);
                transform.position = Vector3.MoveTowards(transform.position, _target.position, 2 * Time.deltaTime);
                isAttacking = false; // Reset attacking state when moving
            }
            else if (distance <= 5f && !isAttacking)
            {
                StartCoroutine(AttackAfterDelay());
            }
        }

        private IEnumerator AttackAfterDelay()
        {
            isAttacking = true; // Set attacking state to true
            yield return new WaitForSeconds(5f);

            GameObject fireBallObject = ObjectPooling.Instance.SpawnFromPool(SurvivorGameDataModel.PoolObjectType.FireBall, _fireBallPoint.position, Quaternion.identity);
            if (fireBallObject != null)
            {
                _enemyAnimatorController.SetFloat("enemyAction", 0.5f);
                fireBallObject.GetComponent<FireballProjection>().InitializeFireBall();
            }

            yield return new WaitForSeconds(1f); // Optional: Additional wait time after attack before moving again
            isAttacking = false; // Reset attacking state after the attack
        }
        #endregion
    }
}
