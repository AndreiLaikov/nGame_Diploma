using UnityEngine;

public class Episode : MonoBehaviour
{
    public int GroupNumber;
    public EpisodeButton[] EpisodeButtons;
    public int openedEpisodes;

    private void OnEnable()
    {
        string key = "Episode" + GroupNumber.ToString();
        openedEpisodes = PlayerPrefs.GetInt(key, 0);

        ShowEpisodes();
    }

    private void ShowEpisodes()
    {
        for (int i = 0; i < EpisodeButtons.Length; i++)
        {
            string number = GroupNumber.ToString() + i.ToString();
            EpisodeButtons[i].OpenEpisode(openedEpisodes >= i, number);
        }
    }
}
