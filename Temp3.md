# 📋 MainviewUserControl.cs 進出站處理流程筆記

**位置**: R:\MyCodes\Projects\Calin\DataCollectionSystem\DataCollectionSystem\UserControl\MainviewUserControl.cs (第 407-810 行)
**主方法**: PollingLog() - 核心邏輯段
**語言**: C# 7.3 | .NET Framework 4.8
**功能**: 生產過程中的條碼驗證、進出站記錄、檢測結果存儲

---

## 🎯 系統功能概述

整個流程負責**光學鏡頭產品的生產過程管理**，涵蓋：

- ✅ 條碼識別與驗證
- ✅ 產品進出站流程
- ✅ 多工序檢測結果記錄
- ✅ 生產軌跡追蹤

流程架構：條碼取得 → 最小工序檢查 → 條碼驗證 → 狀態判斷 → 進出站流程 → 結果記錄

---

## 📌 核心流程分解

### 1️⃣ 條碼主檔案取得與驗證 (第 410-423 行)

```csharp
jsonstring = (pmAccount.Codetype.ToUpper() == "MAIN") ?
     DataTrans.GET_MAIN_BARCODE_NEW(pmAccount.Model, code[0], null, pmAccount.Database)
         : DataTrans.GET_MAIN_BARCODE_NEW(pmAccount.Model, code[0], pmAccount.Codetype, pmAccount.Database);
List<CMAINCODE> maincode = JsonConvert.DeserializeObject<List<CMAINCODE>>(jsonstring);
```

**目的**：從資料庫取得條碼的主檔案資訊

**程式碼邏輯**：
根據 pmAccount.Codetype 決定查詢模式，將結果反序列化為 List<CMAINCODE>

**流程說明**：

| 項目        | 說明                                 |
| ----------- | ------------------------------------ |
| 條件判斷    | 根據 pmAccount.Codetype 決定查詢模式 |
| "MAIN" 類型 | 傳 null → 通用條碼查詢               |
| 其他類型    | 傳具體的 Codetype → 專用查詢         |
| 反序列化    | JSON 字串 → List<CMAINCODE> 物件     |

**關鍵參數**：

| 參數               | 用途       |
| ------------------ | ---------- |
| pmAccount.Model    | 產品型號   |
| code[0]            | 條碼值     |
| pmAccount.Database | 資料庫連線 |

---

### 2️⃣ 最小工序檢查 (第 415-424 行)

```csharp
if (seqID == minSEQ[0].DLLRESULT)
{
    if (codeState.Count == 0)
    {
        bCreate = true;
        string createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        createSEQ = DataTrans.PROC_CREATE(...);
    }
}
```

**目的**：確保只在最小工序建立新條碼記錄，防止產品追蹤錯亂

**核心邏輯**：

| 條件                         | 動作                       | 目的             |
| ---------------------------- | -------------------------- | ---------------- |
| seqID == minSEQ[0].DLLRESULT | 檢查當前工序是否為最小工序 | 只在起始工序建立 |
| codeState.Count == 0         | 檢查條碼是否已存在         | 防止重複建立     |
| 兩者皆真                     | 設定 bCreate = true        | 標記為新建立     |

**重要提示**：
若不在最小工序就建立條碼，會導致產品追蹤錯亂！

---

### 3️⃣ 主條碼驗證與條件分支 (第 426-446 行)

```csharp
if (bCreate || maincode[0].RESULT == "OK")
{
    MainCode = maincode[0].BARCODE;
    // ... 後續處理
}
else
{
    // 主條碼錯誤
}
```

**目的**：確認條碼有效性，決定是否繼續流程

**流程決策**：

| 條件                       | 動作                        |
| -------------------------- | --------------------------- |
| bCreate == true            | 新建立的條碼，允許繼續 ✅   |
| maincode[0].RESULT == "OK" | 主條碼查詢成功，允許繼續 ✅ |
| 皆否                       | 標記錯誤，退出流程 ❌       |

---

### 4️⃣ 條碼狀態驗證與模型/版本確認 (第 433-446 行)

```csharp
jsonstring = DataTrans.BARCODE_INFO(MainCode, pmAccount.Database);
List<CCODEINFO> codeInfo = JsonConvert.DeserializeObject<List<CCODEINFO>>(jsonstring);

if (codeInfo[0].BARCODE_STATE.ToUpper() != "NG")
{
    if (codeInfo[0].PID != pmAccount.Model || codeInfo[0].PROCVER != pmAccount.Version)
    {
        // 版次錯誤
        CheckString = "版次錯誤,,,,";
    }
    else
    {
        // 進行工序檢查與進出站
    }
}
```

