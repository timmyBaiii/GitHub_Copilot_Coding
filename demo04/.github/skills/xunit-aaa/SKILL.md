---
name: xunit-aaa
description: "Use when creating an xUnit unit test project with AAA structure using the .NET CLI on .NET 9 or newer."
---

1. 確認使用者要建立的測試專案名稱。
2. 使用 .NET CLI 建立 xUnit 測試專案，並且指定目標框架為 `net9.0` 或更高版本。
   - 範例：`dotnet new xunit -n MyProject.Tests -f net9.0`
3. 使用 `dotnet sln add` 或手動將測試專案加入解決方案（如果需要）。
4. 編寫單元測試時，遵循 AAA 模式：Arrange、Act、Assert。
   - Arrange：設定測試資料與 mocked 物件。
   - Act：呼叫要測試的方法。
   - Assert：驗證結果是否符合預期。
5. 確保每個測試案例只測試單一行為，避免多重斷言聚合不相關驗證。
6. 為測試方法使用清楚的命名，通常包含 `Should` 或 `When` 字眼來表示行為。
7. 使用 `dotnet test` 執行測試，並確認測試專案可以在 .NET 9 以上環境順利通過。
8. 若需要改用更高版本的 .NET，請將 `-f net9.0` 改為 `-f netX.0`（X >= 9）。
