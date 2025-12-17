# Software Design Document – Module Design

## 1. Overview
本文件說明 MR 排球訓練系統的模組設計，並定義各核心模組的功能與責任分工。

## 2. Module List

### 2.1 Hand Tracking Module
- 負責取得 Meta Quest 3 手部追蹤資料
- 提供手部位置、方向與揮動速度

### 2.2 Motion Recognition Module
- 根據手部資料判斷接球、托球、扣殺動作
- 將動作結果傳送至球體物理模組

### 2.3 Volleyball Physics Module
- 控制排球的速度、方向與彈性
- 根據使用者動作即時更新球體行為

### 2.4 MR Scene Module
- 建立混合實境場景
- 對齊真實地面並放置虛擬排球場

## 3. Module Interaction
各模組透過事件與資料介面進行溝通，以確保即時互動與系統穩定性。
