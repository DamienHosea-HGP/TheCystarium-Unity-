using UnityEngine;

public class MusicController : MonoBehaviour
{
    public int songIndex;

    void Start()
    {
        // Play the song at the specified index
        AudioManager.Instance.PlayMusicByIndex(songIndex);
    }

    public void PlaySong(int index)
    {
        AudioManager.Instance.PlayMusicByIndex(index);
    }
}
