using System;
using UnityEngine;

public class Room : MonoBehaviour
{
    public event Action RoomComplete;
    public Doors Door;
    public Transform PlayerSpawnPoint;

    private void Awake()
    {
        Door.PlayerInDoor += OnPlayerInDoor;
    }

    private void OnPlayerInDoor()
    {
        RoomComplete?.Invoke();
    }

    private void OnDestroy()
    {
        Door.PlayerInDoor -= OnPlayerInDoor;
    }
}
