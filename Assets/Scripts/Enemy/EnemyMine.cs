using UnityEngine;

public class EnemyMine : EnemyBase
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            base.OnTriggerEnter2D(collision);
            DestroyEnemy();
        }
    }
}