using NUnit.Framework;
using System;

[TestFixture]
public class ProgramTests
{
    [Test]
    public void ParseInput_ValidNumber_ReturnsNumber()
    {
        string input="123";
        int result=Program.ParseInput(input);
        Assert.That(result,Is.EqualTo(123));
    }

    [Test]
    public void ParseInput_TooLargeNumber_ThrowsOverflowException()
    {
        string input="3000000000";  //Это число больше, чем int.MaxValue
        var ex=Assert.Throws<OverflowException>(()=>Program.ParseInput(input));
        Assert.That(ex.Message,Is.EqualTo("Введено слишком большое число"));
    }

    [Test]
    public void ParseInput_TooSmallNumber_ThrowsOverflowException()
    {
        string input="-3000000000";  //Это число меньше, чем int.MinValue
        var ex=Assert.Throws<OverflowException>(()=>Program.ParseInput(input));
        Assert.That(ex.Message,Is.EqualTo("Введено слишком маленькое число"));
    }

    [Test]
    public void ParseInput_NotANumber_ThrowsFormatException()
    {
        string input = "abc";  // Это не число
        var ex = Assert.Throws<FormatException>(() => Program.ParseInput(input));
        Assert.That(ex.Message, Is.EqualTo("Введено не число."));
    }

    [Test]
    public void ParseInput_ValidNegativeNumber_ReturnsNumber()
    {
        string input = "-123";
        int result = Program.ParseInput(input);
        Assert.That(result, Is.EqualTo(-123));
    }
}