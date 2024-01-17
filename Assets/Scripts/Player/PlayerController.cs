using UnityEngine;

namespace NGame.PlayerMVC
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerModel model;
        public Rigidbody2D rBody;
        private HealthSystem healthSystem;

        private bool IsReadyToWallJumping;
        public Vector2 currentVelocity;
        [SerializeField]private Transform groundChecker;
        [SerializeField]private LayerMask groundedMask;

        private Vector2 directionChanged = Vector2.right;
        public float RayCastLength;
        private Vector2 raycastFrom;
        private Vector2 raycastTo;
        public float lerpValue = 1;

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


            raycastFrom = transform.position + (transform.up * 0.3f) - transform.right * (int)model.playerCurrentDirection * 0.2f;
            raycastTo = Vector3.down;

            Debug.DrawRay(raycastFrom, raycastTo * RayCastLength , Color.red);
            
            var r = Physics2D.RaycastAll(raycastFrom, raycastTo, RayCastLength, groundedMask);
            
            if(r.Length == 0)
            {
                directionChanged = transform.right;
                Rotations(0);
            }
            else
            {
                Debug.DrawRay(r[0].point, r[0].normal, Color.blue);
                Debug.DrawRay(r[0].point, Vector3.Cross(r[0].normal, -transform.forward * (int)model.playerCurrentDirection), Color.green);

                directionChanged = Vector3.Cross(r[0].normal, transform.forward);

                if (Vector2.Angle(directionChanged, Vector2.up) < 30  || Vector2.Angle(directionChanged, Vector2.up) > 150)
                {
                    directionChanged = transform.right;
                }

                Rotations(90-Vector2.Angle(directionChanged, Vector2.up));
            }
        }

        public void Move(float input)
        {
            currentVelocity = rBody.velocity;
            rBody.AddForce(input * model.Acceleration * directionChanged);

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

            var xVelClamp = Mathf.Clamp(rBody.velocity.x, -model.MaxSpeed, model.MaxSpeed);
            rBody.velocity = new Vector2(xVelClamp, currentVelocity.y);
        }

        public void LongJump(bool isJumping)
        {
            if (isJumping && jumpTime > 0)
            {
                jumpTime -= Time.fixedDeltaTime;
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
            model.SetIsGrounded(Physics2D.CircleCast(groundChecker.position, 0.1f, Vector2.down, 0.1f, groundedMask));
        }

        private void CheckSliding()
        {
            model.SetIsSliding(!model.isGrounded &&
                Physics2D.Raycast(transform.position, -Vector2.right * (int)model.playerCurrentDirection, 0.3f, groundedMask));//todo change 0.3 to halfsize of player+0.1
        }

        private void OnDestroy()
        {
            healthSystem.DamageRecieved -= OnDamageRecieved;
        }

        private void Rotations(float dest)
        {
            var r = Mathf.Lerp(rBody.rotation, dest, lerpValue * Time.deltaTime);
            rBody.SetRotation(r);
        }

    }
}