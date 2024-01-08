using UnityEngine;
using NGame.Input;
using UnityEngine.InputSystem;

namespace NGame.PlayerMVC
{
    public class PlayerView : MonoBehaviour
    {
        public PlayerModel model;
        public PlayerController controller;
        public SpriteRenderer spriteView;

        private GameInput input;

        private void OnDeath()
        {
            input.Disable();
            spriteView.color = Color.red;
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

        public void Update()//or FixedUpdate? Or read in Update and invoke in FixedUpdate?
        {
            controller.Move(input.PlayerInput.Move.ReadValue<float>());
            controller.LongJump(input.PlayerInput.Jump.IsInProgress());
        }

        private void OnDestroy()
        {
            model.Death -= OnDeath;
            input.PlayerInput.Jump.performed -= Jump_performed;
        }
    }
}
