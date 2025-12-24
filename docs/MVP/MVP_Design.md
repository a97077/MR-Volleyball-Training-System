# MVP Design – MR Volleyball Training System

## 1. MVP Purpose
本 MVP（Minimum Viable Product）目標在於驗證：
- 遊戲流程邏輯是否完整可行
- 技術穿刺（Technical Spike）是否能實際轉化為可運作系統

本階段為 Greybox 白模版本，不包含美術與完整 MR 互動。

---

## 2. MVP Scope

### Included
- Start → Play → Game Over → Restart 遊戲流程
- 基本球體物理模擬
- 遊戲狀態管理（Game State）

### Excluded
- 美術資源
- 完整排球規則
- AI NPC
- 手部追蹤（後續整合）

---

## 3. Game Flow

1. **Start**
   - 顯示開始狀態
   - 玩家輸入後進入 Play

2. **Play**
   - 球體生成並進行物理模擬
   - 持續至 Game Over 條件成立

3. **Game Over**
   - 顯示結束狀態

4. **Restart**
   - 重置場景並回到 Start

---

## 4. Relation to SDD

本 MVP 依據以下 SDD 文件實作：
- System Architecture: `docs/SDD/SDD_SystemArchitecture.md`
- Module Design: `docs/SDD/SDD_ModuleDesign.md`

MVP 為 SDD 設計的最小可行實作版本。

---

## 5. Expected Outcome
- 能完整執行一輪遊戲流程
- 驗證核心程式邏輯正確性
- 作為後續 MR 功能整合之基礎
