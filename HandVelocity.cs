using UnityEngine;

public class HandVelocity : MonoBehaviour
{
    public Vector3 Velocity { get; private set; }

    Vector3 lastPos;

    void Start()
    {
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        Velocity = (transform.position - lastPos) / Time.fixedDeltaTime;
        lastPos = transform.position;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // 掌心平面
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(0.09f, 0.02f, 0.10f));

        Gizmos.color = Color.blue; // 掌心方向
        Gizmos.DrawRay(Vector3.zero, Vector3.forward * 0.12f);
    }

}
