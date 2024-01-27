using NGame;
using NGame.PlayerMVC;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public Canvas[] Canvases;
    private GameController gameController;
    private PlayerModel model;

    private void Start()
    {
        gameController = GameController.Instance;
        model = gameController.Controller.model;
        model.Death += OnDeath;
    }

    private void OnDeath()
    {
        ShowCanvas(0);
    }

    public void ShowCanvas(int index)
    {
        for (int i = 0; i < Canvases.Length; i++)
        {
            if (i == index)
            {
                Canvases[i].gameObject.SetActive(true);
            }
            else
            {
                Canvases[i].gameObject.SetActive(false);
            }
        }
    }

    public void Restart()
    {
        model.Death -= OnDeath;

        gameController.Restart();
        foreach (var canvas in Canvases)
        {
            canvas.gameObject.SetActive(false);
        }

        model = gameController.Controller.model;
        model.Death += OnDeath;

        ShowCanvas(3);
    }

    private void OnDestroy()
    {
        model.Death -= OnDeath;
    }
}
