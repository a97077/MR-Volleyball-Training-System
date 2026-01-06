using UnityEngine;

public class ForearmBump : MonoBehaviour
{
    [Header("Bump Power")]
    [Range(1.5f, 10f)]
    public float bumpPower = 3.2f;     // 整體力量（越大彈越高）

    [Header("Arc Control")]
    [Range(0f, 1f)]
    public float upwardWeight = 0.85f; // 0.6~0.9 = 高拋弧線

    [Header("Sweet Spot")]
    public float sweetSpotRadius = 0.18f; // 前臂中心穩定範圍

    [Header("Cooldown")]
    public float cooldown = 0.2f;

    float lastBumpTime;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Volleyball")) return;

        Rigidbody ball = other.attachedRigidbody;
        if (ball == null) return;

        if (Time.time - lastBumpTime < cooldown) return;

        PerformBump(ball);
    }

    void PerformBump(Rigidbody ball)
    {
        lastBumpTime = Time.time;

        // 1️⃣ 找球相對前臂中心的位置
        Vector3 localHitPos = transform.InverseTransformPoint(ball.position);

        // 2️⃣ 甜蜜點判定（太邊緣 → 不穩）
        float centerDist = new Vector2(localHitPos.x, localHitPos.z).magnitude;
        float stability = Mathf.Clamp01(1f - centerDist / sweetSpotRadius);

        // 3️⃣ 方向：強制往上 + 微量前方
        Vector3 forward = transform.forward;
        Vector3 bumpDir =
            Vector3.up * upwardWeight +
            forward * (1f - upwardWeight);

        bumpDir.Normalize();

        // 4️⃣ 清掉舊速度（托球關鍵）
        ball.linearVelocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        // 5️⃣ 加力（穩定度影響力量）
        float finalPower = bumpPower * Mathf.Lerp(0.6f, 1f, stability);

        ball.AddForce(
            bumpDir * finalPower,
            ForceMode.VelocityChange
        );

        Debug.DrawRay(ball.position, bumpDir, Color.green, 1f);
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        // 接球面
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one * sweetSpotRadius * 2f);
    }
#endif
}