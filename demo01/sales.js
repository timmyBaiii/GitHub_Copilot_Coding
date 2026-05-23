// 台灣的營業稅是基於銷售額計算的，通常為5%。
// 營業稅的計算公式為：
// 營業稅 = 銷售額 × 營業稅率
// 例如：如果銷售額為1000元，則營業稅為：
// 營業稅 = 1000 × 0.05 = 50元
// 營業稅的計算方式是將銷售額乘以營業稅率，然後將結果四捨五入到小數點後兩位。
// 這樣可以確保計算的準確性和一致性。

function calculateSalesResult(salesAmount) {
    const taxRate = 0.05;
    const salesTax = Math.round(salesAmount * taxRate * 100) / 100; // 四捨五入到小數點後兩位
    return { salesAmount: salesAmount, salesTax: salesTax };
}

// 使用範例：物件計算並輸出指定格式
const result = calculateSalesResult(1000);
const salesAmountStr = Number.isInteger(result.salesAmount) ? result.salesAmount : result.salesAmount.toFixed(2);
const salesTaxStr = Number.isInteger(result.salesTax) ? result.salesTax : result.salesTax.toFixed(2);
console.log(`銷售額: ${salesAmountStr}元, 營業稅: ${salesTaxStr}元`);


