using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    public static float volume = 0.5f;


    // == fields ==
    private AudioSource audioSource;

    // == private methods ==

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = volume;
    }

    //void Update()
    //{

        // Setting volume option of Audio Source to be equal to musicVolume
        //audioSource.volume = volume;
    //}

    // == public methods ==
    public void PlayOneShot(AudioClip clip)
    {
        if (clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void ResumeMusic()
    {
        audioSource.Play();
    }

    public void SetVolume(float vol)
    {
        volume = vol;
        audioSource.volume = volume;
    }

    public static SoundController FindSoundController()
    {
        var soundController = FindObjectOfType<SoundController>();
        if (!soundController)
        {
            Debug.LogWarning("No Sound Controller Found, no sounds will play");
        }
        return soundController;
    }

}
