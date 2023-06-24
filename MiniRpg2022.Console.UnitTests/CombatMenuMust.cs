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

    [Fact]
    public void ShowCorrectMessage_WhenThereAreNoCharactersAlive()
    {
        var sut = new CombatMenu();
        var spy = new ConsoleStub();
        var configuration = ObtainConfiguration(spy);
        sut.Execute(configuration);

        Assert.Collection(spy.WrittenText,
            p1 => Assert.Equal("No loaded characters still.", p1));
    }
}