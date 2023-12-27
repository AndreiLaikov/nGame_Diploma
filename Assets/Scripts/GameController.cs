using UnityEngine;
using NGame.Configuration;
using NGame.Input;
using NGame.PlayerMVC;

namespace NGame
{
    public class GameController : Singleton<GameController>
    {
        [SerializeField] private GameConfigurationData configurationData;
        private GameInput gameInput;
        private PlayerView playerView;
        private PlayerModel playerModel;
        public PlayerController PlayerController;

        private void Start()
        {
            gameInput = new GameInput();
            gameInput.PlayerInput.Enable();

            PlayerInit(configurationData.PlayerConfiguration);
            playerView = Instantiate(configurationData.PlayerConfiguration.PlayerPrefab, Vector3.zero, Quaternion.identity);
            playerView.Initialize(playerModel, gameInput);
            PlayerController = playerView.controller;
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
