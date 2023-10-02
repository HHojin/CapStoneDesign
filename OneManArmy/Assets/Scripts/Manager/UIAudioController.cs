using UnityEngine;

public class UIAudioController : MonoBehaviour
{
    public AudioClip audioStatBtn;
    public AudioClip audioStatDecideBtn;
    AudioSource audioSource;

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string action)
    {
        audioSource.Stop();

        switch (action)
        {
            case "Stat":
                audioSource.clip = audioStatBtn;
                break;
            case "StatDecide":
                audioSource.clip = audioStatDecideBtn;
                break;

        }

        audioSource.Play();
    }
}