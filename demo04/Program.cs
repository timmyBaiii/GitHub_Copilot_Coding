using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/calculate/bmi", (BodyMeasurements input) =>
{
    if (input.HeightCm <= 0 || input.WeightKg <= 0)
    {
        return Results.BadRequest(new { error = "Height and weight must be greater than zero." });
    }

    var (bmi, category) = Calculator.CalculateBmi(input.HeightCm, input.WeightKg);
    return Results.Ok(new { bmi = Math.Round(bmi, 1), category });
});

app.MapPost("/calculate/bmr", (BmrRequest input) =>
{
    if (input.HeightCm <= 0 || input.WeightKg <= 0 || input.Age <= 0)
    {
        return Results.BadRequest(new { error = "Height, weight, and age must be greater than zero." });
    }

    if (string.IsNullOrWhiteSpace(input.Sex))
    {
        return Results.BadRequest(new { error = "Sex is required." });
    }

    var sex = input.Sex.Trim().ToLowerInvariant();
    if (sex != "male" && sex != "female")
    {
        return Results.BadRequest(new { error = "Sex must be either 'male' or 'female'." });
    }

    var (bmr, formula) = Calculator.CalculateBmr(input.HeightCm, input.WeightKg, input.Age, sex);
    return Results.Ok(new { bmr = Math.Round(bmr, 1), formula });
});

app.MapPost("/calculate/tdee", (TdeeRequest input) =>
{
    if (input.HeightCm <= 0 || input.WeightKg <= 0 || input.Age <= 0)
    {
        return Results.BadRequest(new { error = "Height, weight, and age must be greater than zero." });
    }

    if (string.IsNullOrWhiteSpace(input.Sex) || string.IsNullOrWhiteSpace(input.ActivityLevel))
    {
        return Results.BadRequest(new { error = "Sex and activity level are required." });
    }

    var sex = input.Sex.Trim().ToLowerInvariant();
    if (sex != "male" && sex != "female")
    {
        return Results.BadRequest(new { error = "Sex must be either 'male' or 'female'." });
    }

    var parseResult = Calculator.CalculateTdee(input.HeightCm, input.WeightKg, input.Age, sex, input.ActivityLevel);
    if (!parseResult.Success)
    {
        return Results.BadRequest(new { error = parseResult.Error });
    }

    return Results.Ok(new { tdee = Math.Round(parseResult.Tdee, 1), activityFactor = parseResult.ActivityFactor });
});

app.Run();

internal record BodyMeasurements(double HeightCm, double WeightKg);
internal record BmrRequest(double HeightCm, double WeightKg, int Age, string Sex);
internal record TdeeRequest(double HeightCm, double WeightKg, int Age, string Sex, string ActivityLevel);
