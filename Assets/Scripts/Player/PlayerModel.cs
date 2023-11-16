using System;
using UnityEngine;

namespace NGame.Player
{
    [Serializable]
    public class PlayerModel : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rBody;
        public Rigidbody2D RBody => rBody;

        [SerializeField] private Collider2D playerCollider;
        public Collider2D PlayerCollider => playerCollider;
    }
}
