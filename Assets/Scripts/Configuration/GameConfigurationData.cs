using System;
namespace NGame.Configuration
{
    [Serializable]
    public class GameConfigurationData
    {
        public GameConfigurationDataPlayer PlayerConfiguration;
    }

    [Serializable]
    public class GameConfigurationDataPlayer
    {
        public Player.Player PlayerPrefab;
        public float PlayerSpeed;
        public float PlayerInertia;
    }
}
