using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    [SerializeField] private float movementVelocity;
    [SerializeField] private float rotationalVelocity;

    private Rigidbody rb;

    private bool isRolling;

    public event Action<int> RollComplete;

    private const float NotRollingThreshold = 0.1f;
    private const float DiceUpThreshold = 0.9f;

    public int DiceValue { get; private set; }

    private System.Random random;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        random = new System.Random();
        // Debug.Log(rb.maxAngularVelocity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
        {
            rb.velocity = new Vector3(
                (float)(random.NextDouble() * movementVelocity - movementVelocity / 2),
                movementVelocity,
                (float)(random.NextDouble() * movementVelocity - movementVelocity / 2));
            rb.angularVelocity = new Vector3(
                (float)(random.NextDouble() * rotationalVelocity * 2 - rotationalVelocity),
                (float)(random.NextDouble() * rotationalVelocity * 2 - rotationalVelocity),
                (float)(random.NextDouble() * rotationalVelocity * 2 - rotationalVelocity));
            isRolling = true;
        }

        if (isRolling && rb.velocity.magnitude < NotRollingThreshold && rb.angularVelocity.magnitude < NotRollingThreshold)
        {
            DiceValue = EvaluateDiceValue();
            Debug.Log(DiceValue);
            RollComplete?.Invoke(DiceValue);
            isRolling = false;
        }
    }

    private int EvaluateDiceValue()
    {
        if (Vector3.Dot(transform.up, Vector3.up) > DiceUpThreshold) return 1;
        if (Vector3.Dot(transform.right, Vector3.up) > DiceUpThreshold) return 2;
        if (Vector3.Dot(transform.forward, Vector3.up) > DiceUpThreshold) return 3;
        if (Vector3.Dot(transform.forward * -1, Vector3.up) > DiceUpThreshold) return 4;
        if (Vector3.Dot(transform.right * -1, Vector3.up) > DiceUpThreshold) return 5;
        if (Vector3.Dot(transform.up * -1, Vector3.up) > DiceUpThreshold) return 6;
        
        return 0;
    }
}
