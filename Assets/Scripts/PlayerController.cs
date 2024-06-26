using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private Animator playerAnimatorController;
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private Canvas inputCanvas;
    private bool isJoystick;
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
        if(isJoystick)
        {
            Vector3 movement = new Vector3(joystick.Direction.x, 0, joystick.Direction.y) * 1 * Time.deltaTime;
            if (movement.magnitude > 0)
            {
                playerAnimatorController.SetFloat("moveAmount", 1);
                // Rotate the player to face the direction of movement
                Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
                // Adjust rotation speed as needed
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 100*Time.deltaTime);
            }
            if (movement.magnitude == 0)
            {
                playerAnimatorController.SetFloat("moveAmount", 0);
            }
            transform.Translate(movement, Space.World);
        }
    }
    #endregion
}
