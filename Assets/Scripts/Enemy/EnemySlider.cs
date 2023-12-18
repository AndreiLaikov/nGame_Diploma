using UnityEngine;

public class EnemySlider : EnemyBase
{
    public float Speed;
    public Rigidbody2D rBody;
    [SerializeField]private bool isActivated;
    private Vector2 direction;
    [SerializeField]private LayerMask ignoredLayers;

    private void Start()
    {
        ignoredLayers = ~ignoredLayers;
    }

    private void Update()
    {
        if(!isActivated)
        {
            CheckPlayer(Vector2.right);
            CheckPlayer(Vector2.left);
        }
    }

    private void CheckPlayer(Vector2 dir)
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, dir, Mathf.Infinity, ignoredLayers);
        
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                direction = dir;
                isActivated = true;
                rBody.velocity = direction * Speed;
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        isActivated = false;
        rBody.velocity = Vector2.zero;
    }
}
