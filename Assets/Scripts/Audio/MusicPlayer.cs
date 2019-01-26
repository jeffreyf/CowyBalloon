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

}
