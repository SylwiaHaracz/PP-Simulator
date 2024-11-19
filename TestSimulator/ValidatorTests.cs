namespace TestSimulator;
using Simulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(7,5,10, 7)]
    [InlineData(20, 1, 10, 10)]
    [InlineData(-5, 3, 10, 3)]
    [InlineData(5, 5, 30, 5)]
    public void Validator_Limiter_ShouldPassCorrectly(int value, int min, int max, int output)
    {
        Assert.Equal(output, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData("   Shrek    ", 3, 20, '-', "Shrek")]
    [InlineData("       ", 5, 18, '#', "#####")]
    [InlineData("  donkey     ", 5, 18, '_', "Donkey")]
    [InlineData("Puss in Boots – a clever and brave cat.", 1, 13, '.', "Puss in Boots")]
    [InlineData("a                            troll name", 3, 10, '#', "A##")]
    public void Validator_(string value, int min, int max, char placeholder, string output)
    {
        Assert.Equal(output, Validator.Shortener(value, min, max, placeholder));
    }
}
