using NGame.PlayerMVC;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public PlayerController Target;
    public Rigidbody2D rBody;
    public float ForceValue;

    private void Start()
    {
        
    }

    private void Flying()
    {
        var dir = (Target.transform.position - transform.position).normalized;
        rBody.MovePosition(transform.position + ForceValue * Time.deltaTime * dir);
    }

    private void Update()
    {
        Flying();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
