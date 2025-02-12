# .NET 專案 README

## 專案簡介
本專案是一個基於 .NET 開發的應用程式，包含完整的後端功能與單元測試，以確保系統的穩定性與可維護性。

## 主要功能
- **RESTful API**：使用 ASP.NET Core 搭建，支援 CRUD 操作。
- **資料庫整合**：支援 MS SQL 與 Entity Framework Core。
- **單元測試**：使用 xUnit 進行測試，確保系統核心邏輯的正確性。

## 技術架構
- **後端框架**：ASP.NET Core
- **資料庫**：MS SQL / Entity Framework Core
- **測試框架**：xUnit / Moq

## 安裝與執行
### 1. 環境需求
- .NET 8.0 或更新版本
- MS SQL Server
- Visual Studio / VS Code

### 2. 安裝步驟
```sh
# 1. Clone 專案
git clone <repo-url>
cd <project-folder>

# 2. 安裝依賴
dotnet restore

# 3. 設定資料庫
dotnet ef database update

# 4. 執行專案
dotnet run
```

## 單元測試
專案內建 xUnit 測試，可使用以下指令執行測試：
```sh
# 執行所有單元測試
dotnet test
```
本 README 仍在持續更新，如有需求請提供額外資訊！

