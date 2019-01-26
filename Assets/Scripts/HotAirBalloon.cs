using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    public Vector3 movementSpeeds = Vector3.one;
    protected Vector3 input;

    protected Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal") * Vector3.right + Input.GetAxisRaw("Vertical") * Vector3.forward;

        if (Input.GetButton("Jump"))
        {
            input.y = 1.0f;
        }
    }


    private void FixedUpdate()
    {
        Vector3 force = new Vector3(input.x * movementSpeeds.x, input.y * movementSpeeds.y, input.z * movementSpeeds.z) * Time.deltaTime;
        rb.AddForce(force);
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
