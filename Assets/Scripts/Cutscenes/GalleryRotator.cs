using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryRotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Time.deltaTime * 75f, 0f);
    }
}
