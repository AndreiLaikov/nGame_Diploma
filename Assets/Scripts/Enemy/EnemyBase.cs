using NGame.PlayerMVC;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageDealer
{
    [SerializeField] private int damageValue;
    public int DamageValue { get => damageValue; }

    public int ExplosionForce;
    protected Rigidbody2D[] playerRigidBody;


    public void DoDamage(IHealth healthSystem)
    {
        healthSystem.ApplyDamage(damageValue);
        Debug.Log(damageValue);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.GetComponent<PlayerView>())
        {
            Debug.Log("View");
            playerRigidBody = collision.GetComponent<PlayerView>().Parts.GetComponentsInChildren<Rigidbody2D>();
            DoDamage(collision.GetComponent<IHealth>());
            Explode();
        }
    }

    private void Explode()
    {
        foreach (var part in playerRigidBody)
        {
            var forceDirection = ((Vector3)part.position - transform.position) * ExplosionForce;
            Debug.DrawRay(transform.position, forceDirection, Color.cyan);
            part.AddForce(forceDirection, ForceMode2D.Impulse);
        }
    }

    protected virtual void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
