using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SurvivorGame.SurvivorGameDataModel;

namespace SurvivorGame
{
    public class PlayerController : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private Animator playerAnimatorController;
        [SerializeField] private VariableJoystick joystick;
        [SerializeField] private Canvas inputCanvas;
        [SerializeField] private GameObject _playerWeapon;
        [SerializeField] private Transform _bulletPoint;
        [SerializeField] private int damage;

        private bool isJoystick;
        private bool isAttacking;
        private bool isWalkingSoundPlaying;
        private AudioSource _audioSource;
        #endregion

        #region Private Variables

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            EnableJoyStickInput();
        }
        private void EnableJoyStickInput()
        {
            isJoystick = true;
            inputCanvas.gameObject.SetActive(true);
        }
        void Update()
        {
            if (SurvivorGameManager.Instance.CurrentGameState == GameState.GameOver) return;
            if (isJoystick)
            {
                Vector3 movement = new Vector3(joystick.Direction.x, 0, joystick.Direction.y) * 1 * Time.deltaTime;
                if (movement.magnitude > 0)
                {
                    playerAnimatorController.SetFloat("playerMove", 1f);
                    // Rotate the player to face the direction of movement
                    Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
                    // Adjust rotation speed as needed
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 100 * Time.deltaTime);

                    // Play the walking sound if not already playing
                    if (!isWalkingSoundPlaying)
                    {
                        SoundManager.Instance.PlaySound(_audioSource, SoundType.PlayerWalk);
                        isWalkingSoundPlaying = true;
                    }
                }
                if (movement.magnitude == 0)
                {
                    playerAnimatorController.SetFloat("playerMove", 0);
                }
                transform.Translate(movement, Space.World);
            }
        }

        public void Attack()
        {
            Debug.Log("Attack");
            isAttacking = true;
            _playerWeapon.SetActive(true);
            isJoystick = false;
            playerAnimatorController.SetBool("isAttacking", true);
            StartCoroutine(ResetAttackState());
        }

        private IEnumerator ResetAttackState()
        {
            yield return new WaitForSeconds(.5f);
            FireBullet();
            // Wait for the attack animation to complete
            yield return new WaitForSeconds(.5f); // Adjust the time based on your animation length
            isAttacking = false;
            playerAnimatorController.SetBool("isAttacking", false);
            isJoystick = true;
            _playerWeapon.SetActive(false);
        }

        public void FireBullet()
        {
            GameObject obj = ObjectPooling.Instance.SpawnFromPool(PoolObjectType.Bullet, _bulletPoint.position, Quaternion.identity);
            Bullet bulletComponent = obj.GetComponent<Bullet>();
            if (bulletComponent != null)
            {
                bulletComponent.InitalizeBullet(transform.forward, damage);
                SoundManager.Instance.PlaySound(_audioSource, SoundType.PlayerHit);
            }

            StartCoroutine(DisableBulletAfterSomeTime(obj));
        }

        IEnumerator DisableBulletAfterSomeTime(GameObject obj)
        {
            yield return new WaitForSeconds(3f);
            obj.SetActive(false);
        }
        #endregion
    }
}