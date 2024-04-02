using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = 0.1f; // Set volume to 0.1
        }
        else if (instance != this)
        {
            instance.UpdateAudioSource(GetComponent<AudioSource>());
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateAudioSource(AudioSource newSource)
    {
        if (newSource.clip != null && audioSource.clip != newSource.clip)
        {
            audioSource.clip = newSource.clip; // Assign the new clip
            audioSource.volume = 0.1f; // Update volume to 0.1
            audioSource.Play(); // Play the new clip
        }
    }

    // New method to handle transition to the menu
    public void SwitchToMenuMusic(AudioSource menuAudioSource)
    {
        // Stop the current audio clip if it's playing
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Update the audio source to play the menu music
        UpdateAudioSource(menuAudioSource);
    }
}
