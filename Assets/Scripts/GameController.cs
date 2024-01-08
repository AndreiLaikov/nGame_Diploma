using UnityEngine;
using NGame.Configuration;
using NGame.Input;
using NGame.PlayerMVC;

namespace NGame
{
    public class GameController : Singleton<GameController>
    {
        [SerializeField] private GameConfigurationData configurationData;
        public GameInput GameInput;
        private PlayerView playerView;
        private PlayerModel playerModel;
        public PlayerController PlayerController;

        public override void Awake()
        {
            base.Awake();

            GameInput = new GameInput();
            GameInput.PlayerInput.Enable();
        }

        private void PlayerInit(GameConfigurationDataPlayer playerConfig)
        {
            playerModel = new PlayerModel
            {
                MaxSpeed = playerConfig.MaxSpeed,
                Acceleration = playerConfig.Accleleration,
                JumpForce = playerConfig.JumpForce,
                SlidingSpeed = playerConfig.SlidingSpeed,
                JumpPeriod = playerConfig.JumpPeriod
            };
        }

        public void CreatePlayer()
        {
            if (PlayerController != null)
                return;

            PlayerInit(configurationData.PlayerConfiguration);
            playerView = Instantiate(configurationData.PlayerConfiguration.PlayerPrefab, Vector3.zero, Quaternion.identity);
            playerView.Initialize(playerModel);
            PlayerController = playerView.GetComponent<PlayerController>();
        }
    }
}
