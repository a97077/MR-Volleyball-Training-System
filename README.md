# 🏐 Volleyball Hit  
### MR Volleyball Training System (Mixed Reality)

**Volleyball Hit** 是一款基於 **Mixed Reality (MR)** 的排球訓練體驗遊戲。  
玩家配戴 **Meta Quest 3**，透過真實揮手動作擊球，在現實空間中完成排球扣球訓練。

> 🎯 核心目標：驗證「MR 手部追蹤 + 揮手擊球 + 遊戲流程」的可行性。

---

## 🎮 一句話講完在玩什麼（Pitch）
一款讓你 **用真實揮手動作，在 MR 世界中打排球扣球** 的沉浸式訓練遊戲。

---

## 🧩 專案定位（本課作業重點）
本專案屬於 **Technical Spike + MVP（Minimum Viable Product）**：

- 不追求美術品質
- 不追求完整關卡
- 重點放在：
  - MR 互動是否可行
  - 程式邏輯是否完整
  - 遊戲流程是否能跑完一輪

---

## 🔁 遊戲流程
Start → Play → Game Over → Restart

yaml
複製程式碼

- **Start**：進入 MR 排球訓練場
- **Play**：揮手擊球、判定命中與得分
- **Game Over**：完成一輪訓練
- **Restart**：重新開始

✔ 已完成 **Greybox 白模可試玩版本**

---

## 🕹 操作方式（Controls）
| 動作 | 說明 |
|----|----|
| 揮手 | 擊球 |
| 揮動速度 | 影響球速 |
| 手部追蹤 | MR 核心互動方式 |

---

## 🏗 系統架構
XR Hand Tracking
↓
HandVelocity / ForearmBump
↓
VolleyballHit (Collision & Force)
↓
Score / Game State Manager

yaml
複製程式碼

📄 詳細設計文件：
- System Architecture  
  👉 `docs/SDD/SDD_SystemArchitecture.md`
- Module Design  
  👉 `docs/SDD/SDD_ModuleDesign.md`

---

## 📁 專案結構說明
MR-Volleyball-Training-System/
├─ README.md ← 本文件
├─ docs/
│ ├─ MVP/ ← MVP 設計與驗證說明
│ ├─ SDD/ ← 系統與模組設計文件
│ ├─ TechnicalSpike/ ← 技術穿刺驗證
│ └─ UserStory/ ← 使用者故事
└─ src/
└─ UnityProject/ ← Unity 專案原始碼

yaml
複製程式碼

---

## 🧠 MVP 與 SDD 的關係說明（老師會看）
- **SDD（Software Design Document）**  
  描述「系統應該如何設計」

- **MVP（Minimum Viable Product）**  
  實際實作並驗證「這樣的設計是否可行」

📌 本專案中：
- MVP 的每個核心功能（擊球、速度判定、流程）
- 都能在 SDD 文件中找到對應模組說明

---

## 🔬 Technical Spike（技術穿刺）
本專案驗證以下技術可行性：

- MR 手部追蹤是否足以作為擊球輸入
- 揮手速度 → 球速映射是否合理
- 即時碰撞判定在 MR 中的穩定性

📄 詳見：
- `docs/TechnicalSpike/`

---

## 🚀 Build & Run（工程可重現性）
### 環境需求
- Unity（建議 LTS 版本）
- Meta Quest 3
- Android Build Support

### Build Steps
1. Clone 本 Repo
2. 開啟 `src/UnityProject`
3. 設定 XR 與 Android Build
4. Build APK
5. 安裝至 Quest 3

---

## 📦 APK 下載（Demo 用）
👉 **（請補上實際連結）**
- Google Drive / itch.io

---

## 🎥 Gameplay Trailer（60–90 秒）
👉 **（請補上實際影片連結）**
- 展示 Start → Play → Game Over → Restart
- 強調 MR 揮手擊球互動

---

## 🖼 宣傳圖片
（由 AI 或簡單設計製作，用於介紹專案）

---

## 📌 課堂評分對應說明
- ✅ Product Quality：可玩、穩定、MR 互動成立
- ✅ Engineering：可 clone、可 build、commit 有意義
- ✅ Docs：README + SDD + MVP 完整
- ✅ Demo：可現場配戴頭盔展示

---
 
MR Volleyball Training System  