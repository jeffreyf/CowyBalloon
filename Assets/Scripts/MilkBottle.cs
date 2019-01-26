using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkBottle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        HotAirBalloon hotAirBalloon = other.GetComponentInParent<HotAirBalloon>();

        if (hotAirBalloon)
        {
            GameState.NewMilkBottles += 1;
            Destroy(this);

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
    }
}
