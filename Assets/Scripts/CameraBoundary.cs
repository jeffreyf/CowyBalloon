using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    public Vector3 boundary = Vector3.left;

    public bool onlyOnStart = false; // If there's no camera movement, set this to true.

    // Start is called before the first frame update
    void Start()
    {
        SetPosition();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!onlyOnStart)
        {
            SetPosition();
        }
    }

    private void SetPosition()
    {
        Vector3 worldPosition = Camera.main.ViewportToWorldPoint(boundary);
        worldPosition.z = transform.position.z;
        transform.position = worldPosition;
    }
}
