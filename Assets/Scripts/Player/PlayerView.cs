using UnityEngine;
using NGame.Input;
using UnityEngine.InputSystem;
using NGame.Configuration;

namespace NGame.PlayerMVC
{
    public class PlayerView : MonoBehaviour
    {
        public PlayerModel model;
        public PlayerController controller;

        private GameInput input;

        public void Initialize(PlayerModel playerModel)
        {
            model = playerModel;
            controller.model = playerModel;
            input = GameController.Instance.GameInput;

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
    }
}
