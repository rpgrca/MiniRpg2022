using Xunit;
using static MiniRpg2022.Console.UnitTests.Constants;

namespace MiniRpg2022.Console.UnitTests;

public class CombatMenuMust
{
    [Fact]
    public void ReturnCorrectDisplayText()
    {
        var sut = new CombatMenu();
        Assert.Equal("Combat", sut.Text);
    }
}