using NGame.PlayerMVC;
using UnityEngine;

public class FallChecker : MonoBehaviour
{
    [SerializeField] private LayerMask groundedMask;
    private PlayerController player;
    private HealthSystem healthSystem;
    public float DamageVelocity = -13;

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
        healthSystem = player.GetComponent<HealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((groundedMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            if (player.currentVelocity.y < DamageVelocity)
            {
                healthSystem.ApplyDamage(1);
            }
        }
    }
}
