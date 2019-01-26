using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomlyChosenAudioClip : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public AudioSource audioSource;

    private void Start()
    {
        if(!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayAudio()
    {
        if (audioClips.Count > 0)
        {
            AudioClip audioClip = audioClips[Random.Range(0, audioClips.Count)];

            audioSource.PlayOneShot(audioClip);
        }
    }
}
