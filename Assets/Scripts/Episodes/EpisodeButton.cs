using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EpisodeButton : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private Button btn;
    private string sceneNumber;

    private void Start()
    {
        btn.onClick.AddListener(()=>LoadScene());
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("Episode" + sceneNumber.ToString());
    }

    public void OpenEpisode(bool isOpen, string number)
    {
        sceneNumber = number;
        label.gameObject.SetActive(isOpen);
        label.text = number;
        btn.interactable = isOpen;
    }
}
