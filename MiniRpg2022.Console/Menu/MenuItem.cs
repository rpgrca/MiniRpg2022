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
            System.Console.Write($"- {prompt} [{string.Join(", ", options)}]: ");
            answer = System.Console.ReadLine();
        }
        while (! options.Contains(answer));
        return answer;
    }

    protected string Prompt(string prompt, Func<string?, bool> conditionCallback)
    {
        string? answer;
        do
        {
            System.Console.Write($"- {prompt}: ");
            answer = System.Console.ReadLine();
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
            System.Console.Write($"- {prompt} ({format}): ");
            answer = System.Console.ReadLine();
        }
        while (!DateOnly.TryParseExact(answer, new [] { format }, CultureInfo.InvariantCulture, DateTimeStyles.None, out result));

        return result;
    }

    protected int PromptRange(string prompt, int minimum, int maximum)
    {
        do
        {
            System.Console.Write($"- {prompt} ({minimum}..{maximum}): ");
            var answer = System.Console.ReadLine();
            if (int.TryParse(answer, out int value))
            {
                if (minimum <= value && value <= maximum)
                {
                    return value;
                }
            }
        } while (true);
    }
}