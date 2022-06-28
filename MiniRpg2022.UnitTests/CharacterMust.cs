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

    private static Character CreateSubjectUnderTest() =>
        SetupSubjectUnderTest().Build();

    private static Character.Builder SetupSubjectUnderTest() =>
        new Character.Builder()
            .Called(RAISTLIN_NAME)
            .AlsoKnownAs(RAISTLIN_NICKNAME)
            .BornOn(GetRaistlinBirthday())
            .As(GetRaistlinOccupation())
            .WithSpeedOf(RAISTLIN_SPEED)
            .WithDexterityOf(RAISTLIN_DEXTERITY);

    private static Birthday GetRaistlinBirthday() =>
        new Birthday.Builder().BornOn(RAISTLIN_BIRTHDAY).BeingToday(TODAY).Build();

    private static IOccupation GetRaistlinOccupation() => new Mage();

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ThrowException_WhenNameIsInvalid(string invalidName)
    {
        var exception = Assert.Throws<ArgumentException>("name", () => new Character.Builder().Called(invalidName).Build());
        Assert.StartsWith("Invalid name", exception.Message);
    }

    [Fact]
    public void ThrowException_WhenBirthdayIsInvalid()
    {
        var exception = Assert.Throws<ArgumentException>("birthday", () => new Character.Builder().Called(RAISTLIN_NAME).BornOn(null).Build());
        Assert.StartsWith("Invalid birthday", exception.Message);
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
        var exception = Assert.Throws<ArgumentException>("nickname", () => new Character.Builder().Called(RAISTLIN_NAME).AlsoKnownAs(null).Build());
        Assert.StartsWith("Invalid nickname", exception.Message);
    }

    [Theory]
    [InlineData("")]
    [InlineData(RAISTLIN_NICKNAME)]
    public void ReturnNicknameCorrectly(string nickname)
    {
        var sut = SetupSubjectUnderTest()
            .AlsoKnownAs(nickname)
            .Build();
        Assert.Equal(nickname, sut.Nickname);
    }

    [Fact]
    public void ReturnTypeCorrectly()
    {
        var sut = CreateSubjectUnderTest();
        Assert.Equal(RAISTLIN_TYPE, sut.Occupation.ToString());
    }

    [Fact]
    public void ThrowException_WhenTypeIsOmmited()
    {
        var exception = Assert.Throws<ArgumentException>("occupation", () => new Character.Builder().Called(RAISTLIN_NAME).BornOn(GetRaistlinBirthday()).Build());
        Assert.StartsWith("Invalid occupation", exception.Message);
    }

    [Fact]
    public void ThrowException_WhenTypeIsNull()
    {
        var exception = Assert.Throws<ArgumentException>("occupation", () => new Character.Builder().Called(RAISTLIN_NAME).BornOn(GetRaistlinBirthday()).As(null).Build());
        Assert.StartsWith("Invalid occupation", exception.Message);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(11)]
    [InlineData(100)]
    public void ThrowException_WhenSpeedIsInvalid(int invalidSpeed)
    {
        var exception = Assert.Throws<ArgumentException>(() => SetupSubjectUnderTest().WithSpeedOf(invalidSpeed).Build());
        Assert.StartsWith("Invalid property value", exception.Message);
        Assert.Contains(invalidSpeed.ToString(), exception.Message);
    }

    [Fact]
    public void ReturnSpeedCorrectly()
    {
        var sut = CreateSubjectUnderTest();
        Assert.Equal(RAISTLIN_SPEED, sut.Speed);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(6)]
    [InlineData(100)]
    public void ThrowException_WhenDexterityIsInvalid(int invalidDexterity)
    {
        var exception = Assert.Throws<ArgumentException>(() => SetupSubjectUnderTest().WithDexterityOf(invalidDexterity).Build());
        Assert.StartsWith("Invalid property value", exception.Message);
        Assert.Contains(invalidDexterity.ToString(), exception.Message);
    }

    [Fact]
    public void ReturnDexterityCorrectly()
    {
        var sut = CreateSubjectUnderTest();
        Assert.Equal(RAISTLIN_DEXTERITY, sut.Dexterity);
    }
}