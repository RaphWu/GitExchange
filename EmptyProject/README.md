# EmptyProject

簡短說明
--
一個以 .NET 7.0 與 Windows Forms 建置的範例桌面應用程式，示範基本表單結構、表單事件與 CSV 處理範例（專案內有使用 CsvHelper 做範例解析）。

狀態
--
Prototype

需求與相容性
--
- .NET SDK 7.0 或相容版本
- 作業系統：Windows（此專案使用 Windows Forms）

快速開始
--
1. 還原相依套件：

```bash
dotnet restore
```

2. 建置：

```bash
dotnet build
```

3. 執行（開發模式）：

```bash
dotnet run --project EmptyProject.csproj
```

專案結構（重點檔案）
--
- [Program.cs](Program.cs)：應用程式啟動點。
- [Form1.cs](Form1.cs)、[Form1.Designer.cs](Form1.Designer.cs)：主要 Windows Forms 表單與設計檔。
- [Properties/](Properties/)：專案設定與資源檔。

主要相依套件
--
- CsvHelper 27.2.1 — CSV 解析器
- Microsoft.Bcl.AsyncInterfaces 8.0.0
- Microsoft.Bcl.HashCode 1.1.1
- System.Buffers 4.6.1
- System.Memory 4.6.3
- System.Numerics.Vectors 4.6.1
- System.Runtime.CompilerServices.Unsafe 6.1.2
- System.Threading.Tasks.Extensions 4.5.4

建置與發行說明
--
- 建置會產生 Windows 可執行檔案於 `bin/Debug/net7.0-windows/`（或 Release 模式下 `bin/Release/...`）。
- 若要建立發行套件，請使用 `dotnet publish -c Release -r win-x64 --self-contained false`（視需求調整 runtime 與 self-contained 參數）。

測試
--
此專案未包含自動化測試。如要加入，建議建立一個單元測試專案（xUnit / NUnit / MSTest），並在 CI 中執行 `dotnet test`。

持續整合（CI）
--
目前專案內無明確 CI 工作流程設定（例如 `.github/workflows/`）。若要加入 GitHub Actions，可建立簡單的工作流程執行 `dotnet restore`, `dotnet build`, `dotnet test`。

貢獻
--
歡迎透過 Issue 或 Pull Request 貢獻。一般流程建議：

1. Fork 專案
2. 建立功能分支：`git checkout -b feature/your-feature`
3. 提交修改並開 PR

授權
--
此 repository 目前沒有 `LICENSE` 檔案。建議新增 `LICENSE`（例如 MIT 或 Apache-2.0）以明確授權條款。

其他說明
--
- 若需要自動匯入 CSV 範例，請參考專案內 `CsvHelper` 的使用位置。
- 若要自動化產生 README 的工具，參考 `skills/.github/skills/create-readme/SKILL.md` 中的規格。

聯絡
--
請使用 Issues 提交問題或建議。
