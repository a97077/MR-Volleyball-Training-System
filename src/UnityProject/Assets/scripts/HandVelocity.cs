using UnityEngine;
using System.Collections.Generic;

public class HandVelocity : MonoBehaviour
{
    public Vector3 Velocity { get; private set; }
    private Vector3 lastPos;
    private Queue<Vector3> velocitySamples = new Queue<Vector3>();
    private int maxSamples = 5;

    void Start() => lastPos = transform.position;

    void FixedUpdate()
    {
        Vector3 currentVelocity = (transform.position - lastPos) / Time.fixedDeltaTime;
        lastPos = transform.position;

        velocitySamples.Enqueue(currentVelocity);
        if (velocitySamples.Count > maxSamples) velocitySamples.Dequeue();

        Vector3 sum = Vector3.zero;
        foreach (var v in velocitySamples) sum += v;
        Velocity = sum / velocitySamples.Count;
    }
}