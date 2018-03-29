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

        }
        #endregion

        #region Custom Functions
        public void Jump()
        {

        }
        public void Crouch()
        {

        }
        public void UnCrouch()
        {

        }
        public void Move(float horizontal)
        {

        }
        public void Climb(float vertical)
        {

        }
        public void Hurt(int damage)
        {

        }

        private void DetectGround()
        {

        }
        private void CheckGround(RaycastHit2D hit)
        {

        }
        private void CheckEnemy(RaycastHit2D hit)
        {

        }
        private void LimitVelocity()
        {

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
