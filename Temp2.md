將程式碼對照標準 1D 卡爾曼濾波器方程式：
| 步驟 | 標準公式 | 程式碼 | 結果 |
|------|----------|--------|------|
| 預測狀態 | x̂ = A·x + B·u | predX = (A _ x) + (B _ u) | ✅ |
| 預測協方差 | P̂ = A·P·A + R | predCov = ((A _ cov) _ A) + R | ✅ |
| 卡爾曼增益 | K = P̂·C / (C·P̂·C + Q) | K = predCov _ C _ (1 / ((C _ predCov _ C) + Q)) | ✅ |
| 修正狀態 | x = x̂ + K·(z − C·x̂) | x = predX + K _ (measurement - (C _ predX)) | ✅ |
| 修正協方差 | P = (1 − K·C)·P̂ | cov = predCov - (K _ C _ predCov) | ✅ |
| 初始化 x | x₀ = z / C | x = (1 / C) _ measurement | ✅ |
| 初始化 P | P₀ = Q / C² | cov = (1/C) _ Q \* (1/C) | ✅ |

---

但存在以下工程問題
| # | 嚴重度 | 問題 |
|---|--------|------|
| 1 | High | C = 0 時 1/C 造成除以零（回傳 Infinity，後續全部損毀） |
| 2 | High | 無 thread-safe 保護（與 MedianFilter 風格不一致） |
| 3 | High | NaN / Infinity 輸入未防護，一旦汙染將永久傳播 |
| 4 | Medium | Filter(double) 與 Filter(double, double) 完全重複邏輯，違反 DRY |
| 5 | Medium | LastMeasurement() 命名錯誤 — 回傳的是估計狀態，非原始量測值 |
| 6 | Medium | SetMeasurementNoise / SetProcessNoise 無 thread-safe，且無輸入驗證 |
| 7 | Low | 欄位命名不符 C# 慣例（應為 \_a 而非 A） |
| 8 | Low | 無 Reset() 生命週期方法 |

| 欄位                     | 是否需要追蹤            | 原因                                             |
| ------------------------ | ----------------------- | ------------------------------------------------ |
| AlarmCode                | ✅ 需要，但已用 != 解決 | 區分「新警報」vs「持續警報」                     |
| Position / Speed / Force | ❌ 不需要               | SnapshotUpdated 每週期無條件發送，訂閱者自行判斷 |
| StatusWord               | ❌ 不需要               | 同上                                             |

🔴 Critical（會直接造成停產 / 安全事故 / 失控）
| 編號 | 位置 | 問題 |
|---|---|---|
| C-1 | ToyoController.EmergencyStopAsync / Tc100RegisterAccessor.WriteControlWordAsync | 緊急停止與一般指令共用同一個 _transportLock（SemaphoreSlim 1,1），若一般 Move/Read 已持有鎖且阻塞，E-Stop 會被排隊；且 Modbus 寫入是用 await WaitAsync(ct)，無 timeout 保證 → E-Stop 可能永遠送不出去。違反工控「Emergency Stop 必須最高優先、無條件可達」原則。 |
| C-2 | PollingEngine.PollingLoop | 使用 .GetAwaiter().GetResult() sync-over-async 阻塞於 transport I/O。若底層 socket/serial I/O 不響應 CancellationToken，Stop() 的 Join(5s) 後執行緒仍在跑；隨後 Dispose() 釋放 \_transportLock / \_accessor / \_transport → polling thread 觸發 ObjectDisposedException 或 use-after-free。 |
| C-3 | ToyoController.Dispose() | Task.Run(... DisconnectAsync).Wait(5s) + ContinueWith 是 未受控的 fire-and-forget：超時後 Dispose 繼續往下呼叫 \_accessor.Dispose() / \_transport.Dispose()，然而背景任務仍持有 \_transport 在執行 → 必然 race。 |
| C-4 | ToyoController ctor | \_polling.SnapshotUpdated += (_, s) => \_watchdog.NotifySnapshotReceived(s); NotifySnapshotReceived 內同步執行 CheckSafetyLimits → 若超限便 \_stateMachine.ForceError() → 同步觸發 StateChanged event → 使用者 handler 可能阻塞 → 直接卡死 Polling 主迴圈，使 Watchdog 自身偵測不到失效（Polling stuck 反而導致 Watchdog 收不到新時間戳，可能引發次生 ForceError 風暴）。 |
| C-5 | ToyoController.ServoOnAsync / ServoOffAsync | 未經 CommandQueue、未做狀態檢查、未取 lock。可在 Busy / Jogging / Clamping 中被任意呼叫，運動中關 Servo 會造成機械失控掉落。 |

