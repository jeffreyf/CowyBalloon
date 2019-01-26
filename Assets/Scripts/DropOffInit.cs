using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffInit : MonoBehaviour
{
    void Start()
    {
        foreach (var dropOffPosition in GameObject.FindGameObjectsWithTag("DropOffPosition"))
        {
            GameState.AvailableDropOffPositions.Enqueue(dropOffPosition.transform.position);
        }
    }
}
