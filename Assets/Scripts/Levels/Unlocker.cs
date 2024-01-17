using System;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public event Action UnlockerActivated;
    public bool isActivated;
    public Sprite UnlockedImage;
    private SpriteRenderer sRenderer;

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActivated && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isActivated = true;
            sRenderer.sprite = UnlockedImage;
            UnlockerActivated?.Invoke();
        }
    }
}
