using NGame.Input;
using NGame.Configuration;

namespace NGame.Player {
    public class Player : PlayerModel
    {
        private PlayerMover playerMover;
        private GameInput gameInput;

        public void Initialize(GameConfigurationDataPlayer playerConfiguration, GameInput input)
        {
            gameInput = input;

            playerMover = new PlayerMover();
            playerMover.Initialize(playerConfiguration, RBody);
        }

        public void FixedUpdate()
        {
            var moveInput = gameInput.PlayerInput.Move.ReadValue<float>();
            playerMover.Move(moveInput);
        }
    }
}
