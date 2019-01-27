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
        
        SceneManager.LoadScene(nextScene);
    }
}
