using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCamera : MonoBehaviour
{
    // May take peak at the target's rb to get a sense of how far ahead the camera should move
    public HotAirBalloon target;

    protected Vector3 velRef = Vector3.zero;

    protected Camera cam;

    public float maxVelocityLeeway = 2.5f; // This should actually be based off viewport position, may change later
    public float velocityMultiplier = 1f;
    public float velocityPower = 2f;

    protected float smoothTime = 0.1f; // How long it should take to move to the desired position

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector3 desiredPosition = transform.position;

            Vector3 viewPosition = cam.WorldToViewportPoint(target.transform.position);

            Rigidbody rb = target.GetRigidbody();

            //Debug.Log(viewPosition);
            // At the edge of the screen
            desiredPosition.y = target.transform.position.y;
            // Stay ahead of the balloon based on its velocity
            desiredPosition.y += Mathf.Clamp(Mathf.Pow(target.GetRigidbody().velocity.y, velocityPower) * velocityMultiplier, -maxVelocityLeeway, maxVelocityLeeway);

            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velRef, smoothTime, Mathf.Infinity, Time.deltaTime);
        }
    }
}
