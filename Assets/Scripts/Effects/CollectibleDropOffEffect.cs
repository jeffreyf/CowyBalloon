using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleDropOffEffect : MonoBehaviour
{
    protected float effectDuration = 1.0f; // How long it takes to move to the target when collected
    public ParticleSystem particles;

    public void BeginEffect(Vector3 startPosition, Vector3 targetPosition, Vector3 targetScale)
    {
        StartCoroutine(MoveToTransform(startPosition, targetPosition, targetScale));
    }

    protected IEnumerator MoveToTransform(Vector3 startPosition, Vector3 targetPosition, Vector3 targetScale)
    {
        float elapsedTime = 0f;

        // Play some particles if we got em
        if (particles)
        {
            particles.Play();
        }

        transform.localScale = targetScale;

        while (elapsedTime < effectDuration)
        {
            elapsedTime += Time.deltaTime;
            float elapsedRatio = elapsedTime / effectDuration;

            Vector3 newPos = Vector3.Lerp(startPosition, targetPosition, elapsedRatio);
            newPos.z = startPosition.z - 3f * Mathf.Sin(elapsedRatio * Mathf.PI);
            transform.position = newPos;

            // Debug.Log(elapsedRatio);

            yield return null;
        }

        transform.position = targetPosition;
        yield break;
    }
}
