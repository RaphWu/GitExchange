| 狀態    | 說明                           |
| ------- | ------------------------------ |
| Closed  | 控制卡未開啟                   |
| Opened  | 控制卡已開啟，伺服關閉         |
| ServoOn | 所有軸伺服開啟，可接受運動命令 |
| Error   | 控制卡或軸發生嚴重錯誤         |

| 觸發器 (Trigger)   | 對應方法                      |
| ------------------ | ----------------------------- |
| BoardOpen          | BoardOpen()                   |
| BoardClose         | BoardClose()                  |
| ServoOn / ServoOff | ServoOn() / ServoOff()        |
| Fault              | 輪詢偵測到錯誤或 API 回傳失敗 |
| Reset              | ResetAxisState() 或重新開啟   |

```mermaid
stateDiagram-v2
    state "已關閉 (Closed)" as Closed
    state "已開啟 (Opened)" as Opened
    state "伺服開啟 (ServoOn)" as ServoOn
    state "錯誤 (Error)" as Error

    [*] --> Closed
    Closed --> Opened : BoardOpen
    Opened --> Closed : BoardClose
    Opened --> ServoOn : ServoOn
    ServoOn --> Opened : ServoOff
    Opened --> Error : Fault
    ServoOn --> Error : Fault
    Error --> Closed : BoardClose
    Error --> Opened : Reset
```

| 狀態      | 對應硬體旗標                                               |
| --------- | ---------------------------------------------------------- |
| Disabled  | STA_AX_DISABLE                                             |
| Ready     | STA_AX_READY                                               |
| Moving    | STA_AX_PTP_MOTION、STA_AX_CONTI_MOTION、STA_AX_SYNC_MOTION |
| Homing    | STA_AX_HOMING                                              |
| Jog / Mpg | STA_AX_EXT_JOG、STA_AX_EXT_MPG                             |
| Stopping  | STA_AX_STOPPING                                            |
| Paused    | STA_AX_PAUSE                                               |
| ErrorStop | STA_AX_ERROR_STOP                                          |

| 觸發器 (Trigger)                   | 對應方法                     |
| ---------------------------------- | ---------------------------- | --- | -------------------- | -------------------- |
| ServoOn / ServoOff                 | 伺服開關                     |
| MoveStart / MoveDone               | 運動開始、完成（由輪詢判定） |     | HomeStart / HomeDone | AxisHome()、輪詢判定 |
| JogStart / MpgStart / ExtDriveStop | SetExtDrive(axis, 1/2/0)     |
| Stop                               | AxisStop()                   |     | EmgStop              | AxisStopEmg()        |
| Pause / Resume                     | 暫停、恢復                   |
| Fault                              | 輪詢偵測到 STA_AX_ERROR_STOP |
| ResetError                         | ResetAxisState()             |

```mermaid
stateDiagram-v2
    state "已關閉 (Closed)" as Closed
    state "已開啟、伺服關閉 (Initialized)" as Initialized
    state "伺服開啟、待原點復歸 (NotHomed)" as NotHomed
    state "就緒 (Ready)" as Ready
    state "原點復歸中 (Homing)" as Homing
    state "運動中 (Moving)" as Moving
    state "JOG/MPG 模式 (Jog)" as Jog
    state "減速停止中 (Stopping)" as Stopping
    state "暫停 (Paused)" as Paused
    state "錯誤停止 (ErrorStop)" as ErrorStop
    state "緊急停止 (EmgStop)" as EmgStop

    [*] --> Closed
    Closed --> Initialized : AxisOpen
    Initialized --> Closed : AxisClose
    Initialized --> NotHomed : ServoOn
    NotHomed --> Initialized : ServoOff

    NotHomed --> Homing : HomeStart
    Ready --> Homing : HomeStart
    Homing --> Ready : HomeDone

    Ready --> Initialized : ServoOff
    Ready --> Moving : MoveStart
    Moving --> Ready : MoveDone
    Ready --> Jog : JogStart
    Jog --> Ready : JogStop

    Moving --> Paused : Pause
    Paused --> Moving : Resume

    Moving --> Stopping : Stop
    Jog --> Stopping : Stop
    Stopping --> Ready : StopDone

    Ready --> ErrorStop : Fault
    Homing --> ErrorStop : Fault
    Moving --> ErrorStop : Fault
    Jog --> ErrorStop : Fault
    Stopping --> ErrorStop : Fault
    ErrorStop --> Ready : ResetError

    NotHomed --> EmgStop : EmgStop
    Ready --> EmgStop : EmgStop
    Homing --> EmgStop : EmgStop
    Moving --> EmgStop : EmgStop
    Jog --> EmgStop : EmgStop
    Paused --> EmgStop : EmgStop
    Stopping --> EmgStop : EmgStop
    ErrorStop --> EmgStop : EmgStop
    EmgStop --> Initialized : ResetEmg
    EmgStop --> Closed : AxisClose
```