🟠 High
| 編號 | 位置 | 問題 |
|---|---|---|
| H-1 | MoveRelativeAsync | int currentPos = (int)Math.Round(snapshot.Position _ 100) 浮點來回轉換，長時間累積誤差 → 相對位移漂移。Snapshot 應同時保留 raw 整數座標。 |
| H-2 | EnsureState + TryTransition | 兩段檢查之間是 TOCTOU race：兩條 thread 同時呼叫 MoveAbsoluteAsync 都通過 EnsureState(Idle)，然後排隊 → 第二筆執行時才在 worker 內失敗，但已造成 queue 污染。 |
| H-3 | WaitForInPositionAsync / HomeAsync 完成判斷 | 直接讀 \_polling.LatestSnapshot.StatusWord，未比較 Timestamp → 命令送出後第一次取到的 snapshot 可能是命令前的舊資料，InPosition bit 還是 true（上一段運動的殘留） → 立刻誤判完成。 |
| H-4 | ToyoController.DisconnectAsync | 串行 Stop()：Polling.Stop(5s) + Watchdog.Stop(5s) + transport.Disconnect → 最壞 ~10s 才呼叫 transport.Disconnect。應先 Cancel CTS + 先 Disconnect transport 解除 I/O 阻塞，再 Join thread。 |
| H-5 | CommandQueue.EnqueueAsync | \_accepting 檢查與 TryAdd 之間存在 race：StopAccepting 後仍可能有指令成功進入 queue，但隨後 CompleteAdding 會丟 InvalidOperationException，造成呼叫端拿到非預期例外。 |
| H-6 | ConnectAsync | 未清除 \_polling.\_latestSnapshot / \_lastAlarmCode。重新連線後 MoveRelative 立刻拿到上一次斷線前的舊位置 → 歸零失敗 / 衝撞風險。 |
| H-7 | WatchdogEngine.WatchdogLoop | int interval = \_config.EffectiveWatchdogIntervalMs; 只在 loop 進入時讀一次，運行中 SafetyConfig.WatchdogIntervalMs 變更不會生效；但更嚴重的是 \_config 是公開可變 POCO，多執行緒寫入 SafetyConfig 沒有任何保護 → 撕裂讀取（torn read of double）。 |
| H-8 | Dispose 全體 | \_disposed = true; 在 if (\_disposed) return; 後賦值但沒有 Interlocked，多執行緒同時 Dispose 會 double-dispose SemaphoreSlim / BlockingCollection 拋例外。 |
| H-9 | EmergencyStopAsync | 寫入後僅 ForceError()，沒有停止 Polling / Watchdog / 排空 CommandQueue，仍在背景持續傳送。E-Stop 後的 watchdog/polling 還會繼續打 transport。 |
🟡 Medium
| 編號 | 位置 | 問題 |
|---|---|---|
| M-1 | PollingEngine | WaitHandle.WaitOne(remaining) 受 OS scheduler 抖動影響，無高解析度時序。工控建議使用 MultimediaTimer 或 Stopwatch busy-spin 最後 1ms，至少要記錄 jitter 統計。 |
| M-2 | PollingEngine.PollingLoop | \_lastPollFailed 連續失敗只記第一次，不知道失敗次數；應記錄連續失敗計數並在 N 次後 ForceError。 |
| M-3 | WatchdogEngine.CheckSafetyLimits | 在 polling event handler context 同步執行，且 MaxForce / Position_ 是 double 公開可寫 → 工控規範下 SafetyConfig 應是不可變且建構時固化。 |
| M-4 | Tc100RegisterAccessor | 所有 R/W 都過 SemaphoreSlim — Modbus RTU 必要，但無 per-call timeout。底層 transport hang 時整個系統卡死。 |
| M-5 | StateChanged / SnapshotUpdated / AlarmRaised | 都是同步 invoke，外部 handler 例外被 catch 但長時間執行會阻塞 polling thread。應 dispatch 到專屬 event thread / Channel。 |
| M-6 | DeviceSnapshot allocation | Polling 每週期都 new DeviceSnapshot(...) → GC 壓力。20Hz × 多軸下 Gen0 頻繁。建議結構體 (readonly struct) 或物件池。 |
| M-7 | Stopwatch 在 WaitForInPosition / Home / Stop 重複 new Stopwatch + StartNew | 可改 Environment.TickCount64 比較。 |
| M-8 | DeviceStateChangedEventArgs.Timestamp 用 DateTime.Now，DeviceSnapshot.Timestamp 用 DateTime.UtcNow | 時間戳不一致，跨日誌比對困難；工控應一律 UTC + ISO8601。 |
| M-9 | FaultResetAsync | 在 timeout loop 內每 200ms 呼一次 ReadAlarmCodeAsync，繞過 polling 直打 transport，與 polling 競爭 lock；應改讀 \_polling.LatestSnapshot.AlarmCode。 |
🟢 Low
| 編號 | 位置 | 問題 |
|---|---|---|
| L-1 | IntervalMs.set | 只限下限，無上限驗證。 |
| L-2 | CommandQueue capacity 256 hardcoded | 未由 config 注入。 |
| L-3 | Drain() 命名 | 實作為 CompleteAdding，命名誤導。 |
| L-4 | WatchdogIntervalMs 註解 | 與實作 fallback 邏輯說明不清。 |
| L-5 | IModbusTransport.IsConnected | 沒有 thread-safe 約束聲明。 |
| L-6 | \_logger.LogDebug(...) 在 hot path 用 IsEnabled 包了一層 ✓ | 但 Write\*Async 內 \_logger.LogDebug("...") 仍有 boxing of values（minor）。 |

