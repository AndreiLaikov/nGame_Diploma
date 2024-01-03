using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float Force;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.AddForce(transform.up * Force, ForceMode2D.Impulse);
    }
}
