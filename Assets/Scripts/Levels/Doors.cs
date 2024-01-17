using System;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public event Action PlayerInDoor;
    public bool IsOpen;
    public Unlocker[] unlockers;
    public Sprite DoorOpened;
    private SpriteRenderer sRenderer;

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        foreach (var unlocker in unlockers)
        {
            unlocker.UnlockerActivated += OnUnlockerActivate;
        }
    }

    private void OnUnlockerActivate()
    {
        IsOpen = true;
        sRenderer.sprite = DoorOpened;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsOpen && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerInDoor?.Invoke();
        }
    }

    private void OnDestroy()
    {
        foreach (var unlocker in unlockers)
        {
            unlocker.UnlockerActivated -= OnUnlockerActivate;
        }
    }
}
