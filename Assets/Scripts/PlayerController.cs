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
    // Start is called before the first frame update
    void Start()
    {
        EnableJoyStickInput();
    }

    private void EnableJoyStickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       /* 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * 1 * Time.deltaTime;
        if(movement.magnitude > 0)
        {
            playerAnimatorController.SetFloat("moveAmount", 1);
        }
        if(movement.magnitude ==0)
        {
            playerAnimatorController.SetFloat("moveAmount", 0);
        }
        transform.Translate(movement);*/

        if(isJoystick)
        {
            Vector3 movement = new Vector3(joystick.Direction.x, 0, joystick.Direction.y) * 1 * Time.deltaTime;
            if (movement.magnitude > 0)
            {
                playerAnimatorController.SetFloat("moveAmount", 1);
            }
            if (movement.magnitude == 0)
            {
                playerAnimatorController.SetFloat("moveAmount", 0);
            }
            transform.Translate(movement);
        }
    }
}
