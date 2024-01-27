using NGame.PlayerMVC;
using UnityEngine;

public class Rocket : EnemyBase
{
    public PlayerController Target;
    public Rigidbody2D rBody;
    public float ForceValue;

    private void Flying()
    {
        var dir = Target.transform.position - transform.position;
        rBody.MovePosition(transform.position + ForceValue * Time.fixedDeltaTime * dir.normalized);

        var rot = Quaternion.LookRotation(dir,Vector2.up);
        rBody.SetRotation(rot);
    }

    private void FixedUpdate()
    {
        Flying();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Destroy(gameObject);
    }
}
