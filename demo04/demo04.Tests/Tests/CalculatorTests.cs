using Xunit;

public class CalculatorTests
{
    [Fact]
    public void CalculateBmi_ReturnsExpectedCategory()
    {
        // Arrange
        var heightCm = 170.0;
        var weightKg = 65.0;

        // Act
        var (bmi, category) = Calculator.CalculateBmi(heightCm, weightKg);

        // Assert
        Assert.InRange(bmi, 22.0, 23.0);
        Assert.Equal("Normal weight", category);
    }

    [Fact]
    public void CalculateBmr_Male_ComputesValue()
    {
        // Arrange
        var heightCm = 175.0;
        var weightKg = 70.0;
        var age = 30;
        var sex = "male";

        // Act
        var (bmr, formula) = Calculator.CalculateBmr(heightCm, weightKg, age, sex);

        // Assert
        Assert.True(bmr > 0);
        Assert.Contains("Mifflin-St Jeor", formula);
    }

    [Fact]
    public void CalculateTdee_InvalidActivity_ReturnsFailure()
    {
        // Arrange
        var heightCm = 170.0;
        var weightKg = 65.0;
        var age = 30;
        var sex = "female";
        var activity = "not-a-level";

        // Act
        var result = Calculator.CalculateTdee(heightCm, weightKg, age, sex, activity);

        // Assert
        Assert.False(result.Success);
        Assert.Equal("Invalid activity level.", result.Error);
    }
}
