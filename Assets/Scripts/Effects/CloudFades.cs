using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFades : MonoBehaviour
{
    public static CloudFades Instance;

    public List<CloudFader> faders = new List<CloudFader>();

    private void OnEnable()
    {
        Instance = this;
    }


    public void Fade(float alpha)
    {
        for(int i = 0; i < faders.Count; i++)
        {
            faders[i].Fade(1.0f - alpha);
        }
    }
}
