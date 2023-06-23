namespace MiniRpg2022.Console;

public class Console : IConsole
{
    public string? ReadLine() => System.Console.ReadLine();

    public void WriteLine(string text) => System.Console.WriteLine(text);
}