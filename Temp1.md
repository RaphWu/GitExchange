| 測試                                                   | 問題                                                      | 修正方式                                   |
| ------------------------------------------------------ | --------------------------------------------------------- | ------------------------------------------ |
| Fit_SineWave_ShouldCaptureFirstHarmonic                | interval = 2π/n 讓最後一點不落在 2π，正規化後頻率錯配     | 改 interval = 2π/(n-1)，x 覆蓋完整 [0, 2π] |
| Fit_WithHigherHarmonics_ShouldFitComplexWave           | 同上                                                      | 同上                                       |
| Fit_IncreasesSmoothPoints_ShouldIncreaseResolution     | xs2[last] > xs1[last] 兩者都等於 xMax=4，邏輯永遠為 false | 改為檢查步距縮小                           |
| Fit_PeriodicDegreeSamples_ShouldReproduceOriginalWave  | y 用 i\*π/180 但正規化周期是 359 不是 360，1e-6 必定失敗  | 改用正規化角度 i/(n-1)\*2π 生成 y          |
| Fit_PeriodicDegreeSamples_ShouldKeepEndpointContinuous | 修正 FourierFit.cs 後自動通過                             | 無需修改                                   |
