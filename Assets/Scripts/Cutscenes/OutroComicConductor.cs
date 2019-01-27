using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OutroComicConductor : MonoBehaviour
{
    public List<Sprite> ComicImages;
    public Image ComicImage;

    public string nextScene = "Gallery";

    void Start()
    {
        StartCoroutine(PlayComic());
    }

    private IEnumerator PlayComic()
    {
        for (int i = 0; i < ComicImages.Count; i++)
		{
            ComicImage.sprite = ComicImages[i];
            yield return new WaitForSeconds(2.0f);
		}

        yield return StartCoroutine(FadeAudio());

        SceneManager.LoadScene(nextScene);
    }

    IEnumerator FadeAudio()
    {
        float t = 0f;
        AudioSource audioSource = FindObjectOfType<AudioSource>();

        while (t < 1.0f)
        {
            t += Time.deltaTime * 8f;
            audioSource.volume = 1.0f - t;
            yield return null;
        }

        yield break;
    }
}
