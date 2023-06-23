using System.Globalization;
using Videogame;

namespace MiniRpg2022.Console;

public abstract class MenuItem
{
    public string Text { get; }

    public abstract bool Execute(Configuration configuration);

    protected MenuItem(string text)
    {
        Text = text;
    }

    protected string Choose(string prompt, IEnumerable<string> options)
    {
        string? answer;
        do
        {
            WriteToConsole($"- {prompt} [{string.Join(", ", options)}]: ");
            answer = ReadLineFromConsole();
        }
        while (! options.Contains(answer));
        return answer!;
    }

    protected string? Prompt(string prompt, Func<string?, bool> conditionCallback)
    {
        string? answer;
        do
        {
            WriteToConsole($"- {prompt}: ");
            answer = ReadLineFromConsole();
        }
        while (conditionCallback(answer));

        return answer;
    }

    protected DateOnly PromptDate(string prompt, string format)
    {
        DateOnly result;
        string? answer;
        do
        {
            WriteToConsole($"- {prompt} ({format}): ");
            answer = ReadLineFromConsole();
        }
        while (!DateOnly.TryParseExact(answer, new [] { format }, CultureInfo.InvariantCulture, DateTimeStyles.None, out result));

        return result;
    }

    protected int PromptRange(string prompt, int minimum, int maximum)
    {
        do
        {
            WriteToConsole($"- {prompt} ({minimum}..{maximum}): ");
            var answer = ReadLineFromConsole();
            if (int.TryParse(answer, out int value))
            {
                if (minimum <= value && value <= maximum)
                {
                    return value;
                }
            }
        } while (true);
    }

    protected virtual void WriteToConsole(string text) =>
        System.Console.Write(text);

    protected virtual string? ReadLineFromConsole() =>
        System.Console.ReadLine();
}