using UnityEngine;

namespace NGame.PlayerMVC
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerModel model;
        private Rigidbody2D rBody;
        private HealthSystem healthSystem;

        private bool IsReadyToWallJumping;
        public Vector2 currentVelocity;
        [SerializeField]private Transform groundChecker;
        [SerializeField]private LayerMask groundedMask;

        private float jumpTime;

        private void Start()
        {
            rBody = GetComponent<Rigidbody2D>();
            jumpTime = model.JumpPeriod;

            healthSystem = GetComponent<HealthSystem>();
            healthSystem.DamageRecieved += OnDamageRecieved;
        }

        private void OnDamageRecieved()
        {
            if(healthSystem.GetHealth() == 0)
            {
                model.SetIsDeath(true);
            }
        }

        private void Update()
        {
            CheckDirection();
            CheckGround();
            CheckSliding();
        }

        public void Move(float input)
        {
            currentVelocity = rBody.velocity;

            currentVelocity.x = Mathf.Lerp(currentVelocity.x, input * model.MaxSpeed, model.Acceleration * Time.deltaTime);

            if (model.isSliding)
            {
                var CurrentGravity = Mathf.Clamp(rBody.velocity.y, -model.SlidingSpeed, float.MaxValue);
                currentVelocity.y = CurrentGravity;

                IsReadyToWallJumping = true;
            }

            if (IsReadyToWallJumping)
            {
                IsReadyToWallJumping = !model.isGrounded;
            }
 
            rBody.velocity = currentVelocity;
        }

        public void LongJump(bool isJumping)
        {
            if (isJumping && jumpTime > 0)
            {
                jumpTime -= Time.deltaTime;
                rBody.AddForce(Vector2.up * model.JumpForce * jumpTime, ForceMode2D.Force);
            }
        }

        public void Jump()
        {
            if (model.isGrounded)
            {
                rBody.AddForce(Vector2.up * model.JumpForce, ForceMode2D.Impulse);
                jumpTime = model.JumpPeriod;
            }

            if (model.isSliding)
            {
                rBody.AddForce(Vector2.up * model.JumpForce, ForceMode2D.Impulse);
                rBody.AddForce(Vector2.right * model.JumpForce * (int)model.playerCurrentDirection, ForceMode2D.Impulse);
            }
        }

        private void CheckDirection()
        {
            if (rBody.velocity.x < -0.1f)
            {
                model.SetDirection(PlayerModel.PlayerDirection.Left);
            }
            if (rBody.velocity.x > 0.1f)
            {
                model.SetDirection(PlayerModel.PlayerDirection.Right);
            }
        }

        private void CheckGround()
        {
            model.SetIsGrounded(Physics2D.CircleCast(groundChecker.position, 0.2f, Vector2.down, 0.2f, groundedMask));
        }

        private void CheckSliding()
        {
            model.SetIsSliding(!model.isGrounded &&
                Physics2D.Raycast(transform.position, -transform.right * (int)model.playerCurrentDirection, 0.3f, groundedMask));//todo change 0.3 to halfsize of player+0.1
        }

        private void OnDestroy()
        {
            healthSystem.DamageRecieved -= OnDamageRecieved;
        }

    }
}