---

2. 修正方向總結（對應工控原則）
1. E-Stop 必須有專屬 transport 通道或 priority bypass：拆分 EmergencyStopAsync 為 直通 transport（不過 Accessor lock），並在 lock 上設置 WaitAsync(timeout)。
1. 取消必須是強制的：所有 sync-over-async 必須有「先關 transport、再 Cancel、再 Join」的順序。
1. Snapshot 命令完成判斷必須帶時間戳：WaitForInPositionAsync 紀錄命令送出後的 baseline timestamp，只接受 Snapshot.Timestamp > baseline 後的判讀。
1. SafetyConfig 必須不可變：用 record / readonly fields，建構時驗證並固化。
1. Watchdog 與 SafetyCheck 解耦於 Polling thread：NotifySnapshotReceived 只更新 \_lastSnapshotTicks；安全檢查在 Watchdog 自己的 thread。
1. State machine event 改非同步派發：避免 handler 阻塞 polling/watchdog。
1. Dispose / Stop 必須冪等且 thread-safe：用 Interlocked.Exchange 守護。
1. MoveRelative 用 raw 整數：DeviceSnapshot 額外曝露 PositionRaw。
1. ServoOn/Off 必須走 queue + 狀態檢查。
1. 連線時必須 reset internal cached state。

---

## 結論

- ✔ 可以「設定推力限制」並前進
- ✘ 無法做到**真正閉迴路固定出力前進（高精度力控制）**

## TC100 控制能力本質

### 控制器特性

- 採用**二相步進馬達（含編碼器）** ([toyorobotics.co][1])
- 控制模式：
  - 位置（ABS / INC）
  - 連續運動
  - **Thrust Mode （推力模式）** ([toyorobotics.co][1])

- 功能：
  - 扭矩 / 速度限制 ([Accu Tech USA][2])
  - 推力控制（參數化） ([ACE PILLAR][3])

## 關鍵判斷：是否等同「固定出力」

### ✔ 可以做到的

