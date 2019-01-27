using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonTrigger : MonoBehaviour
{
    public Transform target; // The landing pad
    public float duration = 3f;
    public ParticleSystem particles;

    private void OnTriggerEnter(Collider other)
    {
        HotAirBalloon hotAirBalloon = other.GetComponentInParent<HotAirBalloon>();

        if(hotAirBalloon)
        {
            Rigidbody rb = hotAirBalloon.GetRigidbody();
            Destroy(rb);
            StartCoroutine(LandBalloon(hotAirBalloon.transform));
        }
    }

    protected IEnumerator LandBalloon(Transform balloon)
    {
        float t = 0f;

        Vector3 startPosition = balloon.position;
        Vector3 startScale = balloon.localScale;

        // Play some particles if we got em
        if (particles)
        {
            particles.Play();
        }

        // Play some audio
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

        while (t < duration)
        {
            t += Time.deltaTime;
            float ellapsedRatio = t / duration;

            Vector3 newPos = Vector3.Lerp(startPosition, target.position, ellapsedRatio);
            newPos.z = newPos.z - 3f * Mathf.Sin(ellapsedRatio * Mathf.PI);
            balloon.position = newPos;

            yield return null;
        }

        balloon.position = target.position;

        yield break;
    }
}
