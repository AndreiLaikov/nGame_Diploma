using UnityEngine;

public class Lift : MonoBehaviour
{
    public LayerMask Mask;
    public float Speed;
    public Rigidbody2D rBody;

    [SerializeField]private bool isActive;
    private Vector2 startPos;

    private void Start()
    {
        startPos = rBody.position;
        rBody.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -transform.up, Mathf.Infinity, Mask);
        Debug.DrawRay(transform.position, -transform.up, Color.blue, 0.5f);
        if (!isActive)
        {
            Rise();
        }
        else if (hit)
        {
            Fall();
        }
    }

    private void Fall()
    {
        rBody.gravityScale = 1;
    }

    private void Rise()
    {
        if (Vector2.SqrMagnitude(rBody.position-startPos) < 0.1f)
        {
            isActive = true;
            return;
        }

        rBody.gravityScale = 0;
        var posY = rBody.position.y + Speed * Time.fixedDeltaTime;
        rBody.MovePosition(new Vector2(rBody.position.x, posY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isActive = false;
    }
}
