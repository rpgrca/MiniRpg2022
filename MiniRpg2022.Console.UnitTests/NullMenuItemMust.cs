using Xunit;
using static MiniRpg2022.Console.UnitTests.Constants;

namespace MiniRpg2022.Console.UnitTests;

public class NullMenuItemMust
{
    [Fact]
    public void ReturnEmptyMenuDescription()
    {
        var sut = new NullMenuItem();
        Assert.Empty(sut.Text);
    }

    [Fact]
    public void ReturnFalse()
    {
        var sut = new NullMenuItem();
        var configuration = ObtainConfiguration(new DummyConsole());
        Assert.False(sut.Execute(configuration));
    }
}