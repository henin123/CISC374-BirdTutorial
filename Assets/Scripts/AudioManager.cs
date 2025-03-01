using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source----------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------Audio Clip----------------")]
    public AudioClip jump;
    public AudioClip point;
    public AudioClip endGame;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
