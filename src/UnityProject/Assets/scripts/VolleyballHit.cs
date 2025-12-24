//偵測排球與手腕打擊

using UnityEngine;

public class VolleyballHit : MonoBehaviour
{
    public float hitMultiplier = 0.7f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        HandVelocity hand = collision.collider.GetComponent<HandVelocity>();
        if (hand == null) return;

        float maxHandSpeed = 2.2f;
        Vector3 handVel = Vector3.ClampMagnitude(hand.Velocity, maxHandSpeed);

        if (handVel.magnitude < 0.4f) return;

        float mappedSpeed = Mathf.Sqrt(handVel.magnitude);

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(handVel.normalized * mappedSpeed * hitMultiplier,
                    ForceMode.VelocityChange);
    }
}
