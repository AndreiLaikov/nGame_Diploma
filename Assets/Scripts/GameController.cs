using UnityEngine;
using NGame.Configuration;
using NGame.Input;
using NGame.PlayerMVC;

namespace NGame
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameConfigurationData configurationData;
        private GameInput gameInput;
        private PlayerView playerView;
        private PlayerModel playerModel;

        private void Start()
        {
            gameInput = new GameInput();
            gameInput.PlayerInput.Enable();

            PlayerInit(configurationData.PlayerConfiguration);
            playerView = Instantiate(configurationData.PlayerConfiguration.PlayerPrefab, Vector3.zero, Quaternion.identity);
            playerView.Initialize(playerModel, gameInput);
        }

        private void PlayerInit(GameConfigurationDataPlayer playerConfig)
        {
            playerModel = new PlayerModel
            {
                MaxSpeed = playerConfig.MaxSpeed,
                Acceleration = playerConfig.Accleleration,
                JumpForce = playerConfig.JumpForce,
                SlidingSpeed = playerConfig.SlidingSpeed
            };
        }
    }
}
