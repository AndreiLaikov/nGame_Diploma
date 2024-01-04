using UnityEngine;

public class PrefsTester : MonoBehaviour
{
    public int GroupNumber;
    public int EpisodeNumber;

    [ContextMenu("Set")]
    public void Set()
    {
        string key = "Episode" + GroupNumber.ToString();
        PlayerPrefs.SetInt(key, EpisodeNumber);
    }
}
