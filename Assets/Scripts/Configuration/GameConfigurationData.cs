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
        public float MaxSpeed;
        public float Accleleration;
        public float JumpForce;
        public float SlidingSpeed;
    }
}
