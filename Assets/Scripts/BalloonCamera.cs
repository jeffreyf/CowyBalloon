using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonCamera : MonoBehaviour
{
    // May take peak at the target's rb to get a sense of how far ahead the camera should move
    public HotAirBalloon target;

    protected Vector3 velRef = Vector3.zero;

    protected Camera cam;

    public float maxVelocityLeeway = 5f; // This should actually be based off viewport position, may change later
    public float velocityMultiplier = 0.01f;
    public float velocityPower = 5f;

    protected float smoothTime = 0.1f; // How long it should take to move to the desired position

    public Vector2 yBounds = new Vector2(0f, 100000000000000f); // Change this second value to the moon when we get there

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

            if (rb)
            {
                //Debug.Log(viewPosition);
                // At the edge of the screen
                desiredPosition.y = target.transform.position.y + 0.5f;
                // Stay ahead of the balloon based on its velocity
                desiredPosition.y += Mathf.Clamp(Mathf.Pow(target.GetRigidbody().velocity.y, velocityPower) * velocityMultiplier, -maxVelocityLeeway, maxVelocityLeeway);

                desiredPosition.y = Mathf.Clamp(desiredPosition.y, yBounds[0], yBounds[1]);

            }
            else
            {
                // We're landing on the moon, so go to the max top.
                desiredPosition.y = yBounds[1];

            }
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velRef, smoothTime, Mathf.Infinity, Time.deltaTime);
        }
    }
}
