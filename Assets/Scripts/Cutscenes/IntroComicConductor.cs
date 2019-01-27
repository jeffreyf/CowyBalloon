using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroComicConductor : MonoBehaviour
{
    public List<Sprite> ComicImages;
    public Image ComicImage;
    public Button SkipButton;

    private string nextScene = "CowyBalloon";

    void Start()
    {
        StartCoroutine(PlayComic());
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            SceneManager.LoadScene(nextScene);
        }
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
