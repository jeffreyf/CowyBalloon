using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeTrigger : MonoBehaviour
{
    public float[] bottomVolumes = new float[4];
    public float[] topVolumes = new float[4];

    public Transform lowerBound;
    public Transform upperBound;

    public void OnTriggerStay(Collider other)
    {
        if(other.GetComponentInParent<HotAirBalloon>())
        {
            float ratioBetweenBounds = RatioBetweenBounds(other.transform.position.y);
            Debug.Log(ratioBetweenBounds);

            MusicPlayer.Instance.SetVolumes(LerpBetweenTwoArraysOfFloats(bottomVolumes, topVolumes, ratioBetweenBounds));
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<HotAirBalloon>())
        {
            float ratioBetweenBounds = RatioBetweenBounds(other.transform.position.y);

            if(ratioBetweenBounds > 0.5f)
            {
                MusicPlayer.Instance.SetVolumes(topVolumes);
            }
            else
            {
                MusicPlayer.Instance.SetVolumes(bottomVolumes);
            }
        }
    }


    public float RatioBetweenBounds(float yValue)
    {
        float difference = upperBound.position.y - lowerBound.position.y;
        float fromMin = yValue - lowerBound.position.y;
        float ratio = fromMin / difference;
        return Mathf.Clamp01(ratio);
    }

    // This should go into a utils class but whatever
    public static float[] LerpBetweenTwoArraysOfFloats(float[] min, float[] max, float ratio)
    {
        float[] lerped = new float[min.Length];

        for(int i = 0; i < min.Length && i < max.Length; i++)
        {
            lerped[i] = Mathf.Lerp(min[i], max[i], ratio);
        }

        return lerped;
    }
}
