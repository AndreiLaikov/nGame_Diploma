using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageDealer
{
    [SerializeField] private int damageValue;
    public int DamageValue { get => damageValue; }

    protected Rigidbody2D playerRigidBody;


    public void DoDamage(IHealth healthSystem)
    {
        healthSystem.ApplyDamage(damageValue);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRigidBody = collision.GetComponent<Rigidbody2D>();
            DoDamage(collision.GetComponent<IHealth>());
        }
    }

    protected virtual void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
