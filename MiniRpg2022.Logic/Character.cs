namespace Videogame;

public class Character
{
    public string Name { get; }

    public Character(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name", nameof(name));
        Name = name;
    }
}