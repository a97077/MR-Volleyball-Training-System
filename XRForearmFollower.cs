using UnityEngine;

public class XRForearmFollower : MonoBehaviour
{
    public Transform xrHandWrist;

    // 前臂偏移（往手肘方向）
    public Vector3 forearmOffset = new Vector3(0f, -0.12f, 0.03f);

    void LateUpdate()
    {
        if (xrHandWrist == null) return;

        transform.position = xrHandWrist.TransformPoint(forearmOffset);
        transform.rotation = xrHandWrist.rotation;
    }
}