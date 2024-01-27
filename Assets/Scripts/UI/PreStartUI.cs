using NGame;
using UnityEngine;
using UnityEngine.InputSystem;

public class PreStartUI : MonoBehaviour
{
    private GameController gameController;

    private void Unpause()
    {
        gameController.SetPause(false);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        gameController = GameController.Instance;
        gameController.GameInput.PlayerInput.Jump.started += SpacebarDown;
    }

    private void SpacebarDown(InputAction.CallbackContext obj)
    {
        Unpause();
        gameController.GameInput.PlayerInput.Jump.started -= SpacebarDown;

    }
}
