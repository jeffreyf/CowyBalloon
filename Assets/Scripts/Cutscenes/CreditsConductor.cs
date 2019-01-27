using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsConductor : MonoBehaviour
{
    public CanvasGroup cg;
    public Transform credits;
    public Transform target;

    public float duration = 10f;

    public AudioSource audioSource;
    public AudioClip polkaClip;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        if(!cg)
        {
            cg = GetComponentInChildren<CanvasGroup>();
        }

        yield return new WaitForSeconds(1.0f);

        float t = 0f;

        Vector3 startPosition = credits.position;

        while(t < duration)
        {
            t += Time.deltaTime;

            credits.transform.position = Vector3.Lerp(startPosition, target.position, t / duration);

            yield return null;
        }

        credits.transform.position = target.position;

        yield return null;

        t = 0f;

        while(t < 1.0f)
        {
            t += Time.deltaTime;

            cg.alpha = Mathf.Lerp(1.0f, 0.0f, t);

            yield return null;
        }

        cg.alpha = 0f;

        audioSource.clip = polkaClip;
        audioSource.Play();

        StartCoroutine(FindObjectOfType<GalleryTrain>().MoveRight());

        yield break;
    }
}
