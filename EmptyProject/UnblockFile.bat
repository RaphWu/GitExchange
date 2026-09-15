@echo off

REM 強制切換到 .bat 所在資料夾
cd /d "%~dp0"

echo =========================================================
echo   !!!  警告  !!!
echo   此動作將會解除目前資料夾與底下所有項目的 MOTW 標記：
echo.
echo        - 目前資料夾本身
echo        - 所有檔案
echo        - 所有子資料夾
echo.
echo   目前目錄：
echo   %cd%
echo =========================================================
echo.

set /p confirm=請輸入 Y 確認執行，其他鍵取消:

if /I not "%confirm%"=="Y" (
    echo.
    echo 已取消操作。
    pause
    exit /b
)

echo.
echo ===== 開始解除封鎖 =====
echo.

setlocal enabledelayedexpansion
set count=0

for /f %%n in ('powershell -NoProfile -ExecutionPolicy Bypass -Command "$items = @(Get-Item -LiteralPath . -Force) + @(Get-ChildItem -LiteralPath . -Recurse -Force); foreach ($item in $items) { Unblock-File -LiteralPath $item.FullName }; Write-Output $items.Count"') do set count=%%n

echo.
echo =========================================================
echo   解除封鎖完成！
echo   共處理 !count! 個項目
echo =========================================================
pause
