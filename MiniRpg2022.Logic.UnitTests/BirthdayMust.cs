using static MiniRpg2022.Logic.UnitTests.Constants;
using Videogame;

namespace MiniRpg2022.Logic.UnitTests;

public class BirthdayMust
{
    [Fact]
    public void ThrowException_WhenMinValueIsSuppliedAsBirthday()
    {
        var exception = Assert.Throws<ArgumentException>("birthday", () => new Birthday.Builder().Build());
        Assert.StartsWith("Invalid birthday", exception.Message);
    }

    [Fact]
    public void ThrowException_WhenMaxValueIsSuppliedAsBirthday()
    {
        var exception = Assert.Throws<ArgumentException>("birthday", () => new Birthday.Builder().BornOn(DateOnly.MaxValue).BeingToday(TODAY).Build());
        Assert.StartsWith("Invalid birthday", exception.Message);
    }

    [Fact]
    public void ThrowException_WhenMinValueIsSuppliedAsToday()
    {
        var exception = Assert.Throws<ArgumentException>("today", () => new Birthday.Builder().BornOn(RAISTLIN_BIRTHDAY).BeingToday(DateOnly.MinValue).Build());
        Assert.StartsWith("Invalid today", exception.Message);
    }

    [Fact]
    public void ThrowException_WhenMaxValueIsSuppliedAsToday()
    {
        var exception = Assert.Throws<ArgumentException>("today", () => new Birthday.Builder().BornOn(RAISTLIN_BIRTHDAY).BeingToday(DateOnly.MaxValue).Build());
        Assert.StartsWith("Invalid today", exception.Message);
    }

    [Fact]
    public void ThrowException_WhenBirthdayComesAfterToday()
    {
        var exception = Assert.Throws<ArgumentException>("birthday", () => new Birthday.Builder().BornOn(TODAY).BeingToday(RAISTLIN_BIRTHDAY).Build());
        Assert.StartsWith("Cannot be born after today", exception.Message);
    }

    [Fact]
    public void ThrowException_WhenMoreThan300YearsAreSupplied()
    {
        var exception = Assert.Throws<ArgumentException>("birthday", () => new Birthday.Builder().BornOn(AMERICA_DISCOVERY).BeingToday(TODAY).Build());
    }

    // TODO: BVA for 300y - 1d, 300y, 300y + 1d
}