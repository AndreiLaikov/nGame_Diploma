using UnityEngine;

public class SmallLocker : MonoBehaviour
{
    public Unlocker unlocker;
    private Collider2D collider;
    public bool isInvert;
    public SpriteMask mask;

    private void Start()
    {
        unlocker.UnlockerActivated += OnUnlockerActivate;
        collider = GetComponent<Collider2D>();

        collider.enabled = !isInvert;
        mask.enabled = isInvert;
    }

    private void OnUnlockerActivate()
    {
        collider.enabled = isInvert;
        mask.enabled = !isInvert;
    }


    private void OnDestroy()
    {
        unlocker.UnlockerActivated -= OnUnlockerActivate;
    }
}
