﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroComicConductor : MonoBehaviour
{
    public Image StartScreenImage;
    public List<Sprite> ComicImages;
    public Image ComicImage;
    public Button SkipButton;

    private string nextScene = "CowyBalloon";

    private bool comicRunning;

    void Start()
    {
        comicRunning = false;
        StartScreenImage.enabled = true;
        ComicImage.enabled = false;
    }

    public void StartComic()
    {
        StartScreenImage.enabled = false;
        ComicImage.enabled = true;
        comicRunning = true;
        StartCoroutine(PlayComic());
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (comicRunning)
            {
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                StartComic();
            }
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
