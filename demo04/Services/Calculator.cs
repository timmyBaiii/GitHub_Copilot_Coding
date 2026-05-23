using System;
using System.Collections.Generic;

public static class Calculator
{
    private static readonly Dictionary<string, double> ActivityFactors = new(StringComparer.OrdinalIgnoreCase)
    {
        ["sedentary"] = 1.2,
        ["light"] = 1.375,
        ["moderate"] = 1.55,
        ["active"] = 1.725,
        ["veryActive"] = 1.9,
    };

    public static (double Bmi, string Category) CalculateBmi(double heightCm, double weightKg)
    {
        var heightMeters = heightCm / 100.0;
        var bmi = weightKg / Math.Pow(heightMeters, 2);
        var category = bmi switch
        {
            < 18.5 => "Underweight",
            < 25 => "Normal weight",
            < 30 => "Overweight",
            _ => "Obese",
        };

        return (bmi, category);
    }

    public static (double Bmr, string Formula) CalculateBmr(double heightCm, double weightKg, int age, string sex)
    {
        // sex must be normalized to lower-case external to this method if needed
        var bmr = sex == "male"
            ? 10 * weightKg + 6.25 * heightCm - 5 * age + 5
            : 10 * weightKg + 6.25 * heightCm - 5 * age - 161;

        var formula = sex == "male" ? "Mifflin-St Jeor (male)" : "Mifflin-St Jeor (female)";
        return (bmr, formula);
    }

    public static (bool Success, double Tdee, double ActivityFactor, string Error) CalculateTdee(double heightCm, double weightKg, int age, string sex, string activityLevel)
    {
        if (!ActivityFactors.TryGetValue(activityLevel.Trim(), out var factor))
        {
            return (false, 0, 0, "Invalid activity level.");
        }

        var (bmr, _) = CalculateBmr(heightCm, weightKg, age, sex);
        var tdee = bmr * factor;
        return (true, tdee, factor, string.Empty);
    }
}
