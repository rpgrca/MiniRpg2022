using MiniRpg2022.Console;
using Xunit;

namespace MiniRpg2022.Console.UnitTests;

public class QuitMenuMust
{
    public class TestableQuitMenu : QuitMenu
    {
        private string? _readText;
        public string WrittenText { get; private set; }

        public TestableQuitMenu(string? readText) => _readText = readText;

        protected override void WriteToConsole(string text) => WrittenText = text;

        protected override string? ReadLineFromConsole() => _readText;
    }

    [Fact]
    public void ReturnTrue_WhenQuitMenuReadsY()
    {
        var sut = new TestableQuitMenu("Y");
        Assert.True(sut.Execute(null));
    }

    [Fact]
    public void ReturnFalse_WhenQuitMenuReadsN()
    {
        var sut = new TestableQuitMenu("N");
        Assert.False(sut.Execute(null));
    }
}
