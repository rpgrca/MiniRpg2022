namespace Videogame;

public interface IMessaging
{
    string Choose(string prompt, IEnumerable<string> options);
    string? Prompt(string prompt, Func<string?, bool> conditionCallback);
    DateOnly PromptDate(string prompt, string format);
    int PromptRange(string prompt, int minimum, int maximum);
    string? Prompt();
    void Show(string text);
}
