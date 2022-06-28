using static MiniRpg2022.UnitTests.Constants;
using Videogame;

namespace MiniRpg2022.UnitTests;

public class CharacterMust
{

    [Fact]
    public void ReturnNameCorrectly()
    {
        var sut = CreateSubjectUnderTest();
        Assert.Equal(RAISTLIN_NAME, sut.Name);
    }

    private static Character CreateSubjectUnderTest() => new(RAISTLIN_NAME, RAISTLIN_NICKNAME, GetRaistlinBirthday());

    private static Birthday GetRaistlinBirthday() =>
        new Birthday.Builder().BornOn(RAISTLIN_BIRTHDAY).BeingToday(TODAY).Build();

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ThrowException_WhenNameIsInvalid(string invalidName)
    {
        var exception = Assert.Throws<ArgumentException>("name", () => new Character(invalidName, RAISTLIN_NICKNAME, GetRaistlinBirthday()));
        Assert.StartsWith("Invalid name", exception.Message);
    }

    [Fact]
    public void ReturnBirthdayCorrectly()
    {
        var sut = CreateSubjectUnderTest();
        Assert.Equal(RAISTLIN_BIRTHDAY_IN_TEXT, sut.Birthday.ToString());
    }

    [Fact]
    public void ReturnHealthCorrectly()
    {
        var sut = CreateSubjectUnderTest();
        Assert.Equal(100, sut.Health);
    }

    [Fact]
    public void ThrowException_WhenNicknameIsInvalid()
    {
        var exception = Assert.Throws<ArgumentException>("nickname", () => new Character(RAISTLIN_NAME, null, GetRaistlinBirthday()));
        Assert.StartsWith("Invalid nickname", exception.Message);
    }

    [Theory]
    [InlineData("")]
    [InlineData(RAISTLIN_NICKNAME)]
    public void ReturnNicknameCorrectly(string nickname)
    {
        var sut = new Character(RAISTLIN_NAME, nickname, GetRaistlinBirthday());
        Assert.Equal(nickname, sut.Nickname);
    }
}