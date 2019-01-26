using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkBottle : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        HotAirBalloon hotAirBalloon = other.GetComponentInParent<HotAirBalloon>();

        if (hotAirBalloon)
        {
            GameState.NewMilkBottles += 1;
            Destroy(this.gameObject);
        }
    }
}
