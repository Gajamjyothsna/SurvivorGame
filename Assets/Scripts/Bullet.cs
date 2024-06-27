using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                if (gameObject.activeInHierarchy)
                {
                    gameObject.SetActive(false);
                    collision.gameObject.SetActive(false);
                    GameObject obj = ObjectPooling.Instance.SpawnFromPool(SurvivorGameDataModel.PoolObjectType.Coin, collision.transform.position, Quaternion.identity);
                }
            }
        }
        #endregion
    }
}