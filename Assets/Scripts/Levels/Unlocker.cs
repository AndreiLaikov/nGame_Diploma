using System;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public event Action UnlockerActivated;
    public bool isActivated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActivated && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isActivated = true;
            UnlockerActivated?.Invoke();
        }
    }
}
