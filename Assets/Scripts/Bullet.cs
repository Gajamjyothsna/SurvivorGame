using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SurvivorGame
{
    public class Bullet : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private Rigidbody _bulletRidiBody;
        [SerializeField] private float bulletSpeed = 2f;
        #endregion

        #region Public Methods
        public void InitalizeBullet(Vector3 direction, int damage)
        {
            if (_bulletRidiBody != null)
            {
                _bulletRidiBody.velocity = direction.normalized * bulletSpeed;
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("Hit Enemy");
                UIController.Instance.UpdatePlayerHealth(10, true);
                GameObject bulletPS = ObjectPooling.Instance.SpawnFromPool(SurvivorGameDataModel.PoolObjectType.BulletPS, collision.transform.position, Quaternion.identity);
                StartCoroutine(DelayPS());
                IEnumerator DelayPS()
                {
                    yield return new WaitForSeconds(1f);
                    bulletPS.SetActive(false);
                }
                gameObject.SetActive(false);
                EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.IsDead = true;
                    enemyController.DeactivePlayer();
                }
                
            }
        }

       
        #endregion
    }
}
