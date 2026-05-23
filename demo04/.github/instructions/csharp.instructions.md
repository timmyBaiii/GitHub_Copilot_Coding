---
name: csharp-code-style
description: "Use when writing or reviewing C# code in this workspace."
applyTo:
  - "**/*.cs"
---

- 遵循 Microsoft C# 命名慣例：類別與方法使用 PascalCase，區域變數與參數使用 camelCase。
- 盡量使用 `var` 只在右側型別明確時，避免過度使用 `var` 或顯式型別宣告混用。
- 控制流程與區塊縮排使用 4 個空格，不使用 Tab。
- 保持程式碼行長不超過 120 個字元，必要時適當斷行。
- 盡量使用 expression-bodied members 來簡化一行方法、屬性或建構函式。
- 使用 `async` / `await` 處理非同步程式，避免直接使用 `.Result` 或 `.Wait()`。
- 儘量使用 `using` 宣告或 `using` 區塊管理可釋放資源。
- 方法應維持單一職責，避免大型方法；若方法超過 30 行，考慮拆分。
- null 判斷採用 nullable reference types 與 `is null` / `is not null`。
- 例外處理僅在需要時捕捉，避免捕捉所有例外；若要重新拋出例外，請保留原始例外資訊。
- 盡量使用集合初始化器、物件初始化器與宣告式 LINQ，避免手動迴圈與臨時列表。
- 依功能分組 `using`，並應排序成：系統命名空間在前，再是第三方，最後是專案內部命名空間。
- 公開 API 需加上簡潔 XML 註解；內部實作可用註解說明非直覺行為。
- 儘量用不可變的類型與只讀屬性，保持物件狀態穩定。
- 若使用 records、structs 與 immutable types，請根據資料領域選擇最適合的型別。
- 保持程式碼可讀性為優先，避免過度聰明的寫法；清楚實作勝過短小精悍。
