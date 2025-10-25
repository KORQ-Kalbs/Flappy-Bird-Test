using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager singleton;

    public AudioClip[] clips;

    AudioSource audioSource;

    void Awake()
    {
        singleton = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int clipIndex)
    {
        audioSource.PlayOneShot(clips[clipIndex]);
    }

}
