using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    public AudioSource sfxSource;

    [Header("Clips")]
    public AudioClip buttonClick;
    public AudioClip catchCorrect;
    public AudioClip catchWrong;
    public AudioClip goalScored;
    public AudioClip powerUp;

    [Header("Variación procedural")]
    [Range(0.5f, 1.5f)] public float pitchMin = 0.92f;
    [Range(0.5f, 1.5f)] public float pitchMax = 1.08f;
    [Range(0f, 1f)] public float volumeMin = 0.9f;
    [Range(0f, 1f)] public float volumeMax = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayButtonClick()
    {
        PlaySound(buttonClick);
    }

    public void PlayCatchCorrect()
    {
        PlaySound(catchCorrect);
    }

    public void PlayCatchWrong()
    {
        PlaySound(catchWrong);
    }

    public void PlayGoalScored()
    {
        PlaySound(goalScored);
    }

    public void PlayPowerUp()
    {
        PlaySound(powerUp);
    }

    void PlaySound(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;

        // Variación aleatoria de tono y volumen para que no suene igual cada vez
        sfxSource.pitch = Random.Range(pitchMin, pitchMax);
        float volumeScale = Random.Range(volumeMin, volumeMax);

        sfxSource.PlayOneShot(clip, volumeScale);
    }
}