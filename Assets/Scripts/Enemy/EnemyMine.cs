using UnityEngine;

public class EnemyMine : MonoBehaviour
{
    public int damageValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<IHealth>().ApplyDamage(damageValue);
        }
    }

}
