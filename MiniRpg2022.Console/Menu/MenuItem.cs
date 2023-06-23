using Videogame;

namespace MiniRpg2022.Console;

public abstract class MenuItem
{
    public string Text { get; }

    public abstract bool Execute(Configuration configuration);

    protected MenuItem(string text) => Text = text;
}