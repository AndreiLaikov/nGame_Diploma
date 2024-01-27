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
        public PlayerController Controller;

        public LevelController currentLevelController;

        public override void Awake()
        {
            base.Awake();

            GameInput = new GameInput();
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
            if (Controller != null)
                return;

            GameInput.PlayerInput.Enable();
            PlayerInit(configurationData.PlayerConfiguration);
            playerView = Instantiate(configurationData.PlayerConfiguration.PlayerPrefab, Vector3.zero, Quaternion.identity);
            playerView.Initialize(playerModel);
            Controller = playerView.GetComponent<PlayerController>();
        }

        public void Restart()
        {
            GameInput.PlayerInput.Enable();
            Destroy(Controller.gameObject);
            Controller = null;

            currentLevelController.Restart();
        }

        public void SetPause(bool value)
        {
            if (value == true)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
}
