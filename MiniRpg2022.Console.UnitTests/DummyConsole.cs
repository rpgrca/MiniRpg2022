namespace MiniRpg2022.Console.UnitTests;

public class DummyConsole : IConsole
{
    public string? ReadLine() => string.Empty;

    public void WriteLine(string text)
    {
    }
}