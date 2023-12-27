using System;
using NGame.PlayerMVC;

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
        public PlayerView PlayerPrefab;
        public float MaxSpeed = 5;
        public float Accleleration = 1;
        public float JumpForce = 4;
        public float SlidingSpeed = 1;
        public float JumpPeriod = 1;
    }
}