**目的**：確保產品型號和流程版本匹配

**驗證層級**：

| 層級 | 驗證項目 | 內容                               |
| ---- | -------- | ---------------------------------- |
| 1️⃣   | 條碼狀態 | 確保不是 "NG" 狀態                 |
| 2️⃣   | 產品型號 | PID 必須匹配 pmAccount.Model       |
| 3️⃣   | 流程版本 | PROCVER 必須匹配 pmAccount.Version |

**設計精妙**：雙層驗證保證資料完整性，提前發現不匹配的產品

---

### 5️⃣ 條碼狀態分流 (第 451-756 行)

```csharp
switch (Convert.ToChar(codeInfo[0].BARCODE_STATE))
{
    case 'N': // 生產中
        // 執行進出站邏輯
        break;
    case 'Y': // 良品已完工
        row = new object[] { code[0], "", value[0], pos, ... };
        dgvLog.Rows.Add(row);
        break;
    // ... 其他狀態
}
```

**目的**：根據條碼生產狀態採取不同的處理方式

**狀態對應表**：

| 狀態字元 | 狀態名稱   | 含義             | 動作                    |
| -------- | ---------- | ---------------- | ----------------------- |
| 'N'      | 生產中     | 在工序上進行測試 | ✅ 進行進出站與結果記錄 |
| 'Y'      | 良品已完工 | 已通過所有工序   | ⏭️ 標記完成，跳過後續   |
| 'X'      | 重工已鎖定 | 因問題需重工     | 🚫 拒絕操作             |
| 'Z'      | 已報廢     | 無法修復         | 🚫 拒絕操作             |

---

## 🔄 進出站核心流程 (狀態為 'N' 時)

此流程包含 **5 個檢查點**，每個檢查點決定下一步的執行

### 步驟 A: 進站檢查 (PROC_CHECK) - 檢查點 1

```csharp
string chkResult = DataTrans.PROC_CHECK(pmAccount.Model, MainCode, seqID, INOUT, pmAccount.Database);
string[] chkMsg = chkResult.Split(';');

CheckString += chkMsg[0]; // 檢查點1
if (chkMsg[0] == "OK")
{
    // 允許進站
}
```

**目的**：驗證該條碼是否可進入指定工序

**檢查內容**：

- 該條碼是否可進入指定工序
- 工序流程是否正確
- 條碼狀態是否允許進站

| 結果 | 意義        |
| ---- | ----------- |
| "OK" | 允許進站 ✅ |
| "NG" | 拒絕進站 ❌ |

**設計**：進站前的第一道防線，防止無效條碼進站

---

### 步驟 B: 進站動作 (PROC_ACTION - 進站) - 檢查點 2

```csharp
if (bProcessing == false)
{
    bProcessing = true; // 設定鎖定，防止重複處理
    ActionResult = DataTrans.PROC_ACTION(
        pmAccount.Model, MainCode, seqID,
        pmAccount.Employee, time, INOUT="1", INRs="OK",
        pmAccount.Database
    );
}
```

**目的**：在資料庫中記錄條碼進站事件

**關鍵機制**：

| 機制             | 功能                   |
| ---------------- | ---------------------- |
| bProcessing 旗標 | 🔒 防止並發競態條件    |
| 鎖定狀態         | 同一時刻只處理一筆條碼 |
| 時間戳記         | 唯一確定，確保一致性   |

**重要提示**：時間戳記在此時刻確定，後續出站時必須使用同一時間！

---

### 步驟 C: 進站結果記錄 (getSeqInResult) - 檢查點 3

```csharp
InResult = DataCollect.getSeqInResult(
    seqName, seqID, pmAccount.Model, MainCode,
    time, pmAccount.Employee, MID, CNAME,
    pmAccount.Database
);
List<CREPLY> dbInMsg = JsonConvert.DeserializeObject<List<CREPLY>>(InResult);

CheckString += "," + dbInMsg[0].DLLRESULT; // 檢查點3
```

**目的**：記錄完整的進站資訊用於追蹤

**紀錄內容**：

| 資訊     | 說明               |
| -------- | ------------------ |
| 進站員工 | pmAccount.Employee |
| 進站時間 | time               |
| 工序編號 | seqID              |
| 測試機台 | MID                |
| 電腦名稱 | CNAME              |

**追蹤**：完整記錄進站資訊，便於事後追蹤生產軌跡

---

### 步驟 D: 測試結果出站 (基於工序類型)

