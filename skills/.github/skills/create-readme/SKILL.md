name: create-readme
description: 掃描指定專案並產生通用且完整的 `README.md` 模板，適用於任何程式專案（包含建置、執行、相依性與貢獻指南等）。
version: 1.2.0

---

# create-readme

## 目的

自動為任意程式專案產生一份結構完整、可直接使用於 GitHub/Repo 的 `README.md`，使維護者與貢獻者可快速了解專案內容、建置與使用方法。

## 行為規格

- 掃描指定資料夾或 repo 根目錄，尋找主要專案檔（如 `*.csproj`, `package.json`, `pyproject.toml`, `pom.xml`, `build.gradle` 等）以判斷專案語言與類型。
- 從專案檔擷取關鍵資訊：名稱、TargetFramework/engine/version、相依套件與版本、是否為 GUI/CLI/Library/服務、主要輸入點（例如 `Program.cs`、`index.js`、`main.py`）。
- 產生 README.md，包含以下標準章節（優先順序）：
  1.  專案名稱（Project Title）
  2.  簡短描述（Short Description）
  3.  狀態（Status）— e.g., Active / Prototype / Deprecated
  4.  要求與相容性（Requirements & Compatibility）
  5.  安裝（Installation）
  6.  建置（Build）
  7.  執行（Run / Usage）
  8.  使用範例（Examples）
  9.  專案結構（Project Structure）
  10. 相依套件（Dependencies）
  11. 測試（Tests）
  12. 持續整合（CI / Workflow）
  13. 貢獻（Contributing）
  14. 授權（License）
  15. 聯絡（Contact / Maintainers）
  16. 常見問題與疑難排解（FAQ / Troubleshooting）
  17. 更新紀錄（Changelog / Release Notes）

## 內容產出規則（每個章節的內容說明）

- **專案名稱**：以 `AssemblyName`、`name` 欄位或目錄名稱決定；若找不到，使用資料夾名稱。
- **簡短描述**：一行描述專案做什麼、解決何種問題。
- **狀態**：若 repo 含 `README` 或 `STATUS` 標記，嘗試讀取；否則預設 `Prototype`。
- **要求與相容性**：列出執行環境（如 `.NET 7.0`, `Node.js >= 14`, `Python 3.10`）、作業系統限制（如 Windows Forms 需 Windows）。
- **安裝**：提供套件還原/安裝指令（例如 `dotnet restore`, `npm install`, `pip install -r requirements.txt`）。
- **建置**：提供建置指令範例（例如 `dotnet build`, `npm run build`, `mvn package`）。
- **執行／使用**：給出最簡單的執行指令與範例（`dotnet run`、`node index.js`、`python -m mypackage`），並示範 CLI 或 API 的基本使用。
- **使用範例**：若 repo 含 sample 程式碼或範例資料，將產生最小可執行示例與輸出預期。
- **專案結構**：列出主要目錄與檔案並加簡短說明（例如 `src/`、`tests/`、`README.md`、`LICENSE`）。
- **相依套件**：從專案檔列出套件名稱與版本；若套件數量過多，則只列出主要套件並提示完整清單位置（例如 `project.assets.json` 或 `package-lock.json`）。
- **測試**：說明如何執行測試（例如 `dotnet test`, `npm test`, `pytest`）與測試覆蓋率指令（如有）。
- **CI**：若存在 `.github/workflows/` 或其他 CI 設定，列出已啟用的工作流程檔名與簡短說明。
- **貢獻**：若存在 `CONTRIBUTING.md`，引用該檔；否則加入最小指南：Fork → Branch → PR → Review → Merge。
- **授權**：如果 repository 包含 `LICENSE` 檔案，引用其名稱；若無，提示加上授權建議（MIT/Apache-2.0 等）。
- **聯絡**：列出 maintainer 或 issue 提交方式（預設為 `Issues`）。
- **FAQ / Troubleshooting**：收集常見錯誤提示與快速解法（若可推斷）。
- **Changelog**：若存在 `CHANGELOG.md` 或 Releases，引用並連結。

## 輸入與配置

- `projectPath`（可選）：要掃描的根目錄。
- `preferProject`（可選）：當 repo 有多個專案檔時，指定要優先使用的專案檔名稱或路徑。
- `backupExisting`（bool, 預設 true）：覆寫 README 前是否備份原檔（`README.md.bak.TIMESTAMP`）。
- `includeExamples`（bool, 預設 true）：是否自動產生使用範例段落。

## 輸出

- 預設會在 `projectPath`（或 repo 根目錄）產生或更新 `README.md`。
- 若 `backupExisting=true`，會建立備份檔案。

## 錯誤處理與邊界情況

- 若找不到任何可辨識的專案檔，仍會輸出一份通用 README 範本，並在開頭註明「未偵測到專案檔，請手動補充」。
- 若偵測到多個專案檔且未提供 `preferProject`，預設以：1) 指定主分支專案檔（含 Startup/AssemblyName）→ 2) 目錄名稱最接近 repo 名稱 → 3) 第一個找到的專案檔 為準。

## 擴充支援與測試

- 支援語言／檔案：C# (`.csproj`), Node (`package.json`), Python (`pyproject.toml`/`requirements.txt`), Java (`pom.xml`/`build.gradle`), Go (`go.mod`) 等。
- 測試重點：單一專案、多專案、無專案檔、含 CI、含 LICENSE、含 CONTRIBUTING.md。

## 隱私與限制

- 本 skill 只讀取檔案系統內可存取的檔案；不會上傳或外傳任何內容。

## 範例使用流程

1. 呼叫 `create-readme --projectPath ./MyApp`。
2. Skill 解析 `MyApp` 中的專案檔與主要檔案。
3. 在 `MyApp/README.md` 產生完整說明並備份舊檔（如有）。

## 更新紀錄

- 1.2.0：擴充為通用 README 規格，加入多語言/多專案支援、備份選項與更完整章節說明。
