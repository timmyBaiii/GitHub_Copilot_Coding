using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "SalesApi is running");

// Minimal API endpoint: 計算單筆銷售額的營業稅，並回傳物件
app.MapGet("/sales/{amount}", (decimal amount) =>
{
	const decimal taxRate = 0.05m;
	var salesTax = Math.Round(amount * taxRate, 2, MidpointRounding.AwayFromZero);
	var result = new { salesAmount = amount, salesTax = salesTax };
	return Results.Json(result);
});

app.Run();
