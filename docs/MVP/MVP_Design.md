# MVP Design  
## MR Volleyball Training System

---

## 1. MVP 定義與目的（MVP Purpose）

本文件定義本專案的 **最小可行產品（Minimum Viable Product, MVP）** 設計範圍。  
MVP 的目的並非呈現最終產品品質，而是用來驗證以下關鍵事項：

- 核心遊戲流程是否能完整執行
- 系統架構（SDD）是否能實際落地實作
- 技術穿刺（Technical Spike）成果是否可被整合進實際系統

本 MVP 版本採用 **Greybox 白模設計**，以邏輯正確性與流程穩定性為優先考量。

---

## 2. MVP 實作範圍（Scope）

### 2.1 本階段包含內容（Included）

- 完整遊戲流程：
  - Start → Play → Game Over → Restart
- 基本球體物理模擬（Rigidbody）
- 遊戲狀態管理（Game State）
- 球體生成、重置與場景初始化

---

### 2.2 本階段不包含內容（Excluded）

以下功能 **刻意排除於 MVP 階段**，將於後續版本逐步整合：

- 美術資源與視覺特效
- 完整排球規則與計分系統
- NPC AI 行為
- 手部追蹤與 MR 互動（已於 Technical Spike 驗證，尚未整合）

---

## 3. MVP 遊戲流程設計（Game Flow）

### 3.1 遊戲狀態流程

1. **Start**
   - 顯示初始狀態
   - 等待玩家輸入以開始遊戲

2. **Play**
   - 生成球體
   - 啟動物理模擬
   - 遊戲進行中，持續監控 Game Over 條件

3. **Game Over**
   - 停止遊戲進行
   - 顯示結束狀態

4. **Restart**
   - 重置遊戲狀態
   - 清除球體與相關數據
   - 回到 Start 狀態

---

### 3.2 狀態轉換示意

```text
Start
  ↓
Play
  ↓
Game Over
  ↓
Restart
  ↺
Start
4. 與系統設計文件之關聯（Relation to SDD）
本 MVP 為 系統設計文件（SDD）之最小實作版本，對應關係如下：

System Architecture

docs/SDD/SDD_SystemArchitecture.md

Module Design

docs/SDD/SDD_ModuleDesign.md

MVP 階段僅實作以下模組之核心邏輯：

Game Flow Manager

Ball Physics & Interaction（簡化版）

基礎場景初始化流程

其餘模組將於 MVP 驗證完成後逐步整合。

5. 預期成果（Expected Outcome）
完成本 MVP 後，預期達成以下成果：

遊戲可從開始到結束完整執行一輪

核心遊戲流程邏輯已被驗證為可行

系統架構與模組設計具備實作可行性

為後續整合 MR 手部追蹤與完整排球互動奠定穩定基礎

6. 後續發展方向（Next Steps）
將 Technical Spike 中的手部互動技術整合進 MVP

導入 MR 場景與手部追蹤

擴充 NPC 行為與訓練模式

強化物理回饋與使用者體驗