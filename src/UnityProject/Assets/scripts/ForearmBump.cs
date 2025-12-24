//¤âÁu¸I¼²¾¹
using UnityEngine;

public class ForearmBump : MonoBehaviour
{
    public BumpCoordinator coordinator;
    public bool isLeft;   // Inspector ¤Ä¿ï

    public Vector3 Normal => transform.up;

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Volleyball")) return;

        coordinator.NotifyContact(this, collision.rigidbody);
    }
}