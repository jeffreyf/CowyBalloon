using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    public Vector3 movementSpeeds = Vector3.one;
    protected Vector3 input;

    protected Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal") * Vector3.right;

        if (Input.GetButton("Jump"))
        {
            input.y = 1.0f;
        }
    }

    private void FixedUpdate()
    {
        Vector2 force = new Vector2(input.x * movementSpeeds.x, input.y * movementSpeeds.y) * Time.deltaTime;
        rb.AddForce(force);
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