```csharp
int seqType = DataCollect.getSEQType(seqName);

switch (seqType)
{
    case 0: // MTF
        OutResult = DataTrans.MTF_OUT(...);
        break;
    case 1: // AIR
        OutResult = DataTrans.AIR_OUT(...);
        break;
    case 2: // PF (Prefocus)
    case 3: // TF (Thruфocus)
        OutResult = DataTrans.PREFOCUS_OUT(...);
        break;
    case 4: // MFBL
        OutResult = DataTrans.MBFL_OUT(...);
        break;
    case 6: // MTF 2
        // 分別處理 Wide 和 Tele
        OutResult = DataTrans.MTF2_OUT(..., "Wide", ...);
        OutResult = DataTrans.MTF2_OUT(..., "Tele", ...);
        break;
}
```

**目的**：根據不同工序類型調用對應的測試結果記錄方法

**工序類型對應表**：

| 類型 | 工序名稱      | 測試內容     | 資料格式   | 設備       |
| ---- | ------------- | ------------ | ---------- | ---------- |
| 0    | MTF           | 模態轉移函數 | 單一結果   | MTF測試機  |
| 1    | AIR           | 氣密檢測     | 壓力數據   | 氣密檢測機 |
| 2    | PF            | 焦距對焦     | 焦距數據   | 焦距測試機 |
| 3    | TF            | 透射焦點     | 焦距數據   | 焦距測試機 |
| 4    | MFBL          | 多焦點背光   | 複合數據   | MFBL測試機 |
| 5    | AUTO_ALIGNING | 自動對焦對位 | 複雜參數   | SOMA專用版 |
| 6    | MTF2          | 廣角+望遠MTF | 雙通道結果 | MTF測試機  |

**設計模式**：工序適配器模式，同一介面適配多種測試設備

**MTF2 (案例 6) 的特殊處理**：
需要分別調用廣角 (Wide) 和望遠 (Tele) 兩個通道

---

### 步驟 E: 出站結果判讀與最終動作 - 檢查點 4-5

```csharp
List<COUTREPLY> dbOutMsg = JsonConvert.DeserializeObject<List<COUTREPLY>>(OutResult);

CheckString += "," + dbOutMsg[0].DLLRESULT; // 檢查點4

if (dbOutMsg[0].DLLRESULT == "OK")
{
    if (dbOutMsg[0].OUTRESULT == "OK")
    {
        // 結果OK，系統OK → 綠燈
        ActionResult = DataTrans.PROC_ACTION(..., INOUT="2", OutRs="OK", ...);
    }
    else
    {
        // 結果OK，系統NG → 紅燈
        if (pmConfig.LockCheck.ToUpper() == "YES")
        {
            DataTrans.PROC_ACTION(..., "2", "NG", ...);
        }
    }
}
```

**目的**：根據測試結果確定產品的流向

**檢查點 4**：驗證測試結果是否有效

**出站結果判讀樹**：

```text
dbOutMsg[0].DLLRESULT == "OK"?
├─ YES: dbOutMsg[0].OUTRESULT == "OK"?
│       ├─ YES: 情況 1 - 測試結果 OK + 系統 OK (綠燈)
│       │       └─ 執行出站動作 (檢查點 5-1)
│       │       └─ 產品流向下一工序
│       │
│       └─ NO: 情況 2 - 測試結果 OK + 系統 NG (紅燈)
│               └─ 若 LockCheck="YES" 執行鎖定 (檢查點 5-2)
│               └─ 產品停留當前工序
└─ NO: 情況 3 - 測試系統異常 (SysNG)
       └─ 執行出站動作 (檢查點 5-3)
       └─ 產品標記系統異常
```

---

9. 結果顯示與檔案移動

```csharp
if (err == 0)
{
    // 所有檢查點都是 "OK" 或 "NG"
    DataCollect.moveFiles(seqName, files[0], pmPath, CheckString);
}
else
{
    // 存在異常值
    DataCollect.moveFiles_Err(seqName, files[0], pmPath, CheckString);
}
```

## 說明： 根據檢查點結果，將資料檔案移至不同目錄（成功/失敗）以便事後追蹤。

關鍵設計模式
模式 目的
狀態機 (switch case) 根據條碼狀態分流處理
檢查點串聯 (5個檢查點) 追蹤完整的進出站流程
標誌位 (bProcessing) 防止並發處理同一筆資料
動態方法選擇 (工序類型) 適配不同測試設備

---

建議改進方向

1. 提取魔術字串： 將 "OK"、"NG" 等改為常數
2. 方法過長： 考慮拆分成多個小方法（如 ProcessEntry()、ProcessExit()）
3. 錯誤處理： 加入 try-catch 來處理資料庫連線異常
4. 時間一致性： 注意時間戳記應在同一時刻取得，避免出站時間不一致
