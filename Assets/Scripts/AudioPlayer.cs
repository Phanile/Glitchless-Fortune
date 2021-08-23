using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public AudioClip ricochetClip;

    public void PlayClip(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
