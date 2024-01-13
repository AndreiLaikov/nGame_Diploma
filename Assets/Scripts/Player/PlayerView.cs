using UnityEngine;
using NGame.Input;
using UnityEngine.InputSystem;

namespace NGame.PlayerMVC
{
    public class PlayerView : MonoBehaviour
    {
        private string acSpeed = "Speed";
        private string acSliding = "Sliding";
        private string acSpeedY = "SpeedY";
        private string acGrounded = "Grounded";

        public PlayerModel model;
        public PlayerController controller;
        public SpriteRenderer spriteView;
        public Animator PlayerAC;
        public GameObject Parts;

        private GameInput input;

        private void OnDeath()
        {
            input.Disable();
            spriteView.enabled = false;
            controller.rBody.simulated = false;
            Parts.SetActive(true);
        }

        public void Initialize(PlayerModel playerModel)
        {
            model = playerModel;
            controller.model = playerModel;
            input = GameController.Instance.GameInput;
            spriteView.color = Color.black;
            model.Death += OnDeath;

            input.PlayerInput.Jump.performed += Jump_performed;
        }

        private void Jump_performed(InputAction.CallbackContext context)
        {
            controller.Jump();
        }

        public void Update()
        {
            AnimController();
        }

        public void FixedUpdate()
        {
            controller.Move(input.PlayerInput.Move.ReadValue<float>());
            controller.LongJump(input.PlayerInput.Jump.IsInProgress());
        }

        private void OnDestroy()
        {
            model.Death -= OnDeath;
            input.PlayerInput.Jump.performed -= Jump_performed;
        }

        private void AnimController()
        {
            PlayerAC.SetFloat(acSpeed, Mathf.Abs(controller.currentVelocity.x));
            PlayerAC.SetFloat(acSpeedY, controller.currentVelocity.y);
            PlayerAC.SetBool(acSliding, model.isSliding);
            PlayerAC.SetBool(acGrounded, model.isGrounded);

            if(model.playerCurrentDirection == PlayerModel.PlayerDirection.Right)
            {
                spriteView.flipX = false;
            }
            else
            {
                spriteView.flipX = true;
            }

        }
    }
}
