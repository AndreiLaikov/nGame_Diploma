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

        public GameInput input;

        public void Initialize(PlayerModel playerModel, GameInput playerInput)
        {
            model = playerModel;
            controller.model = playerModel;
            input = playerInput;

            input.PlayerInput.Jump.performed += Jump_performed;
        }

        private void Jump_performed(InputAction.CallbackContext context)
        {
            controller.Jump();
        }

        public void Update()
        {
            controller.Move(input.PlayerInput.Move.ReadValue<float>());
        }
    }
}
