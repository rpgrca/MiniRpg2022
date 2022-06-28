using static MiniRpg2022.UnitTests.Constants;
using Videogame;

namespace MiniRpg2022.UnitTests;

public class CharacterMust
{
    [Fact]
    public void ReturnNameCorrectly()
    {
        var sut = new Character("Raistlin", GetRaistlinBirthday());
        Assert.Equal("Raistlin", sut.Name);
    }

    private static Birthday GetRaistlinBirthday() =>
        new Birthday.Builder().BornOn(RAISTLIN_BIRTHDAY).BeingToday(TODAY).Build();

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ThrowException_WhenNameIsInvalid(string invalidName)
    {
        var exception = Assert.Throws<ArgumentException>("name", () => new Character(invalidName, GetRaistlinBirthday()));
        Assert.StartsWith("Invalid name", exception.Message);
    }

    [Fact]
    public void ReturnBirthdayCorrectly()
    {
        var sut = new Character("Raistlin", GetRaistlinBirthday());
        Assert.Equal(RAISTLIN_BIRTHDAY_IN_TEXT, sut.Birthday.ToString());
    }

    [Fact]
    public void ReturnHealthCorrectly()
    {
        var sut = new Character("Raistlin", GetRaistlinBirthday());
        Assert.Equal(100, sut.Health);
    }
}