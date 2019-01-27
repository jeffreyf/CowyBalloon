using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayAnimation : MonoBehaviour
{
    public void StopAnimation()
    {
        Debug.Log("stopping hay explosion animation");
        Destroy(this.gameObject);
    }
}
