using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);

        HotAirBalloon hotAirBalloon = other.GetComponentInParent<HotAirBalloon>();

        if(hotAirBalloon)
        {
            Destroy(hotAirBalloon.gameObject);
        }
    }
}
