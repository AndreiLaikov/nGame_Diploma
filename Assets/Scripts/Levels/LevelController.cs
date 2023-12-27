using NGame;
using NGame.PlayerMVC;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Room[] Rooms;
    private int currentRoomNumber;
    private PlayerController player;

    private void Start()
    {
        player = GameController.Instance.PlayerController;

        foreach (var room in Rooms)
        {
            room.RoomComplete += OnRoomComplete;
        }
        currentRoomNumber = 0;
        LoadRoom(currentRoomNumber);
    }

    private void OnRoomComplete()
    {
        currentRoomNumber++;
        LoadRoom(currentRoomNumber);
    }

    private void LoadRoom(int roomNumber)
    {
        if (roomNumber >= Rooms.Length)
        {
            Debug.Log("NewEpisode");
            //todo Load Next Episode
            return;
        }

        for (int i = 0; i < Rooms.Length; i++)
        {
            Rooms[i].gameObject.SetActive(i == roomNumber);
            player.transform.position = Rooms[currentRoomNumber].PlayerSpawnPoint.position;
            player.transform.rotation = Quaternion.identity;
        }
    }

    private void OnDestroy()
    {
        foreach (var room in Rooms)
        {
            room.RoomComplete += OnRoomComplete;
        }
    }
}
