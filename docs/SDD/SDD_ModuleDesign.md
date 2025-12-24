\# SDD — Module Design  

MR 沙灘排球訓練系統（Meta Quest 3 + Unity）



---



\# 1. MR Scene Manager



\## 1.1 職責 Responsibilities

\- 啟動 Passthrough  

\- 啟動平面偵測（Plane Detection）  

\- 生成排球場 Prefab  

\- 建立 Anchor 固定虛擬場景位置  



\## 1.2 類別 Class Design



```csharp

class MRSceneManager {

&nbsp;   void InitPassthrough();

&nbsp;   void ScanFloorPlane();

&nbsp;   void PlaceCourt(Vector3 pos, Quaternion rot);

&nbsp;   void CreateAnchor(Transform courtTransform);

}




