
\# SDD — System Architecture  

MR 沙灘排球訓練系統（Meta Quest 3 + Unity）



\## 1. 系統概述（System Overview）



本系統是一套運行於 Meta Quest 3 的混合實境排球訓練應用，使用 Unity 與 Meta XR SDK。  

透過 MR 場景、手部追蹤、物理模擬與 NPC 行為控制，使用者可在真實空間中進行接球、托球、扣殺等訓練。



---



\## 2. 系統整體結構（High-Level Architecture）



系統分為六大模組：



1\. \*\*MR Scene Manager\*\*  

&nbsp;  - 管理 Passthrough、平面偵測、排球場生成、Anchor 固定



2\. \*\*Player Tracking Module\*\*  

&nbsp;  - 取得手部追蹤資料（手掌、手指、手腕）  

&nbsp;  - 計算手部速度與手臂揮動速度



3\. \*\*Motion Recognition Module\*\*  

&nbsp;  - 辨識玩家動作：接球 / 托球 / 扣殺  

&nbsp;  - 與球碰撞時決定動作類型



4\. \*\*Ball Physics \& Interaction Module\*\*  

&nbsp;  - 控制排球 Rigidbody、彈性、速度公式  

&nbsp;  - 動作影響球的速度與方向



5\. \*\*NPC Controller Module\*\*  

&nbsp;  - NPC 移動邏輯、接球邏輯、傳球給玩家的行為



6\. \*\*Game Flow Manager\*\*  

&nbsp;  - 管理訓練回合、NPC 發球、分數計算與 UI 顯示



---



\## 3. 系統流程（System Flow）



\### 3.1 启动流程



1\. 啟動 Passthrough  

2\. Scene Understanding 掃描地面  

3\. 玩家在真實地板上生成縮小版排球場  

4\. Anchor 記錄位置以避免漂移  



---



\### 3.2 一次訓練循環（Rally Flow）



```text

NPC 發球 → 球飛向玩家 → 玩家動作偵測  

→ 球被擊回 → NPC 接球 → 再次傳球 → 循環




