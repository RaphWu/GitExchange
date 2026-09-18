@echo off

REM 強制切換到 .bat 所在資料夾
cd /d "%~dp0"

echo =========================================================
echo   !!!  警告  !!!
echo   此動作將會遞迴刪除目前資料夾底下所有：
echo.
echo        - bin 資料夾
echo        - obj 資料夾
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
echo ===== 開始清理 =====
echo.

setlocal enabledelayedexpansion
set count=0

REM 刪除 bin 資料夾
for /d /r %%d in (bin) do (
    if exist "%%d" (
        echo [BIN] 刪除: %%d
        rd /s /q "%%d"
        set /a count+=1
    )
)

REM 刪除 obj 資料夾
for /d /r %%d in (obj) do (
    if exist "%%d" (
        echo [OBJ] 刪除: %%d
        rd /s /q "%%d"
        set /a count+=1
    )
)

echo.
echo =========================================================
echo   清理完成！
echo   共刪除 !count! 個資料夾
echo =========================================================
pause
