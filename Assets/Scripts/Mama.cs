using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mama : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Balloon has hit Mama!");

            PlayRandomlyChosenAudioClip audioPlayer = GetComponent<PlayRandomlyChosenAudioClip>();
            if (audioPlayer)
            {
                audioPlayer.PlayAudio();
            }
            else
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource)
                {
                    audioSource.Play();
                }
            }
        }
    }
}
