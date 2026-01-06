# SDD — Module Design  
## MR 沙灘排球訓練系統（Meta Quest 3 + Unity）

---

## 1. MR Scene Manager

### 1.1 模組職責（Responsibilities）

- 啟動 Mixed Reality Passthrough 模式
- 執行平面偵測（Plane Detection）以取得地面資訊
- 在真實地面上生成虛擬排球場 Prefab
- 建立與管理 Anchor，固定虛擬場景位置，避免漂移

---

### 1.2 類別設計（Class Design）

```csharp
class MRSceneManager
{
    void InitPassthrough();
    void ScanFloorPlane();
    void PlaceCourt(Vector3 position, Quaternion rotation);
    void CreateAnchor(Transform courtTransform);
}
1.3 資料輸入 / 輸出（Inputs / Outputs）
Input：

使用者確認的地面位置

平面偵測結果

Output：

排球場 Transform

場景 Anchor 資訊

2. Player Tracking Module
2.1 模組職責（Responsibilities）
取得手部追蹤資料（手掌、手腕、前臂）

即時更新手部世界座標

計算手部移動速度與揮動方向

2.2 類別設計（Class Design）
csharp
複製程式碼
class HandTracker
{
    Vector3 GetPalmPosition();
    Vector3 GetWristPosition();
    Vector3 GetHandVelocity();
}
2.3 備註
本模組僅負責資料蒐集，不進行動作判斷

所有輸出資料將交由 Motion Recognition Module 處理

3. Motion Recognition Module
3.1 模組職責（Responsibilities）
根據手部資料判斷玩家動作類型

辨識以下排球動作：

接球（Bump）

托球（Set）

扣球（Spike）

在與排球碰撞時決定動作結果

3.2 類別設計（Class Design）
csharp
複製程式碼
enum HitType
{
    None,
    Bump,
    Set,
    Spike
}

class MotionRecognizer
{
    HitType DetectHitType(Vector3 handVelocity, Vector3 palmNormal);
}
3.3 輸出結果
擊球類型（HitType）

擊球方向向量

力量係數

4. Ball Physics & Interaction Module
4.1 模組職責（Responsibilities）
管理排球 Rigidbody 與物理參數

接收動作辨識結果並計算球的反饋行為

控制球的速度、方向與反彈角度

4.2 類別設計（Class Design）
csharp
複製程式碼
class VolleyballPhysics
{
    void ApplyHitForce(HitType hitType, Vector3 direction, float power);
    void ResetBall();
}
4.3 計算邏輯說明
球速 = 基礎速度 + 手部揮動速度 × 動作係數

不同 HitType 對應不同係數與反彈角度

5. NPC Controller Module
5.1 模組職責（Responsibilities）
控制 NPC 的站位與移動

模擬基本排球行為：

接球

回球

發球

作為玩家訓練的對手

5.2 類別設計（Class Design）
csharp
複製程式碼
class NPCController
{
    void MoveToPosition(Vector3 targetPos);
    void ReceiveBall();
    void ServeBall();
}
6. Game Flow Manager
6.1 模組職責（Responsibilities）
管理整體訓練流程

控制遊戲狀態：

開始

Rally 中

結束與重置

管理分數與 UI 顯示

6.2 類別設計（Class Design）
csharp
複製程式碼
enum GameState
{
    Ready,
    Playing,
    GameOver
}

class GameFlowManager
{
    void StartGame();
    void EndGame();
    void ResetGame();
}
7. 模組關係總覽
text
複製程式碼
MR Scene Manager
        ↓
Player Tracking Module
        ↓
Motion Recognition Module
        ↓
Ball Physics & Interaction Module
        ↓
NPC Controller Module
        ↓
Game Flow Manager
8. 設計原則
各模組職責單一，避免耦合

手部追蹤、動作辨識與物理計算可獨立調整

易於擴充新的訓練模式與動作類型

9. 總結
本 Module Design 文件定義了 MR 排球訓練系統中各核心模組的職責與介面，
可直接對應 Unity 專案中的 Script 架構，作為後續 MVP 與完整產品開發的實作依據。