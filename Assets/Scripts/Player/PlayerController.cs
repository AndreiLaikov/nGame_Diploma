using UnityEngine;

namespace NGame.PlayerMVC
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerModel model;
        public Transform GroundChecker;
        public LayerMask GroundedMask;
        public Rigidbody2D rBody;

        private float direction;

        public Transform WallChecker;
        public bool isSliding;
        public float WallSlidingSpeed;
        private Vector2 normal;
        public bool IsWallJumping;
        public Vector2 wallJumping;

        public void CheckGround()
        {
            var grounded = Physics2D.Raycast(GroundChecker.position, Vector2.down, 0.1f, GroundedMask);
            model.SetIsGrounded(grounded);
        }

        public void CheckWall()
        {
            var walled = Physics2D.Raycast(WallChecker.position, -transform.right * transform.localScale.x, 0.1f, GroundedMask);
            normal = walled.normal;
            model.SetIsWalled(walled);
        }

        public void CheckSliding()
        {
            if(model.IsWalled && !model.IsGrounded)
            {
                isSliding = true;
            }
            else
            {
                isSliding = false;
            }
        }

        private void Flip()
        {
            if (rBody.velocity.x < -0.1f)
                transform.localScale = new Vector3(1, 1, 1);
            if  (rBody.velocity.x > 0.1f)
                transform.localScale = new Vector3(-1, 1, 1);
        }

        public void Move(float input)
        {
            Flip();

            var dt = Time.deltaTime;
            direction = Mathf.Lerp(direction, input, model.Inertia * dt);

            if (Mathf.Abs(direction) < 0.01f)
            {
                direction = 0;
            }

            if (isSliding)
            {
                rBody.velocity = new Vector2(rBody.velocity.x, Mathf.Clamp(rBody.velocity.y, -WallSlidingSpeed, float.MaxValue));
            }

            if (IsWallJumping)
            {
                IsWallJumping = !model.IsGrounded;
            }
            else
            {
                rBody.velocity = new Vector2(direction * model.Speed, rBody.velocity.y);
            }
        }

        public void Jump()
        {
            if (model.IsGrounded)
            {
                rBody.AddForce(Vector2.up * model.JumpForce, ForceMode2D.Impulse);
            }

            if (isSliding)
            {
                rBody.AddForce(new Vector2(wallJumping.x * transform.localScale.x, wallJumping.y), ForceMode2D.Impulse);
                IsWallJumping = true;
            }
       
        }


        private void Update()
        {
            CheckGround();
            CheckWall();
            CheckSliding();
            
        }
    }
}