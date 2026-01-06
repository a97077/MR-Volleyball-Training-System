# MR Volleyball Hit  
### 混合實境排球訓練系統（Meta Quest 3）

一款讓玩家在真實空間中進行排球擊球訓練的沉浸式體感遊戲。

---

## 一、專案簡介（Project Overview）

**MR Volleyball Hit** 是一款基於 Meta Quest 3 的混合實境排球體驗，  
玩家不需使用控制器，僅透過雙手動作即可完成接球、托球與扣球等排球動作，  
在真實空間中感受直覺且具物理回饋的排球互動。

---

## 二、系統需求（System Requirements）

- 裝置：Meta Quest 3  
- 作業系統：Android（Quest OS）  
- 開發環境：
  - Unity（建議 LTS 版本）
  - Meta XR SDK
- 支援功能：
  - Hand Tracking
  - Passthrough (Mixed Reality)

---

## 三、安裝與執行方式（Installation）

### 1️⃣ 安裝 APK（玩家）

1. 下載 APK 檔案  
   👉 **APK 下載連結**（請替換為實際連結）  
https://drive.google.com/drive/folders/1RV5gtxnsPCoCWr9eWGgfTjT_ptfUi-Yv?usp=sharing

yaml
複製程式碼

2. 使用 SideQuest 或 adb 將 APK 安裝至 Meta Quest 3  
3. 戴上頭盔後，於應用程式清單中啟動遊戲

---

### 2️⃣ 編譯原始碼（開發者）

1. Clone 本專案：
```bash
git clone https://github.com/a97077/MR-Volleyball-Training-System
使用 Unity Hub 開啟：

bash
複製程式碼
/src/UnityProject
確認已安裝：

Meta XR SDK

啟用 Hand Tracking 與 Passthrough

切換平台為 Android，Build 並部署至 Meta Quest 3

四、操作說明（How to Play）
操作方式（無控制器）
動作	說明
接球（Bump）	以雙手前臂區域接觸排球
托球（Set）	雙手向上托舉動作
扣球（Spike）	手臂快速揮動擊打排球

系統會根據 手部位置、方向與揮動速度 判斷擊球方式

不同動作將產生不同的球速與反彈角度

五、系統架構（System Architecture）
以下為本專案的簡化系統架構：

[Hand Tracking]
        ↓
[HandVelocity / HandFollower]
        ↓
[VolleyballHit Controller]
        ↓
[Rigidbody Physics]
        ↓
[Ball Feedback]

核心模組說明：
HandFollower / XRForearmFollower
負責手部與前臂位置追蹤

HandVelocity
計算揮動速度，作為擊球力道依據

VolleyballHit
判斷擊球類型並施加對應物理反饋

ServeTrainer
控制訓練流程與球生成邏輯

六、技術驗證（Technical Spike）
本專案已完成以下技術驗證：

手掌與手臂碰撞體與排球的角度反彈行為

手部揮動速度轉換為合理的球速

MR 空間中虛擬物件與真實空間的對齊

詳細內容請參考：

docs/TechnicalSpike/Technical_Spike_Spec.md

七、展示資源（Media）
🎬 Gameplay 影片
👉https://drive.google.com/drive/folders/1RV5gtxnsPCoCWr9eWGgfTjT_ptfUi-Yv?usp=sharing

🖼️ 宣傳圖片
👉 docs/media/volleyball_hit_promo.png

八、專案文件（Documentation）
📄 MVP 設計

docs/MVP/MVP_Design.md

📄 系統設計文件（SDD）

docs/SDD/SDD_SystemArchitecture.md

docs/SDD/SDD_ModuleDesign.md

九、專案狀態（Project Status）
✅ MVP 可完整遊玩一輪（Start → Play → Game Over → Restart）

✅ 核心 MR 互動功能完成

🚧 後續可擴充更多訓練模式與評分機制

