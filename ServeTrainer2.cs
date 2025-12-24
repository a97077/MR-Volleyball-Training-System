using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))] // 強制要求物件必須有 LineRenderer
public class ServeTrainer2 : MonoBehaviour
{
    [Header("發球位置")]
    public GameObject ballPrefab;
    public Transform spawnPoint;

    [Header("發球設定 (可即時調整)")]
    [Range(1f, 30f)]
    public float serveSpeed = 12f;     // 發球速度
    [Range(0f, 90f)]
    public float launchAngle = 30f;    // 發球仰角
    public float serveInterval = 2f;   // 發球間隔
    public bool autoServe = false;

    [Header("軌跡線設定")]
    public int trajectoryPoints = 30;  // 軌跡線要畫幾個點 (越多越平滑)
    public float timeStep = 0.1f;      // 每個點之間的時間間隔 (秒)

    private Coroutine serveCoroutine;
    private bool isRunning = false;
    private LineRenderer lineRenderer;

    void Start()
    {
        // 自動獲取同一物件上的 LineRenderer 組件
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // --- 新增功能：每一幀都繪製預測軌跡 ---
        DrawTrajectory();

        // 控制自動發球的開關
        if (autoServe && !isRunning) StartServing();
        else if (!autoServe && isRunning) StopServing();
    }

    // --- 核心功能：計算並繪製軌跡 ---
    void DrawTrajectory()
    {
        if (spawnPoint == null || lineRenderer == null) return;

        // 設定 LineRenderer 需要畫幾個點
        lineRenderer.positionCount = trajectoryPoints;

        // 1. 計算初始速度向量 (這部分與實際發球邏輯相同)
        Vector3 initialVelocity = CalculateLaunchVelocity();

        // 起始點位置
        Vector3 startingPosition = spawnPoint.position;

        // 2. 使用迴圈計算未來每個時間點的位置
        for (int i = 0; i < trajectoryPoints; i++)
        {
            // 計算目前這個點代表的時間 (例如: 0秒, 0.1秒, 0.2秒...)
            float timePassed = i * timeStep;

            // --- 物理拋體公式 ---
            // 位置 = 起始點 + (初速度 * 時間) + (0.5 * 重力 * 時間平方)
            Vector3 movementVector = initialVelocity * timePassed;
            Vector3 gravityVector = Physics.gravity * 0.5f * timePassed * timePassed;

            Vector3 calculatedPosition = startingPosition + movementVector + gravityVector;

            // 設定 LineRenderer 第 i 個點的位置
            lineRenderer.SetPosition(i, calculatedPosition);
        }
    }

    // --- 輔助功能：計算發射速度向量 ---
    // 抽離出來是為了確保「預測線」和「實際發球」用的是同一套計算標準
    private Vector3 CalculateLaunchVelocity()
    {
        if (spawnPoint == null) return Vector3.zero;
        // 以 SpawnPoint 的 Forward 為基準，往 Right 方向轉動負的角度 (仰角)
        Vector3 direction = Quaternion.AngleAxis(-launchAngle, spawnPoint.right) * spawnPoint.forward;
        return direction * serveSpeed;
    }


    // --- 以下是發球控制邏輯 (與之前相同，但使用了新的速度計算函數) ---
    public void StartServing()
    {
        if (serveCoroutine == null)
        {
            isRunning = true;
            serveCoroutine = StartCoroutine(ServeLoop());
        }
    }

    public void StopServing()
    {
        if (serveCoroutine != null)
        {
            StopCoroutine(serveCoroutine);
            serveCoroutine = null;
            isRunning = false;
        }
    }

    IEnumerator ServeLoop()
    {
        while (true)
        {
            if (ballPrefab != null && spawnPoint != null)
            {
                GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
                Rigidbody rb = ball.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    // 使用與畫線相同的計算結果來發球
                    Vector3 finalVelocity = CalculateLaunchVelocity();
                    // 使用 VelocityChange 模式，直接設定速度，忽略質量影響，最精確
                    rb.AddForce(finalVelocity, ForceMode.VelocityChange);
                }
                Destroy(ball, 4f);
            }
            yield return new WaitForSeconds(serveInterval);
        }
    }
}