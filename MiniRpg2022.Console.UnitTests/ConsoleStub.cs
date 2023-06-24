namespace MiniRpg2022.Console.UnitTests;

public class ConsoleStub : IConsole
{
    private readonly string[] _readText;
    private int _index;
    public List<string> WrittenText { get; private set; }

    public string? ReadLine() => _readText[_index++];

    public void WriteLine(string text) => WrittenText.Add(text);

    public ConsoleStub(string[] readText)
    {
        _index = 0;
        _readText = readText;
        WrittenText = new List<string>();
    }

    public ConsoleStub()
        : this(Array.Empty<string>())
    {
    }
}