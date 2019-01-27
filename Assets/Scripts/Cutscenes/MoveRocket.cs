using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    public Transform target;
    public ParticleSystem particles;
    public float duration = 0.5f;
    public CanvasGroup cg;

    [ContextMenu("Play")]
    public void TestPlay()
    {
        StartCoroutine(MoveToTransform(target));
    }

    public IEnumerator MoveToTransform(Transform target)
    {
        yield return null;

        float t = 0f;

        Vector3 startPosition = transform.position;

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
            transform.position = newPos;
            cg.alpha = Mathf.Clamp01(ellapsedRatio * 10f);

            yield return null;
        }

        transform.position = target.position;
        cg.alpha = 1.0f;

        yield return new WaitForSeconds(0.5f);

        yield break;
    }
}
