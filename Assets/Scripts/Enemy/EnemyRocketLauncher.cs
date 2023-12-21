using NGame.PlayerMVC;
using UnityEngine;

public class EnemyRocketLauncher : MonoBehaviour
{
    public PlayerController player;
    public SpriteRenderer sprite;
    public Rocket RocketPrefab;

    private Rocket currentRocket;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void CheckPlayer()
    {
        var dir = player.transform.position - transform.position;
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, dir, Mathf.Infinity);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                sprite.color = Color.red;
                Launch();
            }
            else
            {
                sprite.color = Color.white;
            }
        }
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, player.transform.position);
        if (currentRocket == null)
        {
            CheckPlayer();
        }
    }

    private void Launch()
    {
        currentRocket = Instantiate(RocketPrefab, transform.position, Quaternion.identity);
        currentRocket.Target = player;
    }
}
