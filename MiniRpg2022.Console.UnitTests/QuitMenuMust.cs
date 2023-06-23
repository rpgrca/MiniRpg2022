using Videogame;
using Xunit;

namespace MiniRpg2022.Console.UnitTests;

public class QuitMenuMust
{
    [Fact]
    public void ReturnCorrectMenuDescription()
    {
        var sut = new QuitMenu();
        Assert.Equal("Quit", sut.Text);
    }

    [Fact]
    public void ReturnTrue_WhenQuitMenuReadsY()
    {
        var sut = new QuitMenu();
        var stub = new ConsoleStub(new[] { "Y" });
        Assert.True(sut.Execute(ObtainConfiguration(stub)));
    }

    private static Configuration ObtainConfiguration(IConsole stub) =>
        new(2022, 11, 30, new Messaging(stub));

    [Fact]
    public void ReturnFalse_WhenQuitMenuReadsN()
    {
        var sut = new QuitMenu();
        var stub = new ConsoleStub(new[] { "N" });
        Assert.False(sut.Execute(ObtainConfiguration(stub)));
    }

    [Fact]
    public void DisplayCorrectPrompt()
    {
        var sut = new QuitMenu();
        var spy = new ConsoleStub(new[] { "Y" });
        sut.Execute(ObtainConfiguration(spy));
        Assert.Collection(spy.WrittenText, p => Assert.Equal("- Are you sure? [Y, N]: ", p));
    }

    [Fact]
    public void RetryCorrectly()
    {
        var sut = new QuitMenu();
        var spy = new ConsoleStub(new[] { "P", "Y" });
        sut.Execute(ObtainConfiguration(spy));
        Assert.Collection(spy.WrittenText,
            p1 => Assert.Equal("- Are you sure? [Y, N]: ", p1),
            p2 => Assert.Equal("- Are you sure? [Y, N]: ", p2));
    }
}