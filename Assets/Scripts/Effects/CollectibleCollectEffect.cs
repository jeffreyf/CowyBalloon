using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollectEffect : MonoBehaviour
{
    protected float duration = 0.5f; // How long it takes to move to the target when collected
    public ParticleSystem particles;

    public void BeginEffect(HotAirBalloon hotAirBalloon)
    {
        StartCoroutine(MoveToTransform(hotAirBalloon.GetBasketTransform()));
    }


    protected IEnumerator MoveToTransform(Transform target)
    {
        float t = 0f;

        Vector3 startPosition = transform.position;
        Vector3 startScale = transform.localScale;

        // Play some particles if we got em
        if(particles)
        {
            particles.Play();
        }

        // Play some audio
        PlayRandomlyChosenAudioClip audioPlayer = GetComponent<PlayRandomlyChosenAudioClip>();
        if(audioPlayer)
        {
            audioPlayer.PlayAudio();
        }
        else
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if(audioSource)
            {
                audioSource.Play();
            }
        }

        while(t < duration)
        {
            t += Time.deltaTime;
            float ellapsedRatio = t / duration;

            Vector3 newPos = Vector3.Lerp(startPosition, target.position, ellapsedRatio);
            newPos.z = startPosition.z - 3f * Mathf.Sin(ellapsedRatio * Mathf.PI);
            transform.position = newPos;
            transform.localScale = Vector3.Lerp(startScale, Vector3.one * 0.05f, ellapsedRatio);

            Debug.Log(ellapsedRatio);

            yield return null;
        }

        transform.position = target.position;
        transform.localScale = Vector3.zero;

        yield break;
    }
}
