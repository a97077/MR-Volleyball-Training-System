# Software Design Document – System Architecture

## 1. Introduction
本文件說明「MR 排球訓練系統（MR Volleyball Training System）」之整體系統架構設計。
本系統為一個以 Meta Quest 3 為平台的 Mixed Reality（MR）技術穿刺專案，目標在於驗證手部追蹤、動作辨識與排球物理互動的可行性。

---

## 2. System Overview
本系統運行於 Meta Quest 3，透過 Unity 開發，結合以下核心技術：
- MR Passthrough（混合實境顯示）
- 手部追蹤（Hand Tracking）
- 動作辨識（Motion Recognition）
- 排球物理模擬（Physics Simulation）

系統主要用途為提供使用者在真實空間中，進行基本排球動作訓練，如接球、托球與扣殺。

---

## 3. High-Level Architecture

系統架構可分為以下幾個層級：

### 3.1 Input Layer
- Meta Quest 3 手部追蹤系統
- 提供手部位置、方向與揮動速度資訊

### 3.2 Processing Layer
- 動作辨識模組
- 根據手部資料判斷使用者動作類型（接球、托球、扣殺）

### 3.3 Simulation Layer
- 排球物理模組
- 根據使用者動作結果，計算球體速度、方向與反彈行為

### 3.4 Presentation Layer
- MR 場景顯示
- 將虛擬排球場與球體正確顯示於真實空間中

---

## 4. System Components

### 4.1 Hand Tracking Component
負責即時取得手部追蹤資料，作為動作辨識的輸入來源。

### 4.2 Motion Recognition Component
根據手部移動方向與速度，判斷使用者執行的排球動作。

### 4.3 Volleyball Physics Component
依據動作結果計算排球的物理反應，包含速度與方向。

### 4.4 MR Scene Component
負責建立混合實境場景，對齊真實地面並顯示虛擬物件。

---

## 5. Technical Spike Scope
本系統僅實作核心技術驗證，不包含：
- 完整遊戲流程
- 美術資源
- 使用者介面設計

目標在於確認關鍵技術可在 Meta Quest 3 上穩定運行。

---

## 6. Summary
本文件定義了 MR 排球訓練系統的整體架構，作為後續模組設計與技術驗證的基礎。
