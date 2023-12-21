using UnityEngine;

public class EnemyMine : EnemyBase
{
    public int ExplosionForce;

    private void Explode()
    {
        var forceDirection = ((Vector3)playerRigidBody.position - transform.position) * ExplosionForce;
        Debug.DrawRay(transform.position, forceDirection);
        playerRigidBody.AddForce(forceDirection, ForceMode2D.Impulse);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Explode();
    }
}