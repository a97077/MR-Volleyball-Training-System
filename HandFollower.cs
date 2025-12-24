using UnityEngine;

public class XRHandPalmFollower : MonoBehaviour
{
    public Transform xrHandWrist;

    // ´x¤ß°¾²¾¡]¶W­«­n¡^
    public Vector3 palmOffset = new Vector3(0f, 0f, 0.08f);

    void LateUpdate()
    {
        if (xrHandWrist == null) return;

        transform.position = xrHandWrist.TransformPoint(palmOffset);
        transform.rotation = xrHandWrist.rotation;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(0.09f, 0.02f, 0.10f));
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 0.1f);
    }
}