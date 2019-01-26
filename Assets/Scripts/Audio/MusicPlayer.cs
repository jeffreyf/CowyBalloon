using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public List<AudioSource> audios;


    public void SetVolumes(List<float> volumes)
    {
        for(int i = 0; i < volumes.Count && i < audios.Count; i++)
        {
            audios[i].volume = volumes[i];
        }
    }

}
