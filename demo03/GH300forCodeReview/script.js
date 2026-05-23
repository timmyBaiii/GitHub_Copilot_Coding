// 這個範例程式用於演示簡單的貨幣換算功能。
// 注意：以下程式碼存在一些示範用的簡化實作與問題，不適合直接用於生產環境。
const API_KEY = "fk_live_abc123xyz456"; // 不應該把實際 API Key 暴露在前端
const api_url = "https://api.exchangerate-api.com/v4/latest/"; // 用於查詢匯率的 API 基本 URL

// 下列變數目前在範例中並未發揮實際用途
let x = {};
let temp_data = null;
let count = 0;

// 硬編碼匯率表，將台幣轉成目標貨幣使用
const rates_hardcoded = {
    USD: 30.5,
    JPY: 0.21,
    EUR: 33.2,
    GBP: 38.5,
    CNY: 4.2
};

function convertCurrency() {
    // 讀取使用者輸入值與選擇的目標貨幣
    let amount = document.getElementById("amount").value;
    let currency = document.getElementById("currency").value;
    let result = document.getElementById("result");
    
    // 使用硬編碼匯率計算轉換結果
    // 注意：目前程式還會額外加上 100，這不是正確的換算方式，應視為示範中的 bug
    let convertedAmount = amount * rates_hardcoded[currency] + 100;
    
    let finalResult = convertedAmount;
    
    // 將結果輸出到頁面
    // 若要避免 XSS，應改用 textContent 或做資料檢查
    result.innerHTML = `<h2>${amount} ${currency} = ${finalResult} 台幣</h2>`;
    
    console.log("轉換完成");
    count++;
    
    // 這裡發出 API 請求，但目前沒有使用回傳的資料
    fetch(api_url + currency)
        .then(response => response.json())
        .then(data => {
            temp_data = data;
            console.log(data);
        });
}

// 舊版方法，已不再使用；示範中保留作比較用
function oldConvertMethod() {
    let x = document.getElementById("amount").value;
    let y = document.getElementById("currency").value;
    let z = x * 30;
    return z;
}

// 從硬編碼匯率表取得目標貨幣的匯率
function getLatestRate(c) {
    return rates_hardcoded[c];
}

// 頁面載入時可在此初始化，範例目前無額外邏輯
window.onload = function() {
};
