using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    // Static instance for the singleton pattern
    public static AudioManager Instance;

    // AudioSource for music and sound effects
    public AudioSource musicSource;
    public AudioSource sfxSource;

    // List of AudioClips for background music
    public List<AudioClip> musicClips;

    // Dictionary for sound effects
    private Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();

    // List of AudioClips for sound effects
    public List<AudioClip> sfxClipList;
    public List<string> sfxClipNames;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // If instance is null, assign this instance to it
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist this GameObject across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }

        // Initialize the sound effects dictionary
        for (int i = 0; i < sfxClipList.Count; i++)
        {
            sfxClips[sfxClipNames[i]] = sfxClipList[i];
        }
    }

    // Method to play music
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    // Method to play sound effects
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    // Method to play music by index
    public void PlayMusicByIndex(int index)
    {
        if (index >= 0 && index < musicClips.Count)
        {
            PlayMusic(musicClips[index]);
        }
        else
        {
            Debug.LogError("Music index out of range.");
        }
    }

    // Method to play sound effects by name
    public void PlaySound(string soundName)
    {
        if (sfxClips.ContainsKey(soundName))
        {
            PlaySFX(sfxClips[soundName]);
        }
        else
        {
            Debug.LogError("Sound not found: " + soundName);
        }
    }
}
