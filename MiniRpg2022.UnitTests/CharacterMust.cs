using Videogame;

namespace MiniRpg2022.UnitTests;

public class CharacterMust
{
    private static readonly DateOnly RAISTLIN_BIRTHDAY = new DateOnly(2017, 3, 15);

    [Fact]
    public void ReturnNameCorrectly()
    {
        var sut = new Character("Raistlin", RAISTLIN_BIRTHDAY);
        Assert.Equal("Raistlin", sut.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ThrowException_WhenNameIsInvalid(string invalidName)
    {
        var exception = Assert.Throws<ArgumentException>("name", () => new Character(invalidName, RAISTLIN_BIRTHDAY));
        Assert.StartsWith("Invalid name", exception.Message);
        Assert.Contains("'name'", exception.Message);
    }

    [Fact]
    public void ReturnBirthdayCorrectly()
    {
        var sut = new Character("Raistlin", RAISTLIN_BIRTHDAY);
        Assert.Equal(RAISTLIN_BIRTHDAY, sut.Birthday);
    }
}