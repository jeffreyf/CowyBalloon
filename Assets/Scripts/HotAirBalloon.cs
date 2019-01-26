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
        float energyNeeded = Time.deltaTime * input.y * GameState.EnergyDecayRate;
        if (GameState.Energy > energyNeeded)
        {
            Vector2 force = new Vector2(input.x * movementSpeeds.x, input.y * movementSpeeds.y) * Time.deltaTime;
            rb.AddForce(force);
            GameState.Energy -= energyNeeded;
        }
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
}
