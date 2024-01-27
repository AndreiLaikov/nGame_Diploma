using NGame;
using NGame.PlayerMVC;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public UiController UiControl;
    public int EpisodeNumber;
    public Room[] Rooms;
    private int currentRoomNumber;
    private PlayerController player;
    private GameController gameController;

    private Room currentRoom;

    private void Start()
    {
        foreach (var room in Rooms)
        {
            room.RoomComplete += OnRoomComplete;
        }
        currentRoomNumber = 0;

        gameController = GameController.Instance;
        Restart();
    }

    private void OnRoomComplete()
    {
        currentRoomNumber++;
        LoadRoom();
    }

    public void Restart()
    {
        gameController.CreatePlayer();
        player = gameController.Controller;
        gameController.currentLevelController = this;

        LoadRoom();
    }

    private void LoadRoom()
    {
        if (currentRoomNumber >= Rooms.Length)
        {
            PlayerPrefs.SetInt("Episode" + EpisodeNumber.ToString(), EpisodeNumber + 1);
            UiControl.ShowCanvas(2);
            return;
        }

        gameController.SetPause(true);
        UiControl.ShowCanvas(3);

        if (currentRoom != null)
        {
            currentRoom.RoomComplete -= OnRoomComplete;
            Destroy(currentRoom.gameObject);
        }

        currentRoom = Instantiate(Rooms[currentRoomNumber], transform);
        currentRoom.RoomComplete += OnRoomComplete;
        player.transform.position = currentRoom.PlayerSpawnPoint.position;
        player.transform.rotation = Quaternion.identity;
    }

    private void OnDestroy()
    {
        foreach (var room in Rooms)
        {
            room.RoomComplete -= OnRoomComplete;
        }
    }
}
