using System.Globalization;
using Videogame;

namespace MiniRpg2022.Console;

public class Messaging : IMessaging
{
    private readonly IConsole _console;

    public Messaging(IConsole console) => _console = console;

    public string Choose(string prompt, IEnumerable<string> options)
    {
        string? answer;
        do
        {
            _console.WriteLine($"- {prompt} [{string.Join(", ", options)}]: ");
            answer = _console.ReadLine();
        }
        while (!options.Contains(answer));
        return answer!;
    }

    public string? Prompt(string prompt, Func<string?, bool> conditionCallback)
    {
        string? answer;
        do
        {
            _console.WriteLine($"- {prompt}: ");
            answer = _console.ReadLine();
        }
        while (conditionCallback(answer));

        return answer;
    }

    public string? Prompt() => _console.ReadLine();

    public DateOnly PromptDate(string prompt, string format)
    {
        DateOnly result;
        string? answer;
        do
        {
            _console.WriteLine($"- {prompt} ({format}): ");
            answer = _console.ReadLine();
        }
        while (!DateOnly.TryParseExact(answer, new[] { format }, CultureInfo.InvariantCulture, DateTimeStyles.None, out result));

        return result;
    }

    public int PromptRange(string prompt, int minimum, int maximum)
    {
        do
        {
            _console.WriteLine($"- {prompt} ({minimum}..{maximum}): ");
            var answer = _console.ReadLine();
            if (int.TryParse(answer, out int value))
            {
                if (minimum <= value && value <= maximum)
                {
                    return value;
                }
            }
        } while (true);
    }

    public void Show(string text) => _console.WriteLine(text);
}