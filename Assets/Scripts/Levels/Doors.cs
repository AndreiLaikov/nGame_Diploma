using System;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public event Action PlayerInDoor;
    public bool IsOpen;
    public Unlocker[] unlockers;

    private void Start()
    {
        foreach (var unlocker in unlockers)
        {
            unlocker.UnlockerActivated += OnUnlockerActivate;
        }
    }

    private void OnUnlockerActivate()
    {
        IsOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsOpen && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerInDoor?.Invoke();
            Debug.Log("LoadNext");
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
