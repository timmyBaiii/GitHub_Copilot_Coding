---
name: javascript-code-style
description: "Use when writing or reviewing JavaScript or TypeScript code in this workspace."
applyTo:
  - "**/*.js"
  - "**/*.jsx"
  - "**/*.ts"
  - "**/*.tsx"
---

- 使用 modern JavaScript，優先採用 ES2024+ 語法。
- 變數預設使用 `const`，只有會重新指派時才用 `let`，避免使用 `var`。
- 縮排統一使用 2 個空格。
- 字串預設使用單引號，必要時使用雙引號或模板字串。
- 每行結尾補上分號。
- 比較應使用 `===` / `!==`，避免 `==` / `!=`。
- 簡短函式建議使用 arrow function；較複雜的邏輯可使用命名函式。
- 單行長度最好不超過 100 個字元，超過時請適當斷行。
- 使用模板字串處理插值。
- 儘量用 `async/await`，並在必要時使用 `try/catch` 處理錯誤。
- 匯入排序：先第三方套件，再內部模組，最後相對路徑。
- 變數與函式命名要描述性，避免單一字母名稱（iterator 除外）。
- 優先使用 named exports，只有單一主要匯出時才使用 default export。
- 優先採用聲明式陣列操作（map/filter/reduce），避免不必要的手動迴圈。
- 將資料邏輯與 DOM/UI 操作分離，保持函式純粹與可測試。
- 對外暴露的函式或模組，建議加入簡單 JSDoc 或註解說明參數與回傳值。
