using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFades : MonoBehaviour
{
    public static StarFades Instance;

    public List<StarFader> faders = new List<StarFader>();

    private void OnEnable()
    {
        Instance = this;
    }


    public void Fade(float alpha)
    {
        for(int i = 0; i < faders.Count; i++)
        {
            faders[i].Fade(alpha);
        }
    }
}
