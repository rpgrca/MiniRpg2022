using Videogame;

namespace MiniRpg2022.UnitTests;

public class CharacterMust
{
    [Fact]
    public void ReturnNameCorrectly()
    {
        var sut = new Character("Raistlin");
        Assert.Equal("Raistlin", sut.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ThrowException_WhenNameIsInvalid(string invalidName)
    {
        var exception = Assert.Throws<ArgumentException>("name", () => new Character(invalidName));
        Assert.StartsWith("Invalid name", exception.Message);
        Assert.Contains("'name'", exception.Message);
    }
}