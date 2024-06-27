using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public class PlayerController : MonoBehaviour
    {
        #region Private Variables
        [SerializeField] private Animator playerAnimatorController;
        [SerializeField] private VariableJoystick joystick;
        [SerializeField] private Canvas inputCanvas;
        [SerializeField] private GameObject sword;
        private bool isJoystick;
        private bool isAttacking;
        #endregion

        #region Private Variables

        void Start()
        {
            EnableJoyStickInput();
        }
        private void EnableJoyStickInput()
        {
            isJoystick = true;
            inputCanvas.gameObject.SetActive(true);
        }
        void Update()
        {
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
            sword.SetActive(true);
            isJoystick = false;
            playerAnimatorController.SetBool("isAttacking", true);
            StartCoroutine(ResetAttackState());
        }

        private IEnumerator ResetAttackState()
        {
            // Wait for the attack animation to complete
            yield return new WaitForSeconds(1.0f); // Adjust the time based on your animation length
            isAttacking = false;
            playerAnimatorController.SetBool("isAttacking", false);
            isJoystick = true;
            sword.SetActive(false);
        }
        #endregion
    }
}