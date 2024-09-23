using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip backgroundMusic;    public AudioClip buttonClicked;
    public AudioClip powerUpCollected;
    public AudioClip fiberglassCollected;
    public AudioClip bite;
    public AudioClip collide;
    public AudioClip die;
    public AudioClip landing;
    public AudioClip flying;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        if(sfxSource.isActiveAndEnabled)
            sfxSource.PlayOneShot(clip);
    }

    public void DisableSfx()
    {
        sfxSource.gameObject.SetActive(false);
    }
}
