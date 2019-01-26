using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool collected;
    public Vector3 InitialScale;

    void Start()
    {
        InitialScale = GetComponent<Transform>().localScale;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!collected)
        {
            // Debug.Log("Triggered by: " + other.name);
            Debug.Log("Collecting a collectible");

            HotAirBalloon hotAirBalloon = other.GetComponentInParent<HotAirBalloon>();

            if (hotAirBalloon)
            {
                collected = true;
                GameState.NewCollectibles.Add(this.gameObject);

                CollectibleCollectEffect effect = GetComponent<CollectibleCollectEffect>();
                if (effect)
                {
                    effect.BeginEffect(hotAirBalloon);
                }
                else
                {
                    GetComponent<Transform>().localScale = Vector3.zero;
                }
            }
        // } else {
            // Debug.Log("Ignoring trigger from: " + other.name);
        }
    }
}
