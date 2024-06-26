using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private Animator playerAnimatorController;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        transform.Translate(movement);
    }
}
