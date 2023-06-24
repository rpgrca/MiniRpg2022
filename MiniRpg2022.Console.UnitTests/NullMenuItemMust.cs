using Xunit;

namespace MiniRpg2022.Console.UnitTests;

public class NullMenuItemMust
{
    [Fact]
    public void ReturnEmptyMenuDescription()
    {
        var sut = new NullMenuItem();
        Assert.Empty(sut.Text);
    }
}