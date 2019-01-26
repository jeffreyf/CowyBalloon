using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    public Vector3 movementSpeeds = Vector3.one;
    public Vector3 maxVelocity = new Vector3(20f, 20f, 0f);
    protected Vector3 input;

    protected Rigidbody rb;

    [SerializeField]
    protected Transform basket;

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
        float energyNeeded = Time.deltaTime * input.y * GameState.EnergyDecayRate;
        if (GameState.Energy > energyNeeded)
        {
            Vector2 force = new Vector2(input.x * movementSpeeds.x, input.y * movementSpeeds.y) * Time.deltaTime;
            rb.AddForce(force);
            GameState.Energy -= energyNeeded;
        }

        // Clamp velocity
        Vector3 velocity = rb.velocity;
        velocity = new Vector3(Mathf.Clamp(velocity.x, -maxVelocity.x, maxVelocity.x),
                               Mathf.Clamp(velocity.y, -maxVelocity.y, maxVelocity.y),
                               Mathf.Clamp(velocity.z, -maxVelocity.z, maxVelocity.z));

        rb.velocity = velocity;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Balloon has hit a ground object: " + other.gameObject.name);
            // TODO: stop balloon from bouncing when it hits the ground?
            GameState.TotalMilkBottles += GameState.NewMilkBottles;
            GameState.NewMilkBottles = 0;
            GameState.Energy = GameState.MaxEnergy;

            DropOffCollectibles();
        }
    }

    private void DropOffCollectibles()
    {
        foreach (var collectible in GameState.NewCollectibles)
        {
            Transform collectibleTransform = collectible.GetComponent<Transform>();
            collectibleTransform.position = GameState.AvailableDropOffPositions.Dequeue();
            collectibleTransform.localScale = collectible.GetComponent<Collectible>().InitialScale;

            GameState.CollectedCollectibles.Add(collectible);
        }
        GameState.NewCollectibles.Clear();
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public Transform GetBasketTransform()
    {
        return basket;
    }
}
