using NGame;
using NGame.PlayerMVC;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int EpisodeNumber;
    public Room[] Rooms;
    private int currentRoomNumber;
    private PlayerController player;

    private void Start()
    {
        foreach (var room in Rooms)
        {
            room.RoomComplete += OnRoomComplete;
        }
        currentRoomNumber = 0;

        Restart();
    }

    private void OnRoomComplete()
    {
        currentRoomNumber++;
        LoadRoom();
    }

    public void Restart()
    {
        var gameController = GameController.Instance;
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
            SceneManager.LoadScene(0);
            return;
        }

        for (int i = 0; i < Rooms.Length; i++)
        {
            Rooms[i].gameObject.SetActive(i == currentRoomNumber);
            player.transform.position = Rooms[currentRoomNumber].PlayerSpawnPoint.position;
            player.transform.rotation = Quaternion.identity;
        }
    }

    private void OnDestroy()
    {
        foreach (var room in Rooms)
        {
            room.RoomComplete -= OnRoomComplete;
        }
    }
}