- 設定「最大推力上限」
- 在接觸工件後：
  - 控制器限制電流 → 限制推力
  - 類似「定力壓合」行為

### ✘ 做不到的

- 真正「持續閉迴路力控制」
- 精確維持某一推力值（例如 ±1%）
- 動態負載變化下維持穩定力

## 核心原因（工程面）

### - 控制架構限制

- TC100 是：
  - 步進系統 + 編碼器（位置閉迴路）

- 非：
  - 力感測閉迴路系統

→ 沒有力回授（Load Cell）

### - 推力來源是「電流估算」

- 推力 ≈ 馬達電流 × 常數
- 問題：
  - 摩擦變動
  - 溫升
  - 機構效率

→ 實際推力會漂移

### - Thrust Mode 實際行為

- 本質：
  - **電流限制模式（Torque Limit）**

- 行為：
  - 前進 → 碰到阻力
  - 電流達上限 → 停止或低速推進

→ 比較接近：

- ✔ 防撞
- ✔ 壓合到位
- ✘ 穩定力控制

## 行為模型（實際）

```
前進（位置或連續模式）
    ↓
接觸工件
    ↓
電流上升
    ↓
達設定推力（電流限制）
    ↓
停止 / 微動
```

## 工控等級判斷

### TC100 等級

- ✔ 適合：
  - 定位
  - 搬運
  - 簡單壓合（有無判斷）

- ✘ 不適合：
  - 精密壓力控制
  - 力回授應用（如壓力曲線控制）

## 若目標是「真正固定出力」

### 必要架構

- ✔ 伺服驅動（Torque Mode）
- ✔ 外接 Load Cell
- ✔ 力閉迴路控制

### TC100 無法補足的

- ✘ 無力回授接口
- ✘ 無力控制迴路

## 總結判斷

- TC100：
  - ✔ 有「推力限制」功能
  - ✘ 沒有「力閉迴路控制」能力

→ 結論：
**只能做到「類固定出力（限制型）」
不能做到「工程定義的固定出力控制」**

[1]: https://www.toyorobotics.co/miniature-electric-cylinder.html?utm_source=chatgpt.com 'Miniature Electric Cylinder| TOYO Robotics'
[2]: https://accu-techusa.com/shop/actuators/toyo/tc-100/?utm_source=chatgpt.com 'TC 100 - Accu Tech USA'
[3]: https://www.acepillar.com/product/detail/TC100?utm_source=chatgpt.com 'Toyo 東佑達 TC100 系列 電動缸 | 羅昇企業'

| 重連層級                                               | 應放置位置                                                                                                 | 理由                                                                             |
| ------------------------------------------------------ | ---------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| Transport 自動重連（COM port 斷線/重插、TCP 斷線重撥） | Calin.Communication.Modbus 內部或包一層 ResilientModbusClient 裝飾器                                       | 它擁有 SerialPort/Socket，唯一能正確處理 reopen                                  |
| OPEN/INIT 流程級重試                                   | 已在 Tc100InitSequence 內（InitMaxAttempts）                                                               | 屬於協定握手語意                                                                 |
| 單一 Modbus 命令重試                                   | 已在 Tc100CommandDispatcher 內（MaxRetryCount）                                                            | 屬於指令排程語意                                                                 |
| 「斷線後 → 重連 → 重做 OPEN/INIT」的編排               | 上一層 Host / Application（呼叫 Faulted 後 StopAsync → 重建 IModbusClient → InitializeAsync → StartAsync） | TC-100 Runtime 在 INIT 失敗時會進 Faulted 狀態，由 Host 決定是否重啟整個生命週期 |

| 考量點                        | SerialCore  | SerialPort                          |
| ----------------------------- | ----------- | ----------------------------------- |
| IReconnectStrategy 介面       | ✅ 抽象定義 | —                                   |
| 重連策略實作（Backoff/Fixed） | —           | ✅ 驅動層行為                       |
| SerialPortConnection 重連迴圈 | —           | ✅ IO 操作生命週期                  |
| AutoReconnectEnabled 設定欄位 | —           | ✅ 已存在於 SerialPortConfiguration |
