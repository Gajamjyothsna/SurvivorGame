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
        private float moveSpeed = .2f;
        private float separationDistance = 5f; // Minimum distance between enemies
        private bool canAttack = true;
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
            if (isAttacking)
                return; // Don't move if attacking
            Vector3 direction = _target.position - transform.position;
            float distance = direction.magnitude;

            if (distance > 5f)
            {
                _enemyAnimatorController.SetFloat("enemyAction", 0.25f);
                Vector3 moveDirection = GetSeparationVector() + direction.normalized;
                transform.LookAt(_target);
                transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
                isAttacking = false; // Reset attacking state when moving
            }
            else if (distance <= 5f && canAttack)
            {
                StartCoroutine(AttackAfterDelay());
            }
        }

        private Vector3 GetSeparationVector()
        {
            Vector3 separationVector = Vector3.zero;
            Collider[] nearbyEnemies = Physics.OverlapSphere(transform.position, separationDistance);
            foreach (Collider collider in nearbyEnemies)
            {
                if (collider != null && collider.transform != transform && collider.GetComponent<EnemyController>() != null)
                {
                    Vector3 awayFromEnemy = transform.position - collider.transform.position;
                    separationVector += awayFromEnemy.normalized / awayFromEnemy.magnitude;
                }
            }
            return separationVector;
        }

        private IEnumerator AttackAfterDelay()
        {
            canAttack = false; // Prevent further attacks until this coroutine finishes
            transform.LookAt(_target);
            isAttacking = true; // Set attacking state to true
            yield return new WaitForSeconds(1f);
            _enemyAnimatorController.SetFloat("enemyAction", 0.5f);
            yield return new WaitForSeconds(10f); // Time spent attacking
            ThrowFireBall();
            isAttacking = false;
            canAttack = true; // Allow attacking again
        }

        public void ThrowFireBall()
        {

            GameObject fireBallObject = ObjectPooling.Instance.SpawnFromPool(SurvivorGameDataModel.PoolObjectType.FireBall, _fireBallPoint.position, Quaternion.identity);
            if (fireBallObject != null && fireBallObject.activeInHierarchy)
            {
                fireBallObject.transform.SetParent(null); // Correctly detach from parent
                fireBallObject.GetComponent<FireballProjection>().InitializeFireBall();
                StartCoroutine(DisableFireBall(fireBallObject));
            }
        }

        private IEnumerator DisableFireBall(GameObject fireBallObject)
        {
            yield return new WaitForSeconds(3f);
            fireBallObject.SetActive(false);
        }
        #endregion
    }
}
