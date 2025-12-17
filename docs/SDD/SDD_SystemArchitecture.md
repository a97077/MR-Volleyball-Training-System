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
- Meta
