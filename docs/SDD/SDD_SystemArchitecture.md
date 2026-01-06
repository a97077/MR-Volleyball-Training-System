# SDD — System Architecture  
## MR 沙灘排球訓練系統（Meta Quest 3 + Unity）

---

## 1. 系統概述（System Overview）

本系統為一套運行於 **Meta Quest 3** 的混合實境（Mixed Reality, MR）排球訓練應用，  
使用 **Unity Engine** 搭配 **Meta XR SDK** 進行開發。

系統結合：
- MR Passthrough 場景
- 手部追蹤（Hand Tracking）
- 動作辨識
- 即時物理模擬
- NPC 行為控制

使用者可在真實空間中，透過自然的手部動作進行接球、托球與扣殺等排球訓練。

---

## 2. 系統整體架構（High-Level Architecture）

整體系統採用 **模組化設計**，可分為六大核心模組，各模組責任明確，彼此透過事件與資料流進行互動。

### 系統模組總覽

1. **MR Scene Manager**  
2. **Player Tracking Module**  
3. **Motion Recognition Module**  
4. **Ball Physics & Interaction Module**  
5. **NPC Controller Module**  
6. **Game Flow Manager**

---

## 3. 模組說明（Module Description）

### 3.1 MR Scene Manager

**職責：**
- 管理 MR Passthrough 顯示
- 執行平面偵測（地面）
- 生成虛擬排球場
- 建立與管理 Anchor，避免場景漂移

**輸出：**
- 排球場空間座標
- 場地對齊資訊

---

### 3.2 Player Tracking Module

**職責：**
- 取得手部追蹤資料：
  - 手掌位置
  - 手指與手腕關節
- 計算：
  - 手部移動速度
  - 手臂揮動方向與速度

**輸出：**
- 手部位置向量
- 手部速度向量

---

### 3.3 Motion Recognition Module

**職責：**
- 根據 Player Tracking Module 的資料判斷玩家動作類型
- 辨識動作包含：
  - 接球（Bump）
  - 托球（Set）
  - 扣殺（Spike）
- 在與排球發生碰撞時，決定當前擊球行為

**輸出：**
- 動作類型（Enum）
- 擊球方向與力量參數

---

### 3.4 Ball Physics & Interaction Module

**職責：**
- 管理排球的 Rigidbody 與物理屬性
- 根據動作類型與手部速度計算：
  - 球速
  - 飛行方向
  - 反彈角度
- 處理手部與排球的碰撞互動

**輸入來源：**
- Motion Recognition Module
- Player Tracking Module

---

### 3.5 NPC Controller Module

**職責：**
- 控制 NPC 的移動行為
- 處理 NPC 接球、回球與發球邏輯
- 模擬基礎排球對手行為

---

### 3.6 Game Flow Manager

**職責：**
- 控制整體訓練流程
- 管理回合狀態：
  - 發球
  - Rally 進行中
  - 結束與重置
- 管理分數與 UI 顯示

---

## 4. 系統流程（System Flow）

### 4.1 系統啟動流程（Startup Flow）

1. 啟動 MR Passthrough 模式  
2. 執行 Scene Understanding 掃描地面  
3. 在真實地面生成虛擬排球場  
4. 建立 Anchor 以固定場景位置  
5. 初始化各系統模組

---

### 4.2 訓練循環流程（Rally Flow）

```text
NPC 發球
   ↓
排球飛向玩家
   ↓
玩家手部追蹤 & 動作辨識
   ↓
排球物理回饋計算
   ↓
球被擊回 NPC
   ↓
NPC 接球並回傳
   ↓
進入下一輪 Rally
5. 模組互動關係（Module Interaction）
text
複製程式碼
MR Scene Manager
        ↓
Player Tracking Module → Motion Recognition Module
                                   ↓
                    Ball Physics & Interaction Module
                                   ↓
                          NPC Controller Module
                                   ↓
                          Game Flow Manager
6. 設計原則與可擴充性
採用模組化設計，降低耦合度

動作辨識與物理模擬可獨立調整

可擴充訓練模式（如發球訓練、反應訓練）

可延伸至多人 MR 或 AI 教練系統

7. 總結
本系統架構以 MR 空間穩定性、手部互動準確度與自然物理回饋 為核心設計目標，
已能支撐 MR 排球訓練的基本互動需求，並作為後續 MVP 與完整產品開發的穩固基礎。