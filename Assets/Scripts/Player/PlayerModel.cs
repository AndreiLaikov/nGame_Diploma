using System;
using UnityEngine;

namespace NGame.PlayerMVC
{
    [Serializable]
    public class PlayerModel
    {
        public float MaxSpeed;
        public float Acceleration;
        public float JumpForce;
        public float SlidingSpeed;

        public bool isGrounded { get; private set; }
        public bool isSliding { get; private set; }
        public bool isJumping;

        public enum PlayerDirection
        {
            Left = 1,
            Right = -1
        }

        public PlayerDirection playerCurrentDirection { get; private set; }

        public void SetIsGrounded(bool grounded)
        {
            isGrounded = grounded;//+ ивент
        }

        public void SetIsSliding(bool sliding)
        {
            isSliding = sliding;//+ ивент
        }

        public void SetDirection(PlayerDirection value)
        {
            playerCurrentDirection = value;//+ ивент
        }
    }
}