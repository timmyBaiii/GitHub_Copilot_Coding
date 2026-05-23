---
name: daily-task-log
description: "Use when appending today's completed task log entry into logs/yyyy-MM-dd.md with the required session and prompt format."
---

1. 詢問使用者今天要記錄的 session 名稱。
2. 詢問使用者要記錄的每個 Prompt 條目與對應的 [Ask /Agent/ plan] 內容。
3. 使用今天日期作為檔名，格式為 `yyyy-MM-dd`。
4. 確保 workspace 根目錄下存在 `logs/` 資料夾，必要時建立該資料夾。
5. 將目標檔案設為 `logs/yyyy-MM-dd.md`。
6. 若檔案不存在，建立新檔並寫入內容；若檔案已存在，則在檔案末尾追加內容。
7. 追加內容格式如下：
   - `[session name]`
   - `### Prompt[n]: [...]`
   - `[Ask /Agent/ plan] (Model): [...]`
   - 若有多個 Prompt 條目，依序寫入多個 `### Prompt[n]` 區塊。
8. 若檔案已有內容，追加時先插入一個空白行以分隔新舊記錄。
9. 確保一天只使用同一個檔案，並且若檔案已存在就追加到同一個檔案後面。
10. 完成後回報實際寫入的檔案路徑與操作類型（建立或追加）。
