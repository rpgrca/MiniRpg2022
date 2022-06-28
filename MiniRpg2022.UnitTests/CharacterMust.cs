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
}