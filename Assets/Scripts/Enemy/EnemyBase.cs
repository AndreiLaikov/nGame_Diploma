using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageDealer
{
    [SerializeField] private int damageValue;
    public int DamageValue { get => damageValue; }

    public int ForceValue;
    private Rigidbody2D playerRigidBody;


    public void DoDamage(IHealth healthSystem)
    {
        healthSystem.ApplyDamage(damageValue);
        Explode();
    }

    private void Explode()
    {
        var forceDirection = ((Vector3)playerRigidBody.position - transform.position) * ForceValue;
        Debug.DrawRay(transform.position, forceDirection);
        playerRigidBody.AddForce(forceDirection,ForceMode2D.Impulse);
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
