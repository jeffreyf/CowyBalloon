using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance
    {
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType<MusicPlayer>();
            }

            if(!instance)
            {
                Debug.LogError("NO MUSICPLAYER IN THE SCENE");
            }

            return instance;
        }
    }
    protected static MusicPlayer instance;

    public List<AudioSource> audios;

    private void Update()
    {
#if !UNITY_WEBGL
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif
    }

    private void OnEnable()
    {
        instance = this;
    }

    public void SetVolumes(float[] volumes)
    {
        for(int i = 0; i < volumes.Length && i < audios.Count; i++)
        {
            audios[i].volume = volumes[i];
        }
    }

    public IEnumerator FadeAllVolumes(float duration=1f)
    {
        float t = 0f;
        float[] startVolumes = new float[audios.Count];
        float[] endVolumes = new float[audios.Count];

        while(t < duration)
        {
            t += Time.deltaTime;

            SetVolumes(MusicFadeTrigger.LerpBetweenTwoArraysOfFloats(startVolumes, endVolumes, t / duration));
            yield return null;
        }

        SetVolumes(endVolumes);

        yield break;
    }

}
