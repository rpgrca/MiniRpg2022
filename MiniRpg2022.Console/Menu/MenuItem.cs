using System.Globalization;
using Videogame;

namespace MiniRpg2022.Console;

public abstract class MenuItem
{
    public int Index { get; }
    public string Text { get; }
    public abstract bool Execute(Configuration configuration);

    protected MenuItem(int index, string text)
    {
        Index = index;
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
}