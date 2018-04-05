using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SunnyLand
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public int health = 100;
        public int damage = 50;
        public float hitForce = 4f;
        public float damageForce = 4f;
        public float maxVelocity = 3f;
        public float maxSlopeAngle = 45f;
        [Header("Groundding")]
        public float rayDistance = .5f;
        public bool isGround = false;
        [Header("Crouch")]
        public bool isCrouching = false;
        [Header("Jump")]
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public bool isJumping = false;
        [Header("Climb")]
        public float climbSpeed = 5f;
        public bool isClimning = false;
        public bool isOnSlope = false;

        private Vector3 groundNormal = Vector3.up;
        private int currentJump = 0;
        private float inputH, inputV;
        private SpriteRenderer rend;
        private Rigidbody2D rigid;

        #region Unity Functions
        // Use this for initialization
        void Start()
        {
            rend = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            PerformClimb();
            PerformJump();
            PerformMove();
        }
        void FixUpdate()
        {
            DetectGround();
            CheckSlop();
        }
        void OnDrawGizoms()
        {
            //DRAW THE GROUND RAY
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position - right * 1F, transform.position + right * 1F);
        }
        #endregion

        #region Custom Functions
        public void Jump()
        {
            isJumping = true;
        }
        public void Crouch()
        {

        }
        public void UnCrouch()
        {

        }
        public void Move(float horizontal)
        {
            //If there is horizontal input
            if (horizontal != 0)
            {
                //Flip the sprite in the correct direction
                rend.flipX = horizontal < 0;
            }
            //Store the input for later 
            inputH = horizontal;
        }
        public void Climb(float vertical)
        {

        }
        public void Hurt(int damage)
        {

        }

        private void PerformClimb()
        {

        }
        private void PerformMove()
        {
            //Calulate the move direction based on surface 
            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);
            //Add force in direction using horizontal input
            rigid.AddForce(right * inputH * speed);
            //Limit the velocity to max velocity 
            LimitVelocity();
        }
        private void PerformJump()
        {
            //are wejumping?
            if (isJumping)
            {
                if(currentJump < maxJumpCount)
                {
                    currentJump++;
                    rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                }
                isJumping = false;
            }
        }

        private void DetectGround()
        {
            // create a ground ray
            Ray groundRay = new Ray(transform.position, Vector3.down);
            // shoot ray below the player and get all the hits
            RaycastHit2D[] hits = Physics2D.RaycastAll(groundRay.origin, groundRay.direction, rayDistance);

            //loop throught the ground 
            foreach (var hit in hits)
            {

                CheckEnemy(hit);

                if (CheckGround(hit))
                {
                    //exit the loop
                    break;
                }
            }
        }
        private void CheckSlop()
        {
            if (isOnSlope)
            {
                rigid.drag = 5f;
            }
            else
            {
                rigid.drag = 0f;
            }
        }
        private bool CheckGround(RaycastHit2D hit)
        {
            if (hit.collider != null &&          //
                hit.collider.name != name &&
                hit.collider.isTrigger == false)
            {
                currentJump = 0;
                //player is in the grounded state
                isGround = true;
                // update the ground normal
                groundNormal = hit.normal;
                // check for slopes
                float slopAngle = Vector3.Angle(Vector3.up, hit.normal);
                isOnSlope = Mathf.Abs(slopAngle) > 0 &&
                           Mathf.Abs(slopAngle) < maxSlopeAngle;
                //
                if (slopAngle >= maxSlopeAngle)
                {
                    rigid.AddForce(Physics2D.gravity);
                }



                //update the ground normal               
                return true;
            }
            // return false! (ground is found)
            return false;
        }
        private void CheckEnemy(RaycastHit2D hit)
        {

        }
        private void LimitVelocity()
        {
            // CACHE RIGID VELOCITY INTO SMALLER VARIABLE
            Vector3 vel = rigid.velocity;
            //If vel length is greater than max velocity
            if (vel.magnitude > maxVelocity)
            {
                // Cap the velocity to maxVelocity
                vel = vel.normalized * maxVelocity;
            }
            // Apply newly calculated vel to rigidbody
            rigid.velocity = vel;
        }
        private void StopClimbing()
        {

        }
        private void DisablePhysics()
        {

        }
        private void EnablePhysics()
        {

        }
        #endregion
    }
}
