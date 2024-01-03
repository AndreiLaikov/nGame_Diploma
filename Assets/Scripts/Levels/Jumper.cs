using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float Force;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.AddForce(Vector2.up * Force, ForceMode2D.Impulse);
    }
}
