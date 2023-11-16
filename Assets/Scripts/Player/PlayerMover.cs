using UnityEngine;
using NGame.Configuration;

namespace NGame.Player
{
    public class PlayerMover
    {
        private GameConfigurationDataPlayer configPlayer;
        private Rigidbody2D rBody;
        private float direction;

        public void Initialize(GameConfigurationDataPlayer playerConfiguration, Rigidbody2D rigidBody)
        {
            configPlayer = playerConfiguration;
            rBody = rigidBody;
        }

        public void Move(float input)
        {
            direction = Mathf.Lerp(direction, input, configPlayer.PlayerInertia * Time.fixedDeltaTime);

            if (Mathf.Abs(direction) < 0.01f)
            {
                direction = 0;
            }
            rBody.velocity = new Vector2(direction * configPlayer.PlayerSpeed, 0);
        }
    }
}
