using Videogame;

namespace MiniRpg2022.UnitTests;

public class BirthdayMust
{
    [Fact]
    public void ThrowException_WhenInvalidBirthdayIsSupplied()
    {
        var exception = Assert.Throws<ArgumentException>("birthday", () => new Birthday.Builder().Build());
        Assert.StartsWith("Invalid birthday", exception.Message);
    }
}
