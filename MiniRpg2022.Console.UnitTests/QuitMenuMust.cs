using MiniRpg2022.Console;
using System.Collections.Generic;
using Videogame;
using Xunit;

namespace MiniRpg2022.Console.UnitTests;

public class QuitMenuMust
{
    public class TestableQuitMenu : QuitMenu
    {
        private readonly string[] _readText;
        private int _index;

        public List<string> WrittenText { get; private set; }

        public TestableQuitMenu(string[] readText)
        {
            _index = 0;
            _readText = readText;
            WrittenText = new List<string>();
        }

        protected override void WriteToConsole(string text) =>
            WrittenText.Add(text);

        protected override string? ReadLineFromConsole() => _readText[_index++];
    }

    [Fact]
    public void ReturnTrue_WhenQuitMenuReadsY()
    {
        var sut = new TestableQuitMenu(new[] { "Y" });
        Assert.True(sut.Execute(ObtenerConfiguracion()));
    }

    private static Configuration ObtenerConfiguracion() => new(2022, 11, 30);

    [Fact]
    public void ReturnFalse_WhenQuitMenuReadsN()
    {
        var sut = new TestableQuitMenu(new[] { "N" });
        Assert.False(sut.Execute(ObtenerConfiguracion()));
    }

    [Fact]
    public void DisplayCorrectPrompt()
    {
        var sut = new TestableQuitMenu(new[] { "Y" });
        sut.Execute(ObtenerConfiguracion());
        Assert.Collection(sut.WrittenText, p => Assert.Equal("- Are you sure? [Y, N]: ", p));
    }

    [Fact]
    public void RetryCorrectly()
    {
        var sut = new TestableQuitMenu(new[] { "P", "Y" });
        sut.Execute(ObtenerConfiguracion());
        Assert.Collection(sut.WrittenText,
            p1 => Assert.Equal("- Are you sure? [Y, N]: ", p1),
            p2 => Assert.Equal("- Are you sure? [Y, N]: ", p2));
    }
}
