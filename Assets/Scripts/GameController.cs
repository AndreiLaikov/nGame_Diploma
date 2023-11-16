using UnityEngine;
using NGame.Configuration;
using NGame.Input;

namespace NGame
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameConfigurationData configurationData;
        private GameInput gameInput;
        private Player.Player player;

        private void Start()
        {
            gameInput = new GameInput();
            gameInput.PlayerInput.Enable();

            player = Instantiate(configurationData.PlayerConfiguration.PlayerPrefab, Vector3.zero, Quaternion.identity);
            player.Initialize(configurationData.PlayerConfiguration, gameInput);
        }
    }
}
