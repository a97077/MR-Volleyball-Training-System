using UnityEngine;

public class VolleyballHit : MonoBehaviour
{
    [Header("打擊力量設定")]
    [Tooltip("基礎力量倍率，數值越高球速越快")]
    public float hitPower = 2.5f;      // 從 1.8 提升到 2.5

    [Tooltip("速度感加權 (1.0為線性, 1.2~1.5 會讓重扣更有感)")]
    public float speedSensitivity = 1.3f;

    [Tooltip("球速上限 (職業排球扣球可達 30m/s 以上)")]
    public float maxBallSpeed = 45f;   // 提高上限讓球噴得出去

    [Header("方向與反彈")]
    [Range(0, 1)]
    public float directionForwardBias = 0.7f; // 更多依賴掌心方向

    private Rigidbody rb;
    private float cooldown = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 使用連續碰撞偵測，防止高速球穿透牆壁
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void Update() => cooldown -= Time.deltaTime;

    private void OnTriggerEnter(Collider other)
    {
        if (cooldown > 0) return;

        HandVelocity hand = other.GetComponent<HandVelocity>(); // 取得手部速度組件
        if (hand == null) return;

        // 檢查手速是否達到擊球門檻
        if (hand.Velocity.magnitude < 0.8f) return;

        ApplySuperHit(hand);
    }

    void ApplySuperHit(HandVelocity hand)
    {
        cooldown = 0.15f; // 縮短冷卻時間，讓反應更即時

        // 1. 徹底清除球目前的慣性
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // 2. 計算方向：混合手勢方向與掌心前方的向量
        Vector3 palmDir = hand.transform.forward;
        Vector3 hitDir = Vector3.Lerp(hand.Velocity.normalized, palmDir, directionForwardBias).normalized;

        // 3. 關鍵改動：非線性速度計算
        // 使用 Mathf.Pow 讓「快手速」產生的球速遠大於「慢手速」
        float rawHandSpeed = hand.Velocity.magnitude;
        float calculatedSpeed = Mathf.Pow(rawHandSpeed, speedSensitivity) * hitPower;

        // 限制在合理範圍內
        float finalSpeed = Mathf.Clamp(calculatedSpeed, 8f, maxBallSpeed);

        // 4. 施加瞬間衝量 (VelocityChange 會忽略質量，手感最直接)
        rb.AddForce(hitDir * finalSpeed, ForceMode.VelocityChange);

        // 5. 增加強烈的旋轉 (Topspin)，讓球下墜更明顯，更有扣球感
        rb.AddTorque(hand.transform.right * finalSpeed, ForceMode.Impulse);

        Debug.Log($"強力扣球！手速: {rawHandSpeed:F1}, 最終輸出球速: {finalSpeed:F1}");
    }
}