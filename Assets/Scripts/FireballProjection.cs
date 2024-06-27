using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivorGame
{
    public class FireballProjection : MonoBehaviour
    {
        public Transform target; // The player or the target to throw the ball at
        public float angle = 45f; // Angle of the throw in degrees
        public float gravity = 9.81f; // Gravity force
        private Rigidbody _fireBallProjection;
        public float speed = 1f; // Initial speed of the fireball
        // Start is called before the first frame update

        public void Awake()
        {
            target = GameObject.Find("Player").transform;
        }
        public void InitializeFireBall()
        {
            _fireBallProjection = GetComponent<Rigidbody>();
            // Calculate and set the initial velocity
            Vector3 velocity = CalculateVelocity();
            // Check if velocity has NaN components before assigning
           
            _fireBallProjection.velocity = velocity;
        }

        Vector3 CalculateVelocity()
        {
            Vector3 direction = target.position - transform.position; // Direction to target
            float distance = direction.magnitude; // Distance to target

            float angleRad = angle * Mathf.Deg2Rad; // Angle in radians

            // Calculate initial velocity components
            float initialVelocity = Mathf.Sqrt((distance * gravity) / Mathf.Sin(2 * angleRad));
            float horizontalVelocity = initialVelocity * Mathf.Cos(angleRad);
            float verticalVelocity = initialVelocity * Mathf.Sin(angleRad);

            // Combine velocities into a Vector3
            Vector3 velocity = direction.normalized * horizontalVelocity;
            velocity.y = verticalVelocity; // Set vertical velocity component

            return velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
                //Add coin dropping
            }
        }
    }
}